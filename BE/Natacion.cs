using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Natacion: Deporte
    {
        public int id { get; set; }
        public int id_tipo { get; set; }
        public string Estilo { get; set; }
        public string Detalles { get; set; }
        public bool Elementos { get; set; }
        public Pileta Pileta { get; set; }
        public int cantidad_integrantes_equipo { get; set; }


        public double MetrosTotales { get; set; }
        public double TiempoTotal { get; set; }

    }

    public enum Estilos
    {
        Libre,Espalda,Pecho,Mariposa,Medley
    }
}
