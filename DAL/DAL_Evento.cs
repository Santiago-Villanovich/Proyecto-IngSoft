using ABS;
using BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Evento : IMetodosGenericos<Evento>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        private string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        public bool Delete(Evento obj)
        {
            throw new NotImplementedException();
        }

        public Evento Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                List<Evento> list = new List<Evento>();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEvento", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var evento = new Evento()
                            {
                                id = Convert.ToInt32(reader["id_evento"]),
                                nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Fecha = Convert.ToDateTime(reader["fecha"].ToString()),
                                cupo = Convert.ToInt32(reader["cupos"].ToString()),
                                ValorInscripcion = Convert.ToDouble(reader["coste_inscripcion"].ToString()),
                                estado = reader["estado"].ToString(),

                                Organizacion = new Organizacion()
                                {
                                    id = Convert.ToInt32(reader["id_org"].ToString()),
                                    Nombre = reader["nombre"].ToString(),
                                    CUIT = reader["cuit"].ToString(),
                                    Email = reader["email"].ToString(),
                                    DireccionWeb = reader["direccion_web"].ToString()
                                }

                            };

                            list.Add(evento);
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

        public bool Insert(Evento obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertEvento", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrg", obj.Organizacion.id);
                    cmd.Parameters.AddWithValue("@nom", obj.nombre);
                    cmd.Parameters.AddWithValue("@desc", obj.Descripcion );
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@coste", obj.ValorInscripcion);
                    cmd.Parameters.AddWithValue("@idDeporte", 1);
                    cmd.Parameters.AddWithValue("@cupo",obj.cupo );

                    SqlParameter returno = new SqlParameter();
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    int idEvento = (int)returno.Value;

                    foreach (Categoria c in obj.Categorias)
                    {
                        SqlCommand cmd2 = new SqlCommand("sp_InsertCategoria", conn);

                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@idEvento", idEvento);
                        cmd2.Parameters.AddWithValue("@Nom", c.Nombre);
                        cmd2.Parameters.AddWithValue("@EdadMin", c.EdadInicio);
                        cmd2.Parameters.AddWithValue("@EdadMax", c.EdadFin);

                        cmd2.ExecuteNonQuery();
                    }

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

        public int InsertAndInt(Evento obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertEvento", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrg", obj.Organizacion.id);
                    cmd.Parameters.AddWithValue("@nom", obj.nombre);
                    cmd.Parameters.AddWithValue("@desc", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@coste", obj.ValorInscripcion);
                    cmd.Parameters.AddWithValue("@idDeporte", 1);
                    cmd.Parameters.AddWithValue("@cupo", obj.cupo);

                    SqlParameter returno = new SqlParameter();
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    int idEvento = (int)returno.Value;

                    foreach (Categoria c in obj.Categorias)
                    {
                        SqlCommand cmd2 = new SqlCommand("sp_InsertCategoria", conn);

                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddWithValue("@IdEvento", idEvento);
                        cmd2.Parameters.AddWithValue("@Nombre", c.Nombre);
                        cmd2.Parameters.AddWithValue("@EdadMin", c.EdadInicio);
                        cmd2.Parameters.AddWithValue("@EdadMax", c.EdadFin);

                        cmd2.ExecuteNonQuery();
                    }

                    return idEvento;
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

        public bool Update(Evento obj)
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetCategorias(int idEvento) 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                List<Categoria> list = new List<Categoria>();

                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllCategorias", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEvento", idEvento);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cat = new Categoria()
                            {
                                Nombre = reader["nombre"].ToString(),
                                EdadInicio = Convert.ToInt32(reader["edad_min"].ToString()),
                                EdadFin = Convert.ToInt32(reader["edad_max"].ToString())

                            };

                            list.Add(cat);
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
        

    }
}
