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
        public TimeSpan TiempoTotal { get; set; }
        public int MetrosTotal { get; set; }
        public int PosicionGeneral { get; set; }
        public int PosicionCategoria { get; set; }
        public void CalcularTiempoTotal()
        {
           
            if (this.Participantes != null && this.Participantes.Any())
            {
                TimeSpan t = TimeSpan.Zero;
                foreach (var p in this.Participantes)
                {
                    if (p.Tiempos != null && p.Tiempos.Any())
                    {
                        t += p.Tiempos.Aggregate(TimeSpan.Zero, (subtotal, tiempo) => subtotal + tiempo);
                    }
                }

                this.TiempoTotal = t;
            }
            else
            {
                this.TiempoTotal = TimeSpan.Zero;
            }
        }

        public void CalcularMetrosTotal()
        {
            if (this.Participantes != null && this.Participantes.Any())
            {
                int m = 0;
                foreach (var p in this.Participantes)
                {
                    if (p.MetrosLogrados != 0)
                    {
                        m += p.MetrosLogrados;
                    }
                }

                this.MetrosTotal = m;
            }
            else
            {
                this.MetrosTotal = 0;
            }
        }

    }


}
