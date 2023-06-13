using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABS;

namespace BE
{
    public class User: IVerificable
    {
        public int Id { get; set; }

        [VerificableProperty]
        public string Nombre { get; set; } = null;

        [VerificableProperty]
        public string Apellido { get; set; } = null;
        
        [VerificableProperty]
        public int DNI { get; set; }

        public string Clave { get; set; } = null;

        public bool isAdmin { get; set; } = false;

        public string DV { get; set; }

        public User() { }
    }
}
