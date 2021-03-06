CREATE DATABASE [P3Image]
GO
USE [P3Image]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblTipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.tblTipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblTipo] ON
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (1, N'TextBox')
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (2, N'CheckBox')
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (3, N'Inteiro')
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (4, N'Decimal')
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (5, N'Date')
INSERT [dbo].[tblTipo] ([Id], [Descricao]) VALUES (6, N'DropDownList')
SET IDENTITY_INSERT [dbo].[tblTipo] OFF
/****** Object:  Table [dbo].[tblCategoria]    Script Date: 02/12/2015 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
	[Slug] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_dbo.tblCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCampo]    Script Date: 02/12/2015 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCampo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
	[IdTipo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblCampo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubCategoria]    Script Date: 02/12/2015 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
	[Slug] [nvarchar](255) NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblSubCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSubCategoriaCampo]    Script Date: 02/12/2015 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSubCategoriaCampo](
	[IdSubCategoria] [int] NOT NULL,
	[IdCampo] [int] NOT NULL,
	[Ordem] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblSubCategoriaCampo] PRIMARY KEY CLUSTERED 
(
	[IdSubCategoria] ASC,
	[IdCampo] ASC,
	[Ordem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOpcao]    Script Date: 02/12/2015 18:19:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOpcao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](255) NOT NULL,
	[IdCampo] [int] NOT NULL,
 CONSTRAINT [PK_dbo.tblOpcao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_dbo.tblCampo_dbo.tblTipo_IdTipo]    Script Date: 02/12/2015 18:19:14 ******/
ALTER TABLE [dbo].[tblCampo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblCampo_dbo.tblTipo_IdTipo] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[tblTipo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblCampo] CHECK CONSTRAINT [FK_dbo.tblCampo_dbo.tblTipo_IdTipo]
GO
/****** Object:  ForeignKey [FK_dbo.tblOpcao_dbo.tblCampo_IdCampo]    Script Date: 02/12/2015 18:19:14 ******/
ALTER TABLE [dbo].[tblOpcao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblOpcao_dbo.tblCampo_IdCampo] FOREIGN KEY([IdCampo])
REFERENCES [dbo].[tblCampo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblOpcao] CHECK CONSTRAINT [FK_dbo.tblOpcao_dbo.tblCampo_IdCampo]
GO
/****** Object:  ForeignKey [FK_dbo.tblSubCategoria_dbo.tblCategoria_IdCategoria]    Script Date: 02/12/2015 18:19:14 ******/
ALTER TABLE [dbo].[tblSubCategoria]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblSubCategoria_dbo.tblCategoria_IdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[tblCategoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblSubCategoria] CHECK CONSTRAINT [FK_dbo.tblSubCategoria_dbo.tblCategoria_IdCategoria]
GO
/****** Object:  ForeignKey [FK_dbo.tblSubCategoriaCampo_dbo.tblCampo_IdCampo]    Script Date: 02/12/2015 18:19:14 ******/
ALTER TABLE [dbo].[tblSubCategoriaCampo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblSubCategoriaCampo_dbo.tblCampo_IdCampo] FOREIGN KEY([IdCampo])
REFERENCES [dbo].[tblCampo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblSubCategoriaCampo] CHECK CONSTRAINT [FK_dbo.tblSubCategoriaCampo_dbo.tblCampo_IdCampo]
GO
/****** Object:  ForeignKey [FK_dbo.tblSubCategoriaCampo_dbo.tblSubCategoria_IdSubCategoria]    Script Date: 02/12/2015 18:19:14 ******/
ALTER TABLE [dbo].[tblSubCategoriaCampo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.tblSubCategoriaCampo_dbo.tblSubCategoria_IdSubCategoria] FOREIGN KEY([IdSubCategoria])
REFERENCES [dbo].[tblSubCategoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblSubCategoriaCampo] CHECK CONSTRAINT [FK_dbo.tblSubCategoriaCampo_dbo.tblSubCategoria_IdSubCategoria]
GO
