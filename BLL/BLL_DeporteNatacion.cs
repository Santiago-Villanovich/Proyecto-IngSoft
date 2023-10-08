using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DeporteNatacion
    {
        public int InsertPostaMetros(Natacion_PostaMetros obj)
        {
            return new DAL_DeporteNatacion().InsertPostaMetros(obj);
        }

        public int InsertPostaTiempo(Natacion_PostaTiempo obj)
        {
            return new DAL_DeporteNatacion().InsertPostaTiempo(obj);
        }
    }
}
