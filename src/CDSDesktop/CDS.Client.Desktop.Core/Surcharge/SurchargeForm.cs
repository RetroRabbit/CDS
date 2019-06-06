using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;
using System.Transactions;   

namespace CDS.Client.Desktop.Core.Surcharge
{
    public partial class SurchargeForm : CDS.Client.Desktop.Essential.BaseForm
    {
         DB.SYS_Entity sysEntity;
         DB.SYS_Surcharge sysSurcharge;
        public SurchargeForm()
        {
            InitializeComponent();
        }

        public SurchargeForm(Int64 id)
        {
            InitializeComponent();
            base.ItemState = EntityState.Open;
            base.Id = id;
        }

        protected override void OnStart()
        {
            base.OnStart();
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            BindingSourceAccount.DataSource = DataContext.ReadonlyContext.VW_Account.Where(n => n.AccountTypeId == (byte)BL.GLX.GLX_Type.Sales && n.SiteId == defaultSiteId).ToList();
        
    }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowSave = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INSUREED);
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();
            sysEntity = BL.SYS.SYS_Entity.NewSurcharge;
            sysSurcharge = BL.SYS.SYS_Surcharge.New;

            sysEntity.SYS_Surcharge.Add(sysSurcharge);
        }

        public override void OpenRecord(long Id)
        {
            base.OpenRecord(Id);
            sysSurcharge =  BL.SYS.SYS_Surcharge.Load(Id, DataContext, new List<string> { "SYS_Entity" });
            sysEntity = sysSurcharge.SYS_Entity;
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
                    try
                    {
                        using (TransactionScope transaction = DataContext.GetTransactionScope())
                        {
                            BL.EntityController.SaveSYS_Entity(sysEntity, DataContext);
                            DataContext.SaveChangesEntitySystemContext();
                            //DataContext.SaveChangesEntityAccountingContext();
                            sysSurcharge.EntityId = sysEntity.Id;
                            sysSurcharge.AccountId = (long)ddlAccount.EditValue;
                            DataContext.SaveChangesEntitySystemContext();
                            DataContext.CompleteTransaction(transaction);
                        }
                        //DataContext.EntityAccountingContext.AcceptAllChanges();
                        DataContext.EntitySystemContext.AcceptAllChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        DataContext.EntityAccountingContext.RejectChanges();
                        HasErrors = true;
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                return false;
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindingSource.DataSource = sysSurcharge;
            BindingSourceEntity.DataSource = sysEntity;
        }

        private void ddlAccount_EditValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
