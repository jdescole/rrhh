﻿using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioDeProvincias : RepositorioLazySingleton<Provincia>
    {
        private static RepositorioDeProvincias _instancia;

        private RepositorioDeProvincias(IConexionBD conexion)
            :base(conexion, 10)
        {
        }

        public static RepositorioDeProvincias Nuevo(IConexionBD conexion)
        {
            if (!(_instancia != null && !_instancia.ExpiroTiempoDelRepositorio())) _instancia = new RepositorioDeProvincias(conexion);
            return _instancia;
        }

        public List<Provincia> All()
        {
            return this.Obtener();
        }

        public List<Provincia> GetProvinciasDeLaZona(Zona zona)
        {
            SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.VIA_GetProvinciasDeLaZona");
            cn.AsignarParametro("@idZona", zona.Id);

            dr = cn.EjecutarConsulta();
            Provincia unaProvincia;
            List<Provincia> provincias = new List<Provincia>();
            RepositorioDeLocalidades repositorio = RepositorioDeLocalidades.NuevoRepositorioDeLocalidades(this.conexion);

            while (dr.Read())
            {
                unaProvincia = new Provincia { Id = dr.GetInt16(0), Nombre = dr.GetString(1), CodigoAFIP = dr.GetInt16(0) };
                provincias.Add(unaProvincia);
                unaProvincia.Localidades = repositorio.GetLocalidadesDeLaProvincia(unaProvincia);
            }
            return provincias;
        }

        protected override List<Provincia> ObtenerDesdeLaBase()
        {
            var tablaDatos = conexion.Ejecutar("dbo.WEB_GetProvincias");
            var provincias = new List<Provincia>();
            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                    provincias.Add(new Provincia(row.GetSmallintAsInt("id"), row.GetString("nombre")));
                });
            }

            return provincias;
        }

        protected override void GuardarEnLaBase(Provincia objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(Provincia objeto)
        {
            throw new NotImplementedException();
        }
    }
}
