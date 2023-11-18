using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ABS;
using BE;

namespace Services.SecurityAndValidation
{
    public static class GestorDigitoVerificador
    {
        public static string CalcularDV(IVerificable entity)
        {
            Type t = entity.GetType();
            string DV = string.Empty;
            var props = t.GetProperties();
            
            foreach (var item in props)
            {
                var atributos = item.GetCustomAttributes();
                var verificable = atributos.FirstOrDefault(i => i.GetType().Equals(typeof(VerificableProperty)));

                if (verificable != null)
                {
                    DV += item.GetValue(entity).ToString(); 
                }
            }

            return new HashCrypto().GenerarMD5(DV);
        }

        public static string CalcularDVTabla(IEnumerable<IVerificable> List)
        {
            string DVT = string.Empty;
            if (List!= null)
            {
                    
                foreach (IVerificable i in List)
                {
                    DVT += i.DV;
                }

            }

            return new HashCrypto().GenerarMD5(DVT);
        }
    }
}
