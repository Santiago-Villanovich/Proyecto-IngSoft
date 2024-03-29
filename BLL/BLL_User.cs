﻿using System;
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
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public User Get(int id)
        {
            try
            {
                User user = new DAL_User().Get(id);
                user.Email = HashCrypto.Desencriptar(user.Email);
                return user;
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
                List<User> users = new DAL_User().GetAll();
                foreach (var u in users)
                {
                    u.Email = HashCrypto.Desencriptar(u.Email);
                }
                return users;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public List<User> GetAllByPermiso(int permiso)
        {
            try
            {
                List<User> users = new DAL_User().GetAllByPermiso(permiso);
                foreach (var u in users)
                {
                    u.Email = HashCrypto.Desencriptar(u.Email);
                }
                return users;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool Insert(User obj) // Revisar uso de metodo
        {
            try
            {
                HashCrypto hash = new HashCrypto();
                var user = obj;
                user.Clave = hash.GenerarMD5(obj.Clave);
                user.DV = GestorDigitoVerificador.CalcularDV(user);
                user.Email = HashCrypto.Encriptar(obj.Email);

                var dal = new DAL_User().Insert(user);
                return true;
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public bool Register(User obj)
        {
            try
            {
                HashCrypto hash = new HashCrypto();
                var user = obj;
                user.Clave = hash.GenerarMD5(obj.Clave);
                user.Email = HashCrypto.Encriptar(obj.Email);
                user.DV = GestorDigitoVerificador.CalcularDV(user);
                
                var dal = new DAL_User().Insert(user);

                
                //Actualizo DV de tabla Users
                new BLL_DigitoVerificador().InsertDVTabla(this.GetAll(), "Users");

                //Genero logIn del nuevo usuario
                var loggedUser = new DAL_User().Login(user.DNI, user.Clave);
                if (loggedUser != null)
                {
                    //Agrego permisos de usuario
                    Componente comp = new BLL_Permisos().GetComponentePorNombre("Usuario");
                    AgregarPermiso(comp,loggedUser);

                    Session.Login(loggedUser);

                    var bitacora = new Bitacora();
                    bitacora.Detalle = "Registro de usuario";
                    bitacora.Responsable = loggedUser;
                    bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Informacion);
                    new BLL_Bitacora().Insert(bitacora);
                }

                return true;
            }
            catch (Exception e)
            {
                /*var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);*/
                throw e;
            }

        }

        public bool Update(User obj)
        {
            try
            {
                obj.Email = HashCrypto.Encriptar(obj.Email);
                return new DAL_User().Update(obj);
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
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
                    user.Email = HashCrypto.Desencriptar(user.Email);
                    user.Permisos = new BLL_Permisos().GetPermisosUser(user);
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
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public List<DTO_UserHistory> GetAllUserHistory(int? User, DateTime? from, DateTime? to, int page)
        {
            try
            {
                var lista = new DAL_User().GetAllUserHistory(User, from, to, page);
                foreach (var item in lista)
                {
                    item.Mail = HashCrypto.Desencriptar(item.Mail);

                }
                return lista;
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public bool InsertUserHistory(DTO_UserHistory user)
        {
            try
            {
                return new DAL_User().InsertUserHistory(user);
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }
        }

        public bool recursiva(int id, IList<Componente> roles)
        {
            foreach (Componente rol in roles)
            {
                if (rol.Id == id) return true;
                if (rol.Hijos != null) return recursiva(id, rol.Hijos);
            }
            return false;
        }

        public bool tiene_permiso(User usua,int id)
        {
            foreach (Componente rol in usua.Permisos)
            {
                if (rol.Id == id) return true;
                if (rol.Hijos != null)
                {
                    if (recursiva(id, rol.Hijos)) return true;

                }
            }
            return false;
        }

        public bool AgregarPermiso(Componente permiso, User user)
        {
            try
            {
                return new DAL_User().AgregarPermiso(permiso, user);
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public Organizacion GetUserOrg(int id)
        {
            return new DAL_User().GetUserOrg(id);
        }
    }
}
