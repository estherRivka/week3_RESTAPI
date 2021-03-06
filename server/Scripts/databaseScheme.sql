USE [master]
GO
/****** Object:  Database [coronaInformation]    Script Date: 6/8/2020 5:14:25 PM ******/
CREATE DATABASE [coronaInformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'coronaInformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\coronaInformation.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'coronaInformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER01\MSSQL\DATA\coronaInformation_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [coronaInformation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [coronaInformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [coronaInformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [coronaInformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [coronaInformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [coronaInformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [coronaInformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [coronaInformation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [coronaInformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [coronaInformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [coronaInformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [coronaInformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [coronaInformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [coronaInformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [coronaInformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [coronaInformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [coronaInformation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [coronaInformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [coronaInformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [coronaInformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [coronaInformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [coronaInformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [coronaInformation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [coronaInformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [coronaInformation] SET RECOVERY FULL 
GO
ALTER DATABASE [coronaInformation] SET  MULTI_USER 
GO
ALTER DATABASE [coronaInformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [coronaInformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [coronaInformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [coronaInformation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [coronaInformation] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'coronaInformation', N'ON'
GO
ALTER DATABASE [coronaInformation] SET QUERY_STORE = OFF
GO
USE [coronaInformation]
GO
/****** Object:  User [CoronInformationUser]    Script Date: 6/8/2020 5:14:25 PM ******/
CREATE USER [CoronInformationUser] FOR LOGIN [IIS APPPOOL\DefaultAppPool] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [CoronInformationUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [CoronInformationUser]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 6/8/2020 5:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [xml] NULL,
	[LogEvent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paths]    Script Date: 6/8/2020 5:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paths](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [nvarchar](max) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Location] [nvarchar](max) NULL,
	[PatientId] [int] NOT NULL,
 CONSTRAINT [PK_Paths] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/8/2020 5:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[Age] [int] NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Paths]  WITH CHECK ADD FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
GO
ALTER TABLE [dbo].[Paths]  WITH CHECK ADD  CONSTRAINT [FK_Paths_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Paths] CHECK CONSTRAINT [FK_Paths_Patients_PatientId]
GO
USE [master]
GO
ALTER DATABASE [coronaInformation] SET  READ_WRITE 
GO
