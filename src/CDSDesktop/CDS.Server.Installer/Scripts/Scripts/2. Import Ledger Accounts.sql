
USE EXPORT_DB
GO
-- ------------------------------------------
-- Import GL Accounts
-- ------------------------------------------
print '------------------------------------------'
print 'Import GL Accounts'
print '------------------------------------------'
GO

select 
ROW_NUMBER() OVER (ORDER BY tblGeneralLedgerAccount.iGeneralLedgerAccountId) + (select MAX(id) from IMPORT_DB.[CDS_SYS].[SYS_Entity]) AccountId
,pkGeneralLedgerAccountGuid AccountGuid
,case 
	when DENSE_RANK() over (partition by RIGHT('00000'+LEFT(sCode, 5),5) order by iGeneralLedgerAccountId) > 1 
	then RIGHT('00000'+LEFT(sCode, 5),5) + '_'+ convert(nvarchar(10),DENSE_RANK() over (partition by RIGHT('00000'+LEFT(sCode, 5),5) order by iGeneralLedgerAccountId)) 
	else RIGHT('00000'+LEFT(sCode, 5),5)
end AccountCode
into tempGLAccount
from tblGeneralLedgerAccount

GO
--99998 VAT INPUT	5FF0F737-231D-4825-9E32-B9A3DF44701B
--99999 VAT OUTPUT	A791A845-A041-48B9-ADD6-58AFFFCC0D55
INSERT INTO tempGLAccount
       SELECT Id,
              CASE CodeMain
                  WHEN '99998'
                  THEN '5FF0F737-231D-4825-9E32-B9A3DF44701B'
				  WHEN '99999'
                  THEN 'A791A845-A041-48B9-ADD6-58AFFFCC0D55'
              END,
              CodeMain
       FROM [IMPORT_DB].[CDS_SYS].[SYS_Entity] WHERE TypeId = 5;
GO

-- ------------------------------------------
-- Import GL SYS_Entities Accounts
-- ------------------------------------------
print '------------------------------------------'
print 'Import GL SYS_Entities Accounts'
print '------------------------------------------'
GO


SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Entity] ON
	INSERT INTO IMPORT_DB.[CDS_SYS].[SYS_Entity] (Id,TypeId,CodeMain,CodeSub,ShortName,Name,Description,Archived,CreatedBy,CreatedOn)
	SELECT
	AccCodeMap.AccountId Id
	,5 TypeId
	,case 
		when DENSE_RANK() over (partition by RIGHT('00000'+LEFT(sCode, 5),5) order by iGeneralLedgerAccountId) > 1 
		then RIGHT('00000'+LEFT(sCode, 5),5) + '_'+ convert(nvarchar(10),DENSE_RANK() over (partition by RIGHT('00000'+LEFT(sCode, 5),5) order by iGeneralLedgerAccountId)) 
		else RIGHT('00000'+LEFT(sCode, 5),5)
	end CodeMain
	,'00000' CodeSub
	,exLedger.sName ShortName
	,exLedger.sName Name
	,'' Description
	,0 Archived
	,isnull(Creator.Id,1) CreatedBy
	,exLedger.dtCreatedOn CreatedOn
	FROM tblGeneralLedgerAccount exLedger
	inner join tempGLAccount AccCodeMap on exLedger.pkGeneralLedgerAccountGuid=AccCodeMap.AccountGuid 
	LEFT JOIN IMPORT_DB.[CDS_SYS].SYS_Person Creator on exLedger.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Entity] OFF
GO

-- ------------------------------------------
-- Import GL [GLX_Account]
-- ------------------------------------------
print '------------------------------------------'
print 'Import GL [GLX_Account]'
print '------------------------------------------'
GO

insert into IMPORT_DB.[CDS_GLX].[GLX_Account] (EntityId, AccountTypeId,CenterId,AgingAccount,ControlId,MasterControlId,BalanceGroup,CreatedOn,CreatedBy)
select 
inAccountEntity.Id EntityId
, tempAccountType.TypeId AccountTypeId
, null CenterId
, 0 AgingAccount
, null ControlId
, null MasterControlId
--, IIF(LTRIM(exLedger.sGroupBalanceSheet) = '', IIF(LTRIM(exLedger.sGroupIncomeStatement) = '', '', 'I'+exLedger.sGroupIncomeStatement), 'B' + exLedger.sGroupBalanceSheet) BalanceGroup
, CASE WHEN LTRIM(exLedger.sGroupBalanceSheet) = '' THEN CASE WHEN LTRIM(exLedger.sGroupIncomeStatement) = '' THEN '' ELSE 'I'+exLedger.sGroupIncomeStatement END ELSE 'B' + exLedger.sGroupBalanceSheet END BalanceGroup
, exLedger.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
from tblGeneralLedgerAccount exLedger
inner join tempGLAccount AccCodeMap on exLedger.pkGeneralLedgerAccountGuid=AccCodeMap.AccountGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on AccCodeMap.AccountCode = inAccountEntity.CodeMain
inner join tempAccountType on exLedger.fkAccountTypeGuid=tempAccountType.TypeGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].SYS_Person Creator on exLedger.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
GO


-- ------------------------------------------
-- Import SiteAccounts
-- ------------------------------------------
print '------------------------------------------'
print 'Import SiteAccounts'
print '------------------------------------------'
GO

insert into IMPORT_DB.[CDS_GLX].[GLX_SiteAccount]
select 
 inAccountEntity.Id EntityId 
, tempSiteAccountType.TypeId TypeId
, 1 SystemDefaultAccount
, '' ShortDescription
, tblSetting.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblSetting 
inner join tempSiteAccountType on tempSiteAccountType.Name= tblSetting.sName
inner join tempGLAccount AccCodeMap on tblSetting.sValue=AccCodeMap.AccountGuid and sName like 'gl[_]%' and sName<>'GL_PURCHASEDIFFERENCE'
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inAccountEntity on AccCodeMap.AccountCode = inAccountEntity.CodeMain
LEFT JOIN IMPORT_DB.[CDS_SYS].SYS_Person Creator on tblSetting.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

-- ------------------------------------------
-- Import GL Account Histories
-- ------------------------------------------
print 'Import GL Account Histories'
GO


insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
SELECT SYS_Period.Id,SYS_Entity.Id,1,0
FROM [IMPORT_DB].[CDS_SYS].[SYS_Entity] INNER JOIN [IMPORT_DB].[CDS_SYS].[SYS_Period] on 1=1
WHERE SYS_Entity.CodeMain in ('99998','99999')
GO


insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
select 
MEGL.PeriodId PeriodId
,AccCodeMap.AccountId EntityId
,1 AgingId
,case when exAcc.fkaccounttypeguid in ('22EFE845-7423-4211-8B41-3A3F5401B4EF', '8E7435DA-40BB-41DC-AD08-A2073FD8B73A', 'A4456B79-C62E-4049-B804-6B7E8F440F6C', '9B3081E9-04FA-4244-816A-A7F0C97FFA4F', '4E241116-8E68-44CC-890B-3C5EE86F460A') 
	then -isnull(exHist.dBalance,0) 
	else isnull(exHist.dBalance,0) end Amount
from tblMonthEndLedger exHist
inner join tblGeneralLedgerAccount exAcc on exHist.fkGeneralLedgerAccountGuid = exAcc.pkGeneralLedgerAccountGuid
inner join tempMEDates MEGL on exHist.dtDate=MEGL.MEGLDate
inner join tempGLAccount AccCodeMap on exHist.fkGeneralLedgerAccountGuid=AccCodeMap.AccountGuid

GO


insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
select 
MEGL.PeriodId PeriodId
,AccCodeMap.AccountId EntityId
,1 AgingId
,case when exHist.fkaccounttypeguid in ('22EFE845-7423-4211-8B41-3A3F5401B4EF', '8E7435DA-40BB-41DC-AD08-A2073FD8B73A', 'A4456B79-C62E-4049-B804-6B7E8F440F6C', '9B3081E9-04FA-4244-816A-A7F0C97FFA4F', '4E241116-8E68-44CC-890B-3C5EE86F460A') 
	then -isnull(exHist.dBalanceAmount,0) 
	else isnull(exHist.dBalanceAmount,0) end Amount
from tblGeneralLedgerAccount exHist
inner join tempGLAccount AccCodeMap on exHist.pkGeneralLedgerAccountGuid=AccCodeMap.AccountGuid
left join tempMEDates MEGL on MEGL.MEGLDate is null and MEGL.EndDate > (select top 1 StartDate from tempImportStartDate)

GO

--insert into IMPORT_DB.[CDS_GLX].[GLX_History] (PeriodId,EntityId,AgingId,Amount) 
--select 
--MEGL.PeriodId PeriodId
--,AccCodeMap.AccountId EntityId
--,1 AgingId
--,0 Amount
--from tblGeneralLedgerAccount exHist
--inner join tempGLAccount AccCodeMap on exHist.pkGeneralLedgerAccountGuid=AccCodeMap.AccountGuid
--left join tempMEDates MEGL on MEGL.MEGLDate is null 

GO
USE  IMPORT_DB
GO

DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO