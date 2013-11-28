﻿using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class Persona
    {
        private int _id;
        private int _Documento;
        private string _Nombre;
        private string _Apellido;
        private Area _Area;
        private PaseDeArea _PasePendiente;
        private Inasistencia _InasistenciaActual;
        private TipoDeViatico _TipoDeViatico;
        private ModalidadDeContratacion _ModalidadDeContratacion;
        private string _Nivel;
        private string _Grado;
        private float _Retribucion;
        private TipoDePlanta _TipoDePlanta;
        private bool _Es1184;
        private string _Telefono;
        private string _Cuit;
        private string _Legajo;
        private string _categoria;

        public int Id { get { return _id; } set { _id = value; } }
        public int Documento { get { return _Documento; } set { _Documento = value;  } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value;  } }  
        public string Apellido { get { return _Apellido; } set { _Apellido = value;  } }
        public Area Area { get { return _Area; } set { _Area = value;  } }
        public PaseDeArea PasePendiente { get { return _PasePendiente; } set { _PasePendiente = value;  } }
        public Inasistencia InasistenciaActual { get { return _InasistenciaActual; } set { _InasistenciaActual = value;  } }
        public TipoDeViatico TipoDeViatico { get { return _TipoDeViatico; } set { _TipoDeViatico = value; } }
        public ModalidadDeContratacion ModalidadDeContratacion { get { return _ModalidadDeContratacion; } set { _ModalidadDeContratacion = value; } }
        public string Nivel { get { return _Nivel; } set { _Nivel = value;  } }
        public string Grado { get { return _Grado; } set { _Grado = value;  } }    
        public float Retribucion { get { return _Retribucion; } set { _Retribucion = value;  } }  
        public TipoDePlanta TipoDePlanta { get { return _TipoDePlanta; } set { _TipoDePlanta = value;  } }
        public bool Es1184 { get { return _Es1184; } set { _Es1184 = value;  } }  
        public string Telefono { get { return _Telefono; } set { _Telefono = value;  } }
        public string Cuit { get { return _Cuit; } set { _Cuit = value;  } } 
        public string Legajo { get { return _Legajo; } set { _Legajo = value;  } }
        public string Categoria { get { return _categoria; } set { _categoria = value; } }

        
        public Persona() { }

        public override bool Equals(object obj)
        {
            //return this.Id == ((Persona)obj).Id;
            if (!(obj is Persona)) return false;
            Persona otro = (Persona)obj;
            return otro.Documento == Documento;
        }

        public override int GetHashCode()
        {
            return this.Documento.GetHashCode();
        }
       
    }
}