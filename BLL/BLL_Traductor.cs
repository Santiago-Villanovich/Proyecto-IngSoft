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
                
                throw e;
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
           
                throw e;
            }

        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma) 
        {
            try
            {
                IDictionary<string,ITraduccion> traducciones = new DAL_Traductor().ObtenerTraducciones(idioma);
                IDictionary<string, ITraduccion> traDefault = new DAL_Traductor().ObtenerTraducciones(ObtenerIdiomaDefault());
                foreach (var item in traducciones)
                {
                    if (item.Value.texto == "" || item.Value.texto == null)
                    {
                        item.Value.texto = traDefault[item.Key].texto;
                    }
                }
                return traducciones;
            }
            catch (Exception e)
            {
                throw e;
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
