USE [BankDB]
GO
/****** Object:  Table [dbo].[accountTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTable](
	[accountId] [int] NOT NULL,
	[accountTypeId] [int] NOT NULL,
	[balance] [decimal](18, 0) NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[status] [nchar](10) NOT NULL,
 CONSTRAINT [PK_accountTable] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[accountTypeTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTypeTable](
	[accountTypeId] [int] NOT NULL,
	[accountTypeName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_accountTypeTable] PRIMARY KEY CLUSTERED 
(
	[accountTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientAcountTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientAcountTable](
	[clientId] [int] NOT NULL,
	[accountId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientTable](
	[clientId] [int] NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[middleName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[contactNumber] [numeric](18, 0) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[street] [nvarchar](max) NOT NULL,
	[city] [varchar](50) NOT NULL,
	[state] [varchar](50) NOT NULL,
	[zip] [int] NOT NULL,
 CONSTRAINT [PK_clientTable] PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[loanTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loanTable](
	[loanId] [int] NOT NULL,
	[accountId] [int] NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_loanTable] PRIMARY KEY CLUSTERED 
(
	[loanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transactionTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactionTable](
	[transactionId] [int] NOT NULL,
	[accountId] [int] NOT NULL,
	[transactionTypeId] [int] NOT NULL,
	[date] [datetime] NOT NULL,
	[time] [time](7) NOT NULL,
	[amount] [decimal](18, 0) NOT NULL,
	[currentBalance] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_transactionTable] PRIMARY KEY CLUSTERED 
(
	[transactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transactionTypeTable]    Script Date: 3/16/2015 9:25:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[transactionTypeTable](
	[transactionTypeId] [int] NOT NULL,
	[transactionTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_transactionTypeTable] PRIMARY KEY CLUSTERED 
(
	[transactionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[accountTable]  WITH CHECK ADD  CONSTRAINT [FK_accountTable_accountTypeTable] FOREIGN KEY([accountTypeId])
REFERENCES [dbo].[accountTypeTable] ([accountTypeId])
GO
ALTER TABLE [dbo].[accountTable] CHECK CONSTRAINT [FK_accountTable_accountTypeTable]
GO
ALTER TABLE [dbo].[clientAcountTable]  WITH CHECK ADD  CONSTRAINT [FK_clientAcountTable_accountTable] FOREIGN KEY([accountId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[clientAcountTable] CHECK CONSTRAINT [FK_clientAcountTable_accountTable]
GO
ALTER TABLE [dbo].[clientAcountTable]  WITH CHECK ADD  CONSTRAINT [FK_clientAcountTable_clientTable] FOREIGN KEY([clientId])
REFERENCES [dbo].[clientTable] ([clientId])
GO
ALTER TABLE [dbo].[clientAcountTable] CHECK CONSTRAINT [FK_clientAcountTable_clientTable]
GO
ALTER TABLE [dbo].[loanTable]  WITH CHECK ADD  CONSTRAINT [FK_loanTable_accountTable] FOREIGN KEY([accountId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[loanTable] CHECK CONSTRAINT [FK_loanTable_accountTable]
GO
ALTER TABLE [dbo].[transactionTable]  WITH CHECK ADD  CONSTRAINT [FK_transactionTable_accountTable] FOREIGN KEY([accountId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[transactionTable] CHECK CONSTRAINT [FK_transactionTable_accountTable]
GO
ALTER TABLE [dbo].[transactionTable]  WITH CHECK ADD  CONSTRAINT [FK_transactionTable_transactionTypeTable] FOREIGN KEY([transactionTypeId])
REFERENCES [dbo].[transactionTypeTable] ([transactionTypeId])
GO
ALTER TABLE [dbo].[transactionTable] CHECK CONSTRAINT [FK_transactionTable_transactionTypeTable]
GO
