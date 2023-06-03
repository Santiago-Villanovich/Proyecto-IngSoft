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
        public IIdioma ObtenerIdiomaDefault()
        {
            return new DAL_Traductor().ObtenerIdiomaDefault();
        }

        public IList<IIdioma> ObtenerIdiomas()
        {
            return new DAL_Traductor().ObtenerIdiomas();
        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma) 
        {
            return new DAL_Traductor().ObtenerTraducciones(idioma);
        }

        public List<Traduccion> GetAllTerminos()
        {
            return new DAL_Traductor().GetAllTerminos(); 
        }

    }
        
}
