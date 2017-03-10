 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.GLX
{
    public class SiteAccounts
    {
        /*
         * BANK = 1
         * CARDCONTROL = 2
         * CASHCONTROL = 3
         * CHEQUECONTROL = 4
         * COSTDIFFERENCE = 5
         * COSTOFSALES = 6
         * CREDITCONTROL = 7
         * CREDITORS = 8
         * DEBTORS = 9
         * DISTRIBUTEDRESERVES = 10
         * EFTCONTROL = 11
         * INTERESTCHARGED = 12
         * INVENTORY = 13
         * PROFIT = 14
         * ROUNDING = 16
         * SALES = 17
         * SETTLEMENTDISCOUNTALLOWED = 18
         * SETTLEMENTDISCOUNTRECEIVED = 19
         * STOCKADJUSTMENT = 20
         * VATCONTROL = 21
         * VATINPUT = 22
         * VATOUTPUT = 23
         * INVENTORYBUYOUT = 24
         * */

        DB.SYS_Site Site;
        DB.SYS_Entity SiteEntity;
        DB.GLX_SiteAccount bank;
        DB.GLX_SiteAccount cardControl;
        DB.GLX_SiteAccount cashControl;
        DB.GLX_SiteAccount chequeControl;
        DB.GLX_SiteAccount costDifference;
        DB.GLX_SiteAccount costOfSales;
        DB.GLX_SiteAccount creditControl;
        DB.GLX_SiteAccount creditors;
        DB.SYS_Entity creditorsEntity;
        DB.GLX_SiteAccount debtors;
        DB.SYS_Entity debtorsEntity;
        DB.GLX_SiteAccount distributedReserves;
        DB.GLX_SiteAccount eftControl;
        DB.GLX_SiteAccount interestCharged;
        DB.GLX_SiteAccount inventory;
        DB.GLX_SiteAccount profit;
        DB.GLX_SiteAccount rounding;
        DB.GLX_SiteAccount sales;
        DB.GLX_SiteAccount settlemetnDiscountAllowed;
        DB.GLX_SiteAccount settlemetnDiscountRecieved;
        DB.GLX_SiteAccount stockAdjustment;
        DB.GLX_SiteAccount vatControl;
        DB.GLX_SiteAccount vatInput;
        DB.GLX_SiteAccount vatOutput;
        DB.GLX_SiteAccount inventoryBuyout;

        public SiteAccounts()
        {
            
            Site = ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.SYS_Entity.Id == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            SiteEntity = Site.SYS_Entity;

            List<int> siteTypes = Enum.GetValues(typeof(GLX.GLX_SystemAccountType)).Cast<int>().ToList();
            //SEAN: 
            //removed && n.SystemDefaultAccount == true here
            List<DB.GLX_SiteAccount> siteAccounts = ApplicationDataContext.Instance.AccountingEntityContext.GLX_SiteAccount.Where(n => siteTypes.Contains(n.TypeId) && n.SiteId == Site.EntityId).ToList();
            
            bank = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Bank);
            cardControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.CardControl);
            cashControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.CashControl);
            chequeControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.ChequeControl);
            costDifference = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.CostDifference);
            
            costOfSales = costOfSales = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.CostofSales);

            creditControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.CreditControl);
            creditors = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Creditors);
            if (creditors != null)
                creditorsEntity = ApplicationDataContext.Instance.SystemEntityContext.SYS_Entity.FirstOrDefault(n => n.Id == creditors.EntityId);
            debtors = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Debtors);
            if (debtors != null)
                debtorsEntity = ApplicationDataContext.Instance.SystemEntityContext.SYS_Entity.FirstOrDefault(n => n.Id == debtors.EntityId);
            distributedReserves = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Distributedreserves);
            eftControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Eftcontrol);
            interestCharged = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.InterestCharged);
            
            inventory = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Inventory);
           
            profit = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Profit);
            rounding = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Rounding);
            sales = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.Sales);
            settlemetnDiscountAllowed = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.SettlementDiscountAllowed);
            settlemetnDiscountRecieved = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.SettlementDiscountReceived);
            stockAdjustment = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.StockAdjustment);
            vatControl = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.VatControl);
            vatInput = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.VatInput);
            vatOutput = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.VatOutput);
            inventoryBuyout = siteAccounts.FirstOrDefault(n => n.TypeId == (byte)GLX.GLX_SystemAccountType.InventoryBuyout);
        }

        public DB.GLX_SiteAccount Bank { get { return bank; } }
        public DB.GLX_SiteAccount CardControl { get { return cardControl; } }
        public DB.GLX_SiteAccount CashControl { get { return cashControl; } }
        public DB.GLX_SiteAccount ChequeControl { get { return chequeControl; } }
        public DB.GLX_SiteAccount CostDifference { get { return costDifference; } }
        public DB.GLX_SiteAccount CostOfSales { get { return costOfSales; } }
        public DB.GLX_SiteAccount CreditControl { get { return creditControl; } }
        public DB.GLX_SiteAccount Creditors { get { return creditors; } }
        public DB.GLX_SiteAccount Debtors { get { return debtors; } }
        public DB.GLX_SiteAccount DistributedReserves { get { return distributedReserves; } }
        public DB.GLX_SiteAccount EFTControl { get { return eftControl; } }
        public DB.GLX_SiteAccount InterestCharged { get { return interestCharged; } }
        public DB.GLX_SiteAccount Inventory { get { return inventory; } }
        public DB.GLX_SiteAccount Profit { get { return profit; } }
        public DB.GLX_SiteAccount Rounding { get { return rounding; } }
        public DB.GLX_SiteAccount Sales { get { return sales; } }
        public DB.GLX_SiteAccount SettlemetnDiscountAllowed { get { return settlemetnDiscountAllowed; } }
        public DB.GLX_SiteAccount SettlemetnDiscountRecieved { get { return settlemetnDiscountRecieved; } }
        public DB.GLX_SiteAccount StockAdjustment { get { return stockAdjustment; } }
        public DB.GLX_SiteAccount VATControl { get { return vatControl; } }
        public DB.GLX_SiteAccount VATInput { get { return vatInput; } }
        public DB.GLX_SiteAccount VATOutput { get { return vatOutput; } }
        public DB.GLX_SiteAccount InventoryBuyout { get { return inventoryBuyout; } }

        public DB.SYS_Entity CreditorsEntity { get { return creditorsEntity; } }
        public DB.SYS_Entity DebtorsEntity { get { return debtorsEntity; } } 

        public void Reload()
        {
            ApplicationDataContext.Instance.SiteAccounts = new SiteAccounts();
        }

        internal static int ClearSiteAccounts(Int32 typeId, DataContext dataContext)
        {
            return dataContext.EntitySystemContext.ExecuteSqlCommand(string.Format("EXEC CDS_SYS.spClearSiteAccounts {0}", typeId));
        }

        public bool SiteAccountsSetUp()
        { 
            if (this.bank == null)
                return false;
            if (this.costDifference == null)
                return false;
            if (this.creditors == null)
                return false;
            if (this.debtors == null)
                return false;
            if (this.distributedReserves == null)
                return false;
            if (this.inventory == null)
                return false;
            if (this.profit == null)
                return false;
            if (this.sales == null)
                return false;
            if (this.stockAdjustment == null)
                return false;
            if (this.vatControl == null)
                return false;
            if (this.vatInput == null)
                return false;
            if (this.vatOutput == null)
                return false;
            if (this.inventoryBuyout == null)
                return false;
            if (ApplicationDataContext.Instance.CompanySite.RoundingAmount >= 0 && this.rounding == null)
                return false;

            //Return true if all site accounts have been assigned
            return true;
        }
    }
}
