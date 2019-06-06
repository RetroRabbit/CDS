using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Period
    {
        public static DB.SYS_Period New
        {
            get
            {
                DB.SYS_Period entry = new DB.SYS_Period();
                return entry;
            }
        }

        public static void Save(List<DB.SYS_Period> periods,DataContext dataContext)
        {
            periods.ForEach(n => dataContext.EntitySystemContext.SYS_Period.Add(n));
        }

        public static DB.SYS_Period Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Period.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Period Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Period entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    Save(new List<DB.SYS_Period>() { entry }, dataContext);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";

        }

        public static DB.SYS_Period GetNextItem(DB.SYS_Period period, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Period.OrderBy(o => o.EndDate).FirstOrDefault(n => n.EndDate > period.EndDate && n.EndDate != period.EndDate);
        }

        public static DB.SYS_Period GetPreviousItem(DB.SYS_Period period, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Period.OrderByDescending(o => o.EndDate).FirstOrDefault(n => n.EndDate < period.EndDate && n.EndDate != period.EndDate);
        }

        //TODO: Find a way to do this
        public static DB.SYS_Period GetCurrentPeriod(DataContext dataContext)
        {
            return dataContext.EntitySystemContext.Database.SqlQuery<DB.SYS_Period>("select * from [CDS_SYS].[fnCurrentPeriod] ()", new object[] { }).FirstOrDefault();
        }

        public static DB.SYS_Period Load(DateTime dateTime, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Period.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => dateTime >= n.StartDate && dateTime <= n.EndDate);
        }

        public static DB.SYS_Period Load(DateTime dateTime, DataContext dataContext)
        {
            return Load(dateTime, dataContext, new List<string>());
        }
    }
}
