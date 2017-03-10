
USE EXPORT_DB
GO
 
DECLARE @LogFile nvarchar(100)
select top 1 @LogFile = sys.master_files.Name from sys.databases inner join  sys.master_files on sys.databases.database_id = sys.master_files.database_id where type_desc = 'LOG' and sys.databases.name = 'EXPORT_DB'
DBCC SHRINKFILE (@LogFile, 1)


SELECT
ROW_NUMBER() OVER (ORDER BY exH.Id) Id
,exH.id ExHeaderId
,inP.Id PeriodId
,inS.Id StatusId
,inTrack.Id TrackId
,isnull(TypeMap.TypeId,2) JournalTypeId
,exH.Reference Reference
,SUBSTRING(isnull(exH.Description,''''),1,99) Description
,exH.Date Date
,exH.PostedDate PostedDate
,exH.CreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
,tempDoc.DocId ReferenceId
INTO tempGLX_headerMap
FROM GLX_Header exH
INNER JOIN tempTrack inTrack on exH.Id=inTrack.JournalId
inner join STD_Status s on exH.StatusId=s.Id
inner join IMPORT_DB.CDS_SYS.SYS_Status inS on s.Name=inS.Name
INNER JOIN GLX_Period p on exH.PeriodId=p.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period inP on p.StartDate=inP.StartDate
LEFT JOIN tblDocument exDoc on exH.DocumentId=exDoc.iDocumentId
LEFT JOIN tempDocNumber tempDoc on exDoc.pkDocumentGuid=tempDoc.DocGuid
LEFT JOIN tempJournalType TypeMap on exH.InternalReference=TypeMap.TypeMapping and exDoc.fkDocumentTypeGuid=TypeMap.TypeGuid
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exH.CreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT


-- -----------------------------
-- Push to Headers database 
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Push to Headers database'
PRINT '-----------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Header ON
INSERT INTO IMPORT_DB.CDS_GLX.GLX_Header (Id,PeriodId,StatusId,TrackId,JournalTypeId,Reference,Description,Date,PostedDate,CreatedOn,CreatedBy,ReferenceId)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
  'SELECT
tempGLX_headerMap.Id Id
,tempGLX_headerMap.PeriodId PeriodId
,tempGLX_headerMap.StatusId StatusId
,tempGLX_headerMap.TrackId TrackId
,tempGLX_headerMap.JournalTypeId JournalTypeId
,tempGLX_headerMap.Reference Reference
,tempGLX_headerMap.Description Description
,tempGLX_headerMap.Date Date
,tempGLX_headerMap.PostedDate PostedDate
,tempGLX_headerMap.CreatedOn CreatedOn
,tempGLX_headerMap.CreatedBy CreatedBy
,tempGLX_headerMap.ReferenceId ReferenceId
FROM tempGLX_headerMap ') as e;

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Header OFF
GO


-- -----------------------------
-- Push to Lines database
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Push to Lines database'
PRINT '-----------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Line ON
insert into IMPORT_DB.CDS_GLX.GLX_Line (Id,HeaderId,EntityId,ReconId,TaxId,CenterId,AgingId,Amount,CreatedOn,CreatedBy)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
     'SELECT
ROW_NUMBER() OVER (ORDER BY exL.Id) Id
,exH.Id HeaderId
,inE.Id EntityId
,null ReconId
,null TaxId
,null CenterId
,exL.AgingId AgingId
,isnull(exL.Amount,0) Amount
,exL.CreatedOn CreatedOn
,exH.CreatedBy CreatedBy
FROM GLX_Line exL
INNER JOIN tempGLX_headerMap exH on exL.HeaderId=exH.ExHeaderId
INNER JOIN GLX_Account exA on exL.AccountId=exA.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on exA.CodeMain=inE.CodeMain and exA.CodeSub=inE.CodeSub and inE.TypeId = 5') as e;

SET IDENTITY_INSERT IMPORT_DB.CDS_GLX.GLX_Line OFF
GO

USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO