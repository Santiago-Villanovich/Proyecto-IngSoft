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
    public class DAL_Pileta : IMetodosGenericos<Pileta>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool Delete(Pileta obj)
        {
            throw new NotImplementedException();
        }

        public Pileta Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pileta> GetAll()
        {
            List<Pileta> list = new List<Pileta>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllPiletas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pil = new Pileta()
                            {
                                id = Convert.ToInt32(reader["id_pileta"]),
                                Direccion = reader["direccion"].ToString(),
                                Metros = Convert.ToInt32(reader["metros"]),
                                Carriles = Convert.ToInt32(reader["carriles"])
                            };

                            list.Add(pil);
                        }
                    }

                    return list;
                }
                catch (SqlException ex)
                {
                    throw ex;
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

        public bool Insert(Pileta obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pileta obj)
        {
            throw new NotImplementedException();
        }
    }
}
