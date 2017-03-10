using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace CDS.Shared.Exception
{
   public static class DataAccessExceptionHandler
   {
      public static bool HandleException(ref System.Exception ex)
      {
         bool rethrow = false;
         if ((ex is SqlException))
         {
            SqlException dbExp = (SqlException)ex;
            if (dbExp.Number >= 50000)
            {
               rethrow = ExceptionPolicy.HandleException(ex, "DataAccessCustomPolicy");
               ex = new DataAccessCustomException(ex.Message);
            }
            else
            {
                new ExceptionDialogue(ex).ShowDialog();
               //rethrow = ExceptionPolicy.HandleException(ex, "DataAccessPolicy");
               //if (rethrow)
               //{
               //   throw ex;
               //}
            }
         }
         else if (ex is InvalidEntityQueryException)
         {
             new ExceptionDialogue(ex).ShowDialog();
             //rethrow = ExceptionPolicy.HandleException(ex, "DataAccessPolicy");
             //if (rethrow)
             //{
             //   throw ex;
             //}
         }
         else if (ex is System.Exception)
         {
             new ExceptionDialogue(ex).ShowDialog();
             //rethrow = ExceptionPolicy.HandleException(ex, "DataAccessPolicy");
             //if (rethrow)
             //{
             //   throw ex;
             //}
         }
         return rethrow;
      }
   }
}
