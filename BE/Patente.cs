using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patente : Componente
    {
        public override IList<Componente> Hijos { get { return null; } }

        public Patente(string nombre) 
        {
            es_patente = true;
            Nombre = nombre;
        }

        public Patente()
        {
           
        }

        public override void AgregarHijo(Componente c)
        {

        }
    }
}
