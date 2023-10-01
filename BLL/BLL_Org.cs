using ABS;
using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Org : IMetodosGenericos<Organizacion>
    {
        
        public bool Delete(Organizacion obj)
        {
            throw new NotImplementedException();
        }

        public Organizacion Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Organizacion> GetAll()
        {
            return new DAL_Org().GetAll();
        }

        public bool Insert(Organizacion obj)
        {
            return new DAL_Org().Insert(obj);
        }

        public bool Update(Organizacion obj)
        {
            return new DAL_Org().Update(obj);
        }

        public bool AsociarUsuario(Organizacion org, User usua)
        {
            return new DAL_Org().AsociarUsuario(usua.Id,org.id);
        }
    }
}
