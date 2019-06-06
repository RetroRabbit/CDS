﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDS.Client.DataAccessLayer.DB
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.Entity.Validation;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CatalogueEntityTables : DbContext /*ExtenderContext*/
    {
        public CatalogueEntityTables(string connection)
            : base(connection)
        {
    	}
    
    	public CatalogueEntityTables(DbConnection connection, bool ownsConnection)
            : base(connection, ownsConnection)
        {
        }
    
    	public CatalogueEntityTables()
            : base("name=CatalogueEntityTables")
        {
        }
    	
    	public void ReloadEntry(object entity)
        {
    		if((entity as IBaseEntity) == null)
    			return;
    
            (entity as IBaseEntity).IgnoreChanges = true;
            this.Entry(entity).Reload();
            (entity as IBaseEntity).IgnoreChanges = false;
        }
    
    	private int SubmitChanges(System.Data.Entity.Core.Objects.SaveOptions saveOptions)
        {
            var changedEntities = GetChangedEntries().Select(l => l.Entity).Where(n => (n as IBaseEntity) != null && (n as IBaseEntity).HasChanges == true);
    
            int changedRows = ((IObjectContextAdapter)this).ObjectContext.SaveChanges(saveOptions);
    
            foreach (var entity in changedEntities)
            {
                (entity as IBaseEntity).HasChanges = false;
    			(entity as IBaseEntity).ChangeList = new List<String>();
            }
    
            return changedRows;
        }
    
        //Submits all changes and changes entity state use this when you want to .Reload() a Entity
        //System.Data.Entity.Core.Objects.SaveOptions.AcceptAllChangesAfterSave
        //Online runs all Checks when running AcceptAllChanges
        //System.Data.Entity.Core.Objects.SaveOptions.DetectChangesBeforeSave
        public int SaveChanges(System.Data.Entity.Core.Objects.SaveOptions saveOptions )
        {  
            return this.SubmitChanges(saveOptions);
        }
    
        public override int SaveChanges()
        { 
            return this.SubmitChanges(System.Data.Entity.Core.Objects.SaveOptions.AcceptAllChangesAfterSave);
        }
    
        public void AcceptAllChanges()
        {
            ((IObjectContextAdapter)this).ObjectContext.AcceptAllChanges();
        }
    
    	public void RejectChanges()
        {
            foreach (var entity in GetChangedEntries())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        UndoChanges(entity);
                        entity.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    
    	public void UndoChanges<T>(T changedEntity) 
        {
            var originalValues = GetChangedEntries().FirstOrDefault(n => n.Entity == (object)changedEntity).OriginalValues;
                 
            Type type = typeof(T);
    
            foreach (var name in originalValues.PropertyNames)
            {
                var property = type.GetProperty(name);
                property.SetValue(changedEntity, originalValues.GetValue<object>(name));
            } 
        }
    
    	public System.Data.Entity.EntityState GetEntityState(object entry)
    	{
    		return this.Entry(entry).State;
    	}
    
    	public void SetEntityStateDetatched(object entry)
    	{
    		this.Entry(entry).State = System.Data.Entity.EntityState.Detached;
    	}
    
    	public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return this.Database.ExecuteSqlCommand(sql, parameters); 
        }
    
    	public int ExecuteSqlCommand(string sql)
    	{
    		return this.Database.ExecuteSqlCommand(sql);
    	}
    
    	public IEnumerable<T> SqlQueryList<T>(string sql, object[] parameters)
    	{
    		foreach (var item in this.Database.SqlQuery(typeof(T), sql, parameters))
    		{
    			yield return (T)item;
    		}
    	}
    
    	public T SqlQuerySingle<T>(string sql, object[] parameters)
    	{
    		foreach (var item in this.Database.SqlQuery(typeof(T), sql, parameters))
    		{
    			return (T)item;
    		}
    
    		//You should never realy get to here
    		//Try to change your SQL Query to Stored Procedure or Funtion to return a default value
    		//If you are running a select statement this mothod will return a new contructed object of type T
    		//If you would like this behaviour comment out the throw exception and uncomment the return default(T)
    		throw new Exception("You should never have reached this exception");
    		//return default(T);
    	}
    
    	public bool HasChanges(DbEntityEntry entry)
    	{
    		return new List<DbEntityEntry>(
    			from e in ChangeTracker.Entries()
    			where e.State != System.Data.Entity.EntityState.Unchanged && e.Entity == entry
    			select e).Count > 0;
    	}
    
    	public IEnumerable<DbEntityEntry> GetChangedEntries()
    	{
    		return new List<DbEntityEntry>(
    			from e in ChangeTracker.Entries()
    			where e.State != System.Data.Entity.EntityState.Unchanged
    			select e);
    	}
    
    	public String PackageValidationException()
    	{
    		string exceptionString = "ValidationException" + Environment.NewLine;
    
    		foreach (DbEntityValidationResult validationResult in GetValidationErrors())
    		{
    			foreach (var validationError in validationResult.ValidationErrors)
    			{
    				exceptionString += validationError.ErrorMessage + Environment.NewLine;
    			}
    		}
    
    		return exceptionString;
    	}
    
    	public T GetOriginal<T>(T changedEntity)
                  where T : new()
    	{
    		var originalValues = GetChangedEntries().FirstOrDefault(n => n.Entity == (object)changedEntity).OriginalValues;
    
    		T entity = new T();
    		Type type = typeof(T);
    
    		foreach (var name in originalValues.PropertyNames)
    		{
    			var property = type.GetProperty(name);
    			property.SetValue(entity, originalValues.GetValue<object>(name));
    		}
    
    		return entity;
    	}
          
    	public void UseTransaction(DbTransaction transaction)
    	{
    		if (transaction == null)
    			this.Database.UseTransaction(transaction);
    	}
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<CAT_Catalogue> CAT_Catalogue { get; set; }
        public DbSet<CAT_Category> CAT_Category { get; set; }
        public DbSet<CAT_Item> CAT_Item { get; set; }
        public DbSet<CAT_ItemData> CAT_ItemData { get; set; }
        public DbSet<CAT_Meta> CAT_Meta { get; set; }
        public DbSet<CAT_MetaData> CAT_MetaData { get; set; }
    }
}
