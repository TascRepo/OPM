USE [master]
GO
/****** Object:  Database [OpmDB]    Script Date: 10/6/2021 11:55:13 AM ******/
CREATE DATABASE [OpmDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OpmDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OpmDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OpmDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OpmDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OpmDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OpmDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OpmDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OpmDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OpmDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OpmDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OpmDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OpmDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OpmDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OpmDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OpmDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OpmDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OpmDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OpmDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OpmDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OpmDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OpmDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OpmDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OpmDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OpmDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OpmDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OpmDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OpmDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OpmDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OpmDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OpmDB] SET  MULTI_USER 
GO
ALTER DATABASE [OpmDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OpmDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OpmDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OpmDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OpmDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OpmDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OpmDB] SET QUERY_STORE = OFF
GO
USE [OpmDB]
GO
/****** Object:  Table [dbo].[Case]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Case](
	[id] [varchar](10) NOT NULL,
	[id_packagelist] [varchar](10) NULL,
	[make_in] [varchar](20) NULL,
	[dimension] [varchar](20) NULL,
	[weight] [int] NULL,
	[volume] [int] NULL,
 CONSTRAINT [PK_Case] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogAdmin]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogAdmin](
	[stt] [int] IDENTITY(1,1) NOT NULL,
	[ctlID] [varchar](100) NULL,
	[ctlname] [varchar](100) NULL,
	[ctlparent] [varchar](100) NULL,
	[haveparent] [int] NULL,
	[isdeleted] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CatalogAdmin2]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatalogAdmin2](
	[stt] [int] IDENTITY(1,1) NOT NULL,
	[ctlID] [varchar](100) NULL,
	[ctlname] [varchar](100) NULL,
	[ctlparent] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[id] [varchar](50) NOT NULL,
	[namecontract] [nvarchar](250) NULL,
	[codeaccouting] [varchar](250) NULL,
	[datesigned] [date] NULL,
	[typecontract] [nvarchar](250) NULL,
	[durationcontract] [int] NULL,
	[activedate] [date] NULL,
	[valuecontract] [float] NULL,
	[durationpo] [int] NULL,
	[id_siteA] [nvarchar](250) NULL,
	[id_siteB] [nvarchar](250) NULL,
	[phuluc] [varchar](250) NULL,
	[vbgurantee] [varchar](250) NULL,
	[KHMS] [nvarchar](250) NULL,
	[experationDate] [date] NULL,
	[blvalue] [int] NULL,
	[garanteeCreatedDate] [date] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract_Goods]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract_Goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idContract] [varchar](50) NOT NULL,
	[code] [nvarchar](200) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[unit] [nvarchar](20) NULL,
	[priceUnit] [float] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery_PO]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery_PO](
	[Delivery_PO_Id] [int] IDENTITY(1,1) NOT NULL,
	[NumberConfirmPO] [nvarchar](250) NULL,
	[Province] [nvarchar](250) NULL,
	[Count_PO] [int] NULL,
	[Number_PO] [int] NULL,
	[Date_Delivery] [date] NULL,
	[id_po] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Delivery_PO_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[serial] [varchar](10) NOT NULL,
	[id_storage] [varchar](10) NULL,
	[MAC] [varchar](20) NULL,
	[serial_gpon] [varchar](10) NULL,
	[device_name] [varchar](50) NULL,
	[note] [varchar](50) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DP]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DP](
	[id] [varchar](10) NOT NULL,
	[id_po] [varchar](30) NULL,
	[id_contract] [varchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[dateopen] [date] NULL,
	[datedeliver] [date] NULL,
	[mskt] [varchar](10) NULL,
	[note] [nvarchar](50) NULL,
 CONSTRAINT [PK_DP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListExpected_DP]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListExpected_DP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceName] [nvarchar](max) NULL,
	[NumberDevice] [int] NULL,
	[id_dp] [nvarchar](150) NULL,
	[type] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListExpected_PO]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListExpected_PO](
	[id_po] [varchar](30) NOT NULL,
	[id_province] [varchar](20) NOT NULL,
	[numberofdevice] [int] NULL,
	[nameofdevice] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NTKT]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NTKT](
	[id] [nvarchar](20) NOT NULL,
	[id_po] [varchar](30) NULL,
	[numberofdevice] [int] NULL,
	[deliver_date_expected] [date] NULL,
	[email_request_status] [varchar](10) NULL,
	[create_date] [date] NULL,
	[numberofdevice2] [int] NULL,
	[number] [int] NULL,
	[date_BBNTKT] [date] NULL,
	[date_BBKTKT] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NTLicense]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NTLicense](
	[id] [varchar](10) NOT NULL,
	[id_ntkt] [varchar](10) NOT NULL,
	[vdb_naplicense] [varchar](50) NULL,
	[vb_ntlicense] [varchar](50) NULL,
 CONSTRAINT [PK_NTLicense] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_ntkt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageList]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageList](
	[id] [varchar](10) NOT NULL,
	[id_dp] [varchar](10) NULL,
	[date_deliver] [date] NULL,
	[type] [varchar](10) NULL,
	[target_address] [varchar](50) NULL,
	[note] [varchar](50) NULL,
 CONSTRAINT [PK_PackageList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PO]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PO](
	[id] [varchar](30) NOT NULL,
	[id_contract] [varchar](50) NOT NULL,
	[po_number] [varchar](10) NULL,
	[numberofdevice] [float] NULL,
	[datecreated] [date] NULL,
	[priceunit] [int] NULL,
	[dateconfirm] [date] NULL,
	[dateperform] [date] NULL,
	[dateline] [date] NULL,
	[targetdeliveradd] [nchar](10) NULL,
	[email_BLBH_status] [varchar](10) NULL,
	[email_BLTH_status] [varchar](10) NULL,
	[totalvalue] [float] NULL,
	[tupo] [int] NULL,
	[tupo_datecreated] [date] NULL,
	[confirmpo_number] [varchar](20) NULL,
	[confirmpo_datecreated] [date] NULL,
	[bltupo] [int] NULL,
	[bltupo_datecreated] [date] NULL,
	[confirmpo_dateactive] [date] NULL,
 CONSTRAINT [PK_PO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provinces]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameProvinces] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site_Info]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site_Info](
	[id] [nvarchar](250) NULL,
	[type] [varchar](10) NULL,
	[headquater_info] [nvarchar](250) NULL,
	[address] [nvarchar](250) NULL,
	[phonenumber] [varchar](20) NULL,
	[tin] [varchar](20) NULL,
	[account] [varchar](20) NULL,
	[representative] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storage]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage](
	[id] [varchar](10) NOT NULL,
	[id_case] [varchar](10) NULL,
 CONSTRAINT [PK_Storage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VBConfirmPO]    Script Date: 10/6/2021 11:55:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VBConfirmPO](
	[id_ConfirmPO] [varchar](50) NULL,
	[id_po] [varchar](30) NULL,
	[vb_ConfirmPO] [varchar](250) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CatalogAdmin] ON 

INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1, N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', N'111-2020/CUVT-ANSV/DTRR-KHMS', NULL, 0, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13055, N'PO_51/CUVT-KV', N'PO1', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3, N'Contract_113-2020/CUVT-ANSV/DTRR-KHMS', N'113-2020/CUVT-ANSV/DTRR-KHMS', NULL, 0, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13059, N'PO_5133/CUVT-KV', N'PO12', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13060, N'PO_513/CUVT-KV', N'PO3', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (6, N'Contract_116-2020/CUVT-ANSV/DTRR-KHMS', N'116-2020/CUVT-ANSV/DTRR-KHMS', NULL, 0, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13061, N'PO_51/CUVT-KV', N'PO1', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13062, N'PO_5/CUVT-KV', N'PO12', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (12, N'NTKT_A1', N'NTKT1', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13, N'NTKT_A2', N'NTKT2', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (16, N'NTKT_B1', N'NTKT1', N'Contract_112-2020/CUVT-ANSV/DTRR-KHMS', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (17, N'NTKT_B2', N'NTKT2', N'Contract_112-2020/CUVT-ANSV/DTRR-KHMS', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (18, N'DP_C1', N'DP1', N'PO_A1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (19, N'DP_C2', N'DP2', N'PO_A1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (20, N'DP_C3', N'DP3', N'PO_A1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1014, N'PL_D1', N'PL1', N'DP_C1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1015, N'PL_D2', N'PL2', N'DP_C1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1016, N'PL_D3', N'PL3', N'DP_C1', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1018, N'Contract_165-2020/CUVT-ANSV/DTRR-KHMS', N'165-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2014, N'Contract_169-2020/CUVT-ANSV/DTRR-KHMS', N'169-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2015, N'Contract_170-2020/CUVT-ANSV/DTRR-KHMS', N'170-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2016, N'Contract_171-2020/CUVT-ANSV/DTRR-KHMS', N'171-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2018, N'Contract_173-2020/CUVT-ANSV/DTRR-KHMS', N'173-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2025, N'Contract_180-2020/CUVT-ANSV/DTRR-KHMS', N'180-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2026, N'Contract_181-2020/CUVT-ANSV/DTRR-KHMS', N'181-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2027, N'PO_5123/CUVT-KV', N'PO1', N'Contract_181-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2036, N'PO_5130/CUVT-KV', N'PO1', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2037, N'PO_5131/CUVT-KV', N'PO7', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2038, N'PO_5132/CUVT-KV', N'PO0', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2039, N'PO_5133/CUVT-KV', N'PO12', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2040, N'PO_5134/CUVT-KV', N'PO5', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2041, N'PO_5135/CUVT-KV', N'PO6', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2042, N'PO_5136/CUVT-KV', N'PO7', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2043, N'PO_5137/CUVT-KV', N'PO8', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2044, N'PO_5138/CUVT-KV', N'PO8', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3022, N'Contract_139-2020/CUVT-ANSV/DTRR-KHMS', N'139-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3023, N'Contract_178-2020/CUVT-ANSV/DTRR-KHMS', N'178-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3024, N'Contract_183-2020/CUVT-ANSV/DTRR-KHMS', N'183-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3025, N'Contract_184-2020/CUVT-ANSV/DTRR-KHMS', N'184-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3026, N'Contract_123-2020/CUVT-ANSV/DTRR-KHMS', N'123-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3027, N'PO_5139/CUVT-KV', N'PO1', N'Contract_123-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3028, N'Contract_141-2020/CUVT-ANSV/DTRR-KHMS', N'141-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3029, N'PO_5140/CUVT-KV', N'PO1', N'Contract_141-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3030, N'PO_5141/CUVT-KV', N'PO1', N'Contract_183-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3031, N'PO_5142/CUVT-KV', N'PO2', N'Contract_183-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3032, N'Contract_185-2020/CUVT-ANSV/DTRR-KHMS', N'185-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3033, N'PO_5143/CUVT-KV', N'PO2', N'Contract_185-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3034, N'PO_5144/CUVT-KV', N'PO1', N'Contract_180-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3035, N'PO_5146/CUVT-KV', N'PO1', N'Contract_165-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3036, N'PO_5147/CUVT-KV', N'PO1', N'Contract_165-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3037, N'PO_5148/CUVT-KV', N'PO1', N'Contract_113-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3038, N'PO_5149/CUVT-KV', N'PO2', N'Contract_113-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3039, N'Contract_186-2020/CUVT-ANSV/DTRR-KHMS', N'186-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3041, N'PO_5151/CUVT-KV', N'PO2', N'Contract_116-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3042, N'PO_5152/CUVT-KV', N'PO3', N'Contract_113-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3043, N'Contract_200-2020/CUVT-ANSV/DTRR-KHMS', N'200-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3044, N'PO_5153/CUVT-KV', N'PO1', N'Contract_200-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3045, N'Contract_202-2020/CUVT-ANSV/DTRR-KHMS', N'202-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3046, N'Contract_203-2020/CUVT-ANSV/DTRR-KHMS', N'203-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3047, N'Contract_201-2020/CUVT-ANSV/DTRR-KHMS', N'201-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3048, N'PO_5154/CUVT-KV', N'PO1', N'Contract_201-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3049, N'PO_5155/CUVT-KV', N'PO2', N'Contract_201-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3050, N'Contract_205-2020/CUVT-ANSV/DTRR-KHMS', N'205-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3051, N'PO_5156/CUVT-KV', N'PO1', N'Contract_205-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3052, N'Contract_206-2020/CUVT-ANSV/DTRR-KHMS', N'206-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3053, N'Contract_207-2020/CUVT-ANSV/DTRR-KHMS', N'207-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3055, N'Contract_204-2020/CUVT-ANSV/DTRR-KHMS', N'204-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3056, N'PO_5157/CUVT-KV', N'P11', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3058, N'Contract_208-2020/CUVT-ANSV/DTRR-KHMS', N'208-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3059, N'PO_5158/CUVT-KV', N'PO1', N'Contract_208-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3060, N'NTKT_0004', N'NTKT_0004', N'PO_5158/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4021, N'PO_5159/CUVT-KV', N'P12', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4022, N'PO_5160/CUVT-KV', N'PO9', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4034, N'Contract_305-2020/CUVT-ANSV/DTRR-KHMS', N'305-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4035, N'PO_5163/CUVT-KV', N'PO1', N'Contract_305-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4036, N'Contract_306-2020/CUVT-ANSV/DTRR-KHMS', N'306-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4037, N'Contract_307-2020/CUVT-ANSV/DTRR-KHMS', N'307-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4038, N'PO_5170/CUVT-KV', N'PO1', N'Contract_307-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4039, N'PO_5171/CUVT-KV', N'PO2', N'Contract_307-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4040, N'PO_5172/CUVT-KV', N'PO2', N'Contract_303-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5021, N'NTKT_0003', N'NTKT_0003', N'PO_5159/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5022, N'NTKT_0001', N'NTKT_0001', N'PO_5156/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5023, N'NTKT_0002', N'NTKT_0002', N'PO_5157/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5024, N'NTKT_0003', N'NTKT_0003', N'PO_5159/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5025, N'NTKT_0004', N'NTKT_0004', N'PO_5158/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5026, N'NTKT_3001', N'NTKT_3001', N'PO_5165/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5028, N'PO_5173/CUVT-KV', N'PO2', N'Contract_300-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5029, N'NTKT_0005', N'NTKT_0005', N'PO_5173/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (6028, N'PO_5174/CUVT-KV', N'PO1', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (7028, N'PO_5175/CUVT-KV', N'PO2', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (8028, N'PO_5176/CUVT-KV', N'PO3', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9028, N'PO_5177/CUVT-KV', N'PO4', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1019, N'Contract_166-2020/CUVT-ANSV/DTRR-KHMS', N'166-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (1020, N'Contract_168-2020/CUVT-ANSV/DTRR-KHMS', N'168-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3040, N'PO_5150/CUVT-KV', N'PO1', N'Contract_116-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4023, N'PO_5161/CUVT-KV', N'P11', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9029, N'PO_5178/CUVT-KV', N'PO5', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9030, N'PO_5179/CUVT-KV', N'PO6', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9031, N'NTKT_0006', N'NTKT_0006', N'PO_5179/CUVT-KV', NULL, NULL)
GO
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9032, N'Contract_400-2020/CUVT-ANSV/DTRR-KHMS', N'400-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9033, N'PO_5180/CUVT-KV', N'PO1', N'Contract_400-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9034, N'NTKT_0007', N'NTKT_0007', N'PO_5180/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9035, N'NTKT_0008', N'NTKT_0008', N'PO_5180/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9036, N'NTKT_0009', N'NTKT_0009', N'PO_5180/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (9037, N'NTKT_00001', N'NTKT_00001', N'PO_5180/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (10028, N'PO_5181/CUVT-KV', N'PO7', N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11028, N'NTKT_00002', N'NTKT_00002', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11029, N'NTKT_00003', N'NTKT_00003', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11030, N'NTKT_00004', N'NTKT_00004', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11031, N'NTKT_00005', N'NTKT_00005', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11032, N'NTKT_00006', N'NTKT_00006', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11033, N'NTKT_00007', N'NTKT_00007', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11034, N'NTKT_00008', N'NTKT_00008', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11035, N'NTKT_00009', N'NTKT_00009', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (11036, N'NTKT_000001', N'NTKT_000001', N'PO_5181/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13052, N'NTKT_NTKT1', N'YCNTKTNTKT1', N'PO_5133/CUVT-KV', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13048, N'NTKT_1234', N'1234', N'PO_5133/CUVT-KV', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13049, N'NTKT_12', N'YCNTKT12', N'PO_5133/CUVT-KV', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13053, N'NTKT_NTKT12', N'YCNTKTNTKT12', N'PO_5133/CUVT-KV', 1, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2017, N'Contract_172-2020/CUVT-ANSV/DTRR-KHMS', N'172-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2019, N'Contract_174-2020/CUVT-ANSV/DTRR-KHMS', N'174-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2020, N'PO_5121/CUVT-KV', N'PO1', N'Contract_174-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2021, N'Contract_175-2020/CUVT-ANSV/DTRR-KHMS', N'175-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2022, N'Contract_176-2020/CUVT-ANSV/DTRR-KHMS', N'176-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2023, N'Contract_177-2020/CUVT-ANSV/DTRR-KHMS', N'177-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2024, N'PO_5122/CUVT-KV', N'PO1', N'Contract_177-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2028, N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', N'182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2029, N'PO_5124/CUVT-KV', N'PO1', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2030, N'PO_5125/CUVT-KV', N'PO2', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2031, N'PO_5126/CUVT-KV', N'PO3', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2032, N'PO_5127/CUVT-KV', N'PO4', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2034, N'PO_5128/CUVT-KV', N'PO1', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (2035, N'PO_5129/CUVT-KV', N'PO1', N'Contract_182-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (5027, N'NTKT_3001', N'NTKT_3001', N'PO_5163/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (3057, N'NTKT_0003', N'NTKT_0003', N'PO_5157/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4024, N'Contract_300-2020/CUVT-ANSV/DTRR-KHMS', N'300-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4025, N'PO_5162/CUVT-KV', N'PO1', N'Contract_300-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4026, N'Contract_301-2020/CUVT-ANSV/DTRR-KHMS', N'301-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4028, N'Contract_302-2020/CUVT-ANSV/DTRR-KHMS', N'302-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4029, N'PO_5165/CUVT-KV', N'PO2', N'Contract_302-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4030, N'NTKT_3001', N'NTKT_3001', N'PO_5165/CUVT-KV', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4031, N'Contract_304-2020/CUVT-ANSV/DTRR-KHMS', N'304-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4032, N'Contract_303-2020/CUVT-ANSV/DTRR-KHMS', N'303-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (4033, N'PO_5169/CUVT-KV', N'PO1', N'Contract_303-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13051, N'Contract_119-2021/CUVT-ANSV/DTRR-KHMS', N'119-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13054, N'PO_5111/CUVT-KV', N'PO10', N'Contract_111-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13058, N'Contract_112-2020/CUVT-ANSV/DTRR-KHMS', N'112-2020/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13069, N'Contract_111-2021/CUVT-ANSV/DTRR-KHMS', N'111-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13067, N'Contract_108-2021/CUVT-ANSV/DTRR-KHMS', N'108-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13068, N'Contract_107-2021/CUVT-ANSV/DTRR-KHMS', N'107-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13070, N'Contract_100-2021/CUVT-ANSV/DTRR-KHMS', N'100-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13071, N'Contract_101-2021/CUVT-ANSV/DTRR-KHMS', N'101-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
INSERT [dbo].[CatalogAdmin] ([stt], [ctlID], [ctlname], [ctlparent], [haveparent], [isdeleted]) VALUES (13072, N'Contract_102-2021/CUVT-ANSV/DTRR-KHMS', N'102-2021/CUVT-ANSV/DTRR-KHMS', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CatalogAdmin] OFF
GO
SET IDENTITY_INSERT [dbo].[CatalogAdmin2] ON 

INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (8, N'111-2020/CUVT-ANSV/DTRR-KHMS', N'111-2020/CUVT-ANSV/DTRR-KHMS', NULL)
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (2, N'112-2020/CUVT-ANSV/DTRR-KHMS', N'112-2020/CUVT-ANSV/DTRR-KHMS', NULL)
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (3, N'113-2020/CUVT-ANSV/DTRR-KHMS', N'113-2020/CUVT-ANSV/DTRR-KHMS', NULL)
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (4, N'114-2020/CUVT-ANSV/DTRR-KHMS', N'114-2020/CUVT-ANSV/DTRR-KHMS', NULL)
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (5, N'PO111', N'PO1', N'111-2020/CUVT-ANSV/DTRR-KHMS')
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (6, N'DP111', N'DP1', N'PO111')
INSERT [dbo].[CatalogAdmin2] ([stt], [ctlID], [ctlname], [ctlparent]) VALUES (7, N'PL111', N'PL1', N'DP111')
SET IDENTITY_INSERT [dbo].[CatalogAdmin2] OFF
GO
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'1-2020/CUVT-ANSV/DTRR-KHMS', N'namecontract', N'codeaccouting', CAST(N'2021-10-09' AS Date), N'typecontract', 0, CAST(N'2021-10-09' AS Date), 0, 0, N'ANSV', N'SiteB', N'phuluc', N'vbgurantee', N'KHMS', CAST(N'2021-10-09' AS Date), 0, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'100-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'12345678', CAST(N'2020-01-12' AS Date), N'Theo don giá c? d?nh', 310, CAST(N'2021-01-12' AS Date), 10000000000, 50, N'ANSV', N'TTCUVT-TPDN', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-01-27' AS Date), 0, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'100-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 1000000, 15, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 30, CAST(N'2021-10-02' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'101-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'12345678', CAST(N'2020-01-12' AS Date), N'Theo don giá c? d?nh', 310, CAST(N'2021-01-12' AS Date), 10000000000, 50, N'ANSV', N'TTCUVT-TPDN', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-01-27' AS Date), 0, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'101-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, CAST(N'2021-09-19' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'102-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, CAST(N'2021-09-05' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'107-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 100, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'108-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 100, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, CAST(N'2021-09-30' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'111-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2020-08-13' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2020-08-13' AS Date), 10000000000, 50, N'Trung Tâm Cung ứng Vật Tư - Viễn Thông TP.HCM', N'Công ty TNHH Thiết bị Viễn Thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-02-13' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'111-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, CAST(N'2021-09-25' AS Date))
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'112-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2020-08-13' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2020-08-13' AS Date), 10000000000, 50, N'Trung Tâm Cung ứng Vật Tư - Viễn Thông TP.HCM', N'Công ty TNHH Thiết bị Viễn Thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-02-13' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'113-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', NULL, NULL, N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'115-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-23' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-23' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'116-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', NULL, NULL, N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'118-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-23' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-23' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'119-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'B', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 357, CAST(N'2021-01-03' AS Date), 12, 10, N'ANSV', N'Trung Tâm Cung Ứng Vật Tư - Viễn Thông TP.HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'119-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-23' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-23' AS Date), 0, 5, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'120-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'121-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'122-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'123-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo don giá c? d?nh', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'126-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'127-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'128-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'129-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'130-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'131-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'132-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'133-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'134-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'AAAAAAA', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'135-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'AAAAAAA', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'136-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'AAAAAAA', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'137-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'AAAAAAA', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'139-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'140-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'KT-140-2020', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 30673658, 10, N'Trung Tam Cung Ung Vat Tu Ho Chi Minh', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'141-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo don giá c? d?nh', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'CUVT-VNPT HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua s?m t?p trung thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband) tuong thích h? th?ng gpon cho nhu c?u nam 2020', CAST(N'2021-03-10' AS Date), 0, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'150-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'B', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 357, CAST(N'2021-01-03' AS Date), 12, 10, N'ANSV', N'Trung Tâm Cung Ứng Vật Tư - Viễn Thông TP.HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'151-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'', CAST(N'1900-01-01' AS Date), N'Theo đơn giá cố định', 0, CAST(N'1900-01-01' AS Date), 0, 0, N'', N'', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'152-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'', CAST(N'1900-01-01' AS Date), N'Theo đơn giá cố định', 0, CAST(N'1900-01-01' AS Date), 0, 0, N'', N'', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'153-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'', CAST(N'1900-01-01' AS Date), N'Theo đơn giá cố định', 0, CAST(N'1900-01-01' AS Date), 0, 0, N'', N'', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'154-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 337410238, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'155-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 123456789, 10, N'aaaaaaa', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'156-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 123456789, 10, N'aaaaaaa', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'157-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 123456789, 10, N'aaaaaaa', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'160-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'161-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'162-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'163-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'164-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'165-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'166-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'167-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'168-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'169-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'170-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Trung Tâm Cung ?ng V?t Tu - Vi?n Thông TP.HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'171-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'172-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'173-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-11' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-11' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'174-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-11' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-11' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'175-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-11' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-11' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'176-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-11' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-11' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'177-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-11' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-11' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'178-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'180-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-12' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-12' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'181-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-12' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-12' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'182-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-12' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-12' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'183-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'184-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'185-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 1234567810, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'186-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-16' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'Công ty TNHH Thi?t B? Vi?n Thông ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'190-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'198-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'199-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'BBBBBBBBB', CAST(N'2021-01-03' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-01-03' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'200-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo don giá c? d?nh', 365, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'201-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'202-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo don giá c? d?nh', 365, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'203-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'204-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'205-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'206-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'207-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-17' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'208-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-17' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-17' AS Date), 123456789, 10, N'ANSV', N'CUVT-VNPT HCMCUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'300-2020/CUVT-ANSV/DTRR-KHMS', N'ACBXYZ', N'ACBXYZ', CAST(N'2021-03-04' AS Date), N'Theo đơn giá cố định', 364, CAST(N'2021-03-19' AS Date), 123456789, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'301-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCXYZ', CAST(N'2021-03-02' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-19' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'302-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCD', CAST(N'2021-03-02' AS Date), N'', 0, CAST(N'2021-03-19' AS Date), 123456789, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'303-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCXYZ', CAST(N'2021-03-04' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-14' AS Date), 12345678, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'304-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ACBXYZ', CAST(N'2021-03-10' AS Date), N'Theo đơn giá cố định', 354, CAST(N'2021-03-19' AS Date), 123456789, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), 20, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'305-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCXYZ', CAST(N'2021-03-02' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-19' AS Date), 1234567, 10, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'ua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'306-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCXYZ', CAST(N'2021-03-04' AS Date), N'Theo đơn giá cố định', 0, CAST(N'2021-03-12' AS Date), 123456, 365, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'307-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'ABCXYZ', CAST(N'2021-03-04' AS Date), N'Theo đơn giá cố định', 20, CAST(N'2021-03-05' AS Date), 123456789, 23, N'ANSV', N'CUVT-VNPT HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-03-10' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'400-2020/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'AAABBB', CAST(N'2021-04-13' AS Date), N'Đơn giá cố định', 365, CAST(N'2021-04-13' AS Date), 8000000000, 14, N'Công ty TNHH Thiết Bị Viễn Thông ANSV', N'Trung Tâm Cung Ứng Vật Tư - Viễn Thông TP.HCM', N'', N'', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-04-23' AS Date), NULL, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'41-2020/CUVT-ANSV/DTRR-KHMS', N'Mua s?m thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband)', N'A', CAST(N'2021-03-16' AS Date), N'Theo don giá c? d?nh', 365, CAST(N'2021-03-16' AS Date), 12345678, 10, N'CUVT-VNPT HCM', N'CUVT-VNPT HCM', N'', N'', N'Mua s?m t?p trung thi?t b? d?u cu?i ONT lo?i (2FE/GE+Wifi singleband) tuong thích h? th?ng gpon cho nhu c?u nam 2020', CAST(N'2021-03-10' AS Date), 0, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'X11-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-23' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-23' AS Date), 0, 0, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'XX1-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-23' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-23' AS Date), 0, 0, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'mua sắm tập trung thiết bị đầu cuối ont loại (2fe/ge+wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-09-30' AS Date), 50, NULL)
INSERT [dbo].[Contract] ([id], [namecontract], [codeaccouting], [datesigned], [typecontract], [durationcontract], [activedate], [valuecontract], [durationpo], [id_siteA], [id_siteB], [phuluc], [vbgurantee], [KHMS], [experationDate], [blvalue], [garanteeCreatedDate]) VALUES (N'XXX-2021/CUVT-ANSV/DTRR-KHMS', N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'C01007', CAST(N'2021-09-30' AS Date), N'Theo đơn giá cố định', 365, CAST(N'2021-09-30' AS Date), 0, 10, N'Trung tâm cung ứng vật tư - Viễn thông TP.HCM', N'Công ty TNHH thiết bị viễn thông ANSV', N'phuluc', N'vbgurantee', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', CAST(N'2021-10-15' AS Date), 50, CAST(N'2021-09-01' AS Date))
GO
INSERT [dbo].[PO] ([id], [id_contract], [po_number], [numberofdevice], [datecreated], [priceunit], [dateconfirm], [dateperform], [dateline], [targetdeliveradd], [email_BLBH_status], [email_BLTH_status], [totalvalue], [tupo], [tupo_datecreated], [confirmpo_number], [confirmpo_datecreated], [bltupo], [bltupo_datecreated], [confirmpo_dateactive]) VALUES (N'5/CUVT-KV', N'111-2020/CUVT-ANSV/DTRR-KHMS', N'PO12', 100000, CAST(N'2021-09-01' AS Date), 0, CAST(N'2021-09-03' AS Date), CAST(N'2021-09-03' AS Date), CAST(N'2021-09-01' AS Date), N'Hà Nội    ', N'', N'', 100000000000, 50, CAST(N'2021-09-16' AS Date), N'679/ANSV-DO', CAST(N'2021-09-10' AS Date), 5, CAST(N'2021-09-24' AS Date), CAST(N'2021-09-10' AS Date))
INSERT [dbo].[PO] ([id], [id_contract], [po_number], [numberofdevice], [datecreated], [priceunit], [dateconfirm], [dateperform], [dateline], [targetdeliveradd], [email_BLBH_status], [email_BLTH_status], [totalvalue], [tupo], [tupo_datecreated], [confirmpo_number], [confirmpo_datecreated], [bltupo], [bltupo_datecreated], [confirmpo_dateactive]) VALUES (N'51/CUVT-KV', N'111-2020/CUVT-ANSV/DTRR-KHMS', N'PO1', 100000, CAST(N'2021-09-28' AS Date), 0, CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date), N'Hà Nội    ', N'', N'', 100000000000, 50, CAST(N'2021-09-28' AS Date), N'679/ANSV-DO', CAST(N'2021-09-28' AS Date), 5, CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date))
INSERT [dbo].[PO] ([id], [id_contract], [po_number], [numberofdevice], [datecreated], [priceunit], [dateconfirm], [dateperform], [dateline], [targetdeliveradd], [email_BLBH_status], [email_BLTH_status], [totalvalue], [tupo], [tupo_datecreated], [confirmpo_number], [confirmpo_datecreated], [bltupo], [bltupo_datecreated], [confirmpo_dateactive]) VALUES (N'513/CUVT-KV', N'111-2020/CUVT-ANSV/DTRR-KHMS', N'PO3', 100000, CAST(N'2021-09-28' AS Date), 0, CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date), N'Hà Nội    ', N'', N'', 100000000000, 50, CAST(N'2021-09-28' AS Date), N'679/ANSV-DO', CAST(N'2021-09-28' AS Date), 5, CAST(N'2021-09-28' AS Date), CAST(N'2021-09-28' AS Date))
INSERT [dbo].[PO] ([id], [id_contract], [po_number], [numberofdevice], [datecreated], [priceunit], [dateconfirm], [dateperform], [dateline], [targetdeliveradd], [email_BLBH_status], [email_BLTH_status], [totalvalue], [tupo], [tupo_datecreated], [confirmpo_number], [confirmpo_datecreated], [bltupo], [bltupo_datecreated], [confirmpo_dateactive]) VALUES (N'5133/CUVT-KV', N'111-2020/CUVT-ANSV/DTRR-KHMS', N'PO12', 100000, CAST(N'2021-09-01' AS Date), 0, CAST(N'2021-09-03' AS Date), CAST(N'2021-09-03' AS Date), CAST(N'2021-09-01' AS Date), N'Hà Nội    ', N'', N'', 100000000000, 50, CAST(N'2021-09-16' AS Date), N'679/ANSV-DO', CAST(N'2021-09-10' AS Date), 5, CAST(N'2021-09-24' AS Date), CAST(N'2021-09-10' AS Date))
GO
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'Công ty TNHH thiết bị Viễn thông ANSV', N'0100113871', N'124 Hoàng Quốc Việt, Phường Nghĩa Tân, Quận Cầu Giấy, TP.Hà Nội', N'124 Hoàng Quốc Việt, Phường Nghĩa Tân, Quận Cầu Giấy, TP.Hà Nội', N'02438362094', N'02433861195', N'26010000554593', N'Nguyễn Văn Nam')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'Trung Tâm Cung ứng Vật Tư - Viễn Thông TP.HCM', N'0300954529', N'125 Hai Bà Trưng, Phường Bến Ngé, Quận 1, TP.HCM', N'12/1 Nguyễn Thị Minh Khai, Phường Đa Kao, Quận 1, TP.HCM', N'02835282338', N'02835282357', N'0071001103921', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'ANSV1', N'0300954529', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'02835282338', N'02433861195', N'0071001103933', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'ANSV2', N'0300954529', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'02835282338', N'02433861195', N'0071001103933', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'ANSV4', N'0300954529', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'02835282338', N'02433861195', N'0071001103933', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'1ANSV', N'0300954529', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'02835282338', N'02433861195', N'0071001103933', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
INSERT [dbo].[Site_Info] ([id], [type], [headquater_info], [address], [phonenumber], [tin], [account], [representative]) VALUES (N'1TTCUVT-TPDN', N'0300954529', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'124-Hoàng Quốc Việt-Cầu Giấy- Hà Nội', N'02835282338', N'02433861195', N'0071001103933', N'Ông Nguyễn Văn Nam - Tổng giám đốc')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Contract_Goods_Unique]    Script Date: 10/6/2021 11:55:14 AM ******/
ALTER TABLE [dbo].[Contract_Goods] ADD  CONSTRAINT [Contract_Goods_Unique] UNIQUE NONCLUSTERED 
(
	[idContract] ASC,
	[code] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT ('111-2020/CUVT-ANSV/DTRR-KHMS') FOR [idContract]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT (N'Việt Nam/VNPT Technology/iGate GW020-H') FOR [code]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT (N'Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)') FOR [name]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT (N'Bộ') FOR [unit]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT ((0)) FOR [priceUnit]
GO
ALTER TABLE [dbo].[Contract_Goods] ADD  DEFAULT ((0)) FOR [quantity]
GO
ALTER TABLE [dbo].[Case]  WITH CHECK ADD  CONSTRAINT [FK_Case_PackageList1] FOREIGN KEY([id_packagelist])
REFERENCES [dbo].[PackageList] ([id])
GO
ALTER TABLE [dbo].[Case] CHECK CONSTRAINT [FK_Case_PackageList1]
GO
ALTER TABLE [dbo].[Contract_Goods]  WITH CHECK ADD  CONSTRAINT [FK_Contract] FOREIGN KEY([idContract])
REFERENCES [dbo].[Contract] ([id])
GO
ALTER TABLE [dbo].[Contract_Goods] CHECK CONSTRAINT [FK_Contract]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Storage] FOREIGN KEY([id_storage])
REFERENCES [dbo].[Storage] ([id])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Storage]
GO
ALTER TABLE [dbo].[DP]  WITH CHECK ADD  CONSTRAINT [FK_DP_PO] FOREIGN KEY([id_po])
REFERENCES [dbo].[PO] ([id])
GO
ALTER TABLE [dbo].[DP] CHECK CONSTRAINT [FK_DP_PO]
GO
ALTER TABLE [dbo].[ListExpected_PO]  WITH CHECK ADD  CONSTRAINT [fk_PO_ID] FOREIGN KEY([id_po])
REFERENCES [dbo].[PO] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ListExpected_PO] CHECK CONSTRAINT [fk_PO_ID]
GO
ALTER TABLE [dbo].[NTKT]  WITH CHECK ADD  CONSTRAINT [FK_NTKT_PO] FOREIGN KEY([id_po])
REFERENCES [dbo].[PO] ([id])
GO
ALTER TABLE [dbo].[NTKT] CHECK CONSTRAINT [FK_NTKT_PO]
GO
ALTER TABLE [dbo].[PackageList]  WITH CHECK ADD  CONSTRAINT [FK_PackageList_DP] FOREIGN KEY([id_dp])
REFERENCES [dbo].[DP] ([id])
GO
ALTER TABLE [dbo].[PackageList] CHECK CONSTRAINT [FK_PackageList_DP]
GO
ALTER TABLE [dbo].[PO]  WITH CHECK ADD  CONSTRAINT [FK_PO_Contract] FOREIGN KEY([id_contract])
REFERENCES [dbo].[Contract] ([id])
GO
ALTER TABLE [dbo].[PO] CHECK CONSTRAINT [FK_PO_Contract]
GO
ALTER TABLE [dbo].[Storage]  WITH CHECK ADD  CONSTRAINT [FK_Case_PackageList] FOREIGN KEY([id_case])
REFERENCES [dbo].[Case] ([id])
GO
ALTER TABLE [dbo].[Storage] CHECK CONSTRAINT [FK_Case_PackageList]
GO
ALTER TABLE [dbo].[VBConfirmPO]  WITH CHECK ADD  CONSTRAINT [FK_VBConfirmPO_PO] FOREIGN KEY([id_po])
REFERENCES [dbo].[PO] ([id])
GO
ALTER TABLE [dbo].[VBConfirmPO] CHECK CONSTRAINT [FK_VBConfirmPO_PO]
GO
/****** Object:  Trigger [dbo].[DeleteCatalogAdmin_After_DeleteContract]    Script Date: 10/05/2021 8:19:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DeleteCatalogAdmin_After_DeleteContract] ON [dbo].[Contract] AFTER DELETE AS 
BEGIN
	DELETE FROM dbo.CatalogAdmin WHERE ctlID=(SELECT 'Contract_'+Deleted.id FROM Deleted)
END
GO
ALTER TABLE [dbo].[Contract] ENABLE TRIGGER [DeleteCatalogAdmin_After_DeleteContract]
GO
/****** Object:  Trigger [dbo].[InsertCatalogAdmin_After_InsertContract]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertCatalogAdmin_After_InsertContract] ON [dbo].[Contract] AFTER INSERT AS 
BEGIN
	INSERT INTO dbo.CatalogAdmin
(
    ctlID,
    ctlname
)
VALUES
(   (SELECT 'Contract_'+id FROM INSERTED),
	(SELECT ID FROM INSERTED))
END
GO
ALTER TABLE [dbo].[Contract] ENABLE TRIGGER [InsertCatalogAdmin_After_InsertContract]
GO
/****** Object:  Trigger [dbo].[DeleteCatalogAdmin_After_DeleteNTKT]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DeleteCatalogAdmin_After_DeleteNTKT] ON [dbo].[NTKT] AFTER DELETE AS 
BEGIN
	DELETE FROM dbo.CatalogAdmin WHERE ctlID=(SELECT 'NTKT_'+Deleted.id FROM Deleted)
END
GO
ALTER TABLE [dbo].[NTKT] ENABLE TRIGGER [DeleteCatalogAdmin_After_DeleteNTKT]
GO
/****** Object:  Trigger [dbo].[InsertCatalogAdmin_After_InsertNTKT]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertCatalogAdmin_After_InsertNTKT] ON [dbo].[NTKT] AFTER INSERT AS 
BEGIN
	INSERT INTO dbo.CatalogAdmin
(
    ctlID,
    ctlname,
	ctlparent
)
VALUES
(   (SELECT 'NTKT_'+ Inserted.id FROM INSERTED),
	(SELECT 'NTKT_'+ CAST(Inserted.number AS VARCHAR(100))  FROM INSERTED),
	(SELECT 'PO_'+Inserted.id_po FROM INSERTED))
END
GO
ALTER TABLE [dbo].[NTKT] ENABLE TRIGGER [InsertCatalogAdmin_After_InsertNTKT]
GO
/****** Object:  Trigger [dbo].[UpdateCatalogAdmin_After_UdateNTKT]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[UpdateCatalogAdmin_After_UdateNTKT] ON [dbo].[NTKT] AFTER UPDATE AS 
BEGIN
	UPDATE dbo.CatalogAdmin
	SET ctlname = (SELECT 'NTKT_'+ CAST(Inserted.number AS VARCHAR(100)) FROM INSERTED)
	WHERE ctlID = (SELECT 'NTKT_'+ Inserted.id FROM INSERTED)
END
GO
ALTER TABLE [dbo].[NTKT] ENABLE TRIGGER [UpdateCatalogAdmin_After_UdateNTKT]
GO
/****** Object:  Trigger [dbo].[DeleteCatalogAdmin_After_DeletePO]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[DeleteCatalogAdmin_After_DeletePO] ON [dbo].[PO] AFTER DELETE AS 
BEGIN
	DELETE FROM dbo.CatalogAdmin WHERE ctlID=(SELECT 'PO_'+Deleted.id FROM Deleted)
END
GO
ALTER TABLE [dbo].[PO] ENABLE TRIGGER [DeleteCatalogAdmin_After_DeletePO]
GO
/****** Object:  Trigger [dbo].[InsertCatalogAdmin_After_InsertPO]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[InsertCatalogAdmin_After_InsertPO] ON [dbo].[PO] AFTER INSERT AS 
BEGIN
	INSERT INTO dbo.CatalogAdmin
(
    ctlID,
    ctlname,
	ctlparent
)
VALUES
(   (SELECT 'PO_'+Inserted.id FROM INSERTED),
	(SELECT Inserted.po_number FROM INSERTED),
	(SELECT 'Contract_'+Inserted.id_contract FROM INSERTED))
END
GO
ALTER TABLE [dbo].[PO] ENABLE TRIGGER [InsertCatalogAdmin_After_InsertPO]
GO
/****** Object:  Trigger [dbo].[UpdateCatalogAdmin_After_UpdatePO]    Script Date: 10/05/2021 8:19:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[UpdateCatalogAdmin_After_UpdatePO] ON [dbo].[PO] AFTER UPDATE AS 
BEGIN
	UPDATE dbo.CatalogAdmin SET ctlname = (select Inserted.po_number FROM Inserted) WHERE ctlID = 'PO_'+(select Inserted.id FROM Inserted)
END
GO
ALTER TABLE [dbo].[PO] ENABLE TRIGGER [UpdateCatalogAdmin_After_UpdatePO]
GO
USE [master]
GO
ALTER DATABASE [OpmDB] SET  READ_WRITE 
GO
