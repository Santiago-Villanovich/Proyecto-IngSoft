using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Multilanguage
{
    public class TraduccionDTO
    {
        public TraduccionDTO() { }
        public int id { get; set; }
        public string termino { get; set; }
        public string traduccion { get; set; }
    }
}
