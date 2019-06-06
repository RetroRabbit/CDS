using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;

namespace CDS.Client.Desktop.Stock.BOM
{
    public partial class BOMDocumentList : CDS.Client.Desktop.Essential.BaseList
    {
        public BOMDocumentList()
        {
            InitializeComponent();
        } 

        protected override void OnStart()
        {
            try
            {
                base.OnStart();
                AllowNewRecord = false;
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
                BOMDocumentForm childForm = new BOMDocumentForm();
                childForm.OpenRecord(Id);
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
            //Henko - TODO: BOM Security roles removed... Will implement later
            //AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.INDOBM01);
        }
    }
}
