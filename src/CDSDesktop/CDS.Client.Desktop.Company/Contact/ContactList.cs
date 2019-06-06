using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Company.Contact
{
    public partial class ContactList : CDS.Client.Desktop.Essential.BaseList
    {
        public ContactList()
        {
            InitializeComponent();
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            ContactForm childform = new ContactForm();
            ShowForm(childform);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {
                    ContactForm childform = new ContactForm(Id);
                    ShowForm(childform);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORCORECR);
        }
    }
}
