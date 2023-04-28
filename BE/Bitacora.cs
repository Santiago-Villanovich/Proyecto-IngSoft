using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int Id { get; set; }

        public string Detalle { get; set; } = null;

        public User Responsable { get; set; } = null;

        public DateTime Fecha { get; set; }


    }
}
