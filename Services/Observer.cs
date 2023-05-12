using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Observer : IObserver
    {
        private string IidiomaActual { get; set; }
        public void Notify(string idioma)
        {
            throw new NotImplementedException();
        }
    }
}
