USE [DBBank]
GO
/****** Object:  Table [dbo].[accountTable]    Script Date: 3/17/2015 5:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTable](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[clientId] [int] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[status] [nchar](10) NOT NULL,
 CONSTRAINT [PK_accountTable] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 3/17/2015 5:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientTable](
	[clientId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[middleName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
	[contactNumber] [nvarchar](15) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_clientTable] PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[depositPayLoan]    Script Date: 3/17/2015 5:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depositPayLoan](
	[dplId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[loanId] [int] NOT NULL,
	[paidAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DepositPayLoan] PRIMARY KEY CLUSTERED 
(
	[dplId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loanTable]    Script Date: 3/17/2015 5:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[loanTable](
	[loanId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[amountLoan] [decimal](18, 2) NOT NULL,
	[status] [varchar](10) NOT NULL,
	[loanBalance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[loanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[transactionTable]    Script Date: 3/17/2015 5:42:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[transactionTable](
	[transactionId] [int] IDENTITY(1,1) NOT NULL,
	[accountId] [int] NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[type] [char](1) NOT NULL,
	[date] [datetime] NOT NULL,
	[currentBalance] [decimal](18, 2) NOT NULL,
	[currentLoan] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_transactionTable] PRIMARY KEY CLUSTERED 
(
	[transactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[accountTable]  WITH CHECK ADD  CONSTRAINT [FK_accountTable_accountTable] FOREIGN KEY([clientId])
REFERENCES [dbo].[clientTable] ([clientId])
GO
ALTER TABLE [dbo].[accountTable] CHECK CONSTRAINT [FK_accountTable_accountTable]
GO
ALTER TABLE [dbo].[depositPayLoan]  WITH CHECK ADD  CONSTRAINT [FK_DepositPayLoan_DepositPayLoan] FOREIGN KEY([dplId])
REFERENCES [dbo].[depositPayLoan] ([dplId])
GO
ALTER TABLE [dbo].[depositPayLoan] CHECK CONSTRAINT [FK_DepositPayLoan_DepositPayLoan]
GO
ALTER TABLE [dbo].[loanTable]  WITH CHECK ADD  CONSTRAINT [FK_Loan_transactionTable] FOREIGN KEY([transactionId])
REFERENCES [dbo].[transactionTable] ([transactionId])
GO
ALTER TABLE [dbo].[loanTable] CHECK CONSTRAINT [FK_Loan_transactionTable]
GO
ALTER TABLE [dbo].[transactionTable]  WITH CHECK ADD  CONSTRAINT [FK_transactionTable_accountTable] FOREIGN KEY([transactionId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[transactionTable] CHECK CONSTRAINT [FK_transactionTable_accountTable]
GO
