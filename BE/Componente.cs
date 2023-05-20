using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        int _id;

        string _nombre;

        public Componente  (string nombre)
        {
            _nombre = nombre;
            
        }

        public Componente(string nombre, int id)
        {
            _nombre = nombre;
            _id = id;

        }

        public string Nombre { get { return _nombre; } }

        public int Id { get { return _id; } }

        public abstract void AgregarHijo(Componente permiso);

        public abstract IList<Componente> ObtenerHijos();


    }
}
