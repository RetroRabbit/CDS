﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL = CDS.Client.BusinessLayer;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.RPT
{
    public class RPT_Report
    {

        public static DB.RPT_Report New
        {
            get
            {
                DB.RPT_Report entry = new DB.RPT_Report();
                entry.CreatedBy = ApplicationDataContext.Instance.LoggedInUser.PersonId;
                

                return entry;
            }
        }

        public static DB.RPT_Report Load(Int64 Id, DataContext dataContext, List<string> includes)
        {
            var query = dataContext.EntityReportContext.RPT_Report.AsQueryable();

            if (includes != null)
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }

            return query.FirstOrDefault(n => n.Id == Id);
        }

        public static DB.RPT_Report Load(Int64 Id, DataContext dataContext)
        {
            return Load(Id, dataContext, null);
        }

        public static DB.RPT_Report LoadByName(string name, DataContext dataContext)
        {
            return dataContext.EntityReportContext.RPT_Report.FirstOrDefault(n => n.Name == name);
        } 

        internal static String Save(DB.RPT_Report entry, DataContext dataContext)
        {
            try
            {
                if (dataContext.EntityReportContext.GetEntityState(entry) == System.Data.Entity.EntityState.Detached)
                {
                    dataContext.EntityReportContext.RPT_Report.Add(entry);
                    

                }
                else
                {
                    
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                return dataContext.PackageValidationException();
            }

            return "Success";
        }

        public static DB.RPT_Report GetNextItem(DB.RPT_Report rpt_analytic, DataContext dataContext)
        {
            return dataContext.EntityReportContext.RPT_Report.OrderBy(o => o.Name).Where(n => n.Name.CompareTo(rpt_analytic.Name) > 0 && n.Name.CompareTo(rpt_analytic.Name) != 0).FirstOrDefault();
        }

        public static DB.RPT_Report GetPreviousItem(DB.RPT_Report rpt_analytic, DataContext dataContext)
        {
            return dataContext.EntityReportContext.RPT_Report.OrderByDescending(o => o.Name).Where(n => n.Name.CompareTo(rpt_analytic.Name) < 0 && n.Name.CompareTo(rpt_analytic.Name) != 0).FirstOrDefault();
        }
         
    }
}
