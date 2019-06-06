
USE EXPORT_DB
GO


SET IDENTITY_INSERT IMPORT_DB.[CDS_ITM].[ITM_DIS_Discount] ON

INSERT INTO IMPORT_DB.[CDS_ITM].[ITM_DIS_Discount] (Id,InventoryId,EntityId,DiscountTypeId,DiscountAmountTypeId,CompanyDiscountCode,InventoryDiscountCode,VolumeNumber,PriorityDiscount,CompanyDiscount,WorkshopDiscount,VolumeDiscount,StartDate,EndDate,CreatedOn,CreatedBy)
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
left join IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity on i.sNameAlphaPart=inEntity.Name
left join IMPORT_DB.[CDS_ITM].ITM_Inventory inItem on inEntity.Id=inItem.EntityId
left join tempCompany c on dis.fkCompanyGuid=c.CompanyGuid
left join IMPORT_DB.[CDS_ORG].ORG_Entity inComp on c.CompanyId=inComp.EntityId
left join tlDiscountType exType on exType.pkDiscountTypeGuid=dis.fkDiscountTypeGuid
left join IMPORT_DB.[CDS_ITM].ITM_DIS_Type disType on exType.sName=disType.Name
left join tlDiscountAmountType exAmtType on exAmtType.pkDiscountAmountTypeGuid=dis.fkDiscountAmountTypeGuid
left join IMPORT_DB.[CDS_ITM].ITM_DIS_AmountType disAmountType on exAmtType.sName=disAmountType.Name
LEFT JOIN IMPORT_DB.[CDS_SYS].SYS_Person Creator on dis.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where NOT (inItem.Id is null and sInventoryDiscountCode is null) AND NOT (inComp.Id is null and sCompanyDiscountCode is null)
SET IDENTITY_INSERT IMPORT_DB.[CDS_ITM].[ITM_DIS_Discount] OFF

GO



SET IDENTITY_INSERT IMPORT_DB.[CDS_ORG].[ORG_TRX_LostSale] ON

INSERT INTO IMPORT_DB.[CDS_ORG].[ORG_TRX_LostSale] (Id,CompanyId,ShortName,Description,Reason,Quantity,CreatedBy,CreatedOn)
SELECT
ROW_NUMBER() OVER(ORDER BY iLostSaleId) Id
, oc.Id CompanyId
, isnull(sPartCode ,'') ShortName
, isnull(sPartDescription,'') Description
, isnull(sReason,'') Reason
, CASE dQuantity WHEN '.' THEN CAST(0.0000 AS DECIMAL(18,4)) ELSE dQuantity END Quantity
, isnull(Creator.Id,1) CreatedBy
, ls.dtCreatedOn CreatedOn
FROM tblLostSale ls
inner JOIN tblCompany c on ls.sCustomer=c.sTradingName and bIsDebtor=1 and (bIsArchived is not null and bIsArchived<>1)
LEFT JOIN tempCompany on c.pkCompanyGuid=tempCompany.CompanyGuid 
LEFT JOIN IMPORT_DB.[CDS_ORG].[ORG_Entity] oe on tempCompany.CompanyId=oe.EntityId
LEFT JOIN IMPORT_DB.[CDS_ORG].[ORG_Company] oc on oe.Id=oc.EntityId
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on ls.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT
where ISNUMERIC(dQuantity) = 1

SET IDENTITY_INSERT IMPORT_DB.[CDS_ORG].[ORG_TRX_LostSale] OFF

GO

/*
SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Recon] ON

INSERT INTO IMPORT_DB.[CDS_GLX].[GLX_Recon] (Id,Reference,Description,StartDate,EndDate,StartAmount,EndAmount,StatusId,CreatedBy,CreatedOn)
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
LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator on r.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT

SET IDENTITY_INSERT IMPORT_DB.[CDS_GLX].[GLX_Recon] OFF

GO


UPDATE l SET ReconId=inR.Id
FROM tblReconcileSession r
INNER JOIN tblCash c on r.pkReconcileSessionGuid=c.fkReconGuid
INNER JOIN tblGeneralLedgerAccount a on c.fkGeneralLedgerAccountGuid=a.pkGeneralLedgerAccountGuid
INNER JOIN tempGLAccount inA on a.pkGeneralLedgerAccountGuid=inA.AccountGuid
LEFT JOIN tempGLX_Header h on c.iCashId=h.CashId
LEFT JOIN cds_pegasus..GLX_Line l on inA.AccountId=l.EntityId and l.HeaderId=h.Id
LEFT JOIN cds_pegasus.[CDS_GLX].[GLX_Recon] inR on r.pkReconcileSessionGuid=inR.Reference

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


--DECLARE @DATETIME_MIN DATETIME = CAST(0 AS DATETIME)
--update IMPORT_DB.[CDS_ITM].[ITM_History] set FirstSold = NULL WHERE FirstSold IS NOT NULL AND FirstSold = @DATETIME_MIN
--GO
--DECLARE @DATETIME_MIN DATETIME = CAST(0 AS DATETIME)
--update IMPORT_DB.[CDS_ITM].[ITM_History] set FirstPurchased = NULL WHERE FirstPurchased IS NOT NULL AND FirstPurchased = @DATETIME_MIN
--GO
--DECLARE @DATETIME_MIN DATETIME = CAST(0 AS DATETIME)
--update IMPORT_DB.[CDS_ITM].[ITM_History] set LastSold = NULL WHERE LastSold IS NOT NULL AND LastSold = @DATETIME_MIN
--GO
--DECLARE @DATETIME_MIN DATETIME = CAST(0 AS DATETIME)
--update IMPORT_DB.[CDS_ITM].[ITM_History] set LastPurchased = NULL WHERE LastPurchased IS NOT NULL AND LastPurchased = @DATETIME_MIN
--GO
--DECLARE @DATETIME_MIN DATETIME = CAST(0 AS DATETIME)
--update IMPORT_DB.[CDS_ITM].[ITM_History] set LastMovement = NULL WHERE LastMovement IS NOT NULL AND LastMovement = @DATETIME_MIN
--GO 


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
       inEntity.Id EntityId,
       1 DepartmentId,
       sTelephone1 Telephone,
       sFax1 Fax,
       sEmailAddress1 Email,
       sNotes Note,
       exComp.dtCreatedOn CreatedOn,
       ISNULL(Creator.CreatedBy, 1) CreatedBy INTO tempOrgContacts
FROM tblCompany exComp
     INNER JOIN tblAccount exAccount ON exComp.fkAccountGuid = exAccount.pkAccountGuid
     INNER JOIN tempCompany ON exComp.pkCompanyGuid = tempCompany.CompanyGuid
     INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity ON tempCompany.CompanyId = inEntity.Id
     INNER JOIN IMPORT_DB.[CDS_ORG].[ORG_Entity] inComp ON inEntity.Id = inComp.EntityId
     INNER JOIN tempCostCategory ON tempCostCategory.CCGuid = exAccount.fkCostCategoryGuid
     INNER JOIN tempPaymentTerm ON tempPaymentTerm.TermGuid = exAccount.fkSalesTermGuid
     LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator ON exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT;
INSERT INTO tempOrgContacts
       SELECT exComp.pkCompanyGuid,
              NULL PersonId,
              IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, 1, CHARINDEX(' ', sContact, 1)), ISNULL(sContact, '')) Firstname,
              IIF(CHARINDEX(' ', sContact, 1) <> 0, SUBSTRING(sContact, CHARINDEX(' ', sContact, 1) + 1, 10000), '') Lastname,
              inEntity.Id EntityId,
              2 DepartmentId,
              sTelephone2 Telephone,
              sFax2 Fax,
              sEmailAddress2 Email,
              sNotes2 Note,
              exComp.dtCreatedOn CreatedOn,
              ISNULL(Creator.CreatedBy, 1) CreatedBy
       FROM tblCompany exComp
            INNER JOIN tblAccount exAccount ON exComp.fkAccountGuid = exAccount.pkAccountGuid
            INNER JOIN tempCompany ON exComp.pkCompanyGuid = tempCompany.CompanyGuid
            INNER JOIN IMPORT_DB.[CDS_SYS].[SYS_Entity] inEntity ON tempCompany.CompanyId = inEntity.Id
            INNER JOIN IMPORT_DB.[CDS_ORG].[ORG_Entity] inComp ON inEntity.Id = inComp.EntityId
            INNER JOIN tempCostCategory ON tempCostCategory.CCGuid = exAccount.fkCostCategoryGuid
            INNER JOIN tempPaymentTerm ON tempPaymentTerm.TermGuid = exAccount.fkSalesTermGuid
            LEFT JOIN IMPORT_DB.[CDS_SYS].[SYS_Person] Creator ON exComp.sCreatedBy COLLATE DATABASE_DEFAULT = Creator.Name COLLATE DATABASE_DEFAULT + ' ' + Creator.Surname COLLATE DATABASE_DEFAULT;
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
         [IsDefault]
       )
       SELECT EntityId CompanyId,
              PersonId PersonId,
              DepartmentId DepartmentId,
              Telephone Telephone1,
              NULL Telephone2,
              Fax Fax,
              Email Email,
              SUBSTRING(Note,1,1000) Note,
              CreatedOn CreatedOn,
              CreatedBy CreatedBy,
              1 [IsDefault]
       FROM tempOrgContacts;
GO

USE IMPORT_DB
GO

IF EXISTS( SELECT * FROM master.sys.databases WHERE name = 'cds_rssports' and state = 0 )
BEGIN
	print 'Clean vat entries'
	DELETE CDS_GLX.GLX_Line
	WHERE Id IN( SELECT MAX(GLX_Line.Id)
				 FROM CDS_GLX.GLX_Header
					  INNER JOIN cds_glx.GLX_Line ON GLX_Header.Id = HeaderId
				 WHERE Reference LIKE '36567'
				   AND Description LIKE 'COURIER to ACC#: 0000001_62.'
				 GROUP BY HeaderId,
						  EntityId,
						  Amount,
						  PostedDate
				 HAVING COUNT(1) > 1 );
	-- print 'Clean account Numbers'
	-- UPDATE [CDS_SYS].[SYS_Entity]
	--  SET CodeMain = REPLACE(STR(SUBSTRING(tblGeneralLedgerAccount.sCode, 1, CHARINDEX('/', tblGeneralLedgerAccount.sCode, 1) - 1), 5), SPACE(1), '0'),
	--	  CodeSub = REPLACE(STR(SUBSTRING(tblGeneralLedgerAccount.sCode, CHARINDEX('/', tblGeneralLedgerAccount.sCode, 1) + 1, LEN(tblGeneralLedgerAccount.sCode)), 5), SPACE(1), '0')
	--FROM [CDS_SYS].[SYS_Entity]
	--	 INNER JOIN EXPORT_DB..tblGeneralLedgerAccount ON Name = sName
	--WHERE TypeId = 5
	--  AND CodeMain LIKE '%/%'
	--  AND CodeMain NOT LIKE '%/'
	--  AND CodeSub = '00000';
	--UPDATE IMPORT_DB.[CDS_SYS].[SYS_Entity]
	--  SET CodeMain = REPLACE(STR(SUBSTRING(tblGeneralLedgerAccount.sCode, 1, CHARINDEX('/', tblGeneralLedgerAccount.sCode, 1) - 1), 5), SPACE(1), '0'),
	--	  CodeSub = REPLACE(STR(SUBSTRING(tblGeneralLedgerAccount.sCode, CHARINDEX('/', tblGeneralLedgerAccount.sCode, 1) + 1, LEN(tblGeneralLedgerAccount.sCode)), 5), SPACE(1), '0')
	--FROM [CDS_SYS].[SYS_Entity]
	--	 INNER JOIN EXPORT_DB..tblGeneralLedgerAccount ON Name = sName
	--WHERE TypeId = 5
	--  AND CodeMain LIKE '%/'
	--  AND CodeSub = '00000'; 
END
GO

--print 'Link GLX_Account ControlId and MasterControlId'
--GO

--UPDATE cds_pegasus_rssports.CDS_GLX.GLX_Account
--  SET ControlId = Parent.Id,
--      MasterControlId = Parent.Id
--FROM CDS_GLX.GLX_Account
--     INNER JOIN CDS_SYS.SYS_Entity Child ON GLX_Account.EntityId = Child.Id
--     CROSS JOIN CDS_SYS.SYS_Entity Parent
--WHERE Child.TypeId = 5
--  AND Child.CodeMain = Parent.CodeMain
--  AND Parent.CodeSub = '00000';
GO

print 'Fix System Account types'
UPDATE CDS_GLX.GLX_Account
  SET CDS_GLX.GLX_Account.AccountTypeId = GLX_SystemAccountType.TypeId
FROM CDS_GLX.GLX_Account
     INNER JOIN CDS_GLX.GLX_SiteAccount ON GLX_Account.EntityId = GLX_SiteAccount.EntityId
     INNER JOIN CDS_GLX.GLX_SystemAccountType ON GLX_SiteAccount.TypeId = GLX_SystemAccountType.Id
     INNER JOIN CDS_SYS.SYS_Entity ON GLX_Account.EntityId = SYS_Entity.Id
WHERE GLX_Account.AccountTypeId <> GLX_SystemAccountType.TypeId;
Go

print 'Calculate Input\Output Vat Totals'
GO

--Calculate Input\Output Vat Totals
UPDATE [CDS_GLX].[GLX_History] set Amount = 0
                 FROM [CDS_GLX].[GLX_History] 
                      LEFT JOIN [CDS_SYS].[SYS_Entity] ON SYS_Entity.Id = [GLX_History].EntityId
                 WHERE SYS_Entity.CodeMain IN( '99998','99999' )
                   AND SYS_Entity.CodeSub = '00000' 
GO

UPDATE [CDS_GLX].[GLX_History]
  SET Amount = X.Amount
FROM [CDS_GLX].[GLX_History]
     INNER JOIN( SELECT MAX(GLX_History.Id) Id,
                        SUM(ISNULL(GLX_Line.Amount, 0)) Amount
                 FROM [CDS_GLX].[GLX_History]
                      INNER JOIN [CDS_SYS].[SYS_Period] ON GLX_History.PeriodId = SYS_Period.Id
				  LEFT JOIN [CDS_GLX].[GLX_Header] ON SYS_Period.Id = GLX_Header.PeriodId
                      LEFT JOIN [CDS_GLX].[GLX_Line] ON GLX_Line.HeaderId = GLX_Header.Id AND GLX_History.EntityId = GLX_Line.EntityId 
                      LEFT JOIN [CDS_SYS].[SYS_Entity] ON SYS_Entity.Id = GLX_Line.EntityId
                 WHERE SYS_Entity.CodeMain IN( '99998','99999' )
                   AND SYS_Entity.CodeSub = '00000' 
                 GROUP BY GLX_History.PeriodId,
                          GLX_History.EntityId ) X ON GLX_History.Id = X.Id;
GO

UPDATE [CDS_GLX].[GLX_History]
SET Amount = ISNULL(
(

SELECT SUM(Amount) 
FROM [CDS_GLX].[GLX_History] InnerHistory
INNER JOIN [CDS_SYS].[SYS_Entity] ON  InnerHistory.EntityId = SYS_Entity.Id
INNER JOIN [CDS_SYS].[SYS_Period] ON  InnerHistory.PeriodId = [SYS_Period].Id
  WHERE SYS_Entity.CodeMain IN( '99998', '99999' )
                   AND SYS_Entity.CodeSub = '00000'
    AND InnerHistory.PeriodId <= OuterHistory.PeriodId
    AND InnerHistory.EntityId = OuterHistory.EntityId
),0)
FROM [CDS_GLX].[GLX_History] OuterHistory
INNER JOIN [CDS_SYS].[SYS_Entity] ON  OuterHistory.EntityId = SYS_Entity.Id
INNER JOIN [CDS_SYS].[SYS_Period] ON  OuterHistory.PeriodId = [SYS_Period].Id
  WHERE SYS_Entity.CodeMain IN( '99998', '99999' )
                   AND SYS_Entity.CodeSub = '00000' 
GO

--Subtract Input\Output Vat Totals from Vat Control
UPDATE [CDS_GLX].[GLX_History]
  SET Amount = d.Amount - child.Amount
FROM [CDS_GLX].[GLX_History] d
     INNER JOIN( SELECT PeriodId,
                        SUM(Amount) Amount
                 FROM [CDS_GLX].[GLX_History]
                 WHERE EntityId IN( 
                                    SELECT Id
                                    FROM [CDS_SYS].[SYS_Entity]
                                    WHERE CodeMain IN (
                                             SELECT CodeMain
                                             FROM [CDS_GLX].[GLX_SiteAccount]
                                                  INNER JOIN [CDS_SYS].[SYS_Entity] Contr ON Contr.Id = GLX_SiteAccount.EntityId
                                             WHERE GLX_SiteAccount.TypeId in (22,23) )
                                     )
                 GROUP BY PeriodId ) AS child ON d.PeriodId = child.PeriodId
WHERE d.EntityId = ( SELECT EntityId
                     FROM [CDS_GLX].[GLX_SiteAccount]
                     WHERE TypeId = 21 );
GO

update [CDS_GLX].[GLX_History] set Amount=d.Amount-child.Amount
from [CDS_GLX].[GLX_History] d
inner join (
select PeriodId,sum(Amount) Amount from [CDS_GLX].[GLX_History] where EntityId in (
select Id from [CDS_SYS].[SYS_Entity] where CodeMain=(select CodeMain from [CDS_GLX].[GLX_SiteAccount] inner join [CDS_SYS].[SYS_Entity] Contr on Contr.Id=GLX_SiteAccount.EntityId where GLX_SiteAccount.TypeId=9) and CodeSub<>'00000')
group by PeriodId
) as child on d.PeriodId=child.PeriodId
where d.EntityId=(select EntityId from [CDS_GLX].[GLX_SiteAccount] where TypeId=9)
GO

update [CDS_GLX].[GLX_History] set Amount=d.Amount-child.Amount
from [CDS_GLX].[GLX_History] d
inner join (
select PeriodId,sum(Amount) Amount from [CDS_GLX].[GLX_History] where EntityId in (
select Id from [CDS_SYS].[SYS_Entity] where CodeMain=(select CodeMain from [CDS_GLX].[GLX_SiteAccount] inner join [CDS_SYS].[SYS_Entity] Contr on Contr.Id=GLX_SiteAccount.EntityId where GLX_SiteAccount.TypeId=8) and CodeSub<>'00000')
group by PeriodId
) as child on d.PeriodId=child.PeriodId
where d.EntityId=(select EntityId from [CDS_GLX].[GLX_SiteAccount] where TypeId=8)
GO

USE  IMPORT_DB
GO
DBCC SHRINKFILE ('IMPORT_DB_split_log', 1)
GO