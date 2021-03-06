USE [Almocao]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 04/07/2020 11:43:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](300) NULL,
	[Usuario] [varchar](100) NULL,
	[Senha] [varchar](100) NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Restaurante]    Script Date: 04/07/2020 11:43:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Restaurante](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](300) NULL,
	[Endereco] [varchar](300) NULL,
 CONSTRAINT [PK_Restaurante] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Voto]    Script Date: 04/07/2020 11:43:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AlunoId] [int] NULL,
	[Dia] [date] NULL,
	[RestauranteId] [int] NULL,
 CONSTRAINT [PK_Voto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Aluno] ON 

INSERT [dbo].[Aluno] ([Id], [Nome], [Usuario], [Senha]) VALUES (1, N'Thiago', N'thiago', N'123')
INSERT [dbo].[Aluno] ([Id], [Nome], [Usuario], [Senha]) VALUES (2, N'Getúlio', N'getulio', N'123')
INSERT [dbo].[Aluno] ([Id], [Nome], [Usuario], [Senha]) VALUES (3, N'Enrico', N'enrico', N'123')
SET IDENTITY_INSERT [dbo].[Aluno] OFF
SET IDENTITY_INSERT [dbo].[Restaurante] ON 

INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (1, N'Bar da Rosa', N'Rua da Rosa, 2-33')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (2, N'Gourmeteria Universitária', N'Rua Irmã Arminda 10-50')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (3, N'Camponesa - O Parmegiana', N'Rodovia Marechal Rondon Km 334')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (4, N'Baby Buffalo Churrascaria', N'Rua Ezequiel Ramos 7 52')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (5, N'Lelo''s', N'Avenida Nações Unidas 24-47 Vila Nova Cidade Universitária')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (6, N'Casarão da Picanha', N'Rua Henrique Savi')
INSERT [dbo].[Restaurante] ([Id], [Nome], [Endereco]) VALUES (7, N'Restaurante Tayu', N'Rua Jose Antonio Braga, 2 77')
SET IDENTITY_INSERT [dbo].[Restaurante] OFF
SET IDENTITY_INSERT [dbo].[Voto] ON 

INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (1, 1, CAST(N'2020-07-03' AS Date), 1)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (2, 2, CAST(N'2020-07-03' AS Date), 2)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (3, 1, CAST(N'2020-07-02' AS Date), 2)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (4, 3, CAST(N'2020-07-03' AS Date), 2)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (5, 1, CAST(N'2020-07-03' AS Date), 1)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (6, 1, CAST(N'2020-07-04' AS Date), 5)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (7, 2, CAST(N'2020-07-04' AS Date), 5)
INSERT [dbo].[Voto] ([Id], [AlunoId], [Dia], [RestauranteId]) VALUES (8, 3, CAST(N'2020-07-04' AS Date), 3)
SET IDENTITY_INSERT [dbo].[Voto] OFF
