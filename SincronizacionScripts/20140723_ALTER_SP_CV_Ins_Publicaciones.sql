USE [DB_RRHH]
GO
/****** Object:  StoredProcedure [dbo].[CV_Ins_Publicaciones]    Script Date: 07/23/2014 20:49:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[CV_Ins_Publicaciones]
@CantidadHojas varchar(100),
@DatosEditorial varchar(100),
@DisponeCopia int,
@Titulo varchar(100),
@FechaPublicacion datetime,
@Usuario int,
--@FechaOperacion datetime,
@Baja int=null,  
@IdPersona int =null  

as

BEGIN

INSERT INTO [dbo].[CV_Publicaciones]
           ([CantidadHojas]
           ,[DatosEditorial]
           ,[DisponeCopia]
           ,[Titulo]
           ,[FechaPublicacion]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja]
           ,[IdPersona])
     VALUES
           (@CantidadHojas,
           @DatosEditorial,
           @DisponeCopia,
           @Titulo,
           @FechaPublicacion, 
           @Usuario,
          getdate(),
           @Baja,
           @IdPersona)

SELECT SCOPE_IDENTITY()   

END