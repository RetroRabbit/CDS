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
    public class ITM_DIS_Discount
    {

        public static DB.ITM_DIS_Discount New
        {
            get
            {
                DB.ITM_DIS_Discount entry = new DB.ITM_DIS_Discount() { PriorityDiscount = false, DiscountAmountTypeId = 1, StartDate = DateTime.Now };
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                return entry;
            }
        }

        public static DB.ITM_DIS_Discount Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityInventoryContext.ITM_DIS_Discount.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.ITM_DIS_Discount Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.ITM_DIS_Discount entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityInventoryContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached) 
                    dataContext.EntityInventoryContext.ITM_DIS_Discount.Add(entry); 
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.ITM_DIS_Discount GetNextItem(DB.ITM_DIS_Discount itm_dis_discount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_DIS_Discount.OrderBy(o => o.Id).Where(n => n.Id > itm_dis_discount.Id && n.Id != itm_dis_discount.Id).FirstOrDefault();
        }

        public static DB.ITM_DIS_Discount GetPreviousItem(DB.ITM_DIS_Discount itm_dis_discount, DataContext dataContext)
        {
            return dataContext.EntityInventoryContext.ITM_DIS_Discount.OrderByDescending(o => o.Id).Where(n => n.Id < itm_dis_discount.Id && n.Id != itm_dis_discount.Id).FirstOrDefault();
        }


    }
}
