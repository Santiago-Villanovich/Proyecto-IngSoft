using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABS;
using DAL;



namespace Services.Multilanguage
{
    public class BLL_Traductor
    {
        public bool InsertIdioma(IIdioma idioma) 
        {
            return new DAL_Traductor().InsertIdioma(idioma);
        }
        public IIdioma ObtenerIdiomaDefault()
        {
            return new DAL_Traductor().ObtenerIdiomaDefault();
        }

        public IIdioma GetIdiomaLastAdded()
        {
            return new DAL_Traductor().GetLastIdiomaAdded();
        }

        public IList<IIdioma> ObtenerIdiomas()
        {
            return new DAL_Traductor().ObtenerIdiomas();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma) 
        {
            return new DAL_Traductor().ObtenerTraducciones(idioma);
        }

        public bool InsertTraducciones(List<Traduccion> lista, Idioma idioma)
        {
            return new DAL_Traductor().InsertTraduccion(lista, idioma);
        }

        public List<Traduccion> GetAllTerminos()
        {

            return new DAL_Traductor().GetAllTerminos(); 
        }

        public List<TraduccionDTO> GetAllTerminosDTO()
        {
            List<TraduccionDTO> traduccionDTOs = new List<TraduccionDTO>();
            foreach (var item in new DAL_Traductor().GetAllTerminos())
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

    }
        
}
