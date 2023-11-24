using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Participante
    {
        public Guid Id { get; set; }
        public User Usuario { get; set; }
        public TimeSpan TiempoPromedio { get;set; }
        public List<TimeSpan> Tiempos { get; set; }
        public int MetrosLogrados { get; set; }
        public DateTime fecha { get; set; }

        public Participante() { }

        public Participante(User usuario)
        {
            Usuario = usuario;
            Tiempos = new List<TimeSpan>();
        }
    }
}
