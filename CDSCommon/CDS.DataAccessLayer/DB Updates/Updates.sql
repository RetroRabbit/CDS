
/****** Object:  Schema [CDS_APP]    Script Date: 11/17/2015 1:51:52 PM ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'CDS_APP')
EXEC sys.sp_executesql N'CREATE SCHEMA [CDS_APP]'

GO

