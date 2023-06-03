using Services.Multilanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Observer : IObserver
    {
        private Idioma IidiomaActual { get; set; }

        public void Notify(Idioma idioma)
        {
            throw new NotImplementedException();
        }
    }
}
