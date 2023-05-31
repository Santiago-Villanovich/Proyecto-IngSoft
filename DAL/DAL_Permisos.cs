using ABS;
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
    public class DAL_Permisos : IMetodosGenericos<Componente>
    {
        private SqlConnection _conn = new SqlConnection("Data Source=W10LAPTOPMATIAS\\SQLEXPRESS;Initial Catalog=DB_IngSoft;Integrated Security=True");
        public bool Delete(int id)
        {
            throw new NotImplementedException();
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

        public List<Componente> GetFamilias()
        {
            List<Componente> list = new List<Componente>();
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

        public bool IsInRole(int id)
        {
            var lista = GetAll();

            var c = GetComponent(id, lista);

            return c != null;
        }
    }
}
