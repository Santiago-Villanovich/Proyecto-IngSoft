﻿using System;
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
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        [VerificableProperty]
        public string Clave { get; set; } = null;
        public string DV { get; set; }

        public List<Familia> Permisos = new List<Familia>();

        public Organizacion Organizacion { get; set; }


        public User() { }

        public string NombreApellido
        {
            get { return Nombre + " " + Apellido; }
        }

        public int Edad()
        {
            int edad;
            DateTime Now = DateTime.Now;
            edad = Now.Year - this.FechaNacimiento.Year;
            return edad;
        }
    }
}
