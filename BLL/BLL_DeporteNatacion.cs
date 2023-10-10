using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ABS;

namespace BLL
{
    public class BLL_DeporteNatacion : IMetodosGenericos<Natacion>
    {
        public bool Delete(Natacion obj)
        {
            throw new NotImplementedException();
        }

        public Natacion Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Natacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Natacion obj)
        {
            return new DAL_DeporteNatacion().Insert(obj);
        }

        public bool Update(Natacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
