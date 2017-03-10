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

namespace CDS.Client.Desktop.Stock.Inventory
{
    public partial class DiscountList : CDS.Client.Desktop.Essential.BaseList
    {
        public DiscountList()
        {
            InitializeComponent();
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                DiscountForm childForm = new DiscountForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            { 
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {
                    DiscountForm childForm = new DiscountForm(Id);
                    ShowForm(childForm);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDIRECR);
        } 
    }
}
