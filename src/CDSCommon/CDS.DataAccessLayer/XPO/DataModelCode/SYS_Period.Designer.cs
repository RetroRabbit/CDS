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

    [Persistent(@"CDS_SYS.SYS_Period")]
    public partial class SYS_Period : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        DateTime fStartDate;
        public DateTime StartDate
        {
            get { return fStartDate; }
            set { SetPropertyValue<DateTime>("StartDate", ref fStartDate, value); }
        }
        DateTime fEndDate;
        public DateTime EndDate
        {
            get { return fEndDate; }
            set { SetPropertyValue<DateTime>("EndDate", ref fEndDate, value); }
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
        CDS.DataAccessLayer.XPO.Enums.SYS_Status fStatusId;
        public CDS.DataAccessLayer.XPO.Enums.SYS_Status StatusId
        {
            get { return fStatusId; }
            set { SetPropertyValue<CDS.DataAccessLayer.XPO.Enums.SYS_Status>("StatusId", ref fStatusId, value); }
        }
        string fTitle;
        [Size(151)]
        public string Title
        {
            get { return fTitle; }
            set { SetPropertyValue<string>("Title", ref fTitle, value); }
        }
        short fFinancialYear;
        public short FinancialYear
        {
            get { return fFinancialYear; }
            set { SetPropertyValue<short>("FinancialYear", ref fFinancialYear, value); }
        }
        short fFinancialQuarter;
        public short FinancialQuarter
        {
            get { return fFinancialQuarter; }
            set { SetPropertyValue<short>("FinancialQuarter", ref fFinancialQuarter, value); }
        }
        [Association(@"GLX_BudgetReferencesSYS_Period", typeof(GLX_Budget))]
        public XPCollection<GLX_Budget> GLX_Budgets { get { return GetCollection<GLX_Budget>("GLX_Budgets"); } }
        [Association(@"GLX_HeaderReferencesSYS_Period", typeof(GLX_Header))]
        public XPCollection<GLX_Header> GLX_Headers { get { return GetCollection<GLX_Header>("GLX_Headers"); } }
        [Association(@"GLX_HistoryReferencesSYS_Period", typeof(GLX_History))]
        public XPCollection<GLX_History> GLX_Historys { get { return GetCollection<GLX_History>("GLX_Historys"); } }
        [Association(@"IBO_HistoryReferencesSYS_Period", typeof(IBO_History))]
        public XPCollection<IBO_History> IBO_Historys { get { return GetCollection<IBO_History>("IBO_Historys"); } }
        [Association(@"ITM_HistoryReferencesSYS_Period", typeof(ITM_History))]
        public XPCollection<ITM_History> ITM_Historys { get { return GetCollection<ITM_History>("ITM_Historys"); } }
        [Association(@"ORG_HistoryReferencesSYS_Period", typeof(ORG_History))]
        public XPCollection<ORG_History> ORG_Historys { get { return GetCollection<ORG_History>("ORG_Historys"); } }
    }

}