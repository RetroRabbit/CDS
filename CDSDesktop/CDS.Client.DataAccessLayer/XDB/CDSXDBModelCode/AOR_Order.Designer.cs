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

    public partial class AOR_Order : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        SYS_Entity _SupplierId;
        [Association(@"AOR_OrderReferencesSYS_Entity")]
        public SYS_Entity SupplierId
        {
            get { return _SupplierId; }
            set { SetPropertyValue<SYS_Entity>("SupplierId", ref _SupplierId, value); }
        }
        SYS_Status _StatusId;
        [Association(@"AOR_OrderReferencesSYS_Status")]
        public SYS_Status StatusId
        {
            get { return _StatusId; }
            set { SetPropertyValue<SYS_Status>("StatusId", ref _StatusId, value); }
        }
        DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { SetPropertyValue<DateTime>("StartDate", ref _StartDate, value); }
        }
        DateTime _OrderDate;
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            set { SetPropertyValue<DateTime>("OrderDate", ref _OrderDate, value); }
        }
        string _Filter;
        [Size(500)]
        public string Filter
        {
            get { return _Filter; }
            set { SetPropertyValue<string>("Filter", ref _Filter, value); }
        }
        byte _MonthWeight3;
        public byte MonthWeight3
        {
            get { return _MonthWeight3; }
            set { SetPropertyValue<byte>("MonthWeight3", ref _MonthWeight3, value); }
        }
        byte _MonthWeight6;
        public byte MonthWeight6
        {
            get { return _MonthWeight6; }
            set { SetPropertyValue<byte>("MonthWeight6", ref _MonthWeight6, value); }
        }
        byte _MonthWeight12;
        public byte MonthWeight12
        {
            get { return _MonthWeight12; }
            set { SetPropertyValue<byte>("MonthWeight12", ref _MonthWeight12, value); }
        }
        byte _MonthWeight24;
        public byte MonthWeight24
        {
            get { return _MonthWeight24; }
            set { SetPropertyValue<byte>("MonthWeight24", ref _MonthWeight24, value); }
        }
        byte _MonthWeight36;
        public byte MonthWeight36
        {
            get { return _MonthWeight36; }
            set { SetPropertyValue<byte>("MonthWeight36", ref _MonthWeight36, value); }
        }
        int _LastChangedLine;
        public int LastChangedLine
        {
            get { return _LastChangedLine; }
            set { SetPropertyValue<int>("LastChangedLine", ref _LastChangedLine, value); }
        }
        SYS_Person _CreatedBy;
        [Association(@"AOR_OrderReferencesSYS_Person")]
        public SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        [Association(@"AOR_OrderLineReferencesAOR_Order", typeof(AOR_OrderLine))]
        public XPCollection<AOR_OrderLine> AOR_OrderLines { get { return GetCollection<AOR_OrderLine>("AOR_OrderLines"); } }
    }

}
