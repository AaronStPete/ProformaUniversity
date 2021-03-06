USE [master]
GO
/****** Object:  Database [ProformaUniversity]    Script Date: 4/12/2018 1:41:49 PM ******/
CREATE DATABASE [ProformaUniversity]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProformaUniversity', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProformaUniversity.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProformaUniversity_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ProformaUniversity_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProformaUniversity] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProformaUniversity].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProformaUniversity] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProformaUniversity] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProformaUniversity] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProformaUniversity] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProformaUniversity] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProformaUniversity] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProformaUniversity] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProformaUniversity] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProformaUniversity] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProformaUniversity] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProformaUniversity] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProformaUniversity] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProformaUniversity] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProformaUniversity] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProformaUniversity] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProformaUniversity] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProformaUniversity] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProformaUniversity] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProformaUniversity] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProformaUniversity] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProformaUniversity] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProformaUniversity] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProformaUniversity] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProformaUniversity] SET  MULTI_USER 
GO
ALTER DATABASE [ProformaUniversity] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProformaUniversity] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProformaUniversity] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProformaUniversity] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProformaUniversity] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProformaUniversity] SET QUERY_STORE = OFF
GO
USE [ProformaUniversity]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ProformaUniversity]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 4/12/2018 1:41:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[Level] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Room] [nvarchar](50) NULL,
	[StartTime] [datetime] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilledPositions]    Script Date: 4/12/2018 1:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilledPositions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK-ProfIDs] [int] NULL,
	[FK-CourseIDs] [int] NULL,
 CONSTRAINT [PK_FilledPositions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professors]    Script Date: 4/12/2018 1:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentEnrollment]    Script Date: 4/12/2018 1:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentEnrollment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FK-StudentIDs] [int] NULL,
	[FK-CourseIDs] [int] NULL,
 CONSTRAINT [PK_StudentEnrollment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 4/12/2018 1:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Major] [nvarchar](50) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FilledPositions]  WITH CHECK ADD  CONSTRAINT [FK_FilledPositions_Courses] FOREIGN KEY([FK-CourseIDs])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[FilledPositions] CHECK CONSTRAINT [FK_FilledPositions_Courses]
GO
ALTER TABLE [dbo].[FilledPositions]  WITH CHECK ADD  CONSTRAINT [FK_FilledPositions_Professors] FOREIGN KEY([FK-ProfIDs])
REFERENCES [dbo].[Professors] ([ID])
GO
ALTER TABLE [dbo].[FilledPositions] CHECK CONSTRAINT [FK_FilledPositions_Professors]
GO
ALTER TABLE [dbo].[StudentEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollment_Courses] FOREIGN KEY([FK-CourseIDs])
REFERENCES [dbo].[Courses] ([ID])
GO
ALTER TABLE [dbo].[StudentEnrollment] CHECK CONSTRAINT [FK_StudentEnrollment_Courses]
GO
ALTER TABLE [dbo].[StudentEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_StudentEnrollment_Students] FOREIGN KEY([FK-StudentIDs])
REFERENCES [dbo].[Students] ([ID])
GO
ALTER TABLE [dbo].[StudentEnrollment] CHECK CONSTRAINT [FK_StudentEnrollment_Students]
GO
USE [master]
GO
ALTER DATABASE [ProformaUniversity] SET  READ_WRITE 
GO
