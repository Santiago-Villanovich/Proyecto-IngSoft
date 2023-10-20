﻿using ABS;
using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Equipo : IMetodosGenericos<Equipo>
    {

        DAL_Equipo dal = new DAL_Equipo();

        public bool Delete(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public Equipo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Equipo> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Equipo> GetAllEquiposEvento(int IdEvento)
        {
            try
            {
                List<Equipo> equipos = dal.GetAllEquiposEvento(IdEvento);
                foreach (Equipo equip in equipos)
                {
                    equip.Participantes = GetParticipantes(equip);
                }

                return equipos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Participante> GetParticipantes(Equipo eq)
        {
            List<Participante> list =  dal.GetParticipantes(eq.Id);
            foreach (Participante participante in list)
            {
                participante.Usuario.Email = HashCrypto.Desencriptar(participante.Usuario.Email);
            }

            return list;
        }

        public bool Insert(Equipo obj,int idEvento)
        {
            try
            {
                Guid id = Guid.NewGuid();
                obj.Id = id;
                if (dal.Insert(obj, idEvento))
                {
                    foreach (var item in obj.Participantes)
                    {
                        dal.InsertParticipante(item,id,idEvento);
                    }
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Equipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
