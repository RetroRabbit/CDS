

USE EXPORT_DB
GO


/*


1. Create tracking for Documents
2. Link Tracking for linked documents
3. Link GLX headers for documents
4. Link Payment/Journals for document GLX Headers



*/

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
, null JournalId 
, 0
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
select refTrack.id as parentId, tblDocument.pkDocumentGuid, refTrack.TypeCode, null, 0 from tblDocument
inner join tempTrack as refTrack on refTrack.DocGuid = tblDocument.fkReferenceDocumentGuid 
LEFT join tempTrack as track2 on track2.DocGuid = tblDocument.pkDocumentGuid 
where track2.DocGuid is null
and fkReferenceDocumentGuid is NOT null
select @rows = @@ROWCOUNT
end

GO



-- -----------------------------------
-- Link GLX headers for documents
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Link GLX headers for documents'
PRINT '-----------------------------------'
GO



INSERT INTO tempTrack
SELECT 
track.id AS id
, null DocGuid
, null TypeCode
, jnl.Id JournalId 
, CASE WHEN jnl.TrackNumber = 1 THEN 1 ELSE 0 END Archived
from GLX_Header jnl
inner join tblDocument doc on jnl.DocumentId=doc.iDocumentId
inner join tempTrack track on doc.pkDocumentGuid=track.DocGuid

GO



-- -----------------------------------
-- Link Payment/Journals for document GLX Headers
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Link Payment/Journals for document GLX Headers'
PRINT '-----------------------------------'
GO



INSERT INTO tempTrack
SELECT 
track.id AS id
, null DocGuid
, null TypeCode
, jnl.Id JournalId 
, CASE WHEN jnl.TrackNumber = 1 THEN 1 ELSE 0 END Archived
FROM GLX_Header jnl
inner join GLX_Header d on jnl.TrackNumber=d.TrackNumber and jnl.DocumentId is null and d.DocumentId is not null and jnl.TrackNumber<>1
inner join temptrack track on d.Id=track.JournalId


GO



-- -----------------------------------
-- Link Payment/Journals for document GLX Headers
-- ----------------------------------
PRINT '-----------------------------------'
PRINT 'Link Payment/Journals for document GLX Headers'
PRINT '-----------------------------------'
GO


INSERT INTO tempTrack
SELECT
ROW_NUMBER() OVER(ORDER BY jnl.Id) + (select MAX(id) from tempTrack) AS id
, null DocGuid
, null TypeCode
, jnl.Id JournalId 
, CASE WHEN jnl.TrackNumber = 1 THEN 1 ELSE 0 END Archived
FROM GLX_Header jnl
LEFT JOIN tempTrack t on jnl.Id=t.JournalId
WHERE t.Id IS NULL

GO




SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Tracking ON
insert into IMPORT_DB.CDS_SYS.SYS_Tracking (Id,Initiator,Archived) select id,'',CAST(MAX(CAST(Archived AS int)) AS BIT) from tempTrack group by Id
SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Tracking OFF
GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO
