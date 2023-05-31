using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Multilanguage
{
    public class Idioma : IIdioma
    {
        public string nombre { get; set; }
        public bool isDefault { get; set; }
        public int Id { get; set; }
    }
}
