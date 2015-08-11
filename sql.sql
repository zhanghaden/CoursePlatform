USE [master]
GO
/****** Object:  Database [CoursePlatform]    Script Date: 08/07/2015 12:55:30 ******/
CREATE DATABASE [CoursePlatform] ON  PRIMARY 
( NAME = N'CoursePlatform', FILENAME = N'D:\合作项目\CoursePlatForm\database\CoursePlatform.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoursePlatform_log', FILENAME = N'D:\合作项目\CoursePlatForm\database\CoursePlatform_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoursePlatform] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoursePlatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoursePlatform] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [CoursePlatform] SET ANSI_NULLS OFF
GO
ALTER DATABASE [CoursePlatform] SET ANSI_PADDING OFF
GO
ALTER DATABASE [CoursePlatform] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [CoursePlatform] SET ARITHABORT OFF
GO
ALTER DATABASE [CoursePlatform] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [CoursePlatform] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [CoursePlatform] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [CoursePlatform] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [CoursePlatform] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [CoursePlatform] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [CoursePlatform] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [CoursePlatform] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [CoursePlatform] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [CoursePlatform] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [CoursePlatform] SET  DISABLE_BROKER
GO
ALTER DATABASE [CoursePlatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [CoursePlatform] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [CoursePlatform] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [CoursePlatform] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [CoursePlatform] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [CoursePlatform] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [CoursePlatform] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [CoursePlatform] SET  READ_WRITE
GO
ALTER DATABASE [CoursePlatform] SET RECOVERY FULL
GO
ALTER DATABASE [CoursePlatform] SET  MULTI_USER
GO
ALTER DATABASE [CoursePlatform] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CoursePlatform] SET DB_CHAINING OFF
GO
USE [CoursePlatform]
GO
/****** Object:  Table [dbo].[Tb_StuUser]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_StuUser](
	[StuID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[StuName] [varchar](150) NULL,
	[StuAge] [int] NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CityID] [int] NOT NULL,
	[DetailAddress] [varchar](150) NULL,
	[Birthday] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[IDCard] [varchar](50) NULL,
	[CompanyName] [varchar](150) NULL,
	[PostCode] [varchar](50) NULL,
	[RecordTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tb_StuUser] PRIMARY KEY CLUSTERED 
(
	[StuID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tb_SoftUser]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_SoftUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[PassWord] [varchar](50) NULL,
	[UserType] [int] NOT NULL,
 CONSTRAINT [PK_Tb_SoftUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_SoftUser] ON
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (1, N'admin', N'admin', 1)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (2, N'1', N'1', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (3, N'3', N'3', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (4, N'4', N'4', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (5, N'2', N'2', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (6, N'5', N'5', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (7, N'6', N'6', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (8, N'7', N'7', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (9, N'8', N'8', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (10, N'11', N'11', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (11, N'12', N'12', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (12, N'13', N'13', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (13, N'14', N'14', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (14, N'15', N'15', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (15, N'16', N'16', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (16, N'17', N'17', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (17, N'18', N'18', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (18, N'test', N'test', 0)
INSERT [dbo].[Tb_SoftUser] ([UserID], [UserName], [PassWord], [UserType]) VALUES (19, N'test1', N'test1', 0)
SET IDENTITY_INSERT [dbo].[Tb_SoftUser] OFF
/****** Object:  Table [dbo].[Tb_SoftList]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_SoftList](
	[SoftID] [int] IDENTITY(1,1) NOT NULL,
	[SoftName] [varchar](50) NULL,
	[SoftIntro] [text] NULL,
	[SoftType] [varchar](30) NULL,
	[Contest] [varchar](50) NULL,
	[DownLink] [varchar](150) NULL,
 CONSTRAINT [PK_Tb_SoftList] PRIMARY KEY CLUSTERED 
(
	[SoftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_SoftList] ON
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (1, N'123D Design', N'简单的三维建模软件，容易上手操作，入门级别的三维建模软件。', N'适合小学使用', NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (2, N'123D Catch', N'三维模型的逆向工程，通过全方位照片生成三维模型，再进行修改和加工。', N'适合小学使用', NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (3, N'Sketchbook', N'是一款新一代的自然画图软件，软件界面新颖动人，功能强大，仿手绘效果逼真，笔刷工具分为铅笔，毛笔，马克笔，制图笔，水彩笔，油画笔，喷枪等，自定义选择式界面方式，人性化功能设计，绝对是创意表达的最佳选择。', N'工业设计，创意设计', N'生活创意设计比赛', NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (4, N'Inventor', N'Inventor是一款三维可视化实体模拟软件，可进行三维模型的建立。它包含三维建模、信息管理、协同工作和技术支持等各种特征。', N'工业设计，产品设计，工程制作', N'1、全国工业产品设计技能大赛', NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (5, N'Fusion', N'基于云计算的下一代设计平台，工业设计，结构设计，CAM，3D打印，数据管理，协作，渲染，仿真。自由曲面的工具可以更好的帮助建立不规则的三维模型。', N'工业设计，结构设计，创意设计', NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (6, N'Algor', N'是一款大型通用的有限元分析（CAE）软件。ALGOR拥有强大的线性、非线性分析功能，在结构、热、流场、电场等均有专业的分析模块（流场模块已经移除）。在汽车、电子、航空航天、医学、军事、电力系统、石化、土木工程、微机电系统、日用品生产等诸多领域中均得到了广泛的应用。', N'工程分析', NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (7, N'123D Circuits', N'Circuits是一款电子电路模拟软件。可以在熟悉的面包板视图下工作，也会引导你做出专业的印刷电路板与内置的布局工具。', NULL, NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (8, N'Force Effect', N'Force Effect是一款运动仿真，应力分析的软件。提供直观的操作环境，只需点击设计对象即可对其进行选择、移动、旋转和缩放，同时还可对自由体受力图在概念设计阶段的进行绘图、限定和仿真。', NULL, NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (9, N'123D Make', N'加工工艺的分析及选择，可以通过拼插、折纸、层切等方式进行加工选择，生成加工图，可以进行木工切割或者激光切割，完成模型的制作。', NULL, NULL, NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (10, N'Revit', N'建筑设计使用的软件提供更高质量、更加精确的建筑设计。通过使用专为支持建筑信息模型工作流而构建的工具，可以获取并分析概念，并可通过设计、文档和建筑保持您的视野。强大的建筑设计工具可帮助您捕捉和分析概念，以及保持从设计到建筑的各个阶段的一致性。', N'建筑设计', N'全国大学生可持续建筑设计竞赛', NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (11, N'3ds Max', N'三维动画渲染和制作软件。可完成动画人物及场景的三维建模，并且进行高效的仿真渲染，制作高品质的动画效果', N'动漫设计，动画设计、娱乐传媒', N'全国大学生机械产品数字化设计大赛', NULL)
INSERT [dbo].[Tb_SoftList] ([SoftID], [SoftName], [SoftIntro], [SoftType], [Contest], [DownLink]) VALUES (12, N'Maya', N'3D 建模、动画、特效和高效的渲染功能。很多电影特效都是使用Maya进行建模合成的，Maya能够达到很好的视觉效果。', N'动漫设计，动画设计、娱乐传媒', N'全国大学生机械产品数字化设计大赛', NULL)
SET IDENTITY_INSERT [dbo].[Tb_SoftList] OFF
/****** Object:  Table [dbo].[Tb_SoftCourse]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_SoftCourse](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
	[SoftPlatform] [varchar](100) NULL,
	[StuNum] [int] NULL,
	[ApplyID] [int] NULL,
 CONSTRAINT [PK_Tb_SoftCourse] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_SoftCourse] ON
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (1, N'fgjfg', N'jfg', 9, 5)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (2, N'77', N'77', 77, 5)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (3, N'22', N'2', 2, 6)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (4, N'88', N'88', 88, 8)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (5, N'fdsa', N'fdsa', 22, 9)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (6, N'fdas', N'fdsa', 2, 9)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (7, N'fdsa', N'fdsa', 2, 9)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (12, N'5', N'5', 5, 24)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (13, N'1', N'1', 1, 25)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (14, N'1', N'1', 1, 26)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (15, N'1', N'4', 1, 27)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (16, N'1', N'1', 1, 28)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (17, N'热热热', N'热热热', 2, 27)
INSERT [dbo].[Tb_SoftCourse] ([CourseID], [CourseName], [SoftPlatform], [StuNum], [ApplyID]) VALUES (18, N'3', N'3', 3, 29)
SET IDENTITY_INSERT [dbo].[Tb_SoftCourse] OFF
/****** Object:  Table [dbo].[Tb_ManageUser]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_ManageUser](
	[ManageUserID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DeName] [varchar](150) NULL,
	[Age] [int] NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[CityID] [int] NOT NULL,
	[DetailAddress] [varchar](150) NULL,
	[RecordTime] [datetime] NOT NULL,
	[Birthday] [datetime] NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[IDCard] [varchar](50) NULL,
	[CompanyName] [varchar](150) NULL,
	[PostCode] [varchar](50) NULL,
	[UserType] [int] NOT NULL,
 CONSTRAINT [PK_Tb_User] PRIMARY KEY CLUSTERED 
(
	[ManageUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'课程设计者1，教师0，管理员2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tb_ManageUser', @level2type=N'COLUMN',@level2name=N'UserType'
GO
INSERT [dbo].[Tb_ManageUser] ([ManageUserID], [DeName], [Age], [Account], [Password], [CityID], [DetailAddress], [RecordTime], [Birthday], [Email], [Phone], [IDCard], [CompanyName], [PostCode], [UserType]) VALUES (N'8cb08fb6-c5d2-4368-ae90-74be6a7f973e', NULL, NULL, N'1', N'1', 1, NULL, CAST(0x0000A4EB017A5F70 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 0)
/****** Object:  Table [dbo].[Tb_City]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_City](
	[CityID] [float] NOT NULL,
	[CityName] [nvarchar](255) NULL,
	[ParentID] [float] NULL,
	[Level] [float] NULL,
	[Upid] [nvarchar](255) NULL,
	[ParentPath] [nvarchar](255) NULL,
	[Note] [nvarchar](255) NULL,
	[Area] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tb_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'华东1
华南2
西南3
华北4
华中5东北6西北7海外0其他0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tb_City', @level2type=N'COLUMN',@level2name=N'Area'
GO
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (1, N'北京市', 0, 1, NULL, N'0', NULL, N'4')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (2, N'天津市', 0, 1, NULL, N'0', NULL, N'4')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (3, N'河北省', 0, 1, NULL, N'0', NULL, N'4')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (4, N'山西省', 0, 1, NULL, N'0', NULL, N'4')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (5, N'内蒙古自治区', 0, 1, NULL, N'0', NULL, N'4')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (6, N'辽宁省', 0, 1, NULL, N'0', NULL, N'6')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (7, N'吉林省', 0, 1, NULL, N'0', NULL, N'6')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (8, N'黑龙江省', 0, 1, NULL, N'0', NULL, N'6')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (9, N'上海市', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (10, N'江苏省', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (11, N'浙江省', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (12, N'安徽省', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (13, N'福建省', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (14, N'江西省', 0, 1, NULL, N'0', NULL, N'5')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (15, N'山东省', 0, 1, NULL, N'0', NULL, N'1')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (16, N'河南省', 0, 1, NULL, N'0', NULL, N'5')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (17, N'湖北省', 0, 1, NULL, N'0', NULL, N'5')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (18, N'湖南省', 0, 1, NULL, N'0', NULL, N'5')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (19, N'广东省', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (20, N'广西壮族自治区', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (21, N'海南省', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (22, N'重庆市', 0, 1, NULL, N'0', NULL, N'3')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (23, N'四川省', 0, 1, NULL, N'0', NULL, N'3')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (24, N'贵州省', 0, 1, NULL, N'0', NULL, N'3')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (25, N'云南省', 0, 1, NULL, N'0', NULL, N'3')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (26, N'西藏自治区', 0, 1, NULL, N'0', NULL, N'3')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (27, N'陕西省', 0, 1, NULL, N'0', NULL, N'7')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (28, N'甘肃省', 0, 1, NULL, N'0', NULL, N'7')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (29, N'青海省', 0, 1, NULL, N'0', NULL, N'7')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (30, N'宁夏回族自治区', 0, 1, NULL, N'0', NULL, N'7')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (31, N'新疆维吾尔自治区', 0, 1, NULL, N'0', NULL, N'7')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (32, N'台湾省', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (33, N'香港特别行政区', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (34, N'澳门特别行政区', 0, 1, NULL, N'0', NULL, N'2')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (35, N'海外', 0, 1, NULL, N'0', NULL, N'0')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (36, N'其他', 0, 1, NULL, N'0', NULL, N'0')
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (37, N'东城区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (38, N'西城区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (39, N'崇文区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (40, N'宣武区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (41, N'朝阳区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (42, N'丰台区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (43, N'石景山区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (44, N'海淀区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (45, N'门头沟区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (46, N'房山区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (47, N'通州区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (48, N'顺义区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (49, N'昌平区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (50, N'大兴区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (51, N'怀柔区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (52, N'平谷区', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (53, N'密云县', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (54, N'延庆县', 1, 2, NULL, N'1', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (55, N'和平区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (56, N'河东区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (57, N'河西区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (58, N'南开区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (59, N'河北区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (60, N'红桥区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (61, N'塘沽区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (62, N'汉沽区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (63, N'大港区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (64, N'东丽区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (65, N'西青区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (66, N'津南区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (67, N'北辰区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (68, N'武清区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (69, N'宝坻区', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (70, N'宁河县', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (71, N'静海县', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (72, N'蓟县', 2, 2, NULL, N'2', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (73, N'石家庄市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (74, N'唐山市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (75, N'秦皇岛市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (76, N'邯郸市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (77, N'邢台市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (78, N'保定市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (79, N'张家口市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (80, N'承德市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (81, N'衡水市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (82, N'廊坊市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (83, N'沧州市', 3, 2, NULL, N'3', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (84, N'太原市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (85, N'大同市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (86, N'阳泉市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (87, N'长治市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (88, N'晋城市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (89, N'朔州市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (90, N'晋中市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (91, N'运城市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (92, N'忻州市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (93, N'临汾市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (94, N'吕梁市', 4, 2, NULL, N'4', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (95, N'呼和浩特市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (96, N'包头市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (97, N'乌海市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (98, N'赤峰市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (99, N'通辽市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (100, N'鄂尔多斯市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (101, N'呼伦贝尔市', 5, 2, NULL, N'5', NULL, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (102, N'巴彦淖尔市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (103, N'乌兰察布市', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (104, N'兴安盟', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (105, N'锡林郭勒盟', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (106, N'阿拉善盟', 5, 2, NULL, N'5', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (107, N'沈阳市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (108, N'大连市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (109, N'鞍山市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (110, N'抚顺市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (111, N'本溪市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (112, N'丹东市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (113, N'锦州市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (114, N'营口市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (115, N'阜新市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (116, N'辽阳市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (117, N'盘锦市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (118, N'铁岭市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (119, N'朝阳市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (120, N'葫芦岛市', 6, 2, NULL, N'6', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (121, N'长春市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (122, N'吉林市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (123, N'四平市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (124, N'辽源市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (125, N'通化市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (126, N'白山市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (127, N'松原市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (128, N'白城市', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (129, N'延边朝鲜族自治州', 7, 2, NULL, N'7', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (130, N'哈尔滨市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (131, N'齐齐哈尔市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (132, N'鸡西市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (133, N'鹤岗市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (134, N'双鸭山市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (135, N'大庆市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (136, N'伊春市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (137, N'佳木斯市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (138, N'七台河市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (139, N'牡丹江市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (140, N'黑河市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (141, N'绥化市', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (142, N'大兴安岭地区', 8, 2, NULL, N'8', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (143, N'黄浦区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (144, N'卢湾区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (145, N'徐汇区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (146, N'长宁区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (147, N'静安区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (148, N'普陀区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (149, N'闸北区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (150, N'虹口区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (151, N'杨浦区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (152, N'闵行区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (153, N'宝山区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (154, N'嘉定区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (155, N'浦东新区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (156, N'金山区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (157, N'松江区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (158, N'青浦区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (159, N'南汇区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (160, N'奉贤区', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (161, N'崇明县', 9, 2, NULL, N'9', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (162, N'南京市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (163, N'无锡市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (164, N'徐州市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (165, N'常州市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (166, N'苏州市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (167, N'南通市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (168, N'连云港市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (169, N'淮安市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (170, N'盐城市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (171, N'扬州市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (172, N'镇江市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (173, N'泰州市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (174, N'宿迁市', 10, 2, NULL, N'10', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (175, N'杭州市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (176, N'宁波市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (177, N'温州市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (178, N'嘉兴市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (179, N'湖州市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (180, N'绍兴市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (181, N'舟山市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (182, N'衢州市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (183, N'金华市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (184, N'台州市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (185, N'丽水市', 11, 2, NULL, N'11', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (374, N'奉节县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (375, N'巫山县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (376, N'巫溪县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (377, N'石柱土家族自治县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (378, N'秀山土家族苗族自治县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (379, N'酉阳土家族苗族自治县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (380, N'彭水苗族土家族自治县', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (381, N'江津市', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (382, N'合川市', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (383, N'永川市', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (384, N'南川市', 22, 2, NULL, N'22', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (385, N'成都市', 23, 2, NULL, N'23', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (386, N'自贡市', 23, 2, NULL, N'23', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (387, N'攀枝花市', 23, 2, NULL, N'23', NULL, NULL)
INSERT [dbo].[Tb_City] ([CityID], [CityName], [ParentID], [Level], [Upid], [ParentPath], [Note], [Area]) VALUES (388, N'泸州市', 23, 2, NULL, N'23', NULL, NULL)
/****** Object:  Table [dbo].[Tb_ApplyTable]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_ApplyTable](
	[ApplyID] [int] IDENTITY(1,1) NOT NULL,
	[UnitNameCH] [varchar](50) NULL,
	[UnitNameEN] [varchar](50) NULL,
	[ChargePerson] [varchar](30) NULL,
	[ContactPerson] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[UnitAddress] [varchar](100) NULL,
	[ZipCode] [varchar](50) NULL,
	[UnitIntro] [text] NULL,
	[TeacherNum] [int] NULL,
	[StuNum] [int] NULL,
	[Gradu2015Num] [int] NULL,
	[SeniorTitleNum] [int] NULL,
	[IntermediateTitleNum] [int] NULL,
	[OtherTitleNum] [int] NULL,
	[TechTeacherNum] [int] NULL,
	[AuthTechTeacherNum] [int] NULL,
	[EngineRoomArea] [float] NULL,
	[ComputerNumConfig] [varchar](100) NULL,
	[RecordTime] [date] NULL,
	[UserID] [int] NULL,
	[IsPass] [int] NOT NULL,
 CONSTRAINT [PK_ApplyTable] PRIMARY KEY CLUSTERED 
(
	[ApplyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_ApplyTable] ON
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (1, N'fdasf', N'fdsa', N'fds', N'fdsa', N'fdsa', N'31231', N'fdsafas', N'fdsafdsa', N'fdasf', 31312, 3213, 321, 321, 321, 312, 321, 3213, 321321, N'fdas', CAST(0x50370B00 AS Date), 3, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (2, N'fdsa', N'fdsa', N'fds', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', 11, 11, 11, 11, 11, 11, 11, 11, 1231, N'312', CAST(0x403A0B00 AS Date), 3, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (3, N'fdsa', N'fds', N'fds', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsafs', 21, 21, 21, 312, 321, 321, 319, 321, 321, N'312', CAST(0x413A0B00 AS Date), 3, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (4, N'fdsa', N'fds', N'55', N'55', N'55', N'5', N'5', N'5', N'5', 5, 5, 5, 5, 5, 5, 5, 5, 5, N'5', CAST(0x413A0B00 AS Date), 3, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (5, N'9', N'9', N'9', N'9', N'9', N'9', N'9', N'9', N'9', 9, 9, 9, 7, 9, 9, 9, 9, 9, N'9', CAST(0x413A0B00 AS Date), 4, 1)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (6, N'fdas', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x413A0B00 AS Date), 2, 1)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (8, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x413A0B00 AS Date), 5, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (9, N'gg', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', N'fdsa', 22, 22, 2, 3, 4, 5, 22, 22, 22, N'22', CAST(0x413A0B00 AS Date), 6, 1)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (10, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'fdsaf', 23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1212, N'213', CAST(0x413A0B00 AS Date), 7, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (15, N'2222', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2222, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x453A0B00 AS Date), 9, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (16, N'222', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 222, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x453A0B00 AS Date), 10, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (24, N'5', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'222', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 11, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (25, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 12, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (26, N'11', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 13, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (27, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 14, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (28, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 15, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (29, N'fdsafd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1122, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 16, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (30, N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 22, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x463A0B00 AS Date), 17, 0)
INSERT [dbo].[Tb_ApplyTable] ([ApplyID], [UnitNameCH], [UnitNameEN], [ChargePerson], [ContactPerson], [Email], [Phone], [UnitAddress], [ZipCode], [UnitIntro], [TeacherNum], [StuNum], [Gradu2015Num], [SeniorTitleNum], [IntermediateTitleNum], [OtherTitleNum], [TechTeacherNum], [AuthTechTeacherNum], [EngineRoomArea], [ComputerNumConfig], [RecordTime], [UserID], [IsPass]) VALUES (31, N'黄浦区小学', NULL, N'张先生', N'李先生', N'1@qq.com', N'158', N'上海', NULL, NULL, 200, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x483A0B00 AS Date), 19, 0)
SET IDENTITY_INSERT [dbo].[Tb_ApplyTable] OFF
/****** Object:  Table [dbo].[Tb_ApplySoftList]    Script Date: 08/07/2015 12:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tb_ApplySoftList](
	[ApplySoftID] [int] IDENTITY(1,1) NOT NULL,
	[SoftCourseName] [varchar](100) NULL,
	[TrainNumPerYear] [int] NULL,
	[ApplyNum] [int] NULL,
	[ApplyID] [int] NULL,
	[SoftID] [int] NULL,
 CONSTRAINT [PK_Tb_ApplySoftList] PRIMARY KEY CLUSTERED 
(
	[ApplySoftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_ApplySoftList] ON
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (5, N'fdsafasd', 121, 321, 3, 2)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (6, N'fdsafasd', 321, 321, 3, 3)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (7, N'fd', 12, 2, 4, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (8, N'4', 4, 4, 4, 2)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (11, N'kjgk', 8, 8, 5, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (12, N'f', 2, 2, 6, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (13, N'77', 77, 77, 8, 3)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (14, N'fdsfdas', 221, 2, 9, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (15, N'fdsa', 22, 2, 9, 2)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (16, N'fdaf', 23, 2, 15, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (18, N'111', 11, 11, 16, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (31, N'1', 1, 1, 25, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (32, N'1', 1, 1, 26, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (34, N'1', 1, 1, 28, 1)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (35, N'发 12', 11, 1, 27, 2)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (36, N'嘎嘎嘎', 1, 1, 27, 3)
INSERT [dbo].[Tb_ApplySoftList] ([ApplySoftID], [SoftCourseName], [TrainNumPerYear], [ApplyNum], [ApplyID], [SoftID]) VALUES (37, N'44', 33, 33, 29, 1)
SET IDENTITY_INSERT [dbo].[Tb_ApplySoftList] OFF
/****** Object:  Default [DF_Tb_StuUser_StuID]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_StuUser] ADD  CONSTRAINT [DF_Tb_StuUser_StuID]  DEFAULT (newid()) FOR [StuID]
GO
/****** Object:  Default [DF_Tb_StuUser_RecordTime]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_StuUser] ADD  CONSTRAINT [DF_Tb_StuUser_RecordTime]  DEFAULT (getdate()) FOR [RecordTime]
GO
/****** Object:  Default [DF_Tb_SoftUser_UserType]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_SoftUser] ADD  CONSTRAINT [DF_Tb_SoftUser_UserType]  DEFAULT ((0)) FOR [UserType]
GO
/****** Object:  Default [DF_Tb_Designer_DesignerID]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_ManageUser] ADD  CONSTRAINT [DF_Tb_Designer_DesignerID]  DEFAULT (newid()) FOR [ManageUserID]
GO
/****** Object:  Default [DF_Tb_User_RecordTime]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_ManageUser] ADD  CONSTRAINT [DF_Tb_User_RecordTime]  DEFAULT (getdate()) FOR [RecordTime]
GO
/****** Object:  Default [DF_Tb_User_UserType]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_ManageUser] ADD  CONSTRAINT [DF_Tb_User_UserType]  DEFAULT ((0)) FOR [UserType]
GO
/****** Object:  Default [DF_Tb_ApplyTable_IsPass]    Script Date: 08/07/2015 12:55:31 ******/
ALTER TABLE [dbo].[Tb_ApplyTable] ADD  CONSTRAINT [DF_Tb_ApplyTable_IsPass]  DEFAULT ((0)) FOR [IsPass]
GO
