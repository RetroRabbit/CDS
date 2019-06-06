﻿using CDS.Client.Desktop.HRS;
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

namespace CDS.Client.Desktop.HumanResources.Employee
{
    public partial class EmployeeList : CDS.Client.Desktop.Essential.BaseList
    {
        public EmployeeList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the data.
        /// </summary>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnStart()
        {
            try
            {
                base.OnStart(); 
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        } 

        /// <summary>
        /// Open a new record
        /// </summary>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnNewRecord()
        {
            try
            {
                base.OnNewRecord();
                ShowForm(new EmployeeForm());
            }
            catch (Exception ex)
            {
                if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
            }
        }

        /// <summary>
        /// Open the Employee form for the record indicated in the parameter.
        /// </summary>
        /// <param name="Id">The id (primary key) of the record to open.</param>
        /// <remarks>Created: Theo Crous 24/07/2012</remarks>
        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                EmployeeForm childForm = new EmployeeForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.HREMRECR);
        }
    }
}
