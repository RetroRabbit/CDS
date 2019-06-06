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

    [Persistent(@"CDS_APP.APP_UserValue")]
    public partial class APP_UserValue : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        SYS_Entity fApplicationId;
        [Association(@"APP_UserValueReferencesSYS_Entity")]
        public SYS_Entity ApplicationId
        {
            get { return fApplicationId; }
            set { SetPropertyValue<SYS_Entity>("ApplicationId", ref fApplicationId, value); }
        }
        SYS_Person fPersonId;
        [Association(@"APP_UserValueReferencesSYS_Person")]
        public SYS_Person PersonId
        {
            get { return fPersonId; }
            set { SetPropertyValue<SYS_Person>("PersonId", ref fPersonId, value); }
        }
        APP_Attribute fAttributeId;
        [Association(@"APP_UserValueReferencesAPP_Attribute")]
        public APP_Attribute AttributeId
        {
            get { return fAttributeId; }
            set { SetPropertyValue<APP_Attribute>("AttributeId", ref fAttributeId, value); }
        }
        string fValue;
        [Size(500)]
        public string Value
        {
            get { return fValue; }
            set { SetPropertyValue<string>("Value", ref fValue, value); }
        }
    }

}