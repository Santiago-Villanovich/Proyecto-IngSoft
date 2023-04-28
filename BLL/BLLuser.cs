using BE;
using ABS;
using Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BLL
{
    public class BLLuser : IMetodosGenericos<User>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            return new DALuser().GetAll();
        }

        public bool Insert(User obj)
        {
            HashCrypto hash = new HashCrypto();
            var user = obj;
            user.Clave = hash.GenerarMD5(obj.Clave);
            var dal = new DALuser().Insert(user);
            return true;
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }

        public User Login(int dni, string clave)
        {
            var user = new DALuser().Login(dni, clave);
            if (user != null)
            {
                Session.Login(user);
                var bitacora = new Bitacora();
                bitacora.Detalle = "Login de usuario";
                bitacora.Responsable = user;
                bitacora.Fecha = DateTime.Now;
                new BLL_Bitacora().Insert(bitacora);
            }

            return user;
        }

    }
}
