using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CDS.Client.DataAccessLayer.XDB
{
    [Persistent("CDS_SYS.SYS_Entity")]
    public partial class SYS_Entity
    {
        public SYS_Entity(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }

        [PersistentAlias("Id")]
        public Int64 PrimaryKey
        {
            get { return Convert.ToInt64(EvaluateAlias("PrimaryKey")); }
        }

        //GLX
        [PersistentAlias("IIF(TypeId.Name == 'Account',GLX_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate)].Sum(Amount),0)")]
        public decimal AccountBalance
        {
            get { return Convert.ToDecimal(EvaluateAlias("AccountBalance")); }
        }

        [PersistentAlias("IIF(GLX_SiteAccounts[SystemDefaultAccount = 1].Exists,1,0)")]
        public Boolean SiteAccount
        {
            get { return Convert.ToBoolean(EvaluateAlias("SiteAccount")); }
        }

        [PersistentAlias("IIF(TypeId.Name == 'Account' and GLX_AccountsEntity[AccountTypeId.Id = 1].Exists, 1, 0)")]
        public bool ShowOnSales
        {
            get { return Convert.ToBoolean(EvaluateAlias("ShowOnSales")); }
        }

        [PersistentAlias("IIF(TypeId.Name == 'Account' and GLX_AccountsEntity[AccountTypeId.Id = 3].Exists, 1, 0)")]
        public bool ShowOnPurchases
        {
            get { return Convert.ToBoolean(EvaluateAlias("ShowOnPurchases")); }
        }

        //ITM
        [PersistentAlias("IIF(ITM_Historys[].Exists,IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(OnHand),0),IIF(IBO_TRX_Headers[].Exists,IBO_TRX_Headers[].Sum(Quantity),null))")]
        public decimal OnHand
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnHand")); }
        }

        [PersistentAlias("IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(OnHold),0)")]
        public decimal OnHold
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnHold")); }
        }

        [PersistentAlias("IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(OnReserve),0)")]
        public decimal OnReserve
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnReserve")); }
        }

        [PersistentAlias("IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(OnOrder),0)")]
        public decimal OnOrder
        {
            get { return Convert.ToDecimal(EvaluateAlias("OnOrder")); }
        }

        [PersistentAlias("IIF(ITM_Historys[].Exists,IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(UnitPrice),0),IIF(IBO_TRX_Headers[].Exists,IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitPrice),null))")]
        public decimal UnitPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitPrice")); }
        }

        [PersistentAlias("IIF(ITM_Historys[].Exists,IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Min(UnitCost),0),IIF(IBO_TRX_Headers[].Exists,IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitCost),null))")]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitCost")); }
        }

        [PersistentAlias("IIF(ITM_Historys[].Exists,IsNull(ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Min(UnitAverage),0),IIF(IBO_TRX_Headers[].Exists,IBO_TRX_Headers[Id = ^.IBO_TRX_Headers[].Max(Id)].Max(UnitCost),null))")]
        public decimal UnitAverage
        {
            get { return Convert.ToDecimal(EvaluateAlias("UnitAverage")); }
        }

        [PersistentAlias("ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(FirstSold)")]
        public DateTime? FirstSold
        {
            get { return Convert.ToDateTime(EvaluateAlias("FirstSold")); }
        }

        [PersistentAlias("ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(LastMovement)")]
        public DateTime? LastMovement
        {
            get { return Convert.ToDateTime(EvaluateAlias("LastMovement")); }
        }

        [PersistentAlias("ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(FirstPurchased)")]
        public DateTime? FirstPurchased
        {
            get { return Convert.ToDateTime(EvaluateAlias("FirstPurchased")); }
        }

        [PersistentAlias("ITM_Historys[now() Between(PeriodId.StartDate,PeriodId.EndDate) AND SiteId.Id = ^.SiteId].Max(LastSold)")]
        public DateTime? LastSold
        {
            get { return Convert.ToDateTime(EvaluateAlias("LastSold")); }
        }

        [PersistentAlias("IIF(ITM_InventorySuppliers[PrimarySupplier = 1].Exists,ITM_InventorySuppliers[PrimarySupplier = 1].Max(SupplierStockCode),null)")]
        public string SupplierStockCode
        {
            get
            {
                return (string)EvaluateAlias("SupplierStockCode");
            }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(Category),'')")]
        public String Category
        {
            get { return (string)EvaluateAlias("Category"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(SubCategory),'')")]
        public String SubCategory
        {
            get { return (string)EvaluateAlias("SubCategory"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(StockType),'')")]
        public String StockType
        {
            get { return (string)EvaluateAlias("StockType"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(LocationMain),'')")]
        public String LocationMain
        {
            get { return (string)EvaluateAlias("LocationMain"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(LocationSecondary),'')")]
        public String LocationSecondary
        {
            get { return (string)EvaluateAlias("LocationSecondary"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(DiscountCode),'')")]
        public String DiscountCode
        {
            get { return (string)EvaluateAlias("DiscountCode"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(Grouping),'')")]
        public String Grouping
        {
            get { return (string)EvaluateAlias("Grouping"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(ProfitMargin),0.00)")]
        public Double ProfitMargin
        {
            get { return (Double)EvaluateAlias("ProfitMargin"); }
        }

        [PersistentAlias("IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[SiteId.Id = ^.SiteId].Max(Barcode),null)")]
        public String Barcode
        {
            get { return Convert.ToString(EvaluateAlias("Barcode")); }
        }

        //ORG
        [PersistentAlias("IIF(ORG_Entitys[ORG_Companys[TypeId.Id = 1]].Exists,1,0)")]
        public bool HasCustomer
        {
            get { return Convert.ToBoolean((int)EvaluateAlias("HasCustomer")); }
        }

        [PersistentAlias("IIF(ORG_Entitys[ORG_Companys[TypeId.Id = 2]].Exists,1,0)")]
        public bool HasSupplier
        {
            get { return Convert.ToBoolean((int)EvaluateAlias("HasSupplier")); }
        }

        [PersistentAlias("IIF(IBO_TRX_Headers[].Exists,IBO_TRX_Headers[].Sum(Quantity) <> 0,false)")]
        public bool HasBuyoutQuantity
        {
            get { return Convert.ToBoolean(EvaluateAlias("HasBuyoutQuantity")); }
        }
        [PersistentAlias("IIF(GLX_AccountsEntity[EntityId.Id = ^.Id].Exists,GLX_AccountsEntity[EntityId.Id = ^.Id].Max(SiteId.Id),IIF(ITM_Inventorys_EntityId[].Exists,ITM_Inventorys_EntityId[EntityId.Id = ^.Id].Max(SiteId.Id),null))")]
        public Int64 SiteId
        {
            get { return Convert.ToInt64(EvaluateAlias("SiteId")); }
        }
    }
}
