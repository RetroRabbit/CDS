using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.ITM
{
    public class ITM_BOM_RecipeLine
    {

        public static DB.ITM_BOM_RecipeLine New
        {
            get
            {
                DB.ITM_BOM_RecipeLine entry = new DB.ITM_BOM_RecipeLine() { };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.ITM_BOM_RecipeLine Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_BOM_RecipeLine.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_BOM_RecipeLine Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.ITM_BOM_RecipeLine entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached) 
                    dataContext.EntityInventoryContext.ITM_BOM_RecipeLine.Add(entry);
             
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static void Delete(DB.ITM_BOM_RecipeLine entry, DataContext dataContext)
        {
            dataContext.EntityInventoryContext.ITM_BOM_RecipeLine.Remove(entry);
        }

        public static DB.ITM_BOM_RecipeLine GetNextItem(DB.ITM_BOM_RecipeLine ITM_BOM_RecipeLine, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_RecipeLine.OrderBy(o => o.Id).Where(n => n.Id == ITM_BOM_RecipeLine.Id && n.Id > ITM_BOM_RecipeLine.Id && n.RecipeId == ITM_BOM_RecipeLine.RecipeId).FirstOrDefault();
        }

        public static DB.ITM_BOM_RecipeLine GetPreviousItem(DB.ITM_BOM_RecipeLine ITM_BOM_RecipeLine, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_RecipeLine.OrderByDescending(o => o.Id).Where(n => n.Id == ITM_BOM_RecipeLine.Id && n.Id < ITM_BOM_RecipeLine.Id && n.RecipeId == ITM_BOM_RecipeLine.RecipeId).FirstOrDefault();
        }

    }
}
