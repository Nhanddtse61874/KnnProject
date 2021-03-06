USE [master]
GO
/****** Object:  Database [KnnDbCapstone_v2]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE DATABASE [KnnDbCapstone_v2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KnnDbCapstone_v2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL14\MSSQL\DATA\KnnDbCapstone_v2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KnnDbCapstone_v2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQL14\MSSQL\DATA\KnnDbCapstone_v2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [KnnDbCapstone_v2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KnnDbCapstone_v2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ARITHABORT OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET  MULTI_USER 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KnnDbCapstone_v2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KnnDbCapstone_v2] SET QUERY_STORE = OFF
GO
USE [KnnDbCapstone_v2]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_dbo.Color] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorProduct]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ColorProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](225) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Phone] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageStorage]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageStorage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](255) NULL,
	[Alt] [nvarchar](255) NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ImageStorage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[AddressShipping] [nvarchar](255) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[CurrentPrice] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalLine] [float] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Point] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Rank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_dbo.Size] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SizeProduct]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizeProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SizeProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TagProduct]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TagProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/12/2020 9:33:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[PassWord] [nvarchar](255) NOT NULL,
	[RankId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Phone] [int] NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Point] [float] NOT NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentId] ON [dbo].[Category]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ColorId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ColorId] ON [dbo].[ColorProduct]
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ColorProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[ImageStorage]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Order]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderDetail]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[OrderDetail]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[SizeProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SizeId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_SizeId] ON [dbo].[SizeProduct]
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductId] ON [dbo].[TagProduct]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_TagId] ON [dbo].[TagProduct]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RankId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_RankId] ON [dbo].[User]
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoleId]    Script Date: 10/12/2020 9:33:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[User]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Category_dbo.Category_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_dbo.Category_dbo.Category_ParentId]
GO
ALTER TABLE [dbo].[ColorProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ColorProduct_dbo.Color_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Color] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ColorProduct] CHECK CONSTRAINT [FK_dbo.ColorProduct_dbo.Color_ColorId]
GO
ALTER TABLE [dbo].[ColorProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ColorProduct_dbo.Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ColorProduct] CHECK CONSTRAINT [FK_dbo.ColorProduct_dbo.Product_ProductId]
GO
ALTER TABLE [dbo].[ImageStorage]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ImageStorage_dbo.Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageStorage] CHECK CONSTRAINT [FK_dbo.ImageStorage_dbo.Product_ProductId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Order_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_dbo.Order_dbo.User_UserId]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderId]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetail_dbo.Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_dbo.OrderDetail_dbo.Product_ProductId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Product_dbo.Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_dbo.Product_dbo.Category_CategoryId]
GO
ALTER TABLE [dbo].[SizeProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SizeProduct_dbo.Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SizeProduct] CHECK CONSTRAINT [FK_dbo.SizeProduct_dbo.Product_ProductId]
GO
ALTER TABLE [dbo].[SizeProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SizeProduct_dbo.Size_SizeId] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Size] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SizeProduct] CHECK CONSTRAINT [FK_dbo.SizeProduct_dbo.Size_SizeId]
GO
ALTER TABLE [dbo].[TagProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagProduct_dbo.Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagProduct] CHECK CONSTRAINT [FK_dbo.TagProduct_dbo.Product_ProductId]
GO
ALTER TABLE [dbo].[TagProduct]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagProduct_dbo.Tag_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagProduct] CHECK CONSTRAINT [FK_dbo.TagProduct_dbo.Tag_TagId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_dbo.User_dbo.Rank_RankId] FOREIGN KEY([RankId])
REFERENCES [dbo].[Rank] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_dbo.User_dbo.Rank_RankId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_dbo.User_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_dbo.User_dbo.Role_RoleId]
GO
USE [master]
GO
ALTER DATABASE [KnnDbCapstone_v2] SET  READ_WRITE 
GO
