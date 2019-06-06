using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;


namespace CDS.Client.Desktop.Accounting.Payment.Bulk
{
    public partial class BulkReceiptsForm : CDS.Client.Desktop.Accounting.Payment.Bulk.BaseBulkPaymentForm
    {
        public BulkReceiptsForm()
        {
            InitializeComponent();
        }

        protected override bool SaveSuccessful()
        {
            try
            {
                using (new CDS.Client.Desktop.Essential.UTL.WaitCursor())
                {
                    this.OnSaveRecord();
                    if (!IsValid)
                        return false;

                    foreach (BulkPaymentEntry mainLine in BulkPaymentEntries)
                    {
                        Int64 trackingNumber = -1;
                        // Make a new header entry
                        DB.GLX_Header header = BL.GLX.GLX_Header.New;
                        header.TrackId = -1;
                        header.PeriodId = mainLine.PeriodId.Value;
                        header.ReferencePeriodId = mainLine.PeriodId.Value;
                        header.Date = mainLine.Date.Value;
                        header.PostedDate = BL.ApplicationDataContext.Instance.ServerDateTime.Date;
                        header.Reference = mainLine.Reference;
                        header.Description = mainLine.Description;
                        header.StatusId = 52;
                        if (mainLine.Amount >= 0)
                        {
                            header.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Receipts;
                        }
                        else
                        {
                            header.JournalTypeId = (byte)BL.GLX.GLX_JournalType.Reversal;
                        }

                        //Double check if this has a use
                        if (!trackingNumber.Equals(-1))
                            header.TrackId = trackingNumber;

                        //Loop through INV or C/N or BBF (Agings)
                        foreach (var agingAmount in mainLine.BulkPaymentItems.Where(n => n.Checked.Equals(true)).GroupBy(g => g.AgingId).Select(l => new { AgingId = l.Key, Balance = l.Sum(i => i.Balance) }))
                        {
                            //DEBTOR LINE
                            DB.GLX_Line linedebtor = BL.GLX.GLX_Line.New;
                            //TODO: ACCOUNT NOT LOADING ON subLine
                            linedebtor.EntityId = mainLine.AccountId.Value;
                            linedebtor.AgingId = agingAmount.AgingId;
                            linedebtor.Amount = -agingAmount.Balance;
                            header.GLX_Line.Add(linedebtor);
                        }

                        //BANK LINE
                        DB.GLX_Line linebank = BL.GLX.GLX_Line.New;
                        linebank.EntityId = Convert.ToInt64(ddlAccount.EditValue);
                        linebank.AgingId = 1;
                        linebank.Amount = mainLine.Amount;
                        header.GLX_Line.Add(linebank);
                        if (mainLine.Settlement != 0)
                        {
                            //SETTLEMENT DISCOUNT TAX LINE
                            DB.GLX_Line linesettlementtax = BL.GLX.GLX_Line.New;
                            DB.GLX_Tax taxType = DataContext.EntityAccountingContext
                                                .GLX_Tax.FirstOrDefault(n => n.Id == PaymentAccounts
                                                    .Where(nn => nn.AccountId.Equals(((DB.GLX_Account)ddlSettlementAccount.GetSelectedDataRow()).Id))
                                                    .Select(nn => nn.TaxId).FirstOrDefault());
                            if (taxType != null && taxType.Percentage != 0)
                            {
                                linesettlementtax.Amount = mainLine.Settlement * (1 - taxType.Percentage);
                            }
                            else
                            {
                                linesettlementtax.Amount = mainLine.Settlement;
                            }

                            header.GLX_Line.Add(linesettlementtax);
                            //SETTLEMENT DISCOUNT LINE
                            DB.GLX_Line linesettlement = BL.GLX.GLX_Line.New;
                            linesettlement.EntityId = Convert.ToInt64(ddlSettlementAccount.EditValue);
                            linesettlement.AgingId = 1;
                            linesettlement.Amount = mainLine.Settlement - linesettlementtax.Amount;
                            header.GLX_Line.Add(linesettlement);
                        }
                        
                        //Change the subLines's tracking number to the new tracking number
                        foreach (var subLine in mainLine.BulkPaymentItems.Where(n => n.Checked.Equals(true)))
                        {
                            BL.GLX.GLX_Header.UpdateTrackNumber(subLine.HeaderId, trackingNumber, DataContext);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
            IsValid = ValidateBeforeSave();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE07);
        }

        public override DataTable GetPaymentItems(List<Int64> accounts)
        {
            return BL.GLX.GLX_Header.GetReceivable(BL.SYS.SYS_Period.GetCurrentPeriod(DataContext), String.Format("AccountId in ({0})", string.Join(",", accounts)),DataContext);
        }

    }
}
