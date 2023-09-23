using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum BitacoraTipoEnum
    {
        Informacion,Error
    }
    public class BitacoraTipo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
