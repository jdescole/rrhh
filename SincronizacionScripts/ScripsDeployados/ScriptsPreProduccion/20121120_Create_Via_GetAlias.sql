/*Obtiene todos los Alias de las �reas*/
Create Procedure dbo.Via_GetAlias
as

select Id, Id_Area, Alias from dbo.Via_Alias_Area
