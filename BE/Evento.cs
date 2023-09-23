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
        public Array Categorias { get;}
        public Deporte Deporte { get; set; }
        
        public bool SetCategoria()
        {
            return false;
        }
    }

    public class Categoria
    {
        public string Nombre { get; set; }
        public int EdadInicio { get; set; }
        public int EdadFin { get; set; }
    }
}
