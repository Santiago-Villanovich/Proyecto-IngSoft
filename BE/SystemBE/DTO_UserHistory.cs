using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DTO_UserHistory
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null;

        public string Apellido { get; set; } = null;

        public int DNI { get; set; }

        public string Clave { get; set; } = null;
        public DateTime Fecha { get; set; }
        public DTO_UserHistory() { }

        public string NombreApellido
        {
            get { return Nombre + " " + Apellido; }
        }
    }
}
