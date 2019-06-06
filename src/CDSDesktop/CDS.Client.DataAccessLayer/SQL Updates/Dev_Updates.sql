
ALTER VIEW [dbo].[VW_Transaction]
AS
SELECT
--ROW_NUMBER() OVER(ORDER BY dbo.SYS_DOC_Line.Id DESC) AS Id
dbo.SYS_DOC_Line.Id --I want to use this but the Entity Framework can resolve the PK for some reason
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.Id AS DocumentId
, ITM_Item.Id ItemId
, dbo.ITM_Inventory.Id InventoryId
, VW_Company.Id CompanyId
, VW_Company.TypeId CompanyTypeId
, dbo.SYS_DOC_Type.Name AS DocumentType
, dbo.SYS_DOC_Header.DocumentNumber
, COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS DatePosted
, VW_Site.Name AS SiteName
, VW_Company.Name AS CompanyName
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.HoldingModifier AS QuantityHolding
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.BalanceModifier AS QuantityBalance
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.StockModifier AS QuantityStock
, dbo.ITM_Movement.OnHand
, dbo.ITM_Movement.OnReserve
, dbo.ITM_Movement.OnOrder
, dbo.SYS_DOC_Line.Amount
, dbo.SYS_DOC_Line.Discount
, dbo.ITM_Movement.UnitPrice
, dbo.ITM_Movement.UnitCost
, dbo.ITM_Movement.UnitAverage
, dbo.SYS_DOC_Line.Total
, dbo.SYS_DOC_Line.CreatedOn
, dbo.SEC_User.DisplayName CreatedBy
, dbo.SYS_DOC_Header.CreatedBy CreatedById
, VW_Company.AreaCode AS AreaCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong1	,dbo.JOB_Header.ReferenceLong1		) AS YourReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong2	,dbo.JOB_Header.ReferenceLong2		) AS OurReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong3	,dbo.JOB_Header.ReferenceLong3		) AS ReferenceLong3
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong4	,dbo.JOB_Header.ReferenceLong4		) AS ReferenceLong4
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong5	,dbo.JOB_Header.ReferenceLong5		) AS ReferenceLong5
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort1	,dbo.JOB_Header.ReferenceShort1		) AS OrderNumber
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort2	,dbo.JOB_Header.ReferenceShort2		) AS RepCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort3	,dbo.JOB_Header.ReferenceShort3		) AS SalesManCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort4	,dbo.JOB_Header.ReferenceShort4		) AS ReferenceShort4
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort5	,dbo.JOB_Header.ReferenceShort5		) AS ReferenceShort5
, COALESCE(dbo.ORG_TRX_Header.DateFirstPrinted	,dbo.JOB_Header.DateFirstPrinted	) AS DateFirstPrinted
, COALESCE(dbo.ORG_TRX_Header.DateLastPrinted	,dbo.JOB_Header.DateLastPrinted		) AS DateLastPrinted
, COALESCE(dbo.ORG_TRX_Header.DateValid			,NULL								) AS DateValid
, COALESCE(dbo.ORG_TRX_Header.TotalCash			,0.00								) AS TotalCash
, COALESCE(dbo.ORG_TRX_Header.TotalCredit		,0.00								) AS TotalCredit
, COALESCE(dbo.ORG_TRX_Header.TotalAccount		,0.00								) AS TotalAccount
, COALESCE(dbo.ORG_TRX_Header.Rounding			,0.00								) AS Rounding

FROM
dbo.SYS_DOC_Line
INNER JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id
INNER JOIN dbo.SYS_Entity AS ITM_Item ON dbo.SYS_DOC_Line.ItemId = ITM_Item.Id
INNER JOIN dbo.VW_Site ON dbo.SYS_DOC_Header.SiteId = VW_Site.Id
INNER JOIN dbo.ITM_Inventory ON ITM_Item.Id = dbo.ITM_Inventory.EntityId AND dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id
INNER JOIN dbo.SYS_Person on dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SEC_User ON dbo.SYS_Person.Id = dbo.SEC_User.PersonId
LEFT JOIN dbo.ITM_Movement ON dbo.SYS_DOC_Line.Id = dbo.ITM_Movement.LineId
LEFT JOIN dbo.ORG_TRX_Header ON dbo.SYS_DOC_Header.Id = dbo.ORG_TRX_Header.HeaderId
LEFT JOIN dbo.JOB_Header ON dbo.SYS_DOC_Header.Id = dbo.JOB_Header.HeaderId
LEFT JOIN dbo.VW_Company ON COALESCE(dbo.ORG_TRX_Header.CompanyId,dbo.JOB_Header.CompanyId) = dbo.VW_Company.Id

GO

ALTER VIEW [dbo].[VW_TransactionPurchases]
AS
SELECT     dbo.VW_Transaction.Id, dbo.VW_Transaction.TypeId, dbo.VW_Transaction.DocumentId, dbo.VW_Transaction.ItemId, dbo.VW_Transaction.InventoryId,
dbo.VW_Transaction.CompanyId, dbo.VW_Transaction.CompanyTypeId, dbo.VW_Transaction.DocumentType, dbo.VW_Transaction.DocumentNumber,
dbo.VW_Transaction.DatePosted AS Date, dbo.VW_Transaction.SiteName, dbo.VW_Transaction.CompanyName, dbo.VW_Transaction.QuantityHolding,
dbo.VW_Transaction.QuantityBalance, dbo.VW_Transaction.QuantityStock, dbo.VW_Transaction.OnHand, dbo.VW_Transaction.OnReserve,
dbo.VW_Transaction.OnOrder, dbo.VW_Transaction.Amount, dbo.VW_Transaction.Discount, dbo.VW_Transaction.UnitPrice, dbo.VW_Transaction.UnitCost,
dbo.VW_Transaction.UnitAverage, dbo.VW_Transaction.Total, dbo.VW_Transaction.CreatedOn, dbo.VW_Transaction.CreatedBy, dbo.VW_Transaction.CreatedById,
dbo.VW_Transaction.AreaCode, dbo.VW_Transaction.YourReference, dbo.VW_Transaction.OurReference, dbo.VW_Transaction.ReferenceLong3,
dbo.VW_Transaction.ReferenceLong4, dbo.VW_Transaction.ReferenceLong5, dbo.VW_Transaction.OrderNumber, dbo.VW_Transaction.RepCode,
dbo.VW_Transaction.SalesManCode, dbo.VW_Transaction.ReferenceShort4, dbo.VW_Transaction.ReferenceShort5, dbo.VW_Transaction.DateFirstPrinted,
dbo.VW_Transaction.DateLastPrinted, dbo.VW_Transaction.DateValid, dbo.VW_Transaction.TotalCash, dbo.VW_Transaction.TotalCredit,
dbo.VW_Transaction.TotalAccount, dbo.VW_Transaction.Rounding, dbo.SYS_Period.Code AS FinancialPeriod, dbo.SYS_Period.FinancialYear,
dbo.SYS_Period.FinancialQuarter
FROM         dbo.VW_Transaction INNER JOIN
dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
dbo.SYS_Period ON dbo.VW_Transaction.DatePosted BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate
WHERE     (dbo.SYS_DOC_Type.Name IN ('Goods Received', 'Goods Returned'))

GO

ALTER VIEW [dbo].[VW_TransactionSales]
AS
SELECT     dbo.VW_Transaction.Id, dbo.VW_Transaction.TypeId, dbo.VW_Transaction.DocumentId, dbo.VW_Transaction.ItemId, dbo.VW_Transaction.InventoryId,
dbo.VW_Transaction.CompanyId, dbo.VW_Transaction.CompanyTypeId, dbo.VW_Transaction.DocumentType, dbo.VW_Transaction.DocumentNumber,
dbo.VW_Transaction.DatePosted AS Date, dbo.VW_Transaction.SiteName, dbo.VW_Transaction.CompanyName, dbo.VW_Transaction.QuantityHolding,
dbo.VW_Transaction.QuantityBalance, dbo.VW_Transaction.QuantityStock, dbo.VW_Transaction.OnHand, dbo.VW_Transaction.OnReserve,
dbo.VW_Transaction.OnOrder, dbo.VW_Transaction.Amount, dbo.VW_Transaction.Discount, dbo.VW_Transaction.UnitPrice, dbo.VW_Transaction.UnitCost,
dbo.VW_Transaction.UnitAverage, dbo.VW_Transaction.Total, dbo.VW_Transaction.CreatedOn, dbo.VW_Transaction.CreatedBy, dbo.VW_Transaction.CreatedById,
dbo.VW_Transaction.AreaCode, dbo.VW_Transaction.YourReference, dbo.VW_Transaction.OurReference, dbo.VW_Transaction.ReferenceLong3,
dbo.VW_Transaction.ReferenceLong4, dbo.VW_Transaction.ReferenceLong5, dbo.VW_Transaction.OrderNumber, dbo.VW_Transaction.RepCode,
dbo.VW_Transaction.SalesManCode, dbo.VW_Transaction.ReferenceShort4, dbo.VW_Transaction.ReferenceShort5, dbo.VW_Transaction.DateFirstPrinted,
dbo.VW_Transaction.DateLastPrinted, dbo.VW_Transaction.DateValid, dbo.VW_Transaction.TotalCash, dbo.VW_Transaction.TotalCredit,
dbo.VW_Transaction.TotalAccount, dbo.VW_Transaction.Rounding, dbo.SYS_Period.Code AS FinancialPeriod, dbo.SYS_Period.FinancialYear,
dbo.SYS_Period.FinancialQuarter
FROM         dbo.VW_Transaction INNER JOIN
dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
dbo.SYS_Period ON dbo.VW_Transaction.DatePosted BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate
WHERE     (dbo.SYS_DOC_Type.Name IN ('TAX Invoice', 'Credit Note'))

GO

update SEC_Access set Code = 'SADOPS', ParentId = 12, Name = 'Picking Slip', Description = 'Picking Slip' where Id = 125
update SEC_Access set Code = 'SADOPS01', ParentId = 125 where Id = 182
update SEC_Access set Code = 'SADOPS02', ParentId = 125 where Id = 183

GO

IF NOT EXISTS(SELECT * from SEC_Access WHERE Id = 265)
BEGIN
INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
VALUES
(265,'SADOJQ','Job Quote','Job Quote',12,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END

IF NOT EXISTS(SELECT * from SEC_Access WHERE Id = 266)
BEGIN
INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
VALUES
(266,'SADOJQ01','Read','Read',265,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END

IF NOT EXISTS(SELECT * from SEC_Access WHERE Id = 267)
BEGIN
INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
VALUES
(267,'SADOJQ02','Write','Write',265,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END

GO

DELETE SEC_RoleAccess WHERE AccessId in (197,198,205,206,214,215,237,238)
DELETE SEC_Access WHERE Id in (197,198,205,206,214,215,237,238)
GO

UPDATE SEC_Access SET Code = REPLACE(Code,'SADOSI','SADOTI') WHERE Code LIKE 'SADOSI%'
UPDATE SEC_Access SET Name = 'TAX Invoice',Description = 'TAX Invoice' WHERE Id = 132
GO

IF NOT EXISTS (SELECT * FROM SEC_Access WHERE Id = 268)
BEGIN
	INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
			   ([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
		 VALUES
			   (268,'SYSERL','Roles','Roles',49,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END
GO
IF NOT EXISTS (SELECT * FROM SEC_Access WHERE Id = 269)
BEGIN
	INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
			   ([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
		 VALUES
			   (269,'SYSEUR','Users','Users',49,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END
GO

UPDATE SEC_Access set Code = 'SYSERL01',ParentId = 268,Name = 'Read' ,Description = 'Read' where Id = 141 --Read Roles
UPDATE SEC_Access set Code = 'SYSERL02',ParentId = 268,Name = 'Write',Description = 'Write' where Id = 143 --Write Roles
UPDATE SEC_Access set Code = 'SYSEUR01',ParentId = 269,Name = 'Read' ,Description = 'Read' where Id = 142 --Read Users
UPDATE SEC_Access set Code = 'SYSEUR02',ParentId = 269,Name = 'Write',Description = 'Write' where Id = 144 --Write Users
GO

DELETE SEC_RoleAccess where AccessId in (53,149,150)
DELETE SEC_Access where Id in (53,149,150)
GO

IF NOT EXISTS (SELECT * FROM SEC_Access WHERE Id = 270)
BEGIN
	INSERT INTO [cds_pegasus].[dbo].[SEC_Access]
			   ([Id],[Code],[Name],[Description],[ParentId],[CustomValue1],[CustomValue2],[CustomValue3],[CreatedOn],[CreatedBy],[ModifiedOn],[ModifiedBy])
		 VALUES
			   (270,'PUDOGR05','Update Unit Cost','Updates the Unit Cost',123,NULL,NULL,NULL,GETDATE(),1,NULL,NULL)
END
GO


IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'ReferenceId' AND [object_id] = OBJECT_ID(N'GLX_Header'))
BEGIN
	ALTER TABLE GLX_Header ADD ReferenceId bigint NULL;
END

GO

ALTER VIEW [dbo].[VW_Header]

AS 

SELECT
H.Id  
, H.JournalTypeId
, JT.Name AS JournalType
, H.Reference AS Reference
, ISNULL(H.Description, '') AS Description
, H.Date AS Date
, CAST(H.Date AS DATE) AS HeaderDay
, H.TrackId
, H.CreatedOn AS CreatedOn
, PN.Fullname AS CreatedBy
, S.Name AS StatusCode
, P.Code AS PeriodCode
, H.ReferenceId
FROM 
dbo.GLX_Header AS H 
INNER JOIN dbo.SYS_Period AS P ON H.PeriodId = P.Id 
INNER JOIN dbo.SYS_Person AS PN ON H.CreatedBy = PN.Id 
LEFT JOIN dbo.GLX_JournalType AS JT ON H.JournalTypeId=JT.Id
LEFT OUTER JOIN dbo.SYS_Status AS S ON H.StatusId = S.Id 

GO

DELETE SEC_RoleAccess WHERE AccessId = 223
DELETE SEC_Access WHERE Id = 223
GO 

/****** Object:  View [dbo].[VW_Attachment]    Script Date: 12/08/2014 16:51:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Attachment]
AS
SELECT     dbo.SYS_DOC_Header.Id, dbo.CAL_Attachment.Id AS CalendarId, dbo.CAL_Attachment.DocumentId, dbo.SYS_DOC_Header.TypeId, dbo.SYS_DOC_Header.DocumentNumber, 
					  dbo.CAL_Calendar.StartDate, dbo.SYS_DOC_Type.Name, dbo.CAL_Calendar.Description, SUM(dbo.SYS_DOC_Line.Total) AS Total,
					  dbo.SYS_Person.FullName as CreatedBy, dbo.CAL_Attachment.CreatedOn
FROM         dbo.SYS_DOC_Type INNER JOIN
					  dbo.SYS_DOC_Header INNER JOIN
					  dbo.CAL_Attachment INNER JOIN
					  dbo.CAL_Calendar ON dbo.CAL_Attachment.CalendarId = dbo.CAL_Calendar.Id ON dbo.SYS_DOC_Header.Id = dbo.CAL_Attachment.DocumentId INNER JOIN
					  dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId ON dbo.SYS_DOC_Type.Id = dbo.SYS_DOC_Header.TypeId INNER JOIN
					  dbo.SYS_Person ON dbo.CAL_Attachment.CreatedBy = dbo.SYS_Person.Id
GROUP BY dbo.SYS_DOC_Header.Id, dbo.SYS_DOC_Header.DocumentNumber, dbo.CAL_Attachment.DocumentId, dbo.CAL_Calendar.StartDate, dbo.SYS_DOC_Type.Name, dbo.CAL_Calendar.Description, 
					  dbo.CAL_Attachment.Id, dbo.SYS_DOC_Header.TypeId,dbo.SYS_Person.FullName, dbo.CAL_Attachment.CreatedOn

GO
USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_LineItem]    Script Date: 12/09/2014 10:29:37 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Entity]'))
DROP VIEW [dbo].[VW_Entity]
GO

/****** Object:  View [dbo].[VW_LineItem]    Script Date: 12/09/2014 10:29:37 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_LineItem]'))
DROP VIEW [dbo].[VW_LineItem]
GO


USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_LineItem]    Script Date: 12/09/2014 10:29:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_LineItem]
AS
SELECT 
dbo.SYS_Entity.Id AS Id
, dbo.ITM_Inventory.Id AS InventoryId
, dbo.GLX_Account.Id AS AccountId
, dbo.GLX_Account.AccountTypeId AS AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Type.Name AS Type
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS CreatedOn
, dbo.SYS_Person.CreatedBy AS CreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial
--, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
--, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(dbo.ITM_History.OnHand, 0) AS OnHand
, ISNULL(dbo.ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(dbo.ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(dbo.ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(dbo.ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(dbo.ITM_History.UnitAverage, 0) AS UnitAverage
, SUM(ISNULL(dbo.GLX_History.Amount, 0)) AS BalanceAmount
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
--, dbo.SYS_Entity.CodeMain + '	' + ISNULL(SYS_Entity.Name, '') AS Title
, dbo.SYS_Entity.Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.SYS_Person ON  dbo.SYS_Entity.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SYS_Type ON dbo.SYS_Entity.TypeId = dbo.SYS_Type.Id
LEFT JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
LEFT JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
LEFT JOIN dbo.ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId and ITM_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
LEFT JOIN dbo.GLX_Account ON dbo.SYS_Entity.Id = dbo.GLX_Account.EntityId 
LEFT JOIN dbo.GLX_History WITH (nolock) ON dbo.GLX_Account.EntityId = GLX_History.EntityId and GLX_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
--LEFT JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and dbo.ITM_InventorySupplier.PrimarySupplier = 1
WHERE SYS_Entity.TypeId in (4,5,6,7)
GROUP BY 
dbo.SYS_Entity.Id  
, dbo.ITM_Inventory.Id  
, dbo.GLX_Account.Id  
, dbo.GLX_Account.AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id  
, dbo.SYS_Type.Name
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn 
, dbo.SYS_Person.CreatedBy  
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial 
, ISNULL(dbo.ITM_History.OnHand, 0)  
, ISNULL(dbo.ITM_History.OnReserve, 0) 
, ISNULL(dbo.ITM_History.OnOrder, 0) 
, ISNULL(dbo.ITM_History.UnitPrice, 0) 
, ISNULL(dbo.ITM_History.UnitCost, 0)  
, ISNULL(dbo.ITM_History.UnitAverage, 0)
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name  
, dbo.SYS_Entity.Title
GO

CREATE VIEW [dbo].[VW_Entity]
AS
SELECT 
dbo.SYS_Entity.Id AS Id
, dbo.ITM_Inventory.Id AS InventoryId
, dbo.GLX_Account.Id AS AccountId
, dbo.GLX_Account.AccountTypeId AS AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Type.Name AS Type
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS CreatedOn
, dbo.SYS_Person.CreatedBy AS CreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial
--, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
--, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(dbo.ITM_History.OnHand, 0) AS OnHand
, ISNULL(dbo.ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(dbo.ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(dbo.ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(dbo.ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(dbo.ITM_History.UnitAverage, 0) AS UnitAverage
, SUM(ISNULL(dbo.GLX_History.Amount, 0)) AS BalanceAmount
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
--, dbo.SYS_Entity.CodeMain + '	' + ISNULL(SYS_Entity.Name, '') AS Title
, dbo.SYS_Entity.Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.SYS_Person ON  dbo.SYS_Entity.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SYS_Type ON dbo.SYS_Entity.TypeId = dbo.SYS_Type.Id
LEFT JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
LEFT JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
LEFT JOIN dbo.ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId and ITM_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
LEFT JOIN dbo.GLX_Account ON dbo.SYS_Entity.Id = dbo.GLX_Account.EntityId 
LEFT JOIN dbo.GLX_History WITH (nolock) ON dbo.GLX_Account.EntityId = GLX_History.EntityId and GLX_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
--LEFT JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and dbo.ITM_InventorySupplier.PrimarySupplier = 1
--WHERE SYS_Entity.TypeId in (4,5,6,7)
GROUP BY 
dbo.SYS_Entity.Id  
, dbo.ITM_Inventory.Id  
, dbo.GLX_Account.Id  
, dbo.GLX_Account.AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id  
, dbo.SYS_Type.Name
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn 
, dbo.SYS_Person.CreatedBy  
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial 
, ISNULL(dbo.ITM_History.OnHand, 0)  
, ISNULL(dbo.ITM_History.OnReserve, 0) 
, ISNULL(dbo.ITM_History.OnOrder, 0) 
, ISNULL(dbo.ITM_History.UnitPrice, 0) 
, ISNULL(dbo.ITM_History.UnitCost, 0)  
, ISNULL(dbo.ITM_History.UnitAverage, 0)
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name  
, dbo.SYS_Entity.Title
GO
USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_Entity]    Script Date: 12/09/2014 11:06:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[VW_Entity]
AS
SELECT 
dbo.SYS_Entity.Id AS Id
, dbo.ITM_Inventory.Id AS InventoryId
, dbo.GLX_Account.Id AS AccountId
, dbo.GLX_Account.AccountTypeId AS AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Type.Name AS Type
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS CreatedOn
, dbo.SYS_Person.CreatedBy AS CreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial
--, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
--, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(dbo.ITM_History.OnHand, 0) AS OnHand
, ISNULL(dbo.ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(dbo.ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(dbo.ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(dbo.ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(dbo.ITM_History.UnitAverage, 0) AS UnitAverage
, SUM(ISNULL(dbo.GLX_History.Amount, 0)) AS BalanceAmount
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
--, dbo.SYS_Entity.CodeMain + '	' + ISNULL(SYS_Entity.Name, '') AS Title
, dbo.SYS_Entity.Title
, ISNULL((SELECT CONVERT(BIT,ISNULL(COUNT(1),0)) FROM dbo.ORG_Company INNER JOIN dbo.ORG_Entity ON dbo.ORG_Company.EntityId = dbo.ORG_Entity.Id AND TypeId = 1 WHERE dbo.ORG_Entity.EntityId = SYS_Entity.Id ) ,0) HasCustomer
, ISNULL((SELECT CONVERT(BIT,ISNULL(COUNT(1),0)) FROM dbo.ORG_Company INNER JOIN dbo.ORG_Entity ON dbo.ORG_Company.EntityId = dbo.ORG_Entity.Id AND TypeId = 2 WHERE dbo.ORG_Entity.EntityId = SYS_Entity.Id ) ,0) HasSupplier
FROM dbo.SYS_Entity 
INNER JOIN dbo.SYS_Person ON  dbo.SYS_Entity.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SYS_Type ON dbo.SYS_Entity.TypeId = dbo.SYS_Type.Id
LEFT JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
LEFT JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
LEFT JOIN dbo.ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId and ITM_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
LEFT JOIN dbo.GLX_Account ON dbo.SYS_Entity.Id = dbo.GLX_Account.EntityId 
LEFT JOIN dbo.GLX_History WITH (nolock) ON dbo.GLX_Account.EntityId = GLX_History.EntityId and GLX_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
--LEFT JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and dbo.ITM_InventorySupplier.PrimarySupplier = 1
--WHERE SYS_Entity.TypeId in (4,5,6,7)
GROUP BY 
dbo.SYS_Entity.Id  
, dbo.ITM_Inventory.Id  
, dbo.GLX_Account.Id  
, dbo.GLX_Account.AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id  
, dbo.SYS_Type.Name
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn 
, dbo.SYS_Person.CreatedBy  
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial 
, ISNULL(dbo.ITM_History.OnHand, 0)  
, ISNULL(dbo.ITM_History.OnReserve, 0) 
, ISNULL(dbo.ITM_History.OnOrder, 0) 
, ISNULL(dbo.ITM_History.UnitPrice, 0) 
, ISNULL(dbo.ITM_History.UnitCost, 0)  
, ISNULL(dbo.ITM_History.UnitAverage, 0)
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name  
, dbo.SYS_Entity.Title
GO
USE [cds_pegasus]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CAL_Calendar_ORG_Company]') AND parent_object_id = OBJECT_ID(N'[dbo].[CAL_Calendar]'))
ALTER TABLE [dbo].[CAL_Calendar] DROP CONSTRAINT [FK_CAL_Calendar_ORG_Company]
GO 

ALTER TABLE [dbo].[CAL_Calendar] DROP COLUMN [CompanyId]
GO

ALTER TABLE [dbo].[CAL_Calendar] ADD [EntityId] bigint
GO

ALTER TABLE [dbo].[CAL_Calendar]  WITH CHECK ADD  CONSTRAINT [FK_CAL_Calendar_SYS_Entity] FOREIGN KEY([EntityId])
REFERENCES [dbo].[SYS_Entity] ([Id])
GO

ALTER TABLE [dbo].[CAL_Calendar] CHECK CONSTRAINT [FK_CAL_Calendar_SYS_Entity]
GO
USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_Document]    Script Date: 12/10/2014 15:35:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Document]
AS
SELECT     dbo.SYS_DOC_Header.Id, dbo.ORG_TRX_Header.Id AS TransactionId, dbo.ORG_TRX_Header.HeaderId, dbo.SYS_DOC_Header.TypeId, 
					  dbo.ORG_TRX_Header.ShippingTypeId, dbo.ORG_TRX_Header.CompanyId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, 
					  dbo.SYS_DOC_Type.Name AS [Transaction Type], dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name AS SiteName, 
					  ORG_Company_Entity.Name AS CompanyName, dbo.ORG_TRX_ShippingType.Name AS ShippingTypeName, dbo.ORG_TRX_Header.DatePosted, CAST(dbo.ORG_TRX_Header.DatePosted AS DATE) AS DayPosted,
					  dbo.ORG_TRX_Header.DateFirstPrinted, dbo.ORG_TRX_Header.DateLastPrinted, dbo.ORG_TRX_Header.DateValid, dbo.ORG_TRX_Header.ReferenceShort1, 
					  dbo.ORG_TRX_Header.ReferenceShort2, dbo.ORG_TRX_Header.ReferenceShort3, dbo.ORG_TRX_Header.ReferenceShort4, dbo.ORG_TRX_Header.ReferenceShort5, 
					  dbo.ORG_TRX_Header.ReferenceLong1, dbo.ORG_TRX_Header.ReferenceLong2, dbo.ORG_TRX_Header.ReferenceLong3, dbo.ORG_TRX_Header.ReferenceLong4, 
					  dbo.ORG_TRX_Header.ReferenceLong5, dbo.ORG_TRX_Header.Rounding, dbo.ORG_TRX_Header.ContactPerson, dbo.ORG_TRX_Header.ContactTelephone, 
					  dbo.ORG_TRX_Header.Telephone, dbo.ORG_TRX_Header.VatNumber, dbo.ORG_TRX_Header.ShippingAddressLine1, dbo.ORG_TRX_Header.ShippingAddressLine2, 
					  dbo.ORG_TRX_Header.ShippingAddressLine3, dbo.ORG_TRX_Header.ShippingAddressLine4, dbo.ORG_TRX_Header.ShippingAddressCode, 
					  dbo.ORG_TRX_Header.BillingAddressLine1, dbo.ORG_TRX_Header.BillingAddressLine2, dbo.ORG_TRX_Header.BillingAddressLine3, 
					  dbo.ORG_TRX_Header.BillingAddressLine4, dbo.ORG_TRX_Header.BillingAddressCode, dbo.ORG_TRX_Header.TotalCash, dbo.ORG_TRX_Header.TotalCredit, 
					  dbo.ORG_TRX_Header.TotalAccount, dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname AS CreatedBy, 
					  SUM(dbo.SYS_DOC_Line.Total) AS TotalExcl, SUM(dbo.SYS_DOC_Line.Total + dbo.SYS_DOC_Line.TotalTax) AS Total, SUM(dbo.SYS_DOC_Line.TotalTax) 
					  AS TotalTax
FROM         dbo.ORG_TRX_Header INNER JOIN
					  dbo.ORG_TRX_ShippingType ON dbo.ORG_TRX_Header.ShippingTypeId = dbo.ORG_TRX_ShippingType.Id INNER JOIN
					  dbo.SYS_DOC_Header ON dbo.ORG_TRX_Header.HeaderId = dbo.SYS_DOC_Header.Id INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
					  dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id INNER JOIN
					  dbo.ORG_Company ON dbo.ORG_TRX_Header.CompanyId = dbo.ORG_Company.Id INNER JOIN
					  dbo.ORG_Entity ON dbo.ORG_Company.EntityId = dbo.ORG_Entity.Id INNER JOIN
					  dbo.SYS_Entity AS ORG_Company_Entity ON dbo.ORG_Entity.EntityId = ORG_Company_Entity.Id INNER JOIN
					  dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId INNER JOIN
					  dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
GROUP BY dbo.SYS_DOC_Header.Id, dbo.ORG_TRX_Header.Id, dbo.ORG_TRX_Header.HeaderId, dbo.SYS_DOC_Header.TypeId, dbo.ORG_TRX_Header.ShippingTypeId, 
					  dbo.ORG_TRX_Header.CompanyId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name, 
					  ORG_Company_Entity.Name, dbo.ORG_TRX_ShippingType.Name, dbo.ORG_TRX_Header.DatePosted, dbo.ORG_TRX_Header.DateFirstPrinted, 
					  dbo.ORG_TRX_Header.DateLastPrinted, dbo.ORG_TRX_Header.DateValid, dbo.ORG_TRX_Header.ReferenceShort1, dbo.ORG_TRX_Header.ReferenceShort2, 
					  dbo.ORG_TRX_Header.ReferenceShort3, dbo.ORG_TRX_Header.ReferenceShort4, dbo.ORG_TRX_Header.ReferenceShort5, dbo.ORG_TRX_Header.ReferenceLong1, 
					  dbo.ORG_TRX_Header.ReferenceLong2, dbo.ORG_TRX_Header.ReferenceLong3, dbo.ORG_TRX_Header.ReferenceLong4, dbo.ORG_TRX_Header.ReferenceLong5, 
					  dbo.ORG_TRX_Header.Rounding, dbo.ORG_TRX_Header.ContactPerson, dbo.ORG_TRX_Header.ContactTelephone, dbo.ORG_TRX_Header.Telephone, 
					  dbo.ORG_TRX_Header.VatNumber, dbo.ORG_TRX_Header.ShippingAddressLine1, dbo.ORG_TRX_Header.ShippingAddressLine2, 
					  dbo.ORG_TRX_Header.ShippingAddressLine3, dbo.ORG_TRX_Header.ShippingAddressLine4, dbo.ORG_TRX_Header.ShippingAddressCode, 
					  dbo.ORG_TRX_Header.BillingAddressLine1, dbo.ORG_TRX_Header.BillingAddressLine2, dbo.ORG_TRX_Header.BillingAddressLine3, 
					  dbo.ORG_TRX_Header.BillingAddressLine4, dbo.ORG_TRX_Header.BillingAddressCode, dbo.ORG_TRX_Header.TotalCash, dbo.ORG_TRX_Header.TotalCredit, 
					  dbo.ORG_TRX_Header.TotalAccount, dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname, dbo.SYS_DOC_Type.Name

GO 

/****** Object:  View [dbo].[VW_Attachment]    Script Date: 12/17/2014 09:45:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[VW_Attachment]
AS
SELECT     dbo.CAL_Attachment.Id, dbo.CAL_Attachment.CalendarId AS CalendarId, dbo.CAL_Attachment.DocumentId, dbo.SYS_DOC_Header.TypeId, dbo.SYS_DOC_Header.DocumentNumber, 
					  dbo.CAL_Calendar.StartDate, dbo.SYS_DOC_Type.Name, dbo.CAL_Calendar.Description, SUM(dbo.SYS_DOC_Line.Total) AS Total,
					  dbo.SYS_Person.FullName as CreatedBy, dbo.CAL_Attachment.CreatedOn
FROM         dbo.SYS_DOC_Type INNER JOIN
					  dbo.SYS_DOC_Header INNER JOIN
					  dbo.CAL_Attachment INNER JOIN
					  dbo.CAL_Calendar ON dbo.CAL_Attachment.CalendarId = dbo.CAL_Calendar.Id ON dbo.SYS_DOC_Header.Id = dbo.CAL_Attachment.DocumentId INNER JOIN
					  dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId ON dbo.SYS_DOC_Type.Id = dbo.SYS_DOC_Header.TypeId INNER JOIN
					  dbo.SYS_Person ON dbo.CAL_Attachment.CreatedBy = dbo.SYS_Person.Id
GROUP BY dbo.CAL_Attachment.CalendarId, dbo.SYS_DOC_Header.DocumentNumber, dbo.CAL_Attachment.DocumentId, dbo.CAL_Calendar.StartDate, dbo.SYS_DOC_Type.Name, dbo.CAL_Calendar.Description, 
					  dbo.CAL_Attachment.Id, dbo.SYS_DOC_Header.TypeId,dbo.SYS_Person.FullName, dbo.CAL_Attachment.CreatedOn
GO

--Werner Scheffer
USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_AnalyticSource]    Script Date: 12/22/2014 14:23:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_AnalyticSource]
AS
SELECT   'Sales Analysis' AS Name , 'VW_TransactionSales' AS Source, ISNULL(CAST(1 AS BIT),CAST(0 AS BIT)) AS DateFilter
UNION ALL
SELECT   'Purchases Analysis' AS Name , 'VW_TransactionPurchases' AS Source, ISNULL(CAST(1 AS BIT),CAST(0 AS BIT)) AS DateFilter
UNION ALL
SELECT   'Inventory Analysis' AS Name , 'VW_Inventory' AS Source, ISNULL(CAST(0 AS BIT),CAST(0 AS BIT)) AS DateFilter
UNION ALL
SELECT   'Finance Analysis' AS Name , 'VW_Balance' AS Source, ISNULL(CAST(1 AS BIT),CAST(0 AS BIT)) AS DateFilter
UNION ALL
SELECT   'Finance Entries Analysis' AS Name , 'VW_Line' AS Source, ISNULL(CAST(1 AS BIT),CAST(0 AS BIT)) AS DateFilter
UNION ALL
SELECT   'Workshop Analysis' AS Name , 'VW_Workshop' AS Source, ISNULL(CAST(1 AS BIT),CAST(0 AS BIT)) AS DateFilter

GO

USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_Balance]    Script Date: 12/22/2014 13:33:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO 

ALTER VIEW [dbo].[VW_Balance]
AS
SELECT 
MIN(B.Id) AS Id
, SUM(B.Amount) AS BalanceAmount
, SUM(ISNULL(BU.Amount,0)) AS BudgetAmount
, SUM(B.Amount * T.Flag2) AS RegularBalanceAmount
, A.Code AS AgingCode
, P.StartDate AS PeriodStartDate
, P.EndDate AS PeriodEndDate
, P.Code AS PeriodCode
, AE.CodeMain+'-'+AE.CodeSub AS AccountCode
, AE.Name AS AccountName
, AE.Description AS AccountDescription
, ACC.BalanceGroup AS BalanceGroup
, S.Name AS StatusCode
, T.Name AS TypeCode
, A.Id AS AgingId
, P.Id AS PeriodId
, AE.Id AS AccountId
, S.Id AS StatusId
, T.Id AS TypeId
, ACC.MasterControlId AS AccountMasterControlId
, T.Flag1 AS TypeFlag1
, T.Flag2 AS TypeFlag2
, P.Code AS FinancialPeriod					/*---|					 */
, P.StartDate AS Date						/*   | HERE FOR Analytics*/
, P.FinancialYear AS FinancialYear			/*   |					 */
, P.FinancialQuarter AS FinancialQuarter	/*---|					 */
FROM
	dbo.GLX_Account ACC
	INNER JOIN SYS_Entity AE ON ACC.EntityId=AE.Id
	LEFT JOIN dbo.GLX_Account child ON child.MasterControlId=ACC.EntityId OR (child.EntityId=ACC.EntityId)
	INNER JOIN SYS_Entity ChildE ON child.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_History B ON B.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_Aging A ON B.AgingId = A.Id 
	INNER JOIN dbo.SYS_Period P ON B.PeriodId = P.Id 
	INNER JOIN dbo.GLX_Type T ON ACC.ACcountTypeId = T.Id
	INNER JOIN dbo.SYS_Status S ON P.StatusId = S.Id
	LEFT JOIN dbo.GLX_Budget BU ON AE.Id = BU.EntityId AND P.Id = BU.PeriodId

GROUP BY 
	A.Code
	,P.StartDate
	, P.EndDate
	, P.Code
	, AE.CodeMain
	, AE.CodeSub
	, AE.Name
	, AE.Description
	, ACC.BalanceGroup
	, S.Name
	, T.Name
	, A.Id
	, P.Id
	, AE.Id
	, S.Id
	, T.Id
	, ACC.MasterControlId
	, T.Flag1
	, T.Flag2
	, P.FinancialYear
	, P.FinancialQuarter 
--select 
--  MIN(B.Id) Id
--, ACC.AccountId
--, SUM(B.Amount) AS BalanceAmount
--, SUM(B.Amount * ACC.Flag2Type) RegularBalanceAmount
--, A.Code AgingCode
--, P.StartDate PeriodStartDate
--, P.EndDate PeriodEndDate
--, P.Code PeriodCode
--, ACC.CodeMain+'-'+Acc.CodeSub AccountCode
--, ACC.Name AccountName
--, ACC.Description AccountDescription
--, P.Status StatusCode
--, ACC.CodeType TypeCode
--, AgingId
--, PeriodId
--, P.StatusId StatusId 
--, ACC.AccountTypeId TypeId
--, ACC.ControlId AccountMasterControlId
--, ACC.Flag1Type TypeFlag1
--, ACC.Flag2Type TypeFlag2
--, FinancialYear
--from 
--VW_Account ACC
--LEFT JOIN VW_Account ACCChild ON ACCChild.ControlId=ACC.Id OR ACCChild.Id = ACC.Id
--INNER JOIN dbo.GLX_History B ON B.EntityId=ACCChild.Id
--INNER JOIN VW_Period P on B.PeriodId = P.Id
--INNER JOIN dbo.GLX_Aging A ON B.AgingId = A.Id 
--group by 
--ACC.AccountId
--, A.Code  
--, P.StartDate  
--, P.EndDate  
--, P.Code  
--, ACC.CodeMain
--, Acc.CodeSub  
--, ACC.Name  
--, ACC.Description  
--, P.Status  
--, ACC.CodeType  
--, AgingId
--, PeriodId
--, P.StatusId   
--, ACC.AccountTypeId
--, ACC.ControlId
--, ACC.Flag1Type  
--, ACC.Flag2Type  
--, FinancialYear

GO

USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_Line]    Script Date: 12/22/2014 14:22:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Line]
AS
SELECT     TOP (100) PERCENT L.Id, H.Id AS HeaderId, AE.Id AS AccountId, R.Id AS ReconId, AE.Title AS AccountTitle, H.Reference AS HeaderReference, ISNULL(H.Description, '') 
					  AS HeaderDescription, A.Code AS AgingCode, L.Amount, AE.Name AS AccountName, AE.Description AS AccountDescription, CASE WHEN R.Id IS NULL 
					  THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END AS IsReconned, H.Date AS HeaderDate, CAST(H.Date AS DATE) AS HeaderDay, H.TrackId, 
					  H.CreatedOn AS HeaderCreatedOn, PN.Fullname AS HeaderCreatedBy, S.Name AS StatusCode, ISNULL(Center.CodeMain, '') AS CenterCode, 
					  P.Code AS PeriodCode                      
					, P.Code AS FinancialPeriod					/*---|					 */
					, P.StartDate AS Date						/*   | HERE FOR Analytics*/
					, P.FinancialYear AS FinancialYear			/*   |					 */
					, P.FinancialQuarter AS FinancialQuarter	/*---|					 */
FROM         dbo.GLX_Header AS H INNER JOIN
					  dbo.GLX_Line AS L ON H.Id = L.HeaderId INNER JOIN
					  dbo.SYS_Entity AS AE ON L.EntityId = AE.Id INNER JOIN
					  dbo.SYS_Person AS PN ON H.CreatedBy = PN.Id INNER JOIN
					  dbo.GLX_Account AS ACC ON AE.Id = ACC.EntityId LEFT OUTER JOIN
					  dbo.VW_Center AS Center ON ACC.CenterId = Center.Id INNER JOIN
					  dbo.SYS_Period AS P ON H.PeriodId = P.Id LEFT OUTER JOIN
					  dbo.SYS_Status AS S ON H.StatusId = S.Id LEFT OUTER JOIN
					  dbo.GLX_Aging AS A ON L.AgingId = A.Id LEFT OUTER JOIN
					  dbo.GLX_Recon AS R ON L.ReconId = R.Id
ORDER BY HeaderId
GO

--Werner Scheffer
USE [cds_pegasus]
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Analytic]'))
	DROP VIEW [dbo].[VW_Analytic]
GO

/****** Object:  View [dbo].[VW_Analytic]    Script Date: 12/23/2014 11:44:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_Analytic]
AS
SELECT     dbo.RPT_Analytic.Id, dbo.RPT_Analytic.Code, dbo.RPT_Analytic.Name, dbo.RPT_Analytic.Description, dbo.RPT_Analytic.Category, dbo.RPT_Analytic.SubCategory, 
					  dbo.RPT_Analytic.DataSource, dbo.RPT_Analytic.DataLayout, dbo.RPT_Analytic.Archived, dbo.RPT_Analytic.CreatedOn, 
					  dbo.SYS_Person.Fullname AS CreatedBy
FROM         dbo.RPT_Analytic INNER JOIN
					  dbo.SYS_Person ON dbo.RPT_Analytic.CreatedBy = dbo.SYS_Person.Id

GO


IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Report]'))
	DROP VIEW [dbo].[VW_Report]
GO

/****** Object:  View [dbo].[VW_Report]    Script Date: 12/23/2014 11:44:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_Report]
AS
SELECT     dbo.RPT_Report.Id, dbo.RPT_Report.Code, dbo.RPT_Report.Name, dbo.RPT_Report.Description, dbo.RPT_Report.TypeId, dbo.RPT_Report.Category, 
					  dbo.RPT_Report.SubCategory, dbo.RPT_Report.Data, dbo.RPT_Report.Archived, dbo.RPT_Report.CreatedOn, dbo.SYS_Person.Fullname AS CreatedBy
FROM         dbo.RPT_Report INNER JOIN
					  dbo.SYS_Person ON dbo.RPT_Report.CreatedBy = dbo.SYS_Person.Id
GO 
--Werner Scheffer

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_SYS_MSG_Message_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SYS_MSG_Message] DROP CONSTRAINT [DF_SYS_MSG_Message_CreatedOn]
END
GO

ALTER TABLE SYS_MSG_Message ALTER COLUMN SentOn DateTime
GO
 
ALTER TABLE [dbo].[SYS_MSG_Message] ADD  CONSTRAINT [DF_SYS_MSG_Message_CreatedOn]  DEFAULT (getdate()) FOR [SentOn]
GO

ALTER TABLE SYS_MSG_Message ALTER COLUMN ReceivedOn DateTime
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Messenger]'))
	DROP VIEW [dbo].[VW_Messenger]
GO

CREATE VIEW [dbo].[VW_Messenger]
AS
SELECT     dbo.SYS_MSG_Message.Id, dbo.SYS_MSG_Message.FromId, dbo.SYS_MSG_Message.ToId, SYS_Person_From.Fullname AS FromFullname, 
					  SYS_Person_To.Fullname AS ToFullname, dbo.SYS_MSG_Message.Sent, dbo.SYS_MSG_Message.Received, dbo.SYS_MSG_Message.SentOn, 
					  dbo.SYS_MSG_Message.ReceivedOn, dbo.SYS_MSG_Message.Message
FROM         dbo.SYS_MSG_Message INNER JOIN
					  dbo.SYS_Person AS SYS_Person_From ON dbo.SYS_MSG_Message.FromId = SYS_Person_From.Id INNER JOIN
					  dbo.SYS_Person AS SYS_Person_To ON dbo.SYS_MSG_Message.ToId = SYS_Person_To.Id

GO
--Werner Scheffer

ALTER VIEW [dbo].[VW_User]
AS
SELECT     dbo.SYS_Person.Id, dbo.SYS_Person.Title, dbo.SYS_Person.Name, dbo.SYS_Person.Surname, dbo.SEC_User.Username, dbo.SEC_User.DisplayName, 
					  dbo.SEC_User.LastDate, dbo.SEC_User.LastVersion, dbo.SEC_User.LastLocation, dbo.SYS_Person.Archived, dbo.HRS_Employee.Photo
FROM         dbo.SEC_User INNER JOIN
					  dbo.SYS_Person ON dbo.SEC_User.PersonId = dbo.SYS_Person.Id
					  LEFT JOIN dbo.HRS_Employee on dbo.SYS_Person.Id = dbo.HRS_Employee.PersonId

GO 
--Werner Scheffer
USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_CalendarWeb]    Script Date: 01/27/2015 09:15:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_CalendarWeb]'))
DROP VIEW [dbo].[VW_CalendarWeb]
GO

USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_CalendarWeb]    Script Date: 01/27/2015 09:15:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_CalendarWeb]
AS
SELECT     Id, CASE WHEN DATEDIFF(MONTH, StartDate, EndDate) = 0 THEN '' + LEFT('00', 2 - LEN(CONVERT(nvarchar(2), DATEPART(MONTH, StartDate)))) + CONVERT(nvarchar(2), 
					  DATEPART(MONTH, StartDate)) + '-DD-' + CONVERT(nvarchar(4), DATEPART(YEAR, StartDate)) + '' END AS [Key], CASE WHEN DATEDIFF(MONTH, StartDate, EndDate) 
					  = 0 THEN '{"content" : ["<span>' + [Subject] + '</span>",' + '"<span>' + [Description] + CASE WHEN AllDay = 1 THEN ' (All Day)' ELSE '' END + '</span>"], "startDate" : '
					   + CONVERT(nvarchar(2), DATEPART(DAY, StartDate)) + ', "endDate" : ' + CONVERT(nvarchar(2), DATEPART(DAY, EndDate)) + '}' END AS Value, ResourceId
FROM         dbo.CAL_Calendar

GO
--Werner Scheffer
/****** Object:  View [dbo].[VW_Line]    Script Date: 02/02/2015 09:30:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Line]
AS
SELECT     TOP (100) PERCENT L.Id, H.Id AS HeaderId, AE.Id AS AccountId, R.Id AS ReconId, AE.Title AS AccountTitle, H.Reference AS HeaderReference, ISNULL(H.Description, '') 
					  AS HeaderDescription, A.Code AS AgingCode, L.Amount, AE.Name AS AccountName, AE.Description AS AccountDescription, CASE WHEN R.Id IS NULL 
					  THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END AS IsReconned, H.Date AS HeaderDate, CAST(H.Date AS DATE) AS HeaderDay, H.TrackId, 
					  H.CreatedOn AS HeaderCreatedOn, PN.Fullname AS HeaderCreatedBy, S.Name AS StatusCode, ISNULL(Center.CodeMain, '') AS CenterCode, 
					  ROW_NUMBER ( ) OVER (ORDER BY L.Id) AS RowNumber /*Here for Web Portal Infinite Scroll*/
					, P.Code AS PeriodCode                      
					, P.Code AS FinancialPeriod					/*---|					 */
					, P.StartDate AS Date						/*   | HERE FOR Analytics*/
					, P.FinancialYear AS FinancialYear			/*   |					 */
					, P.FinancialQuarter AS FinancialQuarter	/*---|					 */
FROM         dbo.GLX_Header AS H INNER JOIN
					  dbo.GLX_Line AS L ON H.Id = L.HeaderId INNER JOIN
					  dbo.SYS_Entity AS AE ON L.EntityId = AE.Id INNER JOIN
					  dbo.SYS_Person AS PN ON H.CreatedBy = PN.Id INNER JOIN
					  dbo.GLX_Account AS ACC ON AE.Id = ACC.EntityId LEFT OUTER JOIN
					  dbo.VW_Center AS Center ON ACC.CenterId = Center.Id INNER JOIN
					  dbo.SYS_Period AS P ON H.PeriodId = P.Id LEFT OUTER JOIN
					  dbo.SYS_Status AS S ON H.StatusId = S.Id LEFT OUTER JOIN
					  dbo.GLX_Aging AS A ON L.AgingId = A.Id LEFT OUTER JOIN
					  dbo.GLX_Recon AS R ON L.ReconId = R.Id
ORDER BY HeaderId
GO
--Werner Scheffer
IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'SecurityLevel' AND [object_id] = OBJECT_ID(N'RPT_Report'))
BEGIN
	ALTER TABLE RPT_Report ADD SecurityLevel int NULL;
END

GO
/****** Object:  View [dbo].[VW_Report]    Script Date: 02/02/2015 15:22:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Report]
AS
SELECT     dbo.RPT_Report.Id, dbo.RPT_Report.TypeId, dbo.RPT_Report.Code, dbo.RPT_Report.Name, dbo.RPT_Report.Description, dbo.RPT_Report.Category, 
			dbo.RPT_Report.SecurityLevel,dbo.RPT_Report.SubCategory, dbo.RPT_Report.Data, dbo.RPT_Report.Archived, dbo.RPT_Report.CreatedOn, dbo.SYS_Person.Fullname AS CreatedBy
FROM         dbo.RPT_Report INNER JOIN
					  dbo.SYS_Person ON dbo.RPT_Report.CreatedBy = dbo.SYS_Person.Id

GO
--Werner Scheffer

--Henko Rabie

IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'DiscountPercentage' AND [object_id] = OBJECT_ID(N'SYS_DOC_Line'))
BEGIN
	EXEC sp_rename 'SYS_DOC_Line.Discount', 'DiscountPercentage' , 'COLUMN'
END
GO

IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'DiscountAmount' AND [object_id] = OBJECT_ID(N'SYS_DOC_Line'))
BEGIN
	ALTER TABLE SYS_DOC_Line ADD DiscountAmount decimal(18, 2) NULL;
END

GO



ALTER VIEW [dbo].[VW_Transaction]
AS
SELECT     
--ROW_NUMBER() OVER(ORDER BY dbo.SYS_DOC_Line.Id DESC) AS Id
  dbo.SYS_DOC_Line.Id --I want to use this but the Entity Framework can resolve the PK for some reason
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.Id AS DocumentId
, ITM_Item.Id ItemId
, dbo.ITM_Inventory.Id InventoryId
, VW_Company.Id CompanyId
, VW_Company.TypeId CompanyTypeId
, dbo.SYS_DOC_Type.Name AS DocumentType
, dbo.SYS_DOC_Header.DocumentNumber
, COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS DatePosted
, VW_Site.Name AS SiteName
, VW_Company.Name AS CompanyName
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.HoldingModifier AS QuantityHolding
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.BalanceModifier AS QuantityBalance
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.StockModifier AS QuantityStock
, dbo.ITM_Movement.OnHand
, dbo.ITM_Movement.OnReserve
, dbo.ITM_Movement.OnOrder
, dbo.SYS_DOC_Line.Amount
, dbo.SYS_DOC_Line.DiscountPercentage
, dbo.ITM_Movement.UnitPrice
, dbo.ITM_Movement.UnitCost
, dbo.ITM_Movement.UnitAverage
, dbo.SYS_DOC_Line.Total
, dbo.SYS_DOC_Line.CreatedOn
, dbo.SEC_User.DisplayName CreatedBy
, dbo.SYS_DOC_Header.CreatedBy CreatedById
, VW_Company.AreaCode AS AreaCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong1	,dbo.JOB_Header.ReferenceLong1		) AS YourReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong2	,dbo.JOB_Header.ReferenceLong2		) AS OurReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong3	,dbo.JOB_Header.ReferenceLong3		) AS ReferenceLong3
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong4	,dbo.JOB_Header.ReferenceLong4		) AS ReferenceLong4
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong5	,dbo.JOB_Header.ReferenceLong5		) AS ReferenceLong5
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort1	,dbo.JOB_Header.ReferenceShort1		) AS OrderNumber
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort2	,dbo.JOB_Header.ReferenceShort2		) AS RepCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort3	,dbo.JOB_Header.ReferenceShort3		) AS SalesManCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort4	,dbo.JOB_Header.ReferenceShort4		) AS ReferenceShort4
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort5	,dbo.JOB_Header.ReferenceShort5		) AS ReferenceShort5
, COALESCE(dbo.ORG_TRX_Header.DateFirstPrinted	,dbo.JOB_Header.DateFirstPrinted	) AS DateFirstPrinted
, COALESCE(dbo.ORG_TRX_Header.DateLastPrinted	,dbo.JOB_Header.DateLastPrinted		) AS DateLastPrinted
, COALESCE(dbo.ORG_TRX_Header.DateValid			,NULL								) AS DateValid
, COALESCE(dbo.ORG_TRX_Header.TotalCash			,0.00								) AS TotalCash
, COALESCE(dbo.ORG_TRX_Header.TotalCredit		,0.00								) AS TotalCredit
, COALESCE(dbo.ORG_TRX_Header.TotalAccount		,0.00								) AS TotalAccount
, COALESCE(dbo.ORG_TRX_Header.Rounding			,0.00								) AS Rounding

FROM     
dbo.SYS_DOC_Line
INNER JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity AS ITM_Item ON dbo.SYS_DOC_Line.ItemId = ITM_Item.Id 
INNER JOIN dbo.VW_Site ON dbo.SYS_DOC_Header.SiteId = VW_Site.Id  
INNER JOIN dbo.ITM_Inventory ON ITM_Item.Id = dbo.ITM_Inventory.EntityId AND dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id
INNER JOIN dbo.SYS_Person on dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SEC_User ON dbo.SYS_Person.Id = dbo.SEC_User.PersonId 
LEFT JOIN dbo.ITM_Movement ON dbo.SYS_DOC_Line.Id = dbo.ITM_Movement.LineId 
LEFT JOIN dbo.ORG_TRX_Header ON dbo.SYS_DOC_Header.Id = dbo.ORG_TRX_Header.HeaderId 
LEFT JOIN dbo.JOB_Header ON dbo.SYS_DOC_Header.Id = dbo.JOB_Header.HeaderId 
LEFT JOIN dbo.VW_Company ON COALESCE(dbo.ORG_TRX_Header.CompanyId,dbo.JOB_Header.CompanyId) = dbo.VW_Company.Id


GO

 
ALTER VIEW [dbo].[VW_TransactionSales]
AS
SELECT     dbo.VW_Transaction.Id, dbo.VW_Transaction.TypeId, dbo.VW_Transaction.DocumentId, dbo.VW_Transaction.ItemId, dbo.VW_Transaction.InventoryId, 
					  dbo.VW_Transaction.CompanyId, dbo.VW_Transaction.CompanyTypeId, dbo.VW_Transaction.DocumentType, dbo.VW_Transaction.DocumentNumber, 
					  dbo.VW_Transaction.DatePosted AS Date, dbo.VW_Transaction.SiteName, dbo.VW_Transaction.CompanyName, dbo.VW_Transaction.QuantityHolding, 
					  dbo.VW_Transaction.QuantityBalance, dbo.VW_Transaction.QuantityStock, dbo.VW_Transaction.OnHand, dbo.VW_Transaction.OnReserve, 
					  dbo.VW_Transaction.OnOrder, dbo.VW_Transaction.Amount, dbo.VW_Transaction.DiscountPercentage, dbo.VW_Transaction.UnitPrice, dbo.VW_Transaction.UnitCost, 
					  dbo.VW_Transaction.UnitAverage, dbo.VW_Transaction.Total, dbo.VW_Transaction.CreatedOn, dbo.VW_Transaction.CreatedBy, dbo.VW_Transaction.CreatedById, 
					  dbo.VW_Transaction.AreaCode, dbo.VW_Transaction.YourReference, dbo.VW_Transaction.OurReference, dbo.VW_Transaction.ReferenceLong3, 
					  dbo.VW_Transaction.ReferenceLong4, dbo.VW_Transaction.ReferenceLong5, dbo.VW_Transaction.OrderNumber, dbo.VW_Transaction.RepCode, 
					  dbo.VW_Transaction.SalesManCode, dbo.VW_Transaction.ReferenceShort4, dbo.VW_Transaction.ReferenceShort5, dbo.VW_Transaction.DateFirstPrinted, 
					  dbo.VW_Transaction.DateLastPrinted, dbo.VW_Transaction.DateValid, dbo.VW_Transaction.TotalCash, dbo.VW_Transaction.TotalCredit, 
					  dbo.VW_Transaction.TotalAccount, dbo.VW_Transaction.Rounding, dbo.SYS_Period.Code AS FinancialPeriod, dbo.SYS_Period.FinancialYear, 
					  dbo.SYS_Period.FinancialQuarter
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
					  dbo.SYS_Period ON dbo.VW_Transaction.DatePosted BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate
WHERE     (dbo.SYS_DOC_Type.Name IN ('TAX Invoice', 'Credit Note'))


GO



ALTER VIEW [dbo].[VW_TransactionPurchases]
AS
SELECT     dbo.VW_Transaction.Id, dbo.VW_Transaction.TypeId, dbo.VW_Transaction.DocumentId, dbo.VW_Transaction.ItemId, dbo.VW_Transaction.InventoryId, 
					  dbo.VW_Transaction.CompanyId, dbo.VW_Transaction.CompanyTypeId, dbo.VW_Transaction.DocumentType, dbo.VW_Transaction.DocumentNumber, 
					  dbo.VW_Transaction.DatePosted AS Date, dbo.VW_Transaction.SiteName, dbo.VW_Transaction.CompanyName, dbo.VW_Transaction.QuantityHolding, 
					  dbo.VW_Transaction.QuantityBalance, dbo.VW_Transaction.QuantityStock, dbo.VW_Transaction.OnHand, dbo.VW_Transaction.OnReserve, 
					  dbo.VW_Transaction.OnOrder, dbo.VW_Transaction.Amount, dbo.VW_Transaction.DiscountPercentage, dbo.VW_Transaction.UnitPrice, dbo.VW_Transaction.UnitCost, 
					  dbo.VW_Transaction.UnitAverage, dbo.VW_Transaction.Total, dbo.VW_Transaction.CreatedOn, dbo.VW_Transaction.CreatedBy, dbo.VW_Transaction.CreatedById, 
					  dbo.VW_Transaction.AreaCode, dbo.VW_Transaction.YourReference, dbo.VW_Transaction.OurReference, dbo.VW_Transaction.ReferenceLong3, 
					  dbo.VW_Transaction.ReferenceLong4, dbo.VW_Transaction.ReferenceLong5, dbo.VW_Transaction.OrderNumber, dbo.VW_Transaction.RepCode, 
					  dbo.VW_Transaction.SalesManCode, dbo.VW_Transaction.ReferenceShort4, dbo.VW_Transaction.ReferenceShort5, dbo.VW_Transaction.DateFirstPrinted, 
					  dbo.VW_Transaction.DateLastPrinted, dbo.VW_Transaction.DateValid, dbo.VW_Transaction.TotalCash, dbo.VW_Transaction.TotalCredit, 
					  dbo.VW_Transaction.TotalAccount, dbo.VW_Transaction.Rounding, dbo.SYS_Period.Code AS FinancialPeriod, dbo.SYS_Period.FinancialYear, 
					  dbo.SYS_Period.FinancialQuarter
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
					  dbo.SYS_Period ON dbo.VW_Transaction.DatePosted BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate
WHERE     (dbo.SYS_DOC_Type.Name IN ('Goods Received', 'Goods Returned'))


GO

-- Henko Rabie
--Werner Scheffer

ALTER VIEW [dbo].[VW_Company]
AS
SELECT	
 dbo.ORG_Company.Id AS Id
 , dbo.SYS_Entity.Id AS EntityId
 , dbo.ORG_Entity.Id AS OrgEntityId
 , dbo.ORG_Company.AccountId
 , dbo.ORG_Type.Id AS TypeId
 , dbo.ORG_Type.Name AS Type
 , dbo.SYS_Entity.CodeSub AS Code
 , dbo.SYS_Entity.Name
 , dbo.SYS_Entity.Archived
 , SYS_Person_Accounts.Name AS AccountsContact
 , SYS_Person_Sales.Name AS SalesContact
 , ORG_Contact_Accounts.Telephone1 AS AccountsTelephone
 , ORG_Contact_Sales.Telephone1 AS SalesTelephone
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 1) AS [Current]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 2) AS [30Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 3) AS [60Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 4) AS [90Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 5) AS [120Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 1) + dbo.fnGetAging(dbo.SYS_Entity.Id, 2) + dbo.fnGetAging(dbo.SYS_Entity.Id, 3) + dbo.fnGetAging(dbo.SYS_Entity.Id, 4) + dbo.fnGetAging(dbo.SYS_Entity.Id, 5) AS Total
 --, dbo.fnAccountAmountDue(dbo.ORG_Company.Id) AS AmountDue
 , dbo.ORG_Company.CreatedOn
 , dbo.ORG_Company.CreatedBy
 , dbo.SYS_Entity.Title
 , dbo.ORG_Entity.RegistrationNumber
 , dbo.ORG_Entity.VatNumber
 , dbo.ORG_Entity.Note
 , dbo.ORG_Company.PaymentTermId
 , dbo.ORG_Company.CostCategoryId
 , dbo.ORG_Company.OpenItem
 , dbo.ORG_Company.Active
 , dbo.ORG_Company.OverrideAccount
 , dbo.ORG_Company.DiscountCode
 , dbo.ORG_Company.TagCode
 , dbo.ORG_Company.CountryCode
 , dbo.ORG_Company.StatementPreference
 , dbo.ORG_Company.SalesmanCode
 , dbo.ORG_Company.AreaCode
 , dbo.ORG_Company.RepCode
 , dbo.ORG_Company.URL
 , dbo.ORG_Company.Username
 , dbo.ORG_Company.Password
 , dbo.ORG_Company.CustomValue1
 , dbo.ORG_Company.CustomValue2
 , dbo.ORG_Company.CustomValue3
 , dbo.ORG_Company.CustomValue4
 , dbo.ORG_Company.CustomValue5
 , dbo.ORG_Company.CustomValue6
FROM dbo.SYS_Entity 
INNER JOIN dbo.ORG_Entity ON dbo.SYS_Entity.Id = dbo.ORG_Entity.EntityId 
INNER JOIN dbo.ORG_Company ON dbo.ORG_Entity.Id = dbo.ORG_Company.EntityId 
INNER JOIN dbo.ORG_Type ON dbo.ORG_Company.TypeId = dbo.ORG_Type.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Accounts ON dbo.ORG_Entity.EntityId = ORG_Contact_Accounts.CompanyId AND ORG_Contact_Accounts.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Accounts')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Accounts ON ORG_Contact_Accounts.PersonId = SYS_Person_Accounts.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Sales ON dbo.ORG_Entity.EntityId = ORG_Contact_Sales.CompanyId AND ORG_Contact_Sales.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Sales')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Sales ON ORG_Contact_Sales.PersonId = SYS_Person_Sales.Id


GO

USE [cds_pegasus]
GO

/****** Object:  View [dbo].[VW_JobLine]    Script Date: 2015/02/20 02:25:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_JobLine]
AS
SELECT MIN(dbo.SYS_DOC_Line.Id) AS Id, dbo.SYS_DOC_Line.HeaderId, ISNULL(CONVERT(INT,MIN(dbo.SYS_DOC_Line.LineOrder)),0) as LineOrder, dbo.SYS_DOC_Line.ItemId, dbo.SYS_DOC_Line.DiscountPercentage, dbo.SYS_DOC_Line.Description, SUM(dbo.SYS_DOC_Line.Quantity) AS Quantity, dbo.SYS_DOC_Line.Amount, SUM(dbo.SYS_DOC_Line.Total) AS Total, SUM(dbo.SYS_DOC_Line.TotalTax) AS TotalTax, MIN(dbo.SYS_DOC_Line.CreatedOn) AS CreatedOn, MIN(dbo.SYS_DOC_Line.CreatedBy) AS CreatedBy
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId
WHERE     (dbo.SYS_DOC_Header.TypeId = 9)
GROUP BY dbo.SYS_DOC_Line.HeaderId, dbo.SYS_DOC_Line.ItemId, dbo.SYS_DOC_Line.DiscountPercentage, dbo.SYS_DOC_Line.Description, dbo.SYS_DOC_Line.Amount
HAVING SUM(dbo.SYS_DOC_Line.Quantity) <> 0
GO


ALTER TABLE SYS_Person DROP COLUMN Fullname;
GO
ALTER TABLE SYS_Person ADD Fullname AS ((isnull([Surname],'')+', ')+isnull([Name],''));

--Werner Scheffer

/****** Object:  View [dbo].[VW_Balance]    Script Date: 2015/04/07 10:22:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[VW_Balance]
AS
SELECT 
MIN(B.Id) AS Id
, SUM(B.Amount) AS BalanceAmount
, SUM(ISNULL(BU.Amount,0)) AS BudgetAmount
, SUM(B.Amount * T.Flag2) AS RegularBalanceAmount
, A.Code AS AgingCode
, P.StartDate AS PeriodStartDate
, P.EndDate AS PeriodEndDate
, P.Code AS PeriodCode
, AE.CodeMain+'-'+AE.CodeSub AS AccountCode
, AE.Name AS AccountName
, AE.Description AS AccountDescription
, ACC.BalanceGroup AS BalanceGroup
, S.Name AS StatusCode
, T.Name AS TypeCode
, A.Id AS AgingId
, P.Id AS PeriodId
, AE.Id AS AccountId
, S.Id AS StatusId
, T.Id AS TypeId
, ACC.MasterControlId AS AccountMasterControlId
, T.Flag1 AS TypeFlag1
, T.Flag2 AS TypeFlag2
, P.Code AS FinancialPeriod					/*---|					 */
, P.StartDate AS Date						/*   | HERE FOR Analytics*/
, P.FinancialYear AS FinancialYear			/*   |					 */
, P.FinancialQuarter AS FinancialQuarter	/*---|					 */
FROM
	dbo.GLX_Account ACC
	INNER JOIN SYS_Entity AE ON ACC.EntityId=AE.Id
	LEFT JOIN dbo.GLX_Account child ON child.MasterControlId=ACC.EntityId OR (child.EntityId=ACC.EntityId)
	INNER JOIN SYS_Entity ChildE ON child.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_History B ON B.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_Aging A ON B.AgingId = A.Id 
	INNER JOIN dbo.SYS_Period P ON B.PeriodId = P.Id 
	INNER JOIN dbo.GLX_Type T ON ACC.ACcountTypeId = T.Id
	INNER JOIN dbo.SYS_Status S ON P.StatusId = S.Id
	LEFT JOIN dbo.GLX_Budget BU ON AE.Id = BU.EntityId AND P.Id = BU.PeriodId AND B.AgingId=1

GROUP BY 
	A.Code
	,P.StartDate
	, P.EndDate
	, P.Code
	, AE.CodeMain
	, AE.CodeSub
	, AE.Name
	, AE.Description
	, ACC.BalanceGroup
	, S.Name
	, T.Name
	, A.Id
	, P.Id
	, AE.Id
	, S.Id
	, T.Id
	, ACC.MasterControlId
	, T.Flag1
	, T.Flag2
	, P.FinancialYear
	, P.FinancialQuarter 

GO

/****** Object:  View [dbo].[VW_DocumentLine]    Script Date: 04/07/2015 11:08:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_DocumentLine]

AS

SELECT     dbo.SYS_DOC_Line.Id, dbo.ORG_TRX_Header.Id AS TransactionId,dbo.SYS_DOC_Line.ItemId AS ItemId,dbo.SYS_DOC_Line.LineOrder, dbo.ORG_TRX_Header.HeaderId, dbo.SYS_DOC_Header.TypeId, 
					  dbo.ORG_TRX_Header.ShippingTypeId, dbo.ORG_TRX_Header.CompanyId, dbo.SYS_DOC_Header.TrackId, 
					  dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name AS SiteName, 
					  ORG_Company_Entity.Name AS CompanyName,
					  dbo.ORG_TRX_ShippingType.Name AS ShippingTypeName, dbo.ORG_TRX_Header.DatePosted, dbo.ORG_TRX_Header.DateFirstPrinted, 
					  dbo.ORG_TRX_Header.DateLastPrinted, dbo.ORG_TRX_Header.DateValid, dbo.ORG_TRX_Header.ReferenceShort1, dbo.ORG_TRX_Header.ReferenceShort2, 
					  dbo.ORG_TRX_Header.ReferenceShort3, dbo.ORG_TRX_Header.ReferenceShort4, dbo.ORG_TRX_Header.ReferenceShort5, dbo.ORG_TRX_Header.ReferenceLong1, 
					  dbo.ORG_TRX_Header.ReferenceLong2, dbo.ORG_TRX_Header.ReferenceLong3, dbo.ORG_TRX_Header.ReferenceLong4, dbo.ORG_TRX_Header.ReferenceLong5, 
					  dbo.ORG_TRX_Header.Rounding, dbo.ORG_TRX_Header.ContactPerson, dbo.ORG_TRX_Header.ContactTelephone, dbo.ORG_TRX_Header.Telephone,dbo.ORG_TRX_Header.VatNumber, 
					  dbo.ORG_TRX_Header.ShippingAddressLine1, dbo.ORG_TRX_Header.ShippingAddressLine2, dbo.ORG_TRX_Header.ShippingAddressLine3, 
					  dbo.ORG_TRX_Header.ShippingAddressLine4, dbo.ORG_TRX_Header.ShippingAddressCode, dbo.ORG_TRX_Header.BillingAddressLine1, 
					  dbo.ORG_TRX_Header.BillingAddressLine2, dbo.ORG_TRX_Header.BillingAddressLine3, dbo.ORG_TRX_Header.BillingAddressLine4, 
					  dbo.ORG_TRX_Header.BillingAddressCode, dbo.ORG_TRX_Header.TotalCash, dbo.ORG_TRX_Header.TotalCredit, dbo.ORG_TRX_Header.TotalAccount, 
					  dbo.SYS_DOC_Header.Comment,
					  dbo.SYS_DOC_Line.Description,
					  dbo.SYS_DOC_Line.DiscountPercentage,
					  dbo.SYS_DOC_Line.Quantity,
					  dbo.SYS_DOC_Line.Amount,
					  dbo.SYS_DOC_Type.BalanceModifier,
					  dbo.SYS_DOC_Type.HoldingModifier,
					  dbo.SYS_DOC_Type.StockModifier,
					  dbo.SYS_DOC_Header.CreatedOn,
					  dbo.SYS_Person.FullName AS CreatedBy,
					  (Total - TotalTax) AS TotalExcl,
					  (Total) AS Total, 
					  (TotalTax) AS TotalTax
FROM         dbo.ORG_TRX_Header INNER JOIN
					  dbo.ORG_TRX_ShippingType ON dbo.ORG_TRX_Header.ShippingTypeId = dbo.ORG_TRX_ShippingType.Id INNER JOIN
					  dbo.SYS_DOC_Header ON dbo.ORG_TRX_Header.HeaderId = dbo.SYS_DOC_Header.Id INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
					  dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id INNER JOIN
					  dbo.ORG_Company ON dbo.ORG_TRX_Header.CompanyId = dbo.ORG_Company.id INNER JOIN
					  dbo.ORG_Entity ON dbo.ORG_Company.EntityId = dbo.ORG_Entity.Id INNER JOIN
					  dbo.SYS_Entity AS ORG_Company_Entity ON dbo.ORG_Entity.EntityId = ORG_Company_Entity.Id INNER JOIN
					  dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId INNER JOIN
					  dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id


GO


--Werner Scheffer
/****** Object:  View [dbo].[VW_Site]    Script Date: 04/07/2015 11:42:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Site]
AS
SELECT		dbo.SYS_Entity.Id, dbo.SYS_Entity.CodeMain, dbo.SYS_Entity.ShortName, dbo.SYS_Entity.Name, dbo.SYS_Entity.Description, dbo.SYS_Site.RegistrationNumber, dbo.SYS_Entity.Archived, 
			dbo.SYS_Site.Telephone,
			dbo.SYS_Site.VatNumber,
			dbo.SYS_Site.VatPercentage,
			dbo.SYS_Site.BillingAddress,
			dbo.SYS_Site.ShippingAddress,
			dbo.SYS_Site.BankName,
			dbo.SYS_Site.BankBranch,
			dbo.SYS_Site.BankCode,
			dbo.SYS_Site.BankAccountNumber,
			dbo.SYS_Entity.Title
FROM        dbo.SYS_Entity INNER JOIN
			dbo.SYS_Site ON dbo.SYS_Entity.Id = dbo.SYS_Site.EntityId

GO

/****** Object:  View [dbo].[VW_Address]    Script Date: 04/07/2015 12:06:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Address]
AS
SELECT     dbo.SYS_Address.Id, dbo.SYS_Type.Id AS TypeId, dbo.ORG_Company.Id AS CompanyId, dbo.SYS_Type.Name, dbo.SYS_Address.Line1, dbo.SYS_Address.Line2, 
					  dbo.SYS_Address.Line3, dbo.SYS_Address.Line4, dbo.SYS_Address.Code
FROM         dbo.ORG_CompanyAddress INNER JOIN
					  dbo.ORG_Company ON dbo.ORG_CompanyAddress.CompanyId = dbo.ORG_Company.Id RIGHT JOIN
					  dbo.SYS_Address ON dbo.ORG_CompanyAddress.AddressId = dbo.SYS_Address.Id INNER JOIN
					  dbo.SYS_Type ON dbo.SYS_Address.TypeId = dbo.SYS_Type.Id

GO 

--Werner Scheffer
/****** Object:  View [dbo].[VW_PaymentItems]    Script Date: 2015/04/13 10:32:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_PaymentItems]
AS
SELECT
	'OI' Type,
	a.Id AS AccountId, 
	a.Title, 
	STUFF(MAX(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, h.Reference)), 1, 19, '') AS Reference, 
	STUFF(MAX(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, t.Initiator)), 1, 19, '') AS Description, 
	MIN(h.Date) Date, 
	t.Initiator AS Internal,
	SUM(l.Amount) AS Balance,
	MIN(p.Id) PeriodId,
	MIN(p.Code) Period,
	min(ag.Id) AgingId, 
	STUFF(MAX(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, ag.Code)), 1, 19, '') AS Aging, 
	h.TrackId AS TrackNumber, 
	a.Name, 
	a.CodeSub,
	a.CodeMain, 
	min(l.Id) as LineId,
	min(h.Id) as HeaderId,
	sa.TypeId
FROM 
	GLX_Header h 
	INNER JOIN GLX_Line l ON l.HeaderId=h.Id 
	INNER JOIN SYS_Tracking t ON h.TrackId = t.Id
	INNER JOIN VW_Account a ON l.EntityId=a.Id
	INNER JOIN SYS_Period p ON h.PeriodId=p.Id
	INNER JOIN GLX_Aging ag ON l.AgingId=ag.Id
	INNER JOIN VW_Company e ON e.AccountId=a.Id
	INNER JOIN GLX_SiteAccount sa ON a.ControlId=sa.EntityId
WHERE  
	e.OpenItem=1
GROUP BY 
	h.TrackId, h.StatusId, a.Id, a.Name, a.CodeSub, a.CodeMain, a.Title, t.Initiator, l.AgingId,sa.TypeId
HAVING 
	SUM(l.Amount)<>0

UNION

SELECT 
	'BBF' Type,
	a.Id AS AccountId, 
	a.Title, 
	'' AS Reference, 
	'Oustanding on '+ag.Code AS Description, 
	pe.EndDate Date, 
	'' AS Internal,
	ba.Amount AS Balance,
	pe.Id PeriodId,
	pe.Code Period,
	ag.Id AgingId, 
	ag.Code Aging, 
	NULL AS TrackNumber, 
	a.Name, 
	a.CodeSub,
	a.CodeMain, 
	NULL AS LineId,
	NULL AS HeaderId,
	sa.TypeId
FROM 
	VW_Account a 
	INNER JOIN GLX_History ba ON ba.EntityId=a.Id
	INNER JOIN SYS_Period pe ON ba.PeriodId=pe.Id
	INNER JOIN GLX_Aging ag ON ba.AgingId=ag.Id
	INNER JOIN VW_Company e ON e.AccountId=a.id
	INNER JOIN GLX_Account ga ON a.ControlId=ga.EntityId
	INNER JOIN GLX_SiteAccount sa ON ga.EntityId=sa.EntityId
WHERE 
	e.OpenItem=0
	AND ba.Amount<>0

GO


/****** Object:  StoredProcedure [dbo].[spUpdateCompanyHistory]    Script Date: 2015/04/20 08:37:27 AM ******/
DROP PROCEDURE [dbo].[spUpdateCompanyHistory]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateCompanyHistory]    Script Date: 2015/04/20 08:37:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateCompanyHistory]
	@CompanyId bigint,
	@Amount decimal(18,4)
AS
BEGIN
	
	UPDATE ORG_History SET Amount = Amount + @Amount FROM 
	ORG_History H 
	INNER JOIN SYS_Period on H.PeriodId = SYS_Period.Id 
	INNER JOIN ORG_Company on H.CompanyId = ORG_Company.id 
	WHERE ORG_Company.Id = @CompanyId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

GO


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryAmount]    Script Date: 2015/04/20 08:37:33 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryAmount]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryAmount]    Script Date: 2015/04/20 08:37:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryAmount]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Amount decimal(18,4)
AS
BEGIN
	DECLARE @BalanceModifier smallint
	
	SELECT TOP 1 @BalanceModifier = BalanceModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET Amount = Amount + @BalanceModifier * @Amount FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryMovement]    Script Date: 2015/04/20 08:37:40 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryMovement]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryMovement]    Script Date: 2015/04/20 08:37:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryMovement]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Movement decimal(18,4)
AS
BEGIN
	DECLARE @BalanceModifier smallint
	
	SELECT TOP 1 @BalanceModifier = BalanceModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET Movement = Movement + @BalanceModifier * @Movement FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryMovementDate]    Script Date: 2015/04/20 08:37:46 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryMovementDate]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryMovementDate]    Script Date: 2015/04/20 08:37:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryMovementDate]
	
	@ItemId bigint,
	@SiteId bigint
AS
BEGIN

	UPDATE ITM_History SET LastMovement = getdate() FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnHand]    Script Date: 2015/04/20 08:37:52 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryOnHand]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnHand]    Script Date: 2015/04/20 08:37:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryOnHand]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Quantity decimal(18,4)
AS
BEGIN
	DECLARE @HoldingModifier smallint
	
	SELECT TOP 1 @HoldingModifier = HoldingModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET OnHand = OnHand + @HoldingModifier * @Quantity FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnOrder]    Script Date: 2015/04/20 08:37:58 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryOnOrder]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnOrder]    Script Date: 2015/04/20 08:37:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Order for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryOnOrder]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Quantity decimal(18,4)
AS
BEGIN
	DECLARE @HoldingModifier smallint
	
	SELECT TOP 1 @HoldingModifier = HoldingModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET OnOrder = OnOrder + @HoldingModifier * @Quantity FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

GO


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnReserve]    Script Date: 2015/04/20 08:38:05 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryOnReserve]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryOnReserve]    Script Date: 2015/04/20 08:38:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Reserve for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryOnReserve]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Quantity decimal(18,4)
AS
BEGIN
	DECLARE @HoldingModifier smallint
	
	SELECT TOP 1 @HoldingModifier = HoldingModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET OnReserve = OnReserve + @HoldingModifier * @Quantity FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryPurchaseDate]    Script Date: 2015/04/20 08:38:10 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryPurchaseDate]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryPurchaseDate]    Script Date: 2015/04/20 08:38:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryPurchaseDate]
	
	@ItemId bigint,
	@SiteId bigint
AS
BEGIN

	UPDATE ITM_History SET LastPurchased = getdate(), FirstPurchased = isnull(FirstPurchased,getdate()) FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


GO


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistorySalesDate]    Script Date: 2015/04/20 08:38:16 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventorySalesDate]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistorySalesDate]    Script Date: 2015/04/20 08:38:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical On Hand for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistorySalesDate]
	
	@ItemId bigint,
	@SiteId bigint
AS
BEGIN

	UPDATE ITM_History SET LastSold = getdate(), FirstSold = isnull(FirstSold,getdate()) FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitAverage]    Script Date: 2015/04/20 08:38:21 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryUnitAverage]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitAverage]    Script Date: 2015/04/20 08:38:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical Unit Average for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryUnitAverage]
	
	@ItemId bigint,
	@SiteId bigint,
	@Amount decimal(18,4)
AS
BEGIN
	UPDATE ITM_History SET UnitAverage = @amount FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

GO


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitCost]    Script Date: 2015/04/20 08:38:27 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryUnitCost]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitCost]    Script Date: 2015/04/20 08:38:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical Unit Cost for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryUnitCost]
	
	@ItemId bigint,
	@SiteId bigint,
	@Amount decimal(18,4)
AS
BEGIN
	UPDATE ITM_History SET UnitCost = @amount FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryUnitPrice]    Script Date: 02/24/2014 12:15:55 ******/
SET ANSI_NULLS ON

GO


/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitPrice]    Script Date: 2015/04/20 08:38:32 AM ******/
DROP PROCEDURE [dbo].[spUpdateInventoryUnitPrice]
GO

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryUnitPrice]    Script Date: 2015/04/20 08:38:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Description:	Updates Historical Unit Price for Current Period and forward
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateInventoryHistoryUnitPrice]
	
	@ItemId bigint,
	@SiteId bigint,
	@Amount decimal(18,4)
AS
BEGIN
	UPDATE ITM_History SET UnitPrice = @amount FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate >= (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryUnitAverage]    Script Date: 02/24/2014 12:15:55 ******/
SET ANSI_NULLS ON

GO

-- Henko Rabie


/****** Object:  View [dbo].[VW_StockDocument]    Script Date: 2015/04/20 09:04:51 AM ******/
DROP VIEW [dbo].[VW_StockDocument]
GO

/****** Object:  View [dbo].[VW_StockDocument]    Script Date: 2015/04/20 09:04:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[VW_StockDocument]
AS
SELECT     
dbo.SYS_DOC_Header.Id
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.TrackId
, dbo.SYS_DOC_Header.SiteId
, dbo.SYS_DOC_Type.Name AS [Transaction Type]
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_Entity.Name AS SiteName
, dbo.SYS_DOC_Header.Comment
, dbo.SYS_DOC_Header.CreatedOn
, dbo.SYS_Person.Fullname AS CreatedBy
, SUM(dbo.SYS_DOC_Line.Total) AS TotalExcl
, SUM(dbo.SYS_DOC_Line.Total + dbo.SYS_DOC_Line.TotalTax) AS Total
, SUM(dbo.SYS_DOC_Line.TotalTax) AS TotalTax
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
WHERE SYS_DOC_Type.Name in ('Transfer Request','Transfer Shipment','Transfer Recieved','Inventory Adjustment','BOM Assembly Started','BOM Disassembly Started','BOM Canceled','BOM Complete')
GROUP BY dbo.SYS_DOC_Header.Id, dbo.SYS_DOC_Header.TypeId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name, 
dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname, dbo.SYS_DOC_Type.Name


GO



/****** Object:  View [dbo].[VW_StockDocumentLine]    Script Date: 2015/04/20 09:04:58 AM ******/
DROP VIEW [dbo].[VW_StockDocumentLine]
GO

/****** Object:  View [dbo].[VW_StockDocumentLine]    Script Date: 2015/04/20 09:04:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[VW_StockDocumentLine]

AS

SELECT 
dbo.SYS_DOC_Line.Id
, dbo.SYS_DOC_Line.ItemId AS ItemId
, dbo.SYS_DOC_Line.LineOrder
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.TrackId
, dbo.SYS_DOC_Header.SiteId
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_Entity.Name AS SiteName
, dbo.SYS_DOC_Header.Comment
, dbo.SYS_DOC_Line.Quantity
, dbo.SYS_DOC_Type.BalanceModifier
, dbo.SYS_DOC_Type.HoldingModifier
, dbo.SYS_DOC_Type.StockModifier
, dbo.SYS_DOC_Header.CreatedOn
, dbo.SYS_Person.FullName AS CreatedBy
, (Total - TotalTax) AS TotalExcl
, (Total) AS Total
, (TotalTax) AS TotalTax
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
WHERE SYS_DOC_Type.Name in ('Transfer Request','Transfer Shipment','Transfer Received','Inventory Adjustment','BOM Assembly Started','BOM Disassembly Started','BOM Canceled','BOM Complete')
GO


update SYS_DOC_Type set Name = 'Transfer Received' where Id = 12
GO

/****** Object:  View [dbo].[VW_StockDocumentLine]    Script Date: 04/20/2015 09:20:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_StockDocumentLine]'))
DROP VIEW [dbo].[VW_StockDocumentLine]
GO 

/****** Object:  View [dbo].[VW_StockDocumentLine]    Script Date: 04/20/2015 09:20:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO 
CREATE VIEW [dbo].[VW_StockDocumentLine]

AS

SELECT 
dbo.SYS_DOC_Line.Id
, dbo.SYS_DOC_Line.ItemId AS ItemId
, dbo.SYS_DOC_Line.LineOrder
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.TrackId
, dbo.SYS_DOC_Header.SiteId
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_Entity.Name AS SiteName
, dbo.SYS_DOC_Header.Comment
, dbo.SYS_DOC_Line.Quantity
, dbo.SYS_DOC_Type.BalanceModifier
, dbo.SYS_DOC_Type.HoldingModifier
, dbo.SYS_DOC_Type.StockModifier
, dbo.SYS_DOC_Header.CreatedOn
, dbo.SYS_Person.FullName AS CreatedBy
, (Total - TotalTax) AS TotalExcl
, (Total) AS Total
, (TotalTax) AS TotalTax
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
WHERE SYS_DOC_Type.Name in ('Transfer Request','Transfer Shipment','Transfer Received','Inventory Adjustment','BOM Assembly Started','BOM Disassembly Started','BOM Canceled','BOM Complete')




GO


/****** Object:  View [dbo].[VW_StockDocumentLine]    Script Date: 04/20/2015 09:20:52 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_StockDocument]'))
DROP VIEW [dbo].[VW_StockDocument]
GO 

CREATE VIEW [dbo].[VW_StockDocument]
AS
SELECT     
dbo.SYS_DOC_Header.Id
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.TrackId
, dbo.SYS_DOC_Header.SiteId
, dbo.SYS_DOC_Type.Name AS [Transaction Type]
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_Entity.Name AS SiteName
, dbo.SYS_DOC_Header.Comment
, dbo.SYS_DOC_Header.CreatedOn
, dbo.SYS_Person.Fullname AS CreatedBy
, SUM(dbo.SYS_DOC_Line.Total) AS TotalExcl
, SUM(dbo.SYS_DOC_Line.Total + dbo.SYS_DOC_Line.TotalTax) AS Total
, SUM(dbo.SYS_DOC_Line.TotalTax) AS TotalTax
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
WHERE SYS_DOC_Type.Name in ('Transfer Request','Transfer Shipment','Transfer Received','Inventory Adjustment','BOM Assembly Started','BOM Disassembly Started','BOM Canceled','BOM Complete')
GROUP BY dbo.SYS_DOC_Header.Id, dbo.SYS_DOC_Header.TypeId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name, 
dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname, dbo.SYS_DOC_Type.Name
GO
--Werner Scheffer
--Henko Rabie
/****** Object:  View [dbo].[VW_SalesHistory]    Script Date: 04/22/2015 08:59:40 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_SalesHistory]'))
DROP VIEW [dbo].[VW_SalesHistory]
GO

/****** Object:  View [dbo].[VW_ItemHistory]    Script Date: 04/22/2015 08:59:40 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_ItemHistory]'))
DROP VIEW [dbo].[VW_ItemHistory]
GO


/****** Object:  View [dbo].[VW_ItemHistory]    Script Date: 04/22/2015 08:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_ItemHistory]
AS
SELECT   
ITM_History.Id AS Id, 
ITM_Inventory.Id AS InventoryId, 
SYS_Period.FinancialYear, 
SYS_Period.EndDate AS Date, 
SYS_Period.Code AS Code, 
ITM_History.Amount,
ITM_History.Movement,
ITM_History.OnHand,
ITM_History.OnReserve,
ITM_History.OnOrder,
ITM_History.UnitPrice,
ITM_History.UnitCost,
ITM_History.UnitAverage,
ITM_History.FirstSold,
ITM_History.FirstPurchased,
ITM_History.LastSold,
ITM_History.LastPurchased,
ITM_History.LastMovement,  
--ITM_History.Sales12,
--ITM_History.Sales6,
--ITM_History.Sales3
 (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 12 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X) AS [Sales12],
	   (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 6 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X) AS [Sales6], 
	 (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 3 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X)  AS [Sales3]
FROM         SYS_Period INNER JOIN
					  ITM_History with (nolock) ON SYS_Period.Id = ITM_History.PeriodId INNER JOIN
					  ITM_Inventory ON ITM_Inventory.Id = ITM_History.InventoryId INNER JOIN 
					  SYS_Entity AS ITM_Item ON ITM_Inventory.EntityId = ITM_Item.Id
GO

/****** Object:  StoredProcedure [dbo].[spUpdateCompanyHistory]    Script Date: 04/22/2015 09:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Henko Rabie
-- Create date: 2014-02-22
-- Modified date: 2015-04-22
-- Description:	Updates Historical Amount for Current Period
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateCompanyHistory]
	@CompanyId bigint,
	@Amount decimal(18,4)
AS
BEGIN
	
	UPDATE ORG_History SET Amount = Amount + @Amount FROM 
	ORG_History H 
	INNER JOIN SYS_Period on H.PeriodId = SYS_Period.Id 
	INNER JOIN ORG_Company on H.CompanyId = ORG_Company.id 
	WHERE ORG_Company.Id = @CompanyId
	AND EndDate = (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Modified date: 2015-04-22
-- Description:	Updates Historical Movement for Current Period
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateInventoryHistoryMovement]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Movement decimal(18,4)
AS
BEGIN
	DECLARE @BalanceModifier smallint
	
	SELECT TOP 1 @BalanceModifier = BalanceModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET Movement = Movement + @BalanceModifier * @Movement FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate = (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END

/****** Object:  StoredProcedure [dbo].[spUpdateInventoryHistoryAmount]    Script Date: 04/22/2015 09:45:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Werner C Scheffer
-- Create date: 2014-02-21
-- Modified date: 2015-04-22
-- Description:	Updates Historical Amount for Current Period
-- =============================================
ALTER PROCEDURE [dbo].[spUpdateInventoryHistoryAmount]
	
	@ItemId bigint,
	@SiteId bigint,
	@DocumentType tinyint,
	@Amount decimal(18,4)
AS
BEGIN
	DECLARE @BalanceModifier smallint
	
	SELECT TOP 1 @BalanceModifier = BalanceModifier FROM SYS_DOC_Type where id = @DocumentType

	UPDATE ITM_History SET Amount = Amount + @BalanceModifier * @Amount FROM 
	ITM_History H INNER JOIN 
	SYS_Period on H.PeriodId = SYS_Period.Id INNER JOIN
	ITM_Inventory on H.InventoryId = ITM_Inventory.id 
	WHERE ITM_Inventory.EntityId = @ItemId AND ITM_Inventory.SiteId = @SiteId
	AND EndDate = (select SYS_Period_Current.EndDate from dbo.fnCurrentPeriod() SYS_Period_Current)
END
GO

/****** Object:  View [dbo].[VW_CompanyHistory]    Script Date: 04/22/2015 10:15:06 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_CompanyHistory]'))
DROP VIEW [dbo].[VW_CompanyHistory]
GO

/****** Object:  View [dbo].[VW_CompanyHistory]    Script Date: 04/22/2015 10:15:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_CompanyHistory]
AS
SELECT   ORG_History.Id
		,ORG_Company.Id CompanyId
		,SYS_Period.FinancialYear
		,SYS_Period.EndDate Date
		,SYS_Period.Code
		,ORG_History.Amount
FROM 
		SYS_Period INNER JOIN
		ORG_History with (nolock) ON SYS_Period.Id = ORG_History.PeriodId INNER JOIN 
		ORG_Company ON ORG_History.CompanyId = ORG_Company.Id INNER JOIN
		SYS_Entity ON ORG_Company.EntityId = SYS_Entity.Id

GO
--Werner Scheffer
--Henko Rabie

/****** Object:  View [dbo].[VW_CompanyHistory]    Script Date: 04/24/2015 09:08:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_CompanyHistory]
AS
SELECT   ORG_History.Id
		,ORG_Company.Id CompanyId
		,SYS_Entity.CodeMain
		,SYS_Entity.CodeSub
		,SYS_Entity.Name
		,SYS_Period.FinancialYear
		,SYS_Period.EndDate Date
		,SYS_Period.Code
		,ORG_History.Amount
FROM 
		SYS_Period INNER JOIN
		ORG_History WITH (NOLOCK) ON SYS_Period.Id = ORG_History.PeriodId INNER JOIN 
		ORG_Company ON ORG_History.CompanyId = ORG_Company.Id INNER JOIN
		ORG_Entity ON ORG_Company.EntityId = ORG_Entity.Id INNER JOIN
		SYS_Entity ON ORG_Entity.EntityId = SYS_Entity.Id
GO
--Werner Scheffer
--Henko Rabie
IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'TypeId' and Object_ID = Object_ID(N'GLX_SystemAccountType'))
BEGIN
	ALTER TABLE GLX_SystemAccountType ADD TypeId TINYINT
END
GO

UPDATE GLX_SystemAccountType SET TypeId = 1
GO

ALTER TABLE GLX_SystemAccountType ALTER COLUMN TypeId TINYINT NOT NULL
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GLX_SystemAccountType_GLX_Type]') AND parent_object_id = OBJECT_ID(N'[dbo].[GLX_SystemAccountType]'))
	ALTER TABLE [dbo].[GLX_SystemAccountType] DROP CONSTRAINT [FK_GLX_SystemAccountType_GLX_Type]
GO 

ALTER TABLE [dbo].[GLX_SystemAccountType]  WITH CHECK ADD  CONSTRAINT [FK_GLX_SystemAccountType_GLX_Type] FOREIGN KEY([TypeId])
	REFERENCES [dbo].[GLX_Type] ([Id])
GO

ALTER TABLE [dbo].[GLX_SystemAccountType] CHECK CONSTRAINT [FK_GLX_SystemAccountType_GLX_Type]
GO

UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 1
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 2
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 3
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 4
UPDATE GLX_SystemAccountType SET TypeId = 2 WHERE Id = 5
UPDATE GLX_SystemAccountType SET TypeId = 2 WHERE Id = 6
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 7
UPDATE GLX_SystemAccountType SET TypeId = 5 WHERE Id = 8
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 9
UPDATE GLX_SystemAccountType SET TypeId = 6 WHERE Id = 10
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 11
UPDATE GLX_SystemAccountType SET TypeId = 3 WHERE Id = 12
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 13
UPDATE GLX_SystemAccountType SET TypeId = 6 WHERE Id = 14
UPDATE GLX_SystemAccountType SET TypeId = 2 WHERE Id = 16
UPDATE GLX_SystemAccountType SET TypeId = 1 WHERE Id = 17
UPDATE GLX_SystemAccountType SET TypeId = 3 WHERE Id = 18
UPDATE GLX_SystemAccountType SET TypeId = 3 WHERE Id = 19
UPDATE GLX_SystemAccountType SET TypeId = 2 WHERE Id = 20
UPDATE GLX_SystemAccountType SET TypeId = 5 WHERE Id = 21
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 22
UPDATE GLX_SystemAccountType SET TypeId = 4 WHERE Id = 23
GO
/****** Object:  View [dbo].[VW_SiteAccountType]    Script Date: 04/30/2015 12:59:19 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_SiteAccountType]'))
DROP VIEW [dbo].[VW_SiteAccountType]
GO

/****** Object:  View [dbo].[VW_SiteAccountType]    Script Date: 04/30/2015 12:59:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_SiteAccountType]
AS
SELECT     
		dbo.GLX_SystemAccountType.Id
		,dbo.GLX_Type.Id TypeId
		,dbo.GLX_SystemAccountType.Name
		,dbo.GLX_Type.Name TypeName
		,dbo.GLX_Type.Description
FROM	dbo.GLX_SystemAccountType 
		INNER JOIN dbo.GLX_Type ON dbo.GLX_SystemAccountType.TypeId = dbo.GLX_Type.Id
GO
--Werner Scheffer
--Henko Rabie

update SEC_Access set Name='Back Order', Description='Back Order' where Code='SADOBO'
GO

IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'NotifyonBackOrder' AND [object_id] = OBJECT_ID(N'SYS_Site'))
BEGIN
	EXEC sp_rename 'SYS_Site.NotifyonSalesBackOrder', 'NotifyonBackOrder' , 'COLUMN'
END
GO

--Henko Rabie

update ORG_CostCategory set Name='Selling Price including tax' where Name='Selling Price including sales tax'
GO
update ORG_CostCategory set Name='Selling Price excluding tax' where Name='Selling Price excluding sales tax'
GO
update ORG_CostCategory set Name='Cost including tax' where Name='Cost including sales tax'
GO
update ORG_CostCategory set Name='Cost excluding tax' where Name='Cost excluding sales tax'
GO
update ORG_CostCategory set Name='Average Cost excluding tax' where Name='Average Cost excluding sales tax'
GO

--Henko Rabie
--Werner Scheffer

ALTER TABLE ORG_TRX_Header ALTER COLUMN BillingAddressCode NVARCHAR(10)
--Werner Scheffer

delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where Code = 'SADOSIRECR03')
delete SEC_Access where Code = 'SADOSIRECR03'
--Werner Scheffer

delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'SADOSIRECR01')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'SADOSIRECR02')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'SADOSIRECR04')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'SADOSORECR01')

--DELETE
delete SEC_Access where code = 'SADOSIRECR01'
delete SEC_Access where code = 'SADOSIRECR02'
delete SEC_Access where code = 'SADOSIRECR04'
delete SEC_Access where code = 'SADOSORECR01'

update SEC_Access set Code = 'SADOSORECR01' where Code = 'SADOSORECR02'--Change Discount
update SEC_Access set Code = 'SADOSORECR02' where Code = 'SADOSORECR03'--Change Unit Price
update SEC_Access set Code = 'SADOSORECR03' where Code = 'SADOSORECR04'--Change Rep Code
update SEC_Access set Code = 'SADOSORECR04' where Code = 'SADOSORECR05'--Change Salesman Code

SET IDENTITY_INSERT [dbo].[SEC_Access] ON
insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (295,'SADOSORECR05','Sell Below Cost','Sell Below Cost',(select Id from SEC_Access where Code = 'SADOSORECR'),NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (296,'SADOSORECR06','Sell Below Mark up','Sell Below Mark up',(select Id from SEC_Access where Code = 'SADOSORECR'),NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (297,'SADOQTRECR05','Sell Below Cost','Sell Below Cost',(select Id from SEC_Access where Code = 'SADOQTRECR'),NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (298,'SADOQTRECR06','Sell Below Mark up','Sell Below Mark up',(select Id from SEC_Access where Code = 'SADOQTRECR'),NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
SET IDENTITY_INSERT [dbo].[SEC_Access] OFF
--Werner Scheffer

update GLX_Type set Name='Long Term Debt' where Id=8

--Henko Rabie
 
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'INPM')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'INPMRE')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'INPMRECR')
delete SEC_RoleAccess where AccessId = (select Id from SEC_Access where code = 'INPMREED')
 
delete SEC_Access where code = 'INPM'
delete SEC_Access where code = 'INPMRE'
delete SEC_Access where code = 'INPMRECR'
delete SEC_Access where code = 'INPMREED'
 

 /****** Object:  View [dbo].[VW_PayableItems]    Script Date: 05/12/2015 08:44:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_PayableItems]
AS
SELECT
	 [VW_PaymentItems].* from [VW_PaymentItems]
	 INNER JOIN GLX_SystemAccountType say ON [VW_PaymentItems].TypeId = say.Id AND say.Name = 'Creditors'

GO 

/****** Object:  View [dbo].[VW_ReceivableItems]    Script Date: 05/12/2015 08:44:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_ReceivableItems]
AS
SELECT
	 [VW_PaymentItems].* from [VW_PaymentItems]
	 INNER JOIN GLX_SystemAccountType say ON [VW_PaymentItems].TypeId = say.Id AND say.Name = 'Debtors'

GO
--Werner Scheffer

ALTER TABLE [dbo].[ORG_Distribution] ADD CONSTRAINT DF_ORG_Distribution_CreatedOn DEFAULT (getdate()) FOR CreatedOn
GO
--Werner Scheffer

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GLX_Account_SYS_Entity_Control]') AND parent_object_id = OBJECT_ID(N'[dbo].[GLX_Account]'))
ALTER TABLE [dbo].[GLX_Account] DROP CONSTRAINT [FK_GLX_Account_SYS_Entity_Control]
GO
ALTER TABLE [dbo].[GLX_Account]  WITH CHECK ADD  CONSTRAINT [FK_GLX_Account_SYS_Entity_Control] FOREIGN KEY([ControlId])
REFERENCES [dbo].[SYS_Entity] ([Id])
GO
ALTER TABLE [dbo].[GLX_Account] CHECK CONSTRAINT [FK_GLX_Account_SYS_Entity_Control]
GO 

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GLX_Account_SYS_Entity_MasterControl]') AND parent_object_id = OBJECT_ID(N'[dbo].[GLX_Account]'))
ALTER TABLE [dbo].[GLX_Account] DROP CONSTRAINT [FK_GLX_Account_SYS_Entity_MasterControl]
GO
ALTER TABLE [dbo].[GLX_Account]  WITH CHECK ADD  CONSTRAINT [FK_GLX_Account_SYS_Entity_MasterControl] FOREIGN KEY([MasterControlId])
REFERENCES [dbo].[SYS_Entity] ([Id])
GO
ALTER TABLE [dbo].[GLX_Account] CHECK CONSTRAINT [FK_GLX_Account_SYS_Entity_MasterControl]
GO
--Werner Scheffer

UPDATE SEC_Access SET Code = REPLACE(CODE,'SADOSI','SADOTI')
UPDATE SEC_Access SET Name = 'TAX Invoice', [Description] = 'TAX Invoice' WHERE Code = 'SADOTI'
GO
--Werner Scheffer
/****** Object:  View [dbo].[VW_Document]    Script Date: 05/21/2015 09:32:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Document]
AS
SELECT     dbo.SYS_DOC_Header.Id, dbo.ORG_TRX_Header.Id AS TransactionId, dbo.ORG_TRX_Header.HeaderId, dbo.SYS_DOC_Header.TypeId, 
					  dbo.ORG_TRX_Header.ShippingTypeId, dbo.ORG_TRX_Header.CompanyId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, 
					  dbo.SYS_DOC_Type.Name AS [TransactionType], dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name AS SiteName, 
					  ORG_Company_Entity.Name AS CompanyName, dbo.ORG_TRX_ShippingType.Name AS ShippingTypeName, dbo.ORG_TRX_Header.DatePosted, CAST(dbo.ORG_TRX_Header.DatePosted AS DATE) AS DayPosted,
					  dbo.ORG_TRX_Header.DateFirstPrinted, dbo.ORG_TRX_Header.DateLastPrinted, dbo.ORG_TRX_Header.DateValid, dbo.ORG_TRX_Header.ReferenceShort1, 
					  dbo.ORG_TRX_Header.ReferenceShort2, dbo.ORG_TRX_Header.ReferenceShort3, dbo.ORG_TRX_Header.ReferenceShort4, dbo.ORG_TRX_Header.ReferenceShort5, 
					  dbo.ORG_TRX_Header.ReferenceLong1, dbo.ORG_TRX_Header.ReferenceLong2, dbo.ORG_TRX_Header.ReferenceLong3, dbo.ORG_TRX_Header.ReferenceLong4, 
					  dbo.ORG_TRX_Header.ReferenceLong5, dbo.ORG_TRX_Header.Rounding, dbo.ORG_TRX_Header.ContactPerson, dbo.ORG_TRX_Header.ContactTelephone, 
					  dbo.ORG_TRX_Header.Telephone, dbo.ORG_TRX_Header.VatNumber, dbo.ORG_TRX_Header.ShippingAddressLine1, dbo.ORG_TRX_Header.ShippingAddressLine2, 
					  dbo.ORG_TRX_Header.ShippingAddressLine3, dbo.ORG_TRX_Header.ShippingAddressLine4, dbo.ORG_TRX_Header.ShippingAddressCode, 
					  dbo.ORG_TRX_Header.BillingAddressLine1, dbo.ORG_TRX_Header.BillingAddressLine2, dbo.ORG_TRX_Header.BillingAddressLine3, 
					  dbo.ORG_TRX_Header.BillingAddressLine4, dbo.ORG_TRX_Header.BillingAddressCode, dbo.ORG_TRX_Header.TotalCash, dbo.ORG_TRX_Header.TotalCredit, 
					  dbo.ORG_TRX_Header.TotalAccount, dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname AS CreatedBy, 
					  SUM(dbo.SYS_DOC_Line.Total) AS TotalExcl, SUM(dbo.SYS_DOC_Line.Total + dbo.SYS_DOC_Line.TotalTax) AS Total, SUM(dbo.SYS_DOC_Line.TotalTax) 
					  AS TotalTax
FROM         dbo.ORG_TRX_Header INNER JOIN
					  dbo.ORG_TRX_ShippingType ON dbo.ORG_TRX_Header.ShippingTypeId = dbo.ORG_TRX_ShippingType.Id INNER JOIN
					  dbo.SYS_DOC_Header ON dbo.ORG_TRX_Header.HeaderId = dbo.SYS_DOC_Header.Id INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id INNER JOIN
					  dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id INNER JOIN
					  dbo.ORG_Company ON dbo.ORG_TRX_Header.CompanyId = dbo.ORG_Company.Id INNER JOIN
					  dbo.ORG_Entity ON dbo.ORG_Company.EntityId = dbo.ORG_Entity.Id INNER JOIN
					  dbo.SYS_Entity AS ORG_Company_Entity ON dbo.ORG_Entity.EntityId = ORG_Company_Entity.Id INNER JOIN
					  dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId INNER JOIN
					  dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
GROUP BY dbo.SYS_DOC_Header.Id, dbo.ORG_TRX_Header.Id, dbo.ORG_TRX_Header.HeaderId, dbo.SYS_DOC_Header.TypeId, dbo.ORG_TRX_Header.ShippingTypeId, 
					  dbo.ORG_TRX_Header.CompanyId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name, 
					  ORG_Company_Entity.Name, dbo.ORG_TRX_ShippingType.Name, dbo.ORG_TRX_Header.DatePosted, dbo.ORG_TRX_Header.DateFirstPrinted, 
					  dbo.ORG_TRX_Header.DateLastPrinted, dbo.ORG_TRX_Header.DateValid, dbo.ORG_TRX_Header.ReferenceShort1, dbo.ORG_TRX_Header.ReferenceShort2, 
					  dbo.ORG_TRX_Header.ReferenceShort3, dbo.ORG_TRX_Header.ReferenceShort4, dbo.ORG_TRX_Header.ReferenceShort5, dbo.ORG_TRX_Header.ReferenceLong1, 
					  dbo.ORG_TRX_Header.ReferenceLong2, dbo.ORG_TRX_Header.ReferenceLong3, dbo.ORG_TRX_Header.ReferenceLong4, dbo.ORG_TRX_Header.ReferenceLong5, 
					  dbo.ORG_TRX_Header.Rounding, dbo.ORG_TRX_Header.ContactPerson, dbo.ORG_TRX_Header.ContactTelephone, dbo.ORG_TRX_Header.Telephone, 
					  dbo.ORG_TRX_Header.VatNumber, dbo.ORG_TRX_Header.ShippingAddressLine1, dbo.ORG_TRX_Header.ShippingAddressLine2, 
					  dbo.ORG_TRX_Header.ShippingAddressLine3, dbo.ORG_TRX_Header.ShippingAddressLine4, dbo.ORG_TRX_Header.ShippingAddressCode, 
					  dbo.ORG_TRX_Header.BillingAddressLine1, dbo.ORG_TRX_Header.BillingAddressLine2, dbo.ORG_TRX_Header.BillingAddressLine3, 
					  dbo.ORG_TRX_Header.BillingAddressLine4, dbo.ORG_TRX_Header.BillingAddressCode, dbo.ORG_TRX_Header.TotalCash, dbo.ORG_TRX_Header.TotalCredit, 
					  dbo.ORG_TRX_Header.TotalAccount, dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname, dbo.SYS_DOC_Type.Name

GO
--Werner Scheffer

-- Henko Rabie


alter table ORG_Entity alter column Note nvarchar(4000)

-- Henko Rabie
/****** Object:  View [dbo].[VW_Company]    Script Date: 2015/06/03 11:39:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Company]
AS
SELECT	
 dbo.ORG_Company.Id AS Id
 , dbo.SYS_Entity.Id AS EntityId
 , dbo.ORG_Entity.Id AS OrgEntityId
 , dbo.ORG_Company.AccountId
 , dbo.ORG_Type.Id AS TypeId
 , dbo.ORG_Type.Name AS Type
 , dbo.SYS_Entity.CodeSub AS Code
 , dbo.SYS_Entity.Name
 , dbo.SYS_Entity.Archived
 , SYS_Person_Accounts.Name AS AccountsContact
 , SYS_Person_Sales.Name AS SalesContact
 , ORG_Contact_Accounts.Telephone1 AS AccountsTelephone
 , ORG_Contact_Sales.Telephone1 AS SalesTelephone
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 1) AS [Current]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 2) AS [30Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 3) AS [60Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 4) AS [90Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 5) AS [120Days]
 --, dbo.fnGetAging(dbo.SYS_Entity.Id, 1) + dbo.fnGetAging(dbo.SYS_Entity.Id, 2) + dbo.fnGetAging(dbo.SYS_Entity.Id, 3) + dbo.fnGetAging(dbo.SYS_Entity.Id, 4) + dbo.fnGetAging(dbo.SYS_Entity.Id, 5) AS Total
 --, dbo.fnAccountAmountDue(dbo.ORG_Company.Id) AS AmountDue
 , dbo.ORG_Company.CreatedOn
 , dbo.ORG_Company.CreatedBy
 , ((isnull(nullif(ORG_Company.Prefix,'')+'','')+isnull(nullif(SYS_Entity.CodeSub,'')+' - ',''))+SYS_Entity.Name) Title
 , dbo.ORG_Entity.RegistrationNumber
 , dbo.ORG_Entity.VatNumber
 , dbo.ORG_Entity.Note
 , dbo.ORG_Company.PaymentTermId
 , dbo.ORG_Company.CostCategoryId
 , dbo.ORG_Company.OpenItem
 , dbo.ORG_Company.Active
 , dbo.ORG_Company.OverrideAccount
 , dbo.ORG_Company.DiscountCode
 , dbo.ORG_Company.TagCode
 , dbo.ORG_Company.CountryCode
 , dbo.ORG_Company.StatementPreference
 , dbo.ORG_Company.SalesmanCode
 , dbo.ORG_Company.AreaCode
 , dbo.ORG_Company.RepCode
 , dbo.ORG_Company.URL
 , dbo.ORG_Company.Username
 , dbo.ORG_Company.Password
 , dbo.ORG_Company.CustomValue1
 , dbo.ORG_Company.CustomValue2
 , dbo.ORG_Company.CustomValue3
 , dbo.ORG_Company.CustomValue4
 , dbo.ORG_Company.CustomValue5
 , dbo.ORG_Company.CustomValue6
FROM dbo.SYS_Entity 
INNER JOIN dbo.ORG_Entity ON dbo.SYS_Entity.Id = dbo.ORG_Entity.EntityId 
INNER JOIN dbo.ORG_Company ON dbo.ORG_Entity.Id = dbo.ORG_Company.EntityId 
INNER JOIN dbo.ORG_Type ON dbo.ORG_Company.TypeId = dbo.ORG_Type.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Accounts ON dbo.ORG_Entity.EntityId = ORG_Contact_Accounts.CompanyId AND ORG_Contact_Accounts.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Accounts')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Accounts ON ORG_Contact_Accounts.PersonId = SYS_Person_Accounts.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Sales ON dbo.ORG_Entity.EntityId = ORG_Contact_Sales.CompanyId AND ORG_Contact_Sales.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Sales')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Sales ON ORG_Contact_Sales.PersonId = SYS_Person_Sales.Id
GO  

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VW_Inventory', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_Inventory'

GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'VW_Inventory', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_Inventory'

GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VW_Inventory', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_Inventory'

GO

/****** Object:  View [dbo].[VW_Inventory]    Script Date: 2015/06/08 12:36:21 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Inventory]'))
DROP VIEW [dbo].[VW_Inventory]
GO

/****** Object:  View [dbo].[VW_Inventory]    Script Date: 2015/06/08 12:36:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Inventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Inventory]
AS
SELECT dbo.ITM_Inventory.Id
, dbo.SYS_Entity.Id AS EntityId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS ItemCreatedOn
, dbo.SYS_Entity.CreatedBy AS ItemCreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, ISNULL(dbo.ITM_Inventory.CostofSalesId,0) AS CostofSalesId
, dbo.ITM_Inventory.RequireSerial
, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(ITM_History.OnHand, 0) AS OnHand
, ISNULL(ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(ITM_History.UnitAverage, 0) AS UnitAverage
, ITM_History.FirstSold
, ITM_History.FirstPurchased
, ITM_History.LastSold
, ITM_History.LastPurchased
, ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
, SYS_Entity.CodeMain + ''	'' + ISNULL(SYS_Entity.Name, '''') AS Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
INNER JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
INNER JOIN dbo.ITM_History AS ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId 
INNER JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and PrimarySupplier = 1
' 
GO
/****** Object:  View [dbo].[VW_StockDocument]    Script Date: 2015/06/08 01:54:06 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_StockDocument]'))
DROP VIEW [dbo].[VW_StockDocument]
GO

/****** Object:  View [dbo].[VW_StockDocument]    Script Date: 2015/06/08 01:54:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_StockDocument]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_StockDocument]
AS
SELECT     
dbo.SYS_DOC_Header.Id
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.TrackId
, dbo.SYS_DOC_Header.SiteId
, dbo.SYS_DOC_Type.Name AS TransactionType
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_Entity.Name AS SiteName
, dbo.SYS_DOC_Header.Comment
, dbo.SYS_DOC_Header.CreatedOn
, dbo.SYS_Person.Fullname AS CreatedBy
, SUM(dbo.SYS_DOC_Line.Total) AS TotalExcl
, SUM(dbo.SYS_DOC_Line.Total + dbo.SYS_DOC_Line.TotalTax) AS Total
, SUM(dbo.SYS_DOC_Line.TotalTax) AS TotalTax
FROM dbo.SYS_DOC_Header 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity ON dbo.SYS_DOC_Header.SiteId = dbo.SYS_Entity.Id 
INNER JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_Person ON dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
WHERE SYS_DOC_Type.Name in (''Transfer Request'',''Transfer Shipment'',''Transfer Received'',''Inventory Adjustment'',''BOM Assembly Started'',''BOM Disassembly Started'',''BOM Canceled'',''BOM Complete'')
GROUP BY dbo.SYS_DOC_Header.Id, dbo.SYS_DOC_Header.TypeId, dbo.SYS_DOC_Header.TrackId, dbo.SYS_DOC_Header.SiteId, dbo.SYS_DOC_Header.DocumentNumber, dbo.SYS_Entity.Name, 
dbo.SYS_DOC_Header.Comment, dbo.SYS_DOC_Header.CreatedOn, dbo.SYS_Person.Fullname, dbo.SYS_DOC_Type.Name
' 
GO
 
/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/09 09:51:24 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
DROP VIEW [dbo].[VW_Transaction]
GO

/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/09 09:51:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Transaction]
AS
SELECT     
--ROW_NUMBER() OVER(ORDER BY dbo.SYS_DOC_Line.Id DESC) AS Id
  dbo.SYS_DOC_Line.Id --I want to use this but the Entity Framework can resolve the PK for some reason
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.Id AS DocumentId
, ITM_Item.Id ItemId
, dbo.ITM_Inventory.Id InventoryId
, VW_Company.Id CompanyId
, VW_Company.TypeId CompanyTypeId
, dbo.SYS_DOC_Type.Name AS DocumentType
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_DOC_Header.TrackId AS TackingNumber
, COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS DatePosted
, VW_Site.Name AS SiteName
, VW_Company.Name AS CompanyName
, VW_Company.Code AS CompanyCode
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.HoldingModifier AS QuantityHolding
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.BalanceModifier AS QuantityBalance
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.StockModifier AS QuantityStock
, dbo.ITM_Movement.OnHand
, dbo.ITM_Movement.OnReserve
, dbo.ITM_Movement.OnOrder
, dbo.ITM_Movement.UnitPrice
, dbo.ITM_Movement.UnitCost
, dbo.ITM_Movement.UnitAverage
, dbo.SYS_DOC_Line.Amount
, dbo.SYS_DOC_Line.DiscountPercentage
, dbo.SYS_DOC_Line.Description
, dbo.SYS_DOC_Line.Total
, dbo.SYS_DOC_Line.TotalTax
, dbo.SYS_DOC_Line.CreatedOn
, dbo.SEC_User.DisplayName CreatedBy
, dbo.SYS_DOC_Header.CreatedBy CreatedById
, VW_Company.AreaCode AS AreaCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong1	,dbo.JOB_Header.ReferenceLong1		) AS YourReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong2	,dbo.JOB_Header.ReferenceLong2		) AS OurReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong3	,dbo.JOB_Header.ReferenceLong3		) AS ReferenceLong3
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong4	,dbo.JOB_Header.ReferenceLong4		) AS ReferenceLong4
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong5	,dbo.JOB_Header.ReferenceLong5		) AS ReferenceLong5
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort1	,dbo.JOB_Header.ReferenceShort1		) AS OrderNumber
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort2	,dbo.JOB_Header.ReferenceShort2		) AS RepCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort3	,dbo.JOB_Header.ReferenceShort3		) AS SalesManCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort4	,dbo.JOB_Header.ReferenceShort4		) AS ReferenceShort4
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort5	,dbo.JOB_Header.ReferenceShort5		) AS ReferenceShort5
, COALESCE(dbo.ORG_TRX_Header.DateFirstPrinted	,dbo.JOB_Header.DateFirstPrinted	) AS DateFirstPrinted
, COALESCE(dbo.ORG_TRX_Header.DateLastPrinted	,dbo.JOB_Header.DateLastPrinted		) AS DateLastPrinted
, COALESCE(dbo.ORG_TRX_Header.DateValid			,NULL								) AS DateValid
, COALESCE(dbo.ORG_TRX_Header.TotalCash			,0.00								) AS TotalCash
, COALESCE(dbo.ORG_TRX_Header.TotalCredit		,0.00								) AS TotalCredit
, COALESCE(dbo.ORG_TRX_Header.TotalAccount		,0.00								) AS TotalAccount
, COALESCE(dbo.ORG_TRX_Header.Rounding			,0.00								) AS Rounding
, dbo.SYS_Period.Id AS PeriodId
, dbo.SYS_Period.Code AS PeriodCode 
, dbo.SYS_Period.EndDate AS PeriodEndDate
FROM     
dbo.SYS_DOC_Line
INNER JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity AS ITM_Item ON dbo.SYS_DOC_Line.ItemId = ITM_Item.Id 
INNER JOIN dbo.VW_Site ON dbo.SYS_DOC_Header.SiteId = VW_Site.Id  
INNER JOIN dbo.ITM_Inventory ON ITM_Item.Id = dbo.ITM_Inventory.EntityId AND dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id
INNER JOIN dbo.SYS_Person on dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SEC_User ON dbo.SYS_Person.Id = dbo.SEC_User.PersonId 
LEFT JOIN dbo.ITM_Movement ON dbo.SYS_DOC_Line.Id = dbo.ITM_Movement.LineId 
LEFT JOIN dbo.ORG_TRX_Header ON dbo.SYS_DOC_Header.Id = dbo.ORG_TRX_Header.HeaderId 
LEFT JOIN dbo.JOB_Header ON dbo.SYS_DOC_Header.Id = dbo.JOB_Header.HeaderId 
LEFT JOIN dbo.VW_Company ON COALESCE(dbo.ORG_TRX_Header.CompanyId,dbo.JOB_Header.CompanyId) = dbo.VW_Company.Id
LEFT JOIN dbo.SYS_Period ON SYS_DOC_Header.CreatedOn BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate' 
GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VW_TransactionPurchases', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_TransactionPurchases'

GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VW_TransactionPurchases', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_TransactionPurchases'

GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/09 09:51:28 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
DROP VIEW [dbo].[VW_TransactionPurchases]
GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/09 09:51:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionPurchases]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id 
WHERE     (dbo.SYS_DOC_Type.Name IN (''Goods Received'', ''Goods Returned''))' 
GO 

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VW_TransactionSales', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_TransactionSales'

GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VW_TransactionSales', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_TransactionSales'

GO

/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/09 09:51:56 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
DROP VIEW [dbo].[VW_TransactionSales]
GO

/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/09 09:51:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionSales]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id
WHERE     (dbo.SYS_DOC_Type.Name IN (''TAX Invoice'', ''Credit Note''))' 
GO  
/****** Object:  View [dbo].[VW_ItemHistory]    Script Date: 2015/06/09 02:49:35 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_ItemHistory]'))
DROP VIEW [dbo].[VW_ItemHistory]
GO

/****** Object:  View [dbo].[VW_ItemHistory]    Script Date: 2015/06/09 02:49:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_ItemHistory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_ItemHistory]
AS
SELECT   
ITM_History.Id AS Id, 
ITM_Inventory.Id AS InventoryId, 
SYS_Period.Id AS PeriodId,
SYS_Period.FinancialYear, 
SYS_Period.EndDate AS Date, 
SYS_Period.Code AS Code, 
ITM_History.Amount,
ITM_History.Movement,
ITM_History.OnHand,
ITM_History.OnReserve,
ITM_History.OnOrder,
ITM_History.UnitPrice,
ITM_History.UnitCost,
ITM_History.UnitAverage,
ITM_History.FirstSold,
ITM_History.FirstPurchased,
ITM_History.LastSold,
ITM_History.LastPurchased,
ITM_History.LastMovement,  
--ITM_History.Sales12,
--ITM_History.Sales6,
--ITM_History.Sales3
 (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 12 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X) AS [Sales12],
	   (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 6 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X) AS [Sales6], 
	 (SELECT SUM(ISNULL(Movement,0)) FROM (
	select TOP 3 Movement from SYS_Period INNER_PERIOD LEFT JOIN ITM_History INNER_HISTORY on 
	INNER_PERIOD.Id  = INNER_HISTORY.PeriodId AND INNER_HISTORY.InventoryId = ITM_Inventory.Id
	WHERE INNER_PERIOD.EndDate <= SYS_Period.EndDate   AND INNER_PERIOD.EndDate >= DATEADD(YEAR,-2,SYS_Period.EndDate)
	ORDER BY SYS_Period.EndDate DESC )X)  AS [Sales3]
FROM         SYS_Period INNER JOIN
					  ITM_History with (nolock) ON SYS_Period.Id = ITM_History.PeriodId INNER JOIN
					  ITM_Inventory ON ITM_Inventory.Id = ITM_History.InventoryId INNER JOIN 
					  SYS_Entity AS ITM_Item ON ITM_Inventory.EntityId = ITM_Item.Id' 
GO
--Werner Scheffer
--Henko Rabie


ALTER TABLE ORG_TRX_Header ALTER COLUMN ShippingAddressLine1 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN ShippingAddressLine2 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN ShippingAddressLine3 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN ShippingAddressLine4 nvarchar(100)
GO


ALTER TABLE ORG_TRX_Header ALTER COLUMN BillingAddressLine1 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN BillingAddressLine2 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN BillingAddressLine3 nvarchar(100)
GO
ALTER TABLE ORG_TRX_Header ALTER COLUMN BillingAddressLine4 nvarchar(100)
GO
--Henko Rabie
 
/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/15 11:09:25 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
DROP VIEW [dbo].[VW_Transaction]
GO

/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/15 11:09:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Transaction]
AS
SELECT     
--ROW_NUMBER() OVER(ORDER BY dbo.SYS_DOC_Line.Id DESC) AS Id
  dbo.SYS_DOC_Line.Id --I want to use this but the Entity Framework can resolve the PK for some reason
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.Id AS DocumentId
, ITM_Item.Id ItemId
, dbo.ITM_Inventory.Id InventoryId
, VW_Company.Id CompanyId
, VW_Company.TypeId CompanyTypeId
, dbo.SYS_DOC_Type.Name AS DocumentType
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_DOC_Header.TrackId AS TackingNumber
, COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS DatePosted
, VW_Site.Name AS SiteName
, VW_Company.Name AS CompanyName
, VW_Company.Code AS CompanyCode
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.HoldingModifier AS QuantityHolding
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.BalanceModifier AS QuantityBalance
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.StockModifier AS QuantityStock
, dbo.ITM_Movement.OnHand
, dbo.ITM_Movement.OnReserve
, dbo.ITM_Movement.OnOrder
, dbo.ITM_Movement.UnitPrice
, dbo.ITM_Movement.UnitCost
, dbo.ITM_Movement.UnitAverage
, dbo.SYS_DOC_Line.Amount
, dbo.SYS_DOC_Line.DiscountPercentage
, dbo.SYS_DOC_Line.Description
, dbo.SYS_DOC_Line.Total
, dbo.SYS_DOC_Line.TotalTax
, dbo.SYS_DOC_Line.CreatedOn
, dbo.SEC_User.DisplayName CreatedBy
, dbo.SYS_DOC_Header.CreatedBy CreatedById
, VW_Company.AreaCode AS AreaCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong1	,dbo.JOB_Header.ReferenceLong1		) AS YourReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong2	,dbo.JOB_Header.ReferenceLong2		) AS OurReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong3	,dbo.JOB_Header.ReferenceLong3		) AS ReferenceLong3
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong4	,dbo.JOB_Header.ReferenceLong4		) AS ReferenceLong4
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong5	,dbo.JOB_Header.ReferenceLong5		) AS ReferenceLong5
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort1	,dbo.JOB_Header.ReferenceShort1		) AS OrderNumber
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort2	,dbo.JOB_Header.ReferenceShort2		) AS RepCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort3	,dbo.JOB_Header.ReferenceShort3		) AS SalesManCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort4	,dbo.JOB_Header.ReferenceShort4		) AS ReferenceShort4
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort5	,dbo.JOB_Header.ReferenceShort5		) AS ReferenceShort5
, COALESCE(dbo.ORG_TRX_Header.DateFirstPrinted	,dbo.JOB_Header.DateFirstPrinted	) AS DateFirstPrinted
, COALESCE(dbo.ORG_TRX_Header.DateLastPrinted	,dbo.JOB_Header.DateLastPrinted		) AS DateLastPrinted
, COALESCE(dbo.ORG_TRX_Header.DateValid			,NULL								) AS DateValid
, COALESCE(dbo.ORG_TRX_Header.TotalCash			,0.00								) AS TotalCash
, COALESCE(dbo.ORG_TRX_Header.TotalCredit		,0.00								) AS TotalCredit
, COALESCE(dbo.ORG_TRX_Header.TotalAccount		,0.00								) AS TotalAccount
, COALESCE(dbo.ORG_TRX_Header.Rounding			,0.00								) AS Rounding
, dbo.SYS_Period.Id AS PeriodId
, dbo.SYS_Period.Code AS PeriodCode 
, dbo.SYS_Period.EndDate AS PeriodEndDate
, dbo.SYS_Period.FinancialYear AS PeriodFinancialYear
FROM     
dbo.SYS_DOC_Line
INNER JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
INNER JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
INNER JOIN dbo.SYS_Entity AS ITM_Item ON dbo.SYS_DOC_Line.ItemId = ITM_Item.Id 
INNER JOIN dbo.VW_Site ON dbo.SYS_DOC_Header.SiteId = VW_Site.Id  
INNER JOIN dbo.ITM_Inventory ON ITM_Item.Id = dbo.ITM_Inventory.EntityId AND dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id
INNER JOIN dbo.SYS_Person on dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SEC_User ON dbo.SYS_Person.Id = dbo.SEC_User.PersonId 
LEFT JOIN dbo.ITM_Movement ON dbo.SYS_DOC_Line.Id = dbo.ITM_Movement.LineId 
LEFT JOIN dbo.ORG_TRX_Header ON dbo.SYS_DOC_Header.Id = dbo.ORG_TRX_Header.HeaderId 
LEFT JOIN dbo.JOB_Header ON dbo.SYS_DOC_Header.Id = dbo.JOB_Header.HeaderId 
LEFT JOIN dbo.VW_Company ON COALESCE(dbo.ORG_TRX_Header.CompanyId,dbo.JOB_Header.CompanyId) = dbo.VW_Company.Id
LEFT JOIN dbo.SYS_Period ON SYS_DOC_Header.CreatedOn BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate' 
GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/15 11:09:29 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
DROP VIEW [dbo].[VW_TransactionPurchases]
GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/15 11:09:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionPurchases]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id 
WHERE     (dbo.SYS_DOC_Type.Name IN (''Goods Received'', ''Goods Returned''))' 
GO
 
/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/15 11:09:35 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
DROP VIEW [dbo].[VW_TransactionSales]
GO

/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/15 11:09:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionSales]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id
WHERE     (dbo.SYS_DOC_Type.Name IN (''TAX Invoice'', ''Credit Note''))' 
GO 

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'VW_DashboardSales', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_DashboardSales'

GO

IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'VW_DashboardSales', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_DashboardSales'

GO

/****** Object:  View [dbo].[VW_DashboardSales]    Script Date: 2015/06/15 11:09:46 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_DashboardSales]'))
DROP VIEW [dbo].[VW_DashboardSales]
GO

/****** Object:  View [dbo].[VW_DashboardSales]    Script Date: 2015/06/15 11:09:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_DashboardSales]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_DashboardSales]
AS
SELECT     
ISNULL(ROW_NUMBER() OVER(ORDER BY dbo.VW_TransactionSales.DatePosted DESC) ,0) AS Id
, CAST(dbo.VW_TransactionSales.DatePosted as Date) as [Date]
, CAST(CONVERT(DATETIME, CONVERT(VARCHAR(50), dbo.VW_TransactionSales.DatePosted, 120)) AS TIME) AS Time
, PeriodCode
, PeriodFinancialYear
, RepCode
, SalesManCode
, AreaCode
, SUM(UnitPrice * QuantityBalance) AS Amount
, CreatedBy
, CreatedById
FROM         dbo.VW_TransactionSales
GROUP BY dbo.VW_TransactionSales.DatePosted
, PeriodCode
, PeriodFinancialYear
, RepCode
, SalesManCode
, AreaCode
, QuantityBalance
, UnitPrice
, CreatedBy
, CreatedById
' 
GO

/****** Object:  View [dbo].[VW_Line]    Script Date: 2015/06/17 01:36:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Line]
AS
SELECT    L.Id, H.Id AS HeaderId, AE.Id AS AccountId, R.Id AS ReconId, AE.Title AS AccountTitle, H.Reference AS HeaderReference, ISNULL(H.Description, '') 
					  AS HeaderDescription, A.Code AS AgingCode, L.Amount, AE.Name AS AccountName, AE.Description AS AccountDescription, CASE WHEN R.Id IS NULL 
					  THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END AS IsReconned, H.Date AS HeaderDate, CAST(H.Date AS DATE) AS HeaderDay, H.TrackId, 
					  H.CreatedOn AS HeaderCreatedOn, PN.Fullname AS HeaderCreatedBy, S.Name AS StatusCode, ISNULL(Center.CodeMain, '') AS CenterCode, 
					  ROW_NUMBER ( ) OVER (ORDER BY L.Id) AS RowNumber /*Here for Web Portal Infinite Scroll*/
					, P.Code AS PeriodCode                      
					, P.Code AS FinancialPeriod					/*---|					 */
					, P.StartDate AS Date						/*   | HERE FOR Analytics*/
					, P.FinancialYear AS FinancialYear			/*   |					 */
					, P.FinancialQuarter AS FinancialQuarter	/*---|					 */
FROM         dbo.GLX_Header AS H INNER JOIN
					  dbo.GLX_Line AS L ON H.Id = L.HeaderId LEFT JOIN
					  dbo.SYS_Entity AS AE ON L.EntityId = AE.Id LEFT JOIN
					  dbo.SYS_Person AS PN ON H.CreatedBy = PN.Id LEFT JOIN
					  dbo.GLX_Account AS ACC ON AE.Id = ACC.EntityId LEFT OUTER JOIN
					  dbo.VW_Center AS Center ON ACC.CenterId = Center.Id INNER JOIN
					  dbo.SYS_Period AS P ON H.PeriodId = P.Id LEFT OUTER JOIN
					  dbo.SYS_Status AS S ON H.StatusId = S.Id LEFT OUTER JOIN
					  dbo.GLX_Aging AS A ON L.AgingId = A.Id LEFT OUTER JOIN
					  dbo.GLX_Recon AS R ON L.ReconId = R.Id
GO
--Werner Scheffer

/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/22 11:21:28 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
DROP VIEW [dbo].[VW_Transaction]
GO

/****** Object:  View [dbo].[VW_Transaction]    Script Date: 2015/06/22 11:21:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Transaction]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Transaction]
AS
SELECT     
  dbo.SYS_DOC_Line.Id
, dbo.SYS_DOC_Header.TypeId
, dbo.SYS_DOC_Header.Id AS DocumentId
, ITM_Item.Id ItemId
, dbo.ITM_Inventory.Id InventoryId
, VW_Company.Id CompanyId
, VW_Company.TypeId CompanyTypeId
, dbo.SYS_DOC_Type.Name AS DocumentType
, dbo.SYS_DOC_Header.DocumentNumber
, dbo.SYS_DOC_Header.TrackId AS TackingNumber
, COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS DatePosted
, VW_Site.Name AS SiteName
, VW_Company.Name AS CompanyName
, VW_Company.Code AS CompanyCode
, ITM_Item.Name AS ItemCode
, ITM_Item.ShortName AS ItemName
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.HoldingModifier AS QuantityHolding
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.BalanceModifier AS QuantityBalance
, dbo.SYS_DOC_Line.Quantity * dbo.SYS_DOC_Type.StockModifier AS QuantityStock
, dbo.ITM_Movement.OnHand
, dbo.ITM_Movement.OnReserve
, dbo.ITM_Movement.OnOrder
, dbo.ITM_Movement.UnitPrice
, dbo.ITM_Movement.UnitCost
, dbo.ITM_Movement.UnitAverage
, dbo.SYS_DOC_Line.Amount
, dbo.SYS_DOC_Line.DiscountPercentage
, dbo.SYS_DOC_Line.Description
, dbo.SYS_DOC_Line.Total
, dbo.SYS_DOC_Line.TotalTax
, dbo.SYS_DOC_Line.CreatedOn
, dbo.SEC_User.DisplayName CreatedBy
, dbo.SYS_DOC_Header.CreatedBy CreatedById
, VW_Company.AreaCode AS AreaCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong1	,dbo.JOB_Header.ReferenceLong1		) AS YourReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong2	,dbo.JOB_Header.ReferenceLong2		) AS OurReference
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong3	,dbo.JOB_Header.ReferenceLong3		) AS ReferenceLong3
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong4	,dbo.JOB_Header.ReferenceLong4		) AS ReferenceLong4
, COALESCE(dbo.ORG_TRX_Header.ReferenceLong5	,dbo.JOB_Header.ReferenceLong5		) AS ReferenceLong5
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort1	,dbo.JOB_Header.ReferenceShort1		) AS OrderNumber
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort2	,dbo.JOB_Header.ReferenceShort2		) AS RepCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort3	,dbo.JOB_Header.ReferenceShort3		) AS SalesManCode
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort4	,dbo.JOB_Header.ReferenceShort4		) AS ReferenceShort4
, COALESCE(dbo.ORG_TRX_Header.ReferenceShort5	,dbo.JOB_Header.ReferenceShort5		) AS ReferenceShort5
, COALESCE(dbo.ORG_TRX_Header.DateFirstPrinted	,dbo.JOB_Header.DateFirstPrinted	) AS DateFirstPrinted
, COALESCE(dbo.ORG_TRX_Header.DateLastPrinted	,dbo.JOB_Header.DateLastPrinted		) AS DateLastPrinted
, COALESCE(dbo.ORG_TRX_Header.DateValid			,NULL								) AS DateValid
, COALESCE(dbo.ORG_TRX_Header.TotalCash			,0.00								) AS TotalCash
, COALESCE(dbo.ORG_TRX_Header.TotalCredit		,0.00								) AS TotalCredit
, COALESCE(dbo.ORG_TRX_Header.TotalAccount		,0.00								) AS TotalAccount
, COALESCE(dbo.ORG_TRX_Header.Rounding			,0.00								) AS Rounding
, dbo.SYS_Period.Id AS PeriodId
, dbo.SYS_Period.Code AS PeriodCode 
, dbo.SYS_Period.EndDate AS PeriodEndDate
, dbo.SYS_Period.FinancialYear AS PeriodFinancialYear
, dbo.SYS_Period.Code AS FinancialPeriod												  /*---|					 */
, CAST(COALESCE(dbo.ORG_TRX_Header.DatePosted, dbo.JOB_Header.CreatedOn) AS Date) AS Date /*   | HERE FOR Analytics  */
, dbo.SYS_Period.FinancialYear AS FinancialYear											  /*   |					 */
, dbo.SYS_Period.FinancialQuarter AS FinancialQuarter									  /*---|					 */
FROM     
dbo.SYS_DOC_Line
LEFT JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId 
LEFT JOIN dbo.SYS_DOC_Type ON dbo.SYS_DOC_Header.TypeId = dbo.SYS_DOC_Type.Id 
LEFT JOIN dbo.SYS_Entity AS ITM_Item ON dbo.SYS_DOC_Line.ItemId = ITM_Item.Id 
LEFT JOIN dbo.VW_Site ON dbo.SYS_DOC_Header.SiteId = VW_Site.Id  
LEFT JOIN dbo.ITM_Inventory ON ITM_Item.Id = dbo.ITM_Inventory.EntityId AND dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id
LEFT JOIN dbo.SYS_Person on dbo.SYS_DOC_Header.CreatedBy = dbo.SYS_Person.Id
LEFT JOIN dbo.SEC_User ON dbo.SYS_Person.Id = dbo.SEC_User.PersonId 
LEFT JOIN dbo.ITM_Movement ON dbo.SYS_DOC_Line.Id = dbo.ITM_Movement.LineId 
LEFT JOIN dbo.ORG_TRX_Header ON dbo.SYS_DOC_Header.Id = dbo.ORG_TRX_Header.HeaderId 
LEFT JOIN dbo.JOB_Header ON dbo.SYS_DOC_Header.Id = dbo.JOB_Header.HeaderId 
LEFT JOIN dbo.VW_Company ON COALESCE(dbo.ORG_TRX_Header.CompanyId,dbo.JOB_Header.CompanyId) = dbo.VW_Company.Id
LEFT JOIN dbo.SYS_Period ON SYS_DOC_Header.CreatedOn BETWEEN dbo.SYS_Period.StartDate AND dbo.SYS_Period.EndDate
' 
GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/22 11:32:47 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
DROP VIEW [dbo].[VW_TransactionPurchases]
GO

/****** Object:  View [dbo].[VW_TransactionPurchases]    Script Date: 2015/06/22 11:32:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionPurchases]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionPurchases]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id 
WHERE     (dbo.SYS_DOC_Type.Name IN (''Goods Received'', ''Goods Returned''))
' 
GO

/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/22 11:32:57 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
DROP VIEW [dbo].[VW_TransactionSales]
GO

/****** Object:  View [dbo].[VW_TransactionSales]    Script Date: 2015/06/22 11:32:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_TransactionSales]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_TransactionSales]
AS
SELECT     VW_Transaction.*
FROM         dbo.VW_Transaction INNER JOIN
					  dbo.SYS_DOC_Type ON dbo.VW_Transaction.TypeId = dbo.SYS_DOC_Type.Id
WHERE     (dbo.SYS_DOC_Type.Name IN (''TAX Invoice'', ''Credit Note''))
' 
GO
/****** Object:  View [dbo].[VW_DashboardSales]    Script Date: 2015/06/22 11:48:31 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_DashboardSales]'))
DROP VIEW [dbo].[VW_DashboardSales]
GO

/****** Object:  View [dbo].[VW_DashboardSales]    Script Date: 2015/06/22 11:42:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VW_DashboardSales]
AS
SELECT     
--CAST(ROW_NUMBER() OVER(ORDER BY dbo.VW_TransactionSales.DatePosted DESC) AS bigint) AS Id
  ISNULL(Id,0) AS Id
, CAST(dbo.VW_TransactionSales.DatePosted as Date) as [Date]
, CAST(CONVERT(DATETIME, CONVERT(VARCHAR(50), dbo.VW_TransactionSales.DatePosted, 120)) AS TIME) AS Time
, PeriodCode
, PeriodFinancialYear
, RepCode
, SalesManCode
, AreaCode
, SUM(UnitPrice * QuantityBalance) AS Amount
, CreatedBy
, CreatedById
FROM         dbo.VW_TransactionSales
GROUP BY Id,dbo.VW_TransactionSales.DatePosted
, PeriodCode
, PeriodFinancialYear
, RepCode
, SalesManCode
, AreaCode
, QuantityBalance
, UnitPrice
, CreatedBy
, CreatedById
GO
 /****** Object:  Index [IDX_VW_Transaction_Item]    Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Line]') AND name = N'IDX_VW_Transaction_Item')
DROP INDEX [IDX_VW_Transaction_Item] ON [dbo].[SYS_DOC_Line]
GO

/****** Object:  Index [IDX_VW_Transaction_Item]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Line]') AND name = N'IDX_VW_Transaction_Item')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_Item] ON [dbo].[SYS_DOC_Line]
(
	[ItemId] ASC
)
INCLUDE ( 	[Id],
	[HeaderId],
	[DiscountPercentage],
	[Description],
	[Quantity],
	[Amount],
	[Total],
	[TotalTax],
	[CreatedOn]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO

/****** Object:  Index [IDX_VW_Transaction_Site]   Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ITM_Inventory]') AND name = N'IDX_VW_Transaction_Site')
DROP INDEX [IDX_VW_Transaction_Site] ON [dbo].[ITM_Inventory]
GO

/****** Object:  Index [IDX_VW_Transaction_Site]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ITM_Inventory]') AND name = N'IDX_VW_Transaction_Site')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_Site] ON [dbo].[ITM_Inventory] 
(
	[SiteId]
)
INCLUDE (	[Id],
	[EntityId]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ITM_Movement]') AND name = N'IDX_VW_Transaction_Line')
DROP INDEX [IDX_VW_Transaction_Line] ON [dbo].[ITM_Movement]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ITM_Movement]') AND name = N'IDX_VW_Transaction_Line')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_Line] ON [dbo].[ITM_Movement] 
(
	[LineId]
)
INCLUDE (	[OnHand],
	[OnOrder],
	[OnReserve],
	[UnitCost],
	[UnitPrice],
	[UnitAverage]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ORG_TRX_Header]') AND name = N'IDX_VW_Transaction_TRX_Header')
DROP INDEX [IDX_VW_Transaction_TRX_Header] ON [dbo].[ORG_TRX_Header]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ORG_TRX_Header]') AND name = N'IDX_VW_Transaction_TRX_Header')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_TRX_Header] ON [dbo].[ORG_TRX_Header] 
(
	[HeaderId]
)
INCLUDE (	[CompanyId],
	[DatePosted],
	[DateFirstPrinted],
	[DateLastPrinted],
	[DateValid],
	[ReferenceShort1],
	[ReferenceShort2],
	[ReferenceShort3],
	[ReferenceShort4],
	[ReferenceShort5],
	[ReferenceLong1],
	[ReferenceLong2],
	[ReferenceLong3],
	[ReferenceLong4],
	[ReferenceLong5],
	[Rounding],
	[TotalCash],
	[TotalCredit],
	[TotalAccount]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO


/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Header]') AND name = N'IDX_VW_Transaction_Type')
DROP INDEX [IDX_VW_Transaction_Type] ON [dbo].[SYS_DOC_Header]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Header]') AND name = N'IDX_VW_Transaction_Type')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_Type] ON [dbo].[SYS_DOC_Header] 
(
	[TypeId]
)
INCLUDE (	[Id],
	[TrackId],
	[SiteId],
	[DocumentNumber],
	[CreatedOn],
	[CreatedBy]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO
/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Line]') AND name = N'IDX_VW_Transaction_DOC_Header')
DROP INDEX [IDX_VW_Transaction_DOC_Header] ON [dbo].[SYS_DOC_Line]
GO

/****** Object:  Index [IDX_VW_Transaction_Line]    Script Date: 2015/06/22 12:12:10 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[SYS_DOC_Line]') AND name = N'IDX_VW_Transaction_DOC_Header')
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_DOC_Header] ON [dbo].[SYS_DOC_Line] 
(	
	[HeaderId]
)
INCLUDE (	[Id],
	[ItemId],
	[DiscountPercentage],
	[Description],
	[Quantity],
	[Amount],
	[Total],
	[TotalTax],
	[CreatedOn]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [IDX]
GO
--Werner Scheffer
/****** Object:  View [dbo].[VW_Budget]    Script Date: 2015/06/23 02:12:06 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Budget]'))
DROP VIEW [dbo].[VW_Budget]
GO

/****** Object:  View [dbo].[VW_Budget]    Script Date: 2015/06/23 02:12:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Budget]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Budget]
AS
SELECT ROW_NUMBER() OVER(ORDER BY [EntryType] DESC) AS Id,* FROM (
SELECT 
''Amount'' AS [EntryType]
, AE.Id AS AccountId
, SUM(B.Amount) AS Amount   
, P.StartDate AS PeriodStartDate
, P.EndDate AS PeriodEndDate
, P.Code AS PeriodCode
, AE.CodeMain+''-''+AE.CodeSub AS AccountCode
, AE.Name AS AccountName 
, S.Name AS StatusCode
, T.Name AS TypeCode  
, P.FinancialYear AS FinancialYear
FROM
	dbo.GLX_Account ACC
	INNER JOIN SYS_Entity AE ON ACC.EntityId=AE.Id
	INNER JOIN dbo.GLX_Budget BU ON AE.Id = BU.EntityId 
	LEFT JOIN dbo.GLX_Account child ON child.MasterControlId=ACC.EntityId OR (child.EntityId=ACC.EntityId)
	INNER JOIN SYS_Entity ChildE ON child.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_History B ON B.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_Aging A ON B.AgingId = A.Id and A.Id = 1
	INNER JOIN dbo.SYS_Period P ON B.PeriodId = P.Id 
	INNER JOIN dbo.GLX_Type T ON ACC.ACcountTypeId = T.Id
	INNER JOIN dbo.SYS_Status S ON P.StatusId = S.Id 
GROUP BY 
	ACC.Id
	,A.Code
	,P.StartDate
	, P.EndDate
	, P.Code
	, AE.CodeMain
	, AE.CodeSub
	, AE.Name
	, AE.Description
	, ACC.BalanceGroup
	, S.Name
	, T.Name
	, A.Id
	, P.Id
	, AE.Id
	, S.Id
	, T.Id
	, ACC.MasterControlId
	, T.Flag1
	, T.Flag2
	, P.FinancialYear
UNION ALL
SELECT 
''Budget'' AS [EntryType] 
, AE.Id AS AccountId
, SUM(ISNULL(BU.Amount,0)) AS Amount  
, P.StartDate AS PeriodStartDate
, P.EndDate AS PeriodEndDate
, P.Code AS PeriodCode
, AE.CodeMain+''-''+AE.CodeSub AS AccountCode
, AE.Name AS AccountName 
, S.Name AS StatusCode
, T.Name AS TypeCode 
, P.FinancialYear AS FinancialYear
FROM
	dbo.GLX_Account ACC
	INNER JOIN SYS_Entity AE ON ACC.EntityId=AE.Id
	LEFT JOIN dbo.GLX_Account child ON child.MasterControlId=ACC.EntityId OR (child.EntityId=ACC.EntityId)
	INNER JOIN SYS_Entity ChildE ON child.EntityId=ChildE.Id
	INNER JOIN dbo.GLX_Type T ON ACC.ACcountTypeId = T.Id
	LEFT JOIN dbo.GLX_Budget BU ON AE.Id = BU.EntityId 
	INNER JOIN dbo.SYS_Period P ON P.Id = BU.PeriodId
	INNER JOIN dbo.SYS_Status S ON P.StatusId = S.Id
GROUP BY 
	ACC.Id
	,P.StartDate
	, P.EndDate
	, P.Code
	, AE.CodeMain
	, AE.CodeSub
	, AE.Name
	, AE.Description
	, ACC.BalanceGroup
	, S.Name
	, T.Name 
	, P.Id
	, AE.Id
	, S.Id
	, T.Id
	, ACC.MasterControlId
	, T.Flag1
	, T.Flag2
	, P.FinancialYear) AS X
' 
GO


--Werner Scheffer

/****** Object:  View [dbo].[VW_OnHold]    Script Date: 2015/06/26 09:46:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_OnHold]
AS
WITH VW_DocumentLineBackOrder (ItemId,SiteId,Quantity,QuantityInvoiced)
AS
(
	SELECT 
	ItemId
	,SiteId
	,(Quantity) Quantity
	,ISNULL((select SUM(Quantity) from VW_DocumentLine iVW_DocumentLine 
	INNER JOIN SYS_DOC_Type iSYS_DOC_Type ON 
	iVW_DocumentLine.TypeId = iSYS_DOC_Type.Id 
	and iVW_DocumentLine.CreatedOn > eVW_DocumentLine.CreatedOn 
	and iVW_DocumentLine.ItemId = eVW_DocumentLine.ItemId 
	and iVW_DocumentLine.TrackId = eVW_DocumentLine.TrackId 
	WHERE   iSYS_DOC_Type.Name IN ('TAX Invoice')),0) QuantityInvoiced
	FROM	VW_DocumentLine eVW_DocumentLine 
			INNER JOIN SYS_DOC_Type eSYS_DOC_Type ON eVW_DocumentLine.TypeId = eSYS_DOC_Type.Id
	WHERE     Name IN ('Back Order')
)

SELECT ItemId,SiteId,SUM(IIF(QuantityInvoiced<=Quantity,Quantity-QuantityInvoiced,0)) Quantity
FROM VW_DocumentLineBackOrder 
GROUP BY ItemId,SiteId

GO
/****** Object:  View [dbo].[VW_Company]    Script Date: 2015/06/29 11:34:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[VW_Company]
AS
SELECT	
 dbo.ORG_Company.Id AS Id
 , dbo.SYS_Entity.Id AS EntityId
 , dbo.ORG_Entity.Id AS OrgEntityId
 , dbo.ORG_Company.AccountId
 , dbo.ORG_Type.Id AS TypeId
 , dbo.ORG_Type.Name AS Type 
 , dbo.ORG_Company.Prefix + dbo.SYS_Entity.CodeSub AS Code
 , dbo.SYS_Entity.Name
 , dbo.SYS_Entity.Archived
 , SYS_Person_Accounts.Name AS AccountsContact
 , SYS_Person_Sales.Name AS SalesContact
 , ORG_Contact_Accounts.Telephone1 AS AccountsTelephone
 , ORG_Contact_Sales.Telephone1 AS SalesTelephone
 , dbo.ORG_Company.CreatedOn
 , dbo.ORG_Company.CreatedBy
 , ((isnull(nullif(ORG_Company.Prefix,'')+'','')+isnull(nullif(SYS_Entity.CodeSub,'')+' - ',''))+SYS_Entity.Name) Title
 , dbo.ORG_Entity.RegistrationNumber
 , dbo.ORG_Entity.VatNumber
 , dbo.ORG_Entity.Note
 , dbo.ORG_Company.PaymentTermId
 , dbo.ORG_Company.CostCategoryId
 , dbo.ORG_Company.OpenItem
 , dbo.ORG_Company.Active
 , dbo.ORG_Company.OverrideAccount
 , dbo.ORG_Company.DiscountCode
 , dbo.ORG_Company.TagCode
 , dbo.ORG_Company.CountryCode
 , dbo.ORG_Company.StatementPreference
 , dbo.ORG_Company.SalesmanCode
 , dbo.ORG_Company.AreaCode
 , dbo.ORG_Company.RepCode
 , dbo.ORG_Company.URL
 , dbo.ORG_Company.Username
 , dbo.ORG_Company.Password
 , dbo.ORG_Company.CustomValue1
 , dbo.ORG_Company.CustomValue2
 , dbo.ORG_Company.CustomValue3
 , dbo.ORG_Company.CustomValue4
 , dbo.ORG_Company.CustomValue5
 , dbo.ORG_Company.CustomValue6
FROM dbo.SYS_Entity 
INNER JOIN dbo.ORG_Entity ON dbo.SYS_Entity.Id = dbo.ORG_Entity.EntityId 
INNER JOIN dbo.ORG_Company ON dbo.ORG_Entity.Id = dbo.ORG_Company.EntityId 
INNER JOIN dbo.ORG_Type ON dbo.ORG_Company.TypeId = dbo.ORG_Type.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Accounts ON dbo.ORG_Entity.EntityId = ORG_Contact_Accounts.CompanyId AND ORG_Contact_Accounts.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Accounts')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Accounts ON ORG_Contact_Accounts.PersonId = SYS_Person_Accounts.Id 
LEFT OUTER JOIN dbo.ORG_Contact AS ORG_Contact_Sales ON dbo.ORG_Entity.EntityId = ORG_Contact_Sales.CompanyId AND ORG_Contact_Sales.DepartmentId = (SELECT Id FROM dbo.ORG_Department WHERE (Name = 'Sales')) 
LEFT OUTER JOIN dbo.SYS_Person AS SYS_Person_Sales ON ORG_Contact_Sales.PersonId = SYS_Person_Sales.Id
GO
 

/****** Object:  View [dbo].[VW_OutstandingTransfers]    Script Date: 2015/06/30 12:41:30 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_OutstandingTransfers]'))
DROP VIEW [dbo].[VW_OutstandingTransfers]
GO

/****** Object:  View [dbo].[VW_OutstandingTransfers]    Script Date: 2015/06/30 12:41:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_OutstandingTransfers]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_OutstandingTransfers]
AS
WITH VW_TransferQuantity (SiteId,Warehouse,InventoryId,Quantity)
AS
(
 SELECT  VW_Site.Id SiteId,VW_Site.Name Warehouse,ITM_Inventory.Id InventoryId,SUM(ISNULL(CASE SYS_DOC_Header.TypeId WHEN 11 THEN Quantity ELSE -Quantity End ,0)) Quantity
 FROM	dbo.ITM_Inventory 
		INNER JOIN dbo.VW_Site  ON dbo.VW_Site.Id = dbo.ITM_Inventory.SiteId 
		LEFT JOIN dbo.SYS_DOC_Header ON dbo.SYS_DOC_Header.SiteId = dbo.VW_Site.Id   AND dbo.SYS_DOC_Header.TypeId IN (11,12)
		LEFT JOIN dbo.SYS_DOC_Line ON dbo.SYS_DOC_Header.Id = dbo.SYS_DOC_Line.HeaderId    
 GROUP BY VW_Site.Id, VW_Site.Name,ITM_Inventory.Id
)

SELECT 
VW_TransferQuantity.SiteId AS Id
,VW_Inventory.Id AS InventoryId
,VW_Inventory.EntityId
,VW_Inventory.SiteId
,VW_Inventory.Site
,VW_Inventory.ShortName
,VW_Inventory.OnHand
,VW_Inventory.OnReserve
,VW_Inventory.OnOrder
,VW_Inventory.UnitCost
,VW_TransferQuantity.Quantity InTransit
from VW_Inventory LEFT JOIN  VW_TransferQuantity ON VW_Inventory.Id = VW_TransferQuantity.InventoryId 
' 
GO
IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'SellingPackSize' AND [object_id] = OBJECT_ID(N'ITM_Inventory'))
BEGIN
	ALTER TABLE ITM_Inventory ADD [SellingPackSize] [decimal](18, 4) NULL CONSTRAINT [DF_ITM_Inventory_SellingPackSize]  DEFAULT ((1))
END

/****** Object:  View [dbo].[VW_LineItem]    Script Date: 2015/06/30 02:19:17 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_LineItem]'))
DROP VIEW [dbo].[VW_LineItem]
GO

/****** Object:  View [dbo].[VW_LineItem]    Script Date: 2015/06/30 02:19:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_LineItem]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_LineItem]
AS
SELECT 
dbo.SYS_Entity.Id AS Id
, dbo.ITM_Inventory.Id AS InventoryId
, dbo.GLX_Account.Id AS AccountId
, dbo.GLX_Account.AccountTypeId AS AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Type.Name AS Type
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS CreatedOn
, dbo.SYS_Person.CreatedBy AS CreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial
, dbo.ITM_Inventory.SellingPackSize
--, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
--, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(dbo.ITM_History.OnHand, 0) AS OnHand
, ISNULL(dbo.ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(dbo.ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(dbo.ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(dbo.ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(dbo.ITM_History.UnitAverage, 0) AS UnitAverage
, SUM(ISNULL(dbo.GLX_History.Amount, 0)) AS BalanceAmount
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
--, dbo.SYS_Entity.CodeMain + ''	'' + ISNULL(SYS_Entity.Name, '''') AS Title
, dbo.SYS_Entity.Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.SYS_Person ON  dbo.SYS_Entity.CreatedBy = dbo.SYS_Person.Id
INNER JOIN dbo.SYS_Type ON dbo.SYS_Entity.TypeId = dbo.SYS_Type.Id
LEFT JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
LEFT JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
LEFT JOIN dbo.ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId and ITM_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
LEFT JOIN dbo.GLX_Account ON dbo.SYS_Entity.Id = dbo.GLX_Account.EntityId 
LEFT JOIN dbo.GLX_History WITH (nolock) ON dbo.GLX_Account.EntityId = GLX_History.EntityId and GLX_History.PeriodId = (select top 1 id from dbo.fnCurrentPeriod())
--LEFT JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and dbo.ITM_InventorySupplier.PrimarySupplier = 1
WHERE SYS_Entity.TypeId in (4,5,6,7)
GROUP BY 
dbo.SYS_Entity.Id  
, dbo.ITM_Inventory.Id  
, dbo.GLX_Account.Id  
, dbo.GLX_Account.AccountTypeId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id  
, dbo.SYS_Type.Name
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.CodeMain
, dbo.SYS_Entity.CodeSub
, dbo.ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn 
, dbo.SYS_Person.CreatedBy  
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.CostofSalesId
, dbo.ITM_Inventory.RequireSerial 
, dbo.ITM_Inventory.SellingPackSize
, ISNULL(dbo.ITM_History.OnHand, 0)  
, ISNULL(dbo.ITM_History.OnReserve, 0) 
, ISNULL(dbo.ITM_History.OnOrder, 0) 
, ISNULL(dbo.ITM_History.UnitPrice, 0) 
, ISNULL(dbo.ITM_History.UnitCost, 0)  
, ISNULL(dbo.ITM_History.UnitAverage, 0)
, dbo.ITM_History.FirstSold
, dbo.ITM_History.FirstPurchased
, dbo.ITM_History.LastSold
, dbo.ITM_History.LastPurchased
, dbo.ITM_History.LastMovement
, dbo.VW_Site.Name  
, dbo.SYS_Entity.Title
' 
GO

/****** Object:  View [dbo].[VW_Alternative]    Script Date: 2015/06/30 05:10:43 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Alternative]'))
DROP VIEW [dbo].[VW_Alternative]
GO

/****** Object:  View [dbo].[VW_Alternative]    Script Date: 2015/06/30 05:10:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Alternative]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Alternative]
AS
SELECT DISTINCT AlternativeItem.Id, AlternativeItem.EntityId, SearchItem.Name AS SearchItemName, AlternativeItem.Name AS AlternativeItemName, dbo.VW_Inventory.ShortName, dbo.VW_Inventory.OnHand
FROM            dbo.CAT_ItemData AS AlternativeData INNER JOIN
						 dbo.CAT_ItemData AS SearchItemData ON AlternativeData.CategoryId = SearchItemData.CategoryId AND 
						 AlternativeData.ParentItemId = SearchItemData.ParentItemId INNER JOIN
						 dbo.CAT_Item AS AlternativeItem ON AlternativeData.ItemId = AlternativeItem.Id INNER JOIN
						 dbo.CAT_Item AS SearchItem ON SearchItemData.ItemId = SearchItem.Id INNER JOIN
						 dbo.VW_Inventory ON AlternativeItem.EntityId = dbo.VW_Inventory.EntityId
WHERE        (AlternativeItem.EntityId IS NOT NULL) 
' 
GO
IF NOT EXISTS(SELECT * FROM sys.columns 
		WHERE [name] = N'UserId' AND [object_id] = OBJECT_ID(N'SYS_Layout'))
BEGIN
	ALTER TABLE SYS_Layout ADD [UserId] [bigint] NULL
END
 
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SYS_Layout_SEC_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[SYS_Layout]'))
	ALTER TABLE [dbo].[SYS_Layout]  WITH CHECK ADD  CONSTRAINT [FK_SYS_Layout_SEC_User] FOREIGN KEY([UserId])
	REFERENCES [dbo].[SEC_User] ([Id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SYS_Layout_SEC_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[SYS_Layout]'))
	ALTER TABLE [dbo].[SYS_Layout] CHECK CONSTRAINT [FK_SYS_Layout_SEC_User]
GO
 
/****** Object:  View [dbo].[VW_Role]    Script Date: 2015/07/02 09:50:52 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Role]'))
DROP VIEW [dbo].[VW_Role]
GO

/****** Object:  View [dbo].[VW_Role]    Script Date: 2015/07/02 09:50:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Role]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Role]
AS
SELECT Id, Code, Name
FROM dbo.SEC_Role
' 
GO 
--Werner Scheffer
--Jan de Bruyn
/****** Object:  View [dbo].[VW_PaymentItems]    Script Date: 2015/07/08 10:43:56 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_PaymentItems]'))
DROP VIEW [dbo].[VW_PaymentItems]
GO

/****** Object:  View [dbo].[VW_PaymentItems]    Script Date: 2015/07/08 10:43:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_PaymentItems]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_PaymentItems]
AS
SELECT
	''OI'' Type,
	a.Id AS AccountId, 
	a.Title, 
	STUFF(MAX(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, h.Reference)), 1, 19, '''') AS Reference, 
	STUFF(MAX(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, t.Initiator)), 1, 19, '''') AS Description, 
	MIN(h.Date) Date, 
	t.Initiator AS Internal,
	SUM(l.Amount) AS Balance,
	MIN(p.Id) PeriodId,
	MIN(p.Code) Period,
	min(ag.Id) AgingId, 
	STUFF(MIN(CONVERT(VARCHAR, h.Date, 20) + CONVERT(VARCHAR, ag.Code)), 1, 19, '''') AS Aging, 
	h.TrackId AS TrackNumber, 
	a.Name, 
	a.CodeSub,
	a.CodeMain, 
	min(l.Id) as LineId,
	min(h.Id) as HeaderId,
	min(sa.TypeId) AS TypeId
FROM 
	GLX_Header h 
	INNER JOIN GLX_Line l ON l.HeaderId=h.Id 
	INNER JOIN SYS_Tracking t ON h.TrackId = t.Id
	INNER JOIN VW_Account a ON l.EntityId=a.Id
	INNER JOIN SYS_Period p ON h.PeriodId=p.Id
	INNER JOIN GLX_Aging ag ON l.AgingId=ag.Id
	INNER JOIN VW_Company e ON e.AccountId=a.Id
	INNER JOIN GLX_SiteAccount sa ON a.ControlId=sa.EntityId
WHERE  
	e.OpenItem=1
GROUP BY 
	h.TrackId, h.StatusId, a.Id, a.Name, a.CodeSub, a.CodeMain, a.Title, t.Initiator
HAVING 
	SUM(l.Amount)<>0

UNION

SELECT 
	''BBF'' Type,
	a.Id AS AccountId, 
	a.Title, 
	'''' AS Reference, 
	''Oustanding on ''+ag.Code AS Description, 
	pe.EndDate Date, 
	'''' AS Internal,
	ba.Amount AS Balance,
	pe.Id PeriodId,
	pe.Code Period,
	ag.Id AgingId, 
	ag.Code Aging, 
	NULL AS TrackNumber, 
	a.Name, 
	a.CodeSub,
	a.CodeMain, 
	NULL AS LineId,
	NULL AS HeaderId,
	sa.TypeId AS TypeId
FROM 
	VW_Account a 
	INNER JOIN GLX_History ba ON ba.EntityId=a.Id
	INNER JOIN SYS_Period pe ON ba.PeriodId=pe.Id
	INNER JOIN GLX_Aging ag ON ba.AgingId=ag.Id
	INNER JOIN VW_Company e ON e.AccountId=a.id
	INNER JOIN GLX_Account ga ON a.ControlId=ga.EntityId
	INNER JOIN GLX_SiteAccount sa ON ga.EntityId=sa.EntityId
WHERE 
	e.OpenItem=0
	AND ba.Amount<>0
' 
GO


/****** Object:  View [dbo].[VW_PayableItems]    Script Date: 2015/07/08 10:44:31 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_PayableItems]'))
DROP VIEW [dbo].[VW_PayableItems]
GO

/****** Object:  View [dbo].[VW_PayableItems]    Script Date: 2015/07/08 10:44:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_PayableItems]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_PayableItems]
AS
SELECT
	 [VW_PaymentItems].* from [VW_PaymentItems]
	 INNER JOIN GLX_SystemAccountType say ON [VW_PaymentItems].TypeId = say.Id AND say.Name = ''Creditors''
' 
GO 

/****** Object:  View [dbo].[VW_ReceivableItems]    Script Date: 2015/07/08 10:45:00 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_ReceivableItems]'))
DROP VIEW [dbo].[VW_ReceivableItems]
GO

/****** Object:  View [dbo].[VW_ReceivableItems]    Script Date: 2015/07/08 10:45:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_ReceivableItems]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_ReceivableItems]
AS
SELECT
	 [VW_PaymentItems].* from [VW_PaymentItems]
	 INNER JOIN GLX_SystemAccountType say ON [VW_PaymentItems].TypeId = say.Id AND say.Name = ''Debtors''
' 
GO
/****** Object:  View [dbo].[VW_Inventory]    Script Date: 2015/07/09 10:50:10 AM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Inventory]'))
DROP VIEW [dbo].[VW_Inventory]
GO

/****** Object:  View [dbo].[VW_Inventory]    Script Date: 2015/07/09 10:50:10 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Inventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Inventory]
AS
SELECT dbo.ITM_Inventory.Id
, dbo.SYS_Entity.Id AS EntityId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS ItemCreatedOn
, dbo.SYS_Entity.CreatedBy AS ItemCreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.Comment
, dbo.ITM_Inventory.SellingPackSize
, ISNULL(dbo.ITM_Inventory.CostofSalesId,0) AS CostofSalesId
, dbo.ITM_Inventory.RequireSerial
, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(ITM_History.OnHand, 0) AS OnHand
, ISNULL(ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(ITM_History.UnitAverage, 0) AS UnitAverage
, ITM_History.FirstSold
, ITM_History.FirstPurchased
, ITM_History.LastSold
, ITM_History.LastPurchased
, ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
, SYS_Entity.CodeMain + ''	'' + ISNULL(SYS_Entity.Name, '''') AS Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
INNER JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
INNER JOIN dbo.ITM_History AS ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId 
INNER JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and PrimarySupplier = 1
' 
GO
IF NOT EXISTS(select * from SEC_Access where Code = 'WSDOQT')
BEGIN
	SET IDENTITY_INSERT [dbo].[SEC_Access] ON
	insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (299,'WSDOQT','Job Quote','Job Quote',(select Id from SEC_Access where Code = 'WS'),NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
	insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (300,'WSDOQTRE','View','View',299,NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
	insert into SEC_Access (Id,Code,Name,Description,ParentId,CustomValue1,CustomValue2,CustomValue3,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy) values (301,'WSDOQTRECR','Create','Create',300,NULL,NULL,NULL,getdate(),NULL,NULL,NULL)
	SET IDENTITY_INSERT [dbo].[SEC_Access] OFF
END
GO
update SEC_Access set Name = 'Remove',Description='Remove lines from Job Card',ParentId = (select Id from SEC_Access where Code = 'WSDOJCREED'),Code = 'WSDOJCREED01' where Code = 'WSDOJCRE01'
GO
--Werner Scheffer

/****** Object:  UserDefinedFunction [dbo].[fnBalancePivot]    Script Date: 2015/07/13 06:30:00 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnBalancePivot]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnBalancePivot]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Werner Scheffer
-- Create date: 2015-07-10
-- Description:	Returns a pivot grid the the Balance and Budget amount for an Account
-- =============================================
CREATE FUNCTION fnBalancePivot 
(	
	@AccountId bigint
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT BalanceAmount.PeriodCode,BalanceAmount.PeriodEndDate,
	BalanceAmount.[120+]  	[BalanceAmount_120],
	BudgetAmount. [120+]  	[BudgetAmount_120],
	BalanceAmount.[090] 		[BalanceAmount_090],
	BudgetAmount. [090] 		[BudgetAmount_090],
	BalanceAmount.[060]  		[BalanceAmount_060], 
	BudgetAmount. [060]  		[BudgetAmount_060], 
	BalanceAmount.[030]  		[BalanceAmount_030], 
	BudgetAmount. [030]  		[BudgetAmount_030], 
	BalanceAmount.[000] 		[BalanceAmount_000], 
	BudgetAmount. [000]  		[BudgetAmount_000]
	from (
	SELECT AccountId,PeriodCode,PeriodEndDate,
	[000], [030], [060], [090], [120+]
	FROM
	(SELECT AccountId,PeriodCode,PeriodEndDate,AgingCode,BalanceAmount from VW_Balance where AccountId = @AccountId
	and PeriodEndDate > dateadd(month,-12,getdate()) and PeriodStartDate < getdate()) AS SourceTable
	PIVOT
	(
	SUM(BalanceAmount)
	FOR AgingCode IN ([000], [030], [060], [090], [120+])
	) AS PivotTable ) BalanceAmount inner join (
	SELECT AccountId,PeriodCode,PeriodEndDate,
	[000], [030], [060], [090], [120+]
	FROM
	(SELECT AccountId,PeriodCode,PeriodEndDate,AgingCode,BudgetAmount from VW_Balance where AccountId = @AccountId
	and PeriodEndDate > dateadd(month,-12,getdate()) and PeriodStartDate < getdate()) AS SourceTable
	PIVOT
	(
	SUM(BudgetAmount)
	FOR AgingCode IN ([000], [030], [060], [090], [120+])
	) AS PivotTable ) BudgetAmount  on BalanceAmount.PeriodCode = BudgetAmount.PeriodCode AND BalanceAmount.AccountId = BudgetAmount.AccountId
	where BalanceAmount.PeriodEndDate > dateadd(month,-12,getdate()) and BalanceAmount.periodenddate < getdate() 
)
GO
--Werner Scheffer
/****** Object:  View [dbo].[VW_Inventory]    Script Date: 2015/07/21 01:54:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Inventory]
AS
SELECT dbo.ITM_Inventory.Id
, dbo.SYS_Entity.Id AS EntityId
, dbo.SYS_Entity.TypeId
, dbo.VW_Site.Id AS SiteId
, dbo.SYS_Entity.ShortName
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, ITM_InventorySupplier.SupplierStockCode
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedOn AS ItemCreatedOn
, dbo.SYS_Entity.CreatedBy AS ItemCreatedBy
, dbo.ITM_Inventory.Category
, dbo.ITM_Inventory.SubCategory
, dbo.ITM_Inventory.StockType
, dbo.ITM_Inventory.LocationMain
, dbo.ITM_Inventory.LocationSecondary
, dbo.ITM_Inventory.Barcode
, dbo.ITM_Inventory.MinimumStockLevel
, dbo.ITM_Inventory.MaximumStockLevel
, dbo.ITM_Inventory.SafetyStock
, dbo.ITM_Inventory.WarehousingCost
, dbo.ITM_Inventory.DiscountCode
, dbo.ITM_Inventory.Grouping
, dbo.ITM_Inventory.ProfitMargin
, dbo.ITM_Inventory.LabelFlag
, dbo.ITM_Inventory.Comment
, dbo.ITM_Inventory.SellingPackSize
, ISNULL(dbo.ITM_Inventory.CostofSalesId,0) AS CostofSalesId
, ISNULL(dbo.ITM_Inventory.InventoryId,0) AS InventoryId
, dbo.ITM_Inventory.RequireSerial
, dbo.ITM_Inventory.CreatedOn AS InventoryCreatedOn
, dbo.ITM_Inventory.CreatedBy AS InventoryCreatedBy
, ISNULL(ITM_History.OnHand, 0) AS OnHand
, ISNULL(ITM_History.OnReserve, 0) AS OnReserve
, ISNULL(ITM_History.OnOrder, 0) AS OnOrder
, ISNULL(ITM_History.UnitPrice, 0) AS UnitPrice
, ISNULL(ITM_History.UnitCost, 0) AS UnitCost
, ISNULL(ITM_History.UnitAverage, 0) AS UnitAverage
, ITM_History.FirstSold
, ITM_History.FirstPurchased
, ITM_History.LastSold
, ITM_History.LastPurchased
, ITM_History.LastMovement
, dbo.VW_Site.Name AS Site
, SYS_Entity.CodeMain + '	' + ISNULL(SYS_Entity.Name, '') AS Title
FROM dbo.SYS_Entity 
INNER JOIN dbo.ITM_Inventory ON SYS_Entity.Id = dbo.ITM_Inventory.EntityId 
INNER JOIN dbo.VW_Site ON dbo.ITM_Inventory.SiteId = dbo.VW_Site.Id 
INNER JOIN dbo.ITM_History AS ITM_History WITH (nolock) ON dbo.ITM_Inventory.Id = ITM_History.InventoryId 
INNER JOIN dbo.fnCurrentPeriod() AS GLX_Period ON GLX_Period.Id = ITM_History.PeriodId
LEFT JOIN dbo.ITM_InventorySupplier ON dbo.ITM_Inventory.Id = dbo.ITM_InventorySupplier.InventoryId and PrimarySupplier = 1
GO
--Werner Scheffer

/****** Object:  View [dbo].[VW_Organisations]    Script Date: 2015/07/23 08:54:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VW_Organisations]
AS
SELECT	
dbo.SYS_Entity.Id
, dbo.SYS_Entity.CodeSub
, dbo.SYS_Entity.Name
, dbo.SYS_Entity.Description
, dbo.SYS_Entity.Archived
, dbo.SYS_Entity.CreatedBy
, dbo.SYS_Entity.CreatedOn
, dbo.SYS_Entity.Title
, dbo.ORG_Entity.RegistrationNumber
, dbo.ORG_Entity.VatNumber
, dbo.ORG_Entity.Note
, (SELECT CONVERT(BIT,ISNULL(COUNT(1),0)) FROM dbo.ORG_Company where ORG_Entity.Id = EntityId AND TypeId = 1) HasCustomer
, (SELECT CONVERT(BIT,ISNULL(COUNT(1),0)) FROM dbo.ORG_Company where ORG_Entity.Id = EntityId AND TypeId = 2) HasSupplier
FROM dbo.SYS_Entity 
INNER JOIN dbo.ORG_Entity ON dbo.SYS_Entity.Id = dbo.ORG_Entity.EntityId 
INNER JOIN dbo.SYS_Type ON dbo.SYS_Entity.TypeId=dbo.SYS_Type.Id
WHERE dbo.SYS_Type.Name='Company'
GO
--Werner Scheffer
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 1
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 2
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 3
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 4
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 7
UPDATE GLX_SystemAccountType set TypeId = 2 where Id = 5
UPDATE GLX_SystemAccountType set TypeId = 2 where Id = 6
UPDATE GLX_SystemAccountType set TypeId = 5 where Id = 8
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 9
UPDATE GLX_SystemAccountType set TypeId = 6 where Id = 10
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 11
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 12
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 13
UPDATE GLX_SystemAccountType set TypeId = 6 where Id = 14
UPDATE GLX_SystemAccountType set TypeId = 2 where Id = 16
UPDATE GLX_SystemAccountType set TypeId = 1 where Id = 17
UPDATE GLX_SystemAccountType set TypeId = 3 where Id = 18
UPDATE GLX_SystemAccountType set TypeId = 3 where Id = 19
UPDATE GLX_SystemAccountType set TypeId = 2 where Id = 20
UPDATE GLX_SystemAccountType set TypeId = 7 where Id = 21
UPDATE GLX_SystemAccountType set TypeId = 4 where Id = 22
UPDATE GLX_SystemAccountType set TypeId = 5 where Id = 23
GO
--Werner Scheffer


ALTER TABLE [dbo].[SYS_Tracking]
ADD [Archived] [bit] NOT NULL CONSTRAINT [DF_SYS_Tracking_Archived]  DEFAULT ((0))
GO

--Henko Rabie
--Werner Scheffer

/****** Object:  View [CDS_ORG].[VW_Company]    Script Date: 2015/10/06 1:41:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [CDS_ORG].[VW_Company]
AS
	 SELECT
			ORG_Company.Id AS Id
		  , SYS_Entity.Id AS EntityId
		  , ORG_Entity.Id AS OrgEntityId
		  , Account.Id AS AccountId
		  , ORG_Type.Id AS TypeId
		  , ORG_Type.Name AS Type
		  , ISNULL(ORG_Company.Prefix,'') + SYS_Entity.CodeSub AS Code
		  , SYS_Entity.Name
		  , SYS_Entity.Archived
		  , SYS_Person_Accounts.Name AS AccountsContact
		  , SYS_Person_Sales.Name AS SalesContact
		  , ORG_Contact_Accounts.Telephone1 AS AccountsTelephone
		  , ORG_Contact_Sales.Telephone1 AS SalesTelephone
		  , ORG_Company.CreatedOn
		  , ORG_Company.CreatedBy
		  , (( ISNULL(NULLIF(ORG_Company.Prefix, '') + '', '') + ISNULL(NULLIF(SYS_Entity.CodeSub, '') + ' - ', '')) + SYS_Entity.Name ) AS Title
		  , ORG_Entity.RegistrationNumber
		  , ORG_Entity.VatNumber
		  , ORG_Entity.Note
		  , ORG_Company.PaymentTermId
		  , ORG_Company.CostCategoryId
		  , ORG_Company.OpenItem
		  , ORG_Company.Active
		  , ORG_Company.OverrideAccount
		  , ORG_Company.DiscountCode
		  , ORG_Company.TagCode
		  , ORG_Company.CountryCode
		  , ORG_Company.StatementPreference
		  , ORG_Company.SalesmanCode
		  , ORG_Company.AreaCode
		  , ORG_Company.RepCode
		  , ORG_Company.URL
		  , ORG_Company.Username
		  , ORG_Company.Password
		  , ORG_Company.CustomValue1
		  , ORG_Company.CustomValue2
		  , ORG_Company.CustomValue3
		  , ORG_Company.CustomValue4
		  , ORG_Company.CustomValue5
		  , ORG_Company.CustomValue6
	 FROM [CDS_SYS].SYS_Entity
		  INNER JOIN [CDS_ORG].ORG_Entity ON SYS_Entity.Id = ORG_Entity.EntityId
		  INNER JOIN [CDS_ORG].ORG_Company ON ORG_Entity.Id = ORG_Company.EntityId 
		  INNER JOIN [CDS_ORG].ORG_Type ON ORG_Company.TypeId = ORG_Type.Id  
		INNER JOIN [CDS_SYS].SYS_Entity Account ON SYS_Entity.CodeSub = Account.CodeSub and Account.TypeId = 5
		INNER JOIN [CDS_SYS].SYS_Entity ControlAccount ON Account.CodeMain = ControlAccount.CodeMain and ControlAccount.CodeSub = '00000'
		INNER JOIN [CDS_GLX].GLX_SiteAccount ON ControlAccount.Id = GLX_SiteAccount.EntityId and GLX_SiteAccount.TypeId IN (8,9) 
		  LEFT OUTER JOIN [CDS_ORG].ORG_Contact AS ORG_Contact_Accounts ON ORG_Entity.EntityId = ORG_Contact_Accounts.CompanyId
																	   AND ORG_Contact_Accounts.DepartmentId = ( 
																												 SELECT
																														Id
																												 FROM [CDS_ORG].ORG_Department
																												 WHERE( Name = 'Accounts' ))
		  LEFT OUTER JOIN [CDS_SYS].SYS_Person AS SYS_Person_Accounts ON ORG_Contact_Accounts.PersonId = SYS_Person_Accounts.Id
		  LEFT OUTER JOIN [CDS_ORG].ORG_Contact AS ORG_Contact_Sales ON ORG_Entity.EntityId = ORG_Contact_Sales.CompanyId
																	AND ORG_Contact_Sales.DepartmentId = ( 
																										   SELECT
																												  Id
																										   FROM [CDS_ORG].ORG_Department
																										   WHERE( Name = 'Sales' ))
		  LEFT OUTER JOIN [CDS_SYS].SYS_Person AS SYS_Person_Sales ON ORG_Contact_Sales.PersonId = SYS_Person_Sales.Id;
GO

IF NOT EXISTS (select * from CDS_GLX.GLX_SystemAccountType WHERE Id = 24)
BEGIN
	SET IDENTITY_INSERT [CDS_GLX].[GLX_SystemAccountType] ON 
	INSERT [CDS_GLX].[GLX_SystemAccountType] ([Id], [Name], [TypeId]) VALUES (24, N'Inventory Buyout', 4)
	SET IDENTITY_INSERT [CDS_GLX].[GLX_SystemAccountType] OFF
END
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Person]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] DROP CONSTRAINT [FK_IBO_TRX_Header_SYS_Person]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Entity]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] DROP CONSTRAINT [FK_IBO_TRX_Header_SYS_Entity]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] DROP CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] DROP CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74]
GO

/****** Object:  Table [CDS_IBO].[IBO_TRX_Header]    Script Date: 2015/10/29 3:03:54 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]') AND type in (N'U'))
DROP TABLE [CDS_IBO].[IBO_TRX_Header]
GO

/****** Object:  Table [CDS_IBO].[IBO_TRX_Header]    Script Date: 2015/10/29 3:03:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_IBO].[IBO_TRX_Header](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EntityId] [bigint] NOT NULL,
	[SupplierId] [bigint] NULL,
	[CustomerId] [bigint] NULL,
	[Supplier] [nvarchar](200) NULL,
	[Customer] [nvarchar](200) NULL,
	[Quantity] [decimal](18, 4) NOT NULL,
	[UnitCost] [decimal](18, 2) NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_IBO_TRX_Header_CreatedOn]  DEFAULT (getdate()),
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_IBO_TRX_Header] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74] FOREIGN KEY([CustomerId])
REFERENCES [CDS_ORG].[ORG_Company] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] CHECK CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_CustomerId_CC7BFB74]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64] FOREIGN KEY([SupplierId])
REFERENCES [CDS_ORG].[ORG_Company] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] CHECK CONSTRAINT [FK_CDS_IBO_IBO_TRX_Header_SupplierId_8C7DEB64]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Entity]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header]  WITH CHECK ADD  CONSTRAINT [FK_IBO_TRX_Header_SYS_Entity] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Entity]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] CHECK CONSTRAINT [FK_IBO_TRX_Header_SYS_Entity]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Person]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header]  WITH CHECK ADD  CONSTRAINT [FK_IBO_TRX_Header_SYS_Person] FOREIGN KEY([CreatedBy])
REFERENCES [CDS_SYS].[SYS_Person] ([Id])
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_IBO].[FK_IBO_TRX_Header_SYS_Person]') AND parent_object_id = OBJECT_ID(N'[CDS_IBO].[IBO_TRX_Header]'))
ALTER TABLE [CDS_IBO].[IBO_TRX_Header] CHECK CONSTRAINT [FK_IBO_TRX_Header_SYS_Person]
GO 

UPDATE [CDS_SYS].[SYS_DOC_Type] set HoldingModifier = -1 WHERE Id = 2
GO

IF NOT EXISTS (SELECT * FROM SYS.COLUMNS WHERE name = 'LineTypeFilter' and object_id = OBJECT_ID('CDS_SYS.SYS_Site'))
BEGIN
	ALTER TABLE [CDS_SYS].[SYS_Site] ADD [LineTypeFilter] [nvarchar](200) NULL
END 
GO
IF NOT EXISTS (SELECT * FROM SYS.COLUMNS WHERE name = 'BuyoutSupplierAccount' and object_id = OBJECT_ID('CDS_SYS.SYS_Site'))
BEGIN
	ALTER TABLE [CDS_SYS].[SYS_Site] ADD [BuyoutSupplierAccount] [bigint] NULL
END
GO  
IF NOT EXISTS(SELECT * FROM [CDS_SYS].[SYS_Type] WHERE Id = 11)
BEGIN
	SET IDENTITY_INSERT [CDS_SYS].[SYS_Type] ON 
	INSERT [CDS_SYS].[SYS_Type] ([Id], [Name]) VALUES (11, N'Surcharge')
	SET IDENTITY_INSERT [CDS_SYS].[SYS_Type] OFF
END

/****** Object:  View [CDS_SYS].[VW_LineItem]    Script Date: 2015/11/03 1:03:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [CDS_SYS].[VW_LineItem]
AS
	   SELECT SYS_Entity.Id AS Id,
			ITM_Inventory.Id AS InventoryId,
			GLX_Account.Id AS AccountId,
			GLX_Account.AccountTypeId AS AccountTypeId,
			SYS_Entity.TypeId,
			SYS_Type.Name AS Type,
			SYS_Entity.ShortName,
			SYS_Entity.Name,
			SYS_Entity.Description,
			SYS_Entity.CodeMain,
			SYS_Entity.CodeSub,
			ITM_InventorySupplier.SupplierStockCode,
			SYS_Entity.Archived,
			SYS_Entity.CreatedOn AS CreatedOn,
			SYS_Person.CreatedBy AS CreatedBy,
			ITM_Inventory.Category,
			ITM_Inventory.SubCategory,
			ITM_Inventory.StockType,
			ITM_Inventory.LocationMain,
			ITM_Inventory.LocationSecondary,
			ITM_Inventory.Barcode,
			ITM_Inventory.MinimumStockLevel,
			ITM_Inventory.MaximumStockLevel,
			ITM_Inventory.SafetyStock,
			ITM_Inventory.WarehousingCost,
			ITM_Inventory.DiscountCode,
			ITM_Inventory.Grouping,
			ITM_Inventory.ProfitMargin,
			ITM_Inventory.LabelFlag,
			ITM_Inventory.CostofSalesId,
			ITM_Inventory.RequireSerial,
			ITM_Inventory.SellingPackSize,
			ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0) AS OnHand,
			ISNULL(ITM_History.OnReserve, 0) AS OnReserve,
			ISNULL(ITM_History.OnOrder, 0) AS OnOrder,
			ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0) AS UnitPrice,
			ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0) AS UnitCost,
			ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0) AS UnitAverage,
			SUM(ISNULL(GLX_History.Amount, 0)) AS BalanceAmount,
			ITM_History.FirstSold,
			ITM_History.FirstPurchased,
			ITM_History.LastSold,
			ITM_History.LastPurchased,
			ITM_History.LastMovement,
			SYS_Entity.Title
	 FROM [CDS_SYS].SYS_Entity
		  INNER JOIN [CDS_SYS].SYS_Person ON SYS_Entity.CreatedBy = SYS_Person.Id
		  INNER JOIN [CDS_SYS].SYS_Type ON SYS_Entity.TypeId = SYS_Type.Id
		  LEFT JOIN [CDS_ITM].ITM_Inventory ON SYS_Entity.Id = ITM_Inventory.EntityId
		  LEFT JOIN [CDS_ITM].ITM_History WITH ( nolock ) ON ITM_Inventory.EntityId = ITM_History.InventoryId
		  LEFT JOIN [CDS_ITM].ITM_InventorySupplier ON ITM_Inventory.EntityId = ITM_InventorySupplier.InventoryId
												   AND [CDS_ITM].ITM_InventorySupplier.PrimarySupplier = 1
		  LEFT JOIN [CDS_SYS].SYS_Period AS ITM_Period WITH ( nolock ) ON ITM_Period.Id = ITM_History.PeriodId
																	  AND ITM_Period.StatusId = 1
																	  AND GETDATE() BETWEEN ITM_Period.StartDate AND ITM_Period.EndDate
		  LEFT JOIN [CDS_GLX].GLX_Account ON SYS_Entity.Id = GLX_Account.EntityId
		  LEFT JOIN [CDS_GLX].GLX_History WITH ( nolock ) ON GLX_Account.EntityId = GLX_History.EntityId
		  LEFT JOIN [CDS_SYS].SYS_Period AS GLX_Period WITH ( nolock ) ON GLX_Period.Id = GLX_History.PeriodId
																	  AND GLX_Period.StatusId = 1
																	  AND GETDATE() BETWEEN GLX_Period.StartDate AND GLX_Period.EndDate
		  LEFT JOIN( 
					 SELECT [IBO_TRX_Header].*
					 FROM [CDS_SYS].[SYS_Entity]
						  CROSS JOIN(
							  SELECT TOP 1 *
							  FROM [CDS_IBO].[IBO_TRX_Header]
							  ORDER BY [IBO_TRX_Header].CreatedOn DESC ) [IBO_TRX_Header]
					 WHERE SYS_Entity.Id = IBO_TRX_Header.EntityId
					   AND SYS_Entity.TypeId = 7 ) [IBO_TRX_Header] ON [IBO_TRX_Header].EntityId = SYS_Entity.Id
	 WHERE [IBO_TRX_Header].Id IS NULL
	   AND SYS_Entity.TypeId IN( 4, 5, 6, 7, 11)
		OR SYS_Entity.Id = IBO_TRX_Header.EntityId
	 GROUP BY SYS_Entity.Id,
			  ITM_Inventory.Id,
			  GLX_Account.Id,
			  GLX_Account.AccountTypeId,
			  SYS_Entity.TypeId,
			  SYS_Type.Name,
			  SYS_Entity.ShortName,
			  SYS_Entity.Name,
			  SYS_Entity.Description,
			  SYS_Entity.CodeMain,
			  SYS_Entity.CodeSub,
			  ITM_InventorySupplier.SupplierStockCode,
			  SYS_Entity.Archived,
			  SYS_Entity.CreatedOn,
			  SYS_Person.CreatedBy,
			  ITM_Inventory.Category,
			  ITM_Inventory.SubCategory,
			  ITM_Inventory.StockType,
			  ITM_Inventory.LocationMain,
			  ITM_Inventory.LocationSecondary,
			  ITM_Inventory.Barcode,
			  ITM_Inventory.MinimumStockLevel,
			  ITM_Inventory.MaximumStockLevel,
			  ITM_Inventory.SafetyStock,
			  ITM_Inventory.WarehousingCost,
			  ITM_Inventory.DiscountCode,
			  ITM_Inventory.Grouping,
			  ITM_Inventory.ProfitMargin,
			  ITM_Inventory.LabelFlag,
			  ITM_Inventory.CostofSalesId,
			  ITM_Inventory.RequireSerial,
			  ITM_Inventory.SellingPackSize,
			  ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0),
			  ISNULL(ITM_History.OnReserve, 0),
			  ISNULL(ITM_History.OnOrder, 0),
			  ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0),
			  ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0),
			  ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0),
			  ITM_History.FirstSold,
			  ITM_History.FirstPurchased,
			  ITM_History.LastSold,
			  ITM_History.LastPurchased,
			  ITM_History.LastMovement,
			  SYS_Entity.Title;

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] DROP CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] DROP CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]
GO

/****** Object:  Table [CDS_ITM].[ITM_Surcharge]    Script Date: 2015/11/03 4:51:08 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]') AND type in (N'U'))
DROP TABLE [CDS_ITM].[ITM_Surcharge]
GO

/****** Object:  Table [CDS_ITM].[ITM_Surcharge]    Script Date: 2015/11/03 4:51:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_ITM].[ITM_Surcharge](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[SurchargeId] [bigint] NULL,
 CONSTRAINT [PK_CDS_ITM_ITM_Surcharge_EA787A94] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] CHECK CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496] FOREIGN KEY([SurchargeId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] CHECK CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]
GO

/****** Object:  Table [CDS_SYS].[SYS_Surcharge]    Script Date: 2015/11/03 4:51:24 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]') AND type in (N'U'))
DROP TABLE [CDS_SYS].[SYS_Surcharge]
GO

/****** Object:  Table [CDS_SYS].[SYS_Surcharge]    Script Date: 2015/11/03 4:51:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_SYS].[SYS_Surcharge](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Amount] [money] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_CDS_SYS_SYS_Surcharge_EBC3C76C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E] FOREIGN KEY([AccountId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663] FOREIGN KEY([CreatedBy])
REFERENCES [CDS_SYS].[SYS_Person] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Notification_PersonId_A24677BD]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Notification]'))
ALTER TABLE [CDS_SYS].[SYS_Notification] DROP CONSTRAINT [FK_CDS_SYS_SYS_Notification_PersonId_A24677BD]
GO

/****** Object:  Table [CDS_SYS].[SYS_Notification]    Script Date: 2015/10/29 3:04:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Notification]') AND type in (N'U'))
DROP TABLE [CDS_SYS].[SYS_Notification]
GO

/****** Object:  Table [CDS_SYS].[SYS_Notification]    Script Date: 2015/10/29 3:04:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Notification]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_SYS].[SYS_Notification](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[PersonId] [bigint] NULL,
	[Title] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Read] [bit] NULL,
 CONSTRAINT [PK_CDS_SYS_SYS_Notification_85B8899D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Notification_PersonId_A24677BD]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Notification]'))
ALTER TABLE [CDS_SYS].[SYS_Notification]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Notification_PersonId_A24677BD] FOREIGN KEY([PersonId])
REFERENCES [CDS_SYS].[SYS_Person] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Notification_PersonId_A24677BD]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Notification]'))
ALTER TABLE [CDS_SYS].[SYS_Notification] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Notification_PersonId_A24677BD]
GO
IF NOT EXISTS(SELECT * FROM [CDS_SYS].[SYS_Type] WHERE Id = 11)
BEGIN
	SET IDENTITY_INSERT [CDS_SYS].[SYS_Type] ON 
	INSERT [CDS_SYS].[SYS_Type] ([Id], [Name]) VALUES (11, N'Surcharge')
	SET IDENTITY_INSERT [CDS_SYS].[SYS_Type] OFF
END
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] DROP CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] DROP CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]
GO

/****** Object:  Table [CDS_ITM].[ITM_Surcharge]    Script Date: 2015/11/03 4:51:08 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]') AND type in (N'U'))
DROP TABLE [CDS_ITM].[ITM_Surcharge]
GO

/****** Object:  Table [CDS_ITM].[ITM_Surcharge]    Script Date: 2015/11/03 4:51:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_ITM].[ITM_Surcharge](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[SurchargeId] [bigint] NULL,
 CONSTRAINT [PK_CDS_ITM_ITM_Surcharge_EA787A94] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] CHECK CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_EntityId_B429E21E]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496] FOREIGN KEY([SurchargeId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_ITM].[FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]') AND parent_object_id = OBJECT_ID(N'[CDS_ITM].[ITM_Surcharge]'))
ALTER TABLE [CDS_ITM].[ITM_Surcharge] CHECK CONSTRAINT [FK_CDS_ITM_ITM_Surcharge_SurchargeId_75BB9496]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] DROP CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]
GO

/****** Object:  Table [CDS_SYS].[SYS_Surcharge]    Script Date: 2015/11/03 4:51:24 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]') AND type in (N'U'))
DROP TABLE [CDS_SYS].[SYS_Surcharge]
GO

/****** Object:  Table [CDS_SYS].[SYS_Surcharge]    Script Date: 2015/11/03 4:51:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_SYS].[SYS_Surcharge](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[AccountId] [bigint] NULL,
	[Amount] [money] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_CDS_SYS_SYS_Surcharge_EBC3C76C] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E] FOREIGN KEY([AccountId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_AccountId_6CEB7B8E]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663] FOREIGN KEY([CreatedBy])
REFERENCES [CDS_SYS].[SYS_Person] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_CreatedBy_7FAD6663]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_SYS].[FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]') AND parent_object_id = OBJECT_ID(N'[CDS_SYS].[SYS_Surcharge]'))
ALTER TABLE [CDS_SYS].[SYS_Surcharge] CHECK CONSTRAINT [FK_CDS_SYS_SYS_Surcharge_EntityId_B4F43CE2]
GO 

/****** Object:  View [CDS_SYS].[VW_LineItem]    Script Date: 2015/11/05 12:41:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [CDS_SYS].[VW_LineItem]
AS
	   SELECT SYS_Entity.Id AS Id,
			ITM_Inventory.Id AS InventoryId,
			GLX_Account.Id AS AccountId,
			GLX_Account.AccountTypeId AS AccountTypeId,
			SYS_Entity.TypeId,
			SYS_Type.Name AS Type,
			SYS_Entity.ShortName,
			SYS_Entity.Name,
			SYS_Entity.Description,
			SYS_Entity.CodeMain,
			SYS_Entity.CodeSub,
			ITM_InventorySupplier.SupplierStockCode,
			SYS_Entity.Archived,
			SYS_Entity.CreatedOn AS CreatedOn,
			SYS_Person.CreatedBy AS CreatedBy,
			ITM_Inventory.Category,
			ITM_Inventory.SubCategory,
			ITM_Inventory.StockType,
			ITM_Inventory.LocationMain,
			ITM_Inventory.LocationSecondary,
			ITM_Inventory.Barcode,
			ITM_Inventory.MinimumStockLevel,
			ITM_Inventory.MaximumStockLevel,
			ITM_Inventory.SafetyStock,
			ITM_Inventory.WarehousingCost,
			ITM_Inventory.DiscountCode,
			ITM_Inventory.Grouping,
			ITM_Inventory.ProfitMargin,
			ITM_Inventory.LabelFlag,
			ITM_Inventory.CostofSalesId,
			ITM_Inventory.RequireSerial,
			ITM_Inventory.SellingPackSize,
			ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0) AS OnHand,
			ISNULL(ITM_History.OnReserve, 0) AS OnReserve,
			ISNULL(ITM_History.OnOrder, 0) AS OnOrder,
			ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0) AS UnitPrice,
			ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0) AS UnitCost,
			ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0) AS UnitAverage,
			SUM(ISNULL(GLX_History.Amount, 0)) AS BalanceAmount,
			ITM_History.FirstSold,
			ITM_History.FirstPurchased,
			ITM_History.LastSold,
			ITM_History.LastPurchased,
			ITM_History.LastMovement,
			SYS_Entity.Title
	 FROM [CDS_SYS].SYS_Entity
		  INNER JOIN [CDS_SYS].SYS_Person ON SYS_Entity.CreatedBy = SYS_Person.Id
		  INNER JOIN [CDS_SYS].SYS_Type ON SYS_Entity.TypeId = SYS_Type.Id
		  LEFT JOIN [CDS_ITM].ITM_Inventory ON SYS_Entity.Id = ITM_Inventory.EntityId
		  LEFT JOIN [CDS_ITM].ITM_History WITH ( nolock ) ON ITM_Inventory.EntityId = ITM_History.InventoryId
		  LEFT JOIN [CDS_ITM].ITM_InventorySupplier ON ITM_Inventory.EntityId = ITM_InventorySupplier.InventoryId
												   AND [CDS_ITM].ITM_InventorySupplier.PrimarySupplier = 1
		  LEFT JOIN [CDS_SYS].SYS_Period AS ITM_Period WITH ( nolock ) ON ITM_Period.Id = ITM_History.PeriodId
																	  AND ITM_Period.StatusId = 1
																	  AND GETDATE() BETWEEN ITM_Period.StartDate AND ITM_Period.EndDate
		  LEFT JOIN [CDS_GLX].GLX_Account ON SYS_Entity.Id = GLX_Account.EntityId
		  LEFT JOIN [CDS_GLX].GLX_History WITH ( nolock ) ON GLX_Account.EntityId = GLX_History.EntityId
		  LEFT JOIN [CDS_SYS].SYS_Period AS GLX_Period WITH ( nolock ) ON GLX_Period.Id = GLX_History.PeriodId
																	  AND GLX_Period.StatusId = 1
																	  AND GETDATE() BETWEEN GLX_Period.StartDate AND GLX_Period.EndDate
		  LEFT JOIN( 
					 SELECT [IBO_TRX_Header].*
					 FROM [CDS_SYS].[SYS_Entity]
						  CROSS JOIN(
							  SELECT TOP 1 *
							  FROM [CDS_IBO].[IBO_TRX_Header]
							  ORDER BY [IBO_TRX_Header].CreatedOn DESC ) [IBO_TRX_Header]
					 WHERE SYS_Entity.Id = IBO_TRX_Header.EntityId
					   AND SYS_Entity.TypeId = 7 ) [IBO_TRX_Header] ON [IBO_TRX_Header].EntityId = SYS_Entity.Id
	 WHERE [IBO_TRX_Header].Id IS NULL
	   AND SYS_Entity.TypeId IN( 4, 5, 6, 7, 11)
		OR SYS_Entity.Id = IBO_TRX_Header.EntityId
	 GROUP BY SYS_Entity.Id,
			  ITM_Inventory.Id,
			  GLX_Account.Id,
			  GLX_Account.AccountTypeId,
			  SYS_Entity.TypeId,
			  SYS_Type.Name,
			  SYS_Entity.ShortName,
			  SYS_Entity.Name,
			  SYS_Entity.Description,
			  SYS_Entity.CodeMain,
			  SYS_Entity.CodeSub,
			  ITM_InventorySupplier.SupplierStockCode,
			  SYS_Entity.Archived,
			  SYS_Entity.CreatedOn,
			  SYS_Person.CreatedBy,
			  ITM_Inventory.Category,
			  ITM_Inventory.SubCategory,
			  ITM_Inventory.StockType,
			  ITM_Inventory.LocationMain,
			  ITM_Inventory.LocationSecondary,
			  ITM_Inventory.Barcode,
			  ITM_Inventory.MinimumStockLevel,
			  ITM_Inventory.MaximumStockLevel,
			  ITM_Inventory.SafetyStock,
			  ITM_Inventory.WarehousingCost,
			  ITM_Inventory.DiscountCode,
			  ITM_Inventory.Grouping,
			  ITM_Inventory.ProfitMargin,
			  ITM_Inventory.LabelFlag,
			  ITM_Inventory.CostofSalesId,
			  ITM_Inventory.RequireSerial,
			  ITM_Inventory.SellingPackSize,
			  ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0),
			  ISNULL(ITM_History.OnReserve, 0),
			  ISNULL(ITM_History.OnOrder, 0),
			  ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0),
			  ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0),
			  ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0),
			  ITM_History.FirstSold,
			  ITM_History.FirstPurchased,
			  ITM_History.LastSold,
			  ITM_History.LastPurchased,
			  ITM_History.LastMovement,
			  SYS_Entity.Title;

GO
IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INBU') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (299, N'INBU', N'Buyouts', N'Buyouts', 3, NULL, NULL, NULL, CAST(N'2015-11-04 13:50:12.407' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INBURE') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (300, N'INBURE', N'View', N'View', 299, NULL, NULL, NULL, CAST(N'2015-11-04 13:50:28.307' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INBURECR') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (301, N'INBURECR', N'Create', N'Create', 300, NULL, NULL, NULL, CAST(N'2015-11-04 13:51:09.350' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INBUREED') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (302, N'INBUREED', N'Edit', N'Edit', 300, NULL, NULL, NULL, CAST(N'2015-11-04 13:51:24.770' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INSU') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (303, N'INSU', N'Surcharge', N'Surcharge', 3, NULL, NULL, NULL, CAST(N'2015-11-04 13:51:31.797' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INSURE') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (304, N'INSURE', N'View', N'View', 303, NULL, NULL, NULL, CAST(N'2015-11-04 13:51:52.713' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INSURECR') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (305, N'INSURECR', N'Create', N'Create', 304, NULL, NULL, NULL, CAST(N'2015-11-04 13:52:18.140' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO

IF NOT EXISTS (SELECT * FROM [CDS_SEC].[SEC_Access] WHERE Code = 'INSUREED') 
BEGIN
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] ON
	INSERT [CDS_SEC].[SEC_Access] ([Id], [Code], [Name], [Description], [ParentId], [CustomValue1], [CustomValue2], [CustomValue3], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (308, N'INSUREED', N'Edit', N'Edit', 304, NULL, NULL, NULL, CAST(N'2015-11-04 13:52:49.850' AS DateTime), NULL, NULL, NULL)
	SET IDENTITY_INSERT [CDS_SEC].[SEC_Access] OFF
END
GO
--Werner Scheffer

--Henko Rabie

/****** Object:  View [CDS_SYS].[VW_LineItem]    Script Date: 2015/11/05 3:25:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [CDS_SYS].[VW_LineItem]
AS
	   SELECT SYS_Entity.Id AS Id,
			ITM_Inventory.Id AS InventoryId,
			GLX_Account.Id AS AccountId,
			GLX_Account.AccountTypeId AS AccountTypeId,
			SYS_Entity.TypeId,
			SYS_Type.Name AS Type,
			SYS_Entity.ShortName,
			SYS_Entity.Name,
			SYS_Entity.Description,
			SYS_Entity.CodeMain,
			SYS_Entity.CodeSub,
			ITM_InventorySupplier.SupplierStockCode,
			SYS_Entity.Archived,
			SYS_Entity.CreatedOn AS CreatedOn,
			SYS_Person.CreatedBy AS CreatedBy,
			ITM_Inventory.Category,
			ITM_Inventory.SubCategory,
			ITM_Inventory.StockType,
			ITM_Inventory.LocationMain,
			ITM_Inventory.LocationSecondary,
			ITM_Inventory.Barcode,
			ITM_Inventory.MinimumStockLevel,
			ITM_Inventory.MaximumStockLevel,
			ITM_Inventory.SafetyStock,
			ITM_Inventory.WarehousingCost,
			ITM_Inventory.DiscountCode,
			ITM_Inventory.Grouping,
			ITM_Inventory.ProfitMargin,
			ITM_Inventory.LabelFlag,
			ITM_Inventory.CostofSalesId AccountCostofSalesId,
		  ITM_Inventory.InventoryId AccountInventoryId,
			ITM_Inventory.RequireSerial,
			ITM_Inventory.SellingPackSize,
			ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0) AS OnHand,
			ISNULL(ITM_History.OnReserve, 0) AS OnReserve,
			ISNULL(ITM_History.OnOrder, 0) AS OnOrder,
			ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0) AS UnitPrice,
			ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0) AS UnitCost,
			ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0) AS UnitAverage,
			SUM(ISNULL(GLX_History.Amount, 0)) AS BalanceAmount,
			ITM_History.FirstSold,
			ITM_History.FirstPurchased,
			ITM_History.LastSold,
			ITM_History.LastPurchased,
			ITM_History.LastMovement,
			SYS_Entity.Title
	 FROM [CDS_SYS].SYS_Entity
		  INNER JOIN [CDS_SYS].SYS_Person ON SYS_Entity.CreatedBy = SYS_Person.Id
		  INNER JOIN [CDS_SYS].SYS_Type ON SYS_Entity.TypeId = SYS_Type.Id
		  LEFT JOIN [CDS_ITM].ITM_Inventory ON SYS_Entity.Id = ITM_Inventory.EntityId
		  LEFT JOIN [CDS_ITM].ITM_History WITH ( nolock ) ON ITM_Inventory.EntityId = ITM_History.InventoryId
		  LEFT JOIN [CDS_ITM].ITM_InventorySupplier ON ITM_Inventory.EntityId = ITM_InventorySupplier.InventoryId
												   AND [CDS_ITM].ITM_InventorySupplier.PrimarySupplier = 1
		  LEFT JOIN [CDS_SYS].SYS_Period AS ITM_Period WITH ( nolock ) ON ITM_Period.Id = ITM_History.PeriodId
																	  AND ITM_Period.StatusId = 1
																	  AND GETDATE() BETWEEN ITM_Period.StartDate AND ITM_Period.EndDate
		  LEFT JOIN [CDS_GLX].GLX_Account ON SYS_Entity.Id = GLX_Account.EntityId
		  LEFT JOIN [CDS_GLX].GLX_History WITH ( nolock ) ON GLX_Account.EntityId = GLX_History.EntityId
		  LEFT JOIN [CDS_SYS].SYS_Period AS GLX_Period WITH ( nolock ) ON GLX_Period.Id = GLX_History.PeriodId
																	  AND GLX_Period.StatusId = 1
																	  AND GETDATE() BETWEEN GLX_Period.StartDate AND GLX_Period.EndDate
		  LEFT JOIN( 
					 SELECT [IBO_TRX_Header].*
					 FROM [CDS_SYS].[SYS_Entity]
						  CROSS JOIN(
							  SELECT TOP 1 *
							  FROM [CDS_IBO].[IBO_TRX_Header]
							  ORDER BY [IBO_TRX_Header].CreatedOn DESC ) [IBO_TRX_Header]
					 WHERE SYS_Entity.Id = IBO_TRX_Header.EntityId
					   AND SYS_Entity.TypeId = 7 ) [IBO_TRX_Header] ON [IBO_TRX_Header].EntityId = SYS_Entity.Id
	 WHERE [IBO_TRX_Header].Id IS NULL
	   AND SYS_Entity.TypeId IN( 4, 5, 6, 7, 11)
		OR SYS_Entity.Id = IBO_TRX_Header.EntityId
	 GROUP BY SYS_Entity.Id,
			  ITM_Inventory.Id,
			  GLX_Account.Id,
			  GLX_Account.AccountTypeId,
			  SYS_Entity.TypeId,
			  SYS_Type.Name,
			  SYS_Entity.ShortName,
			  SYS_Entity.Name,
			  SYS_Entity.Description,
			  SYS_Entity.CodeMain,
			  SYS_Entity.CodeSub,
			  ITM_InventorySupplier.SupplierStockCode,
			  SYS_Entity.Archived,
			  SYS_Entity.CreatedOn,
			  SYS_Person.CreatedBy,
			  ITM_Inventory.Category,
			  ITM_Inventory.SubCategory,
			  ITM_Inventory.StockType,
			  ITM_Inventory.LocationMain,
			  ITM_Inventory.LocationSecondary,
			  ITM_Inventory.Barcode,
			  ITM_Inventory.MinimumStockLevel,
			  ITM_Inventory.MaximumStockLevel,
			  ITM_Inventory.SafetyStock,
			  ITM_Inventory.WarehousingCost,
			  ITM_Inventory.DiscountCode,
			  ITM_Inventory.Grouping,
			  ITM_Inventory.ProfitMargin,
			  ITM_Inventory.LabelFlag,
			  ITM_Inventory.CostofSalesId,
			  ITM_Inventory.InventoryId,
			  ITM_Inventory.RequireSerial,
			  ITM_Inventory.SellingPackSize,
			  ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0),
			  ISNULL(ITM_History.OnReserve, 0),
			  ISNULL(ITM_History.OnOrder, 0),
			  ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0),
			  ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0),
			  ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0),
			  ITM_History.FirstSold,
			  ITM_History.FirstPurchased,
			  ITM_History.LastSold,
			  ITM_History.LastPurchased,
			  ITM_History.LastMovement,
			  SYS_Entity.Title;

GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] DROP CONSTRAINT [FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] DROP CONSTRAINT [FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] DROP CONSTRAINT [FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717]
GO

/****** Object:  Table [CDS_GLX].[GLX_Statement]    Script Date: 2015/12/01 3:53:15 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]') AND type in (N'U'))
DROP TABLE [CDS_GLX].[GLX_Statement]
GO

/****** Object:  Table [CDS_GLX].[GLX_Statement]    Script Date: 2015/12/01 3:53:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_GLX].[GLX_Statement](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[PeriodId] [bigint] NULL,
	[ShouldEmail] [bit] NULL,
	[ShouldPrint] [bit] NULL,
	[HasMailed] [bit] NULL,
	[HasPrinted] [bit] NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_GLX_Statement_CreatedOn]  DEFAULT (getdate()),
	[CreatedBy] [bigint] NULL,
 CONSTRAINT [PK_CDS_GLX_GLX_Statement_3B12C7A9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717] FOREIGN KEY([CreatedBy])
REFERENCES [CDS_SYS].[SYS_Person] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] CHECK CONSTRAINT [FK_CDS_GLX_GLX_Statement_CreatedBy_4BED5717]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] CHECK CONSTRAINT [FK_CDS_GLX_GLX_Statement_EntityId_5C9CBC80]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0] FOREIGN KEY([PeriodId])
REFERENCES [CDS_SYS].[SYS_Period] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_GLX].[FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0]') AND parent_object_id = OBJECT_ID(N'[CDS_GLX].[GLX_Statement]'))
ALTER TABLE [CDS_GLX].[GLX_Statement] CHECK CONSTRAINT [FK_CDS_GLX_GLX_Statement_PeriodId_5FD1D0B0]
GO

DELETE [CDS_RPT].[RPT_Report] where Name = 'Account Statement'
GO
SET IDENTITY_INSERT [CDS_RPT].[RPT_Report] ON
INSERT [CDS_RPT].[RPT_Report] ([Id], [Code], [Name], [Description], [Category], [SubCategory], [Data], [Archived], [CreatedOn], [CreatedBy], [SecurityLevel]) VALUES (15, N'002', N'Account Statement', N'Shows Debtor Statement and Creditor Remittance', N'System', N'Accounts', N'<?xml version="1.0" encoding="utf-8"?>
<XtraReportsLayoutSerializer SerializerVersion="14.2.3.0" Ref="1" Name="XtraReport" ControlType="CDS.Client.Desktop.Reporting.Report.Design.Templates.BaseReportTemplate, CDS.Client.Desktop.Reporting, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" DataSource="#Ref-0" DataMember="Movement" Tag_type="System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Tag="15|002|Account Statement|Shows Debtor Statement and Creditor Remittance|System|Accounts|1" Version="14.2" ScriptsSource="&#xD;&#xA;&#xD;&#xA;private void XtraReport_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e) {&#xD;&#xA; 		/*for(int i=0;i&lt;e.ParametersInformation.Length;i++)&#xD;&#xA;            {    &#xD;&#xA;&#xD;&#xA;			DevExpress.XtraEditors.LookUpEdit oldEditor = (e.ParametersInformation[i].Editor as DevExpress.XtraEditors.LookUpEdit);&#xD;&#xA;&#xD;&#xA;	            DevExpress.XtraEditors.SearchLookUpEdit newEditor = new DevExpress.XtraEditors.SearchLookUpEdit();&#xD;&#xA;&#xD;&#xA;			DevExpress.XtraGrid.Columns.GridColumn colDescription = new DevExpress.XtraGrid.Columns.GridColumn();&#xD;&#xA;	            colDescription.FieldName = &quot;Description&quot;;&#xD;&#xA;      	      colDescription.Name = &quot;colDescription&quot;;&#xD;&#xA;            	colDescription.Visible = true;&#xD;&#xA;	            colDescription.VisibleIndex = 0;&#xD;&#xA;	            colDescription.Width = 150;&#xD;&#xA;&#xD;&#xA;			DevExpress.XtraGrid.Views.Grid.GridView vwView = new DevExpress.XtraGrid.Views.Grid.GridView();&#xD;&#xA;	            vwView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {colDescription });&#xD;&#xA;		   &#xD;&#xA;			newEditor.Properties.DisplayMember = oldEditor.Properties.DisplayMember;&#xD;&#xA;			newEditor.Properties.DataSource = oldEditor.Properties.DataSource;&#xD;&#xA;			newEditor.Properties.ValueMember= oldEditor.Properties.ValueMember;&#xD;&#xA;			newEditor.Properties.View = vwView ;&#xD;&#xA;			e.ParametersInformation[i].Editor = newEditor;&#xD;&#xA;             }*/&#xD;&#xA;}&#xD;&#xA;" DisplayName="Statement" PaperKind="A4" Landscape="true" PageWidth="1169" PageHeight="827">
  <Extensions>
	<Item1 Ref="2" Value="Custom" Key="DataSerializationExtension" />
	<Item2 Ref="3" Value="Custom" Key="DataEditorExtension" />
	<Item3 Ref="4" Value="Custom" Key="ParameterEditorExtension" />
  </Extensions>
  <Bands>
	<Item1 Ref="5" Name="topMarginBand1" ControlType="TopMarginBand" HeightF="100" />
	<Item2 Ref="6" ControlType="DetailBand" Name="detailBand1" HeightF="23">
	  <Controls>
		<Item1 Ref="7" Name="table2" ControlType="XRTable" SizeF="935.477234,23" LocationFloat="6, 0" AnchorVertical="Both">
		  <Rows>
			<Item1 Ref="8" Name="tableRow4" ControlType="XRTableRow" Weight="1">
			  <Cells>
				<Item1 Ref="9" Name="tableCell8" ControlType="XRTableCell" StyleName="DataField" CanGrow="false" Weight="19.129375574217256">
				  <DataBindings>
					<Item1 Ref="10" PropertyName="Text" DataMember="Movement.Date" />
				  </DataBindings>
				</Item1>
				<Item2 Ref="11" Name="tableCell10" ControlType="XRTableCell" StyleName="DataField" CanGrow="false" Weight="17.724048194365807">
				  <DataBindings>
					<Item1 Ref="12" PropertyName="Text" DataMember="Movement.Reference" />
				  </DataBindings>
				</Item2>
				<Item3 Ref="13" Name="tableCell12" ControlType="XRTableCell" StyleName="DataField" CanGrow="false" Weight="24.982865590077189">
				  <DataBindings>
					<Item1 Ref="14" PropertyName="Text" DataMember="Movement.Description" />
				  </DataBindings>
				</Item3>
				<Item4 Ref="15" Name="tableCell14" ControlType="XRTableCell" StyleName="DataField" CanGrow="false" Weight="10.313092564156118">
				  <DataBindings>
					<Item1 Ref="16" PropertyName="Text" DataMember="Movement.AgingCode" />
				  </DataBindings>
				</Item4>
				<Item5 Ref="17" Name="tableCell16" ControlType="XRTableCell" StyleName="DataField" CanGrow="false" Weight="18.635320519112248">
				  <DataBindings>
					<Item1 Ref="18" PropertyName="Text" DataMember="Movement.TypeName" />
				  </DataBindings>
				</Item5>
				<Item6 Ref="19" Name="tableCell18" ControlType="XRTableCell" StyleName="DataField" TextAlignment="TopRight" CanGrow="false" Weight="23.814319813358892">
				  <DataBindings>
					<Item1 Ref="20" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="Movement.Outstanding" />
				  </DataBindings>
				  <StylePriority Ref="21" UseTextAlignment="false" />
				</Item6>
				<Item7 Ref="22" Name="tableCell20" ControlType="XRTableCell" StyleName="DataField" TextAlignment="TopRight" CanGrow="false" Weight="23.814320014403748">
				  <DataBindings>
					<Item1 Ref="23" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="Movement.Amount" />
				  </DataBindings>
				  <StylePriority Ref="24" UseTextAlignment="false" />
				</Item7>
				<Item8 Ref="25" Name="tableCell22" ControlType="XRTableCell" StyleName="DataField" TextAlignment="TopRight" CanGrow="false" Weight="23.814319139772707">
				  <DataBindings>
					<Item1 Ref="26" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="Movement.Debit" />
				  </DataBindings>
				  <StylePriority Ref="27" UseTextAlignment="false" />
				</Item8>
				<Item9 Ref="28" Name="tableCell24" ControlType="XRTableCell" StyleName="DataField" TextAlignment="TopRight" CanGrow="false" Weight="23.814318497116503">
				  <DataBindings>
					<Item1 Ref="29" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="Movement.Credit" />
				  </DataBindings>
				  <StylePriority Ref="30" UseTextAlignment="false" />
				</Item9>
			  </Cells>
			</Item1>
		  </Rows>
		</Item1>
	  </Controls>
	</Item2>
	<Item3 Ref="31" Name="bottomMarginBand1" ControlType="BottomMarginBand" HeightF="100" />
	<Item4 Ref="32" ControlType="PageHeaderBand" Name="pageHeaderBand1" HeightF="42">
	  <Controls>
		<Item1 Ref="33" Name="table1" ControlType="XRTable" SizeF="935.4775,36" LocationFloat="6, 6" AnchorVertical="Bottom">
		  <Rows>
			<Item1 Ref="34" Name="tableRow3" ControlType="XRTableRow" Weight="1">
			  <Cells>
				<Item1 Ref="35" Name="tableCell7" ControlType="XRTableCell" StyleName="FieldCaption" Text="Date" TextAlignment="MiddleLeft" CanGrow="false" Weight="19.129375445473066" />
				<Item2 Ref="36" Name="tableCell9" ControlType="XRTableCell" StyleName="FieldCaption" Text="Reference" TextAlignment="MiddleLeft" CanGrow="false" Weight="17.724048241326763" />
				<Item3 Ref="37" Name="tableCell11" ControlType="XRTableCell" StyleName="FieldCaption" Text="Description" TextAlignment="MiddleLeft" CanGrow="false" Weight="24.982865579500483" />
				<Item4 Ref="38" Name="tableCell13" ControlType="XRTableCell" StyleName="FieldCaption" Text="Aging Code" TextAlignment="MiddleLeft" CanGrow="false" Weight="10.313098616584394" />
				<Item5 Ref="39" Name="tableCell15" ControlType="XRTableCell" StyleName="FieldCaption" Text="Type Name" TextAlignment="MiddleLeft" CanGrow="false" Weight="18.635317412856281" />
				<Item6 Ref="40" Name="tableCell17" ControlType="XRTableCell" StyleName="FieldCaption" Text="Outstanding" TextAlignment="MiddleRight" CanGrow="false" Weight="23.814333251957308">
				  <StylePriority Ref="41" UseTextAlignment="false" />
				</Item6>
				<Item7 Ref="42" Name="tableCell19" ControlType="XRTableCell" StyleName="FieldCaption" Text="Amount" TextAlignment="MiddleRight" CanGrow="false" Weight="23.814331935714755">
				  <StylePriority Ref="43" UseTextAlignment="false" />
				</Item7>
				<Item8 Ref="44" Name="tableCell21" ControlType="XRTableCell" StyleName="FieldCaption" Text="Debit" TextAlignment="MiddleRight" CanGrow="false" Weight="23.814332630894118">
				  <StylePriority Ref="45" UseTextAlignment="false" />
				</Item8>
				<Item9 Ref="46" Name="tableCell23" ControlType="XRTableCell" StyleName="FieldCaption" Text="Credit" TextAlignment="MiddleRight" CanGrow="false" Weight="23.814322831991554">
				  <StylePriority Ref="47" UseTextAlignment="false" />
				</Item9>
			  </Cells>
			</Item1>
		  </Rows>
		</Item1>
	  </Controls>
	</Item4>
	<Item5 Ref="48" ControlType="PageFooterBand" Name="pageFooterBand1" HeightF="29">
	  <Controls>
		<Item1 Ref="49" ControlType="XRPageInfo" Name="pageInfo1" PageInfo="DateTime" SizeF="438,23" LocationFloat="6, 6" Padding="2,2,0,0,100" StyleName="PageInfo" />
		<Item2 Ref="50" ControlType="XRPageInfo" Name="pageInfo2" SizeF="438,23" LocationFloat="456, 6" Padding="2,2,0,0,100" StyleName="PageInfo" TextAlignment="TopRight" Format="Page {0} of {1}" />
	  </Controls>
	</Item5>
	<Item6 Ref="51" Name="reportHeaderBand1" ControlType="ReportHeaderBand" HeightF="51">
	  <Controls>
		<Item1 Ref="52" Name="label2" ControlType="XRLabel" TextAlignment="TopRight" SizeF="438,32.9999924" LocationFloat="456, 6.00001" StyleName="Title" Padding="2,2,0,0,100">
		  <DataBindings>
			<Item1 Ref="53" PropertyName="Text" DataMember="StaticValues.PeriodCode" />
		  </DataBindings>
		  <StylePriority Ref="54" UseTextAlignment="false" />
		</Item1>
		<Item2 Ref="55" Name="label1" ControlType="XRLabel" SizeF="438,32.9999924" LocationFloat="6.00001, 6.00001" StyleName="Title" Padding="2,2,0,0,100">
		  <DataBindings>
			<Item1 Ref="56" PropertyName="Text" DataMember="StaticValues.AccountName" />
		  </DataBindings>
		</Item2>
	  </Controls>
	</Item6>
	<Item7 Ref="57" ControlType="ReportFooterBand" Name="ReportFooter" KeepTogether="true" PrintAtBottom="true" HeightF="291.666534">
	  <Controls>
		<Item1 Ref="58" Name="chart1" ControlType="XRChart" Borders="None" BorderColor="Black" LocationFloat="6.00001, 29.208374" SizeF="935.477234,196.875" DataSource="#Ref-0">
		  <Chart Ref="59" PaletteName="Metro" SelectionMode="None" SeriesSelectionMode="Series">
			<Diagram Ref="60" EqualPieSize="false" TypeNameSerializable="SimpleDiagram" />
			<DataContainer Ref="61" SeriesDataMember="Code" DataMember="TransactionSummary">
			  <SeriesTemplate Ref="62" LegendTextPattern="{A} : {V} : ({VP:0%})" ValueDataMembersSerializable="RegularAmount" ArgumentScaleType="Qualitative" ArgumentDataMember="Name">
				<View Ref="63" TypeNameSerializable="PieSeriesView" SweepDirection="Counterclockwise" />
			  </SeriesTemplate>
			</DataContainer>
		  </Chart>
		</Item1>
		<Item2 Ref="64" Name="table3" ControlType="XRTable" SizeF="478.983368,22.9999847" LocationFloat="462.494141, 0">
		  <Rows>
			<Item1 Ref="65" Name="tableRow1" ControlType="XRTableRow" Weight="1">
			  <Cells>
				<Item1 Ref="66" Name="tableCell6" ControlType="XRTableCell" StyleName="DataField" Borders="Top, Bottom" TextAlignment="TopRight" CanGrow="false" Weight="18.4499991589854">
				  <DataBindings>
					<Item1 Ref="67" PropertyName="Text" DataMember="Movement.Outstanding" />
				  </DataBindings>
				  <StylePriority Ref="68" UseBorders="false" UseTextAlignment="false" />
				  <Summary Ref="69" FormatString="{0:0,#.00}" Running="Report" />
				</Item1>
				<Item2 Ref="70" Name="tableCell25" ControlType="XRTableCell" StyleName="DataField" Borders="Top, Bottom" TextAlignment="TopRight" CanGrow="false" Weight="18.4499984995535">
				  <DataBindings>
					<Item1 Ref="71" PropertyName="Text" DataMember="Movement.Amount" />
				  </DataBindings>
				  <StylePriority Ref="72" UseBorders="false" UseTextAlignment="false" />
				  <Summary Ref="73" FormatString="{0:0,#.00}" Running="Report" />
				</Item2>
				<Item3 Ref="74" Name="tableCell26" ControlType="XRTableCell" StyleName="DataField" Borders="Top, Bottom" TextAlignment="TopRight" CanGrow="false" Weight="18.44999913987143">
				  <DataBindings>
					<Item1 Ref="75" PropertyName="Text" DataMember="Movement.Debit" />
				  </DataBindings>
				  <StylePriority Ref="76" UseBorders="false" UseTextAlignment="false" />
				  <Summary Ref="77" FormatString="{0:0,#.00}" Running="Report" />
				</Item3>
				<Item4 Ref="78" Name="tableCell27" ControlType="XRTableCell" StyleName="DataField" Borders="Top, Bottom" TextAlignment="TopRight" CanGrow="false" Weight="18.449997324044457">
				  <DataBindings>
					<Item1 Ref="79" PropertyName="Text" DataMember="Movement.Credit" />
				  </DataBindings>
				  <StylePriority Ref="80" UseBorders="false" UseTextAlignment="false" />
				  <Summary Ref="81" FormatString="{0:0,#.00}" Running="Report" />
				</Item4>
			  </Cells>
			</Item1>
		  </Rows>
		</Item2>
		<Item3 Ref="82" Name="table4" ControlType="XRTable" SizeF="718.5,36" LocationFloat="222.5605, 229.624939">
		  <Rows>
			<Item1 Ref="83" Name="tableRow2" ControlType="XRTableRow" Weight="1">
			  <Cells>
				<Item1 Ref="84" Name="tableCell3" ControlType="XRTableCell" StyleName="FieldCaption" Text="Current" TextAlignment="MiddleRight" CanGrow="false" Weight="23.81514619251147">
				  <StylePriority Ref="85" UseTextAlignment="false" />
				</Item1>
				<Item2 Ref="86" Name="tableCell4" ControlType="XRTableCell" StyleName="FieldCaption" Text="30 Days" TextAlignment="MiddleRight" CanGrow="false" Weight="23.81514649150089">
				  <StylePriority Ref="87" UseTextAlignment="false" />
				</Item2>
				<Item3 Ref="88" Name="tableCell5" ControlType="XRTableCell" StyleName="FieldCaption" Text="60 Days" TextAlignment="MiddleRight" CanGrow="false" Weight="23.815146513840212">
				  <StylePriority Ref="89" UseTextAlignment="false" />
				</Item3>
				<Item4 Ref="90" Name="tableCell28" ControlType="XRTableCell" StyleName="FieldCaption" Text="90 Days" TextAlignment="MiddleRight" CanGrow="false" Weight="23.81514525086515">
				  <StylePriority Ref="91" UseTextAlignment="false" />
				</Item4>
				<Item5 Ref="92" Name="tableCell30" ControlType="XRTableCell" StyleName="FieldCaption" Text="120+ Days" TextAlignment="MiddleRight" CanGrow="false" Weight="23.815146634123096">
				  <StylePriority Ref="93" UseTextAlignment="false" />
				</Item5>
				<Item6 Ref="94" Name="tableCell31" ControlType="XRTableCell" StyleName="FieldCaption" Text="Total" TextAlignment="MiddleRight" CanGrow="false" Weight="23.815143934623549">
				  <StylePriority Ref="95" UseTextAlignment="false" />
				</Item6>
			  </Cells>
			</Item1>
		  </Rows>
		</Item3>
		<Item4 Ref="96" Name="table5" ControlType="XRTable" SizeF="718.5,25" LocationFloat="222.5605, 265.624878">
		  <Rows>
			<Item1 Ref="97" Name="tableRow5" ControlType="XRTableRow" Weight="11.5">
			  <Cells>
				<Item1 Ref="98" Name="tableCell32" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47198756407488873">
				  <DataBindings>
					<Item1 Ref="99" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.CURRENT" />
				  </DataBindings>
				  <StylePriority Ref="100" UseBorders="false" UseTextAlignment="false" />
				</Item1>
				<Item2 Ref="101" Name="tableCell33" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47198765428732814">
				  <DataBindings>
					<Item1 Ref="102" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.030" />
				  </DataBindings>
				  <StylePriority Ref="103" UseBorders="false" UseTextAlignment="false" />
				</Item2>
				<Item3 Ref="104" Name="tableCell34" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47203775226204681">
				  <DataBindings>
					<Item1 Ref="105" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.060" />
				  </DataBindings>
				  <StylePriority Ref="106" UseBorders="false" UseTextAlignment="false" />
				</Item3>
				<Item4 Ref="107" Name="tableCell35" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47197087477358685">
				  <DataBindings>
					<Item1 Ref="108" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.090" />
				  </DataBindings>
				  <StylePriority Ref="109" UseBorders="false" UseTextAlignment="false" />
				</Item4>
				<Item5 Ref="110" Name="tableCell36" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47197111534009206">
				  <DataBindings>
					<Item1 Ref="111" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.120+" />
				  </DataBindings>
				  <StylePriority Ref="112" UseBorders="false" UseTextAlignment="false" />
				</Item5>
				<Item6 Ref="113" Name="tableCell37" ControlType="XRTableCell" Borders="Bottom" TextAlignment="TopRight" Weight="0.47197072441952104">
				  <DataBindings>
					<Item1 Ref="114" FormatString="{0:0,#.00}" PropertyName="Text" DataMember="ClosingBalances.Total" />
				  </DataBindings>
				  <StylePriority Ref="115" UseBorders="false" UseTextAlignment="false" />
				</Item6>
			  </Cells>
			</Item1>
		  </Rows>
		</Item4>
	  </Controls>
	</Item7>
  </Bands>
  <CalculatedFields>
	<Item1 Ref="116" Name="Total" FieldType="Decimal" Expression="[CURRENT]+[030]+[060]+[090]+[120+]" DataMember="ClosingBalances" />
  </CalculatedFields>
  <Parameters>
	<Item1 Ref="120" Description="Period" LookUpSettings="#Ref-117" Name="Period" Type="#Ref-118" Value="#Ref-119" />
	<Item2 Ref="122" Description="Account" LookUpSettings="#Ref-121" Name="Account" Type="#Ref-118" Value="#Ref-119" />
  </Parameters>
  <Scripts Ref="123" OnParametersRequestBeforeShow="XtraReport_ParametersRequestBeforeShow" />
  <StyleSheet>
	<Item1 Ref="124" Name="Title" BorderStyle="Inset" Font="Tahoma, 20pt, style=Bold" ForeColor="DodgerBlue" BackColor="Transparent" BorderColor="Black" BorderWidthSerializable="1" Sides="None" StringFormat="Near;Near;0;None;Character;Default" />
	<Item2 Ref="125" Name="FieldCaption" BorderStyle="Inset" Font="Tahoma, 10pt, style=Bold" ForeColor="DodgerBlue" BackColor="Transparent" BorderColor="Black" BorderWidthSerializable="1" Sides="Bottom" StringFormat="Near;Near;0;None;Character;Default" />
	<Item3 Ref="126" Name="PageInfo" BorderStyle="Inset" Font="Tahoma, 10pt, style=Bold" ForeColor="Black" BackColor="Transparent" BorderColor="Black" BorderWidthSerializable="1" Sides="None" StringFormat="Near;Near;0;None;Character;Default" />
	<Item4 Ref="127" Name="DataField" BorderStyle="Inset" Padding="2,2,0,0,100" Font="Tahoma, 10pt" ForeColor="Black" BackColor="Transparent" BorderColor="Black" BorderWidthSerializable="1" Sides="None" StringFormat="Near;Near;0;None;Character;Default" />
  </StyleSheet>
  <ComponentStorage>
	<Item1 Ref="0" ObjectType="DevExpress.DataAccess.Sql.SqlDataSource,DevExpress.DataAccess.v14.2" Name="sqlDataSource1" Base64="PFNxbERhdGFTb3VyY2U+PE5hbWU+c3FsRGF0YVNvdXJjZTE8L05hbWU+PENvbm5lY3Rpb24gTmFtZT0iUmVwb3J0c0Nvbm5lY3Rpb25TdHJpbmciIEZyb21BcHBDb25maWc9InRydWUiIC8+PFF1ZXJ5IFR5cGU9IkN1c3RvbVNxbFF1ZXJ5IiBOYW1lPSJNb3ZlbWVudCI+PFBhcmFtZXRlciBOYW1lPSJAUGVyaW9kSWQiIFR5cGU9IkRldkV4cHJlc3MuRGF0YUFjY2Vzcy5FeHByZXNzaW9uIj4obnVsbCkoW1BhcmFtZXRlcnMuUGVyaW9kXSk8L1BhcmFtZXRlcj48UGFyYW1ldGVyIE5hbWU9IkBFbnRpdHlJZCIgVHlwZT0iRGV2RXhwcmVzcy5EYXRhQWNjZXNzLkV4cHJlc3Npb24iPihudWxsKShbUGFyYW1ldGVycy5BY2NvdW50XSk8L1BhcmFtZXRlcj48U3FsPg0KICAgICAgLypERUNMQVJFIEBDb2RlTWFpbiBudmFyY2hhcig1MCkgPSAoU0VMRUNUIENvZGVNYWluIGZyb20gW0NEU19TWVNdLltTWVNfRW50aXR5XSB3aGVyZSBJZCA9IEBFbnRpdHlJZCkgKi8NCiAgICAgIERFQ0xBUkUgQElzQ3VzdG9tZXIgQklUID0gQ0FTRSANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgLypHRVQgQUNDT1VOVFMgQ09OVFJPTCBBQ0NPVU5UICovDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICggU0VMRUNUIE1hc3RlckNvbnRyb2xJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gW0NEU19HTFhdLltHTFhfQWNjb3VudF0NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBFbnRpdHlJZCA9IEBFbnRpdHlJZCApIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAvKkNIRUNLIElGIFRIRSBDT05UUk9MIEFDQ09VTlQgSVMgQSBERUJUT1IgKi8NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4oIFNFTEVDVCBUT1AgMSBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uW0dMWF9TaXRlQWNjb3VudF0NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFR5cGVJZCA9IDkgKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiAxDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIA0KICAgICAgLypQUklOVCAnQEVudGl0eUlkJyArIENBU1QoQEVudGl0eUlkIEFTIE5WQVJDSEFSKDEwKSkgKi8NCiAgICAgIC8qR0VUIENPREUgU1VCIEZPUiBFTlRJVFkgKi8NCiAgICAgIERFQ0xBUkUgQENvZGVTdWIgTlZBUkNIQVIoNTApID0gKCBTRUxFQ1QgQ29kZVN1Yg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gW0NEU19TWVNdLltTWVNfRW50aXR5XQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIElkID0gQEVudGl0eUlkICkNCiAgICAgIC8qR0VUIE9QRU5JVEVNIFNUQVVTIE9GIEVOVElUWSAqLw0KICAgICAgREVDTEFSRSBASXNPcGVuSXRlbSBCSVQgPSAoIFNFTEVDVCBJU05VTEwoT3Blbkl0ZW0sIDApDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX09SR10uW09SR19Db21wYW55XQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX09SR10uW09SR19FbnRpdHldIE9OIFtPUkdfQ29tcGFueV0uRW50aXR5SWQgPSBbT1JHX0VudGl0eV0uW0lkXQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX1NZU10uW1NZU19FbnRpdHldIE9OIFtPUkdfRW50aXR5XS5FbnRpdHlJZCA9IFtTWVNfRW50aXR5XS5JZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFtTWVNfRW50aXR5XS5bQ29kZVN1Yl0gPSBAQ29kZVN1Yg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIFtPUkdfQ29tcGFueV0uW1R5cGVJZF0gPSBDQVNFIEBJc0N1c3RvbWVyDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIDENCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSAyDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCApDQogICAgICAvKlBSSU5UICdAQ29kZVN1YicgKyBAQ29kZVN1YiAqLw0KICAgICAgLypQUklOVCAnQElzQ3VzdG9tZXInICsgQ0FTVChASXNDdXN0b21lciBBUyBOVkFSQ0hBUigxMCkpICovDQogICAgICBERUNMQVJFIEBDb21wYW55SWQgQklHSU5UID0gKCBTRUxFQ1QgW09SR19Db21wYW55XS5JZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX09SR10uW09SR19Db21wYW55XQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfT1JHXS5bT1JHX0VudGl0eV0gT04gW09SR19Db21wYW55XS5FbnRpdHlJZCA9IFtPUkdfRW50aXR5XS5bSWRdDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gW0NEU19TWVNdLltTWVNfRW50aXR5XSBPTiBbT1JHX0VudGl0eV0uRW50aXR5SWQgPSBbU1lTX0VudGl0eV0uSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFtTWVNfRW50aXR5XS5bQ29kZVN1Yl0gPSBAQ29kZVN1Yg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgW09SR19Db21wYW55XS5bVHlwZUlkXSA9IENBU0UgQElzQ3VzdG9tZXINCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiAxDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIDINCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgKQ0KICAgICAgLypQUklOVCAnQENvbXBhbnlJZCcgKyBDQVNUKElTTlVMTChAQ29tcGFueUlkLCAtMSkgQVMgTlZBUkNIQVIoMTApKSAqLw0KICAgICAgREVDTEFSRSBAUHJldlBlcmlvZElkIEJJR0lOVA0KICAgICAgREVDTEFSRSBARGF0ZUVuZCBEQVRFVElNRQ0KICAgICAgREVDTEFSRSBARGF0ZVN0YXJ0IERBVEVUSU1FDQogICAgICBERUNMQVJFIEBQYXltZW50QWNjb3VudHMgVEFCTEUoIEVudGl0eUlkICAgIEJJR0lOVCwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVGF4RW50aXR5SWQgQklHSU5ULA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBEZXNjcmlwdGlvbiBOVkFSQ0hBUig1MCkpDQogICAgICBERUNMQVJFIEBQYXltZW50QWNjb3VudCBYTUwNCiAgICAgIFNFTEVDVCBUT1AgMSBAUGF5bWVudEFjY291bnQgPSBQYXltZW50QWNjb3VudHMNCiAgICAgIEZST00gW0NEU19TWVNdLlNZU19TaXRlDQogICAgICBJTlNFUlQgSU5UTyBAUGF5bWVudEFjY291bnRzDQogICAgICAgICAgICAgU0VMRUNUIE4ucXVlcnkoICdFbnRpdHlJZC90ZXh0KCknICkudmFsdWUoICcuJywgJ252YXJjaGFyKDUwKScgKSBBUyBFbnRpdHlJZCwNCiAgICAgICAgICAgICAgICAgICAgSVNOVUxMKCggDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBUT1AgMSBbQ0RTX0dMWF0uR0xYX1RheC5FbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfVGF4DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIElkID0gTi5xdWVyeSggJ1RheElkL3RleHQoKScgKS52YWx1ZSggJy4nLCAnaW50JyApKSwgLTEpIEFTIFRheEVudGl0eUlkLA0KICAgICAgICAgICAgICAgICAgICBOLnF1ZXJ5KCAnQWNjb3VudERlc2NyaXB0aW9uL3RleHQoKScgKS52YWx1ZSggJy4nLCAnbnZhcmNoYXIoNTApJyApIEFTIERlc2NyaXB0aW9uDQogICAgICAgICAgICAgRlJPTSBAUGF5bWVudEFjY291bnQubm9kZXMoICcvQXJyYXlPZlBheW1lbnRBY2NvdW50L1BheW1lbnRBY2NvdW50JyApIEFTIFQoIE4gKQ0KICAgICAgU0VMRUNUIEBEYXRlU3RhcnQgPSBTdGFydERhdGUsDQogICAgICAgICAgICAgQERhdGVFbmQgPSBFbmREYXRlDQogICAgICBGUk9NIFtDRFNfU1lTXS5TWVNfUGVyaW9kDQogICAgICBXSEVSRSBJZCA9IEBQZXJpb2RJZA0KICAgICAgLypQUklOVCBAUGVyaW9kSWQgKi8NCiAgICAgIFNFTEVDVCBUT1AgMSBAUHJldlBlcmlvZElkID0gSWQNCiAgICAgIEZST00gW0NEU19TWVNdLlNZU19QZXJpb2QNCiAgICAgIFdIRVJFIERBVEVBREQoREFZLCAtNSwgQERhdGVTdGFydCkgQkVUV0VFTiBbQ0RTX1NZU10uU1lTX1BlcmlvZC5TdGFydERhdGUgQU5EIFtDRFNfU1lTXS5TWVNfUGVyaW9kLkVuZERhdGUNCiAgICAgIC8qUFJJTlQgQFByZXZQZXJpb2RJZCAqLw0KICAgICAgREVDTEFSRSBAQWdpbmdzIFRBQkxFKCBEYXRlICAgICAgICBEQVRFVElNRSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgUmVmZXJlbmNlICAgTlZBUkNIQVIoMjAwKSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRGVzY3JpcHRpb24gTlZBUkNIQVIoMjAwKSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQWdpbmdDb2RlICAgTlZBUkNIQVIoMjAwKSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgT3V0c3RhbmRpbmcgREVDSU1BTCgxOCwgMiksDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFtb3VudCAgICAgIERFQ0lNQUwoMTgsIDIpLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUeXBlTmFtZSAgICBOVkFSQ0hBUigyMDApKQ0KICAgICAgQkVHSU4NCiAgICAgICAgICBJRiggQElzT3Blbkl0ZW0gPSAxICkNCiAgICAgICAgICAgICAgQkVHSU4NCiAgICAgICAgICAgICAgICAgIC8qUFJJTlQgJ29wZW5pdGVtJyAqLw0KICAgICAgICAgICAgICAgICAgSU5TRVJUIElOVE8gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBARGF0ZVN0YXJ0LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQUxBTkNFIEJST1VHSFQgRk9SV0FSRCcgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICcwMDEnIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDUgKSBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgU1VNKEFtb3VudCkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFByZXZQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCBJTiggNCwgNSApKSBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFR5cGVOYW1lDQogICAgICAgICAgICAgICAgICBJTlNFUlQgSU5UTyBAQWdpbmdzDQogICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIEBEYXRlU3RhcnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJ0JBTEFOQ0UgQlJPVUdIVCBGT1JXQVJEJyBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJzAwMicgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFBlcmlvZElkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgRW50aXR5SWQgPSBARW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBBZ2luZ0lkID0gNCApIE91dHN0YW5kaW5nLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFByZXZQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDMgKSBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFR5cGVOYW1lDQogICAgICAgICAgICAgICAgICBJTlNFUlQgSU5UTyBAQWdpbmdzDQogICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIEBEYXRlU3RhcnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJ0JBTEFOQ0UgQlJPVUdIVCBGT1JXQVJEJyBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJzAwMycgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFBlcmlvZElkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgRW50aXR5SWQgPSBARW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBBZ2luZ0lkID0gMyApIE91dHN0YW5kaW5nLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFByZXZQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDIgKSBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFR5cGVOYW1lDQogICAgICAgICAgICAgICAgICBJTlNFUlQgSU5UTyBAQWdpbmdzDQogICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIEBEYXRlU3RhcnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJ0JBTEFOQ0UgQlJPVUdIVCBGT1JXQVJEJyBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJzAwNCcgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFBlcmlvZElkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgRW50aXR5SWQgPSBARW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBBZ2luZ0lkID0gMiApIE91dHN0YW5kaW5nLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBBbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFBlcmlvZElkID0gQFByZXZQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDEgKSBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQkYnIFR5cGVOYW1lDQogICAgICAgICAgICAgICAgICBJTlNFUlQgSU5UTyBAQWdpbmdzDQogICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIFtDRFNfR0xYXS5HTFhfSGVhZGVyLkNyZWF0ZWRPbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBJU05VTEwoW0NEU19PUkddLk9SR19Db21wYW55LkN1c3RvbVZhbHVlMywgJycpID0gJycNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9IZWFkZXIuUmVmZXJlbmNlDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIFtDRFNfR0xYXS5HTFhfSGVhZGVyLlJlZmVyZW5jZSArIElTTlVMTCgnICgnICsgW0NEU19PUkddLk9SR19Db21wYW55LkN1c3RvbVZhbHVlMyArICcpJywgJycpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9IZWFkZXIuZGVzY3JpcHRpb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIFBheW1lbnRBY2NvdW50cy5EZXNjcmlwdGlvbg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIERlc2NyaXB0aW9uLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnMDA1JyBBZ2luZ0NvZGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBQYXltZW50QWNjb3VudHMuVGF4RW50aXR5SWQgPSAtMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTi1wYXkuQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFLXBheS5BbW91bnQgKyAtUGF5VGF4LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgT3V0c3RhbmRpbmcsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gUGF5bWVudEFjY291bnRzLlRheEVudGl0eUlkID0gLTENCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOLXBheS5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFLXBheS5BbW91bnQgKyAtUGF5VGF4LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIEFtb3VudCwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZS5OYW1lLCAnJykNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSBQYXltZW50QWNjb3VudHMuRGVzY3JpcHRpb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQNCiAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGVhZGVyDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfR0xYXS5HTFhfTGluZSBPTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5JZCA9IFtDRFNfR0xYXS5HTFhfTGluZS5IZWFkZXJJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX0dMWF0uR0xYX0FjY291bnQgT04gW0NEU19HTFhdLkdMWF9MaW5lLkVudGl0eUlkID0gW0NEU19HTFhdLkdMWF9BY2NvdW50LkVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfT1JHXS5PUkdfQ29tcGFueSBPTiBbQ0RTX09SR10uT1JHX0NvbXBhbnkuSWQgPSBAQ29tcGFueUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUgT04gW0NEU19HTFhdLkdMWF9IZWFkZXIuSm91cm5hbFR5cGVJZCA9IFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUuSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBbQ0RTX0dMWF0uR0xYX0xpbmUgUGF5IE9OIHBheS5IZWFkZXJJZCA9IFtDRFNfR0xYXS5HTFhfSGVhZGVyLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBwYXkuRW50aXR5SWQgSU4oIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgRW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBAUGF5bWVudEFjY291bnRzICkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBAUGF5bWVudEFjY291bnRzIFBheW1lbnRBY2NvdW50cyBPTiBwYXkuRW50aXR5SWQgPSBQYXltZW50QWNjb3VudHMuRW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBbQ0RTX0dMWF0uR0xYX0xpbmUgUGF5VGF4IE9OIFBheVRheC5IZWFkZXJJZCA9IFtDRFNfR0xYXS5HTFhfSGVhZGVyLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBQYXlUYXguRW50aXR5SWQgSU4oIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgVGF4RW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBAUGF5bWVudEFjY291bnRzICkNCiAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBbQ0RTX0dMWF0uR0xYX0hlYWRlci5QZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIFtDRFNfR0xYXS5HTFhfTGluZS5FbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIElTTlVMTChbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLk5hbWUsICcnKSAmbHQ7Jmd0OyAnU1VNTUFSWScNCiAgICAgICAgICAgICAgICAgIElOU0VSVCBJTlRPIEBBZ2luZ3MNCiAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgW0NEU19HTFhdLkdMWF9IZWFkZXIuQ3JlYXRlZE9uLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIElTTlVMTChbQ0RTX09SR10uT1JHX0NvbXBhbnkuQ3VzdG9tVmFsdWUzLCAnJykgPSAnJw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5SZWZlcmVuY2UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgW0NEU19HTFhdLkdMWF9IZWFkZXIuUmVmZXJlbmNlICsgSVNOVUxMKCcgKCcgKyBbQ0RTX09SR10uT1JHX0NvbXBhbnkuQ3VzdG9tVmFsdWUzICsgJyknLCAnJykNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIHBheS5JZCBJUyBOVUxMDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5kZXNjcmlwdGlvbg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgUGF5bWVudEFjY291bnRzLkRlc2NyaXB0aW9uDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICcwMDUnIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBbQ0RTX0dMWF0uR0xYX0xpbmUuQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIFBheW1lbnRBY2NvdW50cy5UYXhFbnRpdHlJZCA9IC0xDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOLXBheS5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UtcGF5LkFtb3VudCArIC1QYXlUYXguQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIHBheS5JZCBJUyBOVUxMDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBbQ0RTX0dMWF0uR0xYX0xpbmUuQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBQYXltZW50QWNjb3VudHMuVGF4RW50aXR5SWQgPSAtMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4tcGF5LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UtcGF5LkFtb3VudCArIC1QYXlUYXguQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIElTTlVMTChbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLk5hbWUsICcnKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIFBheW1lbnRBY2NvdW50cy5EZXNjcmlwdGlvbg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORA0KICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gW0NEU19HTFhdLkdMWF9IZWFkZXINCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gW0NEU19HTFhdLkdMWF9MaW5lIE9OIFtDRFNfR0xYXS5HTFhfSGVhZGVyLklkID0gW0NEU19HTFhdLkdMWF9MaW5lLkhlYWRlcklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfR0xYXS5HTFhfQWNjb3VudCBPTiBbQ0RTX0dMWF0uR0xYX0xpbmUuRW50aXR5SWQgPSBbQ0RTX0dMWF0uR0xYX0FjY291bnQuRW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gW0NEU19PUkddLk9SR19Db21wYW55IE9OIFtDRFNfT1JHXS5PUkdfQ29tcGFueS5JZCA9IEBDb21wYW55SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZSBPTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5Kb3VybmFsVHlwZUlkID0gW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZS5JZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgTEVGVCBKT0lOIFtDRFNfR0xYXS5HTFhfTGluZSBQYXkgT04gcGF5LkhlYWRlcklkID0gW0NEU19HTFhdLkdMWF9IZWFkZXIuSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIHBheS5FbnRpdHlJZCBJTiggDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIEBQYXltZW50QWNjb3VudHMgKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgTEVGVCBKT0lOIEBQYXltZW50QWNjb3VudHMgUGF5bWVudEFjY291bnRzIE9OIHBheS5FbnRpdHlJZCA9IFBheW1lbnRBY2NvdW50cy5FbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgTEVGVCBKT0lOIFtDRFNfR0xYXS5HTFhfTGluZSBQYXlUYXggT04gUGF5VGF4LkhlYWRlcklkID0gW0NEU19HTFhdLkdMWF9IZWFkZXIuSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIFBheVRheC5FbnRpdHlJZCBJTiggDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBUYXhFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIEBQYXltZW50QWNjb3VudHMgKQ0KICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIFtDRFNfR0xYXS5HTFhfQWNjb3VudC5Db250cm9sSWQgPSBARW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBbQ0RTX0dMWF0uR0xYX0hlYWRlci5QZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIElTTlVMTChbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLk5hbWUsICcnKSAmbHQ7Jmd0OyAnU1VNTUFSWScNCiAgICAgICAgICAgICAgICAgIFNFTEVDVCBEYXRlLA0KICAgICAgICAgICAgICAgICAgICAgICAgIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICBBZ2luZ0NvZGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgU1VNKE91dHN0YW5kaW5nKSBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICBTVU0oQW1vdW50KSBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgU1VNKENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gQW1vdW50ICZndDs9IDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EKSBEZWJpdCwNCiAgICAgICAgICAgICAgICAgICAgICAgICBTVU0oQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBBbW91bnQgJmd0Oz0gMA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiAwDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFLUFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQpIENyZWRpdCwNCiAgICAgICAgICAgICAgICAgICAgICAgICBUeXBlTmFtZQ0KICAgICAgICAgICAgICAgICAgRlJPTSBAQWdpbmdzDQogICAgICAgICAgICAgICAgICBXSEVSRSBBbW91bnQgJmx0OyZndDsgMA0KICAgICAgICAgICAgICAgICAgR1JPVVAgQlkgRGF0ZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIFJlZmVyZW5jZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIERlc2NyaXB0aW9uLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgVHlwZU5hbWUNCiAgICAgICAgICAgICAgICAgIE9SREVSIEJZIERhdGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgICBSZWZlcmVuY2UNCiAgICAgICAgICAgICAgRU5EDQogICAgICAgICAgRUxTRQ0KICAgICAgICAgICAgICBCRUdJTg0KICAgICAgICAgICAgICAgICAgREVMRVRFIEBBZ2luZ3MNCiAgICAgICAgICAgICAgICAgIC8qUFJJTlQgJ2JiZicgKi8NCiAgICAgICAgICAgICAgICAgIElOU0VSVCBJTlRPIEBBZ2luZ3MNCiAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQERhdGVTdGFydCwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJ0JCRicgUmVmZXJlbmNlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkFMQU5DRSBCUk9VR0hUIEZPUldBUkQnIERlc2NyaXB0aW9uLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnMDAxJyBBZ2luZ0NvZGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICggDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIEFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gW0NEU19HTFhdLkdMWF9IaXN0b3J5DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFUkUgUGVyaW9kSWQgPSBAUGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBFbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEFnaW5nSWQgPSA1ICkgT3V0c3RhbmRpbmcsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICggDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIFNVTShBbW91bnQpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQcmV2UGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBFbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEFnaW5nSWQgSU4oIDQsIDUgKSkgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBUeXBlTmFtZQ0KICAgICAgICAgICAgICAgICAgSU5TRVJUIElOVE8gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBARGF0ZVN0YXJ0LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQUxBTkNFIEJST1VHSFQgRk9SV0FSRCcgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICcwMDInIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDQgKSBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQcmV2UGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBFbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEFnaW5nSWQgPSAzICkgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBUeXBlTmFtZQ0KICAgICAgICAgICAgICAgICAgSU5TRVJUIElOVE8gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBARGF0ZVN0YXJ0LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQUxBTkNFIEJST1VHSFQgRk9SV0FSRCcgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICcwMDMnIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDMgKSBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQcmV2UGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBFbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEFnaW5nSWQgPSAyICkgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBUeXBlTmFtZQ0KICAgICAgICAgICAgICAgICAgSU5TRVJUIElOVE8gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBARGF0ZVN0YXJ0LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICdCQUxBTkNFIEJST1VHSFQgRk9SV0FSRCcgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICcwMDQnIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQZXJpb2RJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEVudGl0eUlkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQWdpbmdJZCA9IDIgKSBPdXRzdGFuZGluZywNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hpc3RvcnkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBQZXJpb2RJZCA9IEBQcmV2UGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBFbnRpdHlJZCA9IEBFbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEFnaW5nSWQgPSAxICkgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnQkJGJyBUeXBlTmFtZQ0KICAgICAgICAgICAgICAgICAgSU5TRVJUIElOVE8gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgICAgICAgIFNFTEVDVCBbQ0RTX0dMWF0uR0xYX0hlYWRlci5DcmVhdGVkT24sDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gSVNOVUxMKFtDRFNfT1JHXS5PUkdfQ29tcGFueS5DdXN0b21WYWx1ZTMsICcnKSA9ICcnDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIFtDRFNfR0xYXS5HTFhfSGVhZGVyLlJlZmVyZW5jZQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSBbQ0RTX0dMWF0uR0xYX0hlYWRlci5SZWZlcmVuY2UgKyBJU05VTEwoJyAoJyArIFtDRFNfT1JHXS5PUkdfQ29tcGFueS5DdXN0b21WYWx1ZTMgKyAnKScsICcnKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgUmVmZXJlbmNlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIFtDRFNfR0xYXS5HTFhfSGVhZGVyLmRlc2NyaXB0aW9uDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSBQYXltZW50QWNjb3VudHMuRGVzY3JpcHRpb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgJzAwNScgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIHBheS5JZCBJUyBOVUxMDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIFtDRFNfR0xYXS5HTFhfTGluZS5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gUGF5bWVudEFjY291bnRzLlRheEVudGl0eUlkID0gLTENCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4tcGF5LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRS1wYXkuQW1vdW50ICsgLVBheVRheC5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIE91dHN0YW5kaW5nLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIFtDRFNfR0xYXS5HTFhfTGluZS5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIFBheW1lbnRBY2NvdW50cy5UYXhFbnRpdHlJZCA9IC0xDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTi1wYXkuQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRS1wYXkuQW1vdW50ICsgLVBheVRheC5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCBBbW91bnQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIHBheS5JZCBJUyBOVUxMDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gSVNOVUxMKFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUuTmFtZSwgJycpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgUGF5bWVudEFjY291bnRzLkRlc2NyaXB0aW9uDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EDQogICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBbQ0RTX0dMWF0uR0xYX0hlYWRlcg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX0dMWF0uR0xYX0xpbmUgT04gW0NEU19HTFhdLkdMWF9IZWFkZXIuSWQgPSBbQ0RTX0dMWF0uR0xYX0xpbmUuSGVhZGVySWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gW0NEU19HTFhdLkdMWF9BY2NvdW50IE9OIFtDRFNfR0xYXS5HTFhfTGluZS5FbnRpdHlJZCA9IFtDRFNfR0xYXS5HTFhfQWNjb3VudC5FbnRpdHlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX09SR10uT1JHX0NvbXBhbnkgT04gW0NEU19PUkddLk9SR19Db21wYW55LklkID0gQENvbXBhbnlJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlIE9OIFtDRFNfR0xYXS5HTFhfSGVhZGVyLkpvdXJuYWxUeXBlSWQgPSBbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBMRUZUIEpPSU4gW0NEU19HTFhdLkdMWF9MaW5lIFBheSBPTiBwYXkuSGVhZGVySWQgPSBbQ0RTX0dMWF0uR0xYX0hlYWRlci5JZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgcGF5LkVudGl0eUlkIElOKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gQFBheW1lbnRBY2NvdW50cyApDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBMRUZUIEpPSU4gQFBheW1lbnRBY2NvdW50cyBQYXltZW50QWNjb3VudHMgT04gcGF5LkVudGl0eUlkID0gUGF5bWVudEFjY291bnRzLkVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBMRUZUIEpPSU4gW0NEU19HTFhdLkdMWF9MaW5lIFBheVRheCBPTiBQYXlUYXguSGVhZGVySWQgPSBbQ0RTX0dMWF0uR0xYX0hlYWRlci5JZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgUGF5VGF4LkVudGl0eUlkIElOKCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIFRheEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gQFBheW1lbnRBY2NvdW50cyApDQogICAgICAgICAgICAgICAgICAgICAgICAgV0hFUkUgW0NEU19HTFhdLkdMWF9IZWFkZXIuUGVyaW9kSWQgPSBAUGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBbQ0RTX0dMWF0uR0xYX0xpbmUuRW50aXR5SWQgPSBARW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBJU05VTEwoW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZS5OYW1lLCAnJykgJmx0OyZndDsgJ1NVTU1BUlknDQogICAgICAgICAgICAgICAgICBJTlNFUlQgSU5UTyBAQWdpbmdzDQogICAgICAgICAgICAgICAgICAgICAgICAgU0VMRUNUIFtDRFNfR0xYXS5HTFhfSGVhZGVyLkNyZWF0ZWRPbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBJU05VTEwoW0NEU19PUkddLk9SR19Db21wYW55LkN1c3RvbVZhbHVlMywgJycpID0gJycNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9IZWFkZXIuUmVmZXJlbmNlDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIFtDRFNfR0xYXS5HTFhfSGVhZGVyLlJlZmVyZW5jZSArIElTTlVMTCgnICgnICsgW0NEU19PUkddLk9SR19Db21wYW55LkN1c3RvbVZhbHVlMyArICcpJywgJycpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9IZWFkZXIuZGVzY3JpcHRpb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIFBheW1lbnRBY2NvdW50cy5EZXNjcmlwdGlvbg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIERlc2NyaXB0aW9uLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAnMDA1JyBBZ2luZ0NvZGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBQYXltZW50QWNjb3VudHMuVGF4RW50aXR5SWQgPSAtMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTi1wYXkuQW1vdW50DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFLXBheS5BbW91bnQgKyAtUGF5VGF4LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQgT3V0c3RhbmRpbmcsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBwYXkuSWQgSVMgTlVMTA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gUGF5bWVudEFjY291bnRzLlRheEVudGl0eUlkID0gLTENCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOLXBheS5BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFLXBheS5BbW91bnQgKyAtUGF5VGF4LkFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EIEFtb3VudCwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gcGF5LklkIElTIE5VTEwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZS5OYW1lLCAnJykNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSBQYXltZW50QWNjb3VudHMuRGVzY3JpcHRpb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQNCiAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGVhZGVyDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfR0xYXS5HTFhfTGluZSBPTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5JZCA9IFtDRFNfR0xYXS5HTFhfTGluZS5IZWFkZXJJZA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBbQ0RTX0dMWF0uR0xYX0FjY291bnQgT04gW0NEU19HTFhdLkdMWF9MaW5lLkVudGl0eUlkID0gW0NEU19HTFhdLkdMWF9BY2NvdW50LkVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfT1JHXS5PUkdfQ29tcGFueSBPTiBbQ0RTX09SR10uT1JHX0NvbXBhbnkuSWQgPSBAQ29tcGFueUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUgT04gW0NEU19HTFhdLkdMWF9IZWFkZXIuSm91cm5hbFR5cGVJZCA9IFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUuSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBbQ0RTX0dMWF0uR0xYX0xpbmUgUGF5IE9OIHBheS5IZWFkZXJJZCA9IFtDRFNfR0xYXS5HTFhfSGVhZGVyLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBwYXkuRW50aXR5SWQgSU4oIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgRW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBAUGF5bWVudEFjY291bnRzICkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBAUGF5bWVudEFjY291bnRzIFBheW1lbnRBY2NvdW50cyBPTiBwYXkuRW50aXR5SWQgPSBQYXltZW50QWNjb3VudHMuRW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIExFRlQgSk9JTiBbQ0RTX0dMWF0uR0xYX0xpbmUgUGF5VGF4IE9OIFBheVRheC5IZWFkZXJJZCA9IFtDRFNfR0xYXS5HTFhfSGVhZGVyLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBQYXlUYXguRW50aXR5SWQgSU4oIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ1QgVGF4RW50aXR5SWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBAUGF5bWVudEFjY291bnRzICkNCiAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBbQ0RTX0dMWF0uR0xYX0FjY291bnQuQ29udHJvbElkID0gQEVudGl0eUlkDQogICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgW0NEU19HTFhdLkdMWF9IZWFkZXIuUGVyaW9kSWQgPSBAUGVyaW9kSWQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBJU05VTEwoW0NEU19HTFhdLkdMWF9Kb3VybmFsVHlwZS5OYW1lLCAnJykgJmx0OyZndDsgJ1NVTU1BUlknDQogICAgICAgICAgICAgICAgICBTRUxFQ1QgRGF0ZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgRGVzY3JpcHRpb24sDQogICAgICAgICAgICAgICAgICAgICAgICAgQWdpbmdDb2RlLA0KICAgICAgICAgICAgICAgICAgICAgICAgIFNVTShPdXRzdGFuZGluZykgT3V0c3RhbmRpbmcsDQogICAgICAgICAgICAgICAgICAgICAgICAgU1VNKEFtb3VudCkgQW1vdW50LA0KICAgICAgICAgICAgICAgICAgICAgICAgIFNVTShDQVNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIEFtb3VudCAmZ3Q7PSAwDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIEFtb3VudA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSAwDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORCkgRGViaXQsDQogICAgICAgICAgICAgICAgICAgICAgICAgU1VNKENBU0UNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRU4gQW1vdW50ICZndDs9IDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gMA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRS1BbW91bnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EKSBDcmVkaXQsDQogICAgICAgICAgICAgICAgICAgICAgICAgVHlwZU5hbWUNCiAgICAgICAgICAgICAgICAgIEZST00gQEFnaW5ncw0KICAgICAgICAgICAgICAgICAgV0hFUkUgQW1vdW50ICZsdDsmZ3Q7IDANCiAgICAgICAgICAgICAgICAgIEdST1VQIEJZIERhdGUsDQogICAgICAgICAgICAgICAgICAgICAgICAgICBSZWZlcmVuY2UsDQogICAgICAgICAgICAgICAgICAgICAgICAgICBEZXNjcmlwdGlvbiwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEFnaW5nQ29kZSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIFR5cGVOYW1lDQogICAgICAgICAgICAgICAgICBPUkRFUiBCWSBEYXRlLA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgUmVmZXJlbmNlDQogICAgICAgICAgICAgIEVORA0KICAgICAgRU5EPC9TcWw+PC9RdWVyeT48UXVlcnkgVHlwZT0iQ3VzdG9tU3FsUXVlcnkiIE5hbWU9IkNsb3NpbmdCYWxhbmNlcyI+PFBhcmFtZXRlciBOYW1lPSJAUGVyaW9kSWQiIFR5cGU9IkRldkV4cHJlc3MuRGF0YUFjY2Vzcy5FeHByZXNzaW9uIj4obnVsbCkoW1BhcmFtZXRlcnMuUGVyaW9kXSk8L1BhcmFtZXRlcj48UGFyYW1ldGVyIE5hbWU9IkBFbnRpdHlJZCIgVHlwZT0iRGV2RXhwcmVzcy5EYXRhQWNjZXNzLkV4cHJlc3Npb24iPihudWxsKShbUGFyYW1ldGVycy5BY2NvdW50XSk8L1BhcmFtZXRlcj48U3FsPlNFTEVDVCBFbnRpdHlJZCwNCiAgICAgICBbMV0gQVMgW0NVUlJFTlRdLA0KICAgICAgIFsyXSBBUyBbMDMwXSwNCiAgICAgICBbM10gQVMgWzA2MF0sDQogICAgICAgWzRdIEFTIFswOTBdLA0KICAgICAgIFs1XSBBUyBbMTIwK10NCkZST00oIA0KICAgICAgU0VMRUNUIEVudGl0eUlkLA0KICAgICAgICAgICAgIEFnaW5nSWQsDQogICAgICAgICAgICAgQW1vdW50DQogICAgICBGUk9NIFtDRFNfR0xYXS5HTFhfSGlzdG9yeQ0KICAgICAgV0hFUkUgRW50aXR5SWQgPSBARW50aXR5SWQNCiAgICAgICAgQU5EIFBlcmlvZElkID0gQFBlcmlvZGlkICkgUCBQSVZPVCggU1VNKEFtb3VudCkgRk9SIEFnaW5nSWQgSU4oIFsxXSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFsyXSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFszXSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFs0XSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFs1XSApKSBBUyBFbmRCYWxhbmNlOzwvU3FsPjwvUXVlcnk+PFF1ZXJ5IFR5cGU9IkN1c3RvbVNxbFF1ZXJ5IiBOYW1lPSJTdGF0aWNWYWx1ZXMiPjxQYXJhbWV0ZXIgTmFtZT0iQFBlcmlvZElkIiBUeXBlPSJEZXZFeHByZXNzLkRhdGFBY2Nlc3MuRXhwcmVzc2lvbiI+KG51bGwpKFtQYXJhbWV0ZXJzLlBlcmlvZF0pPC9QYXJhbWV0ZXI+PFBhcmFtZXRlciBOYW1lPSJARW50aXR5SWQiIFR5cGU9IkRldkV4cHJlc3MuRGF0YUFjY2Vzcy5FeHByZXNzaW9uIj4obnVsbCkoW1BhcmFtZXRlcnMuQWNjb3VudF0pPC9QYXJhbWV0ZXI+PFNxbD5TRUxFQ1QoIA0KICAgICAgICBTRUxFQ1QgVGl0bGUNCiAgICAgICAgRlJPTSBbQ0RTX1NZU10uU1lTX0VudGl0eQ0KICAgICAgICBXSEVSRSBJZCA9IEBFbnRpdHlJZCApIEFTIEFjY291bnROYW1lLA0KICAgICAgKCANCiAgICAgICAgU0VMRUNUIENvZGUNCiAgICAgICAgRlJPTSBbQ0RTX1NZU10uU1lTX1BlcmlvZA0KICAgICAgICBXSEVSRSBJZCA9IEBQZXJpb2RpZCApIEFTIFBlcmlvZENvZGU7PC9TcWw+PC9RdWVyeT48UXVlcnkgVHlwZT0iQ3VzdG9tU3FsUXVlcnkiIE5hbWU9IlRyYW5zYWN0aW9uU3VtbWFyeSI+PFBhcmFtZXRlciBOYW1lPSJARW50aXR5SWQiIFR5cGU9IkRldkV4cHJlc3MuRGF0YUFjY2Vzcy5FeHByZXNzaW9uIj4obnVsbCkoW1BhcmFtZXRlcnMuQWNjb3VudF0pPC9QYXJhbWV0ZXI+PFBhcmFtZXRlciBOYW1lPSJAUGVyaW9kSWQiIFR5cGU9IkRldkV4cHJlc3MuRGF0YUFjY2Vzcy5FeHByZXNzaW9uIj4obnVsbCkoW1BhcmFtZXRlcnMuUGVyaW9kXSk8L1BhcmFtZXRlcj48U3FsPlNFTEVDVCBbQ0RTX1NZU10uU1lTX1BlcmlvZC5Db2RlLA0KICAgICAgIFtDRFNfR0xYXS5HTFhfSm91cm5hbFR5cGUuTmFtZSwNCiAgICAgICBTVU0oW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudCkgQVMgQW1vdW50LA0KICAgICAgIEFCUyhTVU0oW0NEU19HTFhdLkdMWF9MaW5lLkFtb3VudCkpIEFTIFJlZ3VsYXJBbW91bnQNCkZST00gW0NEU19HTFhdLkdMWF9MaW5lDQogICAgIElOTkVSIEpPSU4gW0NEU19HTFhdLkdMWF9IZWFkZXIgT04gW0NEU19HTFhdLkdMWF9MaW5lLkhlYWRlcklkID0gW0NEU19HTFhdLkdMWF9IZWFkZXIuSWQNCiAgICAgSU5ORVIgSk9JTiBbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlIE9OIFtDRFNfR0xYXS5HTFhfSGVhZGVyLkpvdXJuYWxUeXBlSWQgPSBbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLklkDQogICAgIElOTkVSIEpPSU4gW0NEU19TWVNdLlNZU19FbnRpdHkgT04gW0NEU19TWVNdLlNZU19FbnRpdHkuSWQgPSBbQ0RTX0dMWF0uR0xYX0xpbmUuRW50aXR5SWQNCiAgICAgSU5ORVIgSk9JTiBbQ0RTX1NZU10uU1lTX1BlcmlvZCBPTiBbQ0RTX0dMWF0uR0xYX0hlYWRlci5QZXJpb2RJZCA9IFtDRFNfU1lTXS5TWVNfUGVyaW9kLklkDQogICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBbQ0RTX0dMWF0uR0xYX0hlYWRlci5QZXJpb2RJZCA9IEBQZXJpb2RJZA0KV0hFUkUgW0NEU19TWVNdLlNZU19FbnRpdHkuSWQgPSBARW50aXR5SWQNCkdST1VQIEJZIFtDRFNfU1lTXS5TWVNfUGVyaW9kLkNvZGUsDQogICAgICAgICBbQ0RTX0dMWF0uR0xYX0pvdXJuYWxUeXBlLk5hbWU7PC9TcWw+PC9RdWVyeT48UmVzdWx0U2NoZW1hPjxEYXRhU2V0IE5hbWU9InNxbERhdGFTb3VyY2UxIj48VmlldyBOYW1lPSJDbG9zaW5nQmFsYW5jZXMiPjxGaWVsZCBOYW1lPSJFbnRpdHlJZCIgVHlwZT0iSW50NjQiIC8+PEZpZWxkIE5hbWU9IkNVUlJFTlQiIFR5cGU9IkRlY2ltYWwiIC8+PEZpZWxkIE5hbWU9IjAzMCIgVHlwZT0iRGVjaW1hbCIgLz48RmllbGQgTmFtZT0iMDYwIiBUeXBlPSJEZWNpbWFsIiAvPjxGaWVsZCBOYW1lPSIwOTAiIFR5cGU9IkRlY2ltYWwiIC8+PEZpZWxkIE5hbWU9IjEyMCsiIFR5cGU9IkRlY2ltYWwiIC8+PC9WaWV3PjxWaWV3IE5hbWU9Ik1vdmVtZW50Ij48RmllbGQgTmFtZT0iRGF0ZSIgVHlwZT0iRGF0ZVRpbWUiIC8+PEZpZWxkIE5hbWU9IlJlZmVyZW5jZSIgVHlwZT0iU3RyaW5nIiAvPjxGaWVsZCBOYW1lPSJEZXNjcmlwdGlvbiIgVHlwZT0iU3RyaW5nIiAvPjxGaWVsZCBOYW1lPSJBZ2luZ0NvZGUiIFR5cGU9IlN0cmluZyIgLz48RmllbGQgTmFtZT0iT3V0c3RhbmRpbmciIFR5cGU9IkRlY2ltYWwiIC8+PEZpZWxkIE5hbWU9IkFtb3VudCIgVHlwZT0iRGVjaW1hbCIgLz48RmllbGQgTmFtZT0iRGViaXQiIFR5cGU9IkRlY2ltYWwiIC8+PEZpZWxkIE5hbWU9IkNyZWRpdCIgVHlwZT0iRGVjaW1hbCIgLz48RmllbGQgTmFtZT0iVHlwZU5hbWUiIFR5cGU9IlN0cmluZyIgLz48L1ZpZXc+PFZpZXcgTmFtZT0iU3RhdGljVmFsdWVzIj48RmllbGQgTmFtZT0iQWNjb3VudE5hbWUiIFR5cGU9IlN0cmluZyIgLz48RmllbGQgTmFtZT0iUGVyaW9kQ29kZSIgVHlwZT0iU3RyaW5nIiAvPjwvVmlldz48VmlldyBOYW1lPSJUcmFuc2FjdGlvblN1bW1hcnkiPjxGaWVsZCBOYW1lPSJDb2RlIiBUeXBlPSJTdHJpbmciIC8+PEZpZWxkIE5hbWU9Ik5hbWUiIFR5cGU9IlN0cmluZyIgLz48RmllbGQgTmFtZT0iQW1vdW50IiBUeXBlPSJEZWNpbWFsIiAvPjxGaWVsZCBOYW1lPSJSZWd1bGFyQW1vdW50IiBUeXBlPSJEZWNpbWFsIiAvPjwvVmlldz48L0RhdGFTZXQ+PC9SZXN1bHRTY2hlbWE+PC9TcWxEYXRhU291cmNlPg==" />
	<Item2 Ref="128" ObjectType="DevExpress.DataAccess.EntityFramework.EFDataSource,DevExpress.DataAccess.v14.2" Name="eFDataSource1" ConnectionName="EntityReportsConnection" ConnectionStringName="EntityReportsConnection" ConnectionString="metadata=res://*/DB.CDSDBModelReadOnly.csdl|res://*/DB.CDSDBModelReadOnly.ssdl|res://*/DB.CDSDBModelReadOnly.msl;provider=System.Data.SqlClient;provider connection string=&quot;MultipleActiveResultSets=True;Data Source=.;Initial Catalog=cds_pegasus_test;Persist Security Info=True;User ID=sa;Password=CDS0nl1n3&quot;" Source="CDS.Client.DataAccessLayer.DB.EntityViews, CDS.Client.DataAccessLayer, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null" />
  </ComponentStorage>
  <ObjectStorage>
	<Item1 Ref="117" ObjectType="DevExpress.XtraReports.Parameters.DynamicListLookUpSettings, DevExpress.Printing.v14.2.Core" DataSource="#Ref-128" DataMember="VW_Period" ValueMember="Id" DisplayMember="Code" />
	<Item2 ObjectType="DevExpress.XtraReports.Serialization.ObjectStorageInfo, DevExpress.XtraReports.v14.2" Ref="118" Content="System.Int64" Type="System.Type" />
	<Item3 ObjectType="DevExpress.XtraReports.Serialization.ObjectStorageInfo, DevExpress.XtraReports.v14.2" Ref="119" Content="0" Type="System.Int64" />
	<Item4 Ref="121" ObjectType="DevExpress.XtraReports.Parameters.DynamicListLookUpSettings, DevExpress.Printing.v14.2.Core" DataSource="#Ref-128" DataMember="VW_Account" ValueMember="Id" DisplayMember="Title" />
  </ObjectStorage>
</XtraReportsLayoutSerializer>', 0, NULL, 1, 1)
SET IDENTITY_INSERT [CDS_RPT].[RPT_Report] OFF
GO

--Werner Scheffer


/*
Create [CDS_APP] Schema
*/
CREATE SCHEMA [CDS_APP] 
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_APP].[APP_Attribute]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_APP].[APP_Attribute](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Code] [nvarchar](10) NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_CDS_APP_APP_Attribute_2AB4E6E9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO



IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CDS_APP].[APP_CompanyValue]') AND type in (N'U'))
BEGIN
CREATE TABLE [CDS_APP].[APP_AttributeValue](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[EntityId] [bigint] NULL,
	[ApplicationId] [bigint] NULL,
	[AttributeId] [bigint] NULL,
	[Value] [nvarchar](500) NULL,
 CONSTRAINT [PK_CDS_APP_APP_AttributeValue_28A21FA7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_APP].[FK_CDS_APP_APP_AttributeValue_AttributeId_C605B9A8]') AND parent_object_id = OBJECT_ID(N'[CDS_APP].[APP_AttributeValue]'))
ALTER TABLE [CDS_APP].[APP_AttributeValue]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_APP_APP_AttributeValue_AttributeId_C605B9A8] FOREIGN KEY([AttributeId])
REFERENCES [CDS_APP].[APP_Attribute] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_APP].[FK_CDS_APP_APP_AttributeValue_AttributeId_C605B9A8]') AND parent_object_id = OBJECT_ID(N'[CDS_APP].[APP_AttributeValue]'))
ALTER TABLE [CDS_APP].[APP_AttributeValue] CHECK CONSTRAINT [FK_CDS_APP_APP_AttributeValue_AttributeId_C605B9A8]
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_APP].[FK_CDS_APP_APP_AttributeValue_EntityId_5544D021]') AND parent_object_id = OBJECT_ID(N'[CDS_APP].[APP_AttributeValue]'))
ALTER TABLE [CDS_APP].[APP_AttributeValue]  WITH NOCHECK ADD  CONSTRAINT [FK_CDS_APP_APP_AttributeValue_EntityId_5544D021] FOREIGN KEY([EntityId])
REFERENCES [CDS_SYS].[SYS_Entity] ([Id])
NOT FOR REPLICATION 
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[CDS_APP].[FK_CDS_APP_APP_AttributeValue_EntityId_5544D021]') AND parent_object_id = OBJECT_ID(N'[CDS_APP].[APP_AttributeValue]'))
ALTER TABLE [CDS_APP].[APP_AttributeValue] CHECK CONSTRAINT [FK_CDS_APP_APP_AttributeValue_EntityId_5544D021]
GO

IF NOT EXISTS (SELECT * FROM [CDS_SYS].[SYS_Type] WHERE [Name] = 'Application')
	INSERT INTO [CDS_SYS].[SYS_Type] ([Name]) VALUES ('Application')
GO

IF NOT EXISTS (SELECT * FROM [CDS_SYS].[SYS_Module] WHERE [Module] = 'APP')
	INSERT INTO [CDS_SYS].[SYS_Module] ([Module],[Description],[Code]) VALUES ('APP',NULL,'YES')
GO


-- Jan De Bruyn

ALTER VIEW [CDS_SYS].[VW_LineItem]
AS
	SELECT 
	SYS_Entity.Id AS Id,
            ITM_Inventory.Id AS InventoryId,
            GLX_Account.Id AS AccountId,
            GLX_Account.AccountTypeId AS AccountTypeId,
            SYS_Entity.TypeId,
            SYS_Type.Name AS Type,
            SYS_Entity.ShortName,
            SYS_Entity.Name,
            SYS_Entity.Description,
            SYS_Entity.CodeMain,
            SYS_Entity.CodeSub,
            ITM_InventorySupplier.SupplierStockCode,
            SYS_Entity.Archived,
            SYS_Entity.CreatedOn AS CreatedOn,
            SYS_Person.CreatedBy AS CreatedBy,
            ITM_Inventory.Category,
            ITM_Inventory.SubCategory,
            ITM_Inventory.StockType,
            ITM_Inventory.LocationMain,
            ITM_Inventory.LocationSecondary,
            ITM_Inventory.Barcode,
            ITM_Inventory.MinimumStockLevel,
            ITM_Inventory.MaximumStockLevel,
            ITM_Inventory.SafetyStock,
            ITM_Inventory.WarehousingCost,
            ITM_Inventory.DiscountCode,
            ITM_Inventory.Grouping,
            ITM_Inventory.ProfitMargin,
            ITM_Inventory.LabelFlag,
            ITM_Inventory.CostofSalesId AccountCostofSalesId,
		    ITM_Inventory.InventoryId AccountInventoryId,
            ITM_Inventory.RequireSerial,
            ITM_Inventory.SellingPackSize,
            ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0) AS OnHand,
            ISNULL(ITM_History.OnReserve, 0) AS OnReserve,
            ISNULL(ITM_History.OnOrder, 0) AS OnOrder,
            ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0) AS UnitPrice,
            ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0) AS UnitCost,
            ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0) AS UnitAverage,
            SUM(ISNULL(GLX_History.Amount, 0)) AS BalanceAmount,
            ITM_History.FirstSold,
            ITM_History.FirstPurchased,
            ITM_History.LastSold,
            ITM_History.LastPurchased,
            ITM_History.LastMovement,
            SYS_Entity.Title
     FROM [CDS_SYS].SYS_Entity
          INNER JOIN [CDS_SYS].SYS_Person ON SYS_Entity.CreatedBy = SYS_Person.Id
          INNER JOIN [CDS_SYS].SYS_Type ON SYS_Entity.TypeId = SYS_Type.Id
          LEFT JOIN [CDS_ITM].ITM_Inventory ON SYS_Entity.Id = ITM_Inventory.EntityId
          LEFT JOIN [CDS_ITM].ITM_History WITH ( nolock ) ON ITM_Inventory.EntityId = ITM_History.InventoryId and ITM_History.PeriodId = (select Id from CDS_SYS.fnCurrentPeriod())
          LEFT JOIN [CDS_ITM].ITM_InventorySupplier ON ITM_Inventory.EntityId = ITM_InventorySupplier.InventoryId
                                                   AND [CDS_ITM].ITM_InventorySupplier.PrimarySupplier = 1
          LEFT JOIN [CDS_SYS].SYS_Period AS ITM_Period WITH ( nolock ) ON ITM_Period.Id = ITM_History.PeriodId
                                                                      AND ITM_Period.StatusId = 1
                                                                      AND GETDATE() BETWEEN ITM_Period.StartDate AND ITM_Period.EndDate
          LEFT JOIN [CDS_GLX].GLX_Account ON SYS_Entity.Id = GLX_Account.EntityId
          LEFT JOIN [CDS_GLX].GLX_History WITH ( nolock ) ON GLX_Account.EntityId = GLX_History.EntityId
          LEFT JOIN [CDS_SYS].SYS_Period AS GLX_Period WITH ( nolock ) ON GLX_Period.Id = GLX_History.PeriodId
                                                                      AND GLX_Period.StatusId = 1
                                                                      AND GETDATE() BETWEEN GLX_Period.StartDate AND GLX_Period.EndDate
          LEFT JOIN( 
                     SELECT [IBO_TRX_Header].*
                     FROM [CDS_SYS].[SYS_Entity]
                          CROSS JOIN(
                              SELECT TOP 1 *
                              FROM [CDS_IBO].[IBO_TRX_Header]
                              ORDER BY [IBO_TRX_Header].CreatedOn DESC ) [IBO_TRX_Header]
                     WHERE SYS_Entity.Id = IBO_TRX_Header.EntityId
                       AND SYS_Entity.TypeId = 7 ) [IBO_TRX_Header] ON [IBO_TRX_Header].EntityId = SYS_Entity.Id
     WHERE ([IBO_TRX_Header].Id IS NULL
       AND SYS_Entity.TypeId IN( 4, 5, 6, 7, 11)
        OR SYS_Entity.Id = IBO_TRX_Header.EntityId)
     GROUP BY SYS_Entity.Id,
              ITM_Inventory.Id,
              GLX_Account.Id,
              GLX_Account.AccountTypeId,
              SYS_Entity.TypeId,
              SYS_Type.Name,
              SYS_Entity.ShortName,
              SYS_Entity.Name,
              SYS_Entity.Description,
              SYS_Entity.CodeMain,
              SYS_Entity.CodeSub,
              ITM_InventorySupplier.SupplierStockCode,
              SYS_Entity.Archived,
              SYS_Entity.CreatedOn,
              SYS_Person.CreatedBy,
              ITM_Inventory.Category,
              ITM_Inventory.SubCategory,
              ITM_Inventory.StockType,
              ITM_Inventory.LocationMain,
              ITM_Inventory.LocationSecondary,
              ITM_Inventory.Barcode,
              ITM_Inventory.MinimumStockLevel,
              ITM_Inventory.MaximumStockLevel,
              ITM_Inventory.SafetyStock,
              ITM_Inventory.WarehousingCost,
              ITM_Inventory.DiscountCode,
              ITM_Inventory.Grouping,
              ITM_Inventory.ProfitMargin,
              ITM_Inventory.LabelFlag,
              ITM_Inventory.CostofSalesId,
		      ITM_Inventory.InventoryId,
              ITM_Inventory.RequireSerial,
              ITM_Inventory.SellingPackSize,
              ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0),
              ISNULL(ITM_History.OnReserve, 0),
              ISNULL(ITM_History.OnOrder, 0),
              ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0),
              ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0),
              ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0),
              ITM_History.FirstSold,
              ITM_History.FirstPurchased,
              ITM_History.LastSold,
              ITM_History.LastPurchased,
              ITM_History.LastMovement,
              SYS_Entity.Title;


GO


/****** Object:  View [CDS_SYS].[VW_LineItem]    Script Date: 3/30/2016 5:31:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [CDS_SYS].[VW_LineItem]
AS
	SELECT 
	SYS_Entity.Id AS Id,
            ITM_Inventory.Id AS InventoryId,
            GLX_Account.Id AS AccountId,
            GLX_Account.AccountTypeId AS AccountTypeId,
            SYS_Entity.TypeId,
            SYS_Type.Name AS Type,
            SYS_Entity.ShortName,
            SYS_Entity.Name,
            SYS_Entity.Description,
            SYS_Entity.CodeMain,
            SYS_Entity.CodeSub,
            ITM_InventorySupplier.SupplierStockCode,
            SYS_Entity.Archived,
            SYS_Entity.CreatedOn AS CreatedOn,
            SYS_Person.CreatedBy AS CreatedBy,
            ITM_Inventory.Category,
            ITM_Inventory.SubCategory,
            ITM_Inventory.StockType,
            ITM_Inventory.LocationMain,
            ITM_Inventory.LocationSecondary,
            ITM_Inventory.Barcode,
            ITM_Inventory.MinimumStockLevel,
            ITM_Inventory.MaximumStockLevel,
            ITM_Inventory.SafetyStock,
            ITM_Inventory.WarehousingCost,
            ITM_Inventory.DiscountCode,
            ITM_Inventory.Grouping,
            ITM_Inventory.ProfitMargin,
            ITM_Inventory.LabelFlag,
            ITM_Inventory.CostofSalesId AccountCostofSalesId,
		    ITM_Inventory.InventoryId AccountInventoryId,
            ITM_Inventory.RequireSerial,
            ITM_Inventory.SellingPackSize,
            ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0) AS OnHand,
            ISNULL(ITM_History.OnReserve, 0) AS OnReserve,
            ISNULL(ITM_History.OnOrder, 0) AS OnOrder,
			ISNULL(ITM_History.OnHold, 0) AS OnHold,
            ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0) AS UnitPrice,
            ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0) AS UnitCost,
            ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0) AS UnitAverage,
            SUM(ISNULL(GLX_History.Amount, 0)) AS BalanceAmount,
            ITM_History.FirstSold,
            ITM_History.FirstPurchased,
            ITM_History.LastSold,
            ITM_History.LastPurchased,
            ITM_History.LastMovement,
            SYS_Entity.Title
     FROM [CDS_SYS].SYS_Entity
          INNER JOIN [CDS_SYS].SYS_Person ON SYS_Entity.CreatedBy = SYS_Person.Id
          INNER JOIN [CDS_SYS].SYS_Type ON SYS_Entity.TypeId = SYS_Type.Id
          LEFT JOIN [CDS_ITM].ITM_Inventory ON SYS_Entity.Id = ITM_Inventory.EntityId
          LEFT JOIN [CDS_ITM].ITM_History WITH ( nolock ) ON ITM_Inventory.EntityId = ITM_History.InventoryId and ITM_History.PeriodId = (select Id from CDS_SYS.fnCurrentPeriod())
          LEFT JOIN [CDS_ITM].ITM_InventorySupplier ON ITM_Inventory.EntityId = ITM_InventorySupplier.InventoryId
                                                   AND [CDS_ITM].ITM_InventorySupplier.PrimarySupplier = 1
          LEFT JOIN [CDS_SYS].SYS_Period AS ITM_Period WITH ( nolock ) ON ITM_Period.Id = ITM_History.PeriodId
                                                                      AND ITM_Period.StatusId = 1
                                                                      AND GETDATE() BETWEEN ITM_Period.StartDate AND ITM_Period.EndDate
          LEFT JOIN [CDS_GLX].GLX_Account ON SYS_Entity.Id = GLX_Account.EntityId
          LEFT JOIN [CDS_GLX].GLX_History WITH ( nolock ) ON GLX_Account.EntityId = GLX_History.EntityId
          LEFT JOIN [CDS_SYS].SYS_Period AS GLX_Period WITH ( nolock ) ON GLX_Period.Id = GLX_History.PeriodId
                                                                      AND GLX_Period.StatusId = 1
                                                                      AND GETDATE() BETWEEN GLX_Period.StartDate AND GLX_Period.EndDate
          LEFT JOIN( 
                     SELECT [IBO_TRX_Header].*
                     FROM [CDS_SYS].[SYS_Entity]
                          CROSS JOIN(
                              SELECT TOP 1 *
                              FROM [CDS_IBO].[IBO_TRX_Header]
                              ORDER BY [IBO_TRX_Header].CreatedOn DESC ) [IBO_TRX_Header]
                     WHERE SYS_Entity.Id = IBO_TRX_Header.EntityId
                       AND SYS_Entity.TypeId = 7 ) [IBO_TRX_Header] ON [IBO_TRX_Header].EntityId = SYS_Entity.Id
     WHERE ([IBO_TRX_Header].Id IS NULL
       AND SYS_Entity.TypeId IN( 4, 5, 6, 7, 11)
        OR SYS_Entity.Id = IBO_TRX_Header.EntityId)
     GROUP BY SYS_Entity.Id,
              ITM_Inventory.Id,
              GLX_Account.Id,
              GLX_Account.AccountTypeId,
              SYS_Entity.TypeId,
              SYS_Type.Name,
              SYS_Entity.ShortName,
              SYS_Entity.Name,
              SYS_Entity.Description,
              SYS_Entity.CodeMain,
              SYS_Entity.CodeSub,
              ITM_InventorySupplier.SupplierStockCode,
              SYS_Entity.Archived,
              SYS_Entity.CreatedOn,
              SYS_Person.CreatedBy,
              ITM_Inventory.Category,
              ITM_Inventory.SubCategory,
              ITM_Inventory.StockType,
              ITM_Inventory.LocationMain,
              ITM_Inventory.LocationSecondary,
              ITM_Inventory.Barcode,
              ITM_Inventory.MinimumStockLevel,
              ITM_Inventory.MaximumStockLevel,
              ITM_Inventory.SafetyStock,
              ITM_Inventory.WarehousingCost,
              ITM_Inventory.DiscountCode,
              ITM_Inventory.Grouping,
              ITM_Inventory.ProfitMargin,
              ITM_Inventory.LabelFlag,
              ITM_Inventory.CostofSalesId,
		      ITM_Inventory.InventoryId,
              ITM_Inventory.RequireSerial,
              ITM_Inventory.SellingPackSize,
              ISNULL(COALESCE(ITM_History.OnHand, IBO_TRX_Header.Quantity), 0),
              ISNULL(ITM_History.OnReserve, 0),
              ISNULL(ITM_History.OnOrder, 0),
			  ISNULL(ITM_History.OnHold, 0),
              ISNULL(COALESCE(ITM_History.UnitPrice, IBO_TRX_Header.UnitPrice), 0),
              ISNULL(COALESCE(ITM_History.UnitCost, IBO_TRX_Header.UnitCost), 0),
              ISNULL(COALESCE(ITM_History.UnitAverage, IBO_TRX_Header.UnitCost), 0),
              ITM_History.FirstSold,
              ITM_History.FirstPurchased,
              ITM_History.LastSold,
              ITM_History.LastPurchased,
              ITM_History.LastMovement,
              SYS_Entity.Title;



GO



