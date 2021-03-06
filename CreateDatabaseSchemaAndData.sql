USE [master]
GO
/****** Object:  Database [Scraper]    Script Date: 10/01/2021 21:18:53 ******/
CREATE DATABASE [Scraper2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Scraper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Scraper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Scraper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Scraper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Scraper] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Scraper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Scraper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Scraper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Scraper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Scraper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Scraper] SET ARITHABORT OFF 
GO
ALTER DATABASE [Scraper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Scraper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Scraper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Scraper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Scraper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Scraper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Scraper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Scraper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Scraper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Scraper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Scraper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Scraper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Scraper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Scraper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Scraper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Scraper] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Scraper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Scraper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Scraper] SET  MULTI_USER 
GO
ALTER DATABASE [Scraper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Scraper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Scraper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Scraper] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Scraper] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Scraper] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Scraper] SET QUERY_STORE = OFF
GO
USE [Scraper]
GO
/****** Object:  Table [dbo].[SearchEngine]    Script Date: 10/01/2021 21:18:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchEngine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[BaseAddress] [varchar](100) NOT NULL,
	[Query] [varchar](25) NOT NULL,
	[Limit] [varchar](25) NOT NULL,
	[RegexTag] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SearchHistory]    Script Date: 10/01/2021 21:18:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SearchHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SearchEngineId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Url] [nvarchar](250) NOT NULL,
	[Result] [nvarchar](max) NULL,
	[keywords] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SearchEngine] ON 

INSERT [dbo].[SearchEngine] ([Id], [Name], [BaseAddress], [Query], [Limit], [RegexTag]) VALUES (2, N'Google (UK)', N'http://www.google.co.uk/search', N'q', N'num', N'<div class=\"g\"(.*?)</div>')
INSERT [dbo].[SearchEngine] ([Id], [Name], [BaseAddress], [Query], [Limit], [RegexTag]) VALUES (7, N'Google (AU)', N'http://www.google.com.au/search', N'q', N'num', N'<div class=\"g\"(.*?)</div>')
INSERT [dbo].[SearchEngine] ([Id], [Name], [BaseAddress], [Query], [Limit], [RegexTag]) VALUES (8, N'Bing', N'http://www.bing.com/search', N'q', N'count', N'<li class=\"b_algo\"(.*?)</div>')
INSERT [dbo].[SearchEngine] ([Id], [Name], [BaseAddress], [Query], [Limit], [RegexTag]) VALUES (9, N'Google', N'http://www.google.com/search', N'q', N'num', N'<div class=\"g\"(.*?)</div>')
SET IDENTITY_INSERT [dbo].[SearchEngine] OFF
GO
SET IDENTITY_INSERT [dbo].[SearchHistory] ON 

INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (5, 2, CAST(N'2021-01-10' AS Date), N'www.infotrack.co.uk', N'6', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (6, 2, CAST(N'2021-01-09' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (7, 2, CAST(N'2021-01-08' AS Date), N'www.infotrack.co.uk', N'8', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (8, 2, CAST(N'2021-01-07' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (9, 2, CAST(N'2021-01-06' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (10, 2, CAST(N'2021-01-05' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (11, 2, CAST(N'2021-01-04' AS Date), N'www.infotrack.co.uk', N'6', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (12, 2, CAST(N'2021-01-03' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (13, 2, CAST(N'2021-01-02' AS Date), N'www.infotrack.co.uk', N'8', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (14, 2, CAST(N'2021-01-01' AS Date), N'www.infotrack.co.uk', N'10', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (15, 2, CAST(N'2020-12-31' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (16, 2, CAST(N'2020-12-30' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (17, 2, CAST(N'2020-12-29' AS Date), N'www.infotrack.co.uk', N'8', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (19, 2, CAST(N'2020-12-27' AS Date), N'www.infotrack.co.uk', N'4', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (20, 2, CAST(N'2020-12-26' AS Date), N'www.infotrack.co.uk', N'24', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (21, 2, CAST(N'2020-12-25' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (22, 2, CAST(N'2020-12-24' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (23, 2, CAST(N'2020-12-23' AS Date), N'www.infotrack.co.uk', N'6, 7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (24, 2, CAST(N'2020-12-22' AS Date), N'www.infotrack.co.uk', N'7, 10', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (25, 2, CAST(N'2020-12-21' AS Date), N'www.infotrack.co.uk', N'9, 10', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (26, 2, CAST(N'2020-12-20' AS Date), N'www.infotrack.co.uk', N'10, 11', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (27, 2, CAST(N'2020-12-19' AS Date), N'www.infotrack.co.uk', NULL, N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (28, 2, CAST(N'2020-12-18' AS Date), N'www.infotrack.co.uk', NULL, N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (29, 2, CAST(N'2020-12-17' AS Date), N'www.infotrack.co.uk', N'7', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (30, 2, CAST(N'2020-12-16' AS Date), N'www.infotrack.co.uk', NULL, N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (31, 2, CAST(N'2020-12-15' AS Date), N'www.infotrack.co.uk', N'1', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (32, 2, CAST(N'2020-12-14' AS Date), N'www.infotrack.co.uk', N'1', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (33, 2, CAST(N'2020-12-13' AS Date), N'www.infotrack.co.uk', NULL, N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (34, 2, CAST(N'2020-12-12' AS Date), N'www.infotrack.co.uk', N'3', N'land registry search')
INSERT [dbo].[SearchHistory] ([Id], [SearchEngineId], [Date], [Url], [Result], [keywords]) VALUES (35, 2, CAST(N'2020-12-11' AS Date), N'www.infotrack.co.uk', N'9', N'land registry search')
SET IDENTITY_INSERT [dbo].[SearchHistory] OFF
GO
ALTER TABLE [dbo].[SearchHistory]  WITH CHECK ADD FOREIGN KEY([SearchEngineId])
REFERENCES [dbo].[SearchEngine] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Scraper] SET  READ_WRITE 
GO
