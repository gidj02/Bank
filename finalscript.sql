USE [master]
GO
/****** Object:  Database [DBBank]    Script Date: 3/22/2015 3:53:55 AM ******/
CREATE DATABASE [DBBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DBBank.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DBBank_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [DBBank] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DBBank]
GO
/****** Object:  UserDefinedFunction [dbo].[convertDate]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[convertDate] ( @date as datetime)
returns varchar(50)
as
begin
	return CONVERT(VARCHAR, @date, 0)
end


GO
/****** Object:  UserDefinedFunction [dbo].[convertToText]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[convertToText] (@type as char(1))
returns varchar(50)
as 
begin
	if @type = 'D'
		return 'Deposit'
	else if @type = 'W'
		return 'Withdraw'
	else if @type = 'E'
		return 'Encash'
	return 'Error'
end


GO
/****** Object:  UserDefinedFunction [dbo].[decryptPassword]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Encrypt]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[encryptPassword]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  UserDefinedFunction [dbo].[LoanAmount]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[LoanAmount] (@amountLoan as decimal(15,0) )
returns varchar(30)
as
begin
	set @amountLoan = ISNULL(@amountLoan,0)
	if @amountLoan = 0
		return ' '
	else
		return 'Php '+CAST(@amountLoan as varchar(10))
	
	return 'Error'
	
end


GO
/****** Object:  UserDefinedFunction [dbo].[LoanCode]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[LoanCode] (@loanId as int )
returns varchar(10)
as
begin
	set @loanId = ISNULL(@loanId,0)
	if @loanId = 0
	
		return ' '
	else
		return CAST(@loanId as varchar(10))
	
	return 'Error'
	
end


GO
/****** Object:  Table [dbo].[accountTable]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accountTable](
	[accountId] [int] IDENTITY(1,1) NOT NULL,
	[clientId] [int] NOT NULL,
	[dateCreated] [datetime] NOT NULL,
	[status] [bit] NOT NULL,
	[pin] [varbinary](20) NOT NULL,
	[salt] [char](25) NOT NULL,
 CONSTRAINT [PK_accountTable] PRIMARY KEY CLUSTERED 
(
	[accountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[clientTable]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
	[password] [varbinary](20) NOT NULL,
	[status] [bit] NOT NULL,
	[salt] [char](25) NOT NULL,
 CONSTRAINT [PK_clientTable] PRIMARY KEY CLUSTERED 
(
	[clientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[depositPayLoan]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  Table [dbo].[loanTable]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  Table [dbo].[transactionTable]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  View [dbo].[viewAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[viewAccount]  as
select 
	 t.accountId as Account,
	(dbo.convertToText(t.type)) as 'Transaction Type', 
	('Php '+ CAST(t.amount as varchar(15))) as 'Amount Processed', 
	(dbo.convertDate(t.date)) as 'Date of Transaction', 
	('Php '+ CAST(t.currentBalance as varchar(15))) as 'Balance', 
	('Php '+ CAST(t.currentLoan as varchar(15))) as 'Loan Created', 
	(dbo.LoanCode(l.loanId)) as 'Loan Code' , 
	 (dbo.LoanAmount(l.amountLoan)) as 'Loan Amount', 
	 (dbo.LoanCode(p.loanId)) as 'Loan Code Paid', 
	(dbo.LoanAmount(p.paidAmount)) as 'Paid Loan Amount'
from transactionTable as t 
	left join loanTable as l on t.transactionId = l.transactionId 
	left join depositPayLoan as p on t.transactionId = p.transactionId


GO
/****** Object:  UserDefinedFunction [dbo].[viewAccounts]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[viewAccounts] (@accountId AS INT)

RETURNS TABLE

AS

RETURN

   SELECT * FROM viewAccount  WHERE Account=@accountId



GO
/****** Object:  StoredProcedure [dbo].[changePassword]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[changePassword] ( @clientId as int, @oldPassword as nvarchar(30),@newPassword as nvarchar(30) )
as
begin
	declare @return as int
	if not exists ( select *from clientTable where clientId = @clientId and password = HASHBYTES('SHA1', salt + @oldPassword) )
	begin
		set @return  = 2
		print 'wrong password'
		return @return	
	end
	else 
	begin
		update clientTable set password = HASHBYTES('SHA1', salt + @newPassword) where clientId = @clientId
	end
	set @return  = 1
	print 'success'
    return @return	
end 



GO
/****** Object:  StoredProcedure [dbo].[changePin]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[changePin] (@accountId as int, @oldPin as nvarchar(6), @newPin as nvarchar(6))
as 
begin
	declare @return as int
	if not exists ( select *from accountTable where accountId = @accountId and pin = Hashbytes('SHA1', salt + @oldPin) )
	begin
		set @return  = 2
		print 'wrong pin'
		return @return	
	end
	else 
	begin
		update accountTable set pin = HashBytes('SHA1', salt + @newPin) where accountId = @accountId
	end
	set @return  = 1
	print 'success'
    return @return	
	

end


GO
/****** Object:  StoredProcedure [dbo].[createAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
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
	declare @Salt as nvarchar(25);
	declare @SaltPin as nvarchar(125);
	-- Generate the salt
	DECLARE @Seed int;
	DECLARE @LCV tinyint;
	DECLARE @CTime DATETIME;

	SET @CTime = GETDATE();
	SET @Seed = (DATEPART(hh, @Ctime) * 10000000) + (DATEPART(n, @CTime) * 100000)
		+ (DATEPART(s, @CTime) * 1000) + DATEPART(ms, @CTime);
	SET @LCV = 1;
	SET @Salt = CHAR(ROUND((RAND(@Seed) * 94.0) + 32, 3));

	WHILE (@LCV < 25)
	BEGIN
	SET @Salt = @Salt + CHAR(ROUND((RAND() * 94.0) + 32, 3));
	SET @LCV = @LCV + 1;
	END;
	SET @SaltPin = @Salt + @pin;

	
	insert into accountTable(clientId, dateCreated, status, pin, salt)values (@clientId, getdate(), 1, HashBytes('SHA1', @SaltPin), @Salt)
	declare @accountId as int  
	set @accountId = scope_identity()
	insert into transactionTable(accountId, amount, type, date, currentBalance, currentLoan)
	values (@accountId, @initialDeposit, 'D', getdate(), @initialDeposit, 0)
	
	 end 




GO
/****** Object:  StoredProcedure [dbo].[deleteAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[deleteAccount] (
	@accountId as int,
	@pin as nvarchar(6)
)

as begin
	declare @loan as decimal(15,2)
	declare @return as int


	select @loan = currentLoan from(
		select *, row_no = row_number() over ( order by date desc  )
			from  transactionTable where accountId = @accountId )as a where a.row_no = 1
	
	if(@loan >0)
	begin 
		set @return  = 0
		return @return	
	end
	else
	begin
		update accountTable set status = 0 where accountId = @accountId
		set @return  = 1
		return @return	
	end

end



GO
/****** Object:  StoredProcedure [dbo].[deleteClient]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[deleteClient] (@clientId as int, @password as nvarchar(30))

as
 begin

declare @accountId as int 
declare @return as int
declare @loan as decimal(15,2)
declare @myCursor as cursor



set @myCursor = cursor fast_forward
for
	select accountId from accountTable where clientId = @clientId
open @myCursor
	fetch next from @MyCursor
	into @accountId
while @@FETCH_STATUS = 0
begin

	select @loan = currentLoan from(
		select *, row_no = row_number() over ( order by date desc  )
			from  transactionTable where accountId = @accountId )as a where a.row_no = 1
	

	if(@loan >0)
	begin 
		set @return  = 0
		print 'may loan kapa'
		return @return	
	end

	fetch next from @MyCursor
	into @accountId	
end

close @myCursor
deallocate @myCursor

set @return  = 1
delete clientTable where clientId = @clientId
print 'status become inactive'
return @return	


end


GO
/****** Object:  StoredProcedure [dbo].[deposit]    Script Date: 3/22/2015 3:53:55 AM ******/
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
/****** Object:  StoredProcedure [dbo].[encash]    Script Date: 3/22/2015 3:53:55 AM ******/
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

 declare @return as int
 if @amount =0 
 begin
	set @return = 0
	return @return
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

	set @return = 1
	return @return
 end





GO
/****** Object:  StoredProcedure [dbo].[getAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAccount] (@userid as int)
as
begin
	Select accountId, status, dateCreated from accountTable where clientid = @userid AND status = 1
end




GO
/****** Object:  StoredProcedure [dbo].[getAccountInfo]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getAccountInfo] (@accoid as int)
as
begin
	Select * from accountTable where accountId = @accoid;
end





GO
/****** Object:  StoredProcedure [dbo].[getBalanceandLoan]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[getBalanceandLoan] (@accoid as int)
as
begin
	select currentLoan, currentBalance from(
		select *, row_no = row_number() over ( order by date desc  )
			from  transactionTable where accountId = @accoid )as a where a.row_no = 1
end





GO
/****** Object:  StoredProcedure [dbo].[getUser]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[getUser] (@username as nvarchar(30))
as
begin
 Select * from clientTable WHERE userName = @username
end




GO
/****** Object:  StoredProcedure [dbo].[loginAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
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
declare @return as int

if exists (select *from accountTable where pin = HashBytes('SHA1', salt+ @pin) and accountId = @accountId 
		and status = 0)
	begin
		print 'Account Deactivated'
		set @return = 2
		return @return
		
	end	
	

if exists (
	select *
	from dbo.accountTable
	where pin = HashBytes('SHA1', salt + @pin)
	AND accountId = @accountId and status = 1
)
begin
	print 'Success login account'
	set @return = 1
	return @return
end

else
	begin
		print 'Failed login'
		set @return = 0
		return @return
	end
			

end





GO
/****** Object:  StoredProcedure [dbo].[loginClient]    Script Date: 3/22/2015 3:53:55 AM ******/
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
declare @return as int
if exists (select * from clientTable where HASHBYTES('SHA1', salt + @password) = password and @userName = userName
		and status = 0)
	begin
		print 'Client Deactivated'
		set @return = 2
		return @return
		
	end	
if exists (select *from clientTable where HASHBYTES('SHA1', salt + @password) = password and userName = userName
		and status = 1)
	begin
		print 'success login'
		set @return = 1
		return @return
		
	end	
else
	begin
		print 'Failed login'
		set @return = 0
		return @return
	end
			

end






GO
/****** Object:  StoredProcedure [dbo].[payEachLoan]    Script Date: 3/22/2015 3:53:55 AM ******/
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
	while @@FETCH_STATUS = 0
	begin
		if(@amount>@loanBalance)
		begin 
			set @amount = @amount - @loanBalance
			update loanTable set status = 'paid', loanBalance = 0  where loanId = @loanId
			insert depositPayLoan (transactionId, loanId, paidAmount ) values (@transactionIdDeposit, @loanId, @loanBalance)
			
		end
		else if (@amount = @loanBalance)
		begin
			set @amount = @amount - @loanBalance
			update loanTable set status = 'paid',loanBalance = 0 where loanId = @loanId
			insert depositPayLoan (transactionId, loanId, paidAmount ) values (@transactionIdDeposit, @loanId, @loanBalance)	
			break
		end
		else
		begin
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
/****** Object:  StoredProcedure [dbo].[registerAccount]    Script Date: 3/22/2015 3:53:55 AM ******/
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
	declare @Salt as nvarchar(25);
	declare @SaltPassword as nvarchar(125);
	-- Generate the salt
	DECLARE @Seed int;
	DECLARE @LCV tinyint;
	DECLARE @CTime DATETIME;

	SET @CTime = GETDATE();
	SET @Seed = (DATEPART(hh, @Ctime) * 10000000) + (DATEPART(n, @CTime) * 100000)
		+ (DATEPART(s, @CTime) * 1000) + DATEPART(ms, @CTime);
	SET @LCV = 1;
	SET @Salt = CHAR(ROUND((RAND(@Seed) * 94.0) + 32, 3));

	WHILE (@LCV < 25)
	BEGIN
	SET @Salt = @Salt + CHAR(ROUND((RAND() * 94.0) + 32, 3));
	SET @LCV = @LCV + 1;
	END;
	SET @SaltPassword = @Salt + @password;
	declare @existing as int = 0
	select @existing = COUNT( userName ) from dbo.clientTable where userName = @userName
	if @existing > 0
	begin 
		raiserror ('Email already exist',1,1)
		return 0
	end
	
	--insert in clienttable
	insert into clientTable(firstName,middleName,lastName,address,contactNumber,email,userName,password, status, salt)
	values(@firstName,@middleName,@lastName,@address,@contactNumber,@email,@userName,HASHBYTES('SHA1', @SaltPassword), 1,@Salt)
	declare @scopeidentity as int  = SCOPE_IDENTITY()
	
	
	if @@ROWCOUNT = 1
		return 1
	else 
		return 0
end



GO
/****** Object:  StoredProcedure [dbo].[updateClient]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[updateClient](
	@firstName as nvarchar(30),
	@middleName as nvarchar(30),
	@lastName as nvarchar(30), 
	@address as nvarchar(50),
	@contactNumber as nvarchar(15), 
	@email as nvarchar(30), 
	@userName as nvarchar(30),
	@clientId as int
)
as begin
	declare @return as int

	update clientTable set firstName = @firstName, middleName = @middleName, lastName = @lastName,
			address = @address, contactNumber = @contactNumber, email = @email, 
			userName = @userName where clientId = @clientId

	set @return = 1
	return @return

end



GO
/****** Object:  StoredProcedure [dbo].[verifyPass]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[verifyPass] ( @password as nvarchar(30), @clientId as int ) 
as begin
declare @return as int
if exists ( select * from clientTable where password = HashBytes('SHA1', salt + @password) and clientId = @clientId)
begin
	set @return = 1
	print 'succes'
	return @return
end

else
begin
	return
end
	set @return = 0
	print 'wrong pass'
	return @return
end

GO
/****** Object:  StoredProcedure [dbo].[verifyPin]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[verifyPin] ( @pin as nvarchar(30), @accountId as int ) 
as begin
declare @return as int
if exists ( select * from accountTable where pin = HashBytes('SHA1', salt + @pin) and accountId = @accountId)
begin
	set @return = 1
	print 'succes'
	return @return
end

else
begin
	return
end
	set @return = 0
	print 'wrong pass'
	return @return
end

GO
/****** Object:  StoredProcedure [dbo].[viewTransactions]    Script Date: 3/22/2015 3:53:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[viewTransactions](@accountId as int)
as 
begin
select * from viewAccounts(@accountId)
end

GO
/****** Object:  StoredProcedure [dbo].[withdraw]    Script Date: 3/22/2015 3:53:55 AM ******/
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

declare @return as int

 if @amount =0 
 begin
	set @return = 0
	return @return
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

		set @return = 1
		return @return
		
	end
 else
	begin
		set @return = 0
		return @return
	end
 
 
end





GO
USE [master]
GO
ALTER DATABASE [DBBank] SET  READ_WRITE 
GO
