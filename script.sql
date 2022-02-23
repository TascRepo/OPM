USE [master]
GO
/****** Object:  Database [OpmDB]    Script Date: 23/02/2022 22:13:18 ******/
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
/****** Object:  Table [dbo].[Case]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Case](
	[CaseId] [varchar](50) NOT NULL,
	[PLId] [varchar](50) NULL,
	[CaseQuantity] [float] NULL,
 CONSTRAINT [PK_Case] PRIMARY KEY CLUSTERED 
(
	[CaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 23/02/2022 22:13:19 ******/
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
/****** Object:  Table [dbo].[DeliveryPlan]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryPlan](
	[DeliveryPlanId] [int] IDENTITY(1,1) NOT NULL,
	[POId] [varchar](50) NOT NULL,
	[VNPTId] [varchar](50) NOT NULL,
	[DeliveryPlanQuantity] [float] NULL,
	[DeliveryPlanDate] [datetime] NULL,
 CONSTRAINT [PK__Delivery__02814348E0AF5386] PRIMARY KEY CLUSTERED 
(
	[DeliveryPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Device]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Device](
	[DeviceSerial] [varchar](50) NOT NULL,
	[CaseId] [varchar](50) NULL,
	[DeviceMAC] [varchar](50) NULL,
	[DeviceSerialGpon] [varchar](50) NULL,
	[DeviceBoxNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[DeviceSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DP]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DP](
	[DPId] [varchar](50) NOT NULL,
	[POId] [varchar](50) NOT NULL,
	[DPDate] [datetime] NULL,
	[DPType] [int] NULL,
	[DPRemarks] [nvarchar](250) NULL,
 CONSTRAINT [PK__DP__2332F7956F2C9AC1] PRIMARY KEY CLUSTERED 
(
	[DPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DPs]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DPs](
	[DPsId] [int] IDENTITY(1,1) NOT NULL,
	[DPId] [varchar](50) NOT NULL,
	[VNPTId] [varchar](50) NOT NULL,
	[DPQuantity] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[DPsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NTKT]    Script Date: 23/02/2022 22:13:19 ******/
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
/****** Object:  Table [dbo].[NTLicense]    Script Date: 23/02/2022 22:13:19 ******/
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
/****** Object:  Table [dbo].[PL]    Script Date: 23/02/2022 22:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PL](
	[PLId] [varchar](50) NOT NULL,
	[DPsId] [int] NOT NULL,
	[PLDate] [datetime] NULL,
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
/****** Object:  Table [dbo].[PO]    Script Date: 23/02/2022 22:13:19 ******/
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
/****** Object:  Table [dbo].[Site]    Script Date: 23/02/2022 22:13:19 ******/
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
INSERT [dbo].[Contract] ([ContractId], [ContractSignedDate], [ContractName], [ContractShoppingPlan], [ContractType], [SiteId], [ContractValidityDate], [ContractDeadline], [ContractGoodsDesignation], [ContractGoodsCode], [ContractGoodsManufacture], [ContractGoodsOrigin], [ContractGoodsDesignation1], [ContractGoodsCode1], [ContractGoodsCode2], [ContractGoodsSpecies], [ContractGoodsNote], [ContractGoodsUnit], [ContractGoodsUnitPrice], [ContractGoodsQuantity], [ContractGoodsLicenseName], [ContractGoodsLicenseUnitPrice], [ContractGuaranteeCreatedDate], [POGuaranteeRatio], [POGuaranteeValidityPeriod], [ContractGuaranteeDeadline], [AccoutingCode]) VALUES (N'2-2022/CUVT-ANSV/DTRR-KHMS', CAST(N'2022-02-09T00:00:00.000' AS DateTime), N'Mua sắm thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband)', N'Mua sắm tập trung thiết bị đầu cuối ONT loại (2FE/GE+Wifi singleband) tương thích hệ thống gpon cho nhu cầu năm 2020', N'Theo', N'TTCU VNPT Ha Noi', CAST(N'2022-02-09T00:00:00.000' AS DateTime), CAST(N'2022-08-28T00:00:00.000' AS DateTime), N'Thiết bị đầu cuối ONT loại (4FE/GE+Wifi dualband+2POTS) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)', N'iGate GW240-H', N'VNPT/Techlonogy', N'Việt Nam', N'FINAL_PRODUCT, GW020_BOB', N'HY5N2T5N000024NP', N'2FE/GE+WIFI singleband', N'Thiết bị đầu cuối ONT', N'Phụ kiện kèm theo mỗi bộ ONT: 01 Dây cáp mạng UTP dài 1,0 mét với giắc kết nối RJ-45 tại hai đầu; 01 Bộ chuyển đổi điện AC/DC dải rộng với chiều dài dây tối thiểu là 1,5 mét; 01 Tài liệu hướng dẫn sử dụng bằng tiếng Việt.', N'Bộ', 100, 500000, N'Bản quyền quản lý ONT FTTH (bản quyền / ONT)', 20, CAST(N'2022-02-09T00:00:00.000' AS DateTime), 5, 5, CAST(N'2022-02-09T00:00:00.000' AS DateTime), N'C01007')
GO
SET IDENTITY_INSERT [dbo].[DeliveryPlan] ON 

INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (51, N'1111/CUVT-KV', N'12', 1000, CAST(N'2022-02-21T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (52, N'1111/CUVT-KV', N'12', 10000, CAST(N'2022-02-21T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (53, N'1111/CUVT-KV', N'123', 20000, CAST(N'2022-02-21T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (56, N'1111/CUVT-KV', N'1234', 40000, CAST(N'2022-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (57, N'1111/CUVT-KV', N'123', 100000, CAST(N'2022-03-09T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (58, N'1111/CUVT-KV', N'123', 9000, CAST(N'2022-03-10T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (59, N'1111/CUVT-KV', N'123', 1000, CAST(N'2022-02-21T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (60, N'1111/CUVT-KV', N'ANSV', 1000, CAST(N'2022-03-11T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (61, N'1111/CUVT-KV', N'ANSV', 2000, CAST(N'2022-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[DeliveryPlan] ([DeliveryPlanId], [POId], [VNPTId], [DeliveryPlanQuantity], [DeliveryPlanDate]) VALUES (62, N'1111/CUVT-KV', N'ANSV', 16000, CAST(N'2022-03-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[DeliveryPlan] OFF
GO
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPRemarks]) VALUES (N'1/2022', N'1111/CUVT-KV', CAST(N'2022-02-26T00:00:00.000' AS DateTime), 0, N'abcd    èg')
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPRemarks]) VALUES (N'2/2022', N'1111/CUVT-KV', CAST(N'2022-02-26T00:00:00.000' AS DateTime), 1, N'Hàng dự phòng')
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPRemarks]) VALUES (N'3/2022', N'1111/CUVT-KV', CAST(N'2022-02-23T00:00:00.000' AS DateTime), 0, N'Hàng chính')
INSERT [dbo].[DP] ([DPId], [POId], [DPDate], [DPType], [DPRemarks]) VALUES (N'4/2022', N'1111/CUVT-KV', CAST(N'2022-02-26T00:00:00.000' AS DateTime), 1, N'Hàng dự phòng 4')
GO
SET IDENTITY_INSERT [dbo].[DPs] ON 

INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (9, N'1/2022', N'1234', 20000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (10, N'1/2022', N'12', 1000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (11, N'1/2022', N'123', 100000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (12, N'2/2022', N'12', 220)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (13, N'2/2022', N'123', 2600)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (14, N'2/2022', N'1234', 800)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (15, N'4/2022', N'ANSV', 380)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (16, N'3/2022', N'12', 10000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (17, N'3/2022', N'123', 30000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (18, N'3/2022', N'1234', 20000)
INSERT [dbo].[DPs] ([DPsId], [DPId], [VNPTId], [DPQuantity]) VALUES (19, N'3/2022', N'ANSV', 19000)
SET IDENTITY_INSERT [dbo].[DPs] OFF
GO
INSERT [dbo].[NTKT] ([NTKTId], [POId], [NTKTCreatedDate], [NTKTPhase], [NTKTQuantity], [NTKTTestExpectedDate], [TechnicalInspectionReportDate], [TechnicalAcceptanceReportDate], [NTKTLicenseCertificateDate]) VALUES (N'1234/ANSV-DO', N'1111/CUVT-KV', CAST(N'2022-02-16T00:00:00.000' AS DateTime), N'1', 10000, CAST(N'2022-02-16T00:00:00.000' AS DateTime), CAST(N'2022-02-16T00:00:00.000' AS DateTime), CAST(N'2022-02-16T00:00:00.000' AS DateTime), CAST(N'2022-02-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PO] ([POId], [ContractId], [POName], [POCreatedDate], [POGoodsQuantity], [POConfirmRequestDeadline], [PODefaultPerformDate], [POPerformDate], [PODeadline], [POConfirmId], [POConfirmCreatedDate], [POAdvanceId], [POAdvanceCreatedDate], [POAdvancePercentage], [POAdvanceGuaranteeCreatedDate], [POAdvanceGuaranteePercentage], [POAdvanceRequestId], [POAdvanceRequestCreatedDate], [POGuaranteeDate], [PONumberOfPhase]) VALUES (N'1111/CUVT-KV', N'2-2022/CUVT-ANSV/DTRR-KHMS', N'PO1', CAST(N'2022-02-09T00:00:00.000' AS DateTime), 200000, CAST(N'2022-02-19T00:00:00.000' AS DateTime), CAST(N'2022-02-09T00:00:00.000' AS DateTime), CAST(N'2022-02-09T00:00:00.000' AS DateTime), CAST(N'2022-02-19T00:00:00.000' AS DateTime), N'1/ANSV-DO', CAST(N'2022-02-09T00:00:00.000' AS DateTime), N'111/ANSV-TCKT', CAST(N'2022-02-09T00:00:00.000' AS DateTime), 50, CAST(N'2022-02-09T00:00:00.000' AS DateTime), 50, N'11/ANSV-TCKT', CAST(N'2022-02-09T00:00:00.000' AS DateTime), CAST(N'2022-02-09T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'1111', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'12', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'123', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'1234', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'0912', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'ANSV', N'ANSV', N'ANSV', N'NT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'CUVT', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'123456789', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'MSB', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'QNH', N'Viễn thông Quảng Ninh', N'VNPT Quảng Ninh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TTCU VNPT Ha Noi', N'Hà Nội', N'VNPT Hà Nội', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'123456789', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'TTCU VNPT HCM', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'Trung tâm cung ứng vật tư - Viễn thông thành phố Hồ Chí Minh', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
INSERT [dbo].[Site] ([SiteId], [SiteName], [SiteProvince], [SiteType], [SiteHeadquater], [SiteAddress], [SitePhonenumber], [SiteFaxNumber], [SiteTaxCode], [SiteBankAccount], [SiteNameOfBank], [SiteRepresentative1], [SitePosition1], [SiteProxy1], [SiteRepresentative2], [SitePosition2], [SiteProxy2], [SiteRepresentative3], [SitePosition3], [SiteProxy3]) VALUES (N'VT BGN', N'Viễn thông Bắc Giang', N'Viễn thông Bắc Giang', N'CUVT', N'Quận 1 - Thành phố Hồ Chí Minh', N'Quận 1 - Thành phố Hồ Chí Minh', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXX', N'XXXXXXXXXXXXX', N'', N'Ông', N'Giám đốc', N'', N'Ông', N'', N'', N'Ông', N'', N'')
GO
ALTER TABLE [dbo].[Case]  WITH CHECK ADD  CONSTRAINT [FK_Case_PL] FOREIGN KEY([PLId])
REFERENCES [dbo].[PL] ([PLId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Case] CHECK CONSTRAINT [FK_Case_PL]
GO
ALTER TABLE [dbo].[DeliveryPlan]  WITH CHECK ADD  CONSTRAINT [FK__DeliveryP__SiteI__70DDC3D8] FOREIGN KEY([VNPTId])
REFERENCES [dbo].[Site] ([SiteId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliveryPlan] CHECK CONSTRAINT [FK__DeliveryP__SiteI__70DDC3D8]
GO
ALTER TABLE [dbo].[DeliveryPlan]  WITH CHECK ADD  CONSTRAINT [FK__DeliveryPl__POId__6FE99F9F] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeliveryPlan] CHECK CONSTRAINT [FK__DeliveryPl__POId__6FE99F9F]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Case] FOREIGN KEY([CaseId])
REFERENCES [dbo].[Case] ([CaseId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Case]
GO
ALTER TABLE [dbo].[DP]  WITH CHECK ADD  CONSTRAINT [FK__DP__POId__40058253] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DP] CHECK CONSTRAINT [FK__DP__POId__40058253]
GO
ALTER TABLE [dbo].[DPs]  WITH CHECK ADD FOREIGN KEY([DPId])
REFERENCES [dbo].[DP] ([DPId])
GO
ALTER TABLE [dbo].[DPs]  WITH CHECK ADD FOREIGN KEY([VNPTId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[NTKT]  WITH CHECK ADD  CONSTRAINT [FK_NTKT_PO] FOREIGN KEY([POId])
REFERENCES [dbo].[PO] ([POId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[NTKT] CHECK CONSTRAINT [FK_NTKT_PO]
GO
ALTER TABLE [dbo].[PL]  WITH CHECK ADD  CONSTRAINT [FK_PL_DPs] FOREIGN KEY([DPsId])
REFERENCES [dbo].[DPs] ([DPsId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PL] CHECK CONSTRAINT [FK_PL_DPs]
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
