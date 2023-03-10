USE [master]
GO
/****** Object:  Database [SVDB]    Script Date: 31/01/2023 12:30:50 pm ******/
CREATE DATABASE [SVDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SVDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SVDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SVDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SVDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE SQL_Latin1_General_CP1_CI_AS
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SVDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SVDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SVDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SVDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SVDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SVDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SVDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SVDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SVDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SVDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SVDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SVDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SVDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SVDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SVDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SVDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SVDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SVDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SVDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SVDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SVDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SVDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SVDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SVDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SVDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SVDB] SET  MULTI_USER 
GO
ALTER DATABASE [SVDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SVDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SVDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SVDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SVDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SVDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SVDB', N'ON'
GO
ALTER DATABASE [SVDB] SET QUERY_STORE = OFF
GO
USE [SVDB]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyResponseProfileId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[AnswerText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocPath] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NormalizedName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConcurrencyStamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClaimType] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClaimValue] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProviderKey] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProviderDisplayName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NormalizedUserName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NormalizedEmail] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecurityStamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConcurrencyStamp] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LoginProvider] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Value] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Department] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailTemplate]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmailTemplate](
	[Id] [int] NOT NULL,
	[SenderName] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Subject] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Body] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[QuestionText] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Type] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[IsRequire] [bit] NOT NULL,
	[IsDocRequire] [bit] NOT NULL,
	[DocPath] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OptionsText] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CssClass] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OptionsAlignment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LogicalQuestionText] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParentQuestionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Language] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LogoPath] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BannerPath] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BackgroundImagePath] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MaxResponse] [int] NULL,
	[QuestionPerPage] [int] NULL,
	[IsLaunched] [bit] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[DepartmentIds] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SurveyType] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IsRejected] [bit] NULL,
	[IsSubmitted] [bit] NULL,
 CONSTRAINT [PK__Survey__3214EC076FDE4AC7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveyResponseProfile]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveyResponseProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyId] [int] NOT NULL,
	[Full Name] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ResponseOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SurveySharedWithCustomers]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SurveySharedWithCustomers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SurveyID] [int] NULL,
	[Email] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HasSubmitted] [bit] NULL,
	[ContactNumber] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UniqueSurveyURL] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDepartments]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDepartments](
	[UserID] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DepartmentID] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogs]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogs](
	[UserID] [varchar](900) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[UserName] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedOn] [datetime] NULL,
	[LastLoggedIn] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserShareSurvey]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserShareSurvey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SurveyId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2408, 3074, 56, N'asda', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2409, 3074, 33, N'sada', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2410, 3074, 29, N'Single', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2411, 3074, 32, N'Oman', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2412, 3074, 30, N'From a friend', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2413, 3074, 39, N'No', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2414, 3074, 28, N'The interaction with the sales staff,Very satisfied
Your experience at the register,Satisfied
The organization of the store,Satisfied', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2415, 3074, 34, N'Active,Strongly Disagree', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2416, 3074, 35, N'Active,No opinion
Cool,Strongly Disagree
Sophisticated,No opinion', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2417, 3074, 31, N'No, the products were not fit to my choice', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2418, 3074, 36, N'3', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2419, 3074, 37, N'2', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2420, 3074, 38, N'kk', NULL)
INSERT [dbo].[Answer] ([Id], [SurveyResponseProfileId], [QuestionId], [AnswerText], [DocPath]) VALUES (2421, 3074, 55, N'Yes, Samar Kaam krta hai', NULL)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'366f4a22-06dd-4259-9640-85767d168a18', N'Pollster', N'POLLSTER', N'4391a0a2-9df1-4158-912a-39c3072eb1f9')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4856abd9-11af-4eba-a122-47a00969fa5d', N'Admin', N'ADMIN', N'e499428f-0bfb-4a0e-8dbb-e75e7f472523')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4856abd9-11af-4eba-a122-47a00969fa5e', N'User Manager', N'USER MANAGER', N'e499428f-0bfb-4a0e-8dbb-e75e7f472523')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4856abd9-11af-4eba-a122-47a00969fa5f', N'Reviewer', N'REVIEWER', N'e499428f-0bfb-4a0e-8dbb-e75e7f472524')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4856abd9-11af-4eba-a122-47a00969fa5j', N'test', N'TEST', N'e499428f-0bfb-4a0e-8dbb-e75e7f472521')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26f47846-28a0-419a-9421-89ed4b60c7e0', N'4856abd9-11af-4eba-a122-47a00969fa5f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'4856abd9-11af-4eba-a122-47a00969fa5d')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7d92d400-3590-450d-885b-44787cafd662', N'4856abd9-11af-4eba-a122-47a00969fa5f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ba2a1db8-6247-4b99-8177-94cafa0e0694', N'4856abd9-11af-4eba-a122-47a00969fa5e')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dd40d7d0-b3ed-46fd-9597-86f4ed6060be', N'4856abd9-11af-4eba-a122-47a00969fa5f')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e4311ef9-9bac-4bbe-8190-85b8f8ada607', N'366f4a22-06dd-4259-9640-85767d168a18')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'26f47846-28a0-419a-9421-89ed4b60c7e0', N'RevHR2', N'REVHR2', N'revhr2@gmail.com', N'REVHR2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEOyZm+SLQyKzgQbpqcA2Q76JIAo/PB8O3s6wOQnQ5h0n17I7/S4JBbaa+oc6QeRlfw==', N'SNHV7L2KDCNXEYTQFBIOHDOSNJI5R2U5', N'e8c80d40-cfff-4068-908f-40cd255f0dd0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Admin', N'ADMIN', N'syedahmer66@gmail.com', N'SYEDAHMER66@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEMfk9xhAJCBMYHBNAgIvbP+KqCYjj1N9Fers1CoYWedZ8hCfoRVg19a/XEmmoAGPYw==', N'DVPE6CZMS2XMMCMJUX6C667KSMYNW6LG', N'2f9b9c74-2f2f-40fb-bb31-dd900e1c68b5', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7d92d400-3590-450d-885b-44787cafd662', N'RevHR1', N'REVHR1', N'rev2@gmail.com', N'REV2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL+8ODU0djoyk8zevhR+km872bNWZOrSzruZWFBjkrGATsUbkULBL4osUtSKls8Zhw==', N'LQNL5MGV6QZMZZMW3CKVFRPE3T6LPVPA', N'09b0ecb3-b4d7-4b83-a16d-c75c6de86b33', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ba2a1db8-6247-4b99-8177-94cafa0e0694', N'infoUs', N'INFOUS', N'infouser@gmail.com', N'INFOUSER@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKd3SLEsLHUAUTZ+vs8AsUbYmJdcNFDNN6h/bqwnv0mMzp4iYYArpZdqQGznQEv9kA==', N'XQAWFK6FPQUPMC5PEOZJ3MJXRZRNAXTS', N'04fd9470-2697-4770-a3bd-309843d77688', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'dd40d7d0-b3ed-46fd-9597-86f4ed6060be', N'Reviewer', N'REVIEWER', N'reviewer1@gmail.com', N'REVIEWER1@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHX55sAcCUVJxBf9na3UJt9RXHQEq5OoOTVtrLdpqx4Kb1HAH6jX9xss3k9zl59xhw==', N'3AWCSMCCOZKXSKBS2B3P3PEHOHHIGKCJ', N'f3ae07c2-00a4-45bf-9c0c-14ca5e229f02', NULL, 0, 0, CAST(N'2022-11-18T09:49:56.0002183+00:00' AS DateTimeOffset), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e4311ef9-9bac-4bbe-8190-85b8f8ada607', N'Polls1', N'POLLS1', N'polls1@gmail.com', N'POLLS1@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEGY03KO4rIhPI2SwSbHl6ozeF/XNAORhOxNfWhMw0vnxJNd85Cpofn1XJRyfC1nkng==', N'JUTMHGQRNJE3RD45OLKPXQYOK4BFHUBW', N'50a5fe72-6cfc-4b9e-9aa7-c48d0b628a97', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Department]) VALUES (1, N'HR')
INSERT [dbo].[Departments] ([ID], [Department]) VALUES (2, N'Infosec')
INSERT [dbo].[Departments] ([ID], [Department]) VALUES (3, N'Back End Development')
INSERT [dbo].[Departments] ([ID], [Department]) VALUES (5, N'Front End Development')
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
INSERT [dbo].[EmailTemplate] ([Id], [SenderName], [Subject], [Body]) VALUES (1, N'Bank Nizwa Admin', N'Bank Nizwa Survey', N'Dear #Name,

Since a new survey is created, you are requested to follow the link below to fill it

Survey URL: <a href="#surl">Click Here</a>')
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (28, 1003, 7, N'How satisfied or dissatisfied are you with the following', N'Semantic Question', 1, 0, NULL, N'Very satisfied
Satisfied
Neither satisfied nor dissatisfied
Dissatisfied
Very dissatisfiedMH_MR_SPThe interaction with the sales staff
Your experience at the register
The organization of the store
The wait for the fitting room
The products offered in the store
The price of the products', NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (29, 1003, 3, N'Select your marital status', N'Radio', 1, 0, NULL, N'Married
Single
Divorced
Separated
Widowed', NULL, N'horizontal', NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (30, 1003, 5, N'How did you hear about our company?', N'Multiple Choice', 1, 0, NULL, N'Television
Internet
From a friend
Newspaper
Social Media', NULL, N'vertical', NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (31, 1003, 10, N'Will you come back to buy more products from our outlet?', N'Yes or No', 1, 0, NULL, N'Yes, I will happy to come again
No, the products were not fit to my choice', NULL, N'horizontal', NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (32, 1003, 4, N'Select your home country', N'Dropdown Menu', 1, 0, NULL, N'Pakistan
China
India
United Kingdom
Oman
UAE
Saudi Arabia
Qatar
Bahrain', NULL, N'vertical', NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (33, 1003, 2, N'What is your name?', N'Single Text', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (34, 1003, 8, N'Please choose the degree to which you feel the following descriptions align with our brand', N'Matrix Single', 1, 0, NULL, N'Strongly Agree
Strongly Disagree
No opinionMH_MR_SPActive
Cool
Funny', NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (35, 1003, 9, N'Please choose the degree to which you feel the following descriptions align with our brand (Matrix Multi Select)', N'Matrix Multi Select', 1, 0, NULL, N'Strongly Agree
Strongly Disagree
No opinionMH_MR_SPActive
Cool
Funny
Sophisticated', NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (36, 1003, 11, N'Please rate us', N'Rating', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (37, 1003, 12, N'How likely is it that you would recommend this company to a friend or colleague?', N'Net Promoter Score', 1, 0, NULL, N'NOT AT ALL LIKELY
EXTREMELY LIKELY', NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (38, 1003, 13, N'Please give your suggestion on improving our services!', N'Comment Box', 0, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (39, 1003, 6, N'Do u like shirts?', N'Logic', 1, 0, NULL, N'Yes
No', NULL, N'horizontal', N'Yes', NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (40, 1003, 13, N'Which type of shirts you like?', N'Multiple Choice', 1, 0, NULL, N'Checked Shirts
Plain Shirts', NULL, N'vertical', NULL, 39)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (55, 1003, 14, N'samar kia krta hai
', N'Yes or No', 0, 0, NULL, N'Yes, Samar Kaam krta hai
', NULL, N'vertical', NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (56, 1003, 1, N'Enter Email', N'Single Text', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (57, 4032, 1, N'Question1', N'Yes or No', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (58, 4032, 2, N'Sample Question', N'Yes or No', 1, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (59, 4032, 3, N'Sample Question 2', N'Yes or No', 1, 1, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (60, 4032, 4, N'Sample Question 2', N'Yes or No', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Question] ([Id], [SurveyId], [Order], [QuestionText], [Type], [IsRequire], [IsDocRequire], [DocPath], [OptionsText], [CssClass], [OptionsAlignment], [LogicalQuestionText], [ParentQuestionId]) VALUES (61, 4033, 1, N'ueston', N'Yes or No', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (1003, N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Customer Satisfaction Survey', N'English', N'not found', N'not found', N'not found', 15, 5, 1, CAST(N'2023-01-02T01:49:00.000' AS DateTime), CAST(N'2023-02-09T01:49:00.000' AS DateTime), N'1', N'CLOSED', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (4030, N'ba2a1db8-6247-4b99-8177-94cafa0e0694', N'Samar', N'English', N'not found', N'not found', N'not found', 0, 500, 0, NULL, NULL, N'1', N'OPEN', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (4031, N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Survey 2', N'English', N'not found', N'not found', N'not found', 0, 5, 0, NULL, NULL, N'5', N'OPEN', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (4032, N'ba2a1db8-6247-4b99-8177-94cafa0e0694', N'Eg Survey', N'English', N'not found', N'not found', N'not found', 0, 5, 0, CAST(N'2022-11-20T02:46:00.000' AS DateTime), CAST(N'2022-11-30T02:46:00.000' AS DateTime), N'5', N'CLOSED', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (4033, N'e4311ef9-9bac-4bbe-8190-85b8f8ada607', N'Last Survey', N'English', N'not found', N'not found', N'not found', 0, 5, 0, NULL, NULL, N'5', N'OPEN', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (5033, N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Testosterone', N'English', N'not found', N'not found', N'not found', 0, 5, 0, NULL, NULL, N'5', N'OPEN', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (5034, N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Nizwa', N'English', N'not found', N'not found', N'not found', 0, 5, 0, NULL, NULL, N'5', N'OPEN', 0, 1)
INSERT [dbo].[Survey] ([Id], [UserId], [Name], [Language], [LogoPath], [BannerPath], [BackgroundImagePath], [MaxResponse], [QuestionPerPage], [IsLaunched], [StartDate], [EndDate], [DepartmentIds], [SurveyType], [IsRejected], [IsSubmitted]) VALUES (6035, N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Excel Survey', N'English', N'not found', N'not found', N'not found', 0, 5, 0, CAST(N'2022-12-04T14:39:00.000' AS DateTime), CAST(N'2022-12-24T14:39:00.000' AS DateTime), N'5', N'CLOSED', 0, 1)
SET IDENTITY_INSERT [dbo].[Survey] OFF
GO
SET IDENTITY_INSERT [dbo].[SurveyResponseProfile] ON 

INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1, 1, N'', CAST(N'2021-10-24T19:16:09.580' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2, 1, N'', CAST(N'2021-10-24T19:22:34.977' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (3, 1, N'', CAST(N'2021-10-28T02:24:26.737' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (4, 2, N'', CAST(N'2021-10-28T23:37:18.377' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (5, 2, N'', CAST(N'2021-10-28T23:43:42.453' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (6, 2, N'', CAST(N'2021-10-29T00:14:22.640' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (7, 1002, N'', CAST(N'2021-10-29T01:01:54.737' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1048, 1013, N'', CAST(N'2022-03-07T17:47:46.223' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1049, 1013, N'', CAST(N'2022-03-07T18:13:52.110' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1050, 1013, N'', CAST(N'2022-03-07T18:14:28.930' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1051, 1013, N'', CAST(N'2022-03-07T18:15:20.447' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1052, 1013, N'', CAST(N'2022-03-07T18:22:14.360' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1053, 1013, N'', CAST(N'2022-03-07T18:26:44.260' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1054, 1013, N'', CAST(N'2022-03-07T18:28:05.523' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1055, 1013, N'', CAST(N'2022-03-07T18:35:34.330' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1056, 1013, N'', CAST(N'2022-03-07T18:37:47.473' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1057, 1013, N'', CAST(N'2022-03-08T14:38:17.297' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1058, 1013, N'', CAST(N'2022-03-10T13:39:03.113' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (1059, 1015, N'', CAST(N'2022-04-21T13:50:29.143' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2063, 3027, N'', CAST(N'2022-07-29T05:30:39.137' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2064, 3028, N'', CAST(N'2022-07-29T05:35:52.287' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2065, 3028, N'', CAST(N'2022-07-29T05:36:02.047' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2066, 3028, N'', CAST(N'2022-07-29T05:36:09.567' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2067, 3028, N'', CAST(N'2022-07-29T05:46:05.373' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2068, 3028, N'', CAST(N'2022-07-29T05:46:13.193' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2069, 3028, N'', CAST(N'2022-07-29T05:46:20.493' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2070, 3027, N'', CAST(N'2022-07-29T05:53:22.010' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (2071, 3027, N'', CAST(N'2022-07-29T05:55:46.423' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (3072, 4032, N'', CAST(N'2022-11-11T00:55:51.953' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (3073, 4032, N'', CAST(N'2022-11-11T01:27:21.940' AS DateTime))
INSERT [dbo].[SurveyResponseProfile] ([Id], [SurveyId], [Full Name], [ResponseOn]) VALUES (3074, 1003, N'', CAST(N'2023-01-02T01:55:48.063' AS DateTime))
SET IDENTITY_INSERT [dbo].[SurveyResponseProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[SurveySharedWithCustomers] ON 

INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1, 3027, N'samarjhaider@gmail.com', 1, N'03331304025', N'https://tinyurl.com/2a47b8pt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2, 3027, N'murtazahaider@gmail.com', 0, N'03368303860', N'https://tinyurl.com/235ez8ex')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (3, 3027, N'shabbirhaider@gmail.com', 1, N'03323979729', N'https://tinyurl.com/269aregc')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (4, 3027, N'ammarhaider@gmail.com', 1, N'03323846156', N'https://tinyurl.com/2ccqu9t8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (5, 3027, N'bilal@gmail.com', 0, N'bilal@gmail.com', N'https://tinyurl.com/2xubmbc8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (6, 3027, N'zain@gmail.com', 0, N'zain@gmail.com', N'https://tinyurl.com/2cj3jtvd')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (7, 3027, N'junaid@gmail.com', 0, N'junaid@gmail.com', N'https://tinyurl.com/234xjz4e')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (8, 3027, N'samarjhaider@gmail.com', 0, N'samarjhaider@gmail.com', N'https://tinyurl.com/2a47b8pt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (9, 1003, N'samar@gmail.com', 0, N'samar@gmail.com', N'https://tinyurl.com/2kfkpmjl')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (10, 1003, N'haider@gmail.com', 0, N'haider@gmail.com', N'https://tinyurl.com/2my5vg4v')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1009, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1010, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1011, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1012, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1013, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1014, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1015, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1016, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1017, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1018, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1019, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1020, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1021, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1022, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1023, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1024, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1025, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1026, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1027, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1028, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1029, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1030, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1031, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1032, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1033, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1034, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1035, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1036, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1037, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1038, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1039, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1040, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1041, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1042, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1043, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1044, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1045, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1046, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1047, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1048, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1049, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1050, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1051, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1052, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1053, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1054, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1055, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1056, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1057, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1058, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1059, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1060, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1061, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1062, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1063, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1064, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1065, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1066, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1067, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1068, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1069, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1070, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1071, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1072, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1073, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1074, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1075, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1076, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1077, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1078, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1079, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1080, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1081, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1082, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1083, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1084, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1085, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1086, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1087, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1088, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1089, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1090, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1091, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1092, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1093, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1094, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1095, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1096, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1097, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
GO
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1098, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1099, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1100, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1101, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1102, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1103, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1104, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1105, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1106, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1107, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1108, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1109, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1110, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1111, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1112, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1113, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1114, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1115, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1116, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1117, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1118, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1119, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1120, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1121, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1122, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1123, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1124, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1125, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1126, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1127, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1128, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1129, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1130, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1131, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1132, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1133, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1134, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1135, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1136, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1137, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1138, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1139, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1140, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1141, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1142, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1143, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1144, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1145, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1146, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1147, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1148, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1149, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1150, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1151, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1152, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1153, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1154, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1155, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1156, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1157, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1158, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1159, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1160, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1161, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1162, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1163, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1164, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1165, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1166, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1167, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1168, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1169, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1170, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1171, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1172, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1173, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1174, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1175, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1176, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1177, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1178, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1179, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1180, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1181, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1182, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1183, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1184, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1185, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1186, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1187, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1188, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1189, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1190, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1191, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1192, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1193, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1194, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1195, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1196, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1197, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
GO
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1198, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1199, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1200, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1201, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1202, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1203, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1204, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1205, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1206, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1207, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1208, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1209, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1210, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1211, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1212, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1213, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1214, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1215, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1216, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1217, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1218, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1219, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1220, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1221, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1222, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1223, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1224, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1225, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1226, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1227, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1228, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1229, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1230, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1231, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1232, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1233, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1234, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1235, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1236, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1237, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1238, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1239, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1240, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1241, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1242, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1243, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1244, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1245, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1246, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1247, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1248, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1249, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1250, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1251, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1252, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1253, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1254, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1255, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1256, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1257, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1258, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1259, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1260, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1261, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1262, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1263, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1264, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1265, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1266, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1267, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1268, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1269, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1270, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1271, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1272, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1273, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1274, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1275, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1276, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1277, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1278, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1279, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1280, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1281, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1282, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1283, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1284, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1285, 4032, N'samarjhaider@gmail.com', 0, N' samarjhaider@gmail.com', N'https://tinyurl.com/2nev2l83')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1286, 4032, N'jafri@gmail.com', 0, N' jafri@gmail.com', N'https://tinyurl.com/2zb6fgs8')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1287, 4032, N'haider@gmail.com', 0, N' haider@gmail.com', N'https://tinyurl.com/2jb6qxlj')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1288, 4032, N'Syed@gmail.com', 0, N' Syed@gmail.com', N'https://tinyurl.com/2foxugnq')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1289, 4032, NULL, 0, N' 33333', N'https://tinyurl.com/2eltbjbt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1290, 4032, NULL, 0, N' 33333', N'https://tinyurl.com/2eltbjbt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1291, 4032, NULL, 0, N' 333', N'https://tinyurl.com/2kxosn9u')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1292, 4032, NULL, 0, N' 33333333', N'https://tinyurl.com/2j2xwooy')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1293, 4032, N' 33333', 0, N' 33333', N'https://tinyurl.com/2eltbjbt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1294, 4032, N' 33333', 0, N' 33333', N'https://tinyurl.com/2eltbjbt')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1295, 4032, N' 333', 0, N' 333', N'https://tinyurl.com/2kxosn9u')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1296, 4032, N' 33333333', 0, N' 33333333', N'https://tinyurl.com/2j2xwooy')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1297, 4032, N'3123123', 0, N'3123123', N'https://tinyurl.com/2kcx9bvj')
GO
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1298, 4032, N'213123', 0, N'213123', N'https://tinyurl.com/2dw2vpuy')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1299, 4032, N'samar@gmail.com', 0, N'samar@gmail.com', N'https://tinyurl.com/2gqlhvrs')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1300, 4032, N'samar@gmail.com', 0, N'samar@gmail.com', N'https://tinyurl.com/2gqlhvrs')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1301, 4032, N'3434', 0, N'3434', N'https://tinyurl.com/2hv3lym7')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1302, 4032, N'3424234', 0, N'3424234', N'https://tinyurl.com/2m7j4qh7')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1303, 4032, N'23243', 0, N'23243', N'https://tinyurl.com/2kesw5bo')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1304, 4032, N'324324', 0, N'324324', N'https://tinyurl.com/2zke86oc')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1305, 4032, N'sama@gmail.com', 0, N'sama@gmail.com', N'https://tinyurl.com/2h4sz3u2')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (1306, 4032, N'sdas@gmail.com', 0, N'sdas@gmail.com', N'https://tinyurl.com/2lnp9jdo')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2009, 6035, N'944434522', 0, N'944434522', N'https://tinyurl.com/2grck63z')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2010, 6035, N'944434522', 0, N'944434522', N'https://tinyurl.com/2grck63z')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2011, 4032, N' 1234543534', 0, N' 1234543534', N'https://tinyurl.com/2jnrg97y')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2012, 4032, N' 3432324234', 0, N' 3432324234', N'https://tinyurl.com/2mo9jlmh')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2013, 6035, N' 9233312304', 0, N' 9233312304', N'https://tinyurl.com/2lu59uqd')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2014, 6035, N' 33442244534', 0, N' 33442244534', N'https://tinyurl.com/2e8xgzb3')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2015, 6035, N' +923331304025', 0, N' +923331304025', N'https://tinyurl.com/2hokpc8s')
INSERT [dbo].[SurveySharedWithCustomers] ([ID], [SurveyID], [Email], [HasSubmitted], [ContactNumber], [UniqueSurveyURL]) VALUES (2016, 6035, N' +92111222333', 0, N' +92111222333', N'https://tinyurl.com/2h5b52ty')
SET IDENTITY_INSERT [dbo].[SurveySharedWithCustomers] OFF
GO
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'ba2a1db8-6247-4b99-8177-94cafa0e0694', N'')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'faea96f9-4bc4-4251-b680-f8b53542aad3', N'1,2')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'32f76aa3-0a2a-4db5-8de7-15b272746fd6', N'')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'd212e26a-307f-42b9-b082-83a4e5f27508', N'')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'43399db0-296a-485e-a968-5f9604637165', N'1')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'07fd16c9-6b8b-4036-8469-626e3f42715f', N'')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'dd40d7d0-b3ed-46fd-9597-86f4ed6060be', N'2')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'e4311ef9-9bac-4bbe-8190-85b8f8ada607', N'')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'7d92d400-3590-450d-885b-44787cafd662', N'1')
INSERT [dbo].[UserDepartments] ([UserID], [DepartmentID]) VALUES (N'26f47846-28a0-419a-9421-89ed4b60c7e0', N'1')
GO
INSERT [dbo].[UserLogs] ([UserID], [UserName], [CreatedOn], [LastLoggedIn]) VALUES (N'26f47846-28a0-419a-9421-89ed4b60c7e0', N'RevHR2', CAST(N'2023-01-03T02:26:46.083' AS DateTime), NULL)
INSERT [dbo].[UserLogs] ([UserID], [UserName], [CreatedOn], [LastLoggedIn]) VALUES (N'292fbc7e-3f93-4e79-b784-787312d92c0f', N'Admin', CAST(N'2022-03-09T19:17:50.037' AS DateTime), CAST(N'2023-01-27T17:12:46.193' AS DateTime))
INSERT [dbo].[UserLogs] ([UserID], [UserName], [CreatedOn], [LastLoggedIn]) VALUES (N'7d92d400-3590-450d-885b-44787cafd662', N'RevHR1', CAST(N'2023-01-03T02:25:45.533' AS DateTime), CAST(N'2023-01-03T02:32:58.023' AS DateTime))
INSERT [dbo].[UserLogs] ([UserID], [UserName], [CreatedOn], [LastLoggedIn]) VALUES (N'dd40d7d0-b3ed-46fd-9597-86f4ed6060be', N'Reviewer', CAST(N'2022-10-06T04:21:58.797' AS DateTime), CAST(N'2023-01-03T02:03:37.200' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserShareSurvey] ON 

INSERT [dbo].[UserShareSurvey] ([Id], [UserId], [SurveyId]) VALUES (2021, N'e4311ef9-9bac-4bbe-8190-85b8f8ada607', 4032)
SET IDENTITY_INSERT [dbo].[UserShareSurvey] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_User_Survey]    Script Date: 31/01/2023 12:30:50 pm ******/
ALTER TABLE [dbo].[UserShareSurvey] ADD  CONSTRAINT [UC_User_Survey] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[SurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Question_Answer]
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_SurveyResponseProfile_Answer] FOREIGN KEY([SurveyResponseProfileId])
REFERENCES [dbo].[SurveyResponseProfile] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_SurveyResponseProfile_Answer]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_ToQuestion] FOREIGN KEY([ParentQuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_ToQuestion]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Question] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Survey_Question]
GO
ALTER TABLE [dbo].[Survey]  WITH CHECK ADD  CONSTRAINT [FK_Survey_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Survey] CHECK CONSTRAINT [FK_Survey_AspNetUsers]
GO
ALTER TABLE [dbo].[UserShareSurvey]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserUserShare_Survey] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[UserShareSurvey] CHECK CONSTRAINT [FK_AspNetUserUserShare_Survey]
GO
ALTER TABLE [dbo].[UserShareSurvey]  WITH CHECK ADD  CONSTRAINT [FK_SurveyUserShare_Survey] FOREIGN KEY([SurveyId])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserShareSurvey] CHECK CONSTRAINT [FK_SurveyUserShare_Survey]
GO
/****** Object:  StoredProcedure [dbo].[DeleteResponsesBySurveyId]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DeleteResponsesBySurveyId]
	@SurveyId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	--drop table #tmpData

	delete from Answer where id in 
	(select a.Id from Answer a 
	inner join SurveyResponseProfile s on a.SurveyResponseProfileId = s.Id 
	where s.SurveyId = @SurveyId);

	delete from SurveyResponseProfile where SurveyId = @SurveyId; 
END
GO
/****** Object:  StoredProcedure [dbo].[GetTopFiveResponsesByUserId]    Script Date: 31/01/2023 12:30:50 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTopFiveResponsesByUserId] 
	@UserId nvarchar(450)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	--drop table #tmpData

	select * into #tmpData from (

	Select srp.* from dbo.SurveyResponseProfile srp 
	inner join dbo.Survey s on srp.SurveyId = s.Id
	left join dbo.UserShareSurvey uss on uss.SurveyId = srp.Id
	where s.UserId = @UserId

	) as x

	Select * from #tmpData
	order by Id desc
	OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY;
END
GO
USE [master]
GO
ALTER DATABASE [SVDB] SET  READ_WRITE 
GO
