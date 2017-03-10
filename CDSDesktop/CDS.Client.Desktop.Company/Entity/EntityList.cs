using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BL = CDS.Client.BusinessLayer;
using System.Linq;

namespace CDS.Client.Desktop.Company.Entity
{
    public partial class EntityList : CDS.Client.Desktop.Essential.BaseList
    {
        List<Object> customers;
        List<Object> suppliers;


        public EntityList()
        {
            InitializeComponent();
            setLists();
        }

        protected override void OnNewRecord()
        {
            base.OnNewRecord();

            EntityForm childform = new EntityForm();
            ShowForm(childform);
        }

        protected override void OnOpenRecord(long Id)
        {
            try
            {
                base.OnOpenRecord(Id);

                if (Id != -1)
                {
                    EntityForm childform = new EntityForm(Id);
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
            AllowNewRecord = BL.ApplicationDataContext.Instance.AccessGranted(BL.SEC.AccessCodes.ORENRECR);
        }

        protected override void OnRefresh()
        {
            base.OnRefresh();
            setLists();
        }
        //Sets the lists that are used to dynamically set 'Has Supplier' and 'Has Customer' fields
        //Sean Hill 13/9/2014
        private void setLists()
        {
            long? defaultSiteId = BL.ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId;
            customers = DataContext.EntityOrganisationContext.ORG_Company.Where(n => n.SiteId == defaultSiteId && n.TypeId == 1).Select(n => n.EntityId).ToList().ConvertAll(a => (Object)a);
            suppliers = DataContext.EntityOrganisationContext.ORG_Company.Where(n => n.SiteId == defaultSiteId && n.TypeId == 2).Select(n => n.EntityId).ToList().ConvertAll(a => (Object)a);
        }

        //Dynamically sets 'Has Supplier' and 'Has Customer' fields
        //Sean Hill 13/9/2014
        private void GridView_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            List<object> temp;
            if (e.Column.FieldName == "hasSupplier")
                temp = suppliers;
            else
                temp = customers;


            if (temp.Contains(GridView.GetRowCellValue(e.ListSourceRowIndex, "Id")))
            {
                e.Value = true;
            }
            else e.Value = false;
        }
    }
}
