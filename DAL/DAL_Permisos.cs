using ABS;
using BE;
using Services.Multilanguage;
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
    public class DAL_Permisos : IMetodosGenericos<Componente>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        public bool Delete(Componente id)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DeletePermiso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id.Id);
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    throw;
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

        public Componente Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Componente> GetAll()
        {
            _conn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllPermisos";

            var reader = cmd.ExecuteReader();

            var lista = new List<Componente>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_permiso_padre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                var patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));

                Componente c;

                if (!patente)
                    c = new Familia();
                else
                    c = new Patente();

                c.Id = id;
                c.Nombre = nombre;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }



            }
            reader.Close();
            _conn.Close();


            return lista;

        }

        public bool Insert(Componente obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Componente obj)
        {
            throw new NotImplementedException();
        }

        public List<Componente> GetAllComponentes()
        {
            _conn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllComponentes";

            var reader = cmd.ExecuteReader();

            var lista = new List<Componente>();

            while (reader.Read())
            { 
                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                var patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));

                Componente c;

                if (!patente)
                    c = new Familia();
                else
                    c = new Patente();

                c.Id = id;
                c.Nombre = nombre;

                lista.Add(c);

            }
            reader.Close();
            _conn.Close();


            return lista;
        
        }

        public List<Familia> GetFamilias()
        {
            List<Familia> list = new List<Familia>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetFamilias", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var permiso = new Familia()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                es_patente = Convert.ToBoolean(reader["es_patente"])

                            };

                            list.Add(permiso);
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



        public List<Componente> GetPermisosFamilia(int familia)
        {
            _conn.Open();
            var cmd = new SqlCommand();
            cmd.Connection = _conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetAllPermisos";
            cmd.Parameters.AddWithValue("@familia", familia);

            var reader = cmd.ExecuteReader();

            var lista = new List<Componente>();

            while (reader.Read())
            {
                int id_padre = 0;
                if (reader["id_permiso_padre"] != DBNull.Value)
                {
                    id_padre = reader.GetInt32(reader.GetOrdinal("id_permiso_padre"));
                }

                var id = reader.GetInt32(reader.GetOrdinal("id"));
                var nombre = reader.GetString(reader.GetOrdinal("nombre"));
                var patente = reader.GetBoolean(reader.GetOrdinal("es_patente"));


                Componente c;

                if (!patente)
                    c = new Familia();
                else
                    c = new Patente();

                c.Id = id;
                c.Nombre = nombre;
                c.es_patente = patente;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }



            }
            reader.Close();
            _conn.Close();


            return lista;

        }

        private Componente GetComponent(int id, IList<Componente> lista)
        {

            Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {

                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);

                }
            }

            return component;

        }

        public Componente GetComponentePorNombre(string nombre)
        {
            using (SqlConnection conn = _conn)
            {
                Componente permiso = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetFamiliaByName", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToBoolean(reader["es_patente"]))
                            {
                                permiso = new Patente();
                                
                            }else
                            {
                                permiso = new Familia();
                            }

                            permiso.Id = Convert.ToInt32(reader["id"]);
                            permiso.Nombre = Convert.ToString(reader["nombre"]);
                        }
                    }

                    return permiso;
                }
                catch (SqlException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public bool SacarPermisoUser(User user, Componente permiso)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SacarPermisosUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUser", user.Id);
                    cmd.Parameters.AddWithValue("@idPermiso", permiso.Id);
                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (SqlException ex)
                {
                    throw;
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

        public List<Patente> ObtenerPatentes()
        {
            List<Patente> list = new List<Patente>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerPatentes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var permiso = new Patente()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                es_patente = Convert.ToBoolean(reader["es_patente"])

                            };

                            list.Add(permiso);
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



        public bool IsInRole(int id)
        {
            var lista = GetAll();

            var c = GetComponent(id, lista);

            return c != null;
        }

        public List<Familia> GetPermisosUser(User user)
        {
            List<Familia> list = new List<Familia>();
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetPermisosUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Connection = conn;
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var permiso = new Familia()
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                es_patente = Convert.ToBoolean(reader["es_patente"])

                            };

                            list.Add(permiso);
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

        public void AgregarPatentePermiso(Componente permiso, int IdPadre)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_AgregarPatentePermiso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_padre", IdPadre);
                    cmd.Parameters.AddWithValue("@id_hijo", permiso.Id);

                    conn.Open();

                    cmd.ExecuteNonQuery();
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

        public void AgregarPermiso(Componente permiso)
        {
            using(SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertPermiso", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", permiso.Nombre);
                    cmd.Parameters.AddWithValue("@es_patente", permiso.es_patente);
                    conn.Open();

                    cmd.ExecuteNonQuery();
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
    }
}
