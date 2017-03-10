using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class SYS_Printer
    {

        public static DB.SYS_Printer New
        {
            get
            {
                DB.SYS_Printer entry = new DB.SYS_Printer();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                entry.Name = "New Printer";
                return entry;
            }
        }

        public static DB.SYS_Printer Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntitySystemContext.SYS_Printer.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.SYS_Printer Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        } 

        internal static String Save(DB.SYS_Printer entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntitySystemContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntitySystemContext.SYS_Printer.Add(entry);

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.SYS_Printer GetNextItem(DB.SYS_Printer SYS_Printer, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Printer.OrderBy(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(SYS_Printer.Name) > 0 && n.Name.CompareTo(SYS_Printer.Name) != 0);
        }

        public static DB.SYS_Printer GetPreviousItem(DB.SYS_Printer SYS_Printer, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.SYS_Printer.OrderByDescending(o => o.Name).FirstOrDefault(n => n.Name.CompareTo(SYS_Printer.Name) < 0 && n.Name.CompareTo(SYS_Printer.Name) != 0);
        }


        public static List<string> GetAvailablePrinters(BL.CDSWebService.CDSServiceClient service,string excludeLocation)
        {
            return service.GetAvailablePrinter(excludeLocation);
        }
    }
}
