using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Multilanguage
{
    public interface IIdioma
    {
        int Id { get; set; }
        string nombre { get; set; }
        bool isDefault { get; set; } 
    }
}
