USE [master]
GO
/****** Object:  Database [OpmDB]    Script Date: 15/06/2022 6:17:51 CH ******/
CREATE DATABASE [OpmDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OpmDB', FILENAME = N'D:\DataSQL\OpmDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OpmDB_log', FILENAME = N'D:\DataSQL\OpmDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [OpmDB] SET AUTO_CLOSE ON 
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
/****** Object:  Table [dbo].[Contract]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [varchar](50) NOT NULL,
	[ContractSignedDate] [datetime] NULL,
	[ContractName] [nvarchar](250) NULL,
	[ContractShoppingPlan] [nvarchar](250) NULL,
	[ContractType] [nvarchar](100) NULL,
	[SiteId] [varchar](50) NULL,
	[ContractValidityDate] [datetime] NULL,
	[ContractDeadline] [datetime] NULL,
	[ContractGoodsDesignation] [nvarchar](250) NULL,
	[ContractGoodsCode] [varchar](20) NULL,
	[ContractGoodsManufacture] [nvarchar](100) NULL,
	[ContractGoodsOrigin] [nvarchar](50) NULL,
	[ContractGoodsDesignation1] [varchar](250) NULL,
	[ContractGoodsCode1] [varchar](20) NULL,
	[ContractGoodsCode2] [varchar](100) NULL,
	[ContractGoodsSpecies] [nvarchar](100) NULL,
	[ContractGoodsNote] [nvarchar](250) NULL,
	[ContractGoodsUnit] [nvarchar](50) NULL,
	[ContractGoodsUnitPrice] [float] NULL,
	[ContractGoodsQuantity] [float] NULL,
	[ContractGoodsLicenseName] [nvarchar](250) NULL,
	[ContractGoodsLicenseUnitPrice] [float] NULL,
	[ContractGuaranteeCreatedDate] [datetime] NULL,
	[POGuaranteeRatio] [int] NULL,
	[POGuaranteeValidityPeriod] [int] NULL,
	[ContractGuaranteeDeadline] [datetime] NULL,
	[AccoutingCode] [varchar](15) NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryPlan]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryPlan](
	[DeliveryPlanId] [int] IDENTITY(1,1) NOT NULL,
	[POId] [varchar](50) NOT NULL,
	[VNPTId] [varchar](50) NULL,
	[DeliveryPlanQuantity] [float] NULL,
	[DeliveryPlanDate] [datetime] NULL,
 CONSTRAINT [PK__Delivery__02814348E0AF5386] PRIMARY KEY CLUSTERED 
(
	[DeliveryPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceId] [int] IDENTITY(1,1) NOT NULL,
	[PLId] [varchar](50) NULL,
	[DeviceCaseNumber] [varchar](50) NULL,
	[DeviceSerial] [varchar](50) NULL,
	[DeviceMAC] [varchar](50) NULL,
	[DeviceSerialGpon] [varchar](50) NULL,
	[DeviceBoxNumber] [varchar](50) NULL,
	[DeviceSerialRange] [varchar](1000) NULL,
	[DeviceMacRange] [varchar](1000) NULL,
	[DeviceSerialGPONRange] [varchar](1000) NULL,
	[DeviceNumberOfCase] [int] NULL,
 CONSTRAINT [PK__Device__49E12311F3A72D89] PRIMARY KEY CLUSTERED 
(
	[DeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DP]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DP](
	[DPId] [varchar](50) NOT NULL,
	[POId] [varchar](50) NOT NULL,
	[DPDate] [datetime] NULL,
	[DPType] [int] NULL,
	[DPQuantity] [int] NULL,
	[DPQuantity1] [int] NULL,
	[DPRequestDate] [datetime] NULL,
	[DPResponseDate] [datetime] NULL,
	[DPRefundDate] [datetime] NULL,
	[DPRemarks] [nvarchar](250) NULL,
 CONSTRAINT [PK__DP__2332F7956F2C9AC1] PRIMARY KEY CLUSTERED 
(
	[DPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NTKT]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NTKT](
	[NTKTId] [varchar](50) NOT NULL,
	[POId] [varchar](50) NOT NULL,
	[NTKTCreatedDate] [datetime] NULL,
	[NTKTPhase] [varchar](50) NULL,
	[NTKTQuantity] [float] NULL,
	[NTKTTestExpectedDate] [datetime] NULL,
	[TechnicalInspectionReportDate] [datetime] NULL,
	[TechnicalAcceptanceReportDate] [datetime] NULL,
	[NTKTLicenseCertificateDate] [datetime] NULL,
 CONSTRAINT [PK__NTKT__3213E83FBED39F0E] PRIMARY KEY CLUSTERED 
(
	[NTKTId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NTLicense]    Script Date: 15/06/2022 6:17:51 CH ******/
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
/****** Object:  Table [dbo].[PackingList]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackingList](
	[PackingListCaseNumber] [varchar](50) NOT NULL,
	[PLId] [varchar](50) NULL,
	[PackingListCaseQuantity] [varchar](50) NULL,
	[PackingListProductionBoxNumber] [varchar](50) NULL,
	[PackingListSerialRange] [varchar](1000) NULL,
	[PackingListMacRange] [varchar](1000) NULL,
	[PackingListSerialGPONRange] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[PackingListCaseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PL]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PL](
	[PLId] [varchar](50) NOT NULL,
	[DPId] [varchar](50) NOT NULL,
	[VNPTId] [varchar](50) NOT NULL,
	[PLDate] [datetime] NULL,
	[PLQuantity] [int] NULL,
	[CaseQuantity] [int] NULL,
	[PLDimension] [varchar](50) NULL,
	[PLVolume] [float] NULL,
	[PLNetWeight] [float] NULL,
	[PLGrossWeight] [float] NULL,
 CONSTRAINT [PK_PackageList] PRIMARY KEY CLUSTERED 
(
	[PLId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PO]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PO](
	[POId] [varchar](50) NOT NULL,
	[ContractId] [varchar](50) NOT NULL,
	[POName] [varchar](20) NULL,
	[POCreatedDate] [datetime] NULL,
	[POGoodsQuantity] [float] NULL,
	[POConfirmRequestDeadline] [datetime] NULL,
	[PODefaultPerformDate] [datetime] NULL,
	[POPerformDate] [datetime] NULL,
	[PODeadline] [datetime] NULL,
	[POConfirmId] [varchar](50) NULL,
	[POConfirmCreatedDate] [datetime] NULL,
	[POAdvanceId] [varchar](50) NULL,
	[POAdvanceCreatedDate] [datetime] NULL,
	[POAdvancePercentage] [int] NULL,
	[POAdvanceGuaranteeCreatedDate] [datetime] NULL,
	[POAdvanceGuaranteePercentage] [int] NULL,
	[POAdvanceRequestId] [varchar](50) NULL,
	[POAdvanceRequestCreatedDate] [datetime] NULL,
	[POGuaranteeDate] [datetime] NULL,
	[PONumberOfPhase] [int] NULL,
 CONSTRAINT [PK_PO] PRIMARY KEY CLUSTERED 
(
	[POId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 15/06/2022 6:17:51 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteId] [varchar](50) NOT NULL,
	[SiteName] [nvarchar](250) NULL,
	[SiteProvince] [nvarchar](250) NULL,
	[SiteType] [nvarchar](50) NULL,
	[SiteHeadquater] [nvarchar](250) NULL,
	[SiteAddress] [nvarchar](250) NULL,
	[SitePhonenumber] [varchar](20) NULL,
	[SiteFaxNumber] [varchar](20) NULL,
	[SiteTaxCode] [varchar](20) NULL,
	[SiteBankAccount] [varchar](20) NULL,
	[SiteNameOfBank] [nvarchar](100) NULL,
	[SiteRepresentative1] [nvarchar](50) NULL,
	[SitePosition1] [nvarchar](50) NULL,
	[SiteProxy1] [nvarchar](50) NULL,
	[SiteRepresentative2] [nvarchar](50) NULL,
	[SitePosition2] [nvarchar](50) NULL,
	[SiteProxy2] [nvarchar](50) NULL,
	[SiteRepresentative3] [nvarchar](50) NULL,
	[SitePosition3] [nvarchar](50) NULL,
	[SiteProxy3] [nvarchar](50) NULL,
 CONSTRAINT [PK__Site__B9DCB963517A9935] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Contract] ([ContractId], [ContractSignedDate], [ContractName], [ContractShoppingPlan], [ContractType], [SiteId], [ContractValidityDate], [ContractDeadline], [ContractGoodsDesignation], [ContractGoodsCode], [ContractGoodsManufacture], [ContractGoodsOrigin], [ContractGoodsDesignation1], [ContractGoodsCode1], [ContractGoodsCode2], [ContractGoodsSpecies], [ContractGoodsNote], [ContractGoodsUnit], [ContractGoodsUnitPrice], [ContractGoodsQuantity], [ContractGoodsLicenseName], [ContractGoodsLicenseUnitPrice], [ContractGuaranteeCreatedDate], [POGuaranteeRatio], [POGuaranteeValidityPeriod], [ContractGuaranteeDeadline], [AccoutingCode]) VALUES (N'123-2022/CUVT-ANSV/DTRR-KHMS', CAST(N'2022-06-13T00:00:00.000' AS DateTime), N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', N'Theo đơn giá cố định', N'CUVT-HCM', CAST(N'2022-06-13T00:00:00.000' AS DateTime), CAST(N'2023-06-13T00:00:00.000' AS DateTime), N'Thiết bị đầu cuối ONT loại (4FE/GE+Wifi dualband+2POTS) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)', N'iGate GW240-H', N'VNPT/Techlonogy', N'Việt Nam', N'FINAL_PRODUCT, GW020_BOB', N'HY5N2T5N000024NP', N'2FE/GE+WIFI singleband', N'Thiết bị đầu cuối ONT', N'Phụ kiện kèm theo mỗi bộ ONT: 01 Dây cáp mạng UTP dài 1,0 mét với giắc kết nối RJ-45 tại hai đầu; 01 Bộ chuyển đổi điện AC/DC dải rộng với chiều dài dây tối thiểu là 1,5 mét; 01 Tài liệu hướng dẫn sử dụng bằng tiếng Việt.', N'Bộ', 917000, 100000, N'Bản quyền quản lý ONT FTTH (bản quyền / ONT)', 200000, CAST(N'2022-06-13T00:00:00.000' AS DateTime), 5, 5, CAST(N'2023-04-09T00:00:00.000' AS DateTime), N'C01007')
GO
SET IDENTITY_INSERT [dbo].[DeliveryPlan] ON 

INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (2, N'3579/CUVT-KV', N'BDH', 1000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (3, N'3579/CUVT-KV', N'BDH', 500, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (4, N'3579/CUVT-KV', N'BKN', 152, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (5, N'3579/CUVT-KV', N'BNH', 1000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (6, N'3579/CUVT-KV', N'BPC', 1500, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (7, N'3579/CUVT-KV', N'BTE', 746, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (8, N'3579/CUVT-KV', N'BTN', 600, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (9, N'3579/CUVT-KV', N'CBG', 80, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (10, N'3579/CUVT-KV', N'CMU', 906, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (11, N'3579/CUVT-KV', N'DBN', 350, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (12, N'3579/CUVT-KV', N'DLK', 1000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (13, N'3579/CUVT-KV', N'DLK', 1000, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (14, N'3579/CUVT-KV', N'DTP', 2020, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (15, N'3579/CUVT-KV', N'GLI', 700, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (16, N'3579/CUVT-KV', N'HBH', 887, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (17, N'3579/CUVT-KV', N'HCM', 3000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (18, N'3579/CUVT-KV', N'HDG', 500, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (19, N'3579/CUVT-KV', N'HGG', 326, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (20, N'3579/CUVT-KV', N'HNI', 5000, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (21, N'3579/CUVT-KV', N'HNM', 1200, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (22, N'3579/CUVT-KV', N'HPG', 1000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (23, N'3579/CUVT-KV', N'HTH', 300, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (24, N'3579/CUVT-KV', N'THU', 500, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (25, N'3579/CUVT-KV', N'KHA', 310, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (26, N'3579/CUVT-KV', N'KTM', 200, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (27, N'3579/CUVT-KV', N'LAN', 2000, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (28, N'3579/CUVT-KV', N'LDG', 1400, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (29, N'3579/CUVT-KV', N'LSN', 500, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (30, N'3579/CUVT-KV', N'NAN', 3000, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (31, N'3579/CUVT-KV', N'NBH', 1028, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (32, N'3579/CUVT-KV', N'NDH', 1298, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (33, N'3579/CUVT-KV', N'PYN', 600, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (34, N'3579/CUVT-KV', N'QBH', 800, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (35, N'3579/CUVT-KV', N'QNH', 500, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (36, N'3579/CUVT-KV', N'QNI', 920, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (37, N'3579/CUVT-KV', N'STG', 600, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (38, N'3579/CUVT-KV', N'TBH', 1117, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (39, N'3579/CUVT-KV', N'TGG', 876, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (40, N'3579/CUVT-KV', N'THA', 430, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (41, N'3579/CUVT-KV', N'TNH', 300, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (42, N'3579/CUVT-KV', N'TQG', 100, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (43, N'3579/CUVT-KV', N'TVH', 400, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (44, N'3579/CUVT-KV', N'VLG', 651, CAST(N'2022-06-23T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (45, N'3579/CUVT-KV', N'VPC', 400, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (46, N'3579/CUVT-KV', N'BTU', 500, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (47, N'3579/CUVT-KV', N'YBI', 300, CAST(N'2022-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (49, N'3579/CUVT-KV', N'AGG', 600, CAST(N'2022-06-14T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DeliveryPlan] OFF
GO
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPQuantity], [DPQuantity1], [DPRequestDate], [DPResponseDate], [DPRefundDate], [DPRemarks]) VALUES (N'1666/2022', N'3579/CUVT-KV', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 0, 10000, 10000, CAST(N'2022-06-16T00:00:00.000' AS DateTime), CAST(N'2022-06-18T00:00:00.000' AS DateTime), CAST(N'2000-01-22T00:00:00.000' AS DateTime), N'abcdef')
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPQuantity], [DPQuantity1], [DPRequestDate], [DPResponseDate], [DPRefundDate], [DPRemarks]) VALUES (N'1980/2022', N'3579/CUVT-KV', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 0, 10000, 0, CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPQuantity], [DPQuantity1], [DPRequestDate], [DPResponseDate], [DPRefundDate], [DPRemarks]) VALUES (N'1990/2022', N'3579/CUVT-KV', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 0, 13097, 13097, CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_BNH', N'1666/2022', N'BNH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_HCM', N'1666/2022', N'HCM', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_HDG', N'1666/2022', N'HDG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_KTM', N'1666/2022', N'KTM', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 200, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_LSN', N'1666/2022', N'LSN', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_NBH', N'1666/2022', N'NBH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1028, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_QBH', N'1666/2022', N'QBH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 800, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_QNH', N'1666/2022', N'QNH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_QNI', N'1666/2022', N'QNI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 920, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_STG', N'1666/2022', N'STG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 600, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_TBH', N'1666/2022', N'TBH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1117, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_THU', N'1666/2022', N'THU', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_TVH', N'1666/2022', N'TVH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 400, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_VLG', N'1666/2022', N'VLG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 635, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1666/2022_YBI', N'1666/2022', N'YBI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 300, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_DLK', N'1980/2022', N'DLK', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_DTP', N'1980/2022', N'DTP', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 454, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_GLI', N'1980/2022', N'GLI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HBH', N'1980/2022', N'HBH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 887, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HCM', N'1980/2022', N'HCM', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HGG', N'1980/2022', N'HGG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 200, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HNI', N'1980/2022', N'HNI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 3000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HNM', N'1980/2022', N'HNM', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1200, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HPG', N'1980/2022', N'HPG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_HTH', N'1980/2022', N'HTH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 300, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_KHA', N'1980/2022', N'KHA', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 310, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_LAN', N'1980/2022', N'LAN', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_LDG', N'1980/2022', N'LDG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 103, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_TQG', N'1980/2022', N'TQG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 60, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1980/2022_VLG', N'1980/2022', N'VLG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 16, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_DLK', N'1990/2022', N'DLK', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_GLI', N'1990/2022', N'GLI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 200, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_HCM', N'1990/2022', N'HCM', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_HGG', N'1990/2022', N'HGG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 126, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_HNI', N'1990/2022', N'HNI', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 2000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_HPG', N'1990/2022', N'HPG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 500, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_LAN', N'1990/2022', N'LAN', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_LDG', N'1990/2022', N'LDG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1297, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_NAN', N'1990/2022', N'NAN', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 3000, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_NDH', N'1990/2022', N'NDH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 1298, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_PYN', N'1990/2022', N'PYN', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 600, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_TGG', N'1990/2022', N'TGG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 876, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_THA', N'1990/2022', N'THA', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 430, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_TNH', N'1990/2022', N'TNH', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 300, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_TQG', N'1990/2022', N'TQG', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 40, 20, N'55x45x31', 0.076, 15, 16)
INSERT [dbo].[PL] ([PLId], [DPId], [VNPTId], [PLDate], [PLQuantity], [CaseQuantity], [PLDimension], [PLVolume], [PLNetWeight], [PLGrossWeight]) VALUES (N'1990/2022_VPC', N'1990/2022', N'VPC', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 430, 20, N'55x45x31', 0.076, 15, 16)
GO
INSERT [dbo].[PO] ([POId], [ContractId], [POName], [POCreatedDate], [POGoodsQuantity], [POConfirmRequestDeadline], [PODefaultPerformDate], [POPerformDate], [PODeadline], [POConfirmId], [POConfirmCreatedDate], [POAdvanceId], [POAdvanceCreatedDate], [POAdvancePercentage], [POAdvanceGuaranteeCreatedDate], [POAdvanceGuaranteePercentage], [POAdvanceRequestId], [POAdvanceRequestCreatedDate], [POGuaranteeDate], [PONumberOfPhase]) VALUES (N'1259/CUVT-KV', N'123-2022/CUVT-ANSV/DTRR-KHMS', N'PO2', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 0, CAST(N'2022-06-17T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-07-15T00:00:00.000' AS DateTime), N'0254/ANSV-DO', CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'0599/ANSV-TCKT', CAST(N'2022-06-15T00:00:00.000' AS DateTime), 50, CAST(N'2022-06-15T00:00:00.000' AS DateTime), 50, N'0568/ANSV-TCKT', CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[PO] ([POId], [ContractId], [POName], [POCreatedDate], [POGoodsQuantity], [POConfirmRequestDeadline], [PODefaultPerformDate], [POPerformDate], [PODeadline], [POConfirmId], [POConfirmCreatedDate], [POAdvanceId], [POAdvanceCreatedDate], [POAdvancePercentage], [POAdvanceGuaranteeCreatedDate], [POAdvanceGuaranteePercentage], [POAdvanceRequestId], [POAdvanceRequestCreatedDate], [POGuaranteeDate], [PONumberOfPhase]) VALUES (N'3579/CUVT-KV', N'123-2022/CUVT-ANSV/DTRR-KHMS', N'PO1', CAST(N'2022-06-13T00:00:00.000' AS DateTime), 43097, CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-13T00:00:00.000' AS DateTime), CAST(N'2022-06-13T00:00:00.000' AS DateTime), CAST(N'2022-07-13T00:00:00.000' AS DateTime), N'1234/ANSV-DO', CAST(N'2022-06-13T00:00:00.000' AS DateTime), N'6789/ANSV-TCKT', CAST(N'2022-06-13T00:00:00.000' AS DateTime), 50, CAST(N'2022-06-13T00:00:00.000' AS DateTime), 50, N'2468/ANSV-TCKT', CAST(N'2022-06-13T00:00:00.000' AS DateTime), CAST(N'2022-06-13T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'AGG', N'Viễn Thông An Giang', N'An Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BDG', N'Viễn Thông Bình Dương', N'Bình Dương', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BDH', N'Viễn Thông Bình Định', N'Bình Định', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BGG', N'Viễn Thông Bắc Giang', N'Bắc Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BKN', N'Viễn Thông Bắc Kạn', N'Bắc Kạn', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BLU', N'Viễn Thông Bạc Liêu', N'Bạc Liêu', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BNH', N'Viễn Thông Bắc Ninh', N'Bắc Ninh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BPC', N'Viễn Thông Bình Phước', N'Bình Phước', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BTE', N'Viễn Thông Bến Tre', N'Bến Tre', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BTN', N'Viễn Thông Bình Thuận', N'Bình Thuận', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'BTU', N'Viễn Thông Bà Rịa – Vũng Tàu', N'Bà Rịa – Vũng Tàu', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'CBG', N'Viễn Thông Cao Bằng', N'Cao Bằng', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'CMU', N'Viễn Thông Cà Mau', N'Cà Mau', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'CTO', N'Viễn Thông Cần Thơ', N'Cần Thơ', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'CUVT-HCM', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DBN', N'Viễn Thông Điện Biên', N'Điện Biên', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DKNG', N'Viễn Thông Đắk Nông', N'Đắk Nông', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DLK', N'Viễn Thông Đắk Lắk', N'Đắk Lắk', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DNG', N'Viễn Thông Đà Nẵng', N'Đà Nẵng', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DNI', N'Viễn Thông Đồng Nai', N'Đồng Nai', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'DTP', N'Viễn Thông Đồng Tháp', N'Đồng Tháp', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'GLI', N'Viễn Thông Gia Lai', N'Gia Lai', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HBH', N'Viễn Thông Hòa Bình', N'Hòa Bình', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HCM', N'Viễn Thông Hồ Chí Minh', N'Hồ Chí Minh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HDG', N'Viễn Thông Hải Dương', N'Hải Dương', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HGG', N'Viễn Thông Hà Giang', N'Hà Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HNI', N'Viễn Thông Hà Nội', N'Hà Nội', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HNM', N'Viễn Thông Hà Nam', N'Hà Nam', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HPG', N'Viễn Thông Hải Phòng', N'Hải Phòng', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HTH', N'Viễn Thông Hà Tĩnh', N'Hà Tĩnh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HUG', N'Viễn Thông Hậu Giang', N'Hậu Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'HYN', N'Viễn Thông Hưng Yên', N'Hưng Yên', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'KGG', N'Viễn Thông Kiên Giang', N'Kiên Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'KHA', N'Viễn Thông Khánh Hòa', N'Khánh Hòa', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'KTM', N'Viễn Thông Kon Tum', N'Kon Tum', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'LAN', N'Viễn Thông Long An', N'Long An', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'LCI', N'Viễn Thông Lào Cai', N'Lào Cai', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'LCU', N'Viễn Thông Lai Châu', N'Lai Châu', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'LDG', N'Viễn Thông Lâm Đồng', N'Lâm Đồng', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'LSN', N'Viễn Thông Lạng Sơn', N'Lạng Sơn', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'NAN', N'Viễn Thông Nghệ An', N'Nghệ An', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'NBH', N'Viễn Thông Ninh Bình', N'Ninh Bình', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'NDH', N'Viễn Thông Nam Định', N'Nam Định', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'NTN', N'Viễn Thông Ninh Thuận', N'Ninh Thuận', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'PTO', N'Viễn Thông Phú Thọ', N'Phú Thọ', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'PYN', N'Viễn Thông Phú Yên', N'Phú Yên', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QBH', N'Viễn Thông Quảng Bình', N'Quảng Bình', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QNH', N'Viễn Thông Quảng Ninh', N'Quảng Ninh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QNI', N'Viễn Thông Quảng Ngãi', N'Quảng Ngãi', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QNM', N'Viễn Thông Quảng Nam', N'Quảng Nam', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QTI', N'Viễn Thông Quảng Trị', N'Quảng Trị', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'SLA', N'Viễn Thông Sơn La', N'Sơn La', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'STG', N'Viễn Thông Sóc Trăng', N'Sóc Trăng', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TBH', N'Viễn Thông Thái Bình', N'Thái Bình', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TGG', N'Viễn Thông Tiền Giang', N'Tiền Giang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'THA', N'Viễn Thông Thanh Hóa', N'Thanh Hóa', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'THU', N'Viễn Thông Thừa Thiên Huế', N'Thừa Thiên Huế', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TNH', N'Viễn Thông Tây Ninh', N'Tây Ninh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TNN', N'Viễn Thông Thái Nguyên', N'Thái Nguyên', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TQG', N'Viễn Thông Tuyên Quang', N'Tuyên Quang', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TVH', N'Viễn Thông Trà Vinh', N'Trà Vinh', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'VLG', N'Viễn Thông Vĩnh Long', N'Vĩnh Long', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'VPC', N'Viễn Thông Vĩnh Phúc', N'Vĩnh Phúc', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'YBI', N'Viễn Thông Yên Bái', N'Yên Bái', N'Đơn vị sử dụng', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[DP] ADD  CONSTRAINT [DF_DP_DPRequestDate]  DEFAULT (getdate()) FOR [DPRequestDate]
GO
ALTER TABLE [dbo].[DP] ADD  CONSTRAINT [DF_DP_DPResponseDate]  DEFAULT (getdate()) FOR [DPResponseDate]
GO
ALTER TABLE [dbo].[DP] ADD  CONSTRAINT [DF_DP_DPRefundDate]  DEFAULT (getdate()) FOR [DPRefundDate]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Site]
GO
ALTER TABLE [dbo].[DeliveryPlan]  WITH CHECK ADD  CONSTRAINT [FK__DeliveryPl__POId__6FE99F9F] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliveryPlan] CHECK CONSTRAINT [FK__DeliveryPl__POId__6FE99F9F]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_PL] FOREIGN KEY([PLId])
REFERENCES [dbo].[PL] ([PLId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_PL]
GO
ALTER TABLE [dbo].[DP]  WITH CHECK ADD  CONSTRAINT [FK__DP__POId__40058253] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DP] CHECK CONSTRAINT [FK__DP__POId__40058253]
GO
ALTER TABLE [dbo].[NTKT]  WITH CHECK ADD  CONSTRAINT [FK_NTKT_PO] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NTKT] CHECK CONSTRAINT [FK_NTKT_PO]
GO
ALTER TABLE [dbo].[PackingList]  WITH CHECK ADD FOREIGN KEY([PLId])
REFERENCES [dbo].[PL] ([PLId])
GO
ALTER TABLE [dbo].[PL]  WITH CHECK ADD  CONSTRAINT [FK_PL_DP] FOREIGN KEY([DPId])
REFERENCES [dbo].[DP] ([DPId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PL] CHECK CONSTRAINT [FK_PL_DP]
GO
ALTER TABLE [dbo].[PO]  WITH CHECK ADD  CONSTRAINT [FK_PO_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PO] CHECK CONSTRAINT [FK_PO_Contract]
GO
USE [master]
GO
ALTER DATABASE [OpmDB] SET  READ_WRITE 
GO
