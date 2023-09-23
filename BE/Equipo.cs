using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public List<Participante> Participantees { get; set;}
        public Categoria Categoria { get; set; }

        
    }

}
