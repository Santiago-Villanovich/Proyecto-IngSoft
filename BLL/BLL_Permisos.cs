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
                if (permisosFamilia.Count > 0)
                {
                    throw new Exception("Este permiso tiene hijos, no se puede eliminar");
                }
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

        public List<Componente> GetFamilias()
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

        public Componente GetFamiliaPorNombre(string nombre)
        {
            return new DAL_Permisos().GetFamiliaPorNombre(nombre);
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

        public void AgregarPermiso(Componente permiso, int idPadre)
        {
            try
            {
                new DAL_Permisos().AgregarPermiso(permiso, idPadre);
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

