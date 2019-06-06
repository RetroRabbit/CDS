using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ORG
{
    public class ORG_Contact
    {

        public static DB.ORG_Contact New
        {
            get
            {
                DB.ORG_Contact entry = new DB.ORG_Contact() { /*SYS_Person = SYS.SYS_Person.New*/ };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_Contact NewSalesContact
        {
            get
            {
                DB.ORG_Contact entry = new DB.ORG_Contact() { /*SYS_Person = SYS.SYS_Person.New*/ };
                entry.DepartmentId = (byte)BL.ORG.ORG_Department.Sales;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ORG_Contact NewAccountsContact
        {
            get
            {
                DB.ORG_Contact entry = new DB.ORG_Contact() { /*SYS_Person = SYS.SYS_Person.New*/ };
                entry.DepartmentId = (byte)BL.ORG.ORG_Department.Accounts;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.ORG_Contact entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached) 
                    dataContext.EntityOrganisationContext.ORG_Contact.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ORG_Contact Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Contact.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ORG_Contact Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        //public static DB.ORG_Contact GetNextItem(DB.ORG_Contact ORG_Contact, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Contact.OrderBy(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) > 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}

        //public static DB.ORG_Contact GetPreviousItem(DB.ORG_Contact ORG_Contact, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Contact.OrderByDescending(o => o.SYS_Person.Surname).FirstOrDefault(n => n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) < 0 && n.SYS_Person.Surname.CompareTo(n.SYS_Person.Surname) != 0);
        //}

        public static int RemoveContact(Int64 oldContact, DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.ExecuteSqlCommand(string.Format("UPDATE [CDS_ORG].[ORG_Contact] SET CompanyId = NULL, IsDefault = 0 WHERE Id = {0}", oldContact));
        }

        public static int ClearCompanyContact(Int64 CompanyToClear, Int64 DepartmentId, DataContext dataContext)
        {
            return dataContext.EntityAccountingContext.ExecuteSqlCommand(string.Format("UPDATE [CDS_ORG].[ORG_Contact] SET CompanyId = NULL, IsDefault = 0 WHERE CompanyId = {0} and DepartmentId = {1}", CompanyToClear, DepartmentId));
        }

        private static IQueryable<DB.ORG_Contact> LoadContacts(Int64 entityId, DataContext dataContext, BL.ORG.ORG_Department department, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Contact.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.Where(n => n.CompanyId == entityId && n.DepartmentId == (int)department);
        }

        public static DB.ORG_Contact LoadSalesContact(Int64 entityId, DataContext dataContext, List<string> includes)
        {
            return LoadContacts(entityId, dataContext, ORG_Department.Sales, includes).FirstOrDefault(n => n.IsDefault.Value);
        }

        public static DB.ORG_Contact LoadSalesContact(Int64 entityId, DataContext dataContext)
        {
            return LoadContacts(entityId, dataContext, ORG_Department.Sales, null).FirstOrDefault(n => n.IsDefault.Value);
        }

        public static DB.ORG_Contact LoadAccountsContact(Int64 entityId, DataContext dataContext, List<string> includes)
        {
            return LoadContacts(entityId, dataContext, ORG_Department.Accounts, includes).FirstOrDefault(n => n.IsDefault.Value);
        }

        public static DB.ORG_Contact LoadAccountsContact(Int64 entityId, DataContext dataContext)
        {
            return LoadContacts(entityId, dataContext, ORG_Department.Accounts, null).FirstOrDefault(n => n.IsDefault.Value);
        }

    }
}
