using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;

namespace resources.api.cdsonline.co.za.Services
{
    public static class XpoHelper
    {
        public static Session GetNewSession()
        {
            return new Session(DataLayer);
        }

        public static UnitOfWork GetNewUnitOfWork()
        {
            return new UnitOfWork(DataLayer);
        }

        private readonly static object lockObject = new object();

        static volatile IDataLayer fDataLayer;
        static IDataLayer DataLayer
        {
            get
            {
                if (fDataLayer == null)
                {
                    lock (lockObject)
                    {
                        if (fDataLayer == null)
                        {
                            fDataLayer = GetDataLayer();
                        }
                    }
                }
                return fDataLayer;
            }
        }

        private static IDataLayer GetDataLayer()
        {
            
            XpoDefault.Session = null;
            string conn = MSSqlConnectionProvider.GetConnectionString(resources.api.cdsonline.co.za.Properties.Settings.Default.Server.ToString(), resources.api.cdsonline.co.za.Properties.Settings.Default.DB.ToString());
            //XPDictionary dict = new ReflectionDictionary();
            IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
            //dict.GetDataStoreSchema(typeof(PersistentObjects.Customer).Assembly);
            IDataLayer dl = new SimpleDataLayer(store); //new ThreadSafeDataLayer(dict, store);
            return dl;
        }
    }
}