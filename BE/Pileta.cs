using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Pileta
    {
        public int id {  get; set; }
        public string Direccion { get;set; }
        public int Metros { get; set; }
        public int Carriles { get; set; }

        public Pileta() { }
        public Pileta(string direccion, int metros, int carriles)
        {
            Direccion = direccion;
            Metros = metros;
            Carriles = carriles;
        }
    }
}
