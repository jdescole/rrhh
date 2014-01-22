﻿using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;
using General;
using System.Security.Cryptography;

namespace General.MAU
{
    public class Usuario : Persona
    {
        public string Alias { get; set; }
        protected string clave_encriptada { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string alias, string clave_encriptada)
        {
            this.Id = id;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
        }

        public Usuario(Persona persona, string alias, string clave_encriptada)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellido = persona.Apellido;
            this.Documento = persona.Documento;
            this.Legajo = persona.Legajo;
            this.Alias = alias;
            this.clave_encriptada = clave_encriptada;
        }

        public bool EsFirmante { get; set; }

        public virtual bool ValidarClave(string clave)
        {
            return this.clave_encriptada == this.EncriptarSHA1(clave);
        }

        private string EncriptarSHA1(string CadenaOriginal)
        {
            HashAlgorithm hashValue = new SHA1CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(CadenaOriginal); byte[] byteHash = hashValue.ComputeHash(bytes);
            hashValue.Clear();
            return (Convert.ToBase64String(byteHash));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Id == ((Usuario)obj).Id; 
        } 
    }
}
