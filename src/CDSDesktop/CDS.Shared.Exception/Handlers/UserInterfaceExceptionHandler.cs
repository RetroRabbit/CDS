using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace CDS.Shared.Exception
{
    public static class UserInterfaceExceptionHandler
    {

        public static bool HandleException(ref System.Exception ex)
        {
            bool rethrow = false;
            try
            {
                if (ex is BaseException)
                {
                    // do nothing as Data Access or Business Logic exception has already been logged / handled
                }
                else if (ex is System.Threading.ThreadAbortException)
                {
                    //do nothing this is when we kill the check for updates thread
                }
                else
                {
                     rethrow = 
                    ExceptionPolicy.HandleException(exceptionToHandle: ex,policyName: "UserInterfacePolicy");
                    //new ExceptionDialogue(ex).ShowDialog();
                }
            }
            catch (System.Exception exp)
            {
                ex = exp;
            }
            return rethrow;
        }
    }
}
