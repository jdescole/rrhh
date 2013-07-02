﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Modi;
using System.IO;
using System.Linq;

namespace General.Modi
{
    public class RepositorioDeLegajosEscaneados:IRepositorioDeLegajosEscaneados
    {
        private IFileSystem fileSystem;
        private string pathImagenes;
        public RepositorioDeLegajosEscaneados(IFileSystem un_file_system, string pathImagenes)
        {
            this.fileSystem = un_file_system; 
            this.pathImagenes = pathImagenes;
        }

        public List<ImagenModi> getImagenesParaUnLegajo(int legajo)
        {
            var listaImagenes = new List<ImagenModi>();
            List<String> paths_archivos;
            try
            {
                paths_archivos = this.fileSystem.getFiles(this.pathImagenes + "/" + legajo);
            }
            catch (ExcepcionDeCarpetaDeLegajoNoEncontrada e)
            {
                paths_archivos = new List<string>();
            }
            paths_archivos.ForEach(pathImagen =>
            {                
                listaImagenes.Add(new ImagenModi(Path.GetFileNameWithoutExtension(pathImagen)));
            });
            return listaImagenes;
        }

    }
}
