

EXEC sp_configure 'show advanced options', 1
RECONFIGURE
GO
EXEC sp_configure 'ad hoc distributed queries', 1
RECONFIGURE
GO
exec sp_configure  xp_cmdshell,1
reconfigure
GO

USE EXPORT_DB
GO

print '==========================================================================================='
print ' CHecking for Duplicate InventoryAdjustments!'
print '==========================================================================================='
GO

IF EXISTS (select fkDocumentLineGuid from EXPORT_DB.dbo.tblInventoryAdjustment where  sCostColumn='dUnitCost' group by fkDocumentLineGuid having count(1)>1)
BEGIN
DELETE a FROM EXPORT_DB.dbo.tblInventoryAdjustment a 
inner join (
select fkDocumentLineGuid from EXPORT_DB.dbo.tblInventoryAdjustment 
where  sCostColumn='dUnitCost'
group by fkDocumentLineGuid
having count(1)>1
) as r on a.fkDocumentLineGuid=r.fkDocumentLineGuid and a.sCostColumn='dUnitCost'
where a.iInventoryAdjustmentID not in (
select min(iInventoryAdjustmentID) from EXPORT_DB.dbo.tblInventoryAdjustment 
where  sCostColumn='dUnitCost'
group by fkDocumentLineGuid
having count(1)>1)
DECLARE @Duplicates int = @@ROWCOUNT
print '==========================================================================================='
print convert(nvarchar(10), @Duplicates) + ' DUPLICATE InventoryAdjustments have just been DELETED!'
print '==========================================================================================='

END

GO

print '------------------------------------------------------------'
print '-------- Updating Canceled Document Line Status ---------'
print '------------------------------------------------------------'
GO

UPDATE EXPORT_DB.dbo.tblDocumentLine
  SET fkStatusGuid = '3142D822-9E01-4084-8C0A-0636ACCAAE62'
FROM EXPORT_DB.dbo.tblDocumentLine
     INNER JOIN EXPORT_DB.dbo.tblDocument ON fkDocumentGuid = tblDocument.pkDocumentGuid
WHERE tblDocument.fkStatusGuid = '3142D822-9E01-4084-8C0A-0636ACCAAE62'
  AND tblDocument.fkStatusGuid <> tblDocumentLine.fkStatusGuid
  AND tblDocumentLine.dQuantity > tblDocumentLine.dQuantity2;
   
GO 

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_Entity OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_Address OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_Tracking OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_DOC_Header OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_DOC_Line OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].GLX_Header OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].GLX_Line OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_ITM].ITM_History OFF 
SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].GLX_Account OFF
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].SYS_Person OFF
GO

--delete IMPORT_DB.dbo.GLX_Line
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_Line',RESEED,0)
--delete IMPORT_DB.dbo.GLX_Header
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_Header',RESEED,0)
--delete IMPORT_DB.dbo.ORG_TRX_Header
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_TRX_Header',RESEED,0)
--truncate table IMPORT_DB.dbo.ITM_Movement
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_Movement',RESEED,0)
--delete IMPORT_DB.CDS_SYS.SYS_DOC_Line
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_DOC_Line',RESEED,0)
--delete IMPORT_DB.CDS_SYS.SYS_DOC_Header
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_DOC_Header',RESEED,0)
--delete IMPORT_DB.CDS_SYS.SYS_Tracking
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_Tracking',RESEED,0)

--truncate table IMPORT_DB.dbo.ITM_History
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_History',RESEED,0)
--delete IMPORT_DB.dbo.ITM_InventorySupplier
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_InventorySupplier',RESEED,0)
--delete IMPORT_DB.dbo.ITM_Inventory
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_Inventory',RESEED,0)

--delete IMPORT_DB.dbo.ORG_CompanyAddress
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_CompanyAddress',RESEED,0)
--delete IMPORT_DB.CDS_SYS.SYS_Address where id not in (1,2)
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_Address',RESEED,2)
--delete IMPORT_DB.dbo.ORG_History
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_History',RESEED,0)
--delete IMPORT_DB.dbo.ORG_Company
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_Company',RESEED,0)
--delete IMPORT_DB.dbo.ORG_Entity
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_Entity',RESEED,0)

--delete IMPORT_DB.dbo.GLX_History
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_History',RESEED,0)
--delete IMPORT_DB.dbo.GLX_SiteAccount
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_SiteAccount',RESEED,0)
--delete IMPORT_DB.dbo.GLX_Account
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_Account',RESEED,0)
--delete IMPORT_DB.CDS_SYS.SYS_Period
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_Period',RESEED,0)

--delete IMPORT_DB.CDS_SYS.SYS_Entity
--DBCC CHECKIDENT ('IMPORT_DB.CDS_SYS.SYS_Entity',RESEED,0)

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempImportStartDate'))
	drop table EXPORT_DB.dbo.tempImportStartDate
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempMEDates'))
	drop table dbo.tempMEDates
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'temp24MonthHistMap'))
	drop table dbo.temp24MonthHistMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempAccountType'))
	drop table dbo.tempAccountType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempSiteAccountType'))
	drop table dbo.tempSiteAccountType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLAccount'))
	drop table dbo.tempGLAccount
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempCostCategory'))
	drop table dbo.tempCostCategory
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempPaymentTerm'))
	drop table dbo.tempPaymentTerm
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempCompany'))
	drop table dbo.tempCompany
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempOrgContacts'))
	drop table dbo.tempOrgContacts
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempAddress'))
	drop table dbo.tempAddress
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocNumber'))
	drop table dbo.tempDocNumber
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocLineMap'))
	drop table dbo.tempDocLineMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempTrack'))
	drop table dbo.tempTrack
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocType'))
	drop table dbo.tempDocType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLHeaderMap'))
	drop table dbo.tempGLHeaderMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempJournalType'))
	drop table dbo.tempJournalType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempMEINVId'))
	drop table dbo.tempMEINVId
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLHeaderMap'))
	drop table dbo.tempGLHeaderMap
--IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddress'))
--	DROP TABLE EXPORT_DB.dbo.tempDocAddress
--IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddressCleanup'))
--	DROP TABLE EXPORT_DB.dbo.tempDocAddressCleanup
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLXLineMapping'))
	DROP TABLE dbo.tempGLXLineMapping
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLX_Header'))
	DROP TABLE dbo.tempGLX_Header
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLX_Line'))
	DROP TABLE dbo.tempGLX_Line
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLJournalMapping'))
	DROP TABLE dbo.tempGLJournalMapping
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLX_headerMap'))
	DROP TABLE dbo.tempGLX_headerMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempInventory'))
	drop table EXPORT_DB.dbo.tempInventory
	

GO



-- ------------------------------------------
-- Create Import Indexes
-- ------------------------------------------
print 'Create Import Indexes'
GO

print '-----------------------------'
print 'Updating Stock Modifiers'
print '-----------------------------'
GO
update tlDocumentType set iStockModifier = 1	 where iDocumentTypeId = 27
update tlDocumentType set iStockModifier = -1 where iDocumentTypeId = 1
update tlDocumentType set iStockModifier = -1 where iDocumentTypeId = 3
update tlDocumentType set iStockModifier = 1	 where iDocumentTypeId = 5
update tlDocumentType set iStockModifier = 1	 where iDocumentTypeId = 20
update tlDocumentType set iStockModifier = -1 where iDocumentTypeId = 19
update tlDocumentType set iStockModifier = 1	 where iDocumentTypeId = 13
update tlDocumentType set iStockModifier = 1	 where iDocumentTypeId = 14
GO

print '-----------------------------'
print 'Repair Documnetline Totals'
print '-----------------------------'
GO
DECLARE @VAT INT;
SELECT @VAT = CAST(sValue AS INT)
FROM tblSetting
WHERE sName LIKE 'SITEVATPERCENTAGE';
UPDATE tblDocumentLine
  SET dTotalAmount = CASE
                         WHEN fkCostCategoryGuid IN( 'F743187C-7049-4D5B-8542-51D2A7C6C8EA', '785C5822-AD93-4079-B218-DE5FBA9FE271' )
                         THEN( dQuantity * dUnitPrice ) * ( 1 + ( @VAT / 100.00 ))
                         ELSE dQuantity * dUnitPrice
                     END
FROM tblDocumentLine
     INNER JOIN tblDocument ON pkDocumentGuid = tblDocumentLine.fkDocumentGuid
     INNER JOIN tblCompany ON fkCompanyGuid = pkCompanyGuid
     INNER JOIN tblAccount ON pkCompanyGuid = tblAccount.fkCompanyGuid
WHERE ROUND(dQuantity * dUnitPrice, 2) <> tblDocumentLine.dTotalAmountBeforeTax
  AND dQuantity * dUnitPrice <> tblDocumentLine.dTotalAmountBeforeTax;
UPDATE tblDocumentLine
  SET dTotalAmountBeforeTax = dQuantity * dUnitPrice
FROM tblDocumentLine
     INNER JOIN tblDocument ON pkDocumentGuid = tblDocumentLine.fkDocumentGuid
     INNER JOIN tblCompany ON fkCompanyGuid = pkCompanyGuid
     INNER JOIN tblAccount ON pkCompanyGuid = tblAccount.fkCompanyGuid
WHERE ROUND(dQuantity * dUnitPrice, 2) <> tblDocumentLine.dTotalAmountBeforeTax
  AND dQuantity * dUnitPrice <> tblDocumentLine.dTotalAmountBeforeTax;
UPDATE tblDocumentLine
  SET dTotalTax = CASE
                      WHEN fkCostCategoryGuid IN( 'F743187C-7049-4D5B-8542-51D2A7C6C8EA', '785C5822-AD93-4079-B218-DE5FBA9FE271' )
                      THEN((( dQuantity * dUnitPrice ) * ( 1 + ( @VAT / 100.00 ))) / ( 100.00 + @VAT )) * @VAT
                      ELSE 0
                  END
FROM tblDocumentLine
     INNER JOIN tblDocument ON pkDocumentGuid = tblDocumentLine.fkDocumentGuid
     INNER JOIN tblCompany ON fkCompanyGuid = pkCompanyGuid
     INNER JOIN tblAccount ON pkCompanyGuid = tblAccount.fkCompanyGuid
WHERE tblDocumentLine.dTotalAmount <> tblDocumentLine.dTotalAmountBeforeTax + tblDocumentLine.dTotalTax;
GO

-- -----------------------------
-- Create Temp Lookup Tables
-- -----------------------------
print '-----------------------------'
print 'Create Temp Lookup Tables'
print '-----------------------------'
GO

SELECT MAX(EndDate) StartDate INTO tempImportStartDate FROM GLX_Period WHERE GETDATE() BETWEEN StartDate AND EndDate
GO

select 1 as TypeId, 'GLX_SETTLEMENTDISCOUNTRECEIVED' as Name into tempSiteAccountType
where 1=2
GO

INSERT INTO tempSiteAccountType VALUES (1	,'GLX_BANK')
INSERT INTO tempSiteAccountType VALUES (2	,'GLX_CARDCONTROL')
INSERT INTO tempSiteAccountType VALUES (3	,'GLX_CASHCONTROL')
INSERT INTO tempSiteAccountType VALUES (4	,'GLX_CHEQUECONTROL')
INSERT INTO tempSiteAccountType VALUES (5	,'GLX_COSTDIFFERENCE')
INSERT INTO tempSiteAccountType VALUES (6	,'GLX_COSTOFSALES')
INSERT INTO tempSiteAccountType VALUES (7	,'GLX_CREDITCONTROL')
INSERT INTO tempSiteAccountType VALUES (8	,'GLX_CREDITORS')
INSERT INTO tempSiteAccountType VALUES (9	,'GLX_DEBTORS')
INSERT INTO tempSiteAccountType VALUES (10	,'GLX_DISTRIBUTEDRESERVES')
INSERT INTO tempSiteAccountType VALUES (11	,'GLX_EFTCONTROL')
INSERT INTO tempSiteAccountType VALUES (12	,'GLX_INTERESTCHARGED')
INSERT INTO tempSiteAccountType VALUES (13	,'GLX_INVENTORY')
INSERT INTO tempSiteAccountType VALUES (14	,'GLX_PROFIT')
INSERT INTO tempSiteAccountType VALUES (16	,'GLX_ROUNDING')
INSERT INTO tempSiteAccountType VALUES (17	,'GLX_SALES')
INSERT INTO tempSiteAccountType VALUES (18	,'GLX_SETTLEMENTDISCOUNTALLOWED')
INSERT INTO tempSiteAccountType VALUES (19	,'GLX_SETTLEMENTDISCOUNTRECEIVED')
INSERT INTO tempSiteAccountType VALUES (20	,'GLX_STOCKADJUSTMENT')
INSERT INTO tempSiteAccountType VALUES (21	,'GLX_VATACCOUNT')
GO


select 1 as CCId, 'SELLING PRICE INCLUDING SALES TAX' as Name, newid() CCGuid into tempCostCategory
where 1=2
GO

INSERT INTO tempCostCategory VALUES (1	,'SELLING PRICE INCLUDING SALES TAX'	,'F743187C-7049-4D5B-8542-51D2A7C6C8EA'  )  
INSERT INTO tempCostCategory VALUES (2	,'SELLING PRICE EXCLUDING SALES TAX'	,'8489697B-765C-48C2-8BE0-E9F8A6EBDE1B'	 )  
INSERT INTO tempCostCategory VALUES (3	,'COST INCLUDING SALES TAX'				,'785C5822-AD93-4079-B218-DE5FBA9FE271'	 )  
INSERT INTO tempCostCategory VALUES (4	,'COST EXCLUDING SALES TAX'				,'F58CB75B-7824-4294-B2EE-6D02E5F3D54E'	 )  
INSERT INTO tempCostCategory VALUES (5	,'AVERAGE COST EXCLUDING SALES TAX'		,'5A6B0E58-CE68-4962-B7A2-1D47626EE3DB'	 )  
GO

select 1 as TermId, '120 Days' as Name, newid() TermGuid into tempPaymentTerm
where 1=2
GO

INSERT INTO tempPaymentTerm VALUES (1	,'Cash',				'BBD28819-92B0-41B1-A66A-3EB5FA7D0EBF' 	 )  
INSERT INTO tempPaymentTerm VALUES (2	,'30 Days',				'3662CFBE-C7D3-4721-BF92-29D34D07ECE2'	 )  
INSERT INTO tempPaymentTerm VALUES (3	,'60 Days',				'8D46FB8A-A7E4-4563-922D-D8E882FBE981'	 )  
INSERT INTO tempPaymentTerm VALUES (4	,'90 Days',				'419E0972-B3BB-4E7F-9C2A-76173336F245'	 )  
INSERT INTO tempPaymentTerm VALUES (5	,'120 Days',			'AFE1DC2D-05F6-49BA-B887-0A6E5184FB4F'	 )  
GO


select 1 as TypeId, 'BOM Disassembly Started' as Name, newid() TypeGuid, cast(null as int) as JournalTypeId,'Creditor Goods Returned to Acc #:P000000' as TypeDescription into tempDocType
where 1=2
GO

INSERT INTO tempDocType VALUES (14	,'Back Order', '7CD8EDAF-2146-44ED-AC11-911365E60B30' ,null	,'')  
INSERT INTO tempDocType VALUES (15	,'BOM Assembly Started',	'02703B87-79CD-48CE-A254-C33DF8BDC02B' ,null	,'')  
INSERT INTO tempDocType VALUES (17	,'BOM Canceled', '6BFED700-D51B-4BDA-BA85-F94870B20DAC'	,null	,'')  
INSERT INTO tempDocType VALUES (18	,'BOM Complete',	'8CF7F907-734E-4F48-AECD-E6A58758C481' ,null	,'')  
INSERT INTO tempDocType VALUES (16	,'BOM Disassembly Started', '76A9EDBB-AA2C-4D64-86A5-C19A58D61C5C'	,null	,'')  
INSERT INTO tempDocType VALUES (4	,'Credit Note', '17AA529B-884A-4EC4-928B-EED6F576F825'	,5	,'Debtor Credit to Acc #: ')  
INSERT INTO tempDocType VALUES (7	,'Goods Received',	'8DA1C782-2BCA-4E81-B28B-EAFD3204D02D' ,6	,'Creditor Goods Received to Acc #: ')  
INSERT INTO tempDocType VALUES (8	,'Goods Returned', '15D85108-00C5-48BC-930D-4E87BC46F67F'	,7	,'Creditor Goods Returned to Acc #: ')  
INSERT INTO tempDocType VALUES (13	,'Inventory Adjustment',	'29770704-9D0D-4848-81F9-5CBC7551DD38'	,2 ,'Inventory Adjustment.')  
INSERT INTO tempDocType VALUES (9	,'Job',	'61A82D4C-4DA1-4D66-BB54-254BCE402517'	,null	,'')  
INSERT INTO tempDocType VALUES (7	,'Goods Received',	'D0302A33-B772-464B-B73E-10FCB2FB9E50' ,6	,'Creditor Goods Received to Acc #: ')  
INSERT INTO tempDocType VALUES (9	,'Job',	'6E7FE39F-0236-42A3-873B-C8D377B74747'	,null	,'')  
INSERT INTO tempDocType VALUES (6	,'Purchase Order', '70F65416-0F87-4999-B745-3DDA72B4A6CE'	,null	,'')  
INSERT INTO tempDocType VALUES (1	,'Quote', '8EB11219-580C-4414-9667-61B26EE64F6D'	,null	,'')  
INSERT INTO tempDocType VALUES (2	,'Sales Order', '35F6974F-B224-41F9-85BB-78EB03EFB308'	,null	,'')  
INSERT INTO tempDocType VALUES (3	,'TAX Invoice', '6AE4CCED-0439-45B3-B0ED-2C833928D46C'	,1	,'TAX Invoice to Acc #: ')  
GO


select 1 as TypeId, newid() TypeGuid, 'INV - tblcreditor - Goods Recieved' TypeMapping, cast(null as bit) Creditor, CAST(null as nvarchar(100)) HeaderDesc into tempJournalType where 1=2
GO

INSERT INTO tempJournalType VALUES (1 ,'6AE4CCED-0439-45B3-B0ED-2C833928D46C'	,'INV', null, null)
INSERT INTO tempJournalType VALUES (2 ,NULL	,'JNL', null, null)
INSERT INTO tempJournalType VALUES (3 ,NULL	,'PAY',null, null)
INSERT INTO tempJournalType VALUES (4 ,NULL	,'REC', null, null)
INSERT INTO tempJournalType VALUES (5 ,NULL	,'C/N', null,null)
INSERT INTO tempJournalType VALUES (6 ,'8DA1C782-2BCA-4E81-B28B-EAFD3204D02D'	,'INV', null,null)
INSERT INTO tempJournalType VALUES (7 ,NULL	,'D/N', null,null)
INSERT INTO tempJournalType VALUES (9 ,NULL	,'PAY.REV', null, null)
INSERT INTO tempJournalType VALUES (9 ,NULL	,'REC.REV', null, null)
INSERT INTO tempJournalType VALUES (11 ,NULL ,'BULK',null,null)

GO


-- -----------------------------
-- Create Temp Tracking Table
-- -----------------------------
PRINT '-----------------------------'
PRINT 'Create Temp Tracking Table'
PRINT '-----------------------------'
GO


select 
1 AS id
,cast(null as uniqueidentifier) DocGuid
, cast('' as nvarchar(50)) TypeCode
, CAST(null as bigint) JournalId 
, cast(0 as bit) Archived
into tempTrack where 1=2

GO



-- -----------------------------
-- Remove Track # 1 WriteOff
-- -----------------------------
PRINT '-----------------------------'
PRINT 'Remove Track # 1 WriteOff'
PRINT '-----------------------------'
GO


DELETE FROM GLX_Line WHERE HeaderId=(SELECT Id FROM GLX_Header WHERE CreatedBy='SYSTEM IMPORTER')
DELETE FROM GLX_Header WHERE CreatedBy='SYSTEM IMPORTER'
GO


SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Period ON
INSERT INTO IMPORT_DB.CDS_SYS.SYS_Period (Id,StartDate,EndDate,Code,Name,Description,StatusId,FinancialYear,FinancialQuarter)
SELECT 
ROW_NUMBER() OVER (ORDER BY p.Id) Id 
, p.StartDate StartDate
, p.EndDate EndDate
, p.Code Code
, p.Code Name
, p.Description Description
, inS.Id StatusId
, p.FinancialYear FinancialYear
, p.FinancialQuarter FinancialQuarter
FROM GLX_Period p
inner join STD_Status s on StatusId=s.Id
inner join IMPORT_DB.CDS_SYS.SYS_Status inS on s.Name=inS.Name

SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Period OFF

GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO