USE [master]
GO
/****** Object:  Database [DBBank]    Script Date: 03/17/2015 17:18:06 ******/
CREATE DATABASE [DBBank] ON  PRIMARY 
( NAME = N'DBBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DBBank.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\DBBank_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBBank] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBBank] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DBBank] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DBBank] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DBBank] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DBBank] SET ARITHABORT OFF
GO
ALTER DATABASE [DBBank] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DBBank] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DBBank] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DBBank] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DBBank] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DBBank] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DBBank] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DBBank] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DBBank] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DBBank] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DBBank] SET  DISABLE_BROKER
GO
ALTER DATABASE [DBBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DBBank] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DBBank] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DBBank] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DBBank] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DBBank] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DBBank] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DBBank] SET  READ_WRITE
GO
ALTER DATABASE [DBBank] SET RECOVERY SIMPLE
GO
ALTER DATABASE [DBBank] SET  MULTI_USER
GO
ALTER DATABASE [DBBank] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DBBank] SET DB_CHAINING OFF
GO
USE [DBBank]
GO
/****** Object:  Table [dbo].[DepositPayLoan]    Script Date: 03/17/2015 17:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepositPayLoan](
	[dplId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[loanId] [int] NOT NULL,
	[paidAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DepositPayLoan] PRIMARY KEY CLUSTERED 
(
	[dplId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 03/17/2015 17:18:11 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accountTable]    Script Date: 03/17/2015 17:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTable](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[status] [nchar](10) NULL,
 CONSTRAINT [PK_accountTable] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactionTable]    Script Date: 03/17/2015 17:18:11 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 03/17/2015 17:18:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Loan](
	[loanId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[amountLoan] [decimal](18, 2) NOT NULL,
	[status] [varchar](10) NOT NULL,
	[loanBalance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[loanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_DepositPayLoan_DepositPayLoan]    Script Date: 03/17/2015 17:18:11 ******/
ALTER TABLE [dbo].[DepositPayLoan]  WITH CHECK ADD  CONSTRAINT [FK_DepositPayLoan_DepositPayLoan] FOREIGN KEY([dplId])
REFERENCES [dbo].[DepositPayLoan] ([dplId])
GO
ALTER TABLE [dbo].[DepositPayLoan] CHECK CONSTRAINT [FK_DepositPayLoan_DepositPayLoan]
GO
/****** Object:  ForeignKey [FK_accountTable_accountTable]    Script Date: 03/17/2015 17:18:11 ******/
ALTER TABLE [dbo].[accountTable]  WITH CHECK ADD  CONSTRAINT [FK_accountTable_accountTable] FOREIGN KEY([accountId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[accountTable] CHECK CONSTRAINT [FK_accountTable_accountTable]
GO
/****** Object:  ForeignKey [FK_transactionTable_accountTable]    Script Date: 03/17/2015 17:18:11 ******/
ALTER TABLE [dbo].[transactionTable]  WITH CHECK ADD  CONSTRAINT [FK_transactionTable_accountTable] FOREIGN KEY([transactionId])
REFERENCES [dbo].[accountTable] ([accountId])
GO
ALTER TABLE [dbo].[transactionTable] CHECK CONSTRAINT [FK_transactionTable_accountTable]
GO
/****** Object:  ForeignKey [FK_Loan_transactionTable]    Script Date: 03/17/2015 17:18:11 ******/
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_transactionTable] FOREIGN KEY([transactionId])
REFERENCES [dbo].[transactionTable] ([transactionId])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_transactionTable]
GO
