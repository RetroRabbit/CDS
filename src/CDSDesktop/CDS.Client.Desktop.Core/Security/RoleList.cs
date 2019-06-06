using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.Desktop.Core.Security
{
    public partial class RoleList : CDS.Client.Desktop.Essential.BaseList
    {
        public RoleList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowNewRecord = BL.SEC.SecurityLibrary.AccessGranted(BL.SEC.AccessCodes.SYSERLRECR);
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

                RoleForm childForm = new RoleForm(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                RoleForm childForm = new RoleForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYSERLRECR);
        } 
    }
}
