
USE EXPORT_DB
GO
 
DECLARE @LogFile nvarchar(100)
select top 1 @LogFile = sys.master_files.Name from sys.databases inner join  sys.master_files on sys.databases.database_id = sys.master_files.database_id where type_desc = 'LOG' and sys.databases.name = 'EXPORT_DB'
DBCC SHRINKFILE (@LogFile, 1)

-- -----------------------------------
-- Create Import indexes
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Create Import indexes'
PRINT '-----------------------------------'
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_tempTrack_DocGuid')
DROP INDEX [IDX_tempTrack_DocGuid] ON [dbo].[tempTrack]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_tempTrack_DocGuid')
CREATE NONCLUSTERED INDEX [IDX_tempTrack_DocGuid]
ON [dbo].[tempTrack] ([DocGuid])
INCLUDE ([id],[TypeCode]) 
GO


IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempDocNumber]') AND name = N'IDX_tempTrack_DocGuid')
DROP INDEX [IDX_tempTrack_DocGuid] ON [dbo].[tempDocNumber]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempDocNumber]') AND name = N'IDX_tempTrack_DocGuid')
CREATE NONCLUSTERED INDEX [IDX_tempTrack_DocGuid]
ON [dbo].[tempDocNumber] ([DocGuid])
INCLUDE ([DocId])
GO


-- -----------------------------
-- Import Headers (DEBTORS)
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'IMPORT HEADERS TABLE (DEBTORS)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Header 
SELECT
ROW_NUMBER() OVER (ORDER BY iDebtorId) Id
,period.Id PeriodId
,3 StatusId
,tempTrack.id TrackId
,case when JournalTypeMap.TypeId = 2 AND tempDocNumber.DocId is not null THEN 10 ELSE JournalTypeMap.TypeId END JournalTypeId
,JournalTypeMap.TypeGuid JournalTypeGuid
,SUBSTRING(d.sReference,1,50) Reference
,SUBSTRING(isnull(JournalTypeMap.HeaderDesc,d.sDescription + ' to ACC#: ') + tempCompany.CompanyCode + '.',1,100) Description
,d.dtDate Date
,d.dtDate PostedDate
,d.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
,tempDocNumber.DocId ReferenceId
,iDebtorId DebtorId
,null CreditorId
,null CashId
FROM tblDebtor d
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Period] period on d.dtDate between period.StartDate and period.EndDate
INNER JOIN tblAccount a on d.fkAccountGuid=a.pkAccountGuid
INNER JOIN tempCompany on a.fkCompanyGuid=tempCompany.CompanyGuid
INNER JOIN tempJournalType JournalTypeMap on d.fkJournalEntryTypeGuid=JournalTypeMap.TypeGuid and (Creditor=0 or Creditor is null)
INNER JOIN tempTrack on d.pkDebtorGuid=tempTrack.JournalGuid
LEFT JOIN tempDocNumber on d.fkDocumentGuid = tempDocNumber.DocGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on d.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
WHERE (
(d.fkJournalEntryTypeGuid in ('C4D52D8B-69CC-47B1-A157-07FB3D20D90F','C3A4B0AF-20FB-4AAF-826A-6D52D91C887E','1F6576C8-EF59-4CF2-A5F6-46B0F6923828','0D152893-0F1E-418F-ACBD-04B87F149635','F7EB3848-8036-4620-B8E3-14D4D15FBC5B') and d.fkDocumentGuid is not null)
or (d.fkDocumentGuid is null AND d.fkJournalEntryTypeGuid in (
'0D152893-0F1E-418F-ACBD-04B87F149635',
'F7EB3848-8036-4620-B8E3-14D4D15FBC5B',
'61908A3F-7541-493B-A54C-27C97585B733',
'2365E354-E793-4948-9359-2F0176F2AA35',
'F35D760B-004A-4663-85BF-341464DD2903',
'1E7006E7-1E9C-444B-8F83-3551BD5D96A1',
'7CD8DE04-272C-40B1-ADF6-7CA52605E253',
'0D647609-AD18-4563-B509-8388E3315BF3',
'093DA968-0B73-472F-9AEE-C6B2480888E0',
'31B69D54-3F1F-4461-9563-DA5ADEDF3AE6',
'E97E7764-F680-4289-908F-DFD389C62EC2',
'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA')))
and d.dtCreatedOn>'2009-10-30 17:29:02.410' 
GO

-- -----------------------------
-- Import Headers (CREDITORS)
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'IMPORT HEADERS TABLE (CREDITORS)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Header 
SELECT
ROW_NUMBER() OVER (ORDER BY iCreditorId) + (select MAX(id) from tempGLX_Header) Id
,period.Id PeriodId
,3 StatusId
,tempTrack.id TrackId
,JournalTypeMap.TypeId JournalTypeId
,JournalTypeMap.TypeGuid JournalTypeGuid
,SUBSTRING(c.sReference,1,50) Reference
,SUBSTRING(isnull(JournalTypeMap.HeaderDesc,c.sDescription + ' to ACC#: ') + tempCompany.CompanyCode + '.',1,100) Description
,c.dtDate Date
,c.dtDate PostedDate
,c.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
,tempDocNumber.DocId ReferenceId
,null DebtorId
,iCreditorId CreditorId
,null CashId
FROM tblCreditor c
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Period] period on c.dtDate between period.StartDate and period.EndDate
INNER JOIN tblAccount a on c.fkAccountGuid=a.pkAccountGuid
INNER JOIN EXPORT_DB.dbo.tempCompany on a.fkCompanyGuid=tempCompany.CompanyGuid
INNER JOIN tempJournalType JournalTypeMap on c.fkJournalEntryTypeGuid=JournalTypeMap.TypeGuid and (Creditor=1 or Creditor is null)
INNER JOIN tempTrack on c.pkCreditorGuid=tempTrack.JournalGuid
LEFT JOIN tempDocNumber on c.fkDocumentGuid = tempDocNumber.DocGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on c.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
WHERE 
((c.fkJournalEntryTypeGuid in ('C4D52D8B-69CC-47B1-A157-07FB3D20D90F','C3A4B0AF-20FB-4AAF-826A-6D52D91C887E','1F6576C8-EF59-4CF2-A5F6-46B0F6923828','7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA') and c.fkDocumentGuid is not null)
or (c.fkDocumentGuid is null AND c.fkJournalEntryTypeGuid in (
'0D152893-0F1E-418F-ACBD-04B87F149635',
'F7EB3848-8036-4620-B8E3-14D4D15FBC5B',
'61908A3F-7541-493B-A54C-27C97585B733',
'2365E354-E793-4948-9359-2F0176F2AA35',
'F35D760B-004A-4663-85BF-341464DD2903',
'1E7006E7-1E9C-444B-8F83-3551BD5D96A1',
'7CD8DE04-272C-40B1-ADF6-7CA52605E253',
'0D647609-AD18-4563-B509-8388E3315BF3',
'093DA968-0B73-472F-9AEE-C6B2480888E0',
'31B69D54-3F1F-4461-9563-DA5ADEDF3AE6',
'E97E7764-F680-4289-908F-DFD389C62EC2',
'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA')))
and c.dtCreatedOn>'2009-10-30 17:29:02.410'
GO


-- -----------------------------
-- Import Headers (CASH)
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'IMPORT HEADERS TABLE (CASH)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Header 
SELECT
ROW_NUMBER() OVER (ORDER BY iCashId) + (select MAX(id) from tempGLX_Header) Id
,period.Id PeriodId
,3 StatusId
,tempTrack.id TrackId
,2 JournalTypeId
,null JournalTypeGuid
,SUBSTRING(ca.sReference,1,50) Reference
,SUBSTRING(ca.sDescription,1,100) Description
,ca.dtDate Date
,ca.dtDate PostedDate
,ca.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
,null ReferenceId
,null DebtorId
,null CreditorId
,iCashId CashId
FROM tblCash ca
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Period] period on ca.dtDate between period.StartDate and period.EndDate
INNER JOIN tempTrack on ca.pkCashGuid=tempTrack.JournalGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on ca.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

-- -----------------------------
-- Import GLX Lines Documents 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Import GLX Lines Documents'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Line 
SELECT
ROW_NUMBER() OVER(ORDER BY GL.iGeneralLedgerId) + isnull((select MAX(Id) from tempGLX_Line) ,0) Id
,inHeader.Id HeaderId
,CASE WHEN debtor.Id is null THEN inAccount.AccountId ELSE debtor.Id END EntityId
,1 AgingId
,dDebitAmount-dCreditAmount Amount
,d.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblDebtor d 
inner join tempGLX_Header inHeader on inHeader.DebtorId=d.iDebtorId 
inner join tempGLXLineMapping map on d.fkJournalEntryTypeGuid=map.JournalTypeGuid and inHeader.ReferenceId is not null and (Creditor=0 or Creditor is null)
inner join tblGeneralLedger GL on d.fkDocumentGuid=GL.fkDocumentGuid and (map.AccountGuid=gl.fkGeneralLedgerAccount1Guid OR (gl.fkGeneralLedgerAccount1Guid = (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') and map.AccountGuid in  ('A791A845-A041-48B9-ADD6-58AFFFCC0D55','5FF0F737-231D-4825-9E32-B9A3DF44701B'))) and dDebitAmount-dCreditAmount<>0
inner join tempGLAccount inAccount on inAccount.AccountGuid = CASE GL.fkGeneralLedgerAccount1Guid WHEN (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') THEN map.AccountGuid ELSE GL.fkGeneralLedgerAccount1Guid end
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=9 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=d.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] debtor ON debtor.CodeMain=ControlEntity.CodeMain and debtor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on d.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

-- Invoices
INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY GL.iGeneralLedgerId)  + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN creditor.Id is null THEN inAccount.AccountId ELSE creditor.Id END EntityId
,1 AgingId
,dDebitAmount-dCreditAmount Amount
,c.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblCreditor c 
inner join tempGLX_Header inHeader on inHeader.CreditorId=c.iCreditorId
inner join tempGLXLineMapping map on c.fkJournalEntryTypeGuid=map.JournalTypeGuid and inHeader.ReferenceId is not null and Creditor=1
inner join tblGeneralLedger GL on c.fkDocumentGuid=GL.fkDocumentGuid and (map.AccountGuid=gl.fkGeneralLedgerAccount1Guid OR (gl.fkGeneralLedgerAccount1Guid = (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') and map.AccountGuid in  ('A791A845-A041-48B9-ADD6-58AFFFCC0D55','5FF0F737-231D-4825-9E32-B9A3DF44701B'))) and dDebitAmount-dCreditAmount<>0
inner join tempGLAccount inAccount on inAccount.AccountGuid = CASE GL.fkGeneralLedgerAccount1Guid WHEN (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') THEN map.AccountGuid ELSE GL.fkGeneralLedgerAccount1Guid end
INNER JOIN tblCompany exComp on c.fkCompanyGuid=exComp.pkCompanyGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=8 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=c.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] creditor ON creditor.CodeMain=ControlEntity.CodeMain and creditor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on c.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where C.fkJournalEntryTypeGuid in ('C4D52D8B-69CC-47B1-A157-07FB3D20D90F','1F6576C8-EF59-4CF2-A5F6-46B0F6923828')

GO

-- Bills
INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY GL.iGeneralLedgerId)  + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN creditor.Id is null THEN isnull(inAccount.AccountId,inAccount2.AccountId) ELSE creditor.Id END EntityId
,1 AgingId
,isnull(GL.dDebitAmount-GL.dCreditAmount,GL2.dDebitAmount-GL2.dCreditAmount) Amount
,c.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblCreditor c 
inner join tempGLX_Header inHeader on inHeader.CreditorId=c.iCreditorId
inner join tempGLXLineMapping map on c.fkJournalEntryTypeGuid=map.JournalTypeGuid and inHeader.ReferenceId is not null 
left join tblGeneralLedger GL on c.fkDocumentGuid=GL.fkDocumentGuid and (map.AccountGuid=gl.fkGeneralLedgerAccount1Guid OR (gl.fkGeneralLedgerAccount1Guid = (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') and map.AccountGuid in  ('A791A845-A041-48B9-ADD6-58AFFFCC0D55','5FF0F737-231D-4825-9E32-B9A3DF44701B')))
INNER JOIN tblCompany exComp on c.fkCompanyGuid=exComp.pkCompanyGuid
left join tempGLAccount inAccount on inAccount.AccountGuid = CASE GL.fkGeneralLedgerAccount1Guid WHEN (SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT') THEN map.AccountGuid ELSE GL.fkGeneralLedgerAccount1Guid end
left join tblDocument doc on c.fkDocumentGuid=doc.pkDocumentGuid
left join tempGLAccount inAccount2 on doc.fkLedgerAccountGuid=inAccount2.AccountGuid
left join tblGeneralLedger GL2 on c.fkDocumentGuid=GL2.fkDocumentGuid and inAccount2.AccountGuid=GL2.fkGeneralLedgerAccount1Guid and GL2.dDebitAmount-GL2.dCreditAmount<>0
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=8 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=c.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] creditor ON creditor.CodeMain=ControlEntity.CodeMain and creditor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on c.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where c.fkJournalEntryTypeGuid='7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA' and c.dtCreatedOn > '2015-02-27 17:04:54.917'

GO

-- -----------------------------
-- Import GLX Lines Journals 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Import GLX Lines Journals'
PRINT '-----------------------------------'
GO
 
INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY d.iDebtorId,inAccount.AccountId) + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN debtor.Id is null THEN isnull(inAccount.AccountId,inAccount2.AccountId) ELSE debtor.Id END EntityId
,CASE WHEN d.fkDebtorReferenceGuid='E39312C7-DFB6-4E41-B6A1-582704E528C7' THEN 2 WHEN d.fkDebtorReferenceGuid='7835436A-61B4-4490-A765-6E35B1ECDC01' THEN 3 WHEN d.fkDebtorReferenceGuid='C68A132B-683D-41EE-8AB8-DAC043609343' THEN 4 WHEN d.fkDebtorReferenceGuid='60B69BD9-C4BC-45E0-A5A3-F58E4F46626E' THEN 5 ELSE 1 END AgingId
,CASE WHEN map.AmountType=1 THEN d.dAmountBeforeTax WHEN map.AmountType=2 THEN d.dAmountTax WHEN map.AmountType=3 THEN d.dAmount END * map.AmountMultiplier Amount
,d.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblDebtor d 
inner join tempGLX_Header inHeader on inHeader.DebtorId=d.iDebtorId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on (inHeader.JournalTypeId=map.JournalTypeId and map.Creditor=-1)
LEFT JOIN tblGeneralLedger GL on d.sreference=GL.sreference and d.sdescription=GL.sdescription and GL.fkgeneralledgeraccount1guid=(SELECT cast(svalue as uniqueidentifier) from tblsetting WHERE sName='GL_DEBTORS') and d.damountbeforetax=(GL.ddebitamount-GL.dcreditamount) and d.dtdate=GL.dtdate and  abs(datediff(second, GL.dtcreatedon, d.dtcreatedon))<=50
LEFT JOIN tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
LEFT join tempGLAccount inAccount2 on GL.fkgeneralledgeraccount2guid=inAccount2.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=9 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=d.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] debtor ON debtor.CodeMain=ControlEntity.CodeMain and debtor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on d.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where d.iDebtorId not in (
SELECT distinct
d.iDebtorId
FROM tblDebtor d 
inner join tempGLX_Header inHeader on inHeader.DebtorId=d.iDebtorId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on (inHeader.JournalTypeId=map.JournalTypeId and map.Creditor=-1)
LEFT JOIN tblGeneralLedger GL on d.sreference=GL.sreference and d.sdescription=GL.sdescription and GL.fkgeneralledgeraccount1guid=(SELECT cast(svalue as uniqueidentifier) from tblsetting WHERE sName='GL_DEBTORS') and d.damountbeforetax=(GL.ddebitamount-GL.dcreditamount) and d.dtdate=GL.dtdate and  abs(datediff(second, GL.dtcreatedon, d.dtcreatedon))<=90
LEFT JOIN tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
LEFT join tempGLAccount inAccount2 on GL.fkgeneralledgeraccount2guid=inAccount2.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=9 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=d.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] debtor ON debtor.CodeMain=ControlEntity.CodeMain and debtor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on d.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where CASE WHEN debtor.Id is null THEN isnull(inAccount.AccountId,inAccount2.AccountId) ELSE debtor.Id END is null

)
GO

PRINT '-----------------------------------'
PRINT 'Import GLX Lines Journals (DEBTORS)'
PRINT '-----------------------------------'
GO

--All other non documents
INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY d.iDebtorId,inAccount.AccountId) + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN debtor.Id is null THEN inAccount.AccountId ELSE debtor.Id END EntityId
,CASE WHEN d.fkDebtorReferenceGuid='E39312C7-DFB6-4E41-B6A1-582704E528C7' THEN 2 WHEN d.fkDebtorReferenceGuid='7835436A-61B4-4490-A765-6E35B1ECDC01' THEN 3 WHEN d.fkDebtorReferenceGuid='C68A132B-683D-41EE-8AB8-DAC043609343' THEN 4 WHEN d.fkDebtorReferenceGuid='60B69BD9-C4BC-45E0-A5A3-F58E4F46626E' THEN 5 ELSE 1 END AgingId
,CASE WHEN map.AmountType=1 THEN d.dAmountBeforeTax WHEN map.AmountType=2 THEN d.dAmountTax WHEN map.AmountType=3 THEN d.dAmount END * map.AmountMultiplier Amount
,d.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblDebtor d 
inner join tempGLX_Header inHeader on inHeader.DebtorId=d.iDebtorId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on (inHeader.JournalTypeGuid=map.JournalTypeGuid and (map.Creditor=0 or map.Creditor is null) and map.JournalTypeId<>10) 
inner JOIN tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=9 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=d.fkAccountGuid   
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] debtor ON debtor.CodeMain=ControlEntity.CodeMain and debtor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on d.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

PRINT '-----------------------------------'
PRINT 'Import GLX Lines Journals (CREDITORS)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY c.iCreditorId,inAccount.AccountId) + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN creditor.Id is null THEN isnull(inAccount.AccountId,inAccount2.AccountId) ELSE creditor.Id END EntityId
,1 AgingId
,CASE WHEN map.AmountType=1 THEN c.dAmountBeforeTax WHEN map.AmountType=2 THEN c.dAmountTax WHEN map.AmountType=3 THEN c.dAmount END * map.AmountMultiplier Amount
,c.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblCreditor c 
inner join tempGLX_Header inHeader on inHeader.CreditorId=c.iCreditorId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on inHeader.JournalTypeId=map.JournalTypeId and (map.Creditor is null or map.Creditor=1)
LEFT JOIN tblGeneralLedger GL on c.sreference=GL.sreference and c.sdescription=GL.sdescription and GL.fkgeneralledgeraccount1guid=(SELECT cast(svalue as uniqueidentifier) from tblsetting WHERE sName='GL_CREDITORS') and c.damountbeforetax=(GL.dcreditamount-GL.ddebitamount) and c.dtdate=GL.dtdate and  abs(datediff(second, GL.dtcreatedon, c.dtcreatedon))<=50
LEFT JOIN tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
LEFT join tempGLAccount inAccount2 on GL.fkgeneralledgeraccount2guid=inAccount2.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=8 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=c.fkAccountGuid  
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] creditor ON creditor.CodeMain=ControlEntity.CodeMain and creditor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on c.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where c.iCreditorId not in (
SELECT distinct
c.iCreditorId
FROM tblCreditor c 
inner join tempGLX_Header inHeader on inHeader.CreditorId=c.iCreditorId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on inHeader.JournalTypeId=map.JournalTypeId and (map.Creditor is null or map.Creditor=1)
LEFT JOIN tblGeneralLedger GL on c.sreference=GL.sreference and c.sdescription=GL.sdescription and GL.fkgeneralledgeraccount1guid=(SELECT cast(svalue as uniqueidentifier) from tblsetting WHERE sName='GL_CREDITORS') and c.damountbeforetax=(GL.dcreditamount-GL.ddebitamount) and c.dtdate=GL.dtdate and  abs(datediff(second, GL.dtcreatedon, c.dtcreatedon))<=50
LEFT JOIN tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
LEFT join tempGLAccount inAccount2 on GL.fkgeneralledgeraccount2guid=inAccount2.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] siteA ON siteA.TypeId=8 and siteA.SystemDefaultAccount=1
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] ControlEntity on siteA.EntityId=ControlEntity.Id and ControlEntity.Id=inAccount.AccountId
LEFT JOIN tempCompany CompMap on CompMap.AccountGuid=c.fkAccountGuid  
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] creditor ON creditor.CodeMain=ControlEntity.CodeMain and creditor.CodeSub=CompMap.CompanyCode
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on c.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where CASE WHEN creditor.Id is null THEN isnull(inAccount.AccountId,inAccount2.AccountId) ELSE creditor.Id END is null
)
GO

PRINT '-----------------------------------'
PRINT 'Import GLX Lines Journals (CASH)'
PRINT '-----------------------------------'
GO

INSERT INTO tempGLX_Line
SELECT
ROW_NUMBER() OVER(ORDER BY ca.iCashId,inAccount.AccountId,cash.AccountId,cashContra.AccountId) + isnull((select MAX(Id) from tempGLX_Line) ,0)  Id
,inHeader.Id HeaderId
,CASE WHEN inAccount.AccountId is null AND map.AmountType=3 THEN cash.AccountId WHEN inAccount.AccountId is null AND map.AmountType=1 THEN cashContra.AccountId ELSE inAccount.AccountId END EntityId
,1 AgingId
,CASE WHEN map.AmountType=1 THEN ca.dAmountBeforeTax WHEN map.AmountType=2 THEN ca.dAmountTax WHEN map.AmountType=3 THEN ca.dAmountBeforeTax+ca.dAmountTax END * map.AmountMultiplier Amount
,ca.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblCash ca 
inner join tempGLX_Header inHeader on inHeader.CashId=ca.iCashId and inHeader.ReferenceId is null
inner join tempGLXLineMapping map on map.Creditor=2
left join tempGLAccount inAccount on map.AccountGuid=inAccount.AccountGuid
left join tempGLAccount cash on ca.fkGeneralLedgerAccountGuid=cash.AccountGuid
left join tempGLAccount cashContra on ca.fkGeneralLedgerAccount2Guid=cashContra.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on ca.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
WHERE ca.dtCreatedOn > '2015-02-27 17:04:54.917'
GO

-- -----------------------------
-- Import GLX Headers (GL) 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Import GLX Headers (GL)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLJournalMapping
SELECT 
iGeneralLedgerId
,DENSE_RANK() OVER(ORDER BY sReference,sDescription, dtDate ,sCreatedBy) + (select MAX(id) from tempGLX_Header) HeaderId
,SUBSTRING(L.sReference	,1,50) sReference
,SUBSTRING(L.sDescription,1,100) sDescription
,L.dtDate 
,L.sCreatedBy
,L.dtCreatedOn
from 
(
Select cred.* 
from
(
SELECT deb.* 
FROM (
select dDebitAmount,dCreditAmount,iGeneralLedgerId, tblGL.sReference,tblGL.sDescription, fkGeneralLedgerAccount1Guid, tblGL.dtCreatedOn, tblGL.dtDate , tblGL.sCreatedBy, tblGL.dtModifiedOn, tblGL.sModifiedBy
from (
select dDebitAmount,dCreditAmount,iGeneralLedgerId,sReference ,sDescription, fkGeneralLedgerAccount1Guid, dtDate, dtCreatedOn, sCreatedBy, dtModifiedOn, sModifiedBy 
from  
(select dDebitAmount,dCreditAmount,iGeneralLedgerId,sReference,sDescription, fkGeneralLedgerAccount1Guid, dtDate, dtCreatedOn, sCreatedBy, dtModifiedOn, sModifiedBy 
from tblgeneralledger 
where fkDocumentGuid is null
) nonDocGL
WHERE nonDocGL.sdescription<>'Provisional Year End' and
nonDocGL.sReference not like 'Doc #:%' and 
nonDocGL.sdescription not like 'Debtor Payment Received for Account%' and 
nonDocGL.sdescription not like 'Debtor Payment Reversal for Account%' and
nonDocGL.sdescription not like 'Debtor Credit Applied for Account%' and
nonDocGL.sdescription not like 'Debtor Settlement Discount for Account%' and
nonDocGL.sdescription not like 'Creditor Settlement Discount for Account%' and
nonDocGL.sdescription not like 'Creditor Bill Paid for Account%' and
nonDocGL.sdescription not like 'Debtor S/Discount Reversal for Account%' and
nonDocGL.sDescription not like 'VAT on %' 
) tblGL
full outer join tblDebtor d on tblGL.sReference=d.sReference and ABS(DATEDIFF(SECOND,tblGL.dtDate,d.dtDate)) < 80 WHERE d.iDebtorId is null) deb 
full outer join tblCreditor c on deb.sReference=c.sReference and ABS(DATEDIFF(SECOND,deb.dtDate,c.dtDate)) < 80  WHERE c.iCreditorId is null) cred 
full outer join tblCash ca on cred.sReference=ca.sReference and  ABS(DATEDIFF(SECOND,cred.dtDate,ca.dtDate)) < 80 and ca.sReference is not null where ca.iCashId is null 
) L 
left join tempGLAccount on fkGeneralLedgerAccount1Guid=tempGLAccount.AccountGuid
FULL OUTER JOIN (
SELECT h.id, h.reference, h.description, amount, h.date, h.createdon, a.AccountGuid AccountGuid 
FROM 
(
select id, Reference,Description, Date, CreatedOn from tempGLX_Header where ReferenceId is null and Description is not null) h 
INNER JOIN tempGLX_Line l ON l.HeaderId=h.Id
left JOIN tempGLAccount a on a.AccountId=l.EntityId 
) X
on L.fkgeneralledgeraccount1guid=X.AccountGuid and L.sreference=X.reference and X.description = L.sdescription and l.dtDate=X.Date 
WHERE X.id is null
GO

DECLARE @TrackId bigint
select @TrackId=MAX(id) from tempTrack

INSERT INTO tempGLX_Header
SELECT
exGLHead.HeaderId Id
,period.Id PeriodId
,3 StatusId
,DENSE_RANK() OVER(ORDER BY Reference,exGLHead.Description, Date ,exGLHead.CreatedBy) + @TrackId TrackId
,2 JournalTypeId
,null JournalTypeGuid
,SUBSTRING(exGLHead.Reference,1,50) Reference
,SUBSTRING(exGLHead.Description,1,100) Description
,exGLHead.Date Date
,exGLHead.Date PostedDate
,exGLHead.CreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
,null ReferenceId
,null DebtorId
,null CreditorId
,null CashId
FROM 
(SELECT HeaderId,Reference,Description,Date,CreatedBy,MAX(CreatedOn) CreatedOn FROM
tempGLJournalMapping exGL
GROUP BY HeaderId,Reference,Description,Date,CreatedBy
) as exGLHead
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Period] period on exGLHead.Date between period.StartDate and period.EndDate
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exGLHead.CreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
 

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Tracking] ON
insert into IMPORT_DB.[CDS_SYS].[SYS_Tracking] (Id,Initiator,Archived) 
select distinct TrackId,'Journal',0
from tempGLX_Header where TrackId>@TrackId
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Tracking] OFF
GO

-- -----------------------------
-- Import GLX Lines (GL) 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Import GLX Lines (GL)'
PRINT '-----------------------------------'
GO


INSERT INTO tempGLX_Line
SELECT 
ROW_NUMBER() OVER(ORDER BY exGLHead.GLId) + (SELECT MAX(id) FROM tempGLX_Line) Id
,exGLHead.HeaderId HeaderId
,tempGLAccount.AccountId EntityId
,1 AgingId
,dDebitAmount-dCreditAmount Amount
,exGL.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tempGLJournalMapping exGLHead
INNER JOIN tblGeneralLedger exGL on exGLHead.GLId=exgl.iGeneralLedgerId
LEFT JOIN tempGLAccount on fkGeneralLedgerAccount1Guid=tempGLAccount.AccountGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exGLHead.CreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO


DECLARE @LogFile nvarchar(100)
select top 1 @LogFile = sys.master_files.Name from sys.databases inner join  sys.master_files on sys.databases.database_id = sys.master_files.database_id where type_desc = 'LOG' and sys.databases.name = 'EXPORT_DB'
DBCC SHRINKFILE (@LogFile, 1)
GO
-- -----------------------------
-- Push to Headers database 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Push to Headers database'
PRINT '-----------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Header] ON
INSERT INTO IMPORT_DB.[CDS_GLX].[GLX_Header] (Id,PeriodId,StatusId,TrackId,JournalTypeId,Reference,Description,Date,PostedDate,CreatedOn,CreatedBy,ReferenceId)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
  'SELECT
tempGLX_Header.Id Id
,tempGLX_Header.PeriodId PeriodId
,tempGLX_Header.StatusId StatusId
,tempGLX_Header.TrackId TrackId
,tempGLX_Header.JournalTypeId JournalTypeId
,tempGLX_Header.Reference Reference
,isnull(tempGLX_Header.Description,'''') Description
,tempGLX_Header.Date Date
,tempGLX_Header.PostedDate PostedDate
,tempGLX_Header.CreatedOn CreatedOn
,tempGLX_Header.CreatedBy CreatedBy
,tempGLX_Header.ReferenceId ReferenceId
FROM tempGLX_Header') as e;

SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Header] OFF
GO


-- -----------------------------
-- Push to Lines database
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Push to Lines database'
PRINT '-----------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Line] ON
insert into IMPORT_DB.[CDS_GLX].[GLX_Line] (Id,HeaderId,EntityId,ReconId,TaxId,CenterId,AgingId,Amount,CreatedOn,CreatedBy)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
     'SELECT
tempGLX_Line.Id Id
,tempGLX_Line.HeaderId HeaderId
,tempGLX_Line.EntityId EntityId
,null ReconId
,null TaxId
,null CenterId
,tempGLX_Line.AgingId AgingId
,isnull(tempGLX_Line.Amount,0) Amount
,tempGLX_Line.CreatedOn CreatedOn
,tempGLX_Line.CreatedBy CreatedBy
FROM tempGLX_Line') as e;

SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Line] OFF
GO

USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO