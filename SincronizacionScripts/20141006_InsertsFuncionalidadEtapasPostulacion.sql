USE [DB_RRHH]
GO
/****** Object:  Table [dbo].[MAU_Accesos_A_URL]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_URL] ON
INSERT [dbo].[MAU_Accesos_A_URL] ([id], [url], [idBaja], [fechaBaja]) VALUES (22, N'/WebRH/FormularioConcursar/EtapasPostulacion.aspx', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_URL] OFF

/****** Object:  Table [dbo].[MAU_Funcionalidades]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Funcionalidades] ON
INSERT [dbo].[MAU_Funcionalidades] ([Id], [Nombre], [IdBaja], [FechaBaja]) VALUES (14, N'etapas_postular', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Funcionalidades] OFF

/****** Object:  Table [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] ON
INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] ([Id], [IdAccesoAUrl], [IdFuncionalidad]) VALUES (22, 22, 14)
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] OFF
