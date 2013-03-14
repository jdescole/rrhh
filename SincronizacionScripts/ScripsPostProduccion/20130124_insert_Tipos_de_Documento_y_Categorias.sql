
update dbo.sic_tipodedocumento
set Sigla = 'E'
where Descripcion = 'Expediente'

update dbo.sic_tipodedocumento
set Sigla = 'MEMO N�'
where Descripcion = 'Memo'



insert into dbo.SIC_TipoDeDocumento(Descripcion, Sigla) values ('Expediente INAI','E-INAI')
insert into dbo.SIC_TipoDeDocumento(Descripcion, Sigla) values ('Expediente SENAF','E-SENAF')
insert into dbo.SIC_TipoDeDocumento(Descripcion, Sigla) values ('SP','SP')
insert into dbo.SIC_TipoDeDocumento(Descripcion, Sigla) values ('Nota','NOTA N�')
insert into dbo.SIC_TipoDeDocumento(Descripcion, Sigla) values ('Providencia','PROV N�')
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Carta Documento')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Telegrama')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Formulario')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Planilla')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Certificado')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Factura')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Sobre Cerrado')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Dictamen')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Correo')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Carta')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Legajo')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Documento')	
insert into dbo.SIC_TipoDeDocumento (Descripcion) values ('Sobre')	


insert into dbo.SIC_CategoriaDeDocumento values('Alta de Contrato')
insert into dbo.SIC_CategoriaDeDocumento values('Adecuaci�n de Nivel')
insert into dbo.SIC_CategoriaDeDocumento values('Designaci�n')
insert into dbo.SIC_CategoriaDeDocumento values('Embargo')
insert into dbo.SIC_CategoriaDeDocumento values('Unidades Retributivas (UR)')
insert into dbo.SIC_CategoriaDeDocumento values('Recategorizaci�n')
insert into dbo.SIC_CategoriaDeDocumento values('Adecuaci�n de Contrato')
insert into dbo.SIC_CategoriaDeDocumento values('Reintegro')
insert into dbo.SIC_CategoriaDeDocumento values('Promoci�n de Grado')
insert into dbo.SIC_CategoriaDeDocumento values('Solicitud de Equivalencia')
insert into dbo.SIC_CategoriaDeDocumento values('Adscripci�n')
insert into dbo.SIC_CategoriaDeDocumento values('Actualizaci�n de Nomenclador de Funciones Ejecutivas')
insert into dbo.SIC_CategoriaDeDocumento values('Actualizaci�n de Estructura')
insert into dbo.SIC_CategoriaDeDocumento values('Renuncia por Jubilaci�n')
insert into dbo.SIC_CategoriaDeDocumento values('Asignacion Grado Extraordinario')
insert into dbo.SIC_CategoriaDeDocumento values('Designaci�n Unidad Ejecutora')
insert into dbo.SIC_CategoriaDeDocumento values('Reencasillamiento')
insert into dbo.SIC_CategoriaDeDocumento values('Alta Jubilatoria')
insert into dbo.SIC_CategoriaDeDocumento values('Reubicaci�n')
insert into dbo.SIC_CategoriaDeDocumento values('Sobre CAP')
insert into dbo.SIC_CategoriaDeDocumento values('Sobre CDR')
insert into dbo.SIC_CategoriaDeDocumento values('La Caja ART')
insert into dbo.SIC_CategoriaDeDocumento values('Horas Extras')
insert into dbo.SIC_CategoriaDeDocumento values('Bancos')
insert into dbo.SIC_CategoriaDeDocumento values('Certificaci�n de Servicios')
insert into dbo.SIC_CategoriaDeDocumento values('Licencia sin goce de Haberes')
insert into dbo.SIC_CategoriaDeDocumento values('Certificado Licencia M�dica')
insert into dbo.SIC_CategoriaDeDocumento values('Renovaci�n Contractual')
insert into dbo.SIC_CategoriaDeDocumento values('Baja Afiliado')
insert into dbo.SIC_CategoriaDeDocumento values('Planilla Asistencia')
insert into dbo.SIC_CategoriaDeDocumento values('Credencial')
insert into dbo.SIC_CategoriaDeDocumento values('DDJJ')
insert into dbo.SIC_CategoriaDeDocumento values('Pago por T�tulo')
