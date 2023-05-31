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

        public override void AgregarHijo(Componente c)
        {

        }
    }
}
