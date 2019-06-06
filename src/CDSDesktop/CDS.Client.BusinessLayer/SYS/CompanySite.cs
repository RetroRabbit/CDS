using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = CDS.Client.DataAccessLayer.DB;

namespace CDS.Client.BusinessLayer.SYS
{
    public class CompanySite
    {

        DB.SYS_Site Site;
        DB.SYS_Entity Entity;
        DB.SYS_Entity stockTakeEntity;
        DB.SYS_Address billingAddress;
        DB.SYS_Address shippingAddress;
        DB.SYS_Printer printerBarcode;
        DB.SYS_Printer printerPicker;
        DB.SYS_Printer printerReceipt;

        public CompanySite()
        {

            Site = ApplicationDataContext.Instance.SystemEntityContext.SYS_Site.Include("SYS_Entity").FirstOrDefault(n => n.SYS_Entity.Id == ApplicationDataContext.Instance.LoggedInUser.DefaultSiteId);
            Entity = Site.SYS_Entity;
            billingAddress = Site.SYS_Address_BillingAddress; //dataContext.EntitySystemContext.SYS_Address.FirstOrDefault(n => n.Id == Site.BillingAddress);
            shippingAddress = Site.SYS_Address_ShippingAddress; //dataContext.EntitySystemContext.SYS_Address.FirstOrDefault(n => n.Id == Site.ShippingAddress);
            printerBarcode = Site.SYS_Printer_Barcode; //dataContext.EntitySystemContext.SYS_Printer.FirstOrDefault(n => n.Id == Site.PrinterBarcode);
            printerPicker = Site.SYS_Printer_Picker; //dataContext.EntitySystemContext.SYS_Printer.FirstOrDefault(n => n.Id == Site.PrinterPicker);
            printerReceipt = Site.SYS_Printer_Receipt; //dataContext.EntitySystemContext.SYS_Printer.FirstOrDefault(n => n.Id == Site.PrinterReceipt);
        }

        //ENTITY PROPERTIES
        public string Name { get { return Entity.Name; } }
        public string ShortName { get { return Entity.ShortName; } }


        //SITE PROPERTIES
        public DB.SYS_Address BillingAddress { get { return billingAddress; } }
        public DB.SYS_Address ShippingAddress { get { return shippingAddress; } }
        public string Telephone { get { return Site.Telephone; } }
        public string EmailAddress { get { return Site.EmailAddress; } }
        public string RegistrationNumber { get { return Site.RegistrationNumber; } }
        public decimal VatPercentage { get { return Site.VatPercentage; } }
        public string VatNumber { get { return Site.VatNumber; } }
        public string Currency { get { return Site.Currency; } }
        public short CashierRefreshIntervals { get { return Site.CashierRefreshIntervals; } }
        public string SMTPServerLocation { get { return Site.SMTPServerLocation; } }
        public string AccountEmailAddress { get { return Site.AccountEmailAddress; } }
        public string AccountEmailUsername { get { return Site.AccountEmailUsername; } }
        public string AccountEmailPassword { get { return Site.AccountEmailPassword; } }
        public string AccountEmailDomain { get { return Site.AccountEmailDomain; } }
        public string AccountEmailBCCAddress { get { return Site.AccountEmailBCCAddress; } }
        public string DocumentEmailAddress { get { return Site.DocumentEmailAddress; } }
        public string DocumentEmailUsername { get { return Site.DocumentEmailUsername; } }
        public string DocumentEmailPassword { get { return Site.DocumentEmailPassword; } }
        public string DocumentEmailDomain { get { return Site.DocumentEmailDomain; } }
        public string DocumentEmailBCCAddress { get { return Site.DocumentEmailBCCAddress; } }
        public string ProxyServerLocation { get { return Site.ProxyServerLocation; } }
        public string ProxyServerUsername { get { return Site.ProxyServerUsername; } }
        public string ProxyServerPassword { get { return Site.ProxyServerPassword; } }
        public string PrintServerLocation { get { return Site.PrintServerLocation; } }
        public string BankName { get { return Site.BankName; } }
        public string BankBranch { get { return Site.BankBranch; } }
        public string BankCode { get { return Site.BankCode; } }
        public string BankAccountNumber { get { return Site.BankAccountNumber; } }
        public string DefaultMessageDocument { get { return Site.DefaultMessageDocument; } }
        public string DefaultMessageStatement { get { return Site.DefaultMessageStatement; } }
        public DB.SYS_Printer PrinterBarcode { get { return printerBarcode; } }
        public DB.SYS_Printer PrinterPicker { get { return printerPicker; } }
        public DB.SYS_Printer PrinterReceipt { get { return printerReceipt; } }
        public string UpdateURL { get { return Site.UpdateURL; } }
        public bool MinimizeNavigation { get { return Site.MinimizeNavigation; } }
        public string UpdateCheckTime { get { return Site.UpdateCheckTime; } }
        public string PaymentAccounts { get { return Site.PaymentAccounts; } }
        public bool UseBarcodes { get { return Site.UseBarcodes; } }
        public bool UseLabels { get { return Site.UseLabels; } }
        public bool CopyInvoiceOrderNumbertoCreditNote { get { return Site.CopyInvoiceOrderNumbertoCreditNote; } }
        public bool AutoWriteoffOpenItemCredits { get { return Site.AutoWriteoffOpenItemCredits; } }
        public byte NegativeDiscountEffects { get { return Site.NegativeDiscountEffects.Value; } }
        public bool NotifyonZeroMarkupSale { get { return Site.NotifyonZeroMarkupSale; } }
        public bool NotifyonZeroProfitSale { get { return Site.NotifyonZeroProfitSale; } }
        public byte QuoteValidDays { get { return Site.QuoteValidDays.Value; } }
        public byte QuoteValidMax { get { return Site.QuoteValidMax.Value; } }
        public bool NotifyonBackOrder { get { return Site.NotifyonBackOrder; } }
        public decimal RoundingAmount { get { return Site.RoundingAmount.Value; } }
        public bool CashierPaymentsFullAmount { get { return Site.CashierPaymentsFullAmount; } }
        public byte CODAccountLimit { get { return Site.CODAccountLimit; } }
        public byte DebtorGracePeriod { get { return Site.DebtorGracePeriod; } }
        public decimal DefaultInterestCharged { get { return Site.DefaultInterestCharged.Value; } }
        public byte? MonthWeight3 { get { return Site.MonthWeight3; } }
        public byte? MonthWeight6 { get { return Site.MonthWeight6; } }
        public byte? MonthWeight12 { get { return Site.MonthWeight12; } }
        public byte? MonthWeight24 { get { return Site.MonthWeight24; } }
        public byte? MonthWeight36 { get { return Site.MonthWeight36; } }
        public decimal FixedOrderCost { get { return Site.FixedOrderCost.Value; } }
        public byte MaxOrderLines { get { return Site.MaxOrderLines.Value; } }
        public byte SafetyStockPeriod { get { return Site.SafetyStockPeriod.Value; } }
        public string DistributionNumber { get { return Site.DistributionNumber; } }
        public string BackupLocation { get { return Site.BackupLocation; } }
        public long? BuyoutSupplierAccount { get { return Site.BuyoutSupplierAccount; } }
        public string LineTypeFilter { get { return Site.LineTypeFilter; } }
        public byte[] LineTypeList
        {
            get
            {
                return new byte[] { 
                           (byte) SYS.SYS_Type.Inventory     ,
                           (byte) SYS.SYS_Type.Account       ,
                           (byte) SYS.SYS_Type.Message       ,
                           (byte) SYS.SYS_Type.BuyOut        ,
                           (byte) SYS.SYS_Type.Consignment   ,
                           (byte) SYS.SYS_Type.Surcharge };
            }
        }
        public void Reload()
        {
            ApplicationDataContext.Instance.CompanySite = new CompanySite();
        }
    }
}
