using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Categoria
    {
        public void GuardarCategoriaCompleta(Categoria obj)
        {
            BLL_Equipo bllEq = new BLL_Equipo();

            foreach (Equipo eq in obj.equipos)
            {
                bllEq.Update(eq);
            }

        }

        public Categoria CalcularPosicionCategoriaNatacion(Categoria obj, Natacion ev)
        {
            if (ev.MetrosTotales == 0) //POSTA POR METROS
            {
                obj.equipos = obj.equipos.OrderByDescending(equipo => equipo.MetrosTotal).ToList();
            }
            else //POSTA POR TIEMPO
            {
                obj.equipos = obj.equipos.OrderBy(equipo => equipo.TiempoTotal).ToList();
            }

            for (int index = 0; index < obj.equipos.Count; index++)
            {
                obj.equipos[index].PosicionCategoria = index + 1;
            }

            return obj;
        }

        public Categoria CalcularPosicionGeneralNatacion(List<Categoria> obj, Natacion ev)
        {
            Categoria general = new Categoria() { Nombre = "General" };

            foreach (Categoria obj2 in obj)
            {
                general.equipos.AddRange(obj2.equipos);
            }

            return CalcularPosicionCategoriaNatacion(general, ev);
        }
    }
}
