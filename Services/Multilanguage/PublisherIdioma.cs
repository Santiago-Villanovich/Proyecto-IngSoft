using Services.Multilanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PublisherIdioma : IPublisherIdioma
    {
        private List<IObserver> _forms;
        public PublisherIdioma()
        {
            _forms = new List<IObserver>();
        }

        public void Notify(Idioma idioma)
        {
            foreach(IObserver observer in _forms)
            {
                observer.Notify(idioma);
            }
        }

        public void Subscribe(IObserver observer)
        {
            _forms.Add(observer);   
        }

        public void Unsuscribe(IObserver observer)
        {
            _forms.Remove(observer);
        }

        
    }
}
