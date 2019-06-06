
USE EXPORT_DB
GO

-- ------------------------------------------
-- Import Companies
-- ------------------------------------------
print '------------------------------------------'
print 'Import Companies'
print '------------------------------------------'
GO





SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Entity ON
INSERT INTO IMPORT_DB.CDS_SYS.SYS_Entity (Id,TypeId,CodeMain,CodeSub,ShortName,Name,Description,Archived,CreatedBy,CreatedOn)
SELECT 
ROW_NUMBER() OVER (ORDER BY exComp.iCompanyId) + (select MAX(id) from IMPORT_DB.CDS_SYS.SYS_Entity)  Id
, 3 TypeId
, '' CodeMain
, a.CodeSub CodeSub
, a.Name ShortName
, a.Name Name
, isnull(a.Description,'') Description
, a.Archived Archived
,isnull(Creator.Id,1) CreatedBy
, exComp.dtCreatedOn CreatedOn
FROM tblCompany exComp 
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Entity OFF

GO


INSERT INTO IMPORT_DB.CDS_ORG.ORG_Entity
SELECT
inE.Id EntityId
,exComp.sRegistrationNumber RegistrationNumber
,exComp.sVatNumber VatNumber
,exComp.sNotes Note
,exComp.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM 
tblCompany exComp 
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO


INSERT INTO IMPORT_DB.CDS_ORG.ORG_Company
SELECT 
inComp.Id EntityId
, CASE WHEN exComp.bIsDebtor=1 THEN 1 ELSE 2 END TypeId
, tempPaymentTerm.TermId PaymentTermId
, tempCostCategory.CCId CostCategoryId
, null AccountId
, '' Prefix
, exAcc.bOpenItem OpenItem
, exComp.bIsActive Active
, exComp.bIsRemoved OverrideAccount
, exAcc.dAccountLimit AccountLimit
, SUBSTRING(exComp.sDiscountCode,1,20) DiscountCode
, exComp.sTagCode TagCode
, exComp.sAreaCode AreaCode
, exComp.sRepCode RepCode
, SUBSTRING(exComp.sSalesmanCode,1,20) SalesmanCode
, exComp.cStatementPreference StatementPreference
, exComp.sCountryCode CountryCode
, exComp.sURL URL
, exComp.sUsername Username
, exComp.sPassword Password
, exComp.sCustomValue1 CustomValue1
, exComp.sCustomValue2 CustomValue2
, exComp.sCustomValue3 CustomValue3
, exComp.sCustomValue4 CustomValue4
, exComp.sCustomValue5 CustomValue5
, exComp.sCustomValue6 CustomValue6
, exComp.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM 
tblCompany exComp
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
inner join IMPORT_DB.CDS_ORG.ORG_Entity inComp on inE.Id=inComp.EntityId
inner join tempCostCategory on tempCostCategory.CCGuid = exAcc.fkCostCategoryGuid
inner join tempPaymentTerm on tempPaymentTerm.TermGuid = exAcc.fkSalesTermGuid
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

print '------------------------------------------'
print 'Import Company Distribution'
print '------------------------------------------'
GO
INSERT INTO IMPORT_DB.CDS_ORG.ORG_Distribution
       SELECT ORG_Company.Id  ,
                     CASE fkDistributionTypeGuid
                         WHEN '1FAED6F1-6CF7-4713-A3BE-8A29841F21EA'
                         THEN 2
                         ELSE 1
                     END DistributionTypeId,
              sDistributionNumber DistributionNumber,
              sPath Path,
              iInventoryViewLevel InventoryViewLevel,
              sTeccomHeader TeccomHeader,
              sCustomerCode CustomerCode,
              sSupplierCode SupplierCode,
              bViewCost ViewCost,
              tblDistribution.sUrl Url,
              tblDistribution.sUserName UserName,
              tblDistribution.sPassword Password,
              ISNULL(tblDistribution.dtCreatedOn, GETDATE()) CreatedOn,
              ISNULL(SYS_Person.Id, 1) CreatedBy
       FROM tblCompany exComp
            LEFT JOIN tblDistribution ON exComp.pkCompanyGuid = tblDistribution.fkCompanyGuid
            LEFT JOIN tblAccount exAcc ON exComp.fkAccountGuid = exAcc.pkAccountGuid
            LEFT JOIN GLX_Account a ON exAcc.AccountId = a.Id
            LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE ON a.CodeMain = inE.CodeMain
                                                                             AND a.CodeSub = inE.CodeSub
		  LEFT JOIN IMPORT_DB.CDS_ORG.ORG_Entity ON inE.Id = ORG_Entity.EntityId
		  LEFT JOIN IMPORT_DB.CDS_ORG.ORG_Company ON inE.Id = ORG_Entity.EntityId
            LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person ON SYS_Person.Name + ' ' + SYS_Person.Surname = tblDistribution.sCreatedBy
       WHERE inE.TypeId = 5;
GO

-- ------------------------------------------
-- Import Company Addresses
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Addresses'
print '------------------------------------------'
GO

select
ROW_NUMBER() OVER(ORDER BY iCompanyAddressId) + isnull((select MAX(Id) from IMPORT_DB.CDS_SYS.SYS_Address),0) AddressId
, exCompAddress.pkCompanyAddressGuid AddressGuid
, inComp.Id CompanyId
, exCompAddress.dtCreatedOn CreatedOn 
,isnull(Creator.Id,1) CreatedBy
into tempAddress
from tblCompanyAddress exCompAddress
inner join tblCompany exComp on exCompAddress.fkCompanyGuid=exComp.pkCompanyGuid
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
inner join IMPORT_DB.CDS_ORG.ORG_Entity inCompEntity on inE.Id=inCompEntity.EntityId
inner join IMPORT_DB.CDS_ORG.ORG_Company inComp on inCompEntity.Id=inComp.EntityId
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exCompAddress.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Address ON
INSERT INTO IMPORT_DB.CDS_SYS.SYS_Address (Id,TypeId,Line1,Line2,Line3,Line4,Code,CreatedOn,CreatedBy)
SELECT
tempAddress.AddressId Id
, CASE WHEN exCompAddress.fkCompanyAddressTypeGuid='D41478A6-51EC-4E08-9A80-4B27D52AA884' THEN 1 ELSE 2 END TypeId
, exCompAddress.sAddress1 Line1
, exCompAddress.sAddress2 Line2
, exCompAddress.sAddress3 Line3
, exCompAddress.sPostalCode Line4
, '' Code
, exCompAddress.dtCreatedOn CreatedOn
,tempAddress.CreatedBy CreatedBy
FROM 
tblCompanyAddress exCompAddress
inner join tempAddress on exCompAddress.pkCompanyAddressGuid=tempAddress.AddressGuid

SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Address OFF
GO

INSERT INTO IMPORT_DB.CDS_ORG.ORG_CompanyAddress
SELECT
tempAddress.CompanyId CompanyId
, tempAddress.AddressId AddressId
, tempAddress.CreatedOn CreatedOn
, tempAddress.CreatedBy CreatedBy 
FROM
tempAddress

GO

-- ------------------------------------------
-- Import Company Histories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Histories'
print '------------------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.CDS_ORG.ORG_History ON
insert into IMPORT_DB.CDS_ORG.ORG_History (Id,PeriodId,CompanyId,Amount) 
SELECT 
ROW_NUMBER() OVER(ORDER BY h.Id) + isnull((select MAX(Id) from IMPORT_DB.CDS_ORG.ORG_History),0) Id
, inP.Id PeriodId
, inComp.id CompanyId
, h.Amount Amount
FROM ORG_History h
INNER JOIN GLX_Period p on h.PeriodId=p.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period inP on p.StartDate=inP.StartDate
INNER JOIN tblCompany exComp on h.CompanyId=exComp.iCompanyId
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
inner join IMPORT_DB.CDS_ORG.ORG_Entity inCompEntity on inE.Id=inCompEntity.EntityId
inner join IMPORT_DB.CDS_ORG.ORG_Company inComp on inCompEntity.Id=inComp.EntityId

SET IDENTITY_INSERT IMPORT_DB.CDS_ORG.ORG_History OFF

GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO