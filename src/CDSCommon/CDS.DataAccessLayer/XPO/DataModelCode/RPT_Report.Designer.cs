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

    [Persistent(@"CDS_RPT.RPT_Report")]
    public partial class RPT_Report : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        string fCode;
        [Size(50)]
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>("Code", ref fCode, value); }
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
        string fCategory;
        [Size(50)]
        public string Category
        {
            get { return fCategory; }
            set { SetPropertyValue<string>("Category", ref fCategory, value); }
        }
        string fSubCategory;
        [Size(50)]
        public string SubCategory
        {
            get { return fSubCategory; }
            set { SetPropertyValue<string>("SubCategory", ref fSubCategory, value); }
        }
        string fData;
        [Size(SizeAttribute.Unlimited)]
        public string Data
        {
            get { return fData; }
            set { SetPropertyValue<string>("Data", ref fData, value); }
        }
        bool fArchived;
        public bool Archived
        {
            get { return fArchived; }
            set { SetPropertyValue<bool>("Archived", ref fArchived, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref fCreatedOn, value); }
        }
        SYS_Person fCreatedBy;
        [Association(@"RPT_ReportReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref fCreatedBy, value); }
        }
        int fSecurityLevel;
        public int SecurityLevel
        {
            get { return fSecurityLevel; }
            set { SetPropertyValue<int>("SecurityLevel", ref fSecurityLevel, value); }
        }
        short fTypeId;
        public short TypeId
        {
            get { return fTypeId; }
            set { SetPropertyValue<short>("TypeId", ref fTypeId, value); }
        }
    }

}