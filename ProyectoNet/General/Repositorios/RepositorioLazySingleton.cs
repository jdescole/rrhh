﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public abstract class RepositorioLazySingleton<T>:Repositorio<T>
    {
        protected List<T> objetos;

        protected DateTime _fecha_creacion;
        protected int minutos_de_vida;
        public RepositorioLazySingleton(IConexionBD conexion, int _minutos_de_vida)
            : base(conexion)
        {
            this.minutos_de_vida = _minutos_de_vida;
            this._fecha_creacion = DateTime.Now;
        }
        protected bool ExpiroTiempoDelRepositorio()
        {
            if (FechaExpiracion() < DateTime.Now)
            {
                return true;
            }
            return false;
        }
        protected DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(minutos_de_vida);
        }

        abstract protected List<T> ObtenerDesdeLaBase();
        protected List<T> Obtener()
        {
            if (objetos == null) objetos = ObtenerDesdeLaBase();
            return objetos;
        }

        abstract protected void GuardarEnLaBase(T objeto);
        protected void Guardar(T objeto)
        {
            GuardarEnLaBase(objeto);
            if (objetos != null) objetos.Add(objeto);
        }

        abstract protected void QuitarDeLaBase(T objeto);
        protected void Quitar(T objeto)
        {
            QuitarDeLaBase(objeto);
            if (objetos != null) objetos.Remove(objeto);
        }
    }
}