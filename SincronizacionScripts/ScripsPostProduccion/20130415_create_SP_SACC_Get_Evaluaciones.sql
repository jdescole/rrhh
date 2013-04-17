set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SACC_Get_Evaluaciones]

AS

BEGIN

SELECT	id,
		idInstanciaEvaluacion, 
		idAlumno, 
		idCurso, 
		Calificacion, 
		FechaEvaluacion 
FROM [dbo].[SAC_Evaluaciones]
WHERE idBaja = null  
END

