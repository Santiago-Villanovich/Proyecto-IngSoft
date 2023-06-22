using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ABS;
using BE;
using Services;

namespace DAL
{
    public class DAL_User : IMetodosGenericos<User>
    {

        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool Delete(User id)
        {
            using (SqlConnection conn = _conn) 
            {
                try 
                {
                    string query = String.Format("DELETE * FROM Users where Id = {0}",  id.Id);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }catch(Exception ex) 
                {
                    return false;
                }
            
            }
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("select * from Users", conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = Convert.ToInt32(reader["DNI"]),
                                DV = reader["DV"].ToString(),
                                isAdmin = Convert.ToBoolean(reader["isAdmin"])

                            };

                            list.Add(user);
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

        public bool Insert(User obj) //REVISAR
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@DV", obj.DV);
                    //cmd.Parameters.AddWithValue("@isAdmin", obj.isAdmin);
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
                    _conn.Close();
                }
            }
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }

        public User Login(int dni, string clave)
        {
            User user = null;
            using (SqlConnection conn = _conn)
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_LoginUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@Clave", clave);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            user = new User();
                            user.Id = Convert.ToInt32(dr["Id"]);
                            user.Nombre = dr["Nombre"].ToString();
                            user.Apellido = dr["Apellido"].ToString();
                            user.DNI = Convert.ToInt32(dr["DNI"]);
                            user.isAdmin = Convert.ToBoolean(dr["isAdmin"]);
                        }


                    }

                    return user;

                }
                catch (SqlException ex)
                {
                    throw ex;
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
