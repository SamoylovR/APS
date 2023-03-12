USE [master]
GO
/****** Object:  Database [Client]    Script Date: 12.03.2023 21:16:53 ******/
CREATE DATABASE [Client]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Client', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Client.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Client_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Client.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Client] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Client].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Client] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Client] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Client] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Client] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Client] SET ARITHABORT ON 
GO
ALTER DATABASE [Client] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Client] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Client] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Client] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Client] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Client] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Client] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Client] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Client] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Client] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Client] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Client] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Client] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Client] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Client] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Client] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Client] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Client] SET RECOVERY FULL 
GO
ALTER DATABASE [Client] SET  MULTI_USER 
GO
ALTER DATABASE [Client] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Client] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Client] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Client] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Client] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Client]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[cost] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[surname] [varchar](100) NOT NULL,
	[secondname] [varchar](100) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[phone] [varchar](20) NULL,
	[birthday] [date] NULL,
	[Created_at] [datetime] NOT NULL,
	[TypeOfOperation] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contactform]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactform](
	[ContactformId] [int] NOT NULL,
	[ClientId] [int] NULL,
	[name] [varchar](50) NULL,
	[message] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactformId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divorce]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divorce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Client_Id] [int] NULL,
	[Created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[Surname] [varchar](128) NOT NULL,
	[Secondname] [varchar](128) NOT NULL,
	[Email] [varchar](128) NULL,
	[Phone] [varchar](128) NOT NULL,
	[Birthday] [varchar](128) NOT NULL,
	[Location_Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesPositions]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesPositions](
	[PositionId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC,
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marriage]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marriage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Client_Id] [int] NULL,
	[Created_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Client_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[PositionId] [int] NOT NULL,
	[PositionName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12.03.2023 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](250) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[Email] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clients] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[Divorce] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[Marriage] ADD  DEFAULT (getdate()) FOR [Created_at]
GO
ALTER TABLE [dbo].[Contactform]  WITH CHECK ADD FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Divorce]  WITH CHECK ADD FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([id])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([Location_Id])
REFERENCES [dbo].[Location] ([Id])
GO
ALTER TABLE [dbo].[EmployeesPositions]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeesPositions]  WITH CHECK ADD FOREIGN KEY([PositionId])
REFERENCES [dbo].[Position] ([PositionId])
GO
ALTER TABLE [dbo].[Marriage]  WITH CHECK ADD FOREIGN KEY([Client_Id])
REFERENCES [dbo].[Clients] ([id])
GO
USE [master]
GO
ALTER DATABASE [Client] SET  READ_WRITE 
GO
