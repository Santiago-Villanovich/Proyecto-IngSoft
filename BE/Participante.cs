using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Participante
    {
        public User Usuario { get; set; }
        public TimeSpan tiempoPromedio { get;set; }
        public List<TimeSpan> tiempos { get; set; }
        public int MetrosLogrados { get; set; }
    }
}
