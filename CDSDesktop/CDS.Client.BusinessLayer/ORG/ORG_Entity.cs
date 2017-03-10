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
    public class ORG_Entity
    {

        public static DB.ORG_Entity New
        {
            get
            {
                DB.ORG_Entity entry = new DB.ORG_Entity() { /*SYS_Entity = SYS.SYS_Entity.NewCompany*/ };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        internal static String Save(DB.ORG_Entity entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityOrganisationContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityOrganisationContext.ORG_Entity.Add(entry);
                    //ApplicationDatadataContext.Instance.dataContext.SaveChanges();
                }
                else
                {
                    //ApplicationDatadataContext.Instance.dataContext.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ORG_Entity Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Entity.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ORG_Entity Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.ORG_Entity LoadByEntity(Int64 Id, DataContext dataContext)
        {
            return LoadByEntity(Id, dataContext, null);
        }

        public static DB.ORG_Entity LoadByEntity(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityOrganisationContext.ORG_Entity.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.EntityId == Id);
        }

        //public static DB.ORG_Entity GetNextItem(DB.ORG_Entity ORG_Entity, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Entity.OrderBy(o => o.SYS_Entity.Name).FirstOrDefault(n => n.SYS_Entity.Name.CompareTo(n.SYS_Entity.Name) > 0 && n.SYS_Entity.Name.CompareTo(n.SYS_Entity.Name) != 0);
        //}

        //public static DB.ORG_Entity GetPreviousItem(DB.ORG_Entity ORG_Entity, DataContext dataContext)
        //{
        //    return dataContext.EntityOrganisationContext.ORG_Entity.OrderByDescending(o => o.SYS_Entity.Name).FirstOrDefault(n => n.SYS_Entity.Name.CompareTo(n.SYS_Entity.Name) < 0 && n.SYS_Entity.Name.CompareTo(n.SYS_Entity.Name) != 0);
        //}


        
    }
}
