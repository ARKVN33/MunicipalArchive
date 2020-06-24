USE [master]
ƒ
/****** Object:  Database [dbMunicipalArchive]    Script Date: 7/3/2019 2:23:43 AM ******/
CREATE DATABASE [dbMunicipalArchive]
ƒ
ALTER DATABASE [dbMunicipalArchive] SET COMPATIBILITY_LEVEL = 120
ƒ
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbMunicipalArchive].[dbo].[sp_fulltext_database] @action = 'enable'
end
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ANSI_NULL_DEFAULT OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ANSI_NULLS OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ANSI_PADDING OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ANSI_WARNINGS OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ARITHABORT OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET AUTO_CLOSE OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET AUTO_SHRINK OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET AUTO_UPDATE_STATISTICS ON 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET CURSOR_CLOSE_ON_COMMIT OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET CURSOR_DEFAULT  GLOBAL 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET CONCAT_NULL_YIELDS_NULL OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET NUMERIC_ROUNDABORT OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET QUOTED_IDENTIFIER OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET RECURSIVE_TRIGGERS OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET  DISABLE_BROKER 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET DATE_CORRELATION_OPTIMIZATION OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET TRUSTWORTHY OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET ALLOW_SNAPSHOT_ISOLATION OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET PARAMETERIZATION SIMPLE 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET READ_COMMITTED_SNAPSHOT OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET HONOR_BROKER_PRIORITY OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET RECOVERY FULL 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET  MULTI_USER 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET PAGE_VERIFY CHECKSUM  
ƒ
ALTER DATABASE [dbMunicipalArchive] SET DB_CHAINING OFF 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET TARGET_RECOVERY_TIME = 0 SECONDS 
ƒ
ALTER DATABASE [dbMunicipalArchive] SET DELAYED_DURABILITY = DISABLED 
ƒ
EXEC sys.sp_db_vardecimal_storage_format N'dbMunicipalArchive', N'ON'
ƒ
USE [dbMunicipalArchive]
ƒ
/****** Object:  Table [dbo].[tblAppVersion]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblAppVersion](
	[Id] [tinyint] NOT NULL,
	[AppVersion] [nvarchar](7) NULL,
 CONSTRAINT [PK_tblAppVersion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFile]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MainId] [int] NULL,
	[Marlik] [int] NULL,
	[FileType_Id] [tinyint] NULL,
	[Violation_Id] [tinyint] NULL,
	[FileNum] [int] NULL,
	[FileYear] [smallint] NULL,
	[PermitNum] [int] NULL,
	[PermitYear] [smallint] NULL,
	[Mantaghe] [int] NULL,
	[Nahie] [int] NULL,
	[Mahaleh] [int] NULL,
	[Block] [int] NULL,
	[Melk] [int] NULL,
	[Radif] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[VoteNum] [nvarchar](10) NULL,
	[InArchives] [bit] NULL,
	[Separation] [int] NULL,
	[Aggregation] [int] NULL,
	[DateInsert] [nvarchar](10) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_tblFile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFilePerson]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFilePerson](
	[File_Id] [int] NOT NULL,
	[Person_Id] [int] NOT NULL,
 CONSTRAINT [PK_tblFilePerson] PRIMARY KEY CLUSTERED 
(
	[File_Id] ASC,
	[Person_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFilePlaque]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFilePlaque](
	[File_Id] [int] NOT NULL,
	[Plaque_Id] [int] NOT NULL,
 CONSTRAINT [PK_tblFilePlaque] PRIMARY KEY CLUSTERED 
(
	[File_Id] ASC,
	[Plaque_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblFileType]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblFileType](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[FileType] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblFileType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblLicense]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblLicense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppLicense] [nvarchar](40) NULL,
 CONSTRAINT [PK__tblLicen__3214EC07172ACD18] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblPerson]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[Code] [nvarchar](10) NULL,
	[Birthday] [nvarchar](10) NULL,
	[Sex] [tinyint] NULL,
	[Mobile] [nvarchar](11) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_tblPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblPlaque]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblPlaque](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Main] [int] NULL,
	[Secondary] [int] NULL,
	[Part] [int] NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblPlaque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblPostType]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblPostType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PostType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSecurityAccess]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSecurityAccess](
	[Id] [int] NOT NULL,
	[Time] [nvarchar](19) NULL,
	[Counter] [nvarchar](1) NULL,
 CONSTRAINT [PK_tblSecurityAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSecurityQuestion]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSecurityQuestion](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[SecurityQuestion] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblSecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblSundry]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblSundry](
	[Id] [int] NOT NULL,
	[RegisteredAdminPassword] [bit] NULL,
 CONSTRAINT [PK_tblSundry] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblUser]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_PostType_Id] [tinyint] NULL,
	[User_SecurityQuestion_Id] [tinyint] NULL,
	[UserFirstName] [nvarchar](50) NULL,
	[UserLastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [nvarchar](60) NULL,
	[UserMobileNumber] [nvarchar](11) NULL,
	[UserEmail] [nvarchar](200) NULL,
	[UserAnswer] [nvarchar](100) NULL,
	[UserRegistrationDate] [nvarchar](19) NULL,
	[UserImage] [nvarchar](max) NULL,
	[UserDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

ƒ
/****** Object:  Table [dbo].[tblViolation]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE TABLE [dbo].[tblViolation](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Violation] [nvarchar](200) NULL,
 CONSTRAINT [PK_tblViolation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ƒ
/****** Object:  View [dbo].[viewAll]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE VIEW [dbo].[viewAll]
AS
SELECT        dbo.tblPerson.Id AS Person_Id, dbo.tblFile.Id, dbo.tblFile.MainId, dbo.tblFile.Marlik, dbo.tblFile.FileType_Id, dbo.tblFile.Violation_Id, dbo.tblFile.FileNum, dbo.tblFile.FileYear, dbo.tblFile.PermitNum, dbo.tblFile.PermitYear, 
                         dbo.tblFile.Mantaghe, dbo.tblFile.Nahie, dbo.tblFile.Mahaleh, dbo.tblFile.Block, dbo.tblFile.Melk, dbo.tblFile.Radif, dbo.tblFile.Address, dbo.tblFile.PostalCode, dbo.tblFile.VoteNum, dbo.tblFile.InArchives, dbo.tblFile.Separation, 
                         dbo.tblFile.DateInsert, dbo.tblFile.Aggregation, REPLACE(dbo.tblFile.Description, CHAR(13) + CHAR(10), ' ') AS FileDescription, dbo.tblPerson.Name + ' ' + dbo.tblPerson.Family AS FullName, dbo.tblPerson.FatherName, 
                         dbo.tblPerson.Code, dbo.tblPerson.Birthday, dbo.tblPerson.Sex, dbo.tblPerson.Mobile, dbo.tblPerson.Description AS PersonDescription, dbo.tblFileType.FileType, dbo.tblViolation.Violation, dbo.tblFilePlaque.Plaque_Id, 
                         dbo.tblPlaque.Description AS PlaqueDescription, ISNULL(CASE WHEN FileYear IS NOT NULL AND (FileNum IS NOT NULL) THEN CAST(FileYear AS NVARCHAR(9)) + '/' ELSE CAST(FileYear AS NVARCHAR(9)) END, '') 
                         + ISNULL(CASE WHEN FileNum IS NOT NULL THEN CAST(FileNum AS NVARCHAR(9)) END, '') AS FileNumber, ISNULL(CASE WHEN PermitYear IS NOT NULL AND (PermitNum IS NOT NULL) 
                         THEN CAST(PermitYear AS NVARCHAR(9)) + '/' ELSE CAST(PermitYear AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN PermitNum IS NOT NULL THEN CAST(PermitNum AS NVARCHAR(9)) END, '') AS PermitNumber, 
                         ISNULL(CASE WHEN Mantaghe IS NOT NULL AND (Nahie IS NOT NULL OR
                         Mahaleh IS NOT NULL OR
                         Block IS NOT NULL OR
                         Melk IS NOT NULL OR
                         Radif IS NOT NULL) THEN CAST(Mantaghe AS NVARCHAR(9)) + '/' ELSE CAST(Mantaghe AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Nahie IS NOT NULL AND (Mahaleh IS NOT NULL OR
                         Block IS NOT NULL OR
                         Melk IS NOT NULL OR
                         Radif IS NOT NULL) THEN CAST(Nahie AS NVARCHAR(9)) + '/' ELSE CAST(Nahie AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Mahaleh IS NOT NULL AND (Block IS NOT NULL OR
                         Melk IS NOT NULL OR
                         Radif IS NOT NULL) THEN CAST(Mahaleh AS NVARCHAR(9)) + '/' ELSE CAST(Mahaleh AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Block IS NOT NULL AND (Melk IS NOT NULL OR
                         Radif IS NOT NULL) THEN CAST(Block AS NVARCHAR(9)) + '/' ELSE CAST(Block AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Melk IS NOT NULL AND (Radif IS NOT NULL) THEN CAST(Melk AS NVARCHAR(9)) 
                         + '/' ELSE CAST(Melk AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Radif IS NOT NULL THEN CAST(Radif AS NVARCHAR(9)) END, '') AS Reconstruction, ISNULL(CASE WHEN Main IS NOT NULL AND 
                         (Secondary IS NOT NULL OR
                         Part IS NOT NULL) THEN CAST(Main AS NVARCHAR(9)) + '/' ELSE CAST(Main AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Secondary IS NOT NULL AND (Part IS NOT NULL) THEN CAST(Secondary AS NVARCHAR(9)) 
                         + '/' ELSE CAST(Secondary AS NVARCHAR(9)) END, '') + ISNULL(CASE WHEN Part IS NOT NULL THEN CAST(Part AS NVARCHAR(9)) END, '') AS PlaqueNum
FROM            dbo.tblFilePerson FULL OUTER JOIN
                         dbo.tblFile ON dbo.tblFilePerson.File_Id = dbo.tblFile.Id FULL OUTER JOIN
                         dbo.tblPerson ON dbo.tblFilePerson.Person_Id = dbo.tblPerson.Id LEFT OUTER JOIN
                         dbo.tblFileType ON dbo.tblFile.FileType_Id = dbo.tblFileType.Id LEFT OUTER JOIN
                         dbo.tblViolation ON dbo.tblFile.Violation_Id = dbo.tblViolation.Id LEFT OUTER JOIN
                         dbo.tblFilePlaque ON dbo.tblFile.Id = dbo.tblFilePlaque.File_Id LEFT OUTER JOIN
                         dbo.tblPlaque ON dbo.tblFilePlaque.Plaque_Id = dbo.tblPlaque.Id
WHERE        (dbo.tblFile.Id IS NOT NULL)

ƒ
/****** Object:  View [dbo].[viewFilePerson]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE VIEW [dbo].[viewFilePerson]
AS
SELECT        dbo.tblFilePerson.File_Id, dbo.tblFilePerson.Person_Id, dbo.tblPerson.Name, dbo.tblPerson.Family, dbo.tblPerson.FatherName, dbo.tblPerson.Code
FROM            dbo.tblFilePerson INNER JOIN
                         dbo.tblPerson ON dbo.tblFilePerson.Person_Id = dbo.tblPerson.Id

ƒ
/****** Object:  View [dbo].[viewFilePlaque]    Script Date: 7/3/2019 2:23:43 AM ******/
SET ANSI_NULLS ON
ƒ
SET QUOTED_IDENTIFIER ON
ƒ
CREATE VIEW [dbo].[viewFilePlaque]
AS
SELECT        dbo.tblFilePlaque.File_Id, dbo.tblPlaque.Id, dbo.tblPlaque.Main, dbo.tblPlaque.Secondary, dbo.tblPlaque.Part, dbo.tblPlaque.Description, dbo.tblFilePlaque.Plaque_Id
FROM            dbo.tblFilePlaque INNER JOIN
                         dbo.tblPlaque ON dbo.tblFilePlaque.Plaque_Id = dbo.tblPlaque.Id
ƒ
INSERT [dbo].[tblAppVersion] ([Id], [AppVersion]) VALUES (1, NULL)
ƒ
SET IDENTITY_INSERT [dbo].[tblPostType] ON 
ƒ
INSERT [dbo].[tblPostType] ([Id], [PostType]) VALUES (1, N'مدیریت')
ƒ
SET IDENTITY_INSERT [dbo].[tblPostType] OFF
ƒ

SET IDENTITY_INSERT [dbo].[tblSecurityQuestion] ON 
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (1, N'نام اولین معلم شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (2, N'نام گل مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (3, N'رنگ مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (4, N'نام فیلم مورد علاقه شما چیست؟')
ƒ
INSERT [dbo].[tblSecurityQuestion] ([Id], [SecurityQuestion]) VALUES (5, N'مکان مورد علاقه شما کجاست؟')
ƒ
SET IDENTITY_INSERT [dbo].[tblSecurityQuestion] OFF
ƒ

ƒ
SET IDENTITY_INSERT [dbo].[tblViolation] ON 

ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (1, N'تخلف بنای فاقد پروانه در کمیسیون ماده ۱۰۰')
ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (2, N'تخلف عدم احداث پارکینگ در کمیسیون ماده ۱۰۰')
ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (3, N'تخلف احداث بنا مغایر با کاربری ساختمان در کمیسیون ماده ۱۰۰')
ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (4, N'عدم استحکام بنا در کمیسیون ماده ۱۰۰')
ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (5, N'تجاوز به معابر شهری و عدم رعایت اصول فنی')
ƒ
INSERT [dbo].[tblViolation] ([Id], [Violation]) VALUES (6, N'تخلف تراکم ساختمانی')
ƒ
SET IDENTITY_INSERT [dbo].[tblViolation] OFF
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblFilePerson"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblFile"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPerson"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblFileType"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 102
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblViolation"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 102
               Right = 1040
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblFilePlaque"
            Begin Extent = 
               Top = 6
               Left = 1078
               Bottom = 102
               Right = 1248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPlaque"
            Begin Extent = 
               Top = 6
               Left = 1286
               Bottom = 136
               Right = 1456
            End
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewAll'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewAll'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewAll'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblFilePerson"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPerson"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewFilePerson'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewFilePerson'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblFilePlaque"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPlaque"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewFilePlaque'
ƒ
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewFilePlaque'
ƒ
USE [master]
ƒ
ALTER DATABASE [dbMunicipalArchive] SET  READ_WRITE 
ƒ
