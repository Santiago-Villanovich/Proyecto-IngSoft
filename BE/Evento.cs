using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento
    {
        public Organizacion Organizacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double ValorInscripcion { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Deporte Deporte { get; set; }
        public int cupo { get; set; }
        
        public Evento() { }
    }

    public class Categoria
    {
        public string Nombre { get; set; }
        public int EdadInicio { get; set; }
        public int EdadFin { get; set; }
        public string str { get; }

        public Categoria() { }
        public Categoria(string nom, int min, int max) {
            this.Nombre = nom;
            this.EdadInicio = min;
            this.EdadFin = max;
            this.str = $"Categoria {nom}: entre {min} y {max} años";
        }

        public override string ToString()
        {
            return $"Categoria {this.Nombre}: entre {this.EdadInicio} y {this.EdadFin} años";
        }
    }
}
