USE [OpmDB]
GO

/****** Object:  Table [dbo].[PO]    Script Date: 09/28/2021 10:42:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PO](
	[id] [VARCHAR](30) NOT NULL,
	[id_contract] [VARCHAR](50) NOT NULL,
	[po_number] [VARCHAR](10) NULL,
	[numberofdevice] [FLOAT] NULL,
	[datecreated] [DATE] NULL,
	[priceunit] [INT] NULL,
	[dateconfirm] [DATE] NULL,
	[dateperform] [DATE] NULL,
	[dateline] [DATE] NULL,
	[targetdeliveradd] [NCHAR](10) NULL,
	[email_BLBH_status] [VARCHAR](10) NULL,
	[email_BLTH_status] [VARCHAR](10) NULL,
	[totalvalue] [FLOAT] NULL,
	[tupo] [INT] NULL,
	[tupo_datecreated] [DATE] NULL,
	[confirmpo_number] [VARCHAR](20) NULL,
	[confirmpo_datecreated] [DATE] NULL,
	[bltupo] [INT] NULL,
	[bltupo_datecreated] [DATE] NULL,
 CONSTRAINT [PK_PO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PO]  WITH CHECK ADD  CONSTRAINT [FK_PO_Contract] FOREIGN KEY([id_contract])
REFERENCES [dbo].[Contract] ([id])
GO

ALTER TABLE [dbo].[PO] CHECK CONSTRAINT [FK_PO_Contract]
GO


