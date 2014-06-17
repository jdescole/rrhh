﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeCurriculum : IRepositorioDeCurriculum
    {
        protected IConexionBD conexion_bd;
        protected List<CurriculumVitae> lista_cv;
        protected CvDatosPersonales _cvDatosPersonales;
        protected List<CvEstudios> _cvAntecedentesAcademicos;
        protected List<CvCertificadoDeCapacitacion> _cvCapacitacion;
        protected List<CvDocencia> _cvDocencia;
        protected CvEventoAcademico _cvEventoAcademico;
        protected CvPublicaciones _cvPublicacion;
        protected CvMatricula _cvMatricula;
        protected CvInstitucionesAcademicas _cvInstitucion;
        protected CvExperienciaLaboral _cvExperiencia;


        public RepositorioDeCurriculum(IConexionBD conexion) 
        {
            this.conexion_bd = conexion;
            this.lista_cv = new List<CurriculumVitae>();
            this._cvAntecedentesAcademicos = new List<CvEstudios>();
            this._cvDocencia = new List<CvDocencia>();
            this._cvCapacitacion = new List<CvCertificadoDeCapacitacion>();

            //FC a borrar cuando traiga los datos de la base
            string fechaIngreso = new DateTime(2014, 12, 12).ToShortDateString();
            string fechaEgreso = new DateTime(2014, 12, 13).ToShortDateString();
            var un_estudio = new CvEstudios(1, "Contador", "UBA", "Te dije contador", fechaIngreso,
                                                  fechaEgreso, "CABA", "Argentina");
            this._cvAntecedentesAcademicos.Add(un_estudio);
            

        }

        #region GETS Mockeados
        public CurriculumVitae GetCV(int documento)
        {
            var parametros = new Dictionary<string, object>();
            
            parametros.Add("@NroDocumento", documento);
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_GetCurriculumVitae", parametros);

            CurriculumVitae cv = null;

            tablaCVs.Rows.ForEach(row => 
                cv = new CurriculumVitae(
                    new CvDatosPersonales(documento, row.GetString("Nombre"), row.GetString("Apellido"), row.GetString("Sexo"), row.GetString("EstadoCivil"),
                        row.GetString("Cuil"), row.GetString("LugarNacimiento", ""), row.GetString("Nacionalidad"), row.GetDateTime("FechaNacimiento").ToString("dd/MM/yyyy"), "DNI", 
                        new CvDomicilio(row.GetString("DomPers_Calle"), row.GetInt("DomPers_Numero"), row.GetString("DomPers_Piso"), row.GetString("DomPers_Depto"),
                            row.GetString("DomPers_Localidad"), row.GetSmallintAsInt("DomPers_CodigoPostal"), new Provincia(row.GetSmallintAsInt("DomPers_IdProvincia"), row.GetString("DomPers_NombreProvincia"))),
                        new CvDomicilio(row.GetString("DomLab_Calle"), row.GetInt("DomLab_Numero"), row.GetString("DomLab_Piso"), row.GetString("DomLab_Depto"),
                            row.GetString("DomLab_Localidad"), row.GetSmallintAsInt("DomLab_CodigoPostal"), new Provincia(row.GetSmallintAsInt("DomLab_IdProvincia"), row.GetString("DomLab_NombreProvincia"))))));

            return cv; 
        }

       
        public List<CvCapacidadesPersonales> GetCvCapacidadesPersonales(int documento)
        {
            var capacidades_personales = new List<CvCapacidadesPersonales>()
                               {
                                   new CvCapacidadesPersonales("Simpático", "Organizado", "Analista Técnica", "Creativo")
                               };
            
            return capacidades_personales;
        }

        public List<CvCertificadoDeCapacitacion> GetCvCertificadoDeCapacitacion(int documento)
        {
            var certificados_de_capacitaciones = new List<CvCertificadoDeCapacitacion>()
                               {
                                   new CvCertificadoDeCapacitacion("Arquitecto Java", "Oracle", "Java", "2 años",  new DateTime(2012, 01, 13), new DateTime(2014, 03, 10), "CABA", "Argentina" )
                               };

            return certificados_de_capacitaciones;
        }

        public List<CvCompetenciasInformaticas> GetCvCompetenciasInformaticas(int documento)
        {
            var compotencias_informaticas = new List<CvCompetenciasInformaticas>()
                               {
                                   new CvCompetenciasInformaticas("Administrador de Base de Datos", "Sigma", "Base de Datos", "Senior",  "Avanzado" , "CABA", "Argentina", new DateTime(2013, 11, 15) )
                               };

            return compotencias_informaticas;
        }


        public CvDatosPersonales GetCvDatosPersonales(int documento)
        {
           var domicilio = new CvDomicilio("Pedro Morán", 1234, "7", "A", "Capital Federal", 1419, new Provincia(2, "CABA"));
           var datos_personales = new CvDatosPersonales(31369852, "Roberto", "Moreno", "Masculono", "Soltero", "20-31369852-7", "Buenos Aires", "Argentina", new DateTime(1985, 07, 23).ToShortDateString(), "D.N.I", domicilio,domicilio);
           //return datos_personales;
           return this._cvDatosPersonales;
        }


        public List<CvDocencia> GetCvDocencia(int documento)
        {
            var docencia = new List<CvDocencia>()
                               {
                                   new CvDocencia("Matemática Discreta", "Universitario", "Docencia", "Profesor Titular",  "Jefe de Cátedra" , "Dedicación Exclusiva", "40 horas semanales", new DateTime(2005, 03, 01), new DateTime(2009, 12, 01), "Universidad Tecnológica Nacional", "CABA", "Argentina")
                               };

            return docencia;
        }

        public List<CvDomicilio> GetCvDomicilio(int documento)
        {
            var domicilio = new List<CvDomicilio>()
                               {
                                   new CvDomicilio("Pedro Morán", 1234, "7", "A", "Capital Federal", 1419, new Provincia(2, "CABA"))
                               };

            return domicilio;
        }

        public List<CvEventoAcademico> GetCvEventoAcademico(int documento)
        {
            var evento_academico = new List<CvEventoAcademico>()
                               {
                                   new CvEventoAcademico("Encuentro Nacional Docente", "Congreso Nacional", "Expositor", "Joaquín V. González", new DateTime(2008, 02, 07), new DateTime(2008, 02, 11), "4 Jornadas", "CABA", "Argentina")
                               };

            return evento_academico;
        }

        public List<CvExperienciaLaboral> GetCvExperienciaLaboral(int documento)
        {
            var experiencia_laboral = new List<CvExperienciaLaboral>()
                               {
                                   new CvExperienciaLaboral("Analista Oracle", "Renuncia", "Accenture S.A", false, "Privada", "Consultoría", new DateTime(2001, 07, 07), new DateTime(2004, 12, 21), "CABA", "Argentina")
                               };

            return experiencia_laboral;
        }

        public List<CvIdiomas> GetCvIdiomas(int documento)
        {
            var idiomas = new List<CvIdiomas>()
                               {
                                   new CvIdiomas("CAF Certification", "Cultural Inglesa Pueyrredón", "Inglés", "Avanzado", "Avanzado","Avanzado", new DateTime(1999, 01, 07), new DateTime(1997, 12, 15), "CABA", "Argentina"),
                                   new CvIdiomas("International French Language", "CUI", "Francés", "Avanzado", "Intermedio","Intermedio", new DateTime(2002, 04, 27), new DateTime(2007, 05, 17), "CABA", "Argentina")
                               };

            return idiomas;
        }

        public List<CvInstitucionesAcademicas> GetCvInstitucionesAcademicas(int documento)
        {
            var instituciones_academicas = new List<CvInstitucionesAcademicas>()
                               {
                                   new CvInstitucionesAcademicas("Universidad Tecnológica Nacional", "Pública", "Docente", 1234, "Jefe de Cátedra", new DateTime(1992, 08, 17), new DateTime(1993, 01, 17), new DateTime(1992, 04, 21), new DateTime(2011, 09, 29), "CABA", "Argentina")
                               };

            return instituciones_academicas;
        }

        public List<CvMatricula> GetCvMatricula(int documento)
        {
            var matricula = new List<CvMatricula>()
                               {
                                   new CvMatricula("3217/14", "Gobierno de la ciudad de Buenos Aires", "Vigente", new DateTime(1990, 09, 07))
                               };

            return matricula;
        }

        public List<CvPublicaciones> GetCvPublicaciones(int documento)
        {
            var publicaciones = new List<CvPublicaciones>()
                               {
                                   new CvPublicaciones("Factorizaciones", "Santillana", "377", true, new DateTime(2001, 11, 11))
                               };

            return publicaciones;
        }


        # endregion

        #region GUARDAR Datos
        public void GuardarCVDatosPersonales(CvDatosPersonales datosPersonales, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Dni", datosPersonales.Dni);
            parametros.Add("@Apellido", datosPersonales.Apellido);
            parametros.Add("@Nombre", datosPersonales.Nombre);
            parametros.Add("@Cuil", datosPersonales.Cuil);
            parametros.Add("@EstadoCivil", datosPersonales.EstadoCivil);
            parametros.Add("@FechaNacimiento", datosPersonales.FechaNacimiento);
            parametros.Add("@LugarDeNacimiento", datosPersonales.LugarDeNacimiento);
            parametros.Add("@Nacionalidad", datosPersonales.Nacionalidad);
            parametros.Add("@TipoDocumento", datosPersonales.TipoDocumento);
            parametros.Add("@Sexo", datosPersonales.Sexo);

            if (datosPersonales.DomicilioPersonal is CvDomicilio)
            {
                parametros.Add("@DomicilioPersonalCalle", datosPersonales.DomicilioPersonal.Calle);
                parametros.Add("@DomicilioPersonalNumero", datosPersonales.DomicilioPersonal.Numero);
                parametros.Add("@DomicilioPersonalPiso", datosPersonales.DomicilioPersonal.Piso);
                parametros.Add("@DomicilioPersonalDepto", datosPersonales.DomicilioPersonal.Depto);
                parametros.Add("@DomicilioPersonalCp", datosPersonales.DomicilioPersonal.Cp);
                parametros.Add("@DomicilioPersonalLocalidad", datosPersonales.DomicilioPersonal.Localidad);
                parametros.Add("@DomicilioPersonalProvincia", datosPersonales.DomicilioPersonal.Provincia);
                parametros.Add("@DomicilioPersonalTipo", 1);
            }


            if (datosPersonales.DomicilioLegal is CvDomicilio)
            {
                parametros.Add("@DomicilioLegalCalle", datosPersonales.DomicilioLegal.Calle);
                parametros.Add("@DomicilioLegalNumero", datosPersonales.DomicilioLegal.Numero);
                parametros.Add("@DomicilioLegalPiso", datosPersonales.DomicilioLegal.Piso);
                parametros.Add("@DomicilioLegalDepto", datosPersonales.DomicilioLegal.Depto);
                parametros.Add("@DomicilioLegalCp", datosPersonales.DomicilioLegal.Cp);
                parametros.Add("@DomicilioLegalLocalidad", datosPersonales.DomicilioLegal.Localidad);
                parametros.Add("@DomicilioLegalProvincia", datosPersonales.DomicilioLegal.Provincia);
                parametros.Add("@DomicilioLegalTipo", 2);

            }

                parametros.Add("@idUsuario", usuario.Id);

            //return (int)conexion_bd.EjecutarEscalar("dbo.CV_Ins_DatosPersonales", parametros);
            
            
            
            this._cvDatosPersonales = datosPersonales;
            //this.lista_cv.Add(cv);
        }

        public void ActualizarCV(CurriculumVitae cv)
        {
        }


        public List<CvEstudios> GuardarCvAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            this._cvAntecedentesAcademicos.Add(antecedentesAcademicos_nuevo);

            return this._cvAntecedentesAcademicos;
        }

        public CvEstudios EliminarCVAntecedentesAcademicos(CvEstudios antecedentesAcademicos_a_borrar, Usuario usuario)
        {
            this._cvAntecedentesAcademicos.Remove(antecedentesAcademicos_a_borrar);
            return antecedentesAcademicos_a_borrar;
        }

        public CvDocencia EliminarCvActividadesDocentes(CvDocencia actividades_docentes_a_borrar, Usuario usuario)
        {
            this._cvDocencia.Remove(actividades_docentes_a_borrar);
            return actividades_docentes_a_borrar;
        }

        public CvCertificadoDeCapacitacion EliminarCvActividadesCapacitacion(CvCertificadoDeCapacitacion actividades_capacitacion_a_borrar, Usuario usuario)
        {
            this._cvCapacitacion.Remove(actividades_capacitacion_a_borrar);
            return actividades_capacitacion_a_borrar;
        }

        public List<CvEstudios> GetCvEstudios(int documento)
        {
            
            //Hacer que la fecha sea shortDateTime
            //estudios.ForEach(e => e.FechaIngreso.ToShortDateString() e.FechaEgreso.ToShortDateString());
            return this._cvAntecedentesAcademicos;
        }

        public List<CvCertificadoDeCapacitacion> GuardarCvCapacidades(CvCertificadoDeCapacitacion capacidades_nuevo, Usuario usuario)
        {
            this._cvCapacitacion.Add(capacidades_nuevo);
            return this._cvCapacitacion;
        }

        public List<CvDocencia> GuardarCvActividadesDocentes(CvDocencia docencia_nuevo, Usuario usuario)
        {
            this._cvDocencia.Add(docencia_nuevo);
            return this._cvDocencia;
        }

        public void GuardarCvEventoAcademico(CvEventoAcademico eventoAcademico_nuevo, Usuario usuario)
        {
            this._cvEventoAcademico = eventoAcademico_nuevo;
        }


        public void GuardarCvPublicaciones(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            this._cvPublicacion = publicacion_nueva;
        }


        public void GuardarCvMatriculas(CvMatricula matricula_nueva, Usuario usuario)
        {
            this._cvMatricula = matricula_nueva;
        }

        # endregion

        public void GuardarCvInstituciones(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
        {
            this._cvInstitucion = institucion_nueva;
        }


        public void GuardarCvExperiencias(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
        {
            this._cvExperiencia = experiencia_nueva;
        }

    }
}