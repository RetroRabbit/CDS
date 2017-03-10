using System;
using System.Reflection;

namespace CDS.Update.Helper
{
    /// <summary>
    /// The interface that all applications need to implement in order to use SharpUpdate
    /// </summary>
    public interface IApplicationUpdatable
    {
        /// <summary>
        /// The current assembly
        /// </summary>
        Assembly ApplicationAssembly { get; }
        /// <summary>
        /// The application's icon to be displayed in the top left
        /// </summary>
        object ApplicationIcon { get; }
        /// <summary>
        /// The location of the update.xml on a server
        /// </summary>
        Uri UpdateXmlLocation { get; }
        /// <summary>
        /// The context of the program.
        /// For Windows Forms Applications, use 'this'
        /// Console Apps, reference System.Windows.Forms and return null.
        /// </summary>
        object Context { get; }
    }
}
