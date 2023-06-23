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
        public bool Delete(Componente id)
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
            List<Componente> AllPermisos = new List<Componente>();
            var familias = new DAL_Permisos().GetFamilias();

            foreach (var familia in familias)
            {
                var permisosFamilia = LlenarFamilia(familia);
                AllPermisos.Add(permisosFamilia);

            }

            return AllPermisos;

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
            List<Componente> HijosFamilia = new DAL_Permisos().GetPermisosFamilia(parent.Id);


            foreach (var item in HijosFamilia)
            {
                parent.AgregarHijo(item);
            }

            return parent;
        }

        public void AgregarPermiso(Componente permiso, int idPadre)
        {
             new DAL_Permisos().AgregarPermiso(permiso, idPadre);
        }
    }
}

