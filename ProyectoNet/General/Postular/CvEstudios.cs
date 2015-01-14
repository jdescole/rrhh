﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class CvEstudios:ItemCv
    {
        protected int _id;
        protected string _titulo;
        protected int _anios;
        protected string _establecimiento;
        protected int _nivel;
        protected DateTime _fechaIngreso;
        protected DateTime _fechaEgreso;
        protected string _localidad;
        protected int _pais;
        protected string _especialidad;

        public int Id { get { return _id; } set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public int Anios { get { return _anios; } set { _anios = value; } }
        public string Establecimiento { get { return _establecimiento; } set { _establecimiento = value; } }
        public int Nivel { get { return _nivel; } set { _nivel = value; } }
        public string Especialidad { get { return _especialidad; } set { _especialidad = value; } }
        public DateTime FechaIngreso { get { return _fechaIngreso; } set { _fechaIngreso = value; } }
        public DateTime FechaEgreso { get { return _fechaEgreso; } set { _fechaEgreso = value; } }
        public string Localidad { get { return _localidad; } set { _localidad = value; } }
        public int Pais { get { return _pais; } set { _pais = value; } }
        //public const int IdTabla = 1;// { get { return 1; } set { } }


		public CvEstudios() { }
        public CvEstudios(string titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais):base(0,titulo,1)
        {
            SetearCampos(titulo, nivel, anios, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);
        }

        public CvEstudios(int id, string titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais):base(id, titulo,1)
        {
            this._id = id;
            SetearCampos(titulo, nivel, anios, establecimiento, especialidad, fechaIngeso, fechaEgreso, localidad, pais);

        }

        private void SetearCampos(string titulo, int nivel, int anios, string establecimiento, string especialidad, DateTime fechaIngeso, DateTime fechaEgreso, string localidad, int pais)
        {
            this._titulo = titulo;
            this._establecimiento = establecimiento;
            this._nivel = nivel;
            this._anios = anios;
            this._especialidad = especialidad;
            this._fechaIngreso = fechaIngeso;
            this._fechaEgreso = fechaEgreso;
            this._localidad = localidad;
            this._pais = pais;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((CvEstudios)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }
    }
}