using ABS;
using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class DAL_Equipo : IMetodosGenericos<Equipo>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        private string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;


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
        public List<Equipo> GetAllEquiposEvento(int idEvento)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                List<Equipo> list = new List<Equipo>();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEventoEquipos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_evento", idEvento);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var equip = new Equipo()
                            {
                                Nombre = reader["nombre"].ToString(),
                                Categoria = new Categoria() { Nombre = reader["categoria"].ToString() }


                            };

                            list.Add(equip);
                        }

                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Participante> GetParticipantes(Guid idEquipo)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                List<Participante> list = new List<Participante>();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEquipoParticipantes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_equipo", idEquipo);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var par = new Participante()
                            {
                                MetrosLogrados = Convert.ToInt32(reader["metros"]),
                                tiempoPromedio = TimeSpan.Parse(reader["tiempo"].ToString()),
                                Usuario = new User()
                                {
                                    Id = Convert.ToInt32(reader["Id"].ToString()),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    DNI = Convert.ToInt32(reader["DNI"].ToString()),
                                    Email = reader["Email"].ToString(),
                                    Telefono = reader["Telefono"].ToString(),
                                    FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"])
                                }

                            };

                            list.Add(par);
                        }

                    }
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool Insert(Equipo obj, int idEvento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertEquipo", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@id_evento", idEvento);
                    cmd.Parameters.AddWithValue("@nom", obj.Nombre);
                    cmd.Parameters.AddWithValue("@cat", obj.Categoria.Nombre);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool Insert(Equipo obj)
        {
            throw new NotImplementedException();
        }

        public bool InsertParticipante(Participante obj, Guid idEquipo, int idEvento)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertParticipante", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_user", obj.Usuario.Id);
                    cmd.Parameters.AddWithValue("@id_equipo", idEquipo);
                    cmd.Parameters.AddWithValue("@id_evento", idEvento);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public bool Update(Equipo obj)
        {
            throw new NotImplementedException();
        }
    }
}
