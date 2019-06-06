
USE EXPORT_DB
GO


SET IDENTITY_INSERT IMPORT_DB.CDS_ITM.ITM_DIS_Discount ON

INSERT INTO IMPORT_DB.CDS_ITM.ITM_DIS_Discount (Id,InventoryId,EntityId,DiscountTypeId,DiscountAmountTypeId,CompanyDiscountCode,InventoryDiscountCode,VolumeNumber,PriorityDiscount,CompanyDiscount,WorkshopDiscount,VolumeDiscount,StartDate,EndDate,CreatedOn,CreatedBy)
SELECT 
ROW_NUMBER() OVER(ORDER BY iDiscountId) Id
, inItem.Id InventoryId
, inComp.Id EntityId
, disType.Id DiscountTypeId
, disAmountType.Id DiscountAmountTypeId
, sCompanyDiscountCode CompanyDiscountCode
, sInventoryDiscountCode InventoryDiscountCode
, iVolumeNumber VolumeNumber
, case when bIsPriorityDiscount is null then 0 else bIsPriorityDiscount end PriorityDiscount
, dCustomerDiscount CompanyDiscount
, dWorkshopDiscount WorkshopDiscount
, dVolumeDiscount VolumeDiscount
, case when dtStartDate is null then dateadd(year,-1,getdate()) else dtStartDate end StartDate
, dtEndDate EndDate
, dis.dtCreatedOn CreatedOn
, isnull(Creator.Id,1) CreatedBy
from tblDiscount dis
left join tblInventory i on dis.fkInventoryGuid=i.pkInventoryGuid
left join IMPORT_DB.CDS_SYS.SYS_Entity inEntity on i.sNameAlphaPart=inEntity.Name
left join IMPORT_DB.CDS_ITM.ITM_Inventory inItem on inEntity.Id=inItem.EntityId
left JOIN tblAccount exAcc on dis.fkCompanyGuid=exAcc.fkCompanyGuid
left JOIN GLX_Account a on exAcc.AccountId=a.Id
left JOIN IMPORT_DB.CDS_SYS.SYS_Entity inORGEntity on a.CodeMain=inORGEntity.CodeMain and a.CodeSub=inORGEntity.CodeSub
left join IMPORT_DB.CDS_ORG.ORG_Entity inComp on inORGEntity.Id=inComp.EntityId
left join tlDiscountType exType on exType.pkDiscountTypeGuid=dis.fkDiscountTypeGuid
left join IMPORT_DB.CDS_ITM.ITM_DIS_Type disType on exType.sName=disType.Name
left join tlDiscountAmountType exAmtType on exAmtType.pkDiscountAmountTypeGuid=dis.fkDiscountAmountTypeGuid
left join IMPORT_DB.CDS_ITM.ITM_DIS_AmountType disAmountType on exAmtType.sName=disAmountType.Name
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on dis.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.CDS_ITM.ITM_DIS_Discount OFF

GO


SET IDENTITY_INSERT IMPORT_DB.CDS_ORG.ORG_TRX_LostSale ON

INSERT INTO IMPORT_DB.CDS_ORG.ORG_TRX_LostSale (Id,CompanyId,ShortName,Description,Reason,Quantity,CreatedBy,CreatedOn)
SELECT
ROW_NUMBER() OVER(ORDER BY iLostSaleId) Id
, oc.Id CompanyId
, isnull(sPartCode ,'') ShortName
, isnull(sPartDescription,'') Description
, isnull(sReason,'') Reason
, dQuantity Quantity
, isnull(Creator.Id,1) CreatedBy
, ls.dtCreatedOn CreatedOn
FROM tblLostSale ls
LEFT JOIN tblCompany c on ls.sCustomer=c.sTradingName and bIsDebtor=1 and (bIsArchived is not null and bIsArchived<>1)
INNER JOIN tblAccount exAcc on c.pkCompanyGuid=exAcc.fkCompanyGuid
INNER JOIN GLX_Account a on exAcc.AccountId=a.Id
INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity e on a.CodeMain=e.CodeMain and a.CodeSub=e.CodeSub
inner join IMPORT_DB.CDS_ORG.ORG_Entity oe on e.id=oe.EntityId
inner join IMPORT_DB.CDS_ORG.ORG_Company oc on oe.id=oc.EntityId 
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on ls.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where ISNUMERIC(dQuantity) = 1

SET IDENTITY_INSERT IMPORT_DB.CDS_ORG.ORG_TRX_LostSale OFF

GO

/*
SET IDENTITY_INSERT IMPORT_DB.dbo.GLX_Recon ON

INSERT INTO IMPORT_DB..GLX_Recon (Id,Reference,Description,StartDate,EndDate,StartAmount,EndAmount,StatusId,CreatedBy,CreatedOn)
SELECT 
ROW_NUMBER() OVER(ORDER BY iReconcileSessionId) Id
, r.pkReconcileSessionGuid Reference
, null Description
, dtStartDate StartDate
, dtEndDate EndDate
, dOpeningBalance StartAmount
, dClosingBalance EndAmount
, CASE WHEN r.fkStatusGuid='3142D822-9E01-4084-8C0A-0636ACCAAE62' THEN 5 WHEN r.fkStatusGuid='05D0AE34-C00F-452C-99A6-96DC77FE0BB1' THEN 2 WHEN r.fkStatusGuid='8A9F90FB-3796-492B-88A3-36E03CEDD576' THEN 1 ELSE 2 END StatusId
, isnull(Creator.Id,1) CreatedBy
, r.dtCreatedOn CreatedOn
FROM tblReconcileSession r
LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator on r.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.dbo.GLX_Recon OFF

GO


UPDATE l SET ReconId=inR.Id
FROM tblReconcileSession r
INNER JOIN tblCash c on r.pkReconcileSessionGuid=c.fkReconGuid
INNER JOIN tblGeneralLedgerAccount a on c.fkGeneralLedgerAccountGuid=a.pkGeneralLedgerAccountGuid
INNER JOIN tempGLAccount inA on a.pkGeneralLedgerAccountGuid=inA.AccountGuid
LEFT JOIN tempGLX_Header h on c.iCashId=h.CashId
LEFT JOIN cds_pegasus..GLX_Line l on inA.AccountId=l.EntityId and l.HeaderId=h.Id
LEFT JOIN cds_pegasus.dbo.GLX_Recon inR on r.pkReconcileSessionGuid=inR.Reference

GO
*/

PRINT '--------------------------------------------'
PRINT 'Adding Indexes for History'
PRINT '--------------------------------------------'
GO

/****** Object:  Index [IDX_VW_Entity_PeriodId]    Script Date: 2015/09/16 5:12:27 PM ******/
CREATE NONCLUSTERED INDEX [IDX_VW_Entity_PeriodId] ON IMPORT_DB.[CDS_ITM].[ITM_History]
(
	[PeriodId] ASC
)
INCLUDE ( 	[InventoryId],
	[OnHand],
	[OnReserve],
	[OnOrder],
	[UnitPrice],
	[UnitCost],
	[UnitAverage],
	[FirstSold],
	[FirstPurchased],
	[LastSold],
	[LastPurchased],
	[LastMovement]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

/****** Object:  Index [Idx_ITM_History_PeriodId_InventoryId_Amount]    Script Date: 2015/09/16 5:12:31 PM ******/
CREATE NONCLUSTERED INDEX [Idx_ITM_History_PeriodId_InventoryId_Amount] ON IMPORT_DB.[CDS_ITM].[ITM_History]
(
	[PeriodId] ASC
)
INCLUDE ( 	[InventoryId],
	[Amount]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

/****** Object:  Index [Idx_ITM_History_InventoryId_PeriodId]    Script Date: 2015/09/16 5:12:41 PM ******/
CREATE NONCLUSTERED INDEX [Idx_ITM_History_InventoryId_PeriodId] ON IMPORT_DB.[CDS_ITM].[ITM_History]
(
	[InventoryId] ASC
)
INCLUDE ( 	[PeriodId]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

PRINT '--------------------------------------------'
PRINT 'Adding Indexes for Documentline'
PRINT '--------------------------------------------'
GO

/****** Object:  Index [IDX_VW_Transaction_DOC_Header]    Script Date: 2015/09/18 8:54:21 AM ******/
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_DOC_Header] ON IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
(
	[HeaderId] ASC
)
INCLUDE ( 	[Id],
	[ItemId],
	[DiscountPercentage],
	[Description],
	[Quantity],
	[Amount],
	[Total],
	[TotalTax],
	[CreatedOn]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

/****** Object:  Index [IDX_VW_Transaction_Item]    Script Date: 2015/09/18 9:24:25 AM ******/
CREATE NONCLUSTERED INDEX [IDX_VW_Transaction_Item] ON IMPORT_DB.[CDS_SYS].[SYS_DOC_Line]
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
	[CreatedOn]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

-- ------------------------------------------
-- Import Company Contacts
-- ------------------------------------------
print '------------------------------------------'
print 'Import Company Contacts'
print '------------------------------------------'
GO

SELECT exComp.pkCompanyGuid,
       NULL PersonId,
       IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, 1, CHARINDEX(' ', sContact, 1)), ISNULL(sContact, '')) Firstname,
       IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, CHARINDEX(' ', sContact, 1) + 1, 10000), '') Lastname,
       inE.Id EntityId,
       1 DepartmentId,
       sTelephone1 Telephone,
       sFax1 Fax,
       sEmailAddress1 Email,
       sNotes Note,
       exComp.dtCreatedOn CreatedOn,
       ISNULL(Creator.CreatedBy, 1) CreatedBy INTO tempOrgContacts
FROM tblCompany exComp
     INNER JOIN tblAccount exAcc ON exComp.fkAccountGuid = exAcc.pkAccountGuid
     INNER JOIN GLX_Account a ON exAcc.AccountId = a.Id
     INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE ON a.CodeMain = inE.CodeMain
                                                                       AND a.CodeSub = inE.CodeSub
     INNER JOIN IMPORT_DB.CDS_ORG.ORG_Entity org ON inE.Id = org.EntityId
     INNER JOIN IMPORT_DB.CDS_ORG.ORG_Company comp ON org.id = comp.EntityId
     LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator ON exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT;
INSERT INTO tempOrgContacts
       SELECT exComp.pkCompanyGuid,
              NULL PersonId,
              IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, 1, CHARINDEX(' ', sContact, 1)), ISNULL(sContact, '')) Firstname,
              IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, CHARINDEX(' ', sContact, 1) + 1, 10000), '') Lastname,
              inE.Id EntityId,
              2 DepartmentId,
              sTelephone2 Telephone,
              sFax2 Fax,
              sEmailAddress2 Email,
              sNotes2 Note,
              exComp.dtCreatedOn CreatedOn,
              ISNULL(Creator.CreatedBy, 1) CreatedBy
       FROM tblCompany exComp
            INNER JOIN tblAccount exAcc ON exComp.fkAccountGuid = exAcc.pkAccountGuid
            INNER JOIN GLX_Account a ON exAcc.AccountId = a.Id
            INNER JOIN IMPORT_DB.CDS_SYS.SYS_Entity inE ON a.CodeMain = inE.CodeMain
                                                                              AND a.CodeSub = inE.CodeSub
            INNER JOIN IMPORT_DB.CDS_ORG.ORG_Entity org ON inE.Id = org.EntityId
            INNER JOIN IMPORT_DB.CDS_ORG.ORG_Company comp ON org.id = comp.EntityId
            LEFT JOIN IMPORT_DB.CDS_SYS.SYS_Person Creator ON exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT;
UPDATE tempOrgContacts
  SET PersonId = PersonData.PersonId
FROM tempOrgContacts
     INNER JOIN( SELECT RANK() OVER(ORDER BY tempOrgContacts.pkCompanyGuid,
                                             tempOrgContacts.DepartmentId) + ( 
                                                                               SELECT MAX(id)
                                                                               FROM IMPORT_DB.CDS_SYS.SYS_Person ) PersonId,
                        pkCompanyGuid,
                        DepartmentId
                 FROM tempOrgContacts ) PersonData ON tempOrgContacts.pkCompanyGuid = PersonData.pkCompanyGuid
                                                  AND tempOrgContacts.DepartmentId = PersonData.DepartmentId;
SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Person ON;
INSERT INTO IMPORT_DB.CDS_SYS.SYS_Person
       ( Id,
         Title,
         Name,
         Surname,
         Archived,
         CreatedOn,
         CreatedBy
       )
       SELECT PersonId Id,
              NULL Title,
              SUBSTRING(Firstname,1,20)  Name,
              SUBSTRING(Lastname ,1,50) Surname,
              0 Archived,
              CreatedOn CreatedOn,
              CreatedBy CreatedBy
       FROM tempOrgContacts;
SET IDENTITY_INSERT IMPORT_DB.CDS_SYS.SYS_Person OFF;
INSERT INTO IMPORT_DB.CDS_ORG.ORG_Contact
       ( CompanyId,
         PersonId,
         DepartmentId,
         Telephone1,
         Telephone2,
         Fax,
         Email,
         Note,
         CreatedOn,
         CreatedBy,
         [Default]
       )
       SELECT EntityId CompanyId,
              PersonId PersonId,
              DepartmentId DepartmentId,
              Telephone Telephone1,
              NULL Telephone2,
              Fax Fax,
              Email Email,
              Note Note,
              CreatedOn CreatedOn,
              CreatedBy CreatedBy,
              1 [Default]
       FROM tempOrgContacts;
GO


USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO