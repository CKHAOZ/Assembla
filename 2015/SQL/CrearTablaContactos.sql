USE [SHC]
GO

/****** Object:  Table [dbo].[Login_Inquietud]    Script Date: 19/05/2015 23:52:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Login_Inquietud](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NombreApellido] [varchar](250) NOT NULL,
	[Ocupacion] [varchar](250) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[Correo] [varchar](250) NOT NULL,
	[Duda] [varchar](512) NOT NULL,
	[FechaRegistro] [datetime] NOT NULL CONSTRAINT [DF_Login_Inquietud_FechaRegistro]  DEFAULT (getdate()),
 CONSTRAINT [PK_Login_Inquietud] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

