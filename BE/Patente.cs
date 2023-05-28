using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patente : Componente
    {
<<<<<<< HEAD
        public Patente(string nombre) : base(nombre)
        {

        }

        public override void AgregarHijo(Componente permiso)
        {
            
        }

        public override IList<Componente> ObtenerHijos()
        {
            return null;
        }
=======
        public override IList<Componente> Hijos { get { return null; } }

        public override void AgregarHijo(Componente c)
        {
            
        }
>>>>>>> mati
    }
}
