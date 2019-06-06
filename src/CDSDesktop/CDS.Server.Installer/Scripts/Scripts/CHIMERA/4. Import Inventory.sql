
USE EXPORT_DB
GO

-- ------------------------------------------
-- Create Temp Inventory Code Mapping Table
-- ------------------------------------------
print '------------------------------------------'
print 'Create Temp Inventory Code Mapping Table'
print '------------------------------------------'
GO

select 
0 InventoryId
,pkInventoryGuid InventoryGuid 
,case when DENSE_RANK() over (partition by tblInventory.sNameAlphaPart order by (tblInventory.pkInventoryGuid)) > 1
THEN
	RTRIM(tblInventory.sNameAlphaPart) + '_' + CAST(  DENSE_RANK() over (partition by (tblInventory.sNameAlphaPart) order by (tblInventory.pkInventoryGuid)) as Nvarchar(50))   
ELSE 
	RTRIM(tblInventory.sNameAlphaPart)
END InventoryName 
,iInventoryId OldInventoryId
into tempInventory
from tblInventory

-- ------------------------------------------
-- Import Inventories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventories'
print '------------------------------------------'
GO


insert into IMPORT_DB.CDS_SYS.SYS_Entity 
select 
4 TypeId
,'' CodeMain
,'' CodeSub
,isnull(exInv.sName,'') ShortName
,InvCodeMap.InventoryName Name
,LEFT(CONVERT(nvarchar(1000),isnull(exInv.sDescription,'')),1000) Description
,ISNULL(exInv.bIsArchived,0) Archived
,isnull(Creator.Id,1) CreatedBy
,exInv.dtCreatedOn CreatedOn
from tblInventory exInv
inner join tempInventory InvCodeMap on exInv.pkInventoryGuid=InvCodeMap.InventoryGuid
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exInv.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO
UPDATE tempInventory set InventoryId = IMPORT_DB.[CDS_SYS].[SYS_Entity].Id
from tempInventory inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] on IMPORT_DB.[CDS_SYS].[SYS_Entity].Name=tempInventory.InventoryName and IMPORT_DB.[CDS_SYS].[SYS_Entity].TypeId = 4
GO

insert into IMPORT_DB.CDS_ITM.ITM_Inventory
select 
InvCodeMap.InventoryId EntityId 
,(select GLX_SiteAccount.EntityId from IMPORT_DB.CDS_GLX.GLX_SiteAccount where TypeId=6 and SystemDefaultAccount=1) CostofSalesId
,(select GLX_SiteAccount.EntityId from IMPORT_DB.CDS_GLX.GLX_SiteAccount where TypeId=13 and SystemDefaultAccount=1) InventoryId
, exInv.sComment Comment
, exInv.sCategory Category
, exInv.sSubCategory SubCategory
, isnull(exInv.sStockType,'') StockType
, exInv.sItemLocation LocationMain
, exInv.sItemLocation2 LocationSecondary
, exInv.sBarcode Barcode
, exInv.iMinStockLevel MinimumStockLevel
, exInv.dMaximumSize MaximumStockLevel
, exInv.iSafetyStock SafetyStock
, exInv.dWarehousingCost WarehousingCost
, exInv.sDiscountCode DiscountCode
, exInv.sGroup [Grouping]
, exInv.dProfitMargin ProfitMargin
, exInv.sPrintLabel LabelFlag
, exInv.bHasSerialNumbers RequireSerial
, exInv.dPackSizeSelling SellingPackSize
, exInv.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
from tblInventory exInv
inner join tempInventory InvCodeMap on exInv.pkInventoryGuid=InvCodeMap.InventoryGuid 
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exInv.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
GO

-- ------------------------------------------
-- Import Inventory Suppliers
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventory Suppliers'
print '------------------------------------------'
GO

INSERT INTO IMPORT_DB.CDS_ITM.ITM_InventorySupplier (InventoryId,SupplierId,LeadTime,SupplierStockCode,MinimumOrderLevel,MaximumOrderLevel,PackSize,PrimarySupplier,UnitAverage,Available,LastQueried,CreatedOn,CreatedBy)
SELECT
inInv.EntityId InventoryId
,inE.Id SupplierId
,case when exSupp.dLeadTime > 250 then 250 else exSupp.dLeadTime end LeadTime
,exSupp.sSupplierStockCode SupplierStockCode
,exSupp.dMinOrderSize MinimumOrderLevel
,exSupp.dMaxOrderSize MaximumOrderLevel
,exSupp.dpacksize PackSize
,exSupp.bIsPrimarySupplier PrimarySupplier
,exSupp.dUnitCost UnitAverage
,exSupp.dtotalAvailable Available
,exSupp.dtLastQueriedOn LastQueried
,exSupp.dtCreatedOn CreatedOn
,isnull(Creator.Id,1) CreatedBy
FROM
relInventoryCompany exSupp
inner join tblCompany exComp on exSupp.fkCompanyGuid=exComp.pkCompanyGuid
INNER JOIN tblAccount exAcc on exComp.fkAccountGuid=exAcc.pkAccountGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE on a.CodeMain=inE.CodeMain and a.CodeSub=inE.CodeSub
inner join IMPORT_DB.CDS_ORG.ORG_Entity inCompEntity on inE.Id=inCompEntity.EntityId
inner join IMPORT_DB.CDS_ORG.ORG_Company inComp on inCompEntity.Id=inComp.EntityId
INNER JOIN tblInventory exInv on exSupp.fkInventoryGuid=exInv.pkInventoryGuid
inner join tempInventory inInvEntity on exInv.pkInventoryGuid=inInvEntity.InventoryGuid   
inner join IMPORT_DB.CDS_ITM.ITM_Inventory inInv on inInvEntity.InventoryId=inInv.EntityId
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on exSupp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO



-- ------------------------------------------
-- Import Inventory Histories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventory Histories'
print '------------------------------------------'
GO


SET IDENTITY_INSERT IMPORT_DB.CDS_ITM.ITM_History ON
GO
INSERT INTO
  IMPORT_DB.CDS_ITM.ITM_History WITH(TABLOCK) (Id,InventoryId,PeriodId,Amount,Movement,OnHand,OnHold,OnReserve,OnOrder,UnitPrice,UnitCost,UnitAverage,FirstSold,FirstPurchased,LastSold,LastPurchased,LastMovement)
SELECT *
FROM
  OPENROWSET('SQLNCLI', 'Server=EXPORT_INSTANCE;Trusted_Connection=yes;Database=EXPORT_DB;',
     'select 
ROW_NUMBER() OVER(ORDER BY exHIST.Id DESC) AS id
,inInvEntity.InventoryId InventoryId
,inP.Id PeriodId
,ISNULL(exHIST.Amount,0) Amount
,0 Movement
,isnull(exHIST.OnHand,0) OnHand
,isnull(exHIST.OnHold,0) OnHold
,isnull(exHIST.OnJob,0) + isnull(exHIST.OnWIP,0) OnReserve
,isnull(exHIST.OnOrder,0) OnOrder
,isnull(exHIST.UnitPrice,0) UnitPrice
,isnull(exHIST.UnitReplacementCost,0) UnitCost
,isnull(exHIST.UnitCost,0) UnitAverage
,exInv.dtFirstMovement FirstSold
,exHIST.FirstPurchased FirstPurchased
,exHIST.LastSold LastSold
,exHIST.LastPurchased LastPurchased
,exHIST.LastMovement LastMovement
from ITM_History exHIST 
INNER JOIN GLX_Period P on exHIST.PeriodId=p.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period inP on p.StartDate=inP.StartDate
INNER JOIN tblInventory exInv on exHIST.InventoryId=exInv.iInventoryId
inner join tempInventory inInvEntity on exInv.pkInventoryGuid=inInvEntity.InventoryGuid   
inner join IMPORT_DB.CDS_ITM.ITM_Inventory inInv on inInvEntity.InventoryId=inInv.EntityId ') AS e;
GO

SET IDENTITY_INSERT IMPORT_DB.CDS_ITM.ITM_History OFF
GO

DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
SET @bcpCommand = 'bcp "SELECT ROW_NUMBER() OVER(ORDER BY ITM_History.Id DESC) + ( SELECT MAX(Id) FROM IMPORT_DB.CDS_ITM.ITM_History ) AS id,tempInventory.InventoryId,SYS_Period.Id PeriodId,ISNULL(ITM_History.Amount, 0) Amount,ISNULL(ITM_History.Quantity, 0) Movement,ISNULL(ITM_History.OnHand, 0) OnHand,ISNULL(ITM_History.OnHold, 0) OnHold,ISNULL(ITM_History.OnJob, 0) + ISNULL(ITM_History.OnWIP, 0) OnReserve,ISNULL(ITM_History.OnOrder, 0) OnOrder,ISNULL(ITM_History.UnitPrice, 0) UnitPrice,ISNULL(ITM_History.UnitReplacementCost, 0) UnitCost,ISNULL(ITM_History.UnitCost, 0) UnitAverage,exInv.dtFirstMovement FirstSold,ITM_History.FirstPurchased,ITM_History.LastSold,ITM_History.LastPurchased,ITM_History.LastMovement FROM EXPORT_DB..ITM_History INNER JOIN( SELECT InventoryId,MAX(PeriodId) LastPeriod FROM EXPORT_DB..ITM_History GROUP BY InventoryId ) LastHistory ON ITM_History.PeriodId = LastHistory.LastPeriod AND ITM_History.InventoryId = LastHistory.InventoryId INNER JOIN EXPORT_DB..GLX_Period ON ITM_History.PeriodId = GLX_Period.Id INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period ON 1 = 1 AND SYS_Period.EndDate > GLX_Period.EndDate INNER JOIN EXPORT_DB..tempInventory ON OldInventoryId = ITM_History.InventoryId INNER JOIN EXPORT_DB..tblInventory exInv ON tempInventory.OldInventoryId = exInv.iInventoryId;" queryout '
SET @FilePath = 'BCPDIR\'
SET @OutputFile = 'ITM_History2.dat'
SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
exec master..xp_cmdshell @bcpCommand 

BULK INSERT IMPORT_DB.[CDS_ITM].[ITM_History]
FROM 'BCPDIR\ITM_History2.dat'
WITH 
     (
         FORMATFILE = 'FORMAT_LOCATION\ITM_History.xml'
	 );
GO


print 'Create history for item with not movement'
GO

DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
SET @bcpCommand = 'bcp "SELECT ROW_NUMBER() OVER(ORDER BY tempInventory.InventoryId + SYS_Period.Id DESC) + (SELECT MAX(Id) FROM IMPORT_DB.CDS_ITM.ITM_History ) AS id,tempInventory.InventoryId,SYS_Period.Id PeriodId,0 Amount,0 Movement,ISNULL(exInv.iTotalOnHand, 0) OnHand,ISNULL(exInv.iTotalOnHold, 0) OnHold,ISNULL(exInv.iTotalOnJob, 0) + ISNULL(exInv.iTotalOnWIP, 0) OnReserve,ISNULL(exInv.iTotalOnOrder, 0) OnOrder,ISNULL(exInv.dUnitPrice, 0) UnitPrice,ISNULL(exInv.dUnitReplacementCost, 0) UnitCost,ISNULL(exInv.dUnitCost, 0) UnitAverage,exInv.dtFirstMovement FirstSold,NULL FirstPurchased,NULL LastSold,NULL LastPurchased,NULL LastMovement FROM EXPORT_DB..tempInventory INNER JOIN EXPORT_DB..tblInventory exInv ON tempInventory.OldInventoryId = exInv.iInventoryId INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period ON 1 = 1 WHERE iInventoryId NOT IN(SELECT DISTINCT InventoryId FROM EXPORT_DB..ITM_History );" queryout '
SET @FilePath = 'BCPDIR\'
SET @OutputFile = 'ITM_History3.dat'
SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
exec master..xp_cmdshell @bcpCommand 

BULK INSERT IMPORT_DB.[CDS_ITM].[ITM_History]
FROM 'BCPDIR\ITM_History3.dat'
WITH 
     (
         FORMATFILE = 'FORMAT_LOCATION\ITM_History.xml'
	 );
GO

--DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
--SET @bcpCommand = 'bcp "DECLARE @StartPeriod DATETIME;SELECT @StartPeriod = MIN(EndDate) FROM cds_paarl..ITM_History INNER JOIN cds_paarl..GLX_Period ON ITM_History.PeriodId = GLX_Period.Id; SELECT tempInventory.InventoryId,SYS_Period.Id PeriodId,ISNULL(History.Amount, 0) Amount,ISNULL(History.Quantity, 0) Movement,ISNULL(History.OnHand, 0) OnHand,ISNULL(History.OnHold, 0) OnHold,ISNULL(History.OnJob, 0) + ISNULL(History.OnWIP, 0) OnReserve,ISNULL(History.OnOrder, 0) OnOrder,ISNULL(History.UnitPrice, 0) UnitPrice,ISNULL(History.UnitReplacementCost, 0) UnitCost,ISNULL(History.UnitCost, 0) UnitAverage,exInv.dtFirstMovement FirstSold,History.FirstPurchased,History.LastSold,History.LastPurchased,History.LastMovement,SYS_Period.EndDate FROM cds_paarl..tblInventory exInv INNER JOIN cds_paarl..GLX_Period externalP ON 1 = 1 LEFT JOIN cds_paarl..ITM_History ON iInventoryId = ITM_History.InventoryId AND PeriodId = externalP.Id LEFT JOIN cds_paarl..tempInventory ON OldInventoryId = exInv.iInventoryId LEFT JOIN cds_pegasus_paarl.CDS_SYS.SYS_Period ON externalP.EndDate = SYS_Period.EndDate AND SYS_Period.EndDate >= @StartPeriod CROSS APPLY( SELECT TOP 1 LastHistory.Amount,LastHistory.Quantity,LastHistory.OnHand,LastHistory.OnHold,LastHistory.OnJob,LastHistory.OnWIP,LastHistory.OnOrder,LastHistory.UnitPrice,LastHistory.UnitReplacementCost,LastHistory.UnitCost,LastHistory.FirstPurchased,LastHistory.LastSold,LastHistory.LastPurchased,LastHistory.LastMovement FROM cds_paarl..ITM_History LastHistory INNER JOIN cds_paarl..GLX_Period LastPeriod ON LastHistory.PeriodId = LastPeriod.Id WHERE LastHistory.InventoryId = exInv.iInventoryId AND LastPeriod.EndDate < externalP.EndDate ORDER BY LastPeriod.EndDate DESC ) History WHERE ITM_History.Id IS NULL ORDER BY SYS_Period.EndDate;" queryout '
--SET @FilePath = 'D:\Data\import_test\'
--SET @OutputFile = 'ITM_History3.dat'
--SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
--exec master..xp_cmdshell @bcpCommand 
--
--BULK INSERT IMPORT_DB.[CDS_ITM].[ITM_History]
--FROM 'D:\Data\import_test\ITM_History3.dat'
--WITH 
--     (
--         FORMATFILE = 'C:\SolutionsOnline\CDS.Pegasus\CDS.Server.Installer\bin\Debug\SQL\Format\ITM_History.xml'
--	 );
--GO

update IMPORT_DB.CDS_ITM.ITM_History set Movement = X.Movement from IMPORT_DB.CDS_ITM.ITM_History
inner join (
SELECT inInvEntity.InventoryId,
       SYS_Period.Id PeriodId,
       SUM(dQuantity * iBalanceModifier) Movement
FROM tblDocumentLine
     INNER JOIN tlDocumentType ON fkDocumentTypeGuid = pkDocumentTypeGuid
     INNER JOIN tempInventory inInvEntity ON fkInventoryGuid = inInvEntity.InventoryGuid
     INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period ON tblDocumentLine.dtCreatedOn BETWEEN SYS_Period.StartDate AND SYS_Period.EndDate
WHERE sName IN( 'Tax Invoice', 'Sales Credit Note' )
GROUP BY inInvEntity.InventoryId,
       SYS_Period.Id
	  ) X on ITM_History.InventoryId = X.InventoryId and ITM_History.PeriodId = X.PeriodId
GO

UPDATE IMPORT_DB.CDS_ITM.ITM_History
  SET Amount = 0,
      Movement = 0   
FROM IMPORT_DB.CDS_ITM.ITM_History
     INNER JOIN IMPORT_DB.CDS_SYS.SYS_Period ON PeriodId = SYS_Period.Id 
	INNER JOIN tempInventory on ITM_History.InventoryId = tempInventory.InventoryId
	INNER JOIN (select iInventoryId,isNULL((select top 1 EndDate from ITM_History inner join GLX_Period on PeriodId = GLX_Period.id  where InventoryId = iInventoryId order by EndDate desc),(select top 1 EndDate from GLX_Period order by EndDate desc)) EndDate from tblInventory
	) X ON tempInventory.OldInventoryId = X.iInventoryId and SYS_Period.EndDate > X.EndDate
GO

USE  IMPORT_DB
GO

DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO