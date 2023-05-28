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
    public class BLL_Permisos : IMetodosGenericos<Componente>
    {
        public bool Delete(int id)
        {
            return new DAL_Permisos().Delete(id);
        }

        public Componente Get(int id)
        {
            return new DAL_Permisos().Get(id);
        }

        public List<Componente> GetAll()
        {
            return new DAL_Permisos().GetAll();
        }

        public bool Insert(Componente obj)
        {
            return new DAL_Permisos().Insert(obj);
        }

        public bool Update(Componente obj)
        {
            return new DAL_Permisos().Update(obj);
        }

        public List<Componente> GetFamilia(int familia)
        {
            return new DAL_Permisos().GetFamilia(familia);
        }
    }
}

