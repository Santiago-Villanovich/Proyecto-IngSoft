using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DTO_BitacoraUser
    {
        public string Detalle { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }
    }
}
