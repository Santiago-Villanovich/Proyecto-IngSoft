using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Natacion_PostaTiempo: Natacion
    {
        public double TiempoTotal { get; set; }
        public string Estilo { get; set; }
        public string Detalles { get; set; }
        public bool Elementos { get; set; }
        public Pileta Pileta { get; set; }
        public int cantidad_integrantes_equipo { get; set; }
        public int id_deporte {get; set; }
        public int id_tipo { get; set; }

        public Natacion_PostaTiempo() { }
    }
}
