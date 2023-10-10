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
        public bool InsertPostaMetros(Natacion_PostaMetros obj, int idEvento)
        {
            return new DAL_DeporteNatacion().InsertPostaMetros(obj, idEvento);
        }

        public  bool InsertPostaTiempo(Natacion_PostaTiempo obj, int idEvento)
        {
            return new DAL_DeporteNatacion().InsertPostaTiempo(obj, idEvento);
        }
    }
}
