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

    [Persistent(@"CDS_HRS.HRS_Role")]
    public partial class HRS_Role : XPLiteObject
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
        bool fAppointment;
        public bool Appointment
        {
            get { return fAppointment; }
            set { SetPropertyValue<bool>("Appointment", ref fAppointment, value); }
        }
        bool fSaleAppointment;
        public bool SaleAppointment
        {
            get { return fSaleAppointment; }
            set { SetPropertyValue<bool>("SaleAppointment", ref fSaleAppointment, value); }
        }
        bool fPurchaseAppointment;
        public bool PurchaseAppointment
        {
            get { return fPurchaseAppointment; }
            set { SetPropertyValue<bool>("PurchaseAppointment", ref fPurchaseAppointment, value); }
        }
        bool fWorkshopAppointment;
        public bool WorkshopAppointment
        {
            get { return fWorkshopAppointment; }
            set { SetPropertyValue<bool>("WorkshopAppointment", ref fWorkshopAppointment, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref fCreatedOn, value); }
        }
        SYS_Person fCreatedBy;
        [Association(@"HRS_RoleReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref fCreatedBy, value); }
        }
        [Association(@"HRS_EmployeeReferencesHRS_Role", typeof(HRS_Employee))]
        public XPCollection<HRS_Employee> HRS_Employees { get { return GetCollection<HRS_Employee>("HRS_Employees"); } }
    }

}
