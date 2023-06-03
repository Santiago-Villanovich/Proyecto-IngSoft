using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface ITraduccion
    {
        ITermino termino { get; set; }
        string texto { get; set; }
    }
}
