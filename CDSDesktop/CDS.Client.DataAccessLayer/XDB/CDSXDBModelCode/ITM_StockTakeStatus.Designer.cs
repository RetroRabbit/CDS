//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{

    public partial class ITM_StockTakeStatus : XPLiteObject
    {
        short _Id;
        [Key]
        public short Id
        {
            get { return _Id; }
            set { SetPropertyValue<short>("Id", ref _Id, value); }
        }
        string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>("Name", ref _Name, value); }
        }
        string _Description;
        [Size(2000)]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>("Description", ref _Description, value); }
        }
        [Association(@"ITM_StockTakeReferencesITM_StockTakeStatus", typeof(ITM_StockTake))]
        public XPCollection<ITM_StockTake> ITM_StockTakes { get { return GetCollection<ITM_StockTake>("ITM_StockTakes"); } }
    }

}