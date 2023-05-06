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
                    throw new Exception("Su contrasena debe contener:\nMinimo 8 caracteres\n1 Mayuscula\nMin 1 numero");
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
