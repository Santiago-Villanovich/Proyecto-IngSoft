using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bitacora
    {
        public bool Insert(Bitacora bitacora)
        {
            return new DAL_Bitacora().Insert(bitacora);
        }
    }
}
