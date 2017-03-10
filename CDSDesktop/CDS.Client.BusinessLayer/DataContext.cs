using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer
{
    public class DataContext
    { 

        private DB.AccountingEntityTables entityAccountingContext;
        private DB.BuyoutEntityTables entityBuyoutContext;
        private DB.CalendarEntityTables entityCalendarContext;
        private DB.CatalogueEntityTables entityCatalogueContext;
        private DB.HumanResourcesEntityTables entityHumanResourcesContext;
        private DB.InventoryEntityTables entityInventoryContext;
        private DB.OrganisationEntityTables entityOrganisationContext;
        private DB.ReportEntityTables entityReportContext;
        private DB.SecurityEntityTables entitySecurityContext;
        private DB.SystemEntityTables entitySystemContext;
        private DB.WorkshopEntityTables entityWorkshopContext;
        private DB.OrderingEntityTables entityOrderingContext;
        private DB.EntityViews readonlyContext; 

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.AccountingEntityTables EntityAccountingContext
        {
            get
            {
                if (entityAccountingContext == null)
                    entityAccountingContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetAccountingContext();

                return entityAccountingContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.BuyoutEntityTables EntityBuyoutContext
        {
            get
            {
                if (entityBuyoutContext == null)
                    entityBuyoutContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetBuyoutContext();

                return entityBuyoutContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.CalendarEntityTables EntityCalendarContext
        {
            get
            {
                if (entityCalendarContext == null)
                    entityCalendarContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetCalendarContext();

                return entityCalendarContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.CatalogueEntityTables EntityCatalogueContext
        {
            get
            {
                if (entityCatalogueContext == null)
                    entityCatalogueContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetCatalogueContext();

                return entityCatalogueContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.HumanResourcesEntityTables EntityHumanResourcesContext
        {
            get
            {
                if (entityHumanResourcesContext == null)
                    entityHumanResourcesContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetHumanResourcesContext();

                return entityHumanResourcesContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.InventoryEntityTables EntityInventoryContext
        {
            get
            {
                if (entityInventoryContext == null)
                    entityInventoryContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetInventoryContext();

                return entityInventoryContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.OrganisationEntityTables EntityOrganisationContext
        {
            get
            {
                if (entityOrganisationContext == null)
                    entityOrganisationContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetOrganisationContext();

                return entityOrganisationContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.ReportEntityTables EntityReportContext
        {
            get
            {
                if (entityReportContext == null)
                    entityReportContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetReportContext();

                return entityReportContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.SecurityEntityTables EntitySecurityContext
        {
            get
            {
                if (entitySecurityContext == null)
                    entitySecurityContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetSecurityContext();

                return entitySecurityContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.SystemEntityTables EntitySystemContext
        {
            get
            {
                if (entitySystemContext == null)
                    entitySystemContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetSystemContext();

                return entitySystemContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.WorkshopEntityTables EntityWorkshopContext
        {
            get
            {
                if (entityWorkshopContext == null)
                    entityWorkshopContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetWorkshopContext();

                return entityWorkshopContext;
            }
        }

        /// <summary>
        /// This property is used to Insert/Update and Delete only
        /// </summary>
        public DB.OrderingEntityTables EntityOrderingContext
        {
            get
            {
                if (entityOrderingContext == null)
                    entityOrderingContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetOrderingContext();

                return entityOrderingContext;
            }
        }
 
        public int SaveChangesEntityAccountingContext()
        {
            LogChanges(EntityAccountingContext.ChangeTracker);
            return EntityAccountingContext.SaveChanges();
        }

        public int SaveChangesEntityBuyoutContext()
        {
            LogChanges(EntityBuyoutContext.ChangeTracker);
            return EntityBuyoutContext.SaveChanges();
        }

        public int SaveChangesEntityCalendarContext()
        {
            LogChanges(EntityCalendarContext.ChangeTracker);
            return EntityCalendarContext.SaveChanges();
        }

        public int SaveChangesEntityCatalogueContext()
        {
            LogChanges(EntityCatalogueContext.ChangeTracker);
            return EntityCatalogueContext.SaveChanges();
        }

        public int SaveChangesEntityHumanResourcesContext()
        {
            LogChanges(EntityHumanResourcesContext.ChangeTracker);
            return EntityHumanResourcesContext.SaveChanges();
        }

        public int SaveChangesEntityInventoryContext()
        {
            LogChanges(EntityInventoryContext.ChangeTracker);
            return EntityInventoryContext.SaveChanges();
        }

        public int SaveChangesEntityOrganisationContext()
        {
            LogChanges(EntityOrganisationContext.ChangeTracker);
            return EntityOrganisationContext.SaveChanges();
        }

        public int SaveChangesEntityReportContext()
        {
            LogChanges(EntityReportContext.ChangeTracker);
            return EntityReportContext.SaveChanges();
        }

        public int SaveChangesEntitySecurityContext()
        {
            LogChanges(EntitySecurityContext.ChangeTracker);
            return EntitySecurityContext.SaveChanges();
        }

        public int SaveChangesEntitySystemContext()
        {
            LogChanges(EntitySystemContext.ChangeTracker);
            return EntitySystemContext.SaveChanges();
        } 

        public int SaveChangesEntityWorkshopContext()
        {
            LogChanges(EntityWorkshopContext.ChangeTracker);
            return EntityWorkshopContext.SaveChanges();
        }

        public int SaveChangesEntityOrderingContext()
        {
            LogChanges(EntityOrderingContext.ChangeTracker);
            return EntityOrderingContext.SaveChanges();
        } 

        public int SaveChangesEntityAccountingContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityAccountingContext.ChangeTracker);
            return EntityAccountingContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityBuyoutEntityContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityBuyoutContext.ChangeTracker);
            return EntityBuyoutContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityCalendarContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityCalendarContext.ChangeTracker);
            return EntityCalendarContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityCatalogueContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityCatalogueContext.ChangeTracker);
            return EntityCatalogueContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityHumanResourcesContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityHumanResourcesContext.ChangeTracker);
            return EntityHumanResourcesContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityInventoryContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityInventoryContext.ChangeTracker);
            return EntityInventoryContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityOrganisationContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityOrganisationContext.ChangeTracker);
            return EntityOrganisationContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityReportContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityReportContext.ChangeTracker);
            return EntityReportContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntitySecurityContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntitySecurityContext.ChangeTracker);
            return EntitySecurityContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntitySystemContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntitySystemContext.ChangeTracker);
            return EntitySystemContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityWorkshopContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityWorkshopContext.ChangeTracker);
            return EntitySystemContext.SaveChanges(saveOptions);
        }

        public int SaveChangesEntityOrderingContext(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            LogChanges(EntityOrderingContext.ChangeTracker);
            return EntityOrderingContext.SaveChanges(saveOptions);
        }

        private void LogChanges(System.Data.Entity.Infrastructure.DbChangeTracker dbChangeTracker)
        {
            foreach (System.Data.Entity.Infrastructure.DbEntityEntry entity in dbChangeTracker.Entries().Where(obj => { return obj.State == System.Data.Entity.EntityState.Modified || obj.State == System.Data.Entity.EntityState.Deleted; }))
            {
                if (BL.ApplicationDataContext.NonProxyType(entity.GetType()) == typeof(DB.SYS_Log))
                    continue;

                //LogObject logObject = new LogObject();

                //logObject.EntityType = BL.ApplicationDataContext.NonProxyType(entity.Entity.GetType());

                //if (entity.State == System.Data.Entity.EntityState.Added)
                //    logObject.Action = System.Data.Entity.EntityState.Added.ToString();
                //else if (entity.State == System.Data.Entity.EntityState.Modified)
                //    logObject.Action = System.Data.Entity.EntityState.Modified.ToString();
                //else if (entity.State == System.Data.Entity.EntityState.Deleted)
                //    logObject.Action = System.Data.Entity.EntityState.Deleted.ToString();

                switch (entity.State)
                {
                    case System.Data.Entity.EntityState.Modified:
                        
                        foreach (string propertyName in entity.CurrentValues.PropertyNames)
                        {
                            DB.SYS_Log sysLog = BL.SYS.SYS_Log.New;
                            sysLog.EntityId = Convert.ToInt64(entity.CurrentValues["Id"]);
                            sysLog.TableName = BL.ApplicationDataContext.NonProxyType(entity.Entity.GetType()).Name;

                            if (propertyName == "CreatedOn" || propertyName == "CreatedBy" || propertyName == "Title")
                                continue;

                            sysLog.FieldName = propertyName;

                            if (entity.CurrentValues[propertyName] == null && entity.OriginalValues[propertyName] == null)
                            {
                                
                            }
                            else if (entity.CurrentValues[propertyName] != null && entity.OriginalValues[propertyName] == null)
                            {
                                sysLog.OldValue = "";
                                sysLog.NewValue = entity.CurrentValues[propertyName].ToString();
                                EntityController.SaveSYS_Log(sysLog, this); 
                            }
                            else if (entity.CurrentValues[propertyName] == null && entity.OriginalValues[propertyName] != null)
                            {
                                sysLog.OldValue = entity.OriginalValues[propertyName].ToString();
                                sysLog.NewValue = "";
                                EntityController.SaveSYS_Log(sysLog, this); 
                            }
                            else if (entity.CurrentValues[propertyName].ToString() != entity.OriginalValues[propertyName].ToString())
                            {
                                sysLog.OldValue = entity.OriginalValues[propertyName].ToString();
                                sysLog.NewValue = entity.CurrentValues[propertyName].ToString();
                                EntityController.SaveSYS_Log(sysLog, this); 
                            }
                        }
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        //if (BL.ApplicationDataContext.NonProxyType(entity.Entity.GetType()) != typeof(DB.ITM_InventorySupplier))
                        //    throw new Exception("Deleting Entries not allowed in this system implement and archive");
                        break;
                } 

                //if (entity.State == System.Data.Entity.EntityState.Added || entity.State == System.Data.Entity.EntityState.Modified)
                //{
                //    System.Xml.Linq.XDocument currentValues = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement(logObject.EntityType.Name));

                //    foreach (string propertyName in entity.CurrentValues.PropertyNames)
                //    {
                //        currentValues.Root.Add(new System.Xml.Linq.XElement(propertyName, entity.CurrentValues[propertyName]));
                //    }

                //    logObject.NewData = System.Text.RegularExpressions.Regex.Replace(currentValues.ToString(), @"\r\n+", " ");
                //}

                //if (entity.State == System.Data.Entity.EntityState.Modified || entity.State == System.Data.Entity.EntityState.Deleted)
                //{
                //    System.Xml.Linq.XDocument originalValues = new System.Xml.Linq.XDocument(new System.Xml.Linq.XElement(logObject.EntityType.Name));

                //    foreach (string propertyName in entity.OriginalValues.PropertyNames)
                //    {
                //        originalValues.Root.Add(new System.Xml.Linq.XElement(propertyName, entity.OriginalValues[propertyName]));
                //    }

                //    logObject.OldData = System.Text.RegularExpressions.Regex.Replace(originalValues.ToString(), @"\r\n+", " ");
                //}
              
             
                //auditTrailList.Add(auditObject);
            }
        }

        public String PackageValidationException()
        {
            string validationException = string.Empty;

            if (entityAccountingContext != null)
               validationException = entityAccountingContext.PackageValidationException();

            if (entityBuyoutContext != null)
                validationException = entityBuyoutContext.PackageValidationException();

            if (entityCalendarContext != null)
                validationException = entityCalendarContext.PackageValidationException();

            if (entityCatalogueContext != null)
                validationException = entityCatalogueContext.PackageValidationException();

            if (entityInventoryContext != null)
                validationException = entityInventoryContext.PackageValidationException();

            if (entityOrganisationContext != null)
                validationException = entityOrganisationContext.PackageValidationException();

            if (entityReportContext != null)
                validationException = entityReportContext.PackageValidationException();

            if (entitySecurityContext != null)
                validationException = entitySecurityContext.PackageValidationException();

            if (entitySystemContext != null)
                validationException = entitySystemContext.PackageValidationException();

            if (entityWorkshopContext != null)
                validationException = entityWorkshopContext.PackageValidationException();

            if (entityOrderingContext != null)
                validationException = entityOrderingContext.PackageValidationException();

            return validationException;
        } 

        /// <summary>
        /// This property is used for read access only
        /// </summary>
        public DB.EntityViews ReadonlyContext
        {
            get
            {
                //if (readonlyContext == null)
                readonlyContext = CDS.Client.BusinessLayer.Data.DataLibrary.GetReadonlyContext();

                return readonlyContext;
            }
        }

        class LogObject
        {
            public Type EntityType { get; set; }
            public String Action { get; set; }
            public String NewData { get; set; }
            public String OldData { get; set; }
        }

        public TransactionScope GetTransactionScope()
        {
            return new TransactionScope();
        }

        public void CompleteTransaction(TransactionScope transactionScope)
        {
            this.SaveChangesEntitySystemContext();
            transactionScope.Complete();
        } 
    }
}
