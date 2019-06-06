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

    [Persistent(@"CDS_ITM.ITM_History")]
    public partial class ITM_History : XPLiteObject
    {
        long fId;
        [Key(true)]
        public long Id
        {
            get { return fId; }
            set { SetPropertyValue<long>("Id", ref fId, value); }
        }
        SYS_Entity fInventoryId;
        [Association(@"ITM_HistoryReferencesSYS_Entity")]
        public SYS_Entity InventoryId
        {
            get { return fInventoryId; }
            set { SetPropertyValue<SYS_Entity>("InventoryId", ref fInventoryId, value); }
        }
        SYS_Period fPeriodId;
        [Association(@"ITM_HistoryReferencesSYS_Period")]
        public SYS_Period PeriodId
        {
            get { return fPeriodId; }
            set { SetPropertyValue<SYS_Period>("PeriodId", ref fPeriodId, value); }
        }
        decimal fAmount;
        public decimal Amount
        {
            get { return fAmount; }
            set { SetPropertyValue<decimal>("Amount", ref fAmount, value); }
        }
        decimal fMovement;
        public decimal Movement
        {
            get { return fMovement; }
            set { SetPropertyValue<decimal>("Movement", ref fMovement, value); }
        }
        decimal fOnHand;
        public decimal OnHand
        {
            get { return fOnHand; }
            set { SetPropertyValue<decimal>("OnHand", ref fOnHand, value); }
        }
        decimal fOnReserve;
        public decimal OnReserve
        {
            get { return fOnReserve; }
            set { SetPropertyValue<decimal>("OnReserve", ref fOnReserve, value); }
        }
        decimal fOnOrder;
        public decimal OnOrder
        {
            get { return fOnOrder; }
            set { SetPropertyValue<decimal>("OnOrder", ref fOnOrder, value); }
        }
        decimal fUnitPrice;
        public decimal UnitPrice
        {
            get { return fUnitPrice; }
            set { SetPropertyValue<decimal>("UnitPrice", ref fUnitPrice, value); }
        }
        decimal fUnitCost;
        public decimal UnitCost
        {
            get { return fUnitCost; }
            set { SetPropertyValue<decimal>("UnitCost", ref fUnitCost, value); }
        }
        decimal fUnitAverage;
        public decimal UnitAverage
        {
            get { return fUnitAverage; }
            set { SetPropertyValue<decimal>("UnitAverage", ref fUnitAverage, value); }
        }
        DateTime fFirstSold;
        public DateTime FirstSold
        {
            get { return fFirstSold; }
            set { SetPropertyValue<DateTime>("FirstSold", ref fFirstSold, value); }
        }
        DateTime fFirstPurchased;
        public DateTime FirstPurchased
        {
            get { return fFirstPurchased; }
            set { SetPropertyValue<DateTime>("FirstPurchased", ref fFirstPurchased, value); }
        }
        DateTime fLastSold;
        public DateTime LastSold
        {
            get { return fLastSold; }
            set { SetPropertyValue<DateTime>("LastSold", ref fLastSold, value); }
        }
        DateTime fLastPurchased;
        public DateTime LastPurchased
        {
            get { return fLastPurchased; }
            set { SetPropertyValue<DateTime>("LastPurchased", ref fLastPurchased, value); }
        }
        DateTime fLastMovement;
        public DateTime LastMovement
        {
            get { return fLastMovement; }
            set { SetPropertyValue<DateTime>("LastMovement", ref fLastMovement, value); }
        }
        decimal fSales12;
        public decimal Sales12
        {
            get { return fSales12; }
            set { SetPropertyValue<decimal>("Sales12", ref fSales12, value); }
        }
        decimal fSales6;
        public decimal Sales6
        {
            get { return fSales6; }
            set { SetPropertyValue<decimal>("Sales6", ref fSales6, value); }
        }
        decimal fSales3;
        public decimal Sales3
        {
            get { return fSales3; }
            set { SetPropertyValue<decimal>("Sales3", ref fSales3, value); }
        }
    }

}