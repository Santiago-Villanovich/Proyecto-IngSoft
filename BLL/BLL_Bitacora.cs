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

        public List<Bitacora> GetAll()
        {
            return new DAL_Bitacora().GetAll();
<<<<<<< HEAD
=======
        }
        public List<DTO_BitacoraUser> GetAllBU()
        {
            return new DAL_Bitacora().GetAllBU();
>>>>>>> dab8ece2fd644bb8e4d51d45b8d22e27eebfbbc7
        }
    }
}
