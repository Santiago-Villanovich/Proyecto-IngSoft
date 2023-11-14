using ABS;
using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Evento : IMetodosGenericos<Evento>
    {
        DAL_Evento dal = new DAL_Evento();  
        public bool Delete(Evento obj)
        {
            throw new NotImplementedException();
        }
        
        public bool Cancel(Evento obj)
        {
            if (dal.UpdateEstado(obj,3))
            {
                List<Equipo> equips = new BLL_Equipo().GetAllEquiposEvento(obj.id);
                List<string> to = new List<string>();

                MailProvider mail = new MailProvider();
                string body = $"Lamentamos informarle que el evento '{obj.nombre}' del {obj.Fecha} fue cancelado. " +
                              $"Por lo que se le reintegrara el coste de la inscripcion ${obj.ValorInscripcion}";
                

                foreach (var e in equips)
                {
                    foreach (var p in e.Participantes)
                    {
                        to.Add(p.Usuario.Email.Trim());
                    }
                }

                mail.sendMail(to,"Cancelacion de Competencia",body);
                

                return true;

            }
            else { return false; }

            throw new NotImplementedException();

        }

        public bool CerrarInscripcion(Evento obj)
        {
            if (UpdateEstado(obj, 4))
            {
                return true;
            }
            else { return false; }

        }

        public bool TerminarEvento(Evento obj,Categoria cat)
        {
            if (UpdateEstado(obj, 5))
            {
                foreach(Equipo e in cat.equipos)
                {

                }

                return true;
            }
            else { return false; }
        }

        public Evento Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            List<Evento> list = dal.GetAll();
            foreach (Evento obj in list) 
            {
                obj.Deporte = new DAL_DeporteNatacion().Get(obj.id);
                obj.Categorias = dal.GetCategorias(obj.id);
            }

            return list;
        }

        public List<Evento> GetAllByOrg_publicado()
        {
            List<Evento> list = dal.GetAllbyOrg(Session.GetInstance.Usuario.Organizacion.id,2);
            foreach (Evento obj in list)
            {
                obj.Deporte = new DAL_DeporteNatacion().Get(obj.id);
                obj.Categorias = dal.GetCategorias(obj.id);
            }

            return list;
        }

        public List<Evento> GetAllByOrg_estado(int idEstado)
        {
            List<Evento> list = dal.GetAllbyOrg(Session.GetInstance.Usuario.Organizacion.id, idEstado);
            foreach (Evento obj in list)
            {
                obj.Deporte = new DAL_DeporteNatacion().Get(obj.id);
                obj.Categorias = dal.GetCategorias(obj.id);
                obj.Categorias = CalcularCategorias(obj);
            }

            return list;
        }

        public List<Evento> GetAllByUser()
        {
            List<Evento> list = dal.GetAllbyUser(Session.GetInstance.Usuario.Id);
            foreach (Evento obj in list)
            {
                obj.Deporte = new DAL_DeporteNatacion().Get(obj.id);
                obj.Categorias = dal.GetCategorias(obj.id);
            }

            return list;
        }

        public bool Insert(Evento obj)
        {
            return dal.Insert(obj);
        }

        public int InsertAndInt (Evento obj)
        {
            return dal.InsertAndInt(obj);
        }

        
        public bool Update(Evento obj)
        {
            return dal.Update(obj);
        }

        private bool UpdateEstado(Evento obj,int id)
        {
            return dal.UpdateEstado(obj,id);
        }

        public bool isCuposLlenos(Evento ev)
        {
            return dal.isCuposLlenos(ev);
        }

        public List<Categoria> CalcularCategorias(Evento evento)
        {
            try
            {
                List<Equipo> equiposInscriptos = new BLL_Equipo().GetAllEquiposEvento(evento.id);
                int flag = 0;

                foreach (var cat in evento.Categorias)
                {
                    cat.equipos = equiposInscriptos.Where(eq => eq.Categoria.id == cat.id).ToList();
                    flag += cat.equipos.Count;
                }

                if (flag == equiposInscriptos.Count)
                {
                    return evento.Categorias;
                }
                else
                {
                    throw new Exception("Ha ocurrido un error calculando las categorias del evento. Informe a soporte");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
