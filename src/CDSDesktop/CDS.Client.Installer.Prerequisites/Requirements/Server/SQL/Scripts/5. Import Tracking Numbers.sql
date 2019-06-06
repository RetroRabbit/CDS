
USE EXPORT_DB
GO
-- -----------------------------
-- Create tracking for Documents
-- -----------------------------
PRINT '-----------------------------'
PRINT 'Create tracking for Documents'
PRINT '-----------------------------'
GO

INSERT INTO tempTrack
SELECT 
ROW_NUMBER() OVER(ORDER BY iDocumentId) AS id
, pkDocumentGuid DocGuid
, tlDocumentType.sCode TypeCode
, null JournalGuid 
, 0 Archived
from tblDocument
inner join tlDocumentType on tblDocument.fkDocumentTypeGuid=tlDocumentType.pkDocumentTypeGuid
where fkReferenceDocumentGuid is null OR fkDocumentTypeGuid='29770704-9D0D-4848-81F9-5CBC7551DD38'

GO

-- -----------------------------------
-- Link Tracking for linked documents
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Link Tracking for linked documents'
PRINT '-----------------------------------'
GO

declare @rows int
set @rows = 1
WHILE(@rows > 0)
BEGIN
insert into tempTrack
select refTrack.id as parentId, tblDocument.pkDocumentGuid, refTrack.TypeCode, null, 0 Archived from tblDocument
inner join tempTrack as refTrack on refTrack.DocGuid = tblDocument.fkReferenceDocumentGuid 
LEFT join tempTrack as track2 on track2.DocGuid = tblDocument.pkDocumentGuid 
where track2.DocGuid is null
and fkReferenceDocumentGuid is NOT null
select @rows = @@ROWCOUNT
end

GO

-- -----------------------------------
-- Insert debtor headers tracking for documents
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Insert debtor headers tracking for documents'
PRINT '-----------------------------------'
GO


insert into tempTrack 
select 
tempTrack.id id
,null DocGuid
, tempTrack.TypeCode TypeCode
, d.pkDebtorGuid JournalGuid 
,0 Archived
from tblDebtor d
inner join tempTrack on d.fkDocumentGuid=tempTrack.DocGuid

GO

-- -----------------------------------
-- Link Debtor Headers linked to other debtor headers
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Link Debtor Headers linked to other debtor headers'
PRINT '-----------------------------------'
GO


IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_TempTrack_JournalGuid')
DROP INDEX [IDX_TempTrack_JournalGuid] ON [dbo].[tempTrack]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_TempTrack_JournalGuid')
CREATE NONCLUSTERED INDEX [IDX_TempTrack_JournalGuid]
ON [dbo].[tempTrack] ([JournalGuid])
INCLUDE ([id],[TypeCode])
GO


insert into tempTrack 
select 
tempTrack.id id
,null DocGuid
, tempTrack.TypeCode TypeCode
, d.pkDebtorGuid JournalGuid 
,0 Archived
from tblDebtor d
inner join tempTrack on d.fkDebtorReferenceGuid=tempTrack.JournalGuid
left join temptrack track2 on track2.JournalGuid=d.pkDebtorGuid
where track2.JournalGuid is null

-- -----------------------------------
-- Insert Debtor headers tracking for non linked entries
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Insert Debtor headers tracking for non linked entries'
PRINT '-----------------------------------'
GO
/*
LOOK INTO

select* from tblDebtor where fkDebtorReferenceGuid='A28B3E88-9A07-4B67-A28E-5FA5FBF0F096'
select* from tblDebtor where fkDebtorReferenceGuid='692BD37E-296F-4E72-99CB-EB1D08179FF4'
select* from tblDebtor where fkDebtorReferenceGuid='0CBFCFFB-4080-462C-910A-B26DADC6B3B3'


select * from tblDocument where iNameNumericPart='223959'

select * from tlDocumentType where pkDocumentTypeGuid='6AE4CCED-0439-45B3-B0ED-2C833928D46C'
*/

insert into tempTrack 
select 
ROW_NUMBER() OVER(ORDER BY iDebtorId) + (select MAX(id) from tempTrack) AS id
,null DocGuid
, t.sName TypeCode
, d.pkDebtorGuid JournalGuid 
,0 Archived
from tblDebtor d
inner join tlJournalEntryType t on d.fkJournalEntryTypeGuid=t.pkJournalEntryTypeGuid
left join tempTrack on d.pkDebtorGuid=tempTrack.JournalGuid
where tempTrack.JournalGuid is null

GO

-- -----------------------------------
-- Insert creditor headers tracking for documents
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Insert creditor headers tracking for documents'
PRINT '-----------------------------------'
GO

IF EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_Tracking_DocumentGuid')
	DROP INDEX IDX_Tracking_DocumentGuid ON [dbo].[tempTrack]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempTrack]') AND name = N'IDX_Tracking_DocumentGuid')
CREATE NONCLUSTERED INDEX [IDX_Tracking_DocumentGuid]
ON [dbo].[tempTrack] ([DocGuid])
INCLUDE ([id],[TypeCode])
GO

insert into tempTrack 
select 
tempTrack.id id
,null DocGuid
, tempTrack.TypeCode TypeCode
, c.pkCreditorGuid JournalGuid 
,0 Archived
from tblCreditor c
inner join tempTrack on c.fkDocumentGuid=tempTrack.DocGuid

GO

-- -----------------------------------
-- Insert creditor headers tracking for non linked entries
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Insert creditor headers tracking for non linked entries'
PRINT '-----------------------------------'
GO

insert into tempTrack 
select 
ROW_NUMBER() OVER(ORDER BY iCreditorId) + (select MAX(id) from tempTrack) AS id
,null DocGuid
, t.sName TypeCode
, c.pkCreditorGuid JournalGuid 
,0 Archived
from tblCreditor c
inner join tlJournalEntryType t on c.fkJournalEntryTypeGuid=t.pkJournalEntryTypeGuid
left join tempTrack on c.pkCreditorGuid=tempTrack.JournalGuid
where tempTrack.JournalGuid is null

GO

-- -----------------------------------
-- Insert Cash headers tracking for non linked entries
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Insert Cash headers tracking for non linked entries'
PRINT '-----------------------------------'
GO

insert into tempTrack 
select 
ROW_NUMBER() OVER(ORDER BY iCashId) + (select MAX(id) from tempTrack) AS id
,null DocGuid
, 'Journal' TypeCode
, ca.pkCashGuid JournalGuid 
,0 Archived
FROM tblCash ca 
WHERE
sdescription not like 'Debtor Payment Received for Account %'
and sdescription not like 'Debtor Credit Applied for Account %'
and sdescription not like 'Debtor Payment Reversal for Account %'
and sdescription not like 'Creditor Bill Paid for Account %'

GO


SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Tracking] ON
insert into IMPORT_DB.[CDS_SYS].[SYS_Tracking] (Id,Initiator,Archived) select distinct id,TypeCode,Archived from tempTrack
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_Tracking] OFF
GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO