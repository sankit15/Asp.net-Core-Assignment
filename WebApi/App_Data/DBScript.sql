create Database demo

go

USE [demo]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 01-04-2021 09:41:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuppliersRate]    Script Date: 01-04-2021 09:41:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuppliersRate](
	[SupplierID] [int] NULL,
	[Rate] [int] NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Suppliers] ([SupplierID], [Name]) VALUES (1, N'A')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [Name]) VALUES (2, N'B')
GO
INSERT [dbo].[Suppliers] ([SupplierID], [Name]) VALUES (3, N'C')
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (1, 10, CAST(N'2015-01-01' AS Date), CAST(N'2015-03-31' AS Date))
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (1, 20, CAST(N'2015-04-01' AS Date), CAST(N'2015-05-31' AS Date))
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (1, 10, CAST(N'2015-05-30' AS Date), CAST(N'2015-07-25' AS Date))
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (1, 25, CAST(N'2015-10-01' AS Date), NULL)
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (2, 100, CAST(N'2016-11-01' AS Date), NULL)
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (3, 30, CAST(N'2016-12-01' AS Date), CAST(N'2017-01-31' AS Date))
GO
INSERT [dbo].[SuppliersRate] ([SupplierID], [Rate], [StartDate], [EndDate]) VALUES (3, 30, CAST(N'2017-01-02' AS Date), NULL)
GO
/****** Object:  StoredProcedure [dbo].[SP_Supplier]    Script Date: 01-04-2021 09:41:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[SP_Supplier]
(@Type varchar(50)=null,
@SupplierID int=null)
as
begin


if(@Type='AllSuppliers')
begin
insert into temp values(@Type)
insert into temp values(@SupplierID)
select SuppliersRate.SupplierID,SuppliersRate.Rate from Suppliers inner join SuppliersRate on Suppliers.SupplierID=SuppliersRate.SupplierID

end
else if(@Type='OverlapSuppliers')
begin

select SuppliersRate.SupplierID,SuppliersRate.Rate from Suppliers inner join SuppliersRate on Suppliers.SupplierID=SuppliersRate.SupplierID
where SuppliersRate.enddate is null and Suppliers.SupplierID=case when @SupplierID is null then Suppliers.SupplierID  else @SupplierID end

end

end
GO
