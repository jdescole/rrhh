﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvEventoAcademico
    {
        protected int _id;
        protected string _denominacion;
        //protected string _tipoEvento;
        //protected string _caracterDeParticipacion;
        //protected string _institucion;

        protected int _tipoEvento;
        protected int _caracterDeParticipacion;
        protected int _institucion;




        protected DateTime _fechaInicio;
        protected DateTime _fechaFinalizacion;
        protected string _duracion;
        protected string _localidad;
        protected int _pais;

        public int Id { get { return _id; } set { _id = value; } }
        public string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public int TipoDeEvento { get { return _tipoEvento; } set { _tipoEvento = value; } }
        public int CaracterDeParticipacion { get { return _caracterDeParticipacion; } set { _caracterDeParticipacion = value; } }
        public int Institucion { get { return _institucion; } set { _institucion = value; } }
        public DateTime FechaInicio { get { return _fechaInicio; } set { _fechaInicio = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }
        public string Duracion { get { return _duracion; } set { _duracion = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }

        public CvEventoAcademico(int id, string denominacion, int tipoDeEvento, int caracterDeParticipacion, DateTime fechaInicio, DateTime fechaFinalizacion, string duracion, int institucion, string localidad, int pais)
        {
            this._id = id;
            this._denominacion = denominacion;
            this._tipoEvento = tipoDeEvento;
            this._caracterDeParticipacion = caracterDeParticipacion;
            this._institucion = institucion;
            this._fechaInicio = fechaInicio;
            this._fechaFinalizacion = fechaFinalizacion;
            this._duracion = duracion;
            this._localidad = localidad;
            this._pais = pais;
        }

        public CvEventoAcademico()
        {
        }
    }

}

