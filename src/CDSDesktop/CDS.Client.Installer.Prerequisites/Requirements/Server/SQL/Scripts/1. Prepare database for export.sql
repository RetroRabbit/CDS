

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
GO

--delete IMPORT_DB.dbo.GLX_Line
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_Line',RESEED,0)
--delete IMPORT_DB.dbo.GLX_Header
--DBCC CHECKIDENT ('IMPORT_DB.dbo.GLX_Header',RESEED,0)
--delete IMPORT_DB.dbo.ORG_TRX_Header
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_TRX_Header',RESEED,0)
--delete IMPORT_DB.dbo.SYS_DOC_Line
--DBCC CHECKIDENT ('IMPORT_DB.dbo.SYS_DOC_Line',RESEED,0)
--delete IMPORT_DB.dbo.SYS_DOC_Header
--DBCC CHECKIDENT ('IMPORT_DB.dbo.SYS_DOC_Header',RESEED,0)
--delete IMPORT_DB.dbo.SYS_Tracking
--DBCC CHECKIDENT ('IMPORT_DB.dbo.SYS_Tracking',RESEED,0)

--truncate table IMPORT_DB.dbo.ITM_Movement
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_Movement',RESEED,0)
--truncate table IMPORT_DB.dbo.ITM_History
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_History',RESEED,0)
--delete IMPORT_DB.dbo.ITM_InventorySupplier
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_InventorySupplier',RESEED,0)
--delete IMPORT_DB.dbo.ITM_Inventory
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ITM_Inventory',RESEED,0)

--delete IMPORT_DB.dbo.ORG_CompanyAddress
--DBCC CHECKIDENT ('IMPORT_DB.dbo.ORG_CompanyAddress',RESEED,0)
--delete IMPORT_DB.dbo.SYS_Address where id not in (1,2)
--DBCC CHECKIDENT ('IMPORT_DB.dbo.SYS_Address',RESEED,2)
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

--delete IMPORT_DB.dbo.SYS_Entity where Id <> 1
--DBCC CHECKIDENT ('IMPORT_DB.dbo.SYS_Entity',RESEED,1)

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempImportStartDate'))
	drop table EXPORT_DB.dbo.tempImportStartDate
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempMEDates'))
	drop table EXPORT_DB.dbo.tempMEDates
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'temp24MonthHistMap'))
	drop table EXPORT_DB.dbo.temp24MonthHistMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempAccountType'))
	drop table EXPORT_DB.dbo.tempAccountType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempSiteAccountType'))
	drop table EXPORT_DB.dbo.tempSiteAccountType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLAccount'))
	drop table EXPORT_DB.dbo.tempGLAccount
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempCostCategory'))
	drop table EXPORT_DB.dbo.tempCostCategory
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempPaymentTerm'))
	drop table EXPORT_DB.dbo.tempPaymentTerm
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempCompany'))
	drop table EXPORT_DB.dbo.tempCompany
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempOrgContacts'))
	drop table EXPORT_DB.dbo.tempOrgContacts
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempInventory'))
	drop table EXPORT_DB.dbo.tempInventory
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempAddress'))
	drop table EXPORT_DB.dbo.tempAddress
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocNumber'))
	drop table EXPORT_DB.dbo.tempDocNumber
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocLineMap'))
	drop table EXPORT_DB.dbo.tempDocLineMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempTrack'))
	drop table EXPORT_DB.dbo.tempTrack
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocType'))
	drop table EXPORT_DB.dbo.tempDocType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLHeaderMap'))
	drop table EXPORT_DB.dbo.tempGLHeaderMap
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempJournalType'))
	drop table EXPORT_DB.dbo.tempJournalType
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempMEINVId'))
	drop table EXPORT_DB.dbo.tempMEINVId
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLHeaderMap'))
	drop table EXPORT_DB.dbo.tempGLHeaderMap
--IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddress'))
--	DROP TABLE EXPORT_DB.dbo.tempDocAddress
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tmpFutureHistory'))
	DROP TABLE EXPORT_DB.dbo.tmpFutureHistory
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLXLineMapping'))
	DROP TABLE EXPORT_DB.dbo.tempGLXLineMapping
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLX_Header'))
	DROP TABLE EXPORT_DB.dbo.tempGLX_Header
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLX_Line'))
	DROP TABLE EXPORT_DB.dbo.tempGLX_Line
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempGLJournalMapping'))
	DROP TABLE EXPORT_DB.dbo.tempGLJournalMapping

GO

print 'Fixing data'
IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_rssports' and state = 0 )
BEGIN
    UPDATE cds_rssports..tblGeneralLedger SET sDescription = 'OPENING BALANCE' WHERE sDescription = 'OPENING BALANCE CONTRA';
    UPDATE cds_rssports..tblGeneralLedger SET sReference = REPLACE(sReference,' CONTRA','') WHERE sReference like '% CONTRA'
    UPDATE cds_rssports..tblGeneralLedger SET fkGeneralLedgerAccount1Guid = '58A2FB71-7DDA-499E-BB72-4DEEDA5E5F8E' WHERE fkGeneralLedgerAccount1Guid = '07E2E0E5-37F7-44D6-966D-73EC63EF2A32';
    UPDATE cds_rssports..tblGeneralLedger SET fkGeneralLedgerAccount2Guid = '58A2FB71-7DDA-499E-BB72-4DEEDA5E5F8E' WHERE fkGeneralLedgerAccount2Guid = '07E2E0E5-37F7-44D6-966D-73EC63EF2A32';
	UPDATE cds_rssports..tblGeneralLedger SET dtdate = '2013-11-06 11:35:13.757' WHERE sReference = 'OCT-GJ006' AND sDescription = 'MANAL R36 TO SALES' AND dtDate = '2013-11-06 11:35:13.000'
	update cds_rssports..tblGeneralLedger set dtdate = '2013-07-12 12:52:28.850' where sReference = 'JUL-GJ002' and sDescription = 'REALL MANUAL R12 TO SALES - REPAIRS INV' and dtDate = '2013-07-09 12:52:28.000'
	update cds_rssports..tblGeneralLedger set dtdate = '2013-04-19 11:17:14.290' where sReference = 'APR-GJ003' and sDescription = 'REALL CASH DPEOSIT BANKED INTO DE BANK ACC TO 8402' and dtDate = '2013-04-04 11:17:14.000'
	update cds_rssports..tblGeneralLedger set dtdate = '2013-07-12 12:33:57.127' where sReference = 'JUL-GJ001' and sDescription = 'REALL DISCOUNT ON CASH INVOICE AS PER RAMON TO ACCOUNT ' and dtDate = '2013-07-02 12:33:57.000'
	update cds_rssports..tblCreditor set dtdate = '2012-01-04 23:59:59.000' where pkCreditorGuid = '49B52B0A-A416-47D3-B2DF-9E529E91DDCE'
END;

-- -----------------------------
-- Create Functions
-- -----------------------------
print 'Create Functions'
GO

IF OBJECT_ID('[dbo].[fnRemoveNonNumericCharacters]') IS NOT NULL
  DROP FUNCTION [dbo].[fnRemoveNonNumericCharacters]
GO

CREATE Function [dbo].[fnRemoveNonNumericCharacters](@strText VARCHAR(1000))
RETURNS VARCHAR(1000)
AS
BEGIN
	WHILE PATINDEX('%[^0-9]%', @strText) > 0
	BEGIN
		SET @strText = STUFF(@strText, PATINDEX('%[^0-9]%', @strText), 1, '')
	END
	RETURN @strText
END
GO

IF OBJECT_ID('[dbo].[fnMakeCode]') IS NOT NULL
  DROP FUNCTION [dbo].[fnMakeCode]
GO

CREATE Function [dbo].[fnMakeCode](@strText VARCHAR(1000))
RETURNS VARCHAR(1000)
AS
BEGIN
    
	SET @strText = dbo.[fnRemoveNonNumericCharacters](@strText)
	SET @strText = RIGHT('0000000'+LEFT(@strText, 7),7)
	IF LTRIM(@strText) = '' OR @strText = '0000000'
SET @strText = '0000001'
ELSE 
SET @strText = @strText
--SET @strText = IIF(LTRIM(@strText) = '' OR @strText = '00000','00001',@strText)

	RETURN @strText
END
GO

IF OBJECT_ID('[dbo].[fnMakePrefix]') IS NOT NULL
  DROP FUNCTION [dbo].[fnMakePrefix]
GO

CREATE Function [dbo].[fnMakePrefix](@strText VARCHAR(1000))
RETURNS VARCHAR(1000)
AS
BEGIN
    
	WHILE PATINDEX('%[^a-z]%', @strText) > 0
	BEGIN
		SET @strText = STUFF(@strText, PATINDEX('%[^a-z]%', @strText), 1, '')
	END
	
	WHILE PATINDEX('%[^A-Z]%', @strText) > 0
	BEGIN
		SET @strText = STUFF(@strText, PATINDEX('%[^A-Z]%', @strText), 1, '')
	END

	RETURN @strText
END
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

-- ------------------------------------------
-- Create Import Indexes
-- ------------------------------------------
print 'Create Import Indexes'
GO
PRINT 'NNNNNNNNNNNNNNNNNNNNNNNEEEEEEEEEEEEEEDDDDDDDDDDDDDDDDDDDDDD TO UNDO'
--IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblGeneralLedger]') AND name = N'IDX_tblGeneralLedger_fkDocumentGuid')
--DROP INDEX [IDX_tblGeneralLedger_fkDocumentGuid] ON [dbo].[tblGeneralLedger]
--GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblGeneralLedger]') AND name = N'IDX_tblGeneralLedger_fkDocumentGuid')
--CREATE NONCLUSTERED INDEX [IDX_tblGeneralLedger_fkDocumentGuid] ON [dbo].[tblGeneralLedger]
--(
--[fkDocumentGuid] ASC
--)
--INCLUDE ( [dtDate],
--[dtCreatedOn],
--[sReference]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
--GO

--IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblGeneralLedger]') AND name = N'IDX_tblGeneralLedger_fkDocumentGuid_sDescription')
--DROP INDEX [IDX_tblGeneralLedger_fkDocumentGuid_sDescription] ON [dbo].[tblGeneralLedger]
--GO

--IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblGeneralLedger]') AND name = N'IDX_tblGeneralLedger_fkDocumentGuid_sDescription')
--CREATE NONCLUSTERED INDEX [IDX_tblGeneralLedger_fkDocumentGuid_sDescription] ON [dbo].[tblGeneralLedger]
--(
--	[fkDocumentGuid] ASC,
--	[sDescription] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
--GO


IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_fkDocumentGuid')
DROP INDEX [IDX_tblDebtor_fkDocumentGuid] ON [dbo].[tblDebtor]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_fkDocumentGuid')
CREATE NONCLUSTERED INDEX [IDX_tblDebtor_fkDocumentGuid] ON [dbo].[tblDebtor]
(
[fkDocumentGuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_JournalEntryTypeGuid')
DROP INDEX [IDX_tblDebtor_JournalEntryTypeGuid] ON [dbo].[tblDebtor]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_JournalEntryTypeGuid')
CREATE NONCLUSTERED INDEX [IDX_tblDebtor_JournalEntryTypeGuid]
ON [dbo].[tblDebtor] ([fkJournalEntryTypeGuid])
INCLUDE ([pkDebtorGuid],[fkDebtorReferenceGuid])
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCreditor]') AND name = N'IDX_tblCreditor_fkJournalEntryTypeGuid')
DROP INDEX [IDX_tblCreditor_fkJournalEntryTypeGuid] ON [dbo].[tblCreditor]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblCreditor]') AND name = N'IDX_tblCreditor_fkJournalEntryTypeGuid')
CREATE NONCLUSTERED INDEX [IDX_tblCreditor_fkJournalEntryTypeGuid]
ON [dbo].[tblCreditor] ([fkJournalEntryTypeGuid])
INCLUDE ([iCreditorId],[pkCreditorGuid],[sReference],[dtDate],[fkDocumentGuid],[fkAccountGuid],[dtCreatedOn])
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_sReference')
DROP INDEX [IDX_tblDebtor_sReference] ON [dbo].[tblDebtor]
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblDebtor]') AND name = N'IDX_tblDebtor_sReference')
CREATE NONCLUSTERED INDEX [IDX_tblDebtor_sReference]
ON [dbo].[tblDebtor] ([sReference])
INCLUDE ([iDebtorId])
GO
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

-- -----------------------------
-- Create Temp Lookup Tables
-- -----------------------------
print '-----------------------------'
print 'Create Temp Lookup Tables'
print '-----------------------------'
GO


select MAX(dtdate) StartDate into tempImportStartDate from tblMonthEnd

select 1 as TypeId, 'Current Liabilities' as Name, newid() TypeGuid into tempAccountType
where 1=2
GO

INSERT INTO tempAccountType VALUES (1	,'Sales',					'22EFE845-7423-4211-8B41-3A3F5401B4EF' 	 )  
INSERT INTO tempAccountType VALUES (2	,'Cost of Sales',			'089BCF5A-BE96-4C2A-8FB7-604DDEB6D86D'	 )  
INSERT INTO tempAccountType VALUES (3	,'Expenses',				'1E624363-7B88-45CD-8223-56E8C9959577'	 )  
INSERT INTO tempAccountType VALUES (4	,'Current Assets',			'0B6E5863-E909-4DF6-A360-6B9D6BE06C8A'	 )   
INSERT INTO tempAccountType VALUES (4	,'Current Assets',			'4DFF4973-7358-4389-AF71-DB2CFB086754'	 ) 
INSERT INTO tempAccountType VALUES (5	,'Current Liabilities',		'A4456B79-C62E-4049-B804-6B7E8F440F6C'	 )  
INSERT INTO tempAccountType VALUES (6	,'Equity',					'9B3081E9-04FA-4244-816A-A7F0C97FFA4F'	 )  
INSERT INTO tempAccountType VALUES (7	,'Tax',						'4E241116-8E68-44CC-890B-3C5EE86F460A'	 )  
INSERT INTO tempAccountType VALUES (8	,'Long Term Debt',			'8E7435DA-40BB-41DC-AD08-A2073FD8B73A'	 )  
INSERT INTO tempAccountType VALUES (9	,'Fixed Assets',			'6CB0206D-90BF-4FF1-81DF-80145CCF6513'	 )  
GO

select 1 as TypeId, 'GL_SETTLEMENTDISCOUNTRECEIVED' as Name into tempSiteAccountType
where 1=2
GO

INSERT INTO tempSiteAccountType VALUES (1	,'GL_BANK')
INSERT INTO tempSiteAccountType VALUES (2	,'GL_CARDCONTROL')
INSERT INTO tempSiteAccountType VALUES (3	,'GL_CASHCONTROL')
INSERT INTO tempSiteAccountType VALUES (4	,'GL_CHEQUECONTROL')
INSERT INTO tempSiteAccountType VALUES (5	,'GL_COSTDIFFERENCE')
INSERT INTO tempSiteAccountType VALUES (6	,'GL_COSTOFSALES')
INSERT INTO tempSiteAccountType VALUES (7	,'GL_CREDITCONTROL')
INSERT INTO tempSiteAccountType VALUES (8	,'GL_CREDITORS')
INSERT INTO tempSiteAccountType VALUES (9	,'GL_DEBTORS')
INSERT INTO tempSiteAccountType VALUES (10	,'GL_DISTRIBUTEDRESERVES')
INSERT INTO tempSiteAccountType VALUES (11	,'GL_EFTCONTROL')
INSERT INTO tempSiteAccountType VALUES (12	,'GL_INTERESTCHARGED')
INSERT INTO tempSiteAccountType VALUES (13	,'GL_INVENTORY')
INSERT INTO tempSiteAccountType VALUES (14	,'GL_PROFIT')
INSERT INTO tempSiteAccountType VALUES (16	,'GL_ROUNDING')
INSERT INTO tempSiteAccountType VALUES (17	,'GL_SALES')
INSERT INTO tempSiteAccountType VALUES (18	,'GL_SETTLEMENTDISCOUNTALLOWED')
INSERT INTO tempSiteAccountType VALUES (19	,'GL_SETTLEMENTDISCOUNTRECEIVED')
INSERT INTO tempSiteAccountType VALUES (20	,'GL_STOCKADJUSTMENT')
INSERT INTO tempSiteAccountType VALUES (21	,'GL_VATACCOUNT')
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

INSERT INTO tempJournalType VALUES (1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F'	,'INV - Invoice', 0, 'Debtor Sale to Acc #: ')
INSERT INTO tempJournalType VALUES (2 ,'0D152893-0F1E-418F-ACBD-04B87F149635'	,'J/CR - Journal', null, null)
INSERT INTO tempJournalType VALUES (2 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B'	,'J/DR - Journal', null, null)
INSERT INTO tempJournalType VALUES (4 ,'31B69D54-3F1F-4461-9563-DA5ADEDF3AE6'	,'CRED.APPLY - Journal', null, null)
INSERT INTO tempJournalType VALUES (4 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1'	,'PAY - Receipts', 0, null)
INSERT INTO tempJournalType VALUES (5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E'	,'C/N - Credit Note', null,'Debtor Credit to Acc #: ')
INSERT INTO tempJournalType VALUES (6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA'	,'BILL - Goods Recieved', null,'Creditor Goods Received to Acc #: ')
INSERT INTO tempJournalType VALUES (7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828'	,'D/N - Goods Returned', null,'Creditor Goods Returned to Acc #: ')
INSERT INTO tempJournalType VALUES (8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253'	,'S/DIS - Settlement Discount', null, null)
INSERT INTO tempJournalType VALUES (9 ,'F35D760B-004A-4663-85BF-341464DD2903'	,'PAY.REV - Reversal', null, null)
INSERT INTO tempJournalType VALUES (9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0'	,'S/DIS.REV - Reversal', null, null)
INSERT INTO tempJournalType VALUES (3 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1'	,'PAY - tblcreditor - Payment',1, null)
INSERT INTO tempJournalType VALUES (6 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F'	,'INV - tblcreditor - Goods Recieved',1,'Creditor Goods Received to Acc #: ')

GO


SELECT 
cast(null as uniqueidentifier) AccountGuid
,cast(null as bigint) JournalTypeId
,cast(null as uniqueidentifier) JournalTypeGuid
,cast(null as int) AmountType
,cast(null as int) AmountMultiplier
,cast(null as bigint) Creditor
into tempGLXLineMapping
where 1=2

GO
--99998 VAT INPUT	5FF0F737-231D-4825-9E32-B9A3DF44701B
--99999 VAT OUTPUT	A791A845-A041-48B9-ADD6-58AFFFCC0D55

--Goods Returned
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 3, 1 ,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, -1,1)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 2, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTDIFFERENCE')				,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, 1 ,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, 1 ,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, -1,1)

IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_rssports' and state = 0 )
	BEGIN
		INSERT INTO tempGLXLineMapping VALUES ('006B9669-3F42-4541-AF4A-0D1A56767962'								,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, 1 ,1) 
	END
ELSE IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_parow' )
	BEGIN
		INSERT INTO tempGLXLineMapping VALUES ( '91D4A975-3038-495C-ABB8-8A79C760B83E'								,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, 1 ,1) 
	END
ELSE 
	BEGIN
		INSERT INTO tempGLXLineMapping VALUES (NULL																	,7 ,'1F6576C8-EF59-4CF2-A5F6-46B0F6923828', 1, 1 ,1) --'91D4A975-3038-495C-ABB8-8A79C760B83E' parow
	END

--Goods Recieved
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,6 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,6 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,6 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 2, 1,1)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA', 1, -1,null)
INSERT INTO tempGLXLineMapping VALUES (null																			,6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA', 2, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,6 ,'7DD58558-4A6B-4E0D-B023-EAF0BEADE6CA', 1, -1,null)

--Credit Note
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 3, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SALES')						,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, -1,null)
INSERT INTO tempGLXLineMapping VALUES ('A791A845-A041-48B9-ADD6-58AFFFCC0D55'										,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 2, -1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, -1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTOFSALES')					,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTDIFFERENCE')				,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,5 ,'C3A4B0AF-20FB-4AAF-826A-6D52D91C887E', 1, -1,null)

--Invoice
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 3, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SALES')						,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, -1,null)
INSERT INTO tempGLXLineMapping VALUES ('A791A845-A041-48B9-ADD6-58AFFFCC0D55'										,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 2, -1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, -1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTOFSALES')					,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTDIFFERENCE')				,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, -1,null)
IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_rssports' and state = 0 )
	BEGIN
		INSERT INTO tempGLXLineMapping VALUES ('006B9669-3F42-4541-AF4A-0D1A56767962'								,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)    
	END																																									  
ELSE IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_parow' )																						  
	BEGIN																																								  
		INSERT INTO tempGLXLineMapping VALUES ('91D4A975-3038-495C-ABB8-8A79C760B83E'								,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)    
	END																																									  
ELSE 																																								  
	BEGIN																																								  
		INSERT INTO tempGLXLineMapping VALUES (NULL																	,1 ,'C4D52D8B-69CC-47B1-A157-07FB3D20D90F', 1, 1,null)   --'91D4A975-3038-495C-ABB8-8A79C760B83E' parow
	END																									

--Posting
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTDIFFERENCE')				,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_STOCKADJUSTMENT')				,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SALES')						,10 ,'0D152893-0F1E-418F-ACBD-04B87F149635', 3, -1,0)
																													 
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_INVENTORY')					,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_COSTDIFFERENCE')				,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_STOCKADJUSTMENT')				,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SALES')						,10 ,'F7EB3848-8036-4620-B8E3-14D4D15FBC5B', 3, -1,0)

--Receipts
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,4 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_BANK')						,4 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1', 3, -1,0)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,4 ,'31B69D54-3F1F-4461-9563-DA5ADEDF3AE6', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_BANK')						,4 ,'31B69D54-3F1F-4461-9563-DA5ADEDF3AE6', 3, -1,0)

--Settlement Discount
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SETTLEMENTDISCOUNTALLOWED')	,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, -1,0)
INSERT INTO tempGLXLineMapping VALUES ('A791A845-A041-48B9-ADD6-58AFFFCC0D55'										,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 2, -1,0)

--Settlement Discount
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SETTLEMENTDISCOUNTALLOWED')	,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,8 ,'7CD8DE04-272C-40B1-ADF6-7CA52605E253', 2, 1,1)

--Payment
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,3 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1', 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_BANK')						,3 ,'1E7006E7-1E9C-444B-8F83-3551BD5D96A1', 3, 1,1)

--Reversal
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,9 ,'F35D760B-004A-4663-85BF-341464DD2903', 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_BANK')						,9 ,'F35D760B-004A-4663-85BF-341464DD2903', 3, 1,1)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,9 ,'F35D760B-004A-4663-85BF-341464DD2903', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_BANK')						,9 ,'F35D760B-004A-4663-85BF-341464DD2903', 3, -1,0)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 3, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SETTLEMENTDISCOUNTALLOWED')	,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, -1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, 1,0)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, -1,0)
INSERT INTO tempGLXLineMapping VALUES ('A791A845-A041-48B9-ADD6-58AFFFCC0D55'										,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 2, -1,0)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_SETTLEMENTDISCOUNTALLOWED')	,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, -1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,9 ,'093DA968-0B73-472F-9AEE-C6B2480888E0', 2, 1,1)

--Journal
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DEBTORS')						,2 ,null, 3, 1,-1)
INSERT INTO tempGLXLineMapping VALUES (null																			,2 ,null, 1, -1,-1)
INSERT INTO tempGLXLineMapping VALUES ('A791A845-A041-48B9-ADD6-58AFFFCC0D55'										,2 ,null, 2, -1,-1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,2 ,null, 1, -1,-1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,2 ,null, 1, 1,-1)

INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_CREDITORS')					,2 ,null, 3, -1,1)
INSERT INTO tempGLXLineMapping VALUES (null																			,2 ,null, 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ('5FF0F737-231D-4825-9E32-B9A3DF44701B'										,2 ,null, 2, 1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,2 ,null, 1, 1,1)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,2 ,null, 1, -1,1)

INSERT INTO tempGLXLineMapping VALUES (null																			,2 ,null, 3, 1,2)
INSERT INTO tempGLXLineMapping VALUES (null																			,2 ,null, 1, -1,2)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_VATACCOUNT')					,2 ,null, 2, -1,2)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_DISTRIBUTEDRESERVES')			,2 ,null, 1, -1,2)
INSERT INTO tempGLXLineMapping VALUES ((SELECT sValue FROM tblSetting where sName='GL_PROFIT')						,2 ,null, 1, 1,2)

GO


-- -----------------------------
-- Create Temp Data Tables
-- -----------------------------
print '-----------------------------'
print 'Create Temp Data Tables'
print '-----------------------------'
GO

--SELECT 
--cast (null  as uniqueidentifier) DocumentGuid,
--ShippingAddressLine1 AS BillingLine1 ,
--ShippingAddressLine2 AS BillingLine2 ,
--ShippingAddressLine3 AS BillingLine3 ,
--ShippingAddressLine4 AS BillingLine4 ,
--BillingAddressLine1	 AS ShippingLine1 ,
--BillingAddressLine2	 AS ShippingLine2 ,
--BillingAddressLine3	 AS ShippingLine3 ,
--BillingAddressLine4  AS ShippingLine4 
--INTO tempDocAddress 
--from IMPORT_DB.dbo.ORG_TRX_Header
--where 1=2
--GO


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
, CAST(null as uniqueidentifier) JournalGuid 
,CAST(null as bit) Archived
into tempTrack where 1=2

GO

-- -----------------------------
-- Create Temp GLX Header Table
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Create Temp GLX Header Table'
PRINT '-----------------------------------'
GO

select 
1 Id
,1 PeriodId
,1 StatusId
,1 TrackId
,1 JournalTypeId
,cast(null as uniqueidentifier) JournalTypeGuid
,cast('' as nvarchar(50)) Reference
,cast('' as nvarchar(100)) Description
,getdate() Date
,getdate() PostedDate
,getdate() CreatedOn
,1 CreatedBy
,cast(null as bigint) ReferenceId
,cast(null as bigint) DebtorId
,cast(null as bigint) CreditorId
,cast(null as bigint) CashId
into tempGLX_Header where 1=2

GO

-- -----------------------------
-- Create Temp GLX Line Table
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Create Temp GLX Line Table'
PRINT '-----------------------------------'
GO


select 
1 Id
,1 HeaderId
,1 EntityId
,1 AgingId
,cast(0.00 as money) Amount
,getdate() CreatedOn
,1 CreatedBy
into tempGLX_Line where 1=2
GO

-- -----------------------------
-- Create Temp Ledger Mapping Table
-- -----------------------------
PRINT '-----------------------------------'
PRINT 'Create Temp Ledger Mapping Table'
PRINT '-----------------------------------'
GO

select 
1 GLId
,1 HeaderId
,cast(null as nvarchar(50)) Reference
,cast(null as nvarchar(100)) Description
,cast(null as datetime) Date
,cast(null as nvarchar(100)) CreatedBy
,cast(null as datetime) CreatedOn
INTO tempGLJournalMapping where 1=2

GO


-- ------------------------------------------
-- MAP MonthEnds to Periods
-- ------------------------------------------

print 'MAP MonthEnds to Periods'
GO

select 
period.Id PeriodId
,period.StartDate
,period.EndDate
,CAST(null as datetime) MEGLDate
,CAST(null as datetime) MEDate
,CAST(null as datetime) MEINVDate
into tempMEDates 
from IMPORT_DB.[CDS_SYS].[SYS_Period] period

GO

update tempMEDates set MEGLDate=MEGL.dtDate
from tempMEDates 
inner join (select distinct dtdate from tblMonthEndLedger) MEGL on DATEADD(DAY,-15,MEGL.dtdate) between tempMEDates.StartDate and tempMEDates.EndDate

GO

update tempMEDates set MEDate=ME.dtDate
from tempMEDates 
inner join (select distinct dtdate from tblMonthEnd) ME on DATEADD(DAY,-15,ME.dtdate) between tempMEDates.StartDate and tempMEDates.EndDate

GO

update tempMEDates set MEINVDate=MEINV.dtDate
from tempMEDates 
inner join (select distinct dtdate from tblMonthEndInventory) MEINV on DATEADD(DAY,-15,MEINV.dtdate) between tempMEDates.StartDate and tempMEDates.EndDate

GO

USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO