USE [master]
GO
/****** Object:  Database [AracServisTakip]    Script Date: 28.12.2020 12:03:05 ******/
CREATE DATABASE [AracServisTakip]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AracServisTakip', FILENAME = N'C:\DATA\MSSQL14.BT\MSSQL\DATA\AracServisTakip.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AracServisTakip_log', FILENAME = N'C:\DATA\MSSQL14.BT\MSSQL\DATA\AracServisTakip_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AracServisTakip].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AracServisTakip] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AracServisTakip] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AracServisTakip] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AracServisTakip] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AracServisTakip] SET ARITHABORT OFF 
GO
ALTER DATABASE [AracServisTakip] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AracServisTakip] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AracServisTakip] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AracServisTakip] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AracServisTakip] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AracServisTakip] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AracServisTakip] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AracServisTakip] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AracServisTakip] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AracServisTakip] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AracServisTakip] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AracServisTakip] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AracServisTakip] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AracServisTakip] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AracServisTakip] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AracServisTakip] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AracServisTakip] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AracServisTakip] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AracServisTakip] SET  MULTI_USER 
GO
ALTER DATABASE [AracServisTakip] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AracServisTakip] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AracServisTakip] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AracServisTakip] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AracServisTakip] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AracServisTakip]
GO
/****** Object:  Table [dbo].[Firma]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Firma](
	[FirmaId] [tinyint] IDENTITY(1,1) NOT NULL,
	[FirmaAdi] [varchar](100) NULL,
	[FirmaAdres] [varchar](100) NULL,
	[FirmaEPosta] [varchar](50) NULL,
	[FirmaWebAdres] [varchar](50) NULL,
	[FirmaTelefonNo] [varchar](50) NULL,
	[FirmaFaksNo] [varchar](50) NULL,
 CONSTRAINT [PK_Firma] PRIMARY KEY CLUSTERED 
(
	[FirmaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[kullaniciAdi] [nvarchar](50) NULL,
	[kullaniciSifre] [nvarchar](50) NULL,
	[durum] [bit] NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriId] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAdSoyad] [nvarchar](50) NULL,
	[MusteriTelefon] [nvarchar](20) NULL,
	[AracPlakaNo] [nvarchar](50) NULL,
	[AracMarkaModel] [nvarchar](100) NULL,
	[AracSasiMotorNo] [nvarchar](100) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServisIslemleri]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServisIslemleri](
	[ServisId] [int] IDENTITY(1,1) NOT NULL,
	[AraciGetiren] [nvarchar](50) NULL,
	[AracTeslimTarihi] [date] NULL,
	[ServisPersonelId] [smallint] NULL,
	[MusteriId] [int] NULL,
	[FirmaId] [smallint] NULL,
	[MusteriSikayetTalepAciklamasi] [nvarchar](100) NULL,
	[KayitZamani] [datetime] NULL,
	[Tarih] [date] NULL,
	[IskontoOrani] [tinyint] NULL,
 CONSTRAINT [PK_ServisIslemleri] PRIMARY KEY CLUSTERED 
(
	[ServisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServisIslemleriSatir]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServisIslemleriSatir](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StokId] [int] NULL,
	[ServisId] [int] NULL,
	[malzemeKodu] [nvarchar](50) NULL,
	[malzemeAciklama] [nvarchar](100) NULL,
	[Adet] [decimal](18, 2) NULL,
	[BirimFiyat] [decimal](18, 2) NULL,
	[Tutar] [decimal](18, 2) NULL,
	[KayitZamani] [datetime] NULL,
 CONSTRAINT [PK_ServisIslemleriSatir] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServisPersonel]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServisPersonel](
	[ServisPersonelId] [int] IDENTITY(1,1) NOT NULL,
	[PersonelAdSoyad] [varchar](50) NULL,
	[PersonelTelefon] [varchar](50) NULL,
 CONSTRAINT [PK_ServisPersonel] PRIMARY KEY CLUSTERED 
(
	[ServisPersonelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StokKarti]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StokKarti](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StokKodu] [nvarchar](50) NULL,
	[StokAdi] [nvarchar](50) NULL,
	[Birim] [nvarchar](10) NULL,
	[Raf] [nvarchar](10) NULL,
	[MinStok] [decimal](18, 2) NULL,
	[MaksStok] [decimal](18, 2) NULL,
	[TeminSuresi] [int] NULL,
	[AlimFiyati] [decimal](18, 2) NULL,
	[SatisFiyati] [decimal](18, 2) NULL,
	[OzelKod1] [nvarchar](10) NULL,
	[OzelKod2] [nvarchar](10) NULL,
	[Aciklama] [nvarchar](500) NULL,
	[Barkod] [nvarchar](11) NULL,
	[statu] [nvarchar](20) NULL,
 CONSTRAINT [PK_StokKarti] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[AnaServisListesi]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AnaServisListesi]
AS
SELECT        TOP (100) PERCENT dbo.ServisIslemleri.ServisId, dbo.ServisIslemleri.Tarih, dbo.ServisIslemleri.AraciGetiren AS [Aracı Getiren], dbo.ServisIslemleri.AracTeslimTarihi AS [Teslim Tarihi], m.MusteriAdSoyad AS [Ad Soyad], 
                         m.MusteriTelefon AS Telefon, m.AracPlakaNo AS Plaka, m.AracMarkaModel AS MarkaModel, m.AracSasiMotorNo AS SasiMotorNo, sp.PersonelAdSoyad AS Personel
FROM            dbo.ServisIslemleri LEFT OUTER JOIN
                         dbo.ServisPersonel AS sp ON dbo.ServisIslemleri.ServisPersonelId = sp.ServisPersonelId LEFT OUTER JOIN
                         dbo.Musteri AS m ON dbo.ServisIslemleri.MusteriId = m.MusteriId
ORDER BY dbo.ServisIslemleri.Tarih DESC
GO
/****** Object:  View [dbo].[ServisFormu]    Script Date: 28.12.2020 12:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ServisFormu]
AS
SELECT        dbo.Firma.FirmaAdi, dbo.Firma.FirmaAdres, dbo.Firma.FirmaTelefonNo, dbo.Firma.FirmaFaksNo, dbo.Firma.FirmaEPosta, dbo.Firma.FirmaWebAdres, dbo.Musteri.MusteriAdSoyad, dbo.Musteri.MusteriTelefon, 
                         dbo.Musteri.AracPlakaNo, dbo.Musteri.AracMarkaModel, dbo.Musteri.AracSasiMotorNo, dbo.ServisIslemleri.AraciGetiren, dbo.ServisIslemleri.MusteriSikayetTalepAciklamasi, dbo.ServisIslemleri.KayitZamani, 
                         dbo.ServisIslemleri.AracTeslimTarihi, dbo.ServisPersonel.PersonelAdSoyad, dbo.ServisIslemleriSatir.malzemeKodu, dbo.ServisIslemleriSatir.malzemeAciklama, dbo.ServisIslemleriSatir.Adet, 
                         dbo.ServisIslemleriSatir.BirimFiyat, dbo.ServisIslemleriSatir.Tutar
FROM            dbo.ServisIslemleri INNER JOIN
                         dbo.Musteri ON dbo.ServisIslemleri.MusteriId = dbo.Musteri.MusteriId INNER JOIN
                         dbo.ServisPersonel ON dbo.ServisIslemleri.ServisPersonelId = dbo.ServisPersonel.ServisPersonelId INNER JOIN
                         dbo.Firma ON dbo.ServisIslemleri.FirmaId = dbo.Firma.FirmaId INNER JOIN
                         dbo.ServisIslemleriSatir ON dbo.ServisIslemleri.ServisId = dbo.ServisIslemleriSatir.ServisId
GO
ALTER TABLE [dbo].[ServisIslemleri] ADD  CONSTRAINT [DF_ServisIslemleri_KayitZamani]  DEFAULT (getdate()) FOR [KayitZamani]
GO
ALTER TABLE [dbo].[ServisIslemleriSatir] ADD  CONSTRAINT [DF_ServisIslemleriSatir_KayitZamani]  DEFAULT (getdate()) FOR [KayitZamani]
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
         Begin Table = "ServisIslemleri"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 274
               Right = 297
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "m"
            Begin Extent = 
               Top = 9
               Left = 312
               Bottom = 251
               Right = 494
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sp"
            Begin Extent = 
               Top = 9
               Left = 500
               Bottom = 274
               Right = 681
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
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1725
         Alias = 1755
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AnaServisListesi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'AnaServisListesi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[20] 4[31] 2[15] 3) )"
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
         Begin Table = "ServisIslemleri"
            Begin Extent = 
               Top = 16
               Left = 228
               Bottom = 252
               Right = 479
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Musteri"
            Begin Extent = 
               Top = 15
               Left = 510
               Bottom = 256
               Right = 692
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServisPersonel"
            Begin Extent = 
               Top = 15
               Left = 711
               Bottom = 169
               Right = 892
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Firma"
            Begin Extent = 
               Top = 4
               Left = 5
               Bottom = 225
               Right = 179
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ServisIslemleriSatir"
            Begin Extent = 
               Top = 30
               Left = 1042
               Bottom = 275
               Right = 1228
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
         Begin ParameterName = "@id"
            ParameterValue = "2"
         End
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1680
         Width = 1815
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ServisFormu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 2460
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ServisFormu'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ServisFormu'
GO
USE [master]
GO
ALTER DATABASE [AracServisTakip] SET  READ_WRITE 
GO
