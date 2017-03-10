using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class GLX_Recon
    {
        public static DB.GLX_Recon New
        {
            get
            {
                DB.GLX_Recon entry = new DB.GLX_Recon();
                entry.StatusId = (byte)SYS.SYS_Status.Open;
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;

                return entry;
            }
        }

        public static DB.GLX_Recon Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityAccountingContext.GLX_Recon.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.GLX_Recon Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        internal static String Save(DB.GLX_Recon entry,DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityAccountingContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                    dataContext.EntityAccountingContext.GLX_Recon.Add(entry);

                
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        //public static DB.GLX_Recon GetNextItem(DB.GLX_Recon glx_recon, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Recon.OrderBy(o => o.StartDate).Where(n => n.StartDate > glx_recon.StartDate && n.StartDate != glx_recon.StartDate).FirstOrDefault();
        //}

        //public static DB.GLX_Recon GetPreviousItem(DB.GLX_Recon glx_recon, DataContext dataContext)
        //{
        //    return dataContext.EntitySystemContext.SYS_Recon.OrderByDescending(o => o.StartDate).Where(n => n.StartDate > glx_recon.StartDate && n.StartDate != glx_recon.StartDate).FirstOrDefault();
        //}

        public static void RejectRecon(DB.GLX_Recon glx_recon,DataContext dataContext)
        {
            glx_recon.StatusId = (byte)SYS.SYS_Status.Rejected;
            dataContext.EntityAccountingContext.ExecuteSqlCommand(string.Format("UPDATE [CDS_GLX].[GLX_Line] set ReconId = null WHERE ReconId = {0}", glx_recon.Id));
        }
    }
}
