using ABS;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_Pileta : IMetodosGenericos<Pileta>
    {
        public bool Delete(Pileta obj)
        {
            throw new NotImplementedException();
        }

        public Pileta Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pileta> GetAll()
        {
            return new DAL_Pileta().GetAll();
        }

        public bool Insert(Pileta obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pileta obj)
        {
            throw new NotImplementedException();
        }
    }
}
