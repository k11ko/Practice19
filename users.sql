USE [master]
GO
/****** Object:  Database [Users]    Script Date: 11.05.2022 10:37:38 ******/
CREATE DATABASE [Users]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Users', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Users_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Users_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Users] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Users].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Users] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Users] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Users] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Users] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Users] SET ARITHABORT OFF 
GO
ALTER DATABASE [Users] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Users] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Users] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Users] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Users] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Users] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Users] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Users] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Users] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Users] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Users] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Users] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Users] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Users] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Users] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Users] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Users] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Users] SET  MULTI_USER 
GO
ALTER DATABASE [Users] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Users] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Users] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Users] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Users] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Users] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Users] SET QUERY_STORE = OFF
GO
USE [Users]
GO
/****** Object:  Table [dbo].[user]    Script Date: 11.05.2022 10:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[ID] [int] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Rights] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[SecondName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (1, N'k1k0', N'2571486', N'admin', N'kiryshka1092@mail.ru', N'Кирилл', N'Константинов')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (2, N'omega', N'1234567890', N'admin', N'rssk@rssk.rsreu.ru', N'Александр', N'Юдаев')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (3, N'Hloij', N'340137', N'user', N'sibfaguangca1978@rambler.ru', N'Дмитрий', N'Бандуркин')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (4, N'daktrines', N'57585954', N'admin', N'daktrines#4948@discord.com', N'Екатерина', N'Калион')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (5, N'kmitrokhinaaa', N'34821547', N'user', N'Ксю#2227@discord.com', N'Ксения', N'Митрохина')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (6, N'oskolkova', N'134679', N'user', N'anastasiawhite228@gmail.com', N'Анастасия', N'Емельянова')
INSERT [dbo].[user] ([ID], [Login], [Password], [Rights], [Email], [FirstName], [SecondName]) VALUES (7, N'iro4ka66', N'kirilldurak', N'user', N'irishabaeva9@gmail.com', N'Ирина', N'Баева')
GO
USE [master]
GO
ALTER DATABASE [Users] SET  READ_WRITE 
GO
