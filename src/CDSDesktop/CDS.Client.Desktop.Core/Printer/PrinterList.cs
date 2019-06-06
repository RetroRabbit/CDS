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


namespace CDS.Client.Desktop.Core.Printer
{
    public partial class PrinterList : CDS.Client.Desktop.Essential.BaseList
    {
        public PrinterList()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {
                    PrinterForm childForm = new PrinterForm(Id);
                    ShowForm(childForm);
                }
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }


        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            PrinterForm childform = new PrinterForm();
            ShowForm(childform);
        }

        protected override void BindData()
        {
            base.BindData();
        } 

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.SYPRRECR);
        }
    }
}
