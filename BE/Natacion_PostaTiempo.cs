﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Natacion_PostaTiempo: Natacion
    {
        public double TiempoTotal { get; set; }
        public string Estilo { get; set; }
        public string Detalles { get; set; }
        public bool Elementos { get; set; }
        public Pileta Pileta { get; set; }


        public Natacion_PostaTiempo() { }
    }
}