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
        public List<Equipo> GetAllInscriptos(int IdEvento)
        {
            List<Equipo> equipos = dal.GetInscriptos(IdEvento);
            foreach (Equipo equip in equipos)
            {
                equip.Participantes = dal.GetParticipantes(equip.Id);
            }

            return equipos;
        }
        public bool Cancel(Evento obj)
        {
            /*if (dal.Cancel(obj))
            {
                List<Equipo> inscriptos = GetAllInscriptos(obj.id);

                MailProvider mail = new MailProvider();
                string body = @"<style>
                            </style>
                            <h1>Este es el body del correo</h1></br>
                            <h2>Este es el segundo párrafo</h2>";

                foreach (var i in inscriptos)
                {
                    mail.sendMail($"{i.Email}", $"Evento {obj.nombre} cancelado", body);
                }

                return true;

            }else { return false; }*/

            throw new NotImplementedException();

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

        public List<Evento> GetAllByOrg()
        {
            List<Evento> list = dal.GetAllbyOrg(Session.GetInstance.Usuario.Organizacion.id);
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
    }
}
