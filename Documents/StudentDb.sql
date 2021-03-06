CREATE DATABASE StudentDb

USE [StudentDb]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 01/14/2013 09:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Classes] ([Id], [Name], [Code]) VALUES (1, N'Java', N'JVA-1     ')
INSERT [dbo].[Classes] ([Id], [Name], [Code]) VALUES (2, N'C++', N'CPP-01    ')
/****** Object:  Table [dbo].[Students]    Script Date: 01/14/2013 09:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](1024) NOT NULL,
	[ClassId] [int] NOT NULL,
	[Mark1] [decimal](18, 0) NULL,
	[Mark2] [decimal](18, 0) NULL,
	[Mark3] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Students] ([Id], [Name], [ClassId], [Mark1], [Mark2], [Mark3]) VALUES (2, N'Minh', 2, CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)), CAST(10 AS Decimal(18, 0)))
INSERT [dbo].[Students] ([Id], [Name], [ClassId], [Mark1], [Mark2], [Mark3]) VALUES (3, N'Ánh', 2, CAST(9 AS Decimal(18, 0)), CAST(8 AS Decimal(18, 0)), CAST(7 AS Decimal(18, 0)))
/****** Object:  ForeignKey [FK_Student_Class]    Script Date: 01/14/2013 09:43:36 ******/
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Student_Class]
GO
