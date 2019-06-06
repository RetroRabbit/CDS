﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


// Borrowed from : http://www.codeproject.com/Articles/9822/Automatic-Application-Wait-Cursor,
// More advanced examples available from the page.
namespace CDS.Client.Desktop.Essential.UTL
{
    public class WaitCursor : IDisposable
    {
        /// <summary>
        /// WARNING WARNING:
        /// Displaying a Wait Form within an MDI child Form's Load event handler may lead to the application freezing. Instead, you can display a Wait Form within an MDI child Form's Shown event handler.
        /// </summary>

        public WaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            ShowWaitForm();
        }

        public void Dispose()
        {
            Cursor.Current = Cursors.Default;
            CloseWaitForm();
        }

        /// <summary>
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        public void ShowWaitForm()
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("ShowWaitForm");

            methodInf.Invoke(mainform, new object[] {  });
        }

        /// <summary>
        /// This method is called to show a form in the MainForm as a MDIChildform
        /// http://www.codeproject.com/Articles/9162/Invoking-methods-Runtime-on-method-name
        /// </summary>
        /// <remarks>Created: Henko Rabie 15/10/2013</remarks>
        public void CloseWaitForm()
        {
            var mainform = Application.OpenForms["MainForm"];
            Type typExternal = mainform.GetType();
            MethodInfo methodInf = typExternal.GetMethod("CloseWaitForm");

            methodInf.Invoke(mainform, new object[] {  });
        }
    }
}
