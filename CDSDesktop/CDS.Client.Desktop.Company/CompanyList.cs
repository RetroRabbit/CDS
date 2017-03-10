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

namespace CDS.Client.Desktop.Company
{
    public partial class CompanyList : CDS.Client.Desktop.Essential.BaseList
    {
        public BL.ORG.ORG_Type Type;

        public CompanyList(BL.ORG.ORG_Type type)
        {
            InitializeComponent();
            this.Type = type;
        }

        protected override void OnStart()
        {
            base.OnStart();
            XPOInstantFeedbackSource.FixedFilterCriteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[TypeId.Id] = ? && [SiteId.Id] = ?", (byte)Type, BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
        }

        protected override void BindData()
        {
            try
            {
                base.BindData();

                switch (Type)
                {
                    case BL.ORG.ORG_Type.Supplier:
                        this.Text = "Suppliers";
                        break;
                    case BL.ORG.ORG_Type.Customer:
                        this.Text = "Customers";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            //We do not allow New from companies list screens anymore - Must create companies from ORG_Entity
            AllowNewRecord = false;
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            DevExpress.XtraEditors.XtraForm childform = null;

            switch (Type)
            {
                case BL.ORG.ORG_Type.Customer:
                    childform = new Customer.CustomerForm();
                    ShowForm(childform);
                    break;
                case BL.ORG.ORG_Type.Supplier:
                    childform = new Supplier.SupplierForm();
                    ShowForm(childform);
                    break;
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {

                    Essential.BaseForm childform = null;

                    switch (Type)
                    {
                        case BL.ORG.ORG_Type.Customer:
                            childform = new Customer.CustomerForm(Id);
                            break;
                        case BL.ORG.ORG_Type.Supplier:
                            childform = new Supplier.SupplierForm(Id);
                            break;
                    }

                    ShowForm(childform);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }
    }
}
