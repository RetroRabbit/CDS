
USE EXPORT_DB
GO
SET ANSI_PADDING ON;
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
