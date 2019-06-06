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

    [Persistent(@"CDS_ITM.ITM_Movement")]
    public partial class CDS_ITM_ITM_Movement : XPLiteObject
    {
        long _Id;
        [Key(true)]
        public long Id
        {
            get { return _Id; }
            set { SetPropertyValue<long>("Id", ref _Id, value); }
        }
        CDS_SYS_SYS_DOC_Line _LineId;
        [Association(@"CDS_ITM_ITM_MovementReferencesCDS_SYS_SYS_DOC_Line")]
        public CDS_SYS_SYS_DOC_Line LineId
        {
            get { return _LineId; }
            set { SetPropertyValue<CDS_SYS_SYS_DOC_Line>("LineId", ref _LineId, value); }
        }
        decimal _OnHand;
        public decimal OnHand
        {
            get { return _OnHand; }
            set { SetPropertyValue<decimal>("OnHand", ref _OnHand, value); }
        }
        decimal _OnHold;
        public decimal OnHold
        {
            get { return _OnHold; }
            set { SetPropertyValue<decimal>("OnHold", ref _OnHold, value); }
        }
        decimal _OnOrder;
        public decimal OnOrder
        {
            get { return _OnOrder; }
            set { SetPropertyValue<decimal>("OnOrder", ref _OnOrder, value); }
        }
        decimal _OnReserve;
        public decimal OnReserve
        {
            get { return _OnReserve; }
            set { SetPropertyValue<decimal>("OnReserve", ref _OnReserve, value); }
        }
        decimal _UnitCost;
        public decimal UnitCost
        {
            get { return _UnitCost; }
            set { SetPropertyValue<decimal>("UnitCost", ref _UnitCost, value); }
        }
        decimal _UnitPrice;
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { SetPropertyValue<decimal>("UnitPrice", ref _UnitPrice, value); }
        }
        decimal _UnitAverage;
        public decimal UnitAverage
        {
            get { return _UnitAverage; }
            set { SetPropertyValue<decimal>("UnitAverage", ref _UnitAverage, value); }
        }
        decimal _NewUnitCost;
        public decimal NewUnitCost
        {
            get { return _NewUnitCost; }
            set { SetPropertyValue<decimal>("NewUnitCost", ref _NewUnitCost, value); }
        }
        decimal _NewUnitPrice;
        public decimal NewUnitPrice
        {
            get { return _NewUnitPrice; }
            set { SetPropertyValue<decimal>("NewUnitPrice", ref _NewUnitPrice, value); }
        }
        decimal _NewUnitAverage;
        public decimal NewUnitAverage
        {
            get { return _NewUnitAverage; }
            set { SetPropertyValue<decimal>("NewUnitAverage", ref _NewUnitAverage, value); }
        }
        DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }
        CDS_SYS_SYS_Person _CreatedBy;
        [Association(@"CDS_ITM_ITM_MovementReferencesCDS_SYS_SYS_Person")]
        public CDS_SYS_SYS_Person CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<CDS_SYS_SYS_Person>("CreatedBy", ref _CreatedBy, value); }
        }
    }

}