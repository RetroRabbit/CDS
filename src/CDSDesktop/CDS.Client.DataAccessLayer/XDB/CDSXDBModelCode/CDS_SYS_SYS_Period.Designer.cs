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

    [Persistent(@"CDS_SYS.SYS_Period")]
    public partial class CDS_SYS_SYS_Period : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { SetPropertyValue<DateTime>("StartDate", ref _StartDate, value); }
        }
        DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { SetPropertyValue<DateTime>("EndDate", ref _EndDate, value); }
        }
        string _Code;
        [Size(50)]
        public string Code
        {
            get { return _Code; }
            set { SetPropertyValue<string>("Code", ref _Code, value); }
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
        CDS_SYS_SYS_Status _StatusId;
        [Association(@"CDS_SYS_SYS_PeriodReferencesCDS_SYS_SYS_Status")]
        public CDS_SYS_SYS_Status StatusId
        {
            get { return _StatusId; }
            set { SetPropertyValue<CDS_SYS_SYS_Status>("StatusId", ref _StatusId, value); }
        }
        string _Title;
        [Size(151)]
        public string Title
        {
            get { return _Title; }
            set { SetPropertyValue<string>("Title", ref _Title, value); }
        }
        short _FinancialYear;
        public short FinancialYear
        {
            get { return _FinancialYear; }
            set { SetPropertyValue<short>("FinancialYear", ref _FinancialYear, value); }
        }
        short _FinancialQuarter;
        public short FinancialQuarter
        {
            get { return _FinancialQuarter; }
            set { SetPropertyValue<short>("FinancialQuarter", ref _FinancialQuarter, value); }
        }
        [Association(@"CDS_GLX_GLX_BudgetReferencesCDS_SYS_SYS_Period", typeof(CDS_GLX_GLX_Budget))]
        public XPCollection<CDS_GLX_GLX_Budget> CDS_GLX_GLX_Budgets { get { return GetCollection<CDS_GLX_GLX_Budget>("CDS_GLX_GLX_Budgets"); } }
        [Association(@"CDS_GLX_GLX_HeaderReferencesCDS_SYS_SYS_Period", typeof(CDS_GLX_GLX_Header))]
        public XPCollection<CDS_GLX_GLX_Header> CDS_GLX_GLX_Headers { get { return GetCollection<CDS_GLX_GLX_Header>("CDS_GLX_GLX_Headers"); } }
        [Association(@"CDS_GLX_GLX_HistoryReferencesCDS_SYS_SYS_Period", typeof(CDS_GLX_GLX_History))]
        public XPCollection<CDS_GLX_GLX_History> CDS_GLX_GLX_Historys { get { return GetCollection<CDS_GLX_GLX_History>("CDS_GLX_GLX_Historys"); } }
        [Association(@"CDS_ITM_ITM_HistoryReferencesCDS_SYS_SYS_Period", typeof(CDS_ITM_ITM_History))]
        public XPCollection<CDS_ITM_ITM_History> CDS_ITM_ITM_Historys { get { return GetCollection<CDS_ITM_ITM_History>("CDS_ITM_ITM_Historys"); } }
        [Association(@"CDS_ORG_ORG_HistoryReferencesCDS_SYS_SYS_Period", typeof(CDS_ORG_ORG_History))]
        public XPCollection<CDS_ORG_ORG_History> CDS_ORG_ORG_Historys { get { return GetCollection<CDS_ORG_ORG_History>("CDS_ORG_ORG_Historys"); } }
        [Association(@"CDS_GLX_GLX_StatementReferencesCDS_SYS_SYS_Period", typeof(CDS_GLX_GLX_Statement))]
        public XPCollection<CDS_GLX_GLX_Statement> CDS_GLX_GLX_Statements { get { return GetCollection<CDS_GLX_GLX_Statement>("CDS_GLX_GLX_Statements"); } }
    }

}