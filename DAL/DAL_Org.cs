using ABS;
using BE;
using Services.SecurityAndValidation;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL_Org : IMetodosGenericos<Organizacion>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool Delete(Organizacion obj)
        {
            throw new NotImplementedException();
        }

        public Organizacion Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Organizacion> GetAll()
        {
            List<Organizacion> list = new List<Organizacion>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllOrg", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var org = new Organizacion()
                            {
                                id = Convert.ToInt32(reader["id_org"]),
                                Nombre = reader["nombre"].ToString(),
                                DireccionWeb = reader["direccion_web"].ToString(),
                                Email = reader["email"].ToString(),
                                CUIT = reader["cuit"].ToString()


                            };

                            list.Add(org);
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

        public bool Insert(Organizacion obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateOrg", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nom", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Cuit", obj.CUIT);
                    cmd.Parameters.AddWithValue("@Dir", obj.DireccionWeb);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);

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

        public bool Update(Organizacion obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateOrg", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.id);
                    cmd.Parameters.AddWithValue("@Nom", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Cuit", obj.CUIT);
                    cmd.Parameters.AddWithValue("@Dir", obj.DireccionWeb);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);

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

        public bool AsociarUsuario(int id_user, int id_org)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertOrgUsuario", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_user", id_user);
                    cmd.Parameters.AddWithValue("@id_org", id_org);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    throw ex;
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
