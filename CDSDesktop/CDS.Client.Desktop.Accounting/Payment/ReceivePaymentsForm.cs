using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CDS.Client.Desktop.Essential.UTL;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;


namespace CDS.Client.Desktop.Accounting.Payment
{
    public partial class ReceivePaymentsForm : CDS.Client.Desktop.Accounting.Payment.BasePaymentsForm
    {
        public ReceivePaymentsForm()
        {
            InitializeComponent();
        }

        public ReceivePaymentsForm(Int64 Id)
            :base(Id)
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
                     
                    Dictionary<string, BL.GLX.PaymentAccount> paymentAccounts = new Dictionary<string, BL.GLX.PaymentAccount>();

                    foreach (DevExpress.XtraGrid.Columns.GridColumn pa in PaymentGridView.Columns)
                    {
                        if (((DevExpress.XtraGrid.Columns.GridColumn)PaymentGridView.Columns[pa.FieldName]).Tag is CDS.Client.BusinessLayer.GLX.PaymentAccount)
                            paymentAccounts.Add(pa.FieldName, (BL.GLX.PaymentAccount)((DevExpress.XtraGrid.Columns.GridColumn)PaymentGridView.Columns[pa.FieldName]).Tag);
                    }

                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            foreach (DB.GLX_Header header in BL.GLX.GLX_Header.CreateReceipts(entriesDataSource.Select("colCheck=1"),accountsColumns,paymentAccounts,DataContext))
                            {
                                if (header.TrackId == -1)
                                {
                                    DB.SYS_Tracking sysTracking = BL.SYS.SYS_Tracking.New;
                                    BL.EntityController.SaveSYS_Tracking(sysTracking, DataContext);
                                    DataContext.SaveChangesEntitySystemContext();
                                    header.TrackId = sysTracking.Id;
                                } 

                                BL.EntityController.SaveGLX_Header(header, DataContext);
                                BL.GLX.GLX_Header.UpdateLedgerAccountBalance(header, DataContext);
                                DataContext.SaveChangesEntitySystemContext();
                                DataContext.SaveChangesEntityAccountingContext();
                            }
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.SaveChangesEntityAccountingContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        DataContext.EntityAccountingContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntitySystemContext.RejectChanges();
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Created: Theo Crous 13/08/2012</remarks>
        protected override void OnSaveRecord()
        {
            base.OnSaveRecord();
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE04);
            btnAddAdditionalPayment.Visibility = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.FIENRE04) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = BL.GLX.GLX_Header.GetReceivable(BL.SYS.SYS_Period.GetCurrentPeriod(DataContext), DataContext);
            PopulateColumns();
        }
    }
}
