using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DTO_BitacoraUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
    }
}
