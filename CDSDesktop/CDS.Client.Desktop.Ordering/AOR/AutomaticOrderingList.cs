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

namespace CDS.Client.Desktop.Ordering.AOR
{
    public partial class AutomaticOrderingList : CDS.Client.Desktop.Essential.BaseList
    {
        public AutomaticOrderingList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void BindData()
        {
            base.BindData();
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);
                AutomaticOrderingForm childForm = new AutomaticOrderingForm(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            AutomaticOrderingForm childForm = new AutomaticOrderingForm();
            ShowForm(childForm);
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INAORECR);
        } 
    }
}
