using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CDS.Client.Desktop.Essential
{
    public partial class BaseListEdit : CDS.Client.Desktop.Essential.BaseList
    {
        public BaseListEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets whether or not the Edit button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/11/2015</remarks>
        [BrowsableAttribute(true)]
        public bool AllowEdit
        {
            get
            {
                return this.btnEdit.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnEdit.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Undo button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/11/2015</remarks>
        [BrowsableAttribute(true)]
        public bool AllowUndo
        {
            get
            {
                return this.btnUndo.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnUndo.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Sets whether or not the Save button is displayed for this list.
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/11/2015</remarks>
        [BrowsableAttribute(true)]
        public bool AllowSave
        {
            get
            {
                return this.btnSave.Visibility == DevExpress.XtraBars.BarItemVisibility.Always;
            }
            set
            {
                this.btnSave.Visibility = (value) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        /// <summary>
        /// Disables all the columns on GridView
        /// </summary>
        /// <remarks>Created: Werner Scheffer 24/11/2015</remarks>
        public void DisableColumns()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in GridView.Columns)
            {
                column.OptionsColumn.AllowEdit = false;
            }
        }

        protected override void XPOPreBindDataFilter()
        {
            base.XPOPreBindDataFilter();            
        }

        protected override void ApplySecurity()
        {
            base.ApplySecurity();
            AllowOpenRecord = false;
        }

        protected override void BindData()
        {
            base.BindData();
            GridView.OptionsBehavior.Editable = true;
            GridControl.DataSource = XPCollection;
        } 
    }
}
