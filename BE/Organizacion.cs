using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Organizacion
    {
        public int id {  get; set; }
        public string CUIT { get; set; } 
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string DireccionWeb { get; set; }

        public Organizacion() { }
        public Organizacion(string cUIT, string nombre, string email, string direccionWeb)
        {
            CUIT = cUIT;
            Nombre = nombre;
            Email = email;
            DireccionWeb = direccionWeb;
        }
    }
}
