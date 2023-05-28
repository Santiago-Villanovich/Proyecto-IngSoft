using System;
using System.Collections.Generic;
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
        private SqlConnection _conn = new SqlConnection("Data Source = W10LAPTOPMATIAS\\SQLEXPRESS; Initial Catalog = DB_IngSoft; Integrated Security = True");
        public bool Insert(Bitacora bitacora)
        {
            _conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = _conn;
            cmd.CommandText = "sp_InsertBitacora";
            cmd.Parameters.AddWithValue("@Detalle", bitacora.Detalle);
            cmd.Parameters.AddWithValue("@Responsable", bitacora.Responsable.Id);
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

        public List<DTO_BitacoraUser> GetAllBU()
        {
            List<DTO_BitacoraUser> list = new List<DTO_BitacoraUser>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ListarBitacoras", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                                DNI = Convert.ToInt32(reader["DNI"]),

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
