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
        public bool GuardarCategoriaPosiciones(Categoria obj)
        {
            try
            {
                BLL_Equipo bllEq = new BLL_Equipo();

                foreach (Equipo eq in obj.equipos)
                {
                    bllEq.Update(eq);
                }

                return true;
            }
            catch (Exception ex)
            {   
                throw ex;
            }
            

        }

        public bool GuardarLogrado(Categoria obj, Natacion ev)
        {
            try
            {
                BLL_Equipo bllEq = new BLL_Equipo();

                foreach (Equipo eq in obj.equipos)
                {

                    if (ev.MetrosTotales == 0) //POSTA POR METROS
                    {
                        bllEq.UpdateParticipantes(eq);
                    }
                    else //POSTA POR TIEMPO
                    {
                        bllEq.UpdateParticipantes(eq);
                        bllEq.InsertParticipantesTiempo(eq);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Categoria CalcularPosicionCategoriaNatacion(Categoria obj, Natacion ev)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
            
        }

        public Categoria CalcularPosicionGeneralNatacion(List<Categoria> obj, Natacion ev)
        {
            try
            {
                Categoria general = new Categoria() { Nombre = "General"
                };

                foreach (Categoria obj2 in obj)
                {
                    general.equipos.AddRange(obj2.equipos);
                }

                if (ev.MetrosTotales == 0) //POSTA POR METROS
                {
                    general.equipos = general.equipos.OrderByDescending(equipo => equipo.MetrosTotal).ToList();
                }
                else //POSTA POR TIEMPO
                {
                    general.equipos = general.equipos.OrderBy(equipo => equipo.TiempoTotal).ToList();
                }


                //CALCULO POSICIONES
                for (int index = 0; index < general.equipos.Count; index++)
                {
                    general.equipos[index].PosicionGeneral = index + 1;
                }

                return general;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
