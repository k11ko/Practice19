USE [master]
GO
/****** Object:  Database [Бухгалтерия]    Script Date: 11.05.2022 10:38:02 ******/
CREATE DATABASE [Бухгалтерия]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Бухгалтерия', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Бухгалтерия.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Бухгалтерия_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Бухгалтерия_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Бухгалтерия] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Бухгалтерия].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Бухгалтерия] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Бухгалтерия] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Бухгалтерия] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Бухгалтерия] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Бухгалтерия] SET ARITHABORT OFF 
GO
ALTER DATABASE [Бухгалтерия] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Бухгалтерия] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Бухгалтерия] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Бухгалтерия] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Бухгалтерия] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Бухгалтерия] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Бухгалтерия] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Бухгалтерия] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Бухгалтерия] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Бухгалтерия] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Бухгалтерия] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Бухгалтерия] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Бухгалтерия] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Бухгалтерия] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Бухгалтерия] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Бухгалтерия] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Бухгалтерия] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Бухгалтерия] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Бухгалтерия] SET  MULTI_USER 
GO
ALTER DATABASE [Бухгалтерия] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Бухгалтерия] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Бухгалтерия] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Бухгалтерия] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Бухгалтерия] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Бухгалтерия] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Бухгалтерия] SET QUERY_STORE = OFF
GO
USE [Бухгалтерия]
GO
/****** Object:  Table [dbo].[Accounting]    Script Date: 11.05.2022 10:38:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounting](
	[НомерПункта] [int] NOT NULL,
	[ДатаПеречисления] [date] NOT NULL,
	[ОрганизацияПолучатель] [nvarchar](50) NOT NULL,
	[Адрес] [nvarchar](50) NOT NULL,
	[Коммерческая] [nchar](10) NOT NULL,
	[ВидЗатратПеречисления] [nvarchar](50) NOT NULL,
	[СуммаПеречисления] [int] NOT NULL,
 CONSTRAINT [PK_Accounting] PRIMARY KEY CLUSTERED 
(
	[НомерПункта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (1, CAST(N'0001-01-01' AS Date), N'ЭТАЛОН-СТРОЙ', N'Г СПАС-КЛЕПИКИ,ПЛ ЛЕНИНА, Д 32', N'Да        ', N'Налог', 10000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (2, CAST(N'2021-12-30' AS Date), N'АВТОГАРАЖНЫЙ КООПЕРАТИВ ИВОВ', N'Г. РЯЗАНЬ, УЛ. ЗУБКОВОЙ, Д. 8, СТР. 1', N'Да        ', N'Зарплата', 30000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (3, CAST(N'2021-08-28' AS Date), N'АО "СЭЛМОН"', N'Г РЯЗАНЬ,196 КМ, ОКРУЖНАЯ ДОРОГА, СТР 11', N'Да        ', N'Налог', 100000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (4, CAST(N'2021-05-20' AS Date), N'АОЗТ "АССЕТС" ', N'Г РЯЗАНЬ,УЛ ТЕЛЕВИЗИОННАЯ, Д 2', N'Да        ', N'Налог', 75000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (5, CAST(N'2022-03-09' AS Date), N'АООТ "КУРС-ЗАЩИТА"', N'Г РЯЗАНЬ,КОЛХОЗНЫЙ ПРОЕЗД, Д 18 В', N'Да        ', N'Материальные затраты', 150000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (6, CAST(N'2022-01-13' AS Date), N'АПДАК "ПРИОРИТЕТ"', N'Г РЯЗАНЬ,УЛ СПАРТАКОВСКАЯ, Д 16', N'Да        ', N'Амортизация', 30000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (7, CAST(N'0001-01-01' AS Date), N'ГК "АГРОПРОМ"', N'Г РЯЗАНЬ,УЛ ПОПОВА, Д 24', N'Да        ', N'Зарплата', 50000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (8, CAST(N'2021-06-17' AS Date), N'ГК "БАМПЕР"', N' Г РЯЗАНЬ,ПЕРВОМАЙСКИЙ ПРОСП, Д 34', N'Нет       ', N'Налог', 20000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (9, CAST(N'2021-10-13' AS Date), N'ЗАО "ИМЗ"', N'Г РЯЗАНЬ,УЛ СВЯЗИ, Д 14 В', N'Да        ', N'Налог', 60000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (10, CAST(N'2021-11-03' AS Date), N'ИЧП ВОРОБЬЕВ', N'Г РЯЗАНЬ,УЛ ЗУБКОВОЙ, Д 21аа', N'Нет       ', N'Налог', 150000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (11, CAST(N'2021-12-09' AS Date), N'КА РЯЗАНСКАЯ КОЛЛЕГИЯ АДВОКАТОВ', N'Г РЯЗАНЬ,УЛ СОКОЛОВСКАЯ, Д 18', N'Да        ', N'Зарплата', 150000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (12, CAST(N'2022-04-21' AS Date), N'КОМИТЕТ САМОУПРАВЛЕНИЯ КВАРТАЛА А ДАШКОВО-ПЕСОЧНЯ', N'Г РЯЗАНЬ,УЛ ЗУБКОВОЙ, Д 2', N'Да        ', N'Налог', 300000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (13, CAST(N'2021-07-21' AS Date), N'КООП "СИГМА"', N'Г РЯЗАНЬ,УЛ КОЛХОЗНАЯ, Д 12, КОРП 2', N'Да        ', N'Материальные затраты', 500000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (14, CAST(N'2022-04-08' AS Date), N'ЛК ООО "ИНКОМ-АРТ"', N'Г РЯЗАНЬ,КУЙБЫШЕВСКОЕ ШОССЕ, Д 40', N'Да        ', N'Налог', 25000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (15, CAST(N'2020-11-11' AS Date), N'ЛК ООО "ПИЖОН"', N'Г РЯЗАНЬ, КУЙБЫШЕВСКОЕ ШОССЕ, Д 25, СТР 17', N'Да        ', N'Зарплата', 90000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (16, CAST(N'0001-01-01' AS Date), N'ЛК ООО "ТОРГОВЫЙ ДОМ "СПЛАВ" ', N'Г РЯЗАНЬ,Р-Н ПЕСОЧНЯ, Д 2, КОРП 2', N'Да        ', N'Налог', 150000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (17, CAST(N'2021-11-03' AS Date), N'ЛК ООО "ЭРБУТ" ', N'РЯЗАНСКАЯ ОБЛ.,Г ШАЦК,УЛ ГОРЬКОГО, Д 48', N'Нет       ', N'Зарплата', 50000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (18, CAST(N'2021-08-20' AS Date), N'МБУДО "ДШИ № 7"', N'Г РЯЗАНЬ,УЛ ЗУБКОВОЙ, Д 21, КОРП 2', N'Да        ', N'Зарплата', 150000)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (31, CAST(N'2022-04-28' AS Date), N'11', N'11', N'Да        ', N'11', 11)
INSERT [dbo].[Accounting] ([НомерПункта], [ДатаПеречисления], [ОрганизацияПолучатель], [Адрес], [Коммерческая], [ВидЗатратПеречисления], [СуммаПеречисления]) VALUES (333, CAST(N'2022-05-20' AS Date), N'awd', N'awd', N'Да        ', N'wadwad', 1111)
GO
USE [master]
GO
ALTER DATABASE [Бухгалтерия] SET  READ_WRITE 
GO
