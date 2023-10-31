using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services
{
    public static class RegexValidation
    {
        public static bool validarPassword(string password)
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

        public static bool validarNombre(string nombre)
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

        public static bool validarEmail(string email)
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

        public static bool validarTelefono(string tel)
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

        public static bool validarPalabra(string palabra)
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

        public static bool validarDni(string dni)
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
                    throw new Exception("El dni ingresado contiene caracteres invalidos");
                }
            }
        }

        public static bool validarCUIT(string dni)
        {
            if (string.IsNullOrEmpty(dni))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^\b(30|33|34)(\-)?[0-9]{8}(\-)?[0-9]{1}?$");
                if (re.IsMatch(dni))
                {
                    return true;
                }
                else
                {
                    throw new Exception("El CUIT ingresado contiene caracteres invalidos");
                }
            }
        }

        public static bool validarNum(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^\d*$");
                if (re.IsMatch(texto))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Debe ingresar un numero valido");
                }
            }
        }

        public static bool validarTiempo(string tiempo)
        {
            if (string.IsNullOrEmpty(tiempo))
            {
                return false;
            }
            else
            {
                Regex re = new Regex(@"^(?:(?:[0-5]?[0-9][:.])?[0-5]?[0-9][:.]?[0-5]?[0-9])$");
                if (re.IsMatch(tiempo))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Valor ingresado invalido. Ej: 01:10:09 o 00.10.11");
                }
            }
        }
    }
}
