﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class VacacionesSolicitables
    {
        protected int _perido;
        protected int _dias;
        public VacacionesSolicitables()
        {
        }
        public VacacionesSolicitables(int periodo, int dias)
        {
            this._perido = periodo;
            this._dias = dias;
        }



        public int Period
        {
            get { return _perido; }
            set { }
        }

        public int Dias
        {
            get { return _dias; }
            set { }
        }

        public int Periodo()
        {
            return this._perido;
        }

        public int CantidadDeDias()
        {
            return this._dias;
        }
    }
}
