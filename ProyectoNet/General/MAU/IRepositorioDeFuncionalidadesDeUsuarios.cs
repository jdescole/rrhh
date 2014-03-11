﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public interface IRepositorioDeFuncionalidadesDeUsuarios
    {
        List<Funcionalidad> FuncionalidadesPara(Usuario usuario);
        List<Funcionalidad> FuncionalidadesPara(int id_usuario);
        void ConcederFuncionalidadA(Usuario usuario, Funcionalidad funcionalidad);
        void ConcederFuncionalidadA(int id_usuario, int id_funcionalidad);
        void DenegarFuncionalidadA(int id_usuario, int id_funcionalidad);
    }
}
