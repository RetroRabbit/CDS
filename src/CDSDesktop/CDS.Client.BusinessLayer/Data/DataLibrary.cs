using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.Data
{
    public class DataLibrary
    {
        //public static DB.EntityTables GetContext()
        //{
        //    DB.EntityTables context = new DB.EntityTables(ApplicationDataContext.Instance.SqlConnectionString.ConnectionString) { };
        //    ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 120;
        //    //((IObjectContextAdapter)context).ObjectContext.ContextOptions.ProxyCreationEnabled = false;
        //    //((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        //    return context;
        //}

        internal static DB.EntityViews GetReadonlyContext()
        {
            DB.EntityViews context = new DB.EntityViews(ApplicationDataContext.Instance.EntityViewConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 120;
            //((IObjectContextAdapter)context).ObjectContext.ContextOptions.ProxyCreationEnabled = false;
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.AccountingEntityTables GetAccountingContext()
        {
            DB.AccountingEntityTables context = new DB.AccountingEntityTables(ApplicationDataContext.Instance.AccountingConnectionString.ConnectionString) { }; 
            //((IObjectContextAdapter)context).ObjectContext.ContextOptions.ProxyCreationEnabled = false;
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.BuyoutEntityTables GetBuyoutContext()
        {
            DB.BuyoutEntityTables context = new DB.BuyoutEntityTables(ApplicationDataContext.Instance.BuyoutConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.CatalogueEntityTables GetCatalogueContext()
        {
            DB.CatalogueEntityTables context = new DB.CatalogueEntityTables(ApplicationDataContext.Instance.CatalogueConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.CalendarEntityTables GetCalendarContext()
        {
            DB.CalendarEntityTables context = new DB.CalendarEntityTables(ApplicationDataContext.Instance.CalendarConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.InventoryEntityTables GetInventoryContext()
        {
            DB.InventoryEntityTables context = new DB.InventoryEntityTables(ApplicationDataContext.Instance.InventoryConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.OrganisationEntityTables GetOrganisationContext()
        {
            DB.OrganisationEntityTables context = new DB.OrganisationEntityTables(ApplicationDataContext.Instance.OrganisationConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.ReportEntityTables GetReportContext()
        {
            DB.ReportEntityTables context = new DB.ReportEntityTables(ApplicationDataContext.Instance.ReportConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.SecurityEntityTables GetSecurityContext()
        {
            DB.SecurityEntityTables context = new DB.SecurityEntityTables(ApplicationDataContext.Instance.SecurityConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.SystemEntityTables GetSystemContext()
        {
            DB.SystemEntityTables context = new DB.SystemEntityTables(ApplicationDataContext.Instance.SystemConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.WorkshopEntityTables GetWorkshopContext()
        {
            DB.WorkshopEntityTables context = new DB.WorkshopEntityTables(ApplicationDataContext.Instance.WorkshopConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.HumanResourcesEntityTables GetHumanResourcesContext()
        {
            DB.HumanResourcesEntityTables context = new DB.HumanResourcesEntityTables(ApplicationDataContext.Instance.HumanResourcesConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }

        internal static DB.OrderingEntityTables GetOrderingContext()
        {
            DB.OrderingEntityTables context = new DB.OrderingEntityTables(ApplicationDataContext.Instance.OrderingConnectionString.ConnectionString) { };
            ((IObjectContextAdapter)context).ObjectContext.ContextOptions.LazyLoadingEnabled = false;
            return context;
        }
    }
}
