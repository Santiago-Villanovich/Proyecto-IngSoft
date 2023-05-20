using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Permiso : Componente
    {
        List<Componente> _hijos;

        public Permiso(string nombre): base(nombre)
        {
            _hijos = new List<Componente>();
        }

        public override void AgregarHijo(Componente permiso)
        {
            _hijos.Add(permiso);
        }

        public override IList<Componente> ObtenerHijos()
        {
            return _hijos.ToArray();
        }
    }
}
