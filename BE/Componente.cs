using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool es_patente { get; set; }

        public  abstract IList<Componente> Hijos { get; }

        public abstract void AgregarHijo(Componente c);


    }
}
