﻿using System;
using System.Collections.Generic;

using System.Text;

namespace General
{
    public interface IRepositorioMediosDePago
    {
        List<MedioDePago> GetTodosLosMediosDePago();
    }
}