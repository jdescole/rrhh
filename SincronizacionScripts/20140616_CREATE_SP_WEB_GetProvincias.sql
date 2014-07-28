USE [DB_RRHH]
GO
/****** Object:  StoredProcedure [dbo].[WEB_GetProvincias]    Script Date: 06/24/2014 20:25:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WEB_GetProvincias]
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

SELECT p.CodAFIP id , P.nombreProvincia nombre
FROM [dbo].[Provincias] P