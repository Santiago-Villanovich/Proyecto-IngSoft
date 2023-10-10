using ABS;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Evento : IMetodosGenericos<Evento>
    {
        public bool Delete(Evento obj)
        {
            throw new NotImplementedException();
        }

        public Evento Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Evento obj)
        {
            return new DAL_Evento().Insert(obj);
        }

        public int InsertAndInt (Evento obj)
        {
            return new DAL_Evento().InsertAndInt(obj);
        }

        
        public bool Update(Evento obj)
        {
            throw new NotImplementedException();
        }
    }
}
