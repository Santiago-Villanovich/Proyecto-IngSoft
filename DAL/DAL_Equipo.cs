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
                    SqlCommand cmd = new SqlCommand("sp_GetAllEquiposByEvento", conn);
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
                                Id = Guid.Parse(reader["id"].ToString()),
                                Nombre = reader["nombre"].ToString(),
                                Categoria = new Categoria() {
                                    id = Guid.Parse(reader["id_categoria"].ToString()),
                                    Nombre = reader["nombre_categoria"].ToString(),
                                    EdadInicio = Convert.ToInt32(reader["edad_min"]),
                                    EdadFin = Convert.ToInt32(reader["edad_max"])
                                }

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
                    cmd.Parameters.AddWithValue("@id_equipo", idEquipo.ToString());
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var par = new Participante()
                            {
                                Id = Guid.Parse(reader["id"].ToString()),

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

                            if (reader["metros"] is DBNull)
                            {
                                par.MetrosLogrados = 0;
                            }
                            else
                            {
                                par.MetrosLogrados = Convert.ToInt32(reader["metros"]);
                            }


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
                    cmd.Parameters.AddWithValue("@cat", obj.Categoria.id);

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
                    Guid id = Guid.NewGuid();

                    SqlCommand cmd = new SqlCommand("sp_InsertParticipante", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateEquipo", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", obj.Id);
                    cmd.Parameters.AddWithValue("@nom", obj.Nombre);

                    if (obj.PosicionGeneral != 0)
                    {
                        cmd.Parameters.AddWithValue("@posicion", obj.PosicionGeneral);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@posicion", DBNull.Value);
                    }
                    if (obj.PosicionCategoria != 0)
                    {
                        cmd.Parameters.AddWithValue("@posicionCat", obj.PosicionCategoria);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@posicionCat", DBNull.Value);
                    }
                    
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
