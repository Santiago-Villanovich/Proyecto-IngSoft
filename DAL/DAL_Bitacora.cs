using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Bitacora
    {
        private SqlConnection _conn = new SqlConnection("Data Source=RUBEN\\SQLEXPRESS;Initial Catalog=ingenieria-software;Integrated Security=True");
        public bool Insert(Bitacora bitacora)
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = _conn;
            cmd.CommandText = "sp_InsertBitacora";
            cmd.Parameters.AddWithValue("@Detalle", bitacora.Detalle);
            cmd.Parameters.AddWithValue("@Responsable", bitacora.Responsable.Id);
            cmd.Parameters.AddWithValue("@Fecha", bitacora.Fecha);


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
            List<Bitacora> list = new List<Bitacora>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from Bitacora", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var bit = new Bitacora()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Detalle = reader["Detalle"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Apellido"])

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
