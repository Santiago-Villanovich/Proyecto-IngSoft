using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface Natacion: Deporte
    {
        int id { get; set; }
        string Estilo { get; set; }
        bool Elementos { get; set; }
        int cantidad_integrantes_equipo { get; set; }
        Pileta Pileta { get; set; }
        
    }

    public enum Estilos
    {
        Libre,Espalda,Pecho,Mariposa,Medley
    }
}
