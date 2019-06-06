
USE EXPORT_DB
GO


SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Entity ON
INSERT INTO IMPORT_DB.CDS_SYS.SYS_Entity (Id,TypeId,CodeMain,CodeSub,ShortName,Name,Description,Archived,CreatedBy,CreatedOn)
SELECT 
ROW_NUMBER() OVER (ORDER BY exAcc.Id) + (select MAX(id) from IMPORT_DB.CDS_SYS.SYS_Entity) Id
, 5 TypeId
, exAcc.CodeMain CodeMain
, exAcc.CodeSub CodeSub
, exAcc.Name ShortName
, exAcc.Name Name
, isnull(exAcc.Description,'') Description
, exAcc.Archived Archived
,isnull(Creator.Id,1) CreatedBy
, exAcc.CreatedOn CreatedOn
FROM GLX_Account exAcc 
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exAcc.CreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Entity OFF

GO


SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Account ON
insert into IMPORT_DB.CDS_GLX.GLX_Account (Id,EntityId, AccountTypeId,CenterId,AgingAccount,ControlId,MasterControlId,BalanceGroup,CreatedOn,CreatedBy)
SELECT 
ROW_NUMBER() OVER (ORDER BY exAcc.Id) Id
, inEnt.Id EntityId
, isnull(inType.Id,4) AccountTypeId
, null CenterId
, exAcc.AgingAccount AgingAccount
, inControlEnt.Id ControlId
, inControlEnt.Id MasterControlId
, exAcc.BalanceGroup
, exAcc.CreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM GLX_Account exAcc 
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inEnt on exAcc.CodeMain=inEnt.CodeMain and exAcc.CodeSub=inEnt.CodeSub
LEFT JOIN GLX_Account ControlAcc on exAcc.ControlId=ControlAcc.Id
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Entity inControlEnt on ControlAcc.CodeMain=inControlEnt.CodeMain and ControlAcc.CodeSub=inControlEnt.CodeSub
left JOIN STD_Type exType on exAcc.TypeId=exType.id
left JOIN IMPORT_DB.CDS_GLX.GLX_Type inType on exType.Code=inType.Name
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exAcc.CreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Account OFF

GO


insert into IMPORT_DB.CDS_GLX.GLX_SiteAccount
select 
 inAccountEntity.Id EntityId 
, tempSiteAccountType.TypeId TypeId
, 1 SystemDefaultAccount
, '' ShortDescription
, tblSetting.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblSetting 
inner join tempSiteAccountType on tempSiteAccountType.Name= tblSetting.sName
inner join GLX_Account on tblSetting.sValue=GLX_Account.Id and sName like 'glx[_]%' and sName<>'GLX_PURCHASEDIFFERENCE'
inner join IMPORT_DB.CDS_SYS.SYS_Entity inAccountEntity on GLX_Account.CodeMain = inAccountEntity.CodeMain and GLX_Account.CodeSub=inAccountEntity.CodeSub
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on tblSetting.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO



SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_History ON
insert into IMPORT_DB.CDS_GLX.GLX_History (Id,PeriodId,EntityId,AgingId,Amount) 
SELECT 
ROW_NUMBER() OVER (ORDER BY b.Id) Id
, inP.Id PeriodId
, inA.Id EntityId
, b.AgingId AgingId
, b.Amount Amount
FROM GLX_Balance b
INNER JOIN GLX_Period p on b.PeriodId=p.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period inP on p.StartDate=inP.StartDate
INNER JOIN GLX_Account a on b.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inA on a.CodeMain=inA.CodeMain and a.CodeSub=inA.CodeSub and inA.TypeId=5

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_History OFF

GO
