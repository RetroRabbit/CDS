using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDS.Client.BusinessLayer.SEC
{
    public enum AccessCodes : long
    {
        /// <summary>
        /// Finance
        /// </summary>
        FI = 4,
        /// <summary>
        /// Accounts
        /// </summary>
        FIAC = 23,
        /// <summary>
        /// View
        /// </summary>
        FIACRE = 54,
        /// <summary>
        /// Create
        /// </summary>
        FIACRECR = 271,
        /// <summary>
        /// Edit
        /// </summary>
        FIACREED = 55,
        /// <summary>
        /// Budgets
        /// </summary>
        FIBU = 24,
        /// <summary>
        /// View
        /// </summary>
        FIBURE = 56,
        /// <summary>
        /// Edit
        /// </summary>
        FIBUREED = 57,
        /// <summary>
        /// Entries
        /// </summary>
        FIEN = 26,
        /// <summary>
        /// View
        /// </summary>
        FIENRE = 61,
        /// <summary>
        /// Post
        /// </summary>
        FIENRE02 = 60,
        /// <summary>
        /// Post to Control Accounts
        /// </summary>
        FIENRE03 = 59,
        /// <summary>
        /// Receive Receipts
        /// </summary>
        FIENRE04 = 251,
        /// <summary>
        /// Make Payments
        /// </summary>
        FIENRE05 = 112,
        /// <summary>
        /// Bulk Entries
        /// </summary>
        FIENRE06 = 58,
        /// <summary>
        /// Bulk Receipts
        /// </summary>
        FIENRE07 = 247,
        /// <summary>
        /// Bulk Payments
        /// </summary>
        FIENRE08 = 248,
        /// <summary>
        /// Create
        /// </summary>
        FIENRECR = 272,
        /// <summary>
        /// Recons
        /// </summary>
        FIRE = 28,
        /// <summary>
        /// View
        /// </summary>
        FIRERE = 69,
        /// <summary>
        /// Finalize Recon
        /// </summary>
        FIRERE03 = 68,
        /// <summary>
        /// Create
        /// </summary>
        FIRERECR = 273,
        /// <summary>
        /// Edit
        /// </summary>
        FIREREED = 70,
        /// <summary>
        /// Reports
        /// </summary>
        FIRP = 29,
        /// <summary>
        /// Tax
        /// </summary>
        FITA = 30,
        /// <summary>
        /// View
        /// </summary>
        FITARE = 71,
        /// <summary>
        /// Create
        /// </summary>
        FITARECR = 274,
        /// <summary>
        /// Edit
        /// </summary>
        FITAREED = 72,
        /// <summary>
        /// Human Resources
        /// </summary>
        HR = 10,
        /// <summary>
        /// Employee
        /// </summary>
        HREM = 41,
        /// <summary>
        /// View
        /// </summary>
        HREMRE = 119,
        /// <summary>
        /// Create
        /// </summary>
        HREMRECR = 276,
        /// <summary>
        /// Edit
        /// </summary>
        HREMREED = 120,
        /// <summary>
        /// Role
        /// </summary>
        HRRL = 40,
        /// <summary>
        /// View
        /// </summary>
        HRRLRE = 117,
        /// <summary>
        /// Create
        /// </summary>
        HRRLRECR = 275,
        /// <summary>
        /// Edit
        /// </summary>
        HRRLREED = 118,
        /// <summary>
        /// Inventory
        /// </summary>
        IN = 3,
        /// <summary>
        /// Automatic Ordering
        /// </summary>
        INAO = 93,
        /// <summary>
        /// View
        /// </summary>
        INAORE = 283,
        /// <summary>
        /// Create
        /// </summary>
        INAORECR = 284,
        /// <summary>
        /// Catalogue
        /// </summary>
        INCA = 33,
        /// <summary>
        /// Edit
        /// </summary>
        INCAED = 277,
        /// <summary>
        /// Discount
        /// </summary>
        INDI = 260,
        /// <summary>
        /// View
        /// </summary>
        INDIRE = 261,
        /// <summary>
        /// Create
        /// </summary>
        INDIRECR = 278,
        /// <summary>
        /// Edit
        /// </summary>
        INDIREED = 262,
        /// <summary>
        /// Documents
        /// </summary>
        INDO = 32,
        /// <summary>
        /// Adjustment
        /// </summary>
        INDOAD = 73,
        /// <summary>
        /// View
        /// </summary>
        INDOADRE = 151,
        /// <summary>
        /// Create
        /// </summary>
        INDOADRECR = 152,
        /// <summary>
        /// Stock Take
        /// </summary>
        INSK = 97,
        /// <summary>
        /// View
        /// </summary>
        INSKRE = 281,
        /// <summary>
        /// Finalise
        /// </summary>
        INSKRE02 = 94,
        /// <summary>
        /// Create
        /// </summary>
        INSKRECR = 282,
        /// <summary>
        /// Stock
        /// </summary>
        INST = 37,
        /// <summary>
        /// View
        /// </summary>
        INSTRE = 95,
        /// <summary>
        /// View Cost Prices
        /// </summary>
        INSTRE03 = 96,
        /// <summary>
        /// Create
        /// </summary>
        INSTRECR = 280,
        /// <summary>
        /// Edit
        /// </summary>
        INSTREED = 98,
        /// <summary>     
        ///Buyouts	 
        /// </summary>
        INBU = 299,
        /// <summary>     
        ///View	     
        /// </summary>
        INBURE = 300,
        /// <summary>     
        ///Create	     
        /// </summary>
        INBURECR = 301,
        /// <summary>     
        ///Edit	     
        /// </summary>
        INBUREED = 302,
        /// <summary>     
        ///Surcharge	 
        /// </summary>
        INSU = 303,
        /// <summary>     
        ///View	     
        /// </summary>
        INSURE = 304,
        /// <summary>     
        ///Create      
        /// </summary>
        INSURECR = 305,
        /// <summary>     
        ///Edit	     
        /// </summary>
        INSUREED = 308,
        /// <summary>
        /// Organisations
        /// </summary> 
        OR = 9,
        /// <summary>
        /// Contacts
        /// </summary>
        ORCO = 244,
        /// <summary>
        /// View
        /// </summary>
        ORCORE = 245,
        /// <summary>
        /// Create
        /// </summary>
        ORCORECR = 285,
        /// <summary>
        /// Edit
        /// </summary>
        ORCOREED = 246,
        /// <summary>
        /// Customers
        /// </summary>
        ORCU = 38,
        /// <summary>
        /// View
        /// </summary>
        ORCURE = 104,
        /// <summary>
        /// Statements
        /// </summary>
        ORCURE01 = 107,
        /// <summary>
        /// Change Cost Category
        /// </summary>
        ORCURE03 = 101,
        /// <summary>
        /// Change Payment Terms
        /// </summary>
        ORCURE04 = 102,
        /// <summary>
        /// Create
        /// </summary>
        ORCURECR = 286,
        /// <summary>
        /// Edit
        /// </summary>
        ORCUREED = 110,
        /// <summary>
        /// Entities
        /// </summary>
        OREN = 256,
        /// <summary>
        /// View
        /// </summary>
        ORENRE = 257,
        /// <summary>
        /// Create
        /// </summary>
        ORENRECR = 287,
        /// <summary>
        /// Edit
        /// </summary>
        ORENREED = 259,
        /// <summary>
        /// Suppliers
        /// </summary>
        ORSU = 39,
        /// <summary>
        /// View
        /// </summary>
        ORSURE = 113,
        /// <summary>
        /// Remittances
        /// </summary>
        ORSURE01 = 114,
        /// <summary>
        /// Change Cost Category
        /// </summary>
        ORSURE03 = 263,
        /// <summary>
        /// Change Payment Terms
        /// </summary>
        ORSURE04 = 264,
        /// <summary>
        /// Create
        /// </summary>
        ORSURECR = 288,
        /// <summary>
        /// Edit
        /// </summary>
        ORSUREED = 116,
        /// <summary>
        /// Purchases
        /// </summary>
        PU = 2,
        /// <summary>
        /// Calendar
        /// </summary>
        PUCA = 42,
        /// <summary>
        /// Documents
        /// </summary>
        PUDO = 43,
        /// <summary>
        /// Goods Received
        /// </summary>
        PUDOGR = 123,
        /// <summary>
        /// View
        /// </summary>
        PUDOGRRE = 166,
        /// <summary>
        /// Create
        /// </summary>
        PUDOGRRECR = 167,
        /// <summary>
        /// Purchase Order
        /// </summary>
        PUDOPO = 124,
        /// <summary>
        /// View
        /// </summary>
        PUDOPORE = 180,
        /// <summary>
        /// Create
        /// </summary>
        PUDOPORECR = 181,
        /// <summary>
        /// Goods Returned
        /// </summary>
        PUDORU = 122,
        /// <summary>
        /// View
        /// </summary>
        PUDORURE = 174,
        /// <summary>
        /// Create
        /// </summary>
        PUDORURECR = 175,
        /// <summary>
        /// Reporting
        /// </summary>
        RE = 6,
        /// <summary>
        /// Analytics
        /// </summary>
        REAN = 44,
        /// <summary>
        /// View
        /// </summary>
        REANRE = 126,
        /// <summary>
        /// Create
        /// </summary>
        REANRECR = 127,
        /// <summary>
        /// Reports
        /// </summary>
        RERP = 45,
        /// <summary>
        /// View
        /// </summary>
        RERPRE = 128,
        /// <summary>
        /// Create
        /// </summary>
        RERPRECR = 129,
        /// <summary>
        /// Sales
        /// </summary>
        SA = 1,
        /// <summary>
        /// Calendar
        /// </summary>
        SACA = 11,
        /// <summary>
        /// Documents
        /// </summary>
        SADO = 12,
        /// <summary>
        /// Back Order
        /// </summary>
        SADOBO = 130,
        /// <summary>
        /// View 
        /// </summary>
        SADOBORE = 185,
        /// <summary>
        /// Create
        /// </summary>
        SADOBORECR = 186,
        /// <summary>
        /// Sales Quote
        /// </summary>
        SADOQT = 134,
        /// <summary>
        /// View
        /// </summary>
        SADOQTRE = 199,
        /// <summary>
        /// Create
        /// </summary>
        SADOQTRECR = 200,
        /// <summary>
        /// Change Discount
        /// </summary>
        SADOQTRECR01 = 187,
        /// <summary>
        /// Change Unit Price
        /// </summary>
        SADOQTRECR02 = 191,
        /// <summary>
        /// Change Rep Code
        /// </summary>
        SADOQTRECR03 = 189,
        /// <summary>
        /// Change Salesman Code
        /// </summary>
        SADOQTRECR04 = 190,
        /// <summary>
        /// Sell Below Cost
        /// </summary>
        SADOQTRECR05 = 297,
        /// <summary>
        /// Sell Below Mark up
        /// </summary>
        SADOQTRECR06 = 298,
        /// <summary>
        /// Sales Credit
        /// </summary>
        SADOSC = 131,
        /// <summary>
        /// View
        /// </summary>
        SADOSCRE = 207,
        /// <summary>
        /// Authorise
        /// </summary>
        SADOSCRE01 = 201,
        /// <summary>
        /// Create
        /// </summary>
        SADOSCRECR = 209,
        /// <summary>
        /// Unlinked Credit
        /// </summary>
        SADOSCRECR01 = 208,
        /// <summary>
        /// Sales Invoice
        /// </summary>
        SADOTI = 132,
        /// <summary>
        /// Reprint
        /// </summary>
        SADOTI01 = 217,
        /// <summary>
        /// View
        /// </summary>
        SADOTIRE = 216,
        /// <summary>
        /// Create
        /// </summary>
        SADOTIRECR = 222,
        /// <summary>
        /// Sales Order
        /// </summary>
        SADOSO = 133,
        /// <summary>
        /// View
        /// </summary>
        SADOSORE = 239,
        /// <summary>
        /// Create
        /// </summary>
        SADOSORECR = 240,
        /// <summary>
        /// Change Discount 
        /// </summary>
        SADOSORECR01 = 226,
        /// <summary>
        /// Change Unit Price
        /// </summary>
        SADOSORECR02 = 231,
        /// <summary>
        /// Change Rep Code
        /// </summary>
        SADOSORECR03 = 229,
        /// <summary>
        /// Change Salesman Code
        /// </summary>
        SADOSORECR04 = 230,
        /// <summary>
        /// Sell Below Cost
        /// </summary>
        SADOSORECR05 = 295,
        /// <summary>
        /// Sell Below Mark up
        /// </summary>
        SADOSORECR06 = 296,
        /// <summary>
        /// System
        /// </summary>
        SY = 8,
        /// <summary>
        /// Manual Backup
        /// </summary>
        SYBA = 47,
        /// <summary>
        /// Centers
        /// </summary>
        SYCE = 25,
        /// <summary>
        /// View
        /// </summary>
        SYCERE = 62,
        /// <summary>
        /// Create
        /// </summary>
        SYCERECR = 63,
        /// <summary>
        /// Edit
        /// </summary>
        SYCEREED = 294,
        /// <summary>
        /// General
        /// </summary>
        SYGE = 46,
        /// <summary>
        /// Archive Items
        /// </summary>
        SYGE01 = 135,
        /// <summary>
        /// Update Server
        /// </summary>
        SYGE03 = 137,
        /// <summary>
        /// Module
        /// </summary>
        SYMO = 253,
        /// <summary>
        /// View
        /// </summary>
        SYMORE = 254,
        /// <summary>
        /// Edit
        /// </summary>
        SYMOREED = 255,
        /// <summary>
        /// Periods
        /// </summary>
        SYPE = 27,
        /// <summary>
        /// View
        /// </summary>
        SYPERE = 66,
        /// <summary>
        /// Close Period
        /// </summary>
        SYPERE01 = 65,
        /// <summary>
        /// Create
        /// </summary>
        SYPERECR = 67,
        /// <summary>
        /// Printers
        /// </summary>
        SYPR = 48,
        /// <summary>
        /// Change Active Printer
        /// </summary>
        SYPR01 = 138,
        /// <summary>
        /// View
        /// </summary>
        SYPRRE = 139,
        /// <summary>
        /// Create
        /// </summary>
        SYPRRECR = 140,
        /// <summary>
        /// Edit
        /// </summary>
        SYPRREED = 293,
        /// <summary>
        /// Security
        /// </summary>
        SYSE = 49,
        /// <summary>
        /// Roles
        /// </summary>
        SYSERL = 268,
        /// <summary>
        /// View
        /// </summary>
        SYSERLRE = 141,
        /// <summary>
        /// Create
        /// </summary>
        SYSERLRECR = 143,
        /// <summary>
        /// Edit
        /// </summary>
        SYSERLREED = 289,
        /// <summary>
        /// Users
        /// </summary>
        SYSEUR = 269,
        /// <summary>
        /// View
        /// </summary>
        SYSEURRE = 142,
        /// <summary>
        /// Create
        /// </summary>
        SYSEURRECR = 144,
        /// <summary>
        /// Edit
        /// </summary>
        SYSEURREED = 290,
        /// <summary>
        /// Site
        /// </summary>
        SYSI = 50,
        /// <summary>
        /// Change Active Site
        /// </summary>
        SYSI01 = 145,
        /// <summary>
        /// View
        /// </summary>
        SYSIRE = 146,
        /// <summary>
        /// Create
        /// </summary>
        SYSIRECR = 147,
        /// <summary>
        /// Edit
        /// </summary>
        SYSIREED = 291,
        /// <summary>
        /// Workshop
        /// </summary>
        WS = 5,
        /// <summary>
        /// Calendar
        /// </summary>
        WSCA = 51,
        /// <summary>
        /// Documents
        /// </summary>
        WSDO = 52,
        /// <summary>
        /// Job Card
        /// </summary>
        WSDOJC = 148,
        /// <summary>
        /// View
        /// </summary>
        WSDOJCRE = 241,
        /// <summary>
        /// Create
        /// </summary>
        WSDOJCRECR = 242,
        /// <summary>
        /// Edit
        /// </summary>
        WSDOJCREED = 292,
        /// <summary>
        /// Remove Items
        /// </summary>
        WSDOJCREED01 = 243,
        /// <summary>
        /// Job Quote
        /// </summary>
        WSDOQT = 299,
        /// <summary>
        /// Read
        /// </summary>
        WSDOQTRE = 300,
        /// <summary>
        /// Create
        /// </summary>
        WSDOQTRECR = 301,
        /// <summary>
        /// All Accounts
        /// </summary>
        FIAA = 309,
        /// <summary>
        /// View
        /// </summary>
        FIAARE = 310,
        /// <summary>
        /// Edit
        /// </summary>
        FIAAREED = 311,
        /// <summary>
        /// Create
        /// </summary>
        FIAARECR = 312,

    }
}
