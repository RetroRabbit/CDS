using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_ITM.ITM_Inventory")]
    public partial class ITM_Inventory
    {
        public ITM_Inventory(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        

        [PersistentAlias("EntityId.Archived")]
        public Boolean Archived
        {
            get { return Convert.ToBoolean(EvaluateAlias("Archived")); }
        }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        [PersistentAlias("Concat([SiteId], '|', [InventoryId])")]
        public string CombinedKey
        {
            get { return (string)EvaluateAlias("CombinedKey"); }
        }

        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(OnHand),IIF(^.IBO_TRX_Headers[].Exists,IBO_TRX_Headers[].Sum(Quantity),null))")]
        public decimal OnHand
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnHand")); }
        }

        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(OnHold),0)")]
        public decimal OnHold
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnHold")); }
        }

        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(OnOrder),0)")]
        public decimal OnOrder
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnOrder")); }
        }


        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,IsNull(SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(UnitPrice),0),IIF(^.IBO_TRX_Headers[].Exists,^.IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitPrice),null))")]
        public decimal UnitPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitPrice")); }
        }

        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,IsNull(SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(UnitCost),0),IIF(^.IBO_TRX_Headers[].Exists,^.IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitCost),null))")]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitCost")); }
        }

        [PersistentAlias("IIF(SiteId.ITM_Historys1[].Exists,IsNull(SiteId.ITM_Historys1[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.^.SiteId.Id AND InventoryId.Id = ^.^.EntityId.Id].Max(UnitAverage),0),IIF(^.IBO_TRX_Headers[].Exists,^.IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitAverage),null))")]
        public decimal UnitAverage
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitAverage")); }
        }


    }

}
