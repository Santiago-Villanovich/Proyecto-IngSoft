using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia: Componente
    {
        private IList<Componente> _hijos;

        public Familia()
        {
            _hijos = new List<Componente>();
        }

        public override IList<Componente> Hijos { get; set; }

        public override void AgregarHijo(Componente c)
        {
            _hijos.Add(c);
        }

    }
}
