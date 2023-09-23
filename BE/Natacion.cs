using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface Natacion: Deporte
    {
        string Estilo { get; set; }
        string Detalles { get; set; }
        bool Elementos { get; set; }
        Pileta Pileta { get; set; }
        
    }
}
