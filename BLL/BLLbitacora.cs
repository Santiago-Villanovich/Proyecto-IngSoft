﻿using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLbitacora
    {
        public bool Insert(Bitacora bitacora)
        {
            return new DALbitacora().Insert(bitacora);
        }
    }
}
