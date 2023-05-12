using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Services
{
    public class Session
    {
        private static Session _session = null;

        public User Usuario { get; set; }

        public DateTime FechaInicio { get; set; }

        private static object _lock = new object();

        public static PublisherIdioma _publisherIdioma;

        public static string IdiomaActual { get; set; } = "ES";


        public static Session GetInstance
        {
            get
            {
                if (_session == null) new Session();
                return _session;
            }
        }
        private Session() { }

        public static void Login(User user)
        {
            lock (_lock)
            {
                if (_session == null)
                {
                    _session.Usuario = user;
                    _session.FechaInicio = DateTime.Now;

                }
                else
                {
                    throw new Exception("La sesion ya esta iniciada");
                }

            }

        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("La sesion no esta iniciada");
                }
            }

        }

        public static void CambiarIdioma(string idioma)
        {
            IdiomaActual = idioma;
            _publisherIdioma.Notify(idioma);
        }

    }
}
