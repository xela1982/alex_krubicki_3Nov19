USE [master]
GO
/****** Object:  Database [TakeAway2]    Script Date: 11/8/2019 9:57:59 AM ******/
CREATE DATABASE [TakeAway2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N't', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.ALEXDB\MSSQL\DATA\TakeAway2.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N't_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.ALEXDB\MSSQL\DATA\TakeAway2_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TakeAway2] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TakeAway2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TakeAway2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TakeAway2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TakeAway2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TakeAway2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TakeAway2] SET ARITHABORT OFF 
GO
ALTER DATABASE [TakeAway2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TakeAway2] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TakeAway2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TakeAway2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TakeAway2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TakeAway2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TakeAway2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TakeAway2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TakeAway2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TakeAway2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TakeAway2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TakeAway2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TakeAway2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TakeAway2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TakeAway2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TakeAway2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TakeAway2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TakeAway2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TakeAway2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TakeAway2] SET  MULTI_USER 
GO
ALTER DATABASE [TakeAway2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TakeAway2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TakeAway2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TakeAway2] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TakeAway2]
GO
/****** Object:  StoredProcedure [dbo].[sp_EmployeesCardsReport]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EmployeesCardsReport]--1,'2010.10.1','2010.10.10'
(
	@company_id int,
	@start_date datetime,
	@end_date datetime
)
AS
BEGIN
	SELECT report.[user_id], report.full_name,report.last_digit,report.[payment_sum] from (
	SELECT u.[user_id],u.first_name +' '+u.last_name as [full_name],ec.last_digit,sum(b.[payment])[payment_sum]  from 
	[dbo].[EmployeesCards] ec
	 inner join 
	[dbo].[Users] u on u.[user_id]=ec.[user_id]
	inner join 
	[dbo].[Companies] c on ec.company_id=c.company_id
	inner join [dbo].[Banks] b on b.card_id=ec.card_id
	WHERE c.company_id=@company_id and b.payment_date>@start_date and b.payment_date<@end_date
	GROUP BY u.[user_id],u.first_name ,u.last_name,ec.last_digit
	) AS report
END 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetBanks]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetBanks]
AS
SELECT  * from BankRef

GO
/****** Object:  StoredProcedure [dbo].[sp_GetCompanies]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[sp_GetCompanies] AS 
BEGIN
	SELECT * FROM  [dbo].[Companies]
END

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BankRef]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankRef](
	[id] [int] NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banks]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banks](
	[payment] [float] NOT NULL,
	[card_id] [int] NOT NULL,
	[payment_date] [date] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Companies]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[company_id] [int] NOT NULL,
	[company_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeesCards]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesCards](
	[card_id] [int] NOT NULL,
	[last_digit] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[company_id] [int] NOT NULL,
 CONSTRAINT [PK_EmployeesCards] PRIMARY KEY CLUSTERED 
(
	[card_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/8/2019 9:57:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191107144153_InitialCreate3', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191107144923_InitialCreate', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191107170230_InitialCreate', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191107170749_InitialCreate2', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191107170811_InitialCreate3', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191108061553_InitialCreate4', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191108061756_InitialCreate5', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191108061834_InitialCreate6', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191108063146_InitialCreate8', N'2.1.11-servicing-32099')
SET IDENTITY_INSERT [dbo].[Banks] ON 

INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (10.2, 1, CAST(N'2010-10-01' AS Date), 1)
INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (11.34, 1, CAST(N'2010-10-15' AS Date), 2)
INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (15.5, 2, CAST(N'2010-10-15' AS Date), 3)
INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (9.5, 2, CAST(N'2010-10-16' AS Date), 4)
INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (30.5, 3, CAST(N'2010-10-13' AS Date), 5)
INSERT [dbo].[Banks] ([payment], [card_id], [payment_date], [id]) VALUES (10.5, 3, CAST(N'2010-10-29' AS Date), 6)
SET IDENTITY_INSERT [dbo].[Banks] OFF
INSERT [dbo].[Companies] ([company_id], [company_name]) VALUES (1, N'unknown-company')
INSERT [dbo].[Companies] ([company_id], [company_name]) VALUES (2, N'takeAway')
INSERT [dbo].[EmployeesCards] ([card_id], [last_digit], [user_id], [company_id]) VALUES (1, 1234, 1, 1)
INSERT [dbo].[EmployeesCards] ([card_id], [last_digit], [user_id], [company_id]) VALUES (2, 5678, 2, 2)
INSERT [dbo].[EmployeesCards] ([card_id], [last_digit], [user_id], [company_id]) VALUES (3, 9101, 3, 2)
INSERT [dbo].[Users] ([user_id], [first_name], [last_name]) VALUES (1, N'alex', N'krubicki')
INSERT [dbo].[Users] ([user_id], [first_name], [last_name]) VALUES (2, N'eitan', N'hania')
INSERT [dbo].[Users] ([user_id], [first_name], [last_name]) VALUES (3, N'ido', N'levin')
/****** Object:  Index [IX_Companies]    Script Date: 11/8/2019 9:58:00 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Companies] ON [dbo].[Companies]
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeesCards]    Script Date: 11/8/2019 9:58:00 AM ******/
ALTER TABLE [dbo].[EmployeesCards] ADD  CONSTRAINT [IX_EmployeesCards] UNIQUE NONCLUSTERED 
(
	[card_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeesCards_company_id]    Script Date: 11/8/2019 9:58:00 AM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeesCards_company_id] ON [dbo].[EmployeesCards]
(
	[company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeesCards_user_id]    Script Date: 11/8/2019 9:58:00 AM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeesCards_user_id] ON [dbo].[EmployeesCards]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users]    Script Date: 11/8/2019 9:58:00 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [TakeAway2] SET  READ_WRITE 
GO
