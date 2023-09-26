using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public class RegexValidation
    {
        public bool validarPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
                if (re.IsMatch(password))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Su contraseña debe contener:\n\t•Minimo 8 caracteres\n\t•Minimo 1 Mayuscula\n\t•Minimo 1 numero");
                }
            }
        }

        public bool validarNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^[a-zA-Z]+(?:\\s[a-zA-Z]+){0,2}$");
                if (re.IsMatch(nombre))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Su nombre o apellido no debe contener caracteres especiales");
                }
            }
        }

        public bool validarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (re.IsMatch(email))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Su nombre o apellido no debe contener caracteres especiales");
                }
            }
        }

        public bool validarTelefono(string tel)
        {
            if (string.IsNullOrEmpty(tel))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^(11|15)\d{8}$");
                if (re.IsMatch(tel))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Su nombre o apellido no debe contener caracteres especiales");
                }
            }
        }

        public bool validarPalabra(string palabra)
        {
            if (string.IsNullOrEmpty(palabra))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^([A-Za-zÑñÁáÉéÍíÓóÚú]+['\-_]{0,1}[A-Za-zÑñÁáÉéÍíÓóÚú]+)$");
                if (re.IsMatch(palabra))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Palabra invalida, no se aceptan caracteres numericos ni especiales.\nIngrese una nueva palabra");
                }
            }
        }

        public bool validarDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^\d{7,8}$");
                if (re.IsMatch(dni))
                {
                    return true;
                }
                else
                {
                    return false;
                    //throw new Exception("El dni ingresado contiene caracteres invalidos");
                }
            }
        }
    }
}
