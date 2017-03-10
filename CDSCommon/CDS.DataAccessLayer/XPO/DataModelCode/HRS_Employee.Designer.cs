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

    [Persistent(@"CDS_HRS.HRS_Employee")]
    public partial class HRS_Employee : XPLiteObject
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
        string fSalutation;
        [Size(5)]
        public string Salutation
        {
            get { return fSalutation; }
            set { SetPropertyValue<string>("Salutation", ref fSalutation, value); }
        }
        string fNickname;
        public string Nickname
        {
            get { return fNickname; }
            set { SetPropertyValue<string>("Nickname", ref fNickname, value); }
        }
        byte[] fPhoto;
        [Size(SizeAttribute.Unlimited)]
        public byte[] Photo
        {
            get { return fPhoto; }
            set { SetPropertyValue<byte[]>("Photo", ref fPhoto, value); }
        }
        string fIdNumber;
        [Size(20)]
        public string IdNumber
        {
            get { return fIdNumber; }
            set { SetPropertyValue<string>("IdNumber", ref fIdNumber, value); }
        }
        string fPassportNumber;
        [Size(20)]
        public string PassportNumber
        {
            get { return fPassportNumber; }
            set { SetPropertyValue<string>("PassportNumber", ref fPassportNumber, value); }
        }
        DateTime fDateOfBirth;
        public DateTime DateOfBirth
        {
            get { return fDateOfBirth; }
            set { SetPropertyValue<DateTime>("DateOfBirth", ref fDateOfBirth, value); }
        }
        bool fGender;
        public bool Gender
        {
            get { return fGender; }
            set { SetPropertyValue<bool>("Gender", ref fGender, value); }
        }
        bool fMaritalStatus;
        public bool MaritalStatus
        {
            get { return fMaritalStatus; }
            set { SetPropertyValue<bool>("MaritalStatus", ref fMaritalStatus, value); }
        }
        short fNoOfDependents;
        public short NoOfDependents
        {
            get { return fNoOfDependents; }
            set { SetPropertyValue<short>("NoOfDependents", ref fNoOfDependents, value); }
        }
        string fRevenueOffice;
        [Size(50)]
        public string RevenueOffice
        {
            get { return fRevenueOffice; }
            set { SetPropertyValue<string>("RevenueOffice", ref fRevenueOffice, value); }
        }
        string fTaxNumber;
        [Size(20)]
        public string TaxNumber
        {
            get { return fTaxNumber; }
            set { SetPropertyValue<string>("TaxNumber", ref fTaxNumber, value); }
        }
        string fJobDescription;
        [Size(2000)]
        public string JobDescription
        {
            get { return fJobDescription; }
            set { SetPropertyValue<string>("JobDescription", ref fJobDescription, value); }
        }
        string fWorkNumber;
        [Size(20)]
        public string WorkNumber
        {
            get { return fWorkNumber; }
            set { SetPropertyValue<string>("WorkNumber", ref fWorkNumber, value); }
        }
        string fHomeNumber;
        [Size(20)]
        public string HomeNumber
        {
            get { return fHomeNumber; }
            set { SetPropertyValue<string>("HomeNumber", ref fHomeNumber, value); }
        }
        string fMobileNumber;
        [Size(20)]
        public string MobileNumber
        {
            get { return fMobileNumber; }
            set { SetPropertyValue<string>("MobileNumber", ref fMobileNumber, value); }
        }
        string fEmail;
        [Size(50)]
        public string Email
        {
            get { return fEmail; }
            set { SetPropertyValue<string>("Email", ref fEmail, value); }
        }
        string fPhysicalAddress;
        [Size(1000)]
        public string PhysicalAddress
        {
            get { return fPhysicalAddress; }
            set { SetPropertyValue<string>("PhysicalAddress", ref fPhysicalAddress, value); }
        }
        string fPostalAddress;
        [Size(1000)]
        public string PostalAddress
        {
            get { return fPostalAddress; }
            set { SetPropertyValue<string>("PostalAddress", ref fPostalAddress, value); }
        }
        string fContactName;
        public string ContactName
        {
            get { return fContactName; }
            set { SetPropertyValue<string>("ContactName", ref fContactName, value); }
        }
        string fContactTelephone;
        public string ContactTelephone
        {
            get { return fContactTelephone; }
            set { SetPropertyValue<string>("ContactTelephone", ref fContactTelephone, value); }
        }
        HRS_Role fRoleId;
        [Association(@"HRS_EmployeeReferencesHRS_Role")]
        public HRS_Role RoleId
        {
            get { return fRoleId; }
            set { SetPropertyValue<HRS_Role>("RoleId", ref fRoleId, value); }
        }
        SYS_Person fPersonId;
        [Association(@"HRS_EmployeeReferencesSYS_Person1")]
        public SYS_Person PersonId
        {
            get { return fPersonId; }
            set { SetPropertyValue<SYS_Person>("PersonId", ref fPersonId, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref fCreatedOn, value); }
        }
        SYS_Person fCreatedBy;
        [Association(@"HRS_EmployeeReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref fCreatedBy, value); }
        }
    }

}
