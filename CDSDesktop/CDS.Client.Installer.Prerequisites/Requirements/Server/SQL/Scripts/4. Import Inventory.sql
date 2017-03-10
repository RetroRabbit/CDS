
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
into tempInventory
from tblInventory

-- ------------------------------------------
-- Import Inventories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventories'
print '------------------------------------------'
GO


insert into IMPORT_DB.[CDS_SYS].[SYS_Entity] 
select 
4 TypeId
,'' CodeMain
,'' CodeSub
,isnull(substring(exInv.sName,1,48),'') ShortName
,InvCodeMap.InventoryName Name
,LEFT(CONVERT(nvarchar(1000),isnull(exInv.sDescription,'')),1000) Description
,ISNULL(exInv.bIsArchived,0) Archived
,isnull(Creator.Id,1) CreatedBy
,exInv.dtCreatedOn CreatedOn
from tblInventory exInv
inner join tempInventory InvCodeMap on exInv.pkInventoryGuid=InvCodeMap.InventoryGuid
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exInv.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
GO

UPDATE tempInventory set InventoryId = IMPORT_DB.[CDS_SYS].[SYS_Entity].Id
from tempInventory inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] on IMPORT_DB.[CDS_SYS].[SYS_Entity].Name=tempInventory.InventoryName and IMPORT_DB.[CDS_SYS].[SYS_Entity].TypeId = 4
GO

insert into IMPORT_DB.[CDS_ITM].[ITM_Inventory]
select 
InvCodeMap.InventoryId EntityId 
,(select GLX_SiteAccount.EntityId from IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] where TypeId=6 and SystemDefaultAccount=1) CostofSalesId
,(select GLX_SiteAccount.EntityId from IMPORT_DB.[CDS_GLX].[GLX_SiteAccount] where TypeId=13 and SystemDefaultAccount=1) InventoryId
, exInv.sComment Comment
, exInv.sCategory Category
, exInv.sSubCategory SubCategory
, isnuLL(exInv.sStockType,'') StockType
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
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exInv.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
GO

-- ------------------------------------------
-- Import Inventory Suppliers
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventory Suppliers'
print '------------------------------------------'
GO

INSERT INTO IMPORT_DB.[CDS_ITM].[ITM_InventorySupplier] (InventoryId,SupplierId,LeadTime,SupplierStockCode,MinimumOrderLevel,MaximumOrderLevel,PackSize,PrimarySupplier,UnitAverage,Available,LastQueried,CreatedOn,CreatedBy)
SELECT
inInvEntity.InventoryId InventoryId
,inEntity.Id SupplierId
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
inner join tempCompany CompMap on exSupp.fkCompanyGuid=CompMap.CompanyGuid
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on CompMap.CompanyId=inEntity.Id 
INNER JOIN tblInventory exInv on exSupp.fkInventoryGuid=exInv.pkInventoryGuid
inner join tempInventory inInvEntity on exInv.pkInventoryGuid=inInvEntity.InventoryGuid  
inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.InventoryId=inInv.EntityId
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on exSupp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

GO

-- ------------------------------------------
-- Import Inventory Histories
-- ------------------------------------------
print '------------------------------------------'
print 'Import Inventory Histories'
print '------------------------------------------'
GO

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblMonthEndInventory]') AND name = N'IDX_tblMonthEndInventory_iMonthEndInventoryId')
BEGIN
	CREATE NONCLUSTERED INDEX [IDX_tblMonthEndInventory_iMonthEndInventoryId]
	ON [dbo].[tblMonthEndInventory] ([iMonthEndInventoryId])
	INCLUDE ([fkInventoryGuid],[dtDate],[iTotalOnHand],[iTotalOnOrder],[iTotalOnJob],[iTotalOnWIP],[dtLastPurchasedDate],[dUnitCost],[dtLastMovement],[dUnitPrice],[dUnitReplacementCost],[dtLastSold],[dtFirstPurchased])
END
GO

select 
ROW_NUMBER() OVER(ORDER BY iMonthEndInventoryId DESC) AS id
,iMonthEndInventoryId MEInvId
,exInv.iInventoryId InvId
,MEINV.PeriodId PeriodId 
into tempMEINVId
from tblMonthEndInventory exHIST 
INNER JOIN tempMEDates MEINV on exHIST.dtDate=MEINV.MEINVDate
INNER JOIN tblInventory exInv on exHIST.fkInventoryGuid=exInv.pkInventoryGuid 

GO

PRINT '--------------------------------------------'
PRINT 'Adding Default Constraints for History'
PRINT '--------------------------------------------'
GO

ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] ADD CONSTRAINT DF_ITM_History_FirstSold DEFAULT (NULL) FOR FirstSold
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] ADD CONSTRAINT DF_ITM_History_FirstPurchased DEFAULT (NULL) FOR FirstPurchased
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] ADD CONSTRAINT DF_ITM_History_LastSold DEFAULT (NULL) FOR LastSold
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] ADD CONSTRAINT DF_ITM_History_LastPurchased DEFAULT (NULL) FOR LastPurchased
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] ADD CONSTRAINT DF_ITM_History_LastMovement DEFAULT (NULL) FOR LastMovement
GO

PRINT '--------------------------------------------'
PRINT 'Dropping Indexes for History'
PRINT '--------------------------------------------'
GO

/****** Object:  Index [IDX_VW_Entity_PeriodId]    Script Date: 2015/09/16 5:12:26 PM ******/
DROP INDEX [IDX_VW_Entity_PeriodId] ON IMPORT_DB.[CDS_ITM].[ITM_History]
GO
 
/****** Object:  Index [Idx_ITM_History_PeriodId_InventoryId_Amount]    Script Date: 2015/09/16 5:12:31 PM ******/
DROP INDEX [Idx_ITM_History_PeriodId_InventoryId_Amount] ON IMPORT_DB.[CDS_ITM].[ITM_History]
GO
 
/****** Object:  Index [Idx_ITM_History_InventoryId_PeriodId]    Script Date: 2015/09/16 5:12:41 PM ******/
DROP INDEX [Idx_ITM_History_InventoryId_PeriodId] ON IMPORT_DB.[CDS_ITM].[ITM_History]
GO


PRINT '--------------------------------------------'
PRINT ' Importing History					     '
PRINT '--------------------------------------------'
GO

DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
--SET @bcpCommand = 'bcp "select tempMEINVId.id Id,inInv.Id InventoryId,MEINV.PeriodId PeriodId,0 Amount,0 Movement,isnull(exHIST.iTotalOnHand,0) OnHand,isnull(exHIST.iTotalOnJob,0) + isnull(exHIST.iTotalOnWIP,0) OnReserve,isnull(exHIST.iTotalOnOrder,0) OnOrder,isnull(exHIST.dUnitPrice,0) UnitPrice,isnull(exHIST.dUnitReplacementCost,0) UnitCost,isnull(exHIST.dUnitCost,0) UnitAverage,exInv.dtFirstMovement FirstSol,exHIST.dtFirstPurchased FirstPurchase,exHIST.dtLastSold LastSol,exHIST.dtLastPurchasedDate LastPurchased,exHIST.dtLastMovement LastMovement from EXPORT_DB.dbo.tblMonthEndInventory exHIST INNER JOIN EXPORT_DB.dbo.tempMEINVId on exHIST.iMonthEndInventoryId=tempMEINVId.MEInvId INNER JOIN EXPORT_DB.dbo.tempMEDates MEINV on exHIST.dtDate=MEINV.MEINVDate INNER JOIN EXPORT_DB.dbo.tblInventory exInv on exHIST.fkInventoryGuid=exInv.pkInventoryGuid inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inInvEntity on exInv.sNameAlphaPart=inInvEntity.Name and inInvEntity.TypeId=4 inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.Id=inInv.EntityId " queryout '
SET @bcpCommand = 'bcp "SELECT tempMEINVId.id AS Id,inInvEntity.InventoryId AS InventoryId,MEINV.PeriodId AS PeriodId,0 AS Amount,0 AS Movement,ISNULL(exHIST.iTotalOnHand, 0) AS OnHand,ISNULL(exHIST.iTotalOnHold, 0) AS OnHold,ISNULL(exHIST.iTotalOnJob, 0) + ISNULL(exHIST.iTotalOnWIP, 0) AS OnReserve,ISNULL(exHIST.iTotalOnOrder, 0) AS OnOrder,ISNULL(exHIST.dUnitPrice, 0) AS UnitPrice,ISNULL(exHIST.dUnitReplacementCost, 0) AS UnitCost,ISNULL(exHIST.dUnitCost, 0) AS UnitAverage, null AS FirstSold,exHIST.dtFirstPurchased AS FirstPurchased,exHIST.dtLastSold AS LastSold,exHIST.dtLastPurchasedDate AS LastPurchased,exHIST.dtLastMovement AS LastMovement FROM EXPORT_DB..tblMonthEndInventory AS exHIST LEFT JOIN EXPORT_DB..tempMEINVId ON exHIST.iMonthEndInventoryId = tempMEINVId.MEInvId LEFT JOIN EXPORT_DB..tempMEDates AS MEINV ON exHIST.dtDate = MEINV.MEINVDate LEFT JOIN EXPORT_DB..tempInventory AS inInvEntity ON inInvEntity.InventoryGuid = exHIST.fkInventoryGuid;" queryout '
SET @FilePath = 'BCPDIR\'
SET @OutputFile = 'ITM_History.dat'
SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
exec master..xp_cmdshell @bcpCommand

truncate table IMPORT_DB.[CDS_ITM].[ITM_History]

BULK INSERT IMPORT_DB.[CDS_ITM].[ITM_History]
FROM 'BCPDIR\ITM_History.dat'
WITH 
     (
         FORMATFILE = 'FORMAT_LOCATION\ITM_History.xml'
	 );
GO

insert into tempMEINVId (Id,MEInvId, InvId, PeriodId)
select 
ROW_NUMBER() OVER(ORDER BY MEINV.PeriodId DESC) + (select MAX(id) from tempMEINVId) AS id
,0 MEInvId 
,exHIST.iInventoryId InvId
,MEINV.PeriodId PeriodId
from tblInventory exHIST
inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inInvEntity on exHIST.sNameAlphaPart=inInvEntity.Name and inInvEntity.TypeId=4
inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.Id=inInv.EntityId
left join tempMEDates MEINV on MEINV.MEINVDate is null
GO

PRINT '--------------------------------------------'
PRINT ' Importing History (Current)			'
PRINT '--------------------------------------------'
GO

DECLARE @OutputFile NVARCHAR(100) ,    @FilePath NVARCHAR(100) ,    @bcpCommand NVARCHAR(2000)
--SET @bcpCommand = 'bcp "select tempMEINVId.id,inInv.Id InventoryId,MEINV.PeriodId PeriodId,0 Amount,0 Movement,isnull(exHIST.iTotalOnHand,0) OnHand,isnull(exHIST.iTotalOnJob,0) + isnull(exHIST.iTotalOnWIP,0) OnReserv,isnull(exHIST.iTotalOnOrder,0) OnOrde,isnull(exHIST.dUnitPrice,0) UnitPric,isnull(exHIST.dUnitReplacementCost,0) UnitCos,isnull(exHIST.dUnitCost,0) UnitAverag,exHIST.dtFirstMovement FirstSold,exHIST.dtFirstPurchased FirstPurchased,exHIST.dtLastSold LastSold,exHIST.dtLastPurchased LastPurchased,exHIST.dtLastMovement LastMovement from tblInventory exHIST inner join IMPORT_DB.[CDS_SYS].[SYS_Entity] inInvEntity on exHIST.sNameAlphaPart=inInvEntity.Name and inInvEntity.TypeId=4 inner join IMPORT_DB.[CDS_ITM].[ITM_Inventory] inInv on inInvEntity.Id=inInv.EntityId left join tempMEDates MEINV on MEINV.MEINVDate is null INNER JOIN tempMEINVId on exHIST.iInventoryId=tempMEINVId.InvId AND MEINV.PeriodId=tempMEINVId.PeriodId " queryout '
SET @bcpCommand = 'bcp "SELECT tempMEINVId.id AS Id,inInvEntity.InventoryId AS InventoryId,MEINV.PeriodId AS PeriodId,0 AS Amount,0 AS Movement,ISNULL(exHIST.iTotalOnHand, 0) AS OnHand,ISNULL(exHIST.iTotalOnHold, 0) AS OnHold,ISNULL(exHIST.iTotalOnJob, 0) + ISNULL(exHIST.iTotalOnWIP, 0) AS OnReserve,ISNULL(exHIST.iTotalOnOrder, 0) AS OnOrder,ISNULL(exHIST.dUnitPrice, 0) AS UnitPrice,ISNULL(exHIST.dUnitReplacementCost, 0) AS UnitCost,ISNULL(exHIST.dUnitCost, 0) AS UnitAverage,exHIST.dtFirstMovement AS FirstSold,exHIST.dtFirstPurchased AS FirstPurchased,exHIST.dtLastSold AS LastSold,exHIST.dtLastPurchased AS LastPurchased,exHIST.dtLastMovement AS LastMovement FROM EXPORT_DB..tblInventory AS exHIST INNER JOIN EXPORT_DB..tempInventory AS inInvEntity ON inInvEntity.InventoryGuid = exHIST.pkInventoryGuid INNER JOIN EXPORT_DB..tempMEDates AS MEINV ON MEINV.MEINVDate IS NULL INNER JOIN EXPORT_DB..tempMEINVId ON exHIST.iInventoryId = tempMEINVId.InvId AND MEINV.PeriodId = tempMEINVId.PeriodId WHERE MEINV.StartDate > ( SELECT TOP 1 StartDate FROM EXPORT_DB..tempImportStartDate );" queryout '
SET @FilePath = 'BCPDIR\'
SET @OutputFile = 'ITM_History2.dat'
SET @bcpCommand = @bcpCommand + @FilePath + @OutputFile + ' -c -r"\n" -t, -T -S'+ @@servername
exec master..xp_cmdshell @bcpCommand

--truncate table IMPORT_DB..ITM_History

BULK INSERT IMPORT_DB.[CDS_ITM].[ITM_History]
FROM 'BCPDIR\ITM_History2.dat'
WITH 
     (
         FORMATFILE = 'FORMAT_LOCATION\ITM_History.xml'
	 );
GO

PRINT '--------------------------------------------'
PRINT ' Removing Default Constraints for History '
PRINT '--------------------------------------------'
GO

ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] DROP CONSTRAINT DF_ITM_History_FirstSold
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] DROP CONSTRAINT DF_ITM_History_FirstPurchased
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] DROP CONSTRAINT DF_ITM_History_LastSold
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] DROP CONSTRAINT DF_ITM_History_LastPurchased
GO
ALTER TABLE IMPORT_DB.[CDS_ITM].[ITM_History] DROP CONSTRAINT DF_ITM_History_LastMovement
GO


PRINT '--------------------------------------------'
PRINT ' Updating History Dates (Firstmovement)'
PRINT '--------------------------------------------'
GO
UPDATE IMPORT_DB.CDS_ITM.ITM_History SET FirstSold = dtFirstMovement FROM 
IMPORT_DB.CDS_ITM.ITM_History
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Period on ITM_History.PeriodId = SYS_Period.Id
LEFT JOIN tempInventory on ITM_History.InventoryId = tempInventory.InventoryId
LEFT JOIN tblInventory on tblInventory.dtFirstMovement is not null AND tempInventory.InventoryGuid = tblInventory.pkInventoryGuid and SYS_Period.StartDate > dtFirstMovement
GO 

--UPDATE IMPORT_DB.CDS_ITM.ITM_History SET FirstSold = dtFirstMovement FROM 
--IMPORT_DB.CDS_ITM.ITM_History
--LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Period on ITM_History.PeriodId = SYS_Period.Id
--LEFT JOIN tempInventory on ITM_History.InventoryId = tempInventory.InventoryId
--LEFT JOIN tblInventory on tempInventory.InventoryGuid = tblInventory.pkInventoryGuid AND tblInventory.dtFirstMovement is not null and SYS_Period.StartDate > dtFirstMovement
--GO

PRINT '--------------------------------------------'
PRINT ' Updating History Movement'
PRINT '--------------------------------------------'
GO
UPDATE IMPORT_DB.[CDS_ITM].[ITM_History] SET Movement=isnull(exInv.histMove,0)
FROM
IMPORT_DB.[CDS_ITM].[ITM_History] inHist 
inner join temp24MonthHistMap on inHist.PeriodId=temp24MonthHistMap.PeriodId
inner join tempInventory inInvEntity on inInvEntity.InventoryId=inHist.InventoryId 
INNER JOIN
   (SELECT 
   pkInventoryGuid, cast(d01month as money) [01] , cast(d02Month as money) [02], cast(d03Month as money) [03]  , cast(d04Month as money) [04]  , cast(d05Month as money) [05]  , cast(d06Month as money) [06]  , cast(d07Month as money) [07]  , cast(d08Month as money) [08]  , cast(d09Month as money) [09]  
, cast(d10Month as money) [10]  , cast(d11Month as money) [11]  , cast(d12Month as money) [12]  , cast(d13Month as money) [13]  , cast(d14Month as money) [14]  , cast(d15Month as money) [15]  , cast(d16Month as money) [16]  , cast(d17Month as money) [17] , cast(d18Month as money) [18]  
, cast(d19Month as money) [19]  , cast(d20Month as money) [20]  , cast(d21Month as money) [21]  , cast(d22Month as money) [22]  , cast(d23Month as money) [23]  , cast(d24Month as money) [24]  
   FROM tblInventory) p
UNPIVOT
   (histMove FOR dMonth IN ([01],[02],[03],[04],[05],[06],[07],[08],[09],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24])
)AS exInv on temp24MonthHistMap.MonthId=cast(exInv.dMonth as int) AND exInv.pkInventoryGuid=inInvEntity.InventoryGuid 

GO

IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tempMEINVId'))
	drop table EXPORT_DB.dbo.tempMEINVId
GO

/****** Object:  Index [IDX_tblMonthEndInventory_iMonthEndInventoryId]    Script Date: 2015/09/17 11:27:06 AM ******/
DROP INDEX [IDX_tblMonthEndInventory_iMonthEndInventoryId] ON EXPORT_DB.[dbo].[tblMonthEndInventory]
GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO