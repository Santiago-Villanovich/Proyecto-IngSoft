using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABS;
using DAL;
using BE;
using BLL;

namespace Services.Multilanguage
{
    public class BLL_Traductor
    {
        public bool InsertIdioma(IIdioma idioma) 
        {
            try
            {
                return new DAL_Traductor().InsertIdioma(idioma);
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
        public IIdioma ObtenerIdiomaDefault()
        {
            try
            {
                return new DAL_Traductor().ObtenerIdiomaDefault();
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

        public IIdioma GetIdiomaLastAdded()
        {
            try
            {
                return new DAL_Traductor().GetLastIdiomaAdded();
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

        public IList<IIdioma> ObtenerIdiomas()
        {
            try
            {
                return new DAL_Traductor().ObtenerIdiomas();
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

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma) 
        {
            try
            {
                return new DAL_Traductor().ObtenerTraducciones(idioma);
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

        public bool InsertTraducciones(List<Traduccion> lista, Idioma idioma)
        {
            try
            {
                return new DAL_Traductor().InsertTraduccion(lista, idioma);
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

        public bool UpdateTraducciones(List<Traduccion> lista, Idioma idioma)
        {
            try
            {
                return new DAL_Traductor().UpdateTraduccion(lista, idioma);
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

        public List<Traduccion> GetAllTerminos()
        {
            try
            {
                return new DAL_Traductor().GetAllTerminos();
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

        public List<TraduccionDTO> GetAllTerminosDTO(Idioma idioma = null)
        {
            try
            {
                List<TraduccionDTO> traduccionDTOs = new List<TraduccionDTO>();
                foreach (var item in new DAL_Traductor().GetAllTerminos(idioma))
                {
                    traduccionDTOs.Add(new TraduccionDTO
                    {
                        id = item.termino.id,
                        termino = item.termino.termino,
                        traduccion = item.texto
                    }
                    );
                }
                return traduccionDTOs;
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
