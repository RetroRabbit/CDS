
USE EXPORT_DB
GO

-- ------------------------------------------
-- Import Document Heders
-- ------------------------------------------
PRINT '-----------------------------------'
print 'Import Document Headers'
PRINT '-----------------------------------'
GO

select ROW_NUMBER() OVER (ORDER BY exDoc.iDocumentId) DocId,
exDoc.iNameNumericPart DocNumber,
exDoc.pkDocumentGuid DocGuid
into tempDocNumber 
from tblDocument exDoc
GO


USE IMPORT_DB
GO
DISABLE TRIGGER [CDS_SYS].[SYS_DOC_Header_Number] ON [CDS_SYS].[SYS_DOC_Header]
GO

USE EXPORT_DB
GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] ON
INSERT INTO
  IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] WITH(TABLOCK) (Id,TrackId,TypeId,DocumentNumber,Comment,CreatedOn,CreatedBy)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
     'select 
tempDocNumber.DocId Id
,inTrack.Id TrackId
,inType.TypeId TypeId 
,tempDocNumber.DocNumber DocumentNumber
,exDoc.sComment Comment
,exDoc.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
from EXPORT_DB.dbo.tblDocument exDoc
inner join EXPORT_DB.dbo.tempDocNumber on tempDocNumber.DocGuid=exDoc.pkDocumentGuid
inner join EXPORT_DB.dbo.tempTrack inTrack on exDoc.pkDocumentGuid=inTrack.DocGuid
inner join EXPORT_DB.dbo.tempDocType inType on exDoc.fkDocumentTypeGuid=inType.TypeGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exDoc.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT') AS e;

--DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
----SET @bcpCommand = 'bcp "select tempMEINVId.id Id,inInv.Id InventoryId,MEINV.PeriodId PeriodId,0 Amount,0 Movement,isnull(exHIST.iTotalOnHand,0) OnHand,isnull(exHIST.iTotalOnJob,0) + isnull(exHIST.iTotalOnWIP,0) OnReserve,isnull(exHIST.iTotalOnOrder,0) OnOrder,isnull(exHIST.dUnitPrice,0) UnitPrice,isnull(exHIST.dUnitReplacementCost,0) UnitCost,isnull(exHIST.dUnitCost,0) UnitAverage,exInv.dtFirstMovement FirstSol,exHIST.dtFirstPurchased FirstPurchase,exHIST.dtLastSold LastSol,exHIST.dtLastPurchasedDate LastPurchased,exHIST.dtLastMovement LastMovement from EXPORT_DB.dbo.tblMonthEndInventory exHIST INNER JOIN EXPORT_DB.dbo.tempMEINVId on exHIST.iMonthEndInventoryId=tempMEINVId.MEInvId INNER JOIN EXPORT_DB.dbo.tempMEDates MEINV on exHIST.dtDate=MEINV.MEINVDate INNER JOIN EXPORT_DB.dbo.tblInventory exInv on exHIST.fkInventoryGuid=exInv.pkInventoryGuid inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inInvEntity on exInv.sNameAlphaPart=inInvEntity.Name and inInvEntity.TypeId=4 inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.Id=inInv.EntityId " queryout '
--SET @bcpCommand = 'bcp "SELECT tempDocNumber.DocId AS Id, inTrack.Id AS TrackId, inType.TypeId AS TypeId, tempDocNumber.DocNumber AS DocumentNumber, exDoc.sComment AS Comment, exDoc.dtCreatedOn AS CreatedOn, ISNULL(Creator.Id, 1) AS CreatedBy FROM EXPORT_DB.dbo.tblDocument AS exDoc INNER JOIN EXPORT_DB.dbo.tempDocNumber ON tempDocNumber.DocGuid = exDoc.pkDocumentGuid INNER JOIN EXPORT_DB.dbo.tempTrack AS inTrack ON exDoc.pkDocumentGuid = inTrack.DocGuid INNER JOIN EXPORT_DB.dbo.tempDocType AS inType ON exDoc.fkDocumentTypeGuid = inType.TypeGuid LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] AS Creator ON exDoc.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT;" queryout '
--SET @FilePath = 'BCPDIR\'
--SET @OutputFile = 'SYS_DOC_Header.dat'
--SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
--exec master..xp_cmdshell @bcpCommand

--delete IMPORT_DB.[CDS_SYS].[SYS_DOC_Header]

--BULK INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Header]
--FROM 'BCPDIR\SYS_DOC_Header.dat'
--WITH 
--      (
--         FIELDTERMINATOR =',',
--		 ROWTERMINATOR = '\n',
--		 KEEPIDENTITY 
--      );
--GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] OFF
GO
USE IMPORT_DB
GO

ENABLE TRIGGER [CDS_SYS].[SYS_DOC_Header_Number] ON [CDS_SYS].[SYS_DOC_Header]
GO
USE EXPORT_DB
GO

-- ------------------------------------------
-- Import Document lines
-- ------------------------------------------
PRINT '-----------------------------------'
print 'Import Document lines'
PRINT '-----------------------------------'
GO



IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tempInventory]') AND name = N'IX_tempDocLineMap')
BEGIN
    /****** Object:  Index [IX_tempDocLineMap]    Script Date: 2015/09/18 2:38:57 PM ******/
    CREATE NONCLUSTERED INDEX [IX_tempDocLineMap] ON [dbo].[tempInventory]
    (
	    [InventoryGuid] ASC
    )
    INCLUDE ( 	[InventoryId]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
END
GO
 
select 
ROW_NUMBER() OVER (ORDER BY exLine.iDocumentLineId) LineId
,exLine.pkDocumentLineGuid LineGuid
--,DENSE_RANK() OVER (PARTITION BY inHeader.TrackId, inHeader.Id ORDER BY exLine.dtcreatedon) LineOrder
,DENSE_RANK() OVER (PARTITION BY inHeader.TrackId  ORDER BY initem.InventoryId) LineOrder
,ISNULL(Cancel.Mutiplier,1) Mutiplier
into tempDocLineMap 
from tblDocumentLine exLine
inner join tblDocument exDoc on exLine.fkDocumentGuid=exDoc.pkDocumentGuid
inner join tempDocNumber on tempDocNumber.DocGuid=exDoc.pkDocumentGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] inHeader on inHeader.Id = tempDocNumber.DocId 
inner join tblInventory ExI on exLine.fkInventoryGuid=ExI.pkInventoryGuid
inner join tempInventory InItem on ExI.pkInventoryGuid=InItem.InventoryGuid
left join (select 1 Mutiplier union all select -1) Cancel on 1 = CASE exLine.fkStatusGuid WHEN '3142D822-9E01-4084-8C0A-0636ACCAAE62' then 1 else 0 end
where exLine.dQuantity <> 0

/****** Object:  Index [IX_tempDocLineMap]    Script Date: 2015/09/18 2:38:57 PM ******/
DROP INDEX [IX_tempDocLineMap] ON EXPORT_DB.[dbo].[tempInventory]
GO

PRINT '--------------------------------------------'
PRINT 'Dropping Indexes for Documentlines'
PRINT '--------------------------------------------'
GO

/****** Object:  Index [IDX_VW_Transaction_DOC_Header]    Script Date: 2015/09/18 8:54:21 AM ******/
DROP INDEX [IDX_VW_Transaction_DOC_Header] ON IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
GO 

/****** Object:  Index [IDX_VW_Transaction_Item]    Script Date: 2015/09/18 9:24:25 AM ******/
DROP INDEX [IDX_VW_Transaction_Item] ON IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
GO
 
SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Line] ON
--INSERT INTO
--  IMPORT_DB.[CDS_SYS].[SYS_DOC_Line] WITH(TABLOCK) (Id,HeaderId,ItemId,LineOrder,DiscountPercentage,DiscountAmount,Description,Quantity,Amount,Total,TotalTax,CreatedOn,CreatedBy)
--SELECT *
--FROM
--  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
--     'select 
--tempDocLineMap.LineId Id
--,inHeader.Id HeaderId
--,InItem.InventoryId ItemId
--,tempDocLineMap.LineOrder LineOrder
--,isnull(exLine.dDiscountPercentage,0) * 100 DiscountPercentage
--,exLine.dDiscountAmount DiscountAmount
--,LEFT(exLine.sDescription,50) Description
--,CASE tempDocLineMap.Mutiplier WHEN -1 THEN (exLine.dQuantity - exLine.dQuantity2)*tempDocLineMap.Mutiplier ELSE exLine.dQuantity END Quantity
--,exLine.dTotalAmountBeforeTax/exLine.dQuantity Amount
--,exLine.dTotalAmountBeforeTax Total
--,exLine.dTotalTax TotalTax
--,exLine.dtCreatedOn CreatedOn
--,isnull(Creator.Id,1) CreatedBy
--from tblDocumentLine exLine
--inner join tempDocLineMap on exLine.pkDocumentLineGuid=tempDocLineMap.LineGuid
--inner join tblDocument exDoc on exLine.fkDocumentGuid=exDoc.pkDocumentGuid
--inner join tempDocNumber on tempDocNumber.DocGuid=exDoc.pkDocumentGuid
--inner join IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] inHeader on inHeader.Id = tempDocNumber.DocId 
--inner join tblInventory ExI on exLine.fkInventoryGuid=ExI.pkInventoryGuid
--inner join tempInventory InItem on ExI.pkInventoryGuid=InItem.InventoryGuid 
--LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exLine.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT
--where exLine.dQuantity <> 0') AS e;

--DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
----SET @bcpCommand = 'bcp "select tempMEINVId.id Id,inInv.Id InventoryId,MEINV.PeriodId PeriodId,0 Amount,0 Movement,isnull(exHIST.iTotalOnHand,0) OnHand,isnull(exHIST.iTotalOnJob,0) + isnull(exHIST.iTotalOnWIP,0) OnReserve,isnull(exHIST.iTotalOnOrder,0) OnOrder,isnull(exHIST.dUnitPrice,0) UnitPrice,isnull(exHIST.dUnitReplacementCost,0) UnitCost,isnull(exHIST.dUnitCost,0) UnitAverage,exInv.dtFirstMovement FirstSol,exHIST.dtFirstPurchased FirstPurchase,exHIST.dtLastSold LastSol,exHIST.dtLastPurchasedDate LastPurchased,exHIST.dtLastMovement LastMovement from EXPORT_DB.dbo.tblMonthEndInventory exHIST INNER JOIN EXPORT_DB.dbo.tempMEINVId on exHIST.iMonthEndInventoryId=tempMEINVId.MEInvId INNER JOIN EXPORT_DB.dbo.tempMEDates MEINV on exHIST.dtDate=MEINV.MEINVDate INNER JOIN EXPORT_DB.dbo.tblInventory exInv on exHIST.fkInventoryGuid=exInv.pkInventoryGuid inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inInvEntity on exInv.sNameAlphaPart=inInvEntity.Name and inInvEntity.TypeId=4 inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.Id=inInv.EntityId " queryout '
--SET @bcpCommand = 'bcp "SELECT tempDocLineMap.LineId AS Id, inHeader.Id AS HeaderId, InItem.InventoryId AS ItemId, tempDocLineMap.LineOrder AS LineOrder, ISNULL(exLine.dDiscountPercentage, 0) * 100 AS DiscountPercentage, exLine.dDiscountAmount AS DiscountAmount, LEFT(exLine.sDescription, 50) AS Description, exLine.dQuantity AS Quantity, exLine.dTotalAmountBeforeTax / exLine.dQuantity AS Amount, exLine.dTotalAmountBeforeTax AS Total, exLine.dTotalTax AS TotalTax, exLine.dtCreatedOn AS CreatedOn, ISNULL(Creator.Id, 1) AS CreatedBy FROM tblDocumentLine AS exLine INNER JOIN tempDocLineMap ON exLine.pkDocumentLineGuid = tempDocLineMap.LineGuid INNER JOIN tblDocument AS exDoc ON exLine.fkDocumentGuid = exDoc.pkDocumentGuid INNER JOIN tempDocNumber ON tempDocNumber.DocGuid = exDoc.pkDocumentGuid INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] AS inHeader ON inHeader.Id = tempDocNumber.DocId INNER JOIN tblInventory AS ExI ON exLine.fkInventoryGuid = ExI.pkInventoryGuid INNER JOIN tempInventory AS InItem ON ExI.pkInventoryGuid = InItem.InventoryGuid LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] AS Creator ON exLine.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT WHERE exLine.dQuantity <> 0;" queryout '
--SET @FilePath = 'BCPDIR\'
--SET @OutputFile = 'SYS_DOC_Line.dat'
--SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
--exec master..xp_cmdshell @bcpCommand

--delete IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]

--BULK INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
--FROM 'BCPDIR\SYS_DOC_Line.dat'
--WITH 
--      (
--         FIELDTERMINATOR =',',
--		 ROWTERMINATOR = '\n',
--		 KEEPIDENTITY 
--      );
--GO

DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
SET @bcpCommand = 'bcp "select tempDocLineMap.LineId Id,inHeader.Id HeaderId,InItem.InventoryId ItemId,tempDocLineMap.LineOrder LineOrder,isnull(exLine.dDiscountPercentage,0) * 100 DiscountPercentage,exLine.dDiscountAmount DiscountAmount,LEFT(exLine.sDescription,50) Description,CASE tempDocLineMap.Mutiplier WHEN -1 THEN (exLine.dQuantity - exLine.dQuantity2)*tempDocLineMap.Mutiplier ELSE exLine.dQuantity END Quantity,exLine.dTotalAmountBeforeTax/exLine.dQuantity Amount,exLine.dTotalAmountBeforeTax Total,exLine.dTotalTax TotalTax,exLine.dtCreatedOn CreatedOn,isnull(Creator.Id,1) CreatedBy from EXPORT_DB..tblDocumentLine exLine inner join EXPORT_DB..tempDocLineMap on exLine.pkDocumentLineGuid=tempDocLineMap.LineGuid inner join EXPORT_DB..tblDocument exDoc on exLine.fkDocumentGuid=exDoc.pkDocumentGuid inner join EXPORT_DB..tempDocNumber on tempDocNumber.DocGuid=exDoc.pkDocumentGuid inner join IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] inHeader on inHeader.Id = tempDocNumber.DocId inner join EXPORT_DB..tblInventory ExI on exLine.fkInventoryGuid=ExI.pkInventoryGuid inner join EXPORT_DB..tempInventory InItem on ExI.pkInventoryGuid=InItem.InventoryGuid LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exLine.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT where exLine.dQuantity <> 0" queryout '
SET @FilePath = 'BCPDIR\'
SET @OutputFile = 'SYS_DOC_Line.dat'
SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t"$$" -T -S'+ @@servername
exec master..xp_cmdshell @bcpCommand

delete IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]

BULK INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
FROM 'BCPDIR\SYS_DOC_Line.dat'
WITH 
      (
         FIELDTERMINATOR ='$$',
		 ROWTERMINATOR = '\n',
		 KEEPIDENTITY
		 
      );
GO
 

SET IDENTITY_INSERT IMPORT_DB.[CDS_SYS].[SYS_DOC_Line] OFF
GO


 -- ------------------------------------------
-- Split Address over lines
-- ------------------------------------------
PRINT '-----------------------------------'
print 'Split Address over lines'
PRINT '-----------------------------------'
GO


IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddress'))
	DROP TABLE EXPORT_DB.dbo.tempDocAddress
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddressCleanup'))
	DROP TABLE EXPORT_DB.dbo.tempDocAddressCleanup

SELECT 
pkDocumentGuid
,CONVERT(XML,'<Address><Billing>' + REPLACE(REPLACE( REPLACE( REPLACE(REPLACE(REPLACE(ISNULL(sBillingAddress,''),'&','&amp;'),'<','&lt;'),'>','&gt;'),'"','&quot;'),'''','&#39;'),CHAR(13), '</Billing><Billing>') + '</Billing><Shipping>' + REPLACE(REPLACE( REPLACE( REPLACE(REPLACE(REPLACE(ISNULL(sShippingAddress,''),'&','&amp;'),'<','&lt;'),'>','&gt;'),'"','&quot;'),'''','&#39;'),CHAR(13), '</Shipping><Shipping>')+'</Shipping></Address>') AS xmlData
INTO EXPORT_DB..tempDocAddressCleanup 
FROM EXPORT_DB..tblDocument
WHERE sBillingAddress is not null and sShippingAddress is not null and sBillingAddress <> '' and sShippingAddress <> '' and CHARINDEX(char(0),sBillingAddress) = 0 and  CHARINDEX(char(0),sShippingAddress) = 0 
GO

SELECT pkDocumentGuid DocumentGuid,BillingLine1,BillingLine2,BillingLine3,BillingLine4,ShippingLine1,ShippingLine2,ShippingLine3,ShippingLine4 into EXPORT_DB..tempDocAddress from (
	SELECT   pkDocumentGuid, 
	 xmlData.value('/Address[1]/Billing[1]','nvarchar(100)') AS BillingLine1,    
	 xmlData.value('/Address[1]/Billing[2]','nvarchar(100)') AS BillingLine2,
	 xmlData.value('/Address[1]/Billing[3]','nvarchar(100)') AS BillingLine3,
	 xmlData.value('/Address[1]/Billing[4]','nvarchar(100)') AS BillingLine4,
	 xmlData.value('/Address[1]/Shipping[1]','nvarchar(100)')  AS ShippingLine1,    
	 xmlData.value('/Address[1]/Shipping[2]','nvarchar(100)')  AS ShippingLine2,
	 xmlData.value('/Address[1]/Shipping[3]','nvarchar(100)')  AS ShippingLine3,
	 xmlData.value('/Address[1]/Shipping[4]','nvarchar(100)')  AS ShippingLine4
	 FROM 
	 (
		SELECT pkDocumentGuid,xmlData
		FROM EXPORT_DB..tempDocAddressCleanup 
	 ) X
 ) Y

 GO

-- ------------------------------------------
-- Import Document Company Headers
-- ------------------------------------------
PRINT '-----------------------------------'
print 'Import Document Company Headers'
PRINT '-----------------------------------'
GO

SET IDENTITY_INSERT IMPORT_DB.[CDS_ORG].[ORG_TRX_Header] ON
INSERT INTO
  IMPORT_DB.[CDS_ORG].[ORG_TRX_Header] WITH(TABLOCK) (Id, HeaderId,ShippingTypeId,CompanyId,DatePosted,DateFirstPrinted,DateLastPrinted,FirstPrintedBy,LastPrintedBy,DateValid,ReferenceShort1,ReferenceShort2,ReferenceShort3,ReferenceShort4
  ,ReferenceShort5,ReferenceLong1,ReferenceLong2,ReferenceLong3,ReferenceLong4,ReferenceLong5,Rounding,ContactPerson,ContactTelephone,Telephone,VatNumber,ShippingAddressLine1,ShippingAddressLine2,ShippingAddressLine3,ShippingAddressLine4
  ,ShippingAddressCode,BillingAddressLine1,BillingAddressLine2,BillingAddressLine3,BillingAddressLine4,BillingAddressCode,TotalCash,TotalCredit,TotalAccount,CreatedOn,CreatedBy)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
     'select 
ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) Id
,inHeader.Id HeaderId
,1 ShippingTypeId
,inComp.Id CompanyId
,exDoc.dtFinancialDate DatePosted
,exDoc.dtPrintedOn DateFirstPrinted
,exDoc.dtPrintedOn DateLastPrinted
,1 FirstPrintedBy
,1 LastPrintedBy
,exDoc.dtEndDate DateValid
,LEFT(LTRIM(exDoc.sSalesmanCode) ,20) ReferenceShort1
,LEFT(LTRIM(exDoc.sRepCode) ,20) ReferenceShort2
,LEFT(LTRIM(exDoc.sOrderNumber) ,20) ReferenceShort3
,null ReferenceShort4
,null ReferenceShort5
,LEFT(LTRIM(exDoc.sReferenceOurs), 100) ReferenceLong1
,LEFT(LTRIM(exDoc.sReferenceYours), 100) ReferenceLong2
,LEFT(LTRIM(exDoc.iNameNumericPart), 100) ReferenceLong3
,null ReferenceLong4
,null ReferenceLong5
,0.00 Rounding
,LEFT(LTRIM(exDoc.sContact),50) ContactPerson
,LEFT(LTRIM(exDoc.sTelephone),50) ContactTelephone
,LEFT(LTRIM(exDoc.sTelephone),50) Telephone
,LEFT(LTRIM(exDoc.sVatNumber),50) VatNumber
,tempDocAddress.ShippingLine1 ShippingAddressLine1
,tempDocAddress.ShippingLine2 ShippingAddressLine2
,tempDocAddress.ShippingLine3 ShippingAddressLine3
,tempDocAddress.ShippingLine4 ShippingAddressLine4
,'''' ShippingAddressCode
,tempDocAddress.BillingLine1 BillingAddressLine1
,tempDocAddress.BillingLine2 BillingAddressLine2
,tempDocAddress.BillingLine3 BillingAddressLine3
,tempDocAddress.BillingLine4 BillingAddressLine4
,'''' BillingAddressCode
,exDoc.dtotalcash TotalCash
,exDoc.dtotalcredit TotalCredit
,null TotalAccount
,exDoc.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
from EXPORT_DB.dbo.tblDocument exDoc
inner join EXPORT_DB.dbo.tempDocType docType on exDoc.fkDocumentTypeGuid=docType.TypeGuid
inner join EXPORT_DB.dbo.tempDocNumber on tempDocNumber.DocGuid=exDoc.pkDocumentGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_DOC_Header] inHeader on inHeader.Id = tempDocNumber.DocId 
inner join EXPORT_DB.dbo.tempCompany on exDoc.fkCompanyGuid=tempCompany.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on tempCompany.CompanyId=inEntity.Id
inner join IMPORT_DB.[CDS_ORG].[ORG_Entity] inORGEntity on inEntity.Id=inORGEntity.EntityId
inner join IMPORT_DB.[CDS_ORG].[ORG_Company] inComp on inORGEntity.Id=inComp.EntityId
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exDoc.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + '' '' + Creator.Surname COLLATE DATABASE_DEFAULT
LEFT JOIN tempDocAddress ON exDoc.pkDocumentGuid = tempDocAddress.DocumentGuid') AS e;

SET IDENTITY_INSERT IMPORT_DB.[CDS_ORG].[ORG_TRX_Header] OFF
GO
	

-- ------------------------------------------
-- Import Inventory Movment
-- ------------------------------------------
PRINT '-----------------------------------'
print 'Import Inventory Movment'
PRINT '-----------------------------------'
GO

--TODO: Create scritp to update ONORDER, UnitCost etc 

INSERT INTO IMPORT_DB.[CDS_ITM].[ITM_Movement] (LineId,OnHand,OnHold,OnOrder,OnReserve,UnitCost,UnitPrice,UnitAverage,NewUnitCost,NewUnitPrice,NewUnitAverage,CreatedOn,CreatedBy)
SELECT
inLine.Id LineId
,exMove.iTotalOnHand + ((-1*Modif.iStockModifier)*exLine.dQuantity) OnHand
,exMove.iTotalOnHold OnHold
,exMove.iTotalOnOrder OnOrder
,exMove.iTotalOnJob + exMove.iTotalOnWIP OnReserve
,exLine.dUnitCost UnitCost
,CASE WHEN Modif.sName in ('TAX Invoice','Sales Credit Note') AND exLine.dDiscountPercentage <> 0 AND exLine.dDiscountPercentage <> 1.00 THEN exLine.dUnitPrice/(100-(exLine.dDiscountPercentage*100))*100  ELSE exLine.dUnitPrice END UnitPrice
,COALESCE(exAdj.dOldCost,exLine.dUnitCost) UnitAverage
,exLine.dUnitCost NewUnitCost
,CASE WHEN Modif.sName in ('TAX Invoice','Sales Credit Note') AND exLine.dDiscountPercentage <> 0 AND exLine.dDiscountPercentage <> 1.00 THEN exLine.dUnitPrice/(100-(exLine.dDiscountPercentage*100))*100  ELSE exLine.dUnitPrice END  NewUnitPrice
,COALESCE(exAdj.dNewCost,exLine.dUnitCost) NewUnitAverage
, exMove.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM tblInventoryMovement exMove
INNER JOIN tblInventory exInv on exMove.fkInventoryItemGuid=exInv.pkInventoryGuid
LEFT JOIN tblInventoryAdjustment exAdj on exMove.fkDocumentLineGuid=exAdj.fkDocumentLineGuid and sCostColumn='dUnitCost' 
INNER JOIN tblDocumentLine exLine on exMove.fkDocumentLineGuid=exLine.pkDocumentLineGuid
INNER JOIN tlDocumentType Modif on exLine.fkDocumentTypeGuid=Modif.pkDocumentTypeGuid
INNER JOIN tblInventory ExI on exLine.fkInventoryGuid=ExI.pkInventoryGuid
INNER JOIN tempDocLineMap on tempDocLineMap.LineGuid=exLine.pkDocumentLineGuid
INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_DOC_Line] inLine on tempDocLineMap.LineId=inLine.Id 
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exMove.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where exLine.dQuantity<>0 and exLine.sCreatedBy<>'Data  Import' and exLine.fkStatusGuid<>'3142D822-9E01-4084-8C0A-0636ACCAAE62'

GO
/*
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddress'))
	DROP TABLE EXPORT_DB.dbo.tempDocAddress
IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempDocAddressCleanup'))
	DROP TABLE EXPORT_DB.dbo.tempDocAddressCleanup
	*/
USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO