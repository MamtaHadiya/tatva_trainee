USE [master]
GO
/****** Object:  Database [Helperland]    Script Date: 28-Mar-22 10:27:56 AM ******/
CREATE DATABASE [Helperland]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Helperland', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Helperland.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Helperland_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Helperland_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Helperland].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Helperland] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Helperland] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Helperland] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Helperland] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Helperland] SET ARITHABORT OFF 
GO
ALTER DATABASE [Helperland] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Helperland] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Helperland] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Helperland] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Helperland] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Helperland] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Helperland] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Helperland] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Helperland] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Helperland] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Helperland] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Helperland] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Helperland] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Helperland] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Helperland] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Helperland] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Helperland] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Helperland] SET RECOVERY FULL 
GO
ALTER DATABASE [Helperland] SET  MULTI_USER 
GO
ALTER DATABASE [Helperland] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Helperland] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Helperland] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Helperland] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Helperland] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Helperland', N'ON'
GO
ALTER DATABASE [Helperland] SET QUERY_STORE = OFF
GO
USE [Helperland]
GO
/****** Object:  Table [dbo].[City]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactUs]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactUs](
	[ContactUsId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Subject] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[UploadFileName] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[FileName] [varchar](500) NULL,
 CONSTRAINT [PK_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ContactUsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoriteAndBlocked]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteAndBlocked](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TargetUserId] [int] NOT NULL,
	[IsFavorite] [bit] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
 CONSTRAINT [PK_FavoriteAndBlocked] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceRequestId] [int] NOT NULL,
	[RatingFrom] [int] NOT NULL,
	[RatingTo] [int] NOT NULL,
	[Ratings] [decimal](2, 1) NOT NULL,
	[Comments] [nvarchar](2000) NULL,
	[RatingDate] [datetime] NOT NULL,
	[OnTimeArrival] [decimal](2, 1) NOT NULL,
	[Friendly] [decimal](2, 1) NOT NULL,
	[QualityOfService] [decimal](2, 1) NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRequest]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRequest](
	[ServiceRequestId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ServiceId] [int] NOT NULL,
	[ServiceStartDate] [datetime] NOT NULL,
	[ZipCode] [nvarchar](10) NOT NULL,
	[ServiceHourlyRate] [decimal](8, 2) NULL,
	[ServiceHours] [float] NOT NULL,
	[ExtraHours] [float] NULL,
	[SubTotal] [decimal](8, 2) NOT NULL,
	[Discount] [decimal](8, 2) NULL,
	[TotalCost] [decimal](8, 2) NOT NULL,
	[Comments] [nvarchar](500) NULL,
	[PaymentTransactionRefNo] [nvarchar](50) NULL,
	[PaymentDue] [bit] NOT NULL,
	[ServiceProviderId] [int] NULL,
	[SPAcceptedDate] [datetime] NULL,
	[HasPets] [bit] NOT NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NULL,
	[RefundedAmount] [decimal](8, 2) NULL,
	[Distance] [decimal](18, 2) NOT NULL,
	[HasIssue] [bit] NULL,
	[PaymentDone] [bit] NULL,
	[RecordVersion] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ServiceRequest] PRIMARY KEY CLUSTERED 
(
	[ServiceRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRequestAddress]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRequestAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceRequestId] [int] NULL,
	[AddressLine1] [nvarchar](200) NULL,
	[AddressLine2] [nvarchar](200) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_ServiceRequestAddress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRequestExtra]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRequestExtra](
	[ServiceRequestExtraId] [int] IDENTITY(1,1) NOT NULL,
	[ServiceRequestId] [int] NOT NULL,
	[ServiceExtraId] [int] NOT NULL,
 CONSTRAINT [PK_ServiceRequestExtra] PRIMARY KEY CLUSTERED 
(
	[ServiceRequestExtraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[TestId] [int] NOT NULL,
	[TestName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NULL,
	[Mobile] [nvarchar](20) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Gender] [int] NULL,
	[DateOfBirth] [datetime] NULL,
	[UserProfilePicture] [nvarchar](200) NULL,
	[IsRegisteredUser] [bit] NOT NULL,
	[PaymentGatewayUserRef] [nvarchar](200) NULL,
	[ZipCode] [nvarchar](20) NULL,
	[WorksWithPets] [bit] NOT NULL,
	[LanguageId] [int] NULL,
	[NationalityId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Status] [int] NULL,
	[BankTokenId] [nvarchar](100) NULL,
	[TaxNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddress](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressLine1] [nvarchar](200) NOT NULL,
	[AddressLine2] [nvarchar](200) NULL,
	[City] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NOT NULL,
	[IsDefault] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Mobile] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_UserAddresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zipcode]    Script Date: 28-Mar-22 10:27:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zipcode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ZipcodeValue] [nvarchar](50) NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_Zipcode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [StateId]) VALUES (1, N'surat', 1)
INSERT [dbo].[City] ([Id], [CityName], [StateId]) VALUES (2, N'bhavnagar', 1)
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[FavoriteAndBlocked] ON 

INSERT [dbo].[FavoriteAndBlocked] ([Id], [UserId], [TargetUserId], [IsFavorite], [IsBlocked]) VALUES (1, 1009, 1007, 0, 1)
INSERT [dbo].[FavoriteAndBlocked] ([Id], [UserId], [TargetUserId], [IsFavorite], [IsBlocked]) VALUES (3, 1009, 1008, 0, 0)
INSERT [dbo].[FavoriteAndBlocked] ([Id], [UserId], [TargetUserId], [IsFavorite], [IsBlocked]) VALUES (1002, 1008, 1009, 0, 0)
SET IDENTITY_INSERT [dbo].[FavoriteAndBlocked] OFF
GO
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([RatingId], [ServiceRequestId], [RatingFrom], [RatingTo], [Ratings], [Comments], [RatingDate], [OnTimeArrival], [Friendly], [QualityOfService]) VALUES (1, 4, 1008, 1009, CAST(3.3 AS Decimal(2, 1)), N'1st feedback', CAST(N'2022-03-12T16:18:28.603' AS DateTime), CAST(3.0 AS Decimal(2, 1)), CAST(4.0 AS Decimal(2, 1)), CAST(3.0 AS Decimal(2, 1)))
INSERT [dbo].[Rating] ([RatingId], [ServiceRequestId], [RatingFrom], [RatingTo], [Ratings], [Comments], [RatingDate], [OnTimeArrival], [Friendly], [QualityOfService]) VALUES (2, 1002, 1008, 1009, CAST(3.7 AS Decimal(2, 1)), N'abc', CAST(N'2022-03-19T10:10:58.407' AS DateTime), CAST(3.0 AS Decimal(2, 1)), CAST(4.0 AS Decimal(2, 1)), CAST(4.0 AS Decimal(2, 1)))
SET IDENTITY_INSERT [dbo].[Rating] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceRequest] ON 

INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (3, 9, 0, CAST(N'2022-02-24T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 0, 1.5, CAST(4.50 AS Decimal(8, 2)), NULL, CAST(225.00 AS Decimal(8, 2)), N'Added Extra', NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-02-22T11:56:38.027' AS DateTime), CAST(N'2022-03-25T11:11:51.373' AS DateTime), 3, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (4, 1008, 0, CAST(N'2022-03-22T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 0, 1, CAST(4.50 AS Decimal(8, 2)), NULL, CAST(225.00 AS Decimal(8, 2)), N'Email Sended', NULL, 0, 1009, NULL, 0, 3, CAST(N'2022-02-22T14:52:04.717' AS DateTime), CAST(N'2022-02-22T14:52:04.717' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (5, 1007, 0, CAST(N'2022-03-17T14:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 0, 1.5, CAST(5.00 AS Decimal(8, 2)), NULL, CAST(250.00 AS Decimal(8, 2)), N'No pets', NULL, 0, 1009, NULL, 0, 3, CAST(N'2022-02-24T15:47:39.797' AS DateTime), CAST(N'2022-02-24T15:47:39.797' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (1002, 1008, 0, CAST(N'2022-03-04T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 0, 1, CAST(4.50 AS Decimal(8, 2)), NULL, CAST(225.00 AS Decimal(8, 2)), NULL, NULL, 0, 1009, NULL, 0, 1, CAST(N'2022-02-26T10:17:44.430' AS DateTime), CAST(N'2022-02-26T10:17:44.430' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (1003, 1008, 0, CAST(N'2022-03-06T15:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 1, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), N'kk', NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-02-26T17:48:50.837' AS DateTime), CAST(N'2022-02-26T17:48:50.837' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2002, 1007, 0, CAST(N'2022-03-25T15:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 4, 1, CAST(5.00 AS Decimal(8, 2)), NULL, CAST(250.00 AS Decimal(8, 2)), N'I dont have pets at home', NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-03-07T11:25:18.953' AS DateTime), CAST(N'2022-03-07T11:25:18.953' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2003, 2007, 0, CAST(N'2022-03-25T16:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 1, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), N'time overload', NULL, 0, 1010, NULL, 0, 3, CAST(N'2022-03-14T14:33:37.547' AS DateTime), CAST(N'2022-03-14T14:33:37.547' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2004, 2007, 0, CAST(N'2022-03-17T15:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3.5, 0.5, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), N'jk booked Service', NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-03-14T14:36:00.143' AS DateTime), CAST(N'2022-03-14T14:36:00.143' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2005, 1008, 0, CAST(N'2022-03-17T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 0, CAST(3.00 AS Decimal(8, 2)), NULL, CAST(150.00 AS Decimal(8, 2)), N'3rd time overlap', NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-03-14T14:45:53.193' AS DateTime), CAST(N'2022-03-14T14:45:53.193' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2006, 2007, 0, CAST(N'2022-03-22T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 0.5, CAST(3.50 AS Decimal(8, 2)), NULL, CAST(175.00 AS Decimal(8, 2)), NULL, NULL, 0, 1009, NULL, 0, 3, CAST(N'2022-03-14T15:07:17.313' AS DateTime), CAST(N'2022-03-14T15:07:17.313' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2007, 2007, 0, CAST(N'2022-03-22T18:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 1, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), NULL, NULL, 0, NULL, NULL, 0, 4, CAST(N'2022-03-14T16:20:40.160' AS DateTime), CAST(N'2022-03-14T16:20:40.160' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2008, 1008, 0, CAST(N'2022-03-18T14:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3.5, 2, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), N'hjj', NULL, 0, NULL, NULL, 0, 2, CAST(N'2022-03-15T19:03:29.987' AS DateTime), CAST(N'2022-03-15T19:03:29.987' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[ServiceRequest] ([ServiceRequestId], [UserId], [ServiceId], [ServiceStartDate], [ZipCode], [ServiceHourlyRate], [ServiceHours], [ExtraHours], [SubTotal], [Discount], [TotalCost], [Comments], [PaymentTransactionRefNo], [PaymentDue], [ServiceProviderId], [SPAcceptedDate], [HasPets], [Status], [CreatedDate], [ModifiedDate], [ModifiedBy], [RefundedAmount], [Distance], [HasIssue], [PaymentDone], [RecordVersion]) VALUES (2009, 1008, 0, CAST(N'2022-03-18T13:00:00.000' AS DateTime), N'395010', CAST(50.00 AS Decimal(8, 2)), 3, 1, CAST(4.00 AS Decimal(8, 2)), NULL, CAST(200.00 AS Decimal(8, 2)), N'jkkh', NULL, 0, 1009, NULL, 0, 2, CAST(N'2022-03-15T19:13:08.637' AS DateTime), CAST(N'2022-03-15T19:13:08.637' AS DateTime), NULL, NULL, CAST(0.00 AS Decimal(18, 2)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ServiceRequest] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceRequestAddress] ON 

INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (1, 3, N'CreationPlaza', N'12', N'Surat', NULL, N'395010', N'8256445155', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2, 4, N'Sardar Complex', N'96', N'Surat', NULL, N'395010', N'1235678940', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (3, 5, N'Creation Plaza 2', N'36', N'Surat', NULL, N'395010', N'5648723195', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (1002, 1002, N'Creation Plaza 2', N'12', N'Surat', NULL, N'395010', N'5648723195', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (1003, 1003, N'Creation Plaza 2', N'20', N'Surat', NULL, N'395010', N'5648723195', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2002, 2002, N'Creation Plaza 3', N'70', N'Surat', NULL, N'395010', N'5613489257', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2003, 2003, N'Busan Society', N'96', N'Busan', NULL, N'395010', N'4562897185', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2004, 2004, N'Busan Society', N'96', N'Busan', NULL, N'395010', N'4562897185', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2005, 2005, N'Shivshakti Society', N'34', N'Surat', NULL, N'395010', N'8256445134', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2006, 2006, N'Busan Society', N'96', N'Busan', NULL, N'395010', N'4562897185', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2007, 2007, N'Busan 2 Society', N'12', N'Busan', NULL, N'395010', N'5648723195', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2008, 2008, N'Shivshakti Society', N'34', N'Surat', NULL, N'395010', N'8256445134', NULL)
INSERT [dbo].[ServiceRequestAddress] ([Id], [ServiceRequestId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [Mobile], [Email]) VALUES (2009, 2009, N'Shivshakti Society', N'34', N'Surat', NULL, N'395010', N'8256445134', NULL)
SET IDENTITY_INSERT [dbo].[ServiceRequestAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[ServiceRequestExtra] ON 

INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (1, 3, 4)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2, 3, 1)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (3, 3, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (4, 4, 3)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (5, 4, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (6, 5, 4)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (7, 5, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (8, 5, 1)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (1002, 1002, 3)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (1003, 1002, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (1004, 1003, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (1005, 1003, 3)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2002, 2002, 3)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2003, 2002, 5)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2004, 2003, 3)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2005, 2003, 4)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2006, 2004, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2007, 2006, 5)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2008, 2007, 1)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2009, 2007, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2010, 2008, 2)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2011, 2009, 1)
INSERT [dbo].[ServiceRequestExtra] ([ServiceRequestExtraId], [ServiceRequestId], [ServiceExtraId]) VALUES (2012, 2009, 3)
SET IDENTITY_INSERT [dbo].[ServiceRequestExtra] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([Id], [StateName]) VALUES (1, N'Gujarat')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (9, N'First', N'Last', N'cust001@yopmail.com', N'Tatva@123', N'1234567890', 2, NULL, NULL, NULL, 1, NULL, NULL, 1, NULL, NULL, CAST(N'2022-02-15T16:34:30.743' AS DateTime), CAST(N'2022-02-15T16:34:30.743' AS DateTime), 2, 0, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (10, N'pro', N'pro', N'pro@gmail.com', N'Pro@123', N'1235678940', 2, NULL, NULL, NULL, 1, NULL, NULL, 1, NULL, NULL, CAST(N'2022-02-03T15:41:17.207' AS DateTime), CAST(N'2022-02-03T15:41:17.207' AS DateTime), 2, 0, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (1007, N'abcd', N'abcd', N'abc20@gmail.com', N'Abc@123', N'9825485615', 1, NULL, CAST(N'2014-02-05T18:39:00.000' AS DateTime), NULL, 1, NULL, NULL, 1, 1, NULL, CAST(N'2022-02-11T13:14:11.753' AS DateTime), CAST(N'2022-03-25T10:06:36.993' AS DateTime), 3, 0, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (1008, N'Mamata', N'Hadiya', N'hadiyamamta4590@gmail.com', N'Mamta@123', N'8238322588', 1, NULL, CAST(N'2001-01-14T00:00:00.000' AS DateTime), NULL, 1, NULL, NULL, 1, 1, NULL, CAST(N'2022-02-15T14:55:13.570' AS DateTime), CAST(N'2022-02-15T14:55:13.570' AS DateTime), 1, 0, 0, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (1009, N'Kim', N'KimT', N'Kim001@yopmail.com', N'Kim@123', N'8238322585', 2, 1, CAST(N'2012-02-18T00:00:00.000' AS DateTime), N'smiley.png', 1, NULL, N'395010', 1, NULL, 2, CAST(N'2022-02-22T14:04:50.703' AS DateTime), CAST(N'2022-03-25T10:43:45.660' AS DateTime), 3, 1, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (1010, N'Jimin', N'Park', N'Park001@yopmail.com', N'Park@123', N'1234567890', 2, 1, CAST(N'1994-02-03T00:00:00.000' AS DateTime), N'cap.png', 1, NULL, N'395010', 1, NULL, 2, CAST(N'2022-02-22T14:14:18.240' AS DateTime), CAST(N'2022-03-25T10:46:59.963' AS DateTime), 3, 1, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (2007, N'Jungkook', N'Jeon', N'jk001@yopmail.com', N'Jk@123', N'4581664646', 1, NULL, CAST(N'1996-06-13T14:37:00.000' AS DateTime), NULL, 1, NULL, NULL, 1, 1, NULL, CAST(N'2022-03-11T15:55:33.407' AS DateTime), CAST(N'2022-03-11T15:55:33.407' AS DateTime), 1, 0, 0, 1, NULL, NULL, NULL)
INSERT [dbo].[User] ([UserId], [FirstName], [LastName], [Email], [Password], [Mobile], [UserTypeId], [Gender], [DateOfBirth], [UserProfilePicture], [IsRegisteredUser], [PaymentGatewayUserRef], [ZipCode], [WorksWithPets], [LanguageId], [NationalityId], [CreatedDate], [ModifiedDate], [ModifiedBy], [IsApproved], [IsActive], [IsDeleted], [Status], [BankTokenId], [TaxNo]) VALUES (3007, N'Admin', N'Kim', N'admin001@yopmail.com', N'Admin@123', N'9825485615', 3, NULL, NULL, NULL, 1, NULL, NULL, 1, NULL, NULL, CAST(N'2022-03-25T14:38:27.860' AS DateTime), CAST(N'2022-03-25T14:38:27.863' AS DateTime), 1, 1, 0, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAddress] ON 

INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (1, 9, N'CreationPlaza', N'12', N'Surat', NULL, N'395010', 0, 0, N'8256445155', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2, 9, N'Sardar Complex', N'90', N'Surat', NULL, N'395010', 0, 0, N'1235678940', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (1002, 1008, N'Shivshakti Society', N'35', N'Surat', NULL, N'395010', 0, 0, N'8256445134', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2002, 1007, N'Creation Plaza 3', N'72', N'Surat', NULL, N'395010', 0, 0, N'5613489257', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2003, 1007, N'Vishwakarma Society', N'208', N'Ahmedabad', NULL, N'382424', 0, 0, N'5684615482', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2005, 1007, N'Shivshakti Society', N'12', N'Surat', NULL, N'395010', 0, 0, N'8256445155', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2006, 1009, N'Big Hit', N'20', N'Seoul', NULL, N'395010', 0, 0, N'8238322588', N'Kim001@yopmail.com')
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2007, 2007, N'Busan Society', N'96', N'Busan', NULL, N'395010', 0, 0, N'4562897185', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2008, 2007, N'Busan 2 Society', N'12', N'Busan', NULL, N'395010', 0, 0, N'5648723195', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2009, 1008, N'Creation Plaza', N'52', N'Surat', NULL, N'395010', 0, 0, N'4561879354', NULL)
INSERT [dbo].[UserAddress] ([AddressId], [UserId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [IsDefault], [IsDeleted], [Mobile], [Email]) VALUES (2011, 1010, N'BigHit New', N'96', N'Busan', NULL, N'395010', 0, 0, N'1234567890', N'Park001@yopmail.com')
SET IDENTITY_INSERT [dbo].[UserAddress] OFF
GO
SET IDENTITY_INSERT [dbo].[Zipcode] ON 

INSERT [dbo].[Zipcode] ([Id], [ZipcodeValue], [CityId]) VALUES (1, N'395003', 1)
INSERT [dbo].[Zipcode] ([Id], [ZipcodeValue], [CityId]) VALUES (2, N'395010', 1)
SET IDENTITY_INSERT [dbo].[Zipcode] OFF
GO
ALTER TABLE [dbo].[Rating] ADD  CONSTRAINT [DF_Rating_OnTimeArrival]  DEFAULT ((0)) FOR [OnTimeArrival]
GO
ALTER TABLE [dbo].[Rating] ADD  CONSTRAINT [DF_Rating_Friendly]  DEFAULT ((0)) FOR [Friendly]
GO
ALTER TABLE [dbo].[Rating] ADD  CONSTRAINT [DF_Rating_QualityOfService]  DEFAULT ((0)) FOR [QualityOfService]
GO
ALTER TABLE [dbo].[ServiceRequest] ADD  CONSTRAINT [DF_ServiceRequest_PaymentDue]  DEFAULT ((0)) FOR [PaymentDue]
GO
ALTER TABLE [dbo].[ServiceRequest] ADD  CONSTRAINT [DF_ServiceRequest_IsPet]  DEFAULT ((0)) FOR [HasPets]
GO
ALTER TABLE [dbo].[ServiceRequest] ADD  CONSTRAINT [DF_ServiceRequest_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ServiceRequest] ADD  CONSTRAINT [DF_ServiceRequest_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO
ALTER TABLE [dbo].[ServiceRequest] ADD  CONSTRAINT [DF_ServiceRequest_Distance]  DEFAULT ((0)) FOR [Distance]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsRegisteredUser]  DEFAULT ((0)) FOR [IsRegisteredUser]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_WorksWithPets]  DEFAULT ((0)) FOR [WorksWithPets]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserAddress] ADD  CONSTRAINT [DF_UserAddresses_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[UserAddress] ADD  CONSTRAINT [DF_UserAddresses_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_City_State] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_City_State]
GO
ALTER TABLE [dbo].[FavoriteAndBlocked]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteAndBlocked_FavoriteAndBlocked] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[FavoriteAndBlocked] CHECK CONSTRAINT [FK_FavoriteAndBlocked_FavoriteAndBlocked]
GO
ALTER TABLE [dbo].[FavoriteAndBlocked]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteAndBlocked_User] FOREIGN KEY([TargetUserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[FavoriteAndBlocked] CHECK CONSTRAINT [FK_FavoriteAndBlocked_User]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_ServiceRequest] FOREIGN KEY([ServiceRequestId])
REFERENCES [dbo].[ServiceRequest] ([ServiceRequestId])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_ServiceRequest]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_User] FOREIGN KEY([RatingFrom])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_User]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_User1] FOREIGN KEY([RatingTo])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_User1]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequest_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK_ServiceRequest_User]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequest_User1] FOREIGN KEY([ServiceProviderId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK_ServiceRequest_User1]
GO
ALTER TABLE [dbo].[ServiceRequestAddress]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequestAddress_ServiceRequest] FOREIGN KEY([ServiceRequestId])
REFERENCES [dbo].[ServiceRequest] ([ServiceRequestId])
GO
ALTER TABLE [dbo].[ServiceRequestAddress] CHECK CONSTRAINT [FK_ServiceRequestAddress_ServiceRequest]
GO
ALTER TABLE [dbo].[ServiceRequestExtra]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequestExtra_ServiceRequest] FOREIGN KEY([ServiceRequestId])
REFERENCES [dbo].[ServiceRequest] ([ServiceRequestId])
GO
ALTER TABLE [dbo].[ServiceRequestExtra] CHECK CONSTRAINT [FK_ServiceRequestExtra_ServiceRequest]
GO
ALTER TABLE [dbo].[UserAddress]  WITH CHECK ADD  CONSTRAINT [FK_UserAddresses_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserAddress] CHECK CONSTRAINT [FK_UserAddresses_User]
GO
ALTER TABLE [dbo].[Zipcode]  WITH CHECK ADD  CONSTRAINT [FK_Zipcode_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Zipcode] CHECK CONSTRAINT [FK_Zipcode_City]
GO
USE [master]
GO
ALTER DATABASE [Helperland] SET  READ_WRITE 
GO
