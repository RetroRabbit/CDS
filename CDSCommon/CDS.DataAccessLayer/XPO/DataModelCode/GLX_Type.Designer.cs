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
namespace CDS.DataAccessLayer.XPO.Datamodel
{

    [Persistent(@"CDS_GLX.GLX_Type")]
    public partial class GLX_Type : XPLiteObject
    {
        byte fId;
        [Key]
        public byte Id
        {
            get { return fId; }
            set { SetPropertyValue<byte>("Id", ref fId, value); }
        }
        string fGrouping;
        [Size(50)]
        public string Grouping
        {
            get { return fGrouping; }
            set { SetPropertyValue<string>("Grouping", ref fGrouping, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>("Name", ref fName, value); }
        }
        string fDescription;
        [Size(2000)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>("Description", ref fDescription, value); }
        }
        char fFlag1;
        public char Flag1
        {
            get { return fFlag1; }
            set { SetPropertyValue<char>("Flag1", ref fFlag1, value); }
        }
        string fFlag2;
        [Size(2)]
        public string Flag2
        {
            get { return fFlag2; }
            set { SetPropertyValue<string>("Flag2", ref fFlag2, value); }
        }
    }

}