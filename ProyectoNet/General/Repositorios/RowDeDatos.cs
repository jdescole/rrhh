﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.IO;

namespace General.Repositorios
{
/// <summary>
/// Descripción breve de TablaDeDatos
/// </summary>


    public class RowDeDatos
    {
        private DataRow dataRow;
        public RowDeDatos(DataRow dataRow)
        {
            this.dataRow = dataRow;
        }

        public int GetInt(String campo)
        {
            return (int)dataRow[campo];
        }

        public int GetInt(String campo, int default_if_null)
        {
            if (this.GetObject(campo) is DBNull || this.GetSmallintAsInt(campo) == 0) return default_if_null;
            return (int)dataRow[campo];
        }

        public int GetSmallintAsInt(String campo)
        {
            return int.Parse(dataRow[campo].ToString());
        }

        public int GetSmallintAsInt(String campo, int default_if_null)
        {
            if (this.GetObject(campo) is DBNull || this.GetSmallintAsInt(campo) == 0) return default_if_null;
            return int.Parse(dataRow[campo].ToString());
        }

        public string GetString(String campo)
        {
            return (string)dataRow[campo];
        }

        public string GetString(String campo, String default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return (string)dataRow[campo];
        }

        public DateTime GetDateTime(String campo)
        {
            return (DateTime)dataRow[campo];
        }

        public DateTime GetDateTime(String campo, DateTime default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return (DateTime)dataRow[campo];
        }

        public object GetObject(String campo)
        {
            return dataRow[campo];
        }

        public bool GetBoolean(string campo)
        {
            return (bool)dataRow[campo];
        }

        public bool GetBoolean(string campo, bool default_if_null)
        {
            if (this.GetObject(campo) is DBNull) return default_if_null;
            return (bool)dataRow[campo];
        }

        public float getFloat(string campo)
        {
            var valor_double = (double)dataRow[campo];
            return (float)valor_double;
        }

        public Image GetImage(string campo)
        {
            var bytes = (byte[])dataRow[campo];
            MemoryStream ms = new MemoryStream(bytes, 0,
                bytes.Length);

            ms.Write(bytes, 0, bytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}