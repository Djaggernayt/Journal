USE [master]
GO
/****** Object:  Database [register]    Script Date: 03.07.2022 16:06:38 ******/
CREATE DATABASE [register]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'register', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\register.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'register_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\register_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [register] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [register].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [register] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [register] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [register] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [register] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [register] SET ARITHABORT OFF 
GO
ALTER DATABASE [register] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [register] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [register] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [register] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [register] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [register] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [register] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [register] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [register] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [register] SET  DISABLE_BROKER 
GO
ALTER DATABASE [register] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [register] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [register] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [register] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [register] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [register] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [register] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [register] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [register] SET  MULTI_USER 
GO
ALTER DATABASE [register] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [register] SET DB_CHAINING OFF 
GO
ALTER DATABASE [register] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [register] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [register] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [register] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [register] SET QUERY_STORE = OFF
GO
USE [register]
GO
/****** Object:  User [manager]    Script Date: 03.07.2022 16:06:39 ******/
CREATE USER [manager] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[db_accessadmin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [manager]
GO
/****** Object:  Table [dbo].[Performer]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Performer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Famaly] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Patronymic] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
	[Birthday] [date] NULL,
	[Email] [varchar](50) NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ID position] [int] NOT NULL,
 CONSTRAINT [PK_Performer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[About] [varchar](max) NOT NULL,
	[clip] [varchar](max) NULL,
	[ID performer] [int] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[View]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View]
AS
SELECT dbo.Journal.ID, dbo.Journal.Date, dbo.Journal.About, dbo.Performer.Famaly, dbo.Performer.Name, dbo.Performer.Patronymic
FROM     dbo.Journal INNER JOIN
                  dbo.Performer ON dbo.Journal.[ID performer] = dbo.Performer.ID
GO
/****** Object:  Table [dbo].[Position]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_1]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT dbo.Performer.Famaly, dbo.Performer.Name, dbo.Performer.Patronymic, dbo.Performer.Telephone, dbo.Performer.Birthday, dbo.Performer.Email, dbo.Performer.Login, dbo.Performer.Password, dbo.Position.Name AS Expr1
FROM     dbo.Performer INNER JOIN
                  dbo.Position ON dbo.Performer.[ID position] = dbo.Position.ID
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_Performer] FOREIGN KEY([ID performer])
REFERENCES [dbo].[Performer] ([ID])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_Performer]
GO
ALTER TABLE [dbo].[Performer]  WITH CHECK ADD  CONSTRAINT [FK_Performer_Position] FOREIGN KEY([ID position])
REFERENCES [dbo].[Position] ([ID])
GO
ALTER TABLE [dbo].[Performer] CHECK CONSTRAINT [FK_Performer_Position]
GO
/****** Object:  StoredProcedure [dbo].[journall]    Script Date: 03.07.2022 16:06:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[journall]
	@ID INT,
	@date date,
	@about VARCHAR(max),
	@IDpr INT
AS
BEGIN
	SET @ID=LTRIM(RTRIM(@ID));

INSERT INTO [dbo].[Journal](ID, Date, About, [ID performer])
		VALUES (@ID, @date, @about,@IDpr)
		Select*FROM [dbo].[Journal]
		WHERE ID=@ID
END
GO
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
         Begin Table = "Journal"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 239
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Performer"
            Begin Extent = 
               Top = 7
               Left = 297
               Bottom = 268
               Right = 498
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1884
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View'
GO
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
         Begin Table = "Performer"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 286
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Position"
            Begin Extent = 
               Top = 7
               Left = 297
               Bottom = 126
               Right = 498
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [register] SET  READ_WRITE 
GO
