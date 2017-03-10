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

namespace CDS.Client.Desktop.Core.Abbreviation
{
    public partial class AbbreviationList : CDS.Client.Desktop.Essential.BaseList
    {
        public AbbreviationList()
        {
            InitializeComponent();
        }         

        /// <summary>
        /// Open the Abbreviations form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Werner Scheffer 13/12/2011</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                AbbreviationForm childForm = new AbbreviationForm();
                childForm.OpenRecord(Id);
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Abbreviations form with blank data so that a new record may be entered.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 13/12/2011</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();

                AbbreviationForm childForm = new AbbreviationForm();
                ShowForm(childForm);
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 
    }
}
