﻿using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    
    public class TipoDePlanta
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value;  }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value;  }
        }

        public virtual ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            throw new Exception("Responsabilidad de la subclase");
        }

        public TipoDePlanta InstanciaDeSubclase()
        {
            if (this.Id == 22)
            {
                return new TipoDePlantaContratado();
            }
            else
            {
                return new TipoDePlantaGeneral(this._Id, this._Descripcion);
            }
        }
    }
}
