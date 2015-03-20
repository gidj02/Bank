USE [master]
GO
/****** Object:  Database [DBBank]    Script Date: 3/20/2015 10:53:03 AM ******/
CREATE DATABASE [DBBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBBank', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBBank.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBBank_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBBank_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBBank] SET COMPATIBILITY_LEVEL = 110
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
ALTER DATABASE [DBBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBBank] SET  MULTI_USER 
GO
ALTER DATABASE [DBBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBBank] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DBBank]
GO
/****** Object:  StoredProcedure [dbo].[createAccount]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[createAccount] (
	@clientId as  int, 
	@pin as nvarchar(6),
	@initialDeposit as decimal(15,2)
	)

	as begin
	
	insert into accountTable(clientId, dateCreated, status, pin)values (@clientId, getdate(), 1, @pin)
	declare @accountId as int  
	set @accountId = scope_identity()
	insert into transactionTable(accountId, amount, type, date, currentBalance, currentLoan)
	values (@accountId, @initialDeposit, 'D', getdate(), @initialDeposit, 0)
	
	 end 

GO
/****** Object:  StoredProcedure [dbo].[deposit]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deposit]
(
	@accountId as int,
	@amount as decimal(15,2)
)
as 
begin
	declare @loan as decimal(15,2)
	declare @balance as decimal(15,2)
	
	select @loan =  currentLoan, @balance=currentBalance from(
		select *, row_no = row_number() over ( order by date desc  )
			from  transactionTable where accountId = @accountId )as a where a.row_no = 1
	if @loan =0
		begin
				declare @currentBalance as decimal(15,2)
				select @currentBalance = @balance + @amount
				
				insert into transactionTable 
				(
					accountId,
					amount,
					type,
					date,
					currentBalance,
					currentLoan
				)
				values
				(
					@accountId,
					@amount,
					'D',
					getdate(),
					@currentBalance,
					0
				)
			
		end
	else
		begin
			if @loan = @amount
				begin
				insert into transactionTable (accountId,amount,type,date,currentBalance,currentLoan)
				values(@accountId,@amount,'D',getdate(),0,0)	
				declare @transactionId1 as int = scope_identity()
				execute payEachLoan  @accountId, @amount, @transactionId1
				end
			else if @loan < @amount
				begin
				insert into transactionTable (accountId,amount,type,date,currentBalance,currentLoan)
				values(@accountId,@amount,'D',getdate(),@amount-@loan,0)
				declare @transactionId2 as int = scope_identity()
				execute payEachLoan  @accountId, @amount, @transactionId2
				end
			else
				begin
				insert into transactionTable (accountId,amount,type,date,currentBalance,currentLoan)
				values(@accountId,@amount,'D',getdate(),0,@loan-@amount)	
				declare @transactionId as int = scope_identity()
				execute payEachLoan  @accountId, @amount, @transactionId
				end
		end
end


GO
/****** Object:  StoredProcedure [dbo].[encash]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[encash] 
(
	@accountId as int,
	@amount as decimal(15, 2)
)
as 
begin 

 if @amount =0 
 begin
	raiserror ('Cannot withraw 0.00 PHP',1,1)
	return 0
 end
 
 declare @balance as decimal(15, 2)
 declare @currentLoan as decimal(15, 2)
 declare @transactionId as int
 
 select @balance =  currentBalance, @currentLoan = currentLoan
  from(
 select *, row_no = row_number() over ( order by date desc  )
 from  transactionTable where accountId = @accountId )as a where a.row_no = 1
 
 
 if @balance >= @amount
	begin
		declare @currentbalance as decimal(15,2) 
		set @currentbalance = @balance - @amount
		
		insert into transactionTable(accountId,amount,type,date,currentBalance,currentLoan)
		values(@accountId,@amount,'E',getdate(),@currentBalance,0)
		
		
	end
 else
	begin
		select @amount = @amount - @balance
		insert into transactionTable(accountId,amount,type,date,currentBalance,currentLoan)
		values(@accountId,@amount,'E',getdate(),0,@amount+@currentLoan)
		set @transactionId = scope_identity()
		
		insert into loanTable(transactionId,amountLoan,status,loanBalance)
		values(@transactionId,@amount,'notpaid',@amount)
			
	end
 end


GO
/****** Object:  StoredProcedure [dbo].[loginAccount]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[loginAccount]
(
	@pin as nvarchar(6),
	@accountId as int
)

as 
begin
if exists (
	select *
	from dbo.accountTable
	where pin = @pin
	AND accountId = @accountId
)
	return 1
else
			raiserror ('Invalid Input',1,1)

end

GO
/****** Object:  StoredProcedure [dbo].[loginClient]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[loginClient] 
	(	@userName as nvarchar(30),
		@password as nvarchar(30)
	)
as 
begin
if exists (
	select *
	from dbo.clientTable
	where userName = @userName
	AND password = @password
)
	return 1
else
	raiserror ('Invalid Input',1,1)

end


GO
/****** Object:  StoredProcedure [dbo].[payEachLoan]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[payEachLoan] (
	@accountId as int,
	@amount as decimal(15,2),
	@transactionIdDeposit as int
)
as
begin

	declare @loanId as int
	declare @transactionId as int
	declare @status as nvarchar(10)
	declare @loanBalance as decimal(15,2)
	declare @myCursor as cursor
	set @myCursor = cursor fast_forward
	for
		select loanTable.loanId,loanTable.transactionId,loanTable.status,loanTable.loanBalance from transactionTable inner join loantable on
		transactionTable.transactionId = loanTable.transactionId  where transactionTable.accountId = @accountId and (loanTable.status = 'notpaid' or loanTable.status = 'partial')
		order by date asc

	open @myCursor
	fetch next from @MyCursor
	into @loanId,@transactionId,@status,@loanBalance
	print 'super pakyu'
	while @@FETCH_STATUS = 0
	begin
		if(@amount>@loanBalance)
		begin 
			set @amount = @amount - @loanBalance
			print 'pakyu1'
			update loanTable set status = 'paid', loanBalance = 0  where loanId = @loanId
			insert depositPayLoan (transactionId, loanId, paidAmount ) values (@transactionIdDeposit, @loanId, @loanBalance)
			
		end
		else if (@amount = @loanBalance)
		begin
			print 'pakyu2'
			set @amount = @amount - @loanBalance
			update loanTable set status = 'paid',loanBalance = 0 where loanId = @loanId
			insert depositPayLoan (transactionId, loanId, paidAmount ) values (@transactionIdDeposit, @loanId, @loanBalance)	
			break
		end
		else
		begin
			print 'pakyu3'
			update loanTable set status = 'partial', loanBalance = @loanBalance-@amount where loanId = @loanId	
			insert depositPayLoan (transactionId, loanId, paidAmount ) values (@transactionIdDeposit, @loanId, @amount)	
			break		
		end



		fetch next from @MyCursor
		into @loanId,@transactionId,@status,@loanBalance	
	end
	close @myCursor
	deallocate @myCursor
end


GO
/****** Object:  StoredProcedure [dbo].[registerAccount]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[registerAccount]
(
	@firstName as nvarchar(30),
	@middleName as nvarchar(30),
	@lastName as nvarchar(30), 
	@address as nvarchar(50),
	@contactNumber as nvarchar(15), 
	@email as nvarchar(30), 
	@userName as nvarchar(30),
	@password as nvarchar(30)

)

AS 
BEGIN 
	declare @existing as int = 0
	select @existing = COUNT( userName ) from dbo.clientTable where userName = @userName
	if @existing > 0
	begin 
		raiserror ('Email already exist',1,1)
		return 0
	end
	--insert in clienttable
	insert into clientTable(firstName,middleName,lastName,address,contactNumber,email,userName,password)
	values(@firstName,@middleName,@lastName,@address,@contactNumber,@email,@userName,@password)
	declare @scopeidentity as int  = SCOPE_IDENTITY()
	
	
	if @@ROWCOUNT = 1
		return 1
	else 
		return 0
end


GO
/****** Object:  StoredProcedure [dbo].[withdraw]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[withdraw]
(
	@accountId as int,
	@amount as decimal(15, 2)
	
)

as 
begin 

 if @amount =0 
 begin
	raiserror ('Cannot withraw 0.00 PHP',1,1)
	return 0
 end
 
 declare @balance as decimal(15, 2)
 
 select @balance =  currentBalance from(
 select *, row_no = row_number() over ( order by date desc  )
 from  transactionTable where accountId = @accountId )as a where a.row_no = 1
 
 
 if @balance >= @amount
	begin
		declare @currentbalance as decimal(18,2) 
		select @currentbalance = @balance - @amount
		
		insert into transactionTable
		(
			accountId,
			amount,
			type,
			date,
			currentBalance,
			currentLoan
		)
		values
		(
			@accountId,
			@amount,
			'W',
			getdate(),
			@currentBalance,
			0
		)
		
	end
 else
	begin
		raiserror ('Cannot Withraw',1,1)
	end
 
 
end


GO
/****** Object:  UserDefinedFunction [dbo].[decryptPassword]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[decryptPassword] (@code as varbinary(400) )
returns nvarchar(400)
as
begin
	declare @res as nvarchar(400)
	set @res = DECRYPTBYPASSPHRASE('key',@code)
	return(@res)
end 

GO
/****** Object:  UserDefinedFunction [dbo].[Encrypt]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Encrypt] (@passWord as nvarchar(400) )
returns varbinary(8000)
as
begin
	declare @res as varbinary(800)
	set @res = ENCRYPTBYPASSPHRASE('key',@passWord)
	return(@res)
end 

GO
/****** Object:  UserDefinedFunction [dbo].[encryptPassword]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[encryptPassword] (@passWord as nvarchar(400) )
returns varbinary(8000)
as
begin
	declare @res as varbinary(800)
	set @res = ENCRYPTBYPASSPHRASE('key',@passWord)
	return(@res)
end 

GO
/****** Object:  Table [dbo].[accountTable]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountTable](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[clientId] [int] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
	[pin] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_accountTable] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientTable](
	[clientId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](30) NOT NULL,
	[middleName] [nvarchar](30) NOT NULL,
	[lastName] [nvarchar](30) NOT NULL,
	[address] [nvarchar](50) NOT NULL,
	[contactNumber] [nvarchar](15) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[userName] [nvarchar](30) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_clientTable] PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[depositPayLoan]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depositPayLoan](
	[dplId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[loanId] [int] NOT NULL,
	[paidAmount] [decimal](15, 2) NOT NULL,
 CONSTRAINT [PK_DepositPayLoan] PRIMARY KEY CLUSTERED 
(
	[dplId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loanTable]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loanTable](
	[loanId] [int] IDENTITY(1,1) NOT NULL,
	[transactionId] [int] NOT NULL,
	[amountLoan] [decimal](15, 2) NOT NULL,
	[status] [nvarchar](10) NOT NULL,
	[loanBalance] [decimal](15, 2) NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[loanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[transactionTable]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[transactionTable](
	[transactionId] [int] IDENTITY(1,1) NOT NULL,
	[accountId] [int] NOT NULL,
	[amount] [decimal](15, 2) NOT NULL,
	[type] [char](1) NOT NULL,
	[date] [datetime] NOT NULL,
	[currentBalance] [decimal](15, 2) NOT NULL,
	[currentLoan] [decimal](15, 2) NOT NULL,
 CONSTRAINT [PK_transactionTable] PRIMARY KEY CLUSTERED 
(
	[transactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[sampleView]    Script Date: 3/20/2015 10:53:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[sampleView] 
as  
select * from transactionTable 

GO
USE [master]
GO
ALTER DATABASE [DBBank] SET  READ_WRITE 
GO
