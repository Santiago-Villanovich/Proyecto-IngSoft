using ABS;
using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Permisos : IMetodosGenericos<Componente>
    {
        public bool Delete(Componente id)
        {
            try
            {
                var permisosFamilia = GetPermisosFamilia(id.Id);
                return new DAL_Permisos().Delete(id);
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
            throw new NotImplementedException();
        }

        public bool Update(Componente obj)
        {
            return new DAL_Permisos().Update(obj);
        }

        public List<Familia> GetFamilias()
        {
            return new DAL_Permisos().GetFamilias();
        }

        public List<Componente> GetPermisosFamilia(int familia)
        {
            return new DAL_Permisos().GetPermisosFamilia(familia);
        }


        public List<Componente> GetAllPermisos()
        {
            try
            {
                List<Componente> AllPermisos = new List<Componente>();
                var familias = new DAL_Permisos().GetFamilias();

                foreach (var familia in familias)
                {
                    var permisosFamilia = LlenarFamilia(familia);
                    AllPermisos.Add(permisosFamilia);

                }

                return AllPermisos;
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

        public Componente GetComponentePorNombre(string nombre)
        {
            return new DAL_Permisos().GetComponentePorNombre(nombre);
        }

        public List<Componente> GetAllComponentes()
        {
            return new DAL_Permisos().GetAllComponentes();
        }

        public Componente LlenarFamilia(Componente parent)
        {
            try
            {
                List<Componente> HijosFamilia = new DAL_Permisos().GetPermisosFamilia(parent.Id);


                foreach (var item in HijosFamilia)
                {
                    parent.AgregarHijo(item);
                }

                return parent;
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

        public List<Patente> ObtenerPatentes()
        {
            try
            {
                return new DAL_Permisos().ObtenerPatentes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AgregarPermiso(Componente permiso)
        {
            try
            {
                new DAL_Permisos().AgregarPermiso(permiso);
                Componente familia = new DAL_Permisos().GetComponentePorNombre(permiso.Nombre);

                if (!permiso.es_patente && permiso.Hijos != null && permiso.Hijos.Count > 0)
                {
                    permiso.Hijos.ToList().ForEach(i =>
                    {
                        new DAL_Permisos().AgregarPatentePermiso(i, familia.Id);
                    });
                }
                
                var bitacora = new Bitacora();
                bitacora.Detalle = "Agrego nuevo permiso";
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Informacion);
                new BLL_Bitacora().Insert(bitacora);
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
    }
}

