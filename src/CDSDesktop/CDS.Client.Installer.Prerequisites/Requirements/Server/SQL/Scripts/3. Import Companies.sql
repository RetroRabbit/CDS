
USE EXPORT_DB
GO
-- ------------------------------------------
-- Create Temp Company Code Mapping Table
-- ------------------------------------------
print '------------------------------------------'
print 'Create Temp Company Code Mapping Table'
print '------------------------------------------'
GO

select 
0 CompanyId
,pkCompanyGuid CompanyGuid
,fkAccountGuid AccountGuid
,case 
	when DENSE_RANK() over (partition by dbo.[fnMakeCode](isnull(scode,'0000000')) order by pkCompanyGuid) > 1 
	then dbo.[fnMakeCode](isnull(scode,'0000000')) + '_'+ convert(nvarchar(10),DENSE_RANK() over (partition by dbo.[fnMakeCode](isnull(scode,'0000000')) order by pkCompanyGuid)) 
	else dbo.[fnMakeCode](isnull(scode,'0000000'))
end CompanyCode
into tempCompany
from tblCompany


-- ------------------------------------------
-- Import Companies
-- ------------------------------------------
print '------------------------------------------'
print 'Import Companies'
print '------------------------------------------'
GO

insert into IMPORT_DB.[CDS_SYS].[SYS_Entity]
select 
3 TypeId
,'' CodeMain
,CompCodeMap.CompanyCode CodeSub
,isnull(exComp.sTradingName,'') ShortName
,isnull(exComp.sTradingName,'') Name
,'' Description
,exComp.bIsArchived Archived
,isnull(Creator.Id,1) CreatedBy
,exComp.dtCreatedOn CreatedOn
from tblCompany exComp
inner join tempCompany CompCodeMap on exComp.pkCompanyGuid=CompCodeMap.CompanyGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

UPDATE tempCompany set CompanyId = IMPORT_DB.[CDS_SYS].[SYS_Entity].Id
from tempCompany inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] on IMPORT_DB.[CDS_SYS].[SYS_Entity].CodeSub=tempCompany.CompanyCode

GO


INSERT INTO IMPORT_DB.[CDS_ORG].[ORG_Entity]
SELECT
inComp.Id EntityId
,exComp.sRegistrationNumber RegistrationNumber
,exComp.sVatNumber VatNumber
,exComp.sNotes Note
,exComp.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM 
tblCompany exComp
inner join tempCompany on exComp.pkCompanyGuid=tempCompany.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inComp on tempCompany.CompanyId=inComp.Id
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO


INSERT INTO IMPORT_DB.[CDS_ORG].[ORG_Company]
SELECT 
inComp.Id EntityId
, CASE WHEN exComp.bIsDebtor=1 THEN 1 ELSE 2 END TypeId
, tempPaymentTerm.TermId PaymentTermId
, tempCostCategory.CCId CostCategoryId
, null AccountId
, dbo.[fnMakePrefix](scode) Prefix
, exAccount.bOpenItem OpenItem
, exComp.bIsActive Active
, exComp.bIsRemoved OverrideAccount
, exAccount.dAccountLimit AccountLimit
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
inner join tblAccount exAccount on exComp.fkAccountGuid=exAccount.pkAccountGuid
inner join tempCompany on exComp.pkCompanyGuid=tempCompany.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on tempCompany.CompanyId=inEntity.Id
inner join IMPORT_DB.[CDS_ORG].[ORG_Entity] inComp on inEntity.Id=inComp.EntityId
inner join tempCostCategory on tempCostCategory.CCGuid = exAccount.fkCostCategoryGuid
inner join tempPaymentTerm on tempPaymentTerm.TermGuid = exAccount.fkSalesTermGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

print '------------------------------------------'
print 'Import Company Distribution'
print '------------------------------------------'
GO
INSERT INTO IMPORT_DB.cds_ORG.ORG_Distribution
SELECT ORG_Company.Id,
       CASE fkDistributionTypeGuid when '1FAED6F1-6CF7-4713-A3BE-8A29841F21EA' then 2 else 1 end,
       ISNULL(sDistributionNumber, tempCompany.CompanyCode),
       sPath,
       iInventoryViewLevel,
       sTeccomHeader,
       sCustomerCode,
       sSupplierCode,
       ISNULL(bViewCost, 0),
       tblDistribution.sUrl,
       tblDistribution.sUserName,
       tblDistribution.sPassword,
       ISNULL(tblDistribution.dtCreatedOn, GETDATE()),
       ISNULL(Creator.CreatedBy, 1)
FROM tblCompany
     INNER JOIN tempCompany ON tempCompany.CompanyGuid = tblCompany.pkCompanyGuid
     LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Entity ON tempCompany.CompanyCode = SYS_Entity.CodeSub
     LEFT JOIN IMPORT_DB.CDS_ORG.ORG_Entity ON SYS_Entity.Id = ORG_Entity.EntityId
	 LEFT JOIN IMPORT_DB.CDS_ORG.ORG_Company ON ORG_Entity.Id = ORG_Company.EntityId
     LEFT JOIN tblDistribution ON tblDistribution.fkCompanyGuid = tblCompany.pkCompanyGuid
     LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator ON tblDistribution.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
WHERE ORG_Entity.Id IS NOT NULL
ORDER BY ORG_Entity.Id;

-- ------------------------------------------
-- Import Company Addresses
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Addresses'
print '------------------------------------------'
GO

select
ROW_NUMBER() OVER(ORDER BY iCompanyAddressId) +(select MAX(Id) from IMPORT_DB.[CDS_SYS].[SYS_Address]) AddressId
, exCompAddress.pkCompanyAddressGuid AddressGuid
, inComp.Id CompanyId
, exCompAddress.dtCreatedOn CreatedOn 
,isnull(Creator.Id,1) CreatedBy
into tempAddress
from tblCompanyAddress exCompAddress
inner join tblCompany exComp on exCompAddress.fkCompanyGuid=exComp.pkCompanyGuid
inner join tempCompany on exComp.pkCompanyGuid=tempCompany.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on tempCompany.CompanyId=inEntity.Id
inner join IMPORT_DB.[CDS_ORG].[ORG_Entity] inCompEntity on inEntity.Id=inCompEntity.EntityId
inner join IMPORT_DB.[CDS_ORG].[ORG_Company] inComp on inCompEntity.Id=inComp.EntityId
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exCompAddress.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Address] ON
INSERT INTO IMPORT_DB.[CDS_SYS].[SYS_Address] (Id,TypeId,Line1,Line2,Line3,Line4,Code,CreatedOn,CreatedBy)
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
inner join tblCompany exComp on exCompAddress.fkCompanyGuid=exComp.pkCompanyGuid
inner join tempCompany on exComp.pkCompanyGuid=tempCompany.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inComp on tempCompany.CompanyId=inComp.Id

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Address] OFF
GO

INSERT INTO IMPORT_DB.[CDS_ORG].[ORG_CompanyAddress]
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

select 
dMonth MonthId
, periodId
into temp24MonthHistMap
FROM 
  (SELECT top 1
   pkAccountGuid, cast(d01month as money) [01] , cast(d02Month as money) [02], cast(d03Month as money) [03]  , cast(d04Month as money) [04]  , cast(d05Month as money) [05]  , cast(d06Month as money) [06]  , cast(d07Month as money) [07]  , cast(d08Month as money) [08]  , cast(d09Month as money) [09]  
, cast(d10Month as money) [10]  , cast(d11Month as money) [11]  , cast(d12Month as money) [12]  , cast(d13Month as money) [13]  , cast(d14Month as money) [14]  , cast(d15Month as money) [15]  , cast(d16Month as money) [16]  , cast(d17Month as money) [17] , cast(d18Month as money) [18]  
, cast(d19Month as money) [19]  , cast(d20Month as money) [20]  , cast(d21Month as money) [21]  , cast(d22Month as money) [22]  , cast(d23Month as money) [23]  , cast(d24Month as money) [24]  
   FROM tblAccount) p
UNPIVOT
   (hist FOR dMonth IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24])
)AS unpvt
inner join tempMEDates on  DATEDIFF(MONTH,  (select top 1 StartDate from tempImportStartDate),StartDate)=-cast(dMonth as int)

GO

--Last 24 month sales history
insert into IMPORT_DB.[CDS_ORG].[ORG_History] (PeriodId,CompanyId,Amount) 
SELECT  
temp24MonthHistMap.PeriodId PeriodId
,inComp.Id CompanyId
,unpvt.histAmnt Amount
FROM 
   (SELECT 
   fkCompanyGuid, cast(d01month as money) [01] , cast(d02Month as money) [02], cast(d03Month as money) [03]  , cast(d04Month as money) [04]  , cast(d05Month as money) [05]  , cast(d06Month as money) [06]  , cast(d07Month as money) [07]  , cast(d08Month as money) [08]  , cast(d09Month as money) [09]  
, cast(d10Month as money) [10]  , cast(d11Month as money) [11]  , cast(d12Month as money) [12]  , cast(d13Month as money) [13]  , cast(d14Month as money) [14]  , cast(d15Month as money) [15]  , cast(d16Month as money) [16]  , cast(d17Month as money) [17] , cast(d18Month as money) [18]  
, cast(d19Month as money) [19]  , cast(d20Month as money) [20]  , cast(d21Month as money) [21]  , cast(d22Month as money) [22]  , cast(d23Month as money) [23]  , cast(d24Month as money) [24]  
   FROM tblAccount) p
UNPIVOT
   (histAmnt FOR dMonth IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24])
)AS unpvt
inner join temp24MonthHistMap on MonthId=cast(dMonth as int)
inner join tempCompany CompCodeMap on unpvt.fkCompanyGuid=CompCodeMap.CompanyGuid
inner join IMPORT_DB.[CDS_ORG].[ORG_Entity] inCompEntity on CompCodeMap.CompanyId=inCompEntity.EntityId
inner join IMPORT_DB.[CDS_ORG].[ORG_Company] inComp on inCompEntity.Id=inComp.EntityId

GO

-- Current Period PLUS history

insert into IMPORT_DB.[CDS_ORG].[ORG_History] (PeriodId,CompanyId,Amount) 
SELECT 
ME.PeriodId PeriodId
,inComp.Id CompanyId
,0 Amount
from tempCompany Company
inner join IMPORT_DB.[CDS_ORG].[ORG_Entity] inCompEntity on Company.CompanyId=inCompEntity.EntityId
inner join IMPORT_DB.[CDS_ORG].[ORG_Company] inComp on inCompEntity.Id=inComp.EntityId
left join tempMEDates ME on ME.MEDate is null

GO


-- ------------------------------------------
-- Import Company Accounts
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Accounts'
print '------------------------------------------'
GO


insert into IMPORT_DB.[CDS_SYS].[SYS_Entity] 
select 
5 TypeId
,CASE WHEN excomp.bIsDebtor = 1 
THEN (select CodeMain from IMPORT_DB.[CDS_SYS].[SYS_Entity] Debtor inner join IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON Debtor.Id= siteA.EntityId and siteA.TypeId=9 and siteA.SystemDefaultAccount=1) 
ELSE (select CodeMain from IMPORT_DB.[CDS_SYS].[SYS_Entity] Creditor inner join IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON Creditor.Id= siteA.EntityId and siteA.TypeId=8 and siteA.SystemDefaultAccount=1) END CodeMain
,CompCodeMap.CompanyCode CodeSub
,exComp.sTradingName ShortName
,exComp.sTradingName Name
,'' Description
,exComp.bIsArchived Archived
,isnull(Creator.Id,1) CreatedBy
,exComp.dtCreatedOn CreatedOn
from tblCompany exComp
inner join tlCompanyType on pkCompanyTypeGuid = fkCompanyTypeGuid
inner join tempCompany CompCodeMap on exComp.pkCompanyGuid=CompCodeMap.CompanyGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exComp.sCreatedBy = Creator.Name + ' ' + Creator.Surname
where tlCompanyType.sName in ('Customer','Supplier')
GO

--DEBTORS
UPDATE IMPORT_DB.[CDS_ORG].[ORG_Company] SET AccountId=inAccountEntity.Id
FROM IMPORT_DB.[CDS_ORG].[ORG_Company] inComp 
INNER JOIN IMPORT_DB.[CDS_ORG].[ORG_Entity] inCompEntity on inComp.EntityId=inCompEntity.Id
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on inCompEntity.EntityId=inEntity.Id
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=9 and siteA.SystemDefaultAccount=1
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on inEntity.CodeSub = inAccountEntity.CodeSub AND inAccountEntity.CodeMain=ControlEntity.CodeMain
GO

--CREDITORS
UPDATE IMPORT_DB.[CDS_ORG].[ORG_Company] SET AccountId=inAccountEntity.Id
FROM IMPORT_DB.[CDS_ORG].[ORG_Company] inComp 
INNER JOIN IMPORT_DB.[CDS_ORG].[ORG_Entity] inCompEntity on inComp.EntityId=inCompEntity.Id
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on inCompEntity.EntityId=inEntity.Id
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=8 and siteA.SystemDefaultAccount=1
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on inEntity.CodeSub = inAccountEntity.CodeSub AND inAccountEntity.CodeMain=ControlEntity.CodeMain
GO

insert into IMPORT_DB.[CDS_GLX].[GLX_Account] (EntityId, AccountTypeId,CenterId,AgingAccount,ControlId,MasterControlId,BalanceGroup,CreatedOn,CreatedBy)
select 
inAccountEntity.Id EntityId
, CASE WHEN exComp.bIsDebtor=1 THEN 4 ELSE 5 END AccountTypeId
, null CenterId
, 1 AgingAccount
, ControlEntity.Id ControlId
, ControlEntity.Id MasterControlId
, null BalanceGroup
, exComp.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
from tblCompany exComp
inner join tblAccount exAccount on exComp.fkAccountGuid=exAccount.pkAccountGuid
inner join tempCompany CompCodeMap on exComp.pkCompanyGuid=CompCodeMap.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on CompCodeMap.CompanyCode = inAccountEntity.CodeSub
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on ControlEntity.CodeMain=inAccountEntity.CodeMain and ControlEntity.CodeSub='00000' AND ControlEntity.TypeId = 5
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

-- ------------------------------------------
-- Import Company Account Histories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Account Histories'
print '------------------------------------------'
GO

insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
SELECT 
me.PeriodId PeriodId
,inAccountEntity.Id EntityId
,Aging AgingId
,AgingAmount Amount
FROM 
   (SELECT fkAccountGuid, dtDate, dCurrent [1], d30Days [2], d60Days [3], d90Days [4], d120Days [5]
   FROM tblMonthEnd) p
UNPIVOT
   (AgingAmount FOR Aging IN 
      ([1], [2], [3], [4], [5])
)AS unpvt
inner join tempMEDates ME on unpvt.dtDate=ME.MEDate
inner join tblAccount exAccount on unpvt.fkAccountGuid=exAccount.pkAccountGuid
inner join tempCompany CompCodeMap on exAccount.fkCompanyGuid=CompCodeMap.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on CompCodeMap.CompanyCode = inAccountEntity.CodeSub and inAccountEntity.TypeId=5

GO


print '-------------------------------------------'
print 'Import Debtor and Creditor Future histories'
print '-------------------------------------------'
GO 

--delete GLX_History where EntityId in (select Id from SYS_Entity where Codemain in ('02308','03008') and CodeSub <> '00000') and PeriodId > 89

DECLARE @LastMeDate datetime = (select Max(dtdate) from tblMonthend)
DECLARE @LastPeriodDate datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where @LastMeDate between StartDate and EndDate)
DECLARE @CurrentPeriodDate_Current datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(DAY,-1,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriodDate_30 datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(MONTH,-2,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriodDate_60 datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(MONTH,-3,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriodDate_90 datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(MONTH,-4,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriodDate_120 datetime = (select EndDate from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(MONTH,-5,@LastPeriodDate) between StartDate and EndDate)

DECLARE @CurrentPeriod_LastPeriod bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(DAY,0,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriod_Current bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(DAY,5,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriod_30 bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(month,2,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriod_60 bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(month,3,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriod_90 bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(month,4,@LastPeriodDate) between StartDate and EndDate)
DECLARE @CurrentPeriod_120 bigint = (select Id from IMPORT_DB.[CDS_SYS].[SYS_Period] where DATEADD(month,5,@LastPeriodDate) between StartDate and EndDate)



select 
SYS_Period.Id PeriodId,SYS_Period.ENdDate
,GLX_History.EntityId
,GLX_History.AgingId
,GLX_History.Amount
into tmpFutureHistory
from IMPORT_DB.[CDS_GLX].[GLX_History] 
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] on EntityId = SYS_Entity.Id and PeriodID = @CurrentPeriod_LastPeriod and Codemain in (
select CodeMain from IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] Contr on Contr.Id=GLX_SiteAccount.EntityId where GLX_SiteAccount.TypeId=9 and SystemDefaultAccount=1
union all
select CodeMain from IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] Contr on Contr.Id=GLX_SiteAccount.EntityId where GLX_SiteAccount.TypeId=8 and SystemDefaultAccount=1 
) and CodeSub <> '00000'
inner join IMPORT_DB.[CDS_SYS].[SYS_Period] on SYS_Period.EndDate > @LastPeriodDate and 1=1 
--and SYS_Entity.ID = 5451
order by SYS_Period.Id
,GLX_History.EntityId
,GLX_History.AgingId

-------------------------------------------------------------
--				Move Current Month						   --
-------------------------------------------------------------
update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (4,5) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 5 and PeriodId = @CurrentPeriod_Current

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (3) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 4 and PeriodId = @CurrentPeriod_Current

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (2) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 3 and PeriodId = @CurrentPeriod_Current

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 2 and PeriodId = @CurrentPeriod_Current

update tmpFutureHistory set Amount = 
( select Sum(0) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 1 and PeriodId = @CurrentPeriod_Current

-------------------------------------------------------------
--				Move Month +1							   --
-------------------------------------------------------------
update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (4,5) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 5 and PeriodId = @CurrentPeriod_30

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (3) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 4 and PeriodId = @CurrentPeriod_30

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (2) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 3 and PeriodId = @CurrentPeriod_30

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 2 and PeriodId = @CurrentPeriod_30

update tmpFutureHistory set Amount = 
( select Sum(0) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_Current and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 1 and PeriodId = @CurrentPeriod_30

-------------------------------------------------------------
--				Move Month +2							   --
-------------------------------------------------------------
update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_30 and AgingId in (4,5) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 5 and PeriodId = @CurrentPeriod_60

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_30 and AgingId in (3) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 4 and PeriodId = @CurrentPeriod_60

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_30 and AgingId in (2) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 3 and PeriodId = @CurrentPeriod_60

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_30 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 2 and PeriodId = @CurrentPeriod_60

update tmpFutureHistory set Amount = 
( select Sum(0) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_30 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 1 and PeriodId = @CurrentPeriod_60
-------------------------------------------------------------
--				Move Month +3							   --
-------------------------------------------------------------
update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (4,5) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 5 and PeriodId = @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (3) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 4 and PeriodId = @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (2) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 3 and PeriodId = @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 2 and PeriodId = @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(0) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 1 and PeriodId = @CurrentPeriod_90 
-------------------------------------------------------------
--				Move Month +4							   --
-------------------------------------------------------------
update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (4,5) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 5 and PeriodId > @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (3) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 4 and PeriodId > @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (2) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 3 and PeriodId > @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(Amount) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 2 and PeriodId > @CurrentPeriod_90

update tmpFutureHistory set Amount = 
( select Sum(0) from tmpFutureHistory innertmpFutureHistory 
where innertmpFutureHistory.EntityId = tmpFutureHistory.EntityId and innertmpFutureHistory.PeriodId = @CurrentPeriod_60 and AgingId in (1) group by innertmpFutureHistory.PeriodId,innertmpFutureHistory.EntityId)
where AgingId = 1 and PeriodId > @CurrentPeriod_90 

insert into IMPORT_DB.[CDS_GLX].[GLX_History]
select PeriodId,EntityId,AgingId,Amount from tmpFutureHistory
drop table tmpFutureHistory

------------------------------------------------------------------------------

--insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
--select 
--me.PeriodId PeriodId
--,inAccountEntity.Id EntityId
--,Aging AgingId
--,0 Amount
--FROM 
--   (SELECT pkAccountGuid, dCurrent [1], d30Days [2], d60Days [3], d90Days [4], d120Days [5]
--   FROM tblAccount) p
--UNPIVOT
--   (AgingAmount FOR Aging IN 
--      ([1], [2], [3], [4], [5])
--)AS unpvt
--inner join tblAccount exAccount on unpvt.pkAccountGuid=exAccount.pkAccountGuid
--inner join tempCompany CompCodeMap on exAccount.fkCompanyGuid=CompCodeMap.CompanyGuid
--inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on CompCodeMap.CompanyCode = inAccountEntity.CodeSub and inAccountEntity.TypeId=5
--left join tempMEDates ME on ME.MEDate is null

GO

USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO