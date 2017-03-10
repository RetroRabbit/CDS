using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;


namespace CDS.Client.BusinessLayer
{
    public class ApplicationDataContext
    {

        //private CDS.Client.BusinessLayer.DB.EntityTables context;
        //private CDS.Client.BusinessLayer.DB.EntityViews readonlyContext;

        private DataContext dataContext;

        private static ApplicationDataContext instance;

        private DB.SEC_User loggedInUser;

        private SYS.CompanySite companySite;

        private GLX.SiteAccounts siteAccounts;

        private List<DB.VW_Validation> validationRestrictions = new List<DB.VW_Validation>();

        private List<DB.SYS_Module> modules = new List<DB.SYS_Module>();

        private List<DB.SYS_Abbreviation> abbreviations = new List<DB.SYS_Abbreviation>();

        private int sqlCommandTimeOut = 60;

        public BL.CDSWebService.CDSServiceClient Service { get { return new CDSWebService.CDSServiceClient("BasicHttpBinding_ICDSService", CompanySite.PrintServerLocation); } }

        private static List<Int64> profitDistributionEntriesRequired;

        private SqlConnection sqlConnection;

        private SqlTransaction sqlTransaction;

        private DateTime serverDateTime;

        private bool hasMultipleSites;

        public bool HasMultipleSites
        {
            get
            {
                if (hasMultipleSites == null)
                    hasMultipleSites = ReadonlyContext.VW_Site.Count() > 1;

                return hasMultipleSites;
            }
        }

        public ApplicationDataContext()
        {
        }

        public static ApplicationDataContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApplicationDataContext();

                return instance;
            }
        }

        public void Reload()
        {
            companySite = null;
            siteAccounts = null;
        }

        public SYS.CompanySite CompanySite
        {
            get
            {
                if (companySite == null)
                    companySite = new SYS.CompanySite();

                return companySite;
            }
            internal set { companySite = value; }
        }

        public GLX.SiteAccounts SiteAccounts
        {
            get
            {
                if (siteAccounts == null)
                    siteAccounts = new GLX.SiteAccounts();

                return siteAccounts;
            }
            internal set { siteAccounts = value; }
        }

        public DataContext DataContext
        {
            get
            {
                if (dataContext == null)
                    dataContext = new BL.DataContext();

                return dataContext;
            }
        }

        public DB.SystemEntityTables SystemEntityContext
        {
            get { return DataContext.EntitySystemContext; }
        }

        public DB.SecurityEntityTables SecurityEntityContext
        {
            get { return DataContext.EntitySecurityContext; }
        }

        public DB.AccountingEntityTables AccountingEntityContext
        {
            get { return DataContext.EntityAccountingContext; }
        }

        public DB.EntityViews ReadonlyContext
        {
            get { return DataContext.ReadonlyContext; }
        }

        ///// <summary>
        ///// This property is used to Insert/Update and Delete only
        ///// </summary>
        //public DB.SystemEntityTables SiteContext
        //{
        //    get
        //    {
        //        if (siteContext == null)
        //            siteContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetSystemContext();

        //        return siteContext;
        //    }
        //}

        ///// <summary>
        ///// This property is used to Insert/Update and Delete only
        ///// </summary>
        //public DB.SecurityEntityTables SecurityContext
        //{
        //    get
        //    {
        //        if (securityContext == null)
        //            securityContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetSecurityContext();

        //        return securityContext;
        //    }
        //}

        ///// <summary>
        ///// This property is used to Insert/Update and Delete only
        ///// </summary>
        //public DB.AccountingEntityTables AccountingContext
        //{
        //    get
        //    {
        //        if (accountingContext == null)
        //            accountingContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetAccountingContext();

        //        return accountingContext;
        //    }
        //}

        ///// <summary>
        ///// This property is used for read access only
        ///// </summary>
        //public DB.EntityViews SiteReadonlyContext
        //{
        //    get
        //    {
        //        //if (readonlyContext == null)
        //        readonlyContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetReadonlyContext();

        //        return readonlyContext;
        //    }
        //}
        //Removed when Context was moved use BL.SYS.SYS_Period.GetCurrentPeriod(DataContext)
        ///// <summary>
        ///// This property is used to get the current period
        ///// </summary>
        //public DB.SYS_Period CurrentPeriod
        //{
        //    get
        //    {
        //        return SYS.SYS_Period.GetCurrentPeriod();
        //    }
        //}
        public void SetConnections(string connectionstring, bool seperateconnections)
        {

            SqlConnectionString = new SqlConnection(connectionstring);
            //SeperateConnections = seperateconnections;
            EntityViewConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["EntityViews"].ConnectionString, SqlConnectionString.ConnectionString));
            AccountingConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["AccountingEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            BuyoutConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["BuyoutEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            CatalogueConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["CatalogueEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            CalendarConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["CalendarEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            InventoryConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["InventoryEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            OrganisationConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["OrganisationEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            ReportConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["ReportEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            SecurityConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["SecurityEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            SystemConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["SystemEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            WorkshopConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["WorkshopEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            HumanResourcesConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["HumanResourcesEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));
            OrderingConnectionString = new EntityConnection(String.Format(System.Configuration.ConfigurationManager.ConnectionStrings["OrderingEntityTables"].ConnectionString, SqlConnectionString.ConnectionString));

            DevExpress.Xpo.XpoDefault.Session.ConnectionString = String.Format("XpoProvider=MSSqlServer;{0}", connectionstring);
            DevExpress.Xpo.XpoDefault.DataLayer = DevExpress.Xpo.XpoDefault.GetDataLayer(DevExpress.Xpo.XpoDefault.Session.ConnectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            //siteContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetSystemContext();
        }

        internal SqlConnection SqlConnection
        {
            get
            {
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection(SqlConnectionString.ConnectionString);

                switch (sqlConnection.State)
                {
                    case System.Data.ConnectionState.Closed:
                        sqlConnection.Open();
                        break;
                    case System.Data.ConnectionState.Broken:
                        throw new Exception("Connection to database broken");
                    case System.Data.ConnectionState.Connecting:
                        while (sqlConnection.State == System.Data.ConnectionState.Connecting)
                        {
                        }
                        break;
                }

                return sqlConnection;
                //if (sqlConnection != null)
                //{ 
                //    return sqlConnection;
                //}
                //else
                //{
                //    return new SqlConnection(SqlConnectionString.ConnectionString);
                //}
            }
            set
            {
                sqlConnection = value;
            }
        }

        /// <summary>
        /// Returns a pure SqlTrasaction no connection to DataContext
        /// </summary>
        /// <resources>
        /// http://stackoverflow.com/questions/14519596/why-to-use-using-statement-on-dbtransaction-in-ado-net-c
        /// http://stackoverflow.com/questions/8763248/how-to-force-only-one-transaction-within-multiple-dbcontext-classes
        /// </resources>
        internal SqlTransaction SqlTransaction
        {
            get
            {
                if (sqlTransaction == null)
                    //Need to use the SqlConnection Property so that need code can run
                    sqlTransaction = SqlConnection.BeginTransaction();

                return this.sqlTransaction;
            }
        }

        public void RollBackTransaction()
        {
            if (sqlTransaction != null)
                sqlTransaction.Rollback();
        }

        public void CommitSqlTransaction()
        {
            sqlTransaction.Commit();
            sqlConnection.Close();
        }

        public SqlCommand GetCommand(string query, bool readaccessonly)
        {
            if (readaccessonly)
            {
                SqlCommand command = new SqlCommand(query, SqlConnection, SqlTransaction);
                //command.CommandTimeout = 60;
                command.CommandTimeout = sqlCommandTimeOut;
                return command;
            }
            else
            {
                SqlCommand command = new SqlCommand(query, SqlConnection, SqlTransaction);
                //command.CommandTimeout = 60;
                command.CommandTimeout = sqlCommandTimeOut;
                return command;
            }

        }

        public SqlDataAdapter GetAdapter(string query)
        {
            return new SqlDataAdapter(this.GetCommand(query, true));
        }

        public DB.SEC_User LoggedInUser
        {
            get { return loggedInUser; }
            set
            {
                if (loggedInUser != value)
                {
                    loggedInUser = value;
                }
                // Get the user roles and associated access rights
                long[] roleids = Instance.SecurityEntityContext.SEC_UserRole.Where(n => n.UserId == value.Id).Select(n => n.RoleId).ToArray();
                ApplicationDataContext.Instance.AccessIds = Instance.SecurityEntityContext.SEC_RoleAccess.Where(n => roleids.Contains(n.RoleId)).Select(n => n.AccessId).Distinct().ToArray();
            }
        }
        public Int64[] AccessIds { get; set; }
        public SqlConnection SqlConnectionString { get; set; }
        public EntityConnection EntityViewConnectionString { get; set; }
        public EntityConnection AccountingConnectionString { get; set; }
        public EntityConnection BuyoutConnectionString { get; set; }
        public EntityConnection CatalogueConnectionString { get; set; }
        public EntityConnection CalendarConnectionString { get; set; }
        public EntityConnection InventoryConnectionString { get; set; }
        public EntityConnection OrganisationConnectionString { get; set; }
        public EntityConnection ReportConnectionString { get; set; }
        public EntityConnection SecurityConnectionString { get; set; }
        public EntityConnection SystemConnectionString { get; set; }
        public EntityConnection WorkshopConnectionString { get; set; }
        public EntityConnection HumanResourcesConnectionString { get; set; }
        public EntityConnection OrderingConnectionString { get; set; }

        public List<Int64> ProfitDistributionEntriesRequired
        {
            get
            {
                if (profitDistributionEntriesRequired == null)
                {
                    profitDistributionEntriesRequired = AccountingEntityContext.GLX_Account.Where(n => (new String[] { "SALES", "COST OF SALES", "EXPENSES" }).Contains(n.GLX_Type.Name)).Select(l => l.EntityId).ToList();
                }

                return profitDistributionEntriesRequired;
            }
        }

        public bool AccessGranted(BL.SEC.AccessCodes access)
        {
            return Array.Exists<Int64>(AccessIds, delegate (Int64 s) { return s.Equals((Int64)access); });
        }

        public List<DB.SYS_Abbreviation> Abbreviations
        {
            get { return abbreviations; }
            set { abbreviations = value; }
        }

        public List<DB.VW_Validation> ValidationRestrictions
        {
            get { return validationRestrictions; }
            set { validationRestrictions = value; }
        }

        public List<DB.SYS_Module> Modules
        {
            get { return modules; }
            set { modules = value; }
        }

        public static T DeepClone<T>(T toClone, T toCloneInto)
        {
            var properties = toClone.GetType().GetProperties();
            foreach (var property in properties)
            {
                //Will skip and Collections of Entities en Entities
                //Will only copy primitive types
                if (property.PropertyType.Namespace == "System.Collections.Generic" || (property.PropertyType.Namespace == "CDS.Client.DataAccessLayer.DB"))
                    continue;

                //Werner Scheffer
                //NEVER EXCLUDE Id I'm using it on Jobs to identify what line the deleted line comes from
                if (!(new string[] { "CreatedOn", "CreatedBy", "HasChanges" }).Any(n => n.Equals(property.Name)))
                {
                    //Check if there is a Set
                    if (property.CanWrite)
                    {
                        var value = property.GetValue(toClone);
                        property.SetValue(toCloneInto, value);
                    }
                }

                ////Werner Scheffer
                ////NEVER EXCLUDE Id I'm using it on Jobs to identify what line the deleted line comes from
                //if (!property.Name.Equals("CreatedOn") || !property.Name.Equals("CreatedBy"))
                //{
                //    var value = property.GetValue(toClone);
                //    property.SetValue(toCloneInto, value);
                //}
            }
            return toCloneInto;
        }

        public static void CopyOver<T>(T from, T to)
        {
            var properties = from.GetType().GetProperties();
            foreach (var property in properties)
            {
                //Will skip and Collections of Entities en Entities
                //Will only copy primitive types
                if (property.PropertyType.Namespace == "System.Collections.Generic" || (property.PropertyType.Namespace == "CDS.Client.DataAccessLayer.DB"))
                    continue;

                //Werner Scheffer
                //NEVER EXCLUDE Id I'm using it on Jobs to identify what line the deleted line comes from
                if (!(new string[] { "CreatedOn", "CreatedBy", "HasChanges", "Id" }).Any(n => n.Equals(property.Name)))
                {
                    //Check if there is a Set
                    if (property.CanWrite)
                    {
                        var value = property.GetValue(from);
                        property.SetValue(to, value);
                    }
                }
            }
        }

        //public static T DeepClone<T>(T toClone)
        //{
        //    T toCloneInto = default(T);
        //    var properties = toClone.GetType().GetProperties();
        //    foreach (var property in properties)
        //    {
        //        var value = property.GetValue(toClone);
        //        property.SetValue(toCloneInto, value);
        //    }
        //    return toCloneInto;
        //}

        public static T CreateWithValues<T>(System.Data.Entity.Infrastructure.DbPropertyValues values)
            where T : new()
        {
            T entity = new T();
            Type type = typeof(T);

            foreach (var name in values.PropertyNames)
            {
                var property = type.GetProperty(name);
                property.SetValue(entity, values.GetValue<object>(name));
            }

            return entity;
        }

        public static List<Differences> Compair(System.Data.Entity.Infrastructure.DbEntityEntry toCompair)
        {
            List<Differences> differences = new List<Differences>();

            //var properties = toCompair.CurrentValues.GetType().GetProperties();
            //foreach (var property in properties)
            //{
            //    //Will skip and Collections of Entities en Entities
            //    //Will only copy primitive types
            //    if (property.PropertyType.Namespace == "System.Collections.Generic" || (property.PropertyType.Namespace == "CDS.Client.DataAccessLayer.DB"))
            //        continue;

            //    if (property.Name != "CreatedOn" || property.Name != "CreatedBy")
            //    {
            //        var currentValues = property.GetValue(toCompair.CurrentValues);
            //        var originalValues = property.GetValue(toCompair.OriginalValues);
            //        if (currentValues != originalValues)
            //            differences.Add(new Differences() { Property = property, CurrentValue = currentValues, OriginalValues = originalValues });
            //    }
            //}
            for (int i = 0; i < toCompair.CurrentValues.PropertyNames.Count(); i++)
            {
                if (toCompair.CurrentValues[toCompair.CurrentValues.PropertyNames.ElementAt(i)] !=
                    toCompair.OriginalValues[toCompair.CurrentValues.PropertyNames.ElementAt(i)])
                {
                    differences.Add(new Differences()
                    {
                        Property = toCompair.CurrentValues.PropertyNames.ElementAt(i),
                        CurrentValue = toCompair.CurrentValues[toCompair.CurrentValues.PropertyNames.ElementAt(i)],
                        OriginalValues = toCompair.OriginalValues[toCompair.CurrentValues.PropertyNames.ElementAt(i)]
                    });
                }
            }

            return differences;
        }

        //List<DB.SYS_Log> result = Search<DB.SYS_Log>("PM", DataContext.EntitySystemContext.SYS_Log as IEnumerable<DB.SYS_Log>);
        private List<T> Search<T>(string searchString, IEnumerable<T> searchList)
        {
            List<T> foundItems = new List<T>();
            var properties = searchList.ElementAt(0).GetType().GetProperties();

            foreach (T item in searchList)
            {
                bool found = false;
                foreach (var property in properties)
                {
                    if (property.GetValue(item).ToString().Contains(searchString))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                    foundItems.Add(item);
            }

            return foundItems;
        }

        public class Differences
        {
            public String Property { get; set; }
            public object OriginalValues { get; set; }
            public object CurrentValue { get; set; }
        }

        public static Type NonProxyType(Type type)
        {
            return System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(type);
        }

        public int SqlCommandTimeOut { get; set; }

        public DateTime ServerDateTime
        {
            get
            {
                if (serverDateTime == DateTime.MinValue || ((DateTime.Now - serverDateTime).Days > 0))
                {
                    // Refresh the server date
                    try
                    {
                        serverDateTime = SystemEntityContext.Database.SqlQuery<DateTime>("SELECT CAST(CONVERT(char(11), getdate(), 113) AS datetime)").FirstOrDefault();

                    }
                    catch (Exception ex)
                    {
                        if (CDS.Shared.Exception.UserInterfaceExceptionHandler.HandleException(ref ex)) { throw ex; }
                    }
                    finally
                    {
                    }
                }

                return serverDateTime + DateTime.Now.TimeOfDay;
            }
        }

        public void PopulateModuleAccess()
        {
            Instance.Modules = SystemEntityContext.SYS_Module.ToList();
        }

        public void PopulateValidationRestrictions()
        {
            Instance.ValidationRestrictions = ReadonlyContext.VW_Validation.ToList();

            if (Instance.Modules.Any(n => n.Id == (byte)BL.SYS.SYS_Modules.ITM && n.Code == "YES"))
            {
                Instance.ValidationRestrictions.FirstOrDefault(n => n.TableName == "ITM_Inventory" && n.ColumnName == "CostofSalesId").Nullable = false;
            }
        }

        public void PopulateAbbreviations()
        {
            Instance.Abbreviations = SystemEntityContext.SYS_Abbreviation.ToList();
        }

        public static string AddSpaces(string text)
        {
            string value = string.Join(
            string.Empty,
            text.Select((x, i) => (
                 char.IsUpper(x) && i > 0 &&
                 (char.IsLower(text[i - 1]) || (i < text.Count() - 1 && char.IsLower(text[i + 1])))
                                    ) ? " " + x : x.ToString()));
            return value;
        }

        public void ReloadProfitDistributionAccount()
        {
            profitDistributionEntriesRequired = AccountingEntityContext.GLX_Account.Where(n => (new String[] { "SALES", "COST OF SALES", "EXPENSES" }).Contains(n.GLX_Type.Name)).Select(l => l.EntityId).ToList();
        }
    }
}
