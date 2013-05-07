SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SACC_Ins_Curso]
(	
	@id_espacioFisico  [smallint],
	@id_materia   [smallint],
	@id_docente   [int],
	@fecha_inicio [datetime],
	@fecha_fin    [datetime],
	@fecha		  [datetime],
	@baja		  [int] = null
	
) 

AS
    
INSERT INTO [dbo].[SAC_Cursos]
	(IdMateria, IdDocente, Fecha, idBaja,  IdEspacioFisico, FechaInicio, FechaFin)
VALUES
	(@id_materia, @id_docente, @fecha, @baja,  @id_espacioFisico, @fecha_inicio, @fecha_fin)
	
SELECT SCOPE_IDENTITY()	