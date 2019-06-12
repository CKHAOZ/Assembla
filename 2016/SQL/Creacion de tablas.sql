-- Hola, este script pretende dar conocimiento paso a paso de como se llevo a cabo el proceso de creación del modelo, las tablas en la Base de Datos [BryanAlejandroCubillos]

-- 1 - Se realiza la creación de las tablas.

-- 1.1 Empresa
 
 USE [BryanAlejandroCubillos]
GO

/****** Object:  Table [dbo].[Empresa]    Script Date: 13/12/2016 10:45:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Empresa](
	[empId] [int] IDENTITY(1,1) NOT NULL,
	[empName] [varchar](250) NOT NULL,
	[empCreateDate] [datetime] NOT NULL CONSTRAINT [DF_Empresa_empCreateDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- 1.2 Usuario
USE [BryanAlejandroCubillos]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 13/12/2016 10:45:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Usuario](
	[usuId] [int] IDENTITY(1,1) NOT NULL,
	[usuName] [varchar](50) NOT NULL,
	[usuCreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_usuCreateDate]  DEFAULT (getdate()) FOR [usuCreateDate]
GO
 
-- 1.3 Inventario
 USE [BryanAlejandroCubillos]
GO

/****** Object:  Table [dbo].[Inventario]    Script Date: 13/12/2016 10:45:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventario](
	[invId] [int] IDENTITY(1,1) NOT NULL,
	[empId] [int] NOT NULL,
	[usuId] [int] NOT NULL,
	[invProduct] [varchar](250) NOT NULL,
	[invQuantity] [int] NOT NULL,
	[invCreateDate] [datetime] NOT NULL,
	[invModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[invId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Inventario] ADD  CONSTRAINT [DF_Inventario_invCreateDate]  DEFAULT (getdate()) FOR [invCreateDate]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Inventario_empId] FOREIGN KEY([empId])
REFERENCES [dbo].[Empresa] ([empId])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Inventario_empId]
GO

ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Inventario_usuId] FOREIGN KEY([usuId])
REFERENCES [dbo].[Usuario] ([usuId])
GO

ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Inventario_usuId]
GO

