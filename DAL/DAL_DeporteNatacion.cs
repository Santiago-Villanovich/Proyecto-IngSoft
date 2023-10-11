using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Configuration;
using ABS;

namespace DAL
{
    public class DAL_DeporteNatacion : IMetodosGenericos<Natacion>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool Delete(Natacion obj)
        {
            throw new NotImplementedException();
        }

        public Natacion Get(int id)
        {
            using (SqlConnection conn = _conn)
            {
                Natacion nat = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetDeporteNatacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEvento", id);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            nat = new Natacion()
                            {
                                id = Convert.ToInt32(reader["id_natacion"].ToString()),
                                Estilo = reader["estilo"].ToString(),
                                Elementos = Convert.ToBoolean(reader["elementos"]),
                                cantidad_integrantes_equipo = Convert.ToInt32(reader["tamanio_equipo"].ToString()),
                                Pileta = new Pileta()
                                {
                                    id = Convert.ToInt32(reader["id_pileta"].ToString()),
                                    Direccion = reader["direccion"].ToString(),
                                    Metros = Convert.ToInt32(reader["metros"].ToString()),
                                    Carriles = Convert.ToInt32(reader["carriles"].ToString())
                                }
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("total_metros")))
                            {
                                nat.MetrosTotales = Convert.ToInt32(reader["total_metros"]);
                            }
                            else
                            {
                                nat.TiempoTotal = Convert.ToInt32(reader["total_tiempo"]);
                            }
                        }
                    }

                    return nat;
                }
                catch (SqlException ex)
                {
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public List<Natacion> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Natacion obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertDeporteNatacion", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pileta", obj.Pileta.id);
                    cmd.Parameters.AddWithValue("@id_evento", obj.id);
                    cmd.Parameters.AddWithValue("@estilo", obj.Estilo);
                    cmd.Parameters.AddWithValue("@elementos", obj.Elementos);
                    cmd.Parameters.AddWithValue("@cantIntegrantes", obj.cantidad_integrantes_equipo);

                    if (obj.MetrosTotales != 0)
                    {
                        cmd.Parameters.AddWithValue("@metros", obj.MetrosTotales );
                        cmd.Parameters.AddWithValue("@tiempo", DBNull.Value);
                    }
                    else if (obj.TiempoTotal != 0)
                    {
                        cmd.Parameters.AddWithValue("@metros", DBNull.Value);
                        cmd.Parameters.AddWithValue("@tiempo", obj.TiempoTotal);
                    }
                    else
                    {
                        return false;
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

        public bool Update(Natacion obj)
        {
            throw new NotImplementedException();
        }
    }
}
