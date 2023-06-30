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
            try
            {
                return new DAL_Bitacora().GetAll();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public List<DTO_BitacoraUser> GetAllBU(int? User, DateTime? from, DateTime? to, int? tipo, int page)
        {
            try
            {
                return new DAL_Bitacora().GetAllBU(User, from, to, tipo, page);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<BitacoraTipo> GetAllBT()
        {
            try
            {
                return new DAL_Bitacora().GetAllBT();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
