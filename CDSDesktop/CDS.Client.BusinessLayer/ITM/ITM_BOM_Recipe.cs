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
    public class ITM_BOM_Recipe
    {

        public static DB.ITM_BOM_Recipe New
        {
            get
            {
                DB.ITM_BOM_Recipe entry = new DB.ITM_BOM_Recipe() { Building = 0, UnBuilding = 0, Archived = false, ITM_BOM_RecipeLine = new List<DB.ITM_BOM_RecipeLine>() };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        public static DB.ITM_BOM_Recipe Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_BOM_Recipe.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_BOM_Recipe Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.ITM_BOM_Recipe entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityInventoryContext.ITM_BOM_Recipe.Add(entry);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ITM_BOM_Recipe GetNextItem(DB.ITM_BOM_Recipe itm_bom_recipe, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_Recipe.OrderBy(o => o.Id).Where(n => n.Id == itm_bom_recipe.Id && n.Id > itm_bom_recipe.Id).FirstOrDefault();
        }

        public static DB.ITM_BOM_Recipe GetPreviousItem(DB.ITM_BOM_Recipe itm_bom_recipe, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_BOM_Recipe.OrderByDescending(o => o.Id).Where(n => n.Id == itm_bom_recipe.Id && n.Id < itm_bom_recipe.Id).FirstOrDefault();
        }

    }
}
