using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Services;
using BE;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Services.SecurityAndValidation;
using ABS;

namespace BLL
{
    public class BLL_DigitoVerificador
    {
        public BLL_DigitoVerificador() { }

        public bool InsertDVTabla(IEnumerable<IVerificable> list, string Nom)
        {
            try
            {
                string DVT = GestorDigitoVerificador.CalcularDVTabla(list);
                return new DAL_DigitoVerificador().InsertDVTabla(Nom, DVT);
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }

        public bool VerificarEstadoTabla(IEnumerable<IVerificable> list, string Nom)
        {
            try
            {
                string DVfromList = GestorDigitoVerificador.CalcularDVTabla(list);
                string DVinBD = new DAL_DigitoVerificador().GetDVTabla(Nom);
                if (DVfromList == DVinBD)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                var bitacora = new Bitacora();
                bitacora.Detalle = e.Message;
                bitacora.Responsable = Session.GetInstance.Usuario;
                bitacora.Tipo = Convert.ToInt32(BitacoraTipoEnum.Error);
                new BLL_Bitacora().Insert(bitacora);
                throw;
            }

        }
    }
}
