using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public Organizacion Organizacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public double ValorInscripcion { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Deporte Deporte { get; set; }
        public int cupo { get; set; }
        public string estado { get; set; }
        public byte[] portada { get; set; }
       
        public Evento() { }

        public Categoria CalcularCategoriaEquipo(Equipo e)
        {
            int EdadSum = 0;
            Categoria c = null;
            var categoriasOrdenadas = this.Categorias.OrderBy(categoria => categoria.EdadInicio).ToList();

            foreach (var item in e.Participantes)
            {
                EdadSum += item.Usuario.Edad();
            }

            foreach (Categoria item in categoriasOrdenadas)
            {
                if (EdadSum >= item.EdadInicio && EdadSum <= item.EdadFin)
                {
                    c = item;
                }
            }

            if (c!= null)
            {
                return c;

            }else 
            {
                // Como la edad del grupo no coincide con las categorias lo asigno a la primera o ultima

                if (EdadSum <= categoriasOrdenadas.FirstOrDefault().EdadInicio)
                {
                    c = categoriasOrdenadas.FirstOrDefault();
                    return c;
                }
                else
                {
                    c = categoriasOrdenadas.Last();
                    return c;
                }
            }
        }
    }

    public class Categoria
    {
        public Guid id { get; set; }
        public string Nombre { get; set; }
        public int EdadInicio { get; set; }
        public int EdadFin { get; set; }
        public string str { get; }
        public List<Equipo> equipos { get; set; }

        public Categoria() {
            this.equipos = new List<Equipo>();
        }
        public Categoria(string nom, int min, int max) {
            this.Nombre = nom;
            this.EdadInicio = min;
            this.EdadFin = max;
            this.str = $"Categoria {nom}: entre {min} y {max} años";
            this.equipos = new List<Equipo>();
        }

        public override string ToString()
        {
            return $"Categoria {this.Nombre}: entre {this.EdadInicio} y {this.EdadFin} años";
        }
    }
}
