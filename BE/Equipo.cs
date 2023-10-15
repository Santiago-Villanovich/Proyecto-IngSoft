using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Equipo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public List<Participante> Participantes { get; set;}
        public Categoria Categoria { get; set; }

        
    }

}
