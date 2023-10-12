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
                    SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id",id.Id);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }catch(Exception ex) 
                {
                    throw ex;
                }
                finally { conn.Close(); }
            
            }
        }

        public User Get(int id)
        {
            using (SqlConnection conn = _conn)
            {
                User user = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = Convert.ToInt32(reader["DNI"]),
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                Clave = reader["Clave"].ToString(),
                                DV = reader["DV"].ToString()
                            };
                        }
                    }

                    return user;
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

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                                Telefono = reader["Telefono"].ToString(),
                                Email = reader["Email"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["Fecha_Nacimiento"]),
                                Clave = reader["Clave"].ToString(),
                                DV = reader["DV"].ToString()

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

        public bool Insert(User obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("@DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("@Tel", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    SqlParameter date = new SqlParameter("@Nacimiento", SqlDbType.Date); //Conversion explicita a DATE
                    date.Value = obj.FechaNacimiento;
                    cmd.Parameters.Add(date);
                    cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@DV", obj.DV);
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
        public bool AgregarPermiso(Componente permiso, User user)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertPermisoUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_permiso", permiso.Id);
                    cmd.Parameters.AddWithValue("@id_user", user.Id);
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
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Nom", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Ape", obj.Apellido);
                    cmd.Parameters.AddWithValue("@DNI", obj.DNI);
                    cmd.Parameters.AddWithValue("@Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("@DV", obj.DV);
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
                            user.Telefono = dr["Telefono"].ToString();
                            user.Email = dr["Email"].ToString();
                            user.FechaNacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]);
                            user.Clave = dr["Clave"].ToString();
                            user.DV = dr["DV"].ToString();
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

        public List<DTO_UserHistory> GetAllUserHistory(int? User, DateTime? from, DateTime? to, int page)
        {
            List<DTO_UserHistory> list = new List<DTO_UserHistory>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllUserHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@User", User.HasValue ? (object)User.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@from", from.HasValue ? (object)from.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@to", to.HasValue ? (object)to.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Page", page);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new DTO_UserHistory()
                            {
                                Id = Convert.ToInt32(reader["Id_User"]),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                DNI = Convert.ToInt32(reader["DNI"]),
                                Clave = reader["Clave"].ToString(),
                                Fecha = Convert.ToDateTime(reader["Fecha"])

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

        public bool InsertUserHistory(DTO_UserHistory user)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertUserHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Nom", user.Nombre);
                    cmd.Parameters.AddWithValue("@Ape", user.Apellido);
                    cmd.Parameters.AddWithValue("@Dni", user.DNI);
                    cmd.Parameters.AddWithValue("@Clave", user.Clave);
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

        public Organizacion GetUserOrg(int id)
        {
            using (SqlConnection conn = _conn)
            {
                Organizacion organizacion = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetUserOrg", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUser", id);
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
                                CUIT = reader["cuit"].ToString(),


                            };
                            if (!reader.IsDBNull(reader.GetOrdinal("pileta_asociada")))
                            {
                                org.PiletaAsociada = new Pileta()
                                {
                                    id = Convert.ToInt32(reader["pileta_asociada"]),
                                    Direccion = reader["direccion"].ToString(),
                                    Metros = Convert.ToInt32(reader["metros"]),
                                    Carriles = Convert.ToInt32(reader["carriles"])
                                };
                            }
                            else
                            {
                                org.PiletaAsociada = null;
                            }

                            organizacion = org;
                        }
                    }

                    return organizacion;
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
