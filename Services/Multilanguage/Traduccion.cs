using ABS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Multilanguage
{
    public class Traduccion : ITraduccion
    {
        public ITermino termino { get; set; }
        public string texto { get; set; }
    }
}
