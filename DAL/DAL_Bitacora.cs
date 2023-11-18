using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Bitacora
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        public bool Insert(Bitacora bitacora)
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = _conn;
            cmd.CommandText = "sp_InsertBitacora";
            cmd.Parameters.AddWithValue("@Detalle", bitacora.Detalle);
            cmd.Parameters.AddWithValue("@Responsable", bitacora.Responsable.Id);
            cmd.Parameters.AddWithValue("@Tipo", bitacora.Tipo);
            //cmd.Parameters.AddWithValue("@Fecha", bitacora.Fecha);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            catch (Exception ex2)
            {
                return false;
            }
            finally
            {
                _conn.Close();
            }

        }

        public List<Bitacora> GetAll() 
        {
            throw new NotImplementedException();
        }

        public List<DTO_BitacoraUser> GetAllBU(int? User, DateTime? from, DateTime? to,int? tipo,int page)
        {
            List<DTO_BitacoraUser> list = new List<DTO_BitacoraUser>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetBitacora", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", User.HasValue ? (object)User.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@from", from.HasValue ? (object)from.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@to", to.HasValue ? (object)to.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", tipo.HasValue ? (object)tipo.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@PageNumber", page);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bit = new DTO_BitacoraUser()
                            {
                                Detalle = reader["Detalle"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Tipo = reader["NombreTipo"].ToString()

                            };

                            list.Add(bit);
                        }
                    }

                    return list;
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

        public List<BitacoraTipo> GetAllBT()
        {
            List<BitacoraTipo> list = new List<BitacoraTipo>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllBitacorasTipo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bit = new BitacoraTipo()
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Descripcion = reader["Nombre"].ToString()
                            };

                            list.Add(bit);
                        }
                    }

                    return list;
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
    }
}
