using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using System.Net;
using System.Security.Claims;
using Services;
using ABS;
using BE;
using DAL;
using Services.SecurityAndValidation;

namespace BLL
{
    public class BLL_User : IMetodosGenericos<User>
    {
        public bool Delete(User user)
        {
            try
            {
                return new DAL_User().Delete(user);
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = user;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw e;
            }
            
        }

        public User Get(int id)
        {
            try
            {
                return new DAL_User().Get(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return new DAL_User().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public bool Insert(User obj)
        {
            try
            {
                HashCrypto hash = new HashCrypto();
                var user = obj;
                user.Clave = hash.GenerarMD5(obj.Clave);
                user.DV = GestorDigitoVerificador.CalcularDV(user);
                var dal = new DAL_User().Insert(user);
                return true;
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = obj;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw e;
            }
            
        }

        public bool Register(User obj)
        {
            try
            {
                HashCrypto hash = new HashCrypto();
                var user = obj;
                user.Clave = hash.GenerarMD5(obj.Clave);
                user.DV = GestorDigitoVerificador.CalcularDV(user);
                var dal = new DAL_User().Insert(user);

                //Actualizo DV de tabla Users
                new BLL_DigitoVerificador().InsertDVTabla(this.GetAll(), "Users");

                //Genero logIn del nuevo usuario
                var loggedUser = new DAL_User().Login(user.DNI, user.Clave);
                if (loggedUser != null)
                {

                    Session.Login(user);
                    var bitacora = new Bitacora();
                    bitacora.Detalle = "Login de usuario";
                    bitacora.Responsable = user;
                    bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Informacion);
                    new BLL_Bitacora().Insert(bitacora);
                }

                return true;
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = obj;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw e;
            }
            
        }

        public bool Update(User obj)
        {
            try
            {
                return new DAL_User().Update(obj);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public User Login(int dni, string clave)
        {
            try
            {
                HashCrypto hash = new HashCrypto();
                string claveHash = hash.GenerarMD5(clave);

                var user = new DAL_User().Login(dni, claveHash);
                if (user != null)
                {
                    Session.Login(user);
                    var bitacora = new Bitacora();
                    bitacora.Detalle = "Login de usuario";
                    bitacora.Responsable = user;
                    bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Informacion);
                    new BLL_Bitacora().Insert(bitacora);
                }

                return user;
            }
            catch (Exception e)
            {
               /* var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = obj;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);*/
                throw e;
            }
            
        }

        public List<DTO_UserHistory> GetAllUserHistory(int? User, DateTime? from, DateTime? to, int page)
        {
            try
            {
                return new DAL_User().GetAllUserHistory(User, from, to, page);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool InsertUserHistory(DTO_UserHistory user)
        {
            return new DAL_User().InsertUserHistory(user);
        }

    }
}
