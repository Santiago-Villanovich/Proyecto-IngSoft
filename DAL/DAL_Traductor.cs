using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ABS;
using Services.Multilanguage;
using System.Runtime.Remoting.Messaging;
using BE;

namespace DAL
{
    public class DAL_Traductor
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public IIdioma ObtenerIdiomaDefault()
        {
            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                Idioma _idioma = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetIdiomaDefault", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    { 
                        _idioma =
                         new Idioma()
                         {
                             Id = Convert.ToInt32(reader["ID"].ToString()),
                             nombre = reader["NombreIdioma"].ToString(),
                             isDefault = Convert.ToBoolean(reader["defaultIdioma"])

                         };
                    }
                    return _idioma;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    conn.Close();
                }
            }
        }

        public IList<IIdioma> ObtenerIdiomas()
        {
            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                IList<IIdioma> _idiomas = new List<IIdioma>();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllIdiomas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
 
                        _idiomas.Add(
                         new Idioma()
                         {
                             Id = Convert.ToInt32(reader["ID"].ToString()),
                             nombre = reader["NombreIdioma"].ToString(),
                             isDefault = Convert.ToBoolean(reader["defaultIdioma"])

                         });
                    }
                    return _idiomas;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    if (reader != null)
                    reader.Close();
                    conn.Close();
                }
            }


        }

        public IDictionary<string, ITraduccion> ObtenerTraducciones(IIdioma idioma)
        {

            if (idioma == null)
            {
                idioma = ObtenerIdiomaDefault();
            }

            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>();
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("sp_GetAllTraducciones",conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdIdioma", idioma.Id);
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var etiqueta = reader["ID"].ToString();

                        _traducciones.Add(etiqueta,
                         new Traduccion()
                         {

                             texto = reader["traduccion"].ToString(),

                             termino = new Termino()
                             {
                                 id = Convert.ToInt32(etiqueta),
                                 termino = reader["termino"].ToString()
                             }

                         });
                    }
                    return _traducciones;
                }
                catch(Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (reader != null)
                    reader.Close();
                    conn.Close();
                }
            
            }
        }

        public List<Traduccion> GetAllTerminos()
        {
            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                List<Traduccion> _lista = new List<Traduccion>();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllTerminos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        _lista.Add(
                         new Traduccion()
                         {
                             texto = "",

                             termino = new Termino()
                             {
                                 id = Convert.ToInt32(reader["ID"].ToString()),
                                 termino = reader["Termino"].ToString()
                             }
                         });
                    }
                    return _lista;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    conn.Close();
                }
            }
        }

        public bool InsertIdioma(IIdioma idioma) 
        {
            using (SqlConnection conn = _conn)
            {

                SqlCommand cmd = new SqlCommand("sp_InsertIdioma", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdIdioma",idioma.Id);
                cmd.Connection = conn;
                conn.Open();

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
                    conn.Close();
                }
            }

        }

        public Idioma GetLastIdiomaAdded()
        {
            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                Idioma _idioma = null;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_GetLastIdiomaAdded", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        _idioma =
                         new Idioma()
                         {
                             Id = Convert.ToInt32(reader["ID"].ToString()),
                             nombre = reader["NombreIdioma"].ToString(),
                             isDefault = Convert.ToBoolean(reader["defaultIdioma"])

                         };
                    }
                    return _idioma;
                }
                catch (Exception e)
                {

                    throw e;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    conn.Close();
                }
            }
        }

        public bool InsertTraduccion(List<Traduccion> traduc, IIdioma idioma)
        {
            using (SqlConnection conn = _conn)
            {
                conn.Open();

                try
                {
                    foreach (Traduccion item in traduc)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        cmd.CommandText = "sp_InsertTraduccion";

                        cmd.Parameters.AddWithValue("@IdIdioma", idioma.Id);
                        cmd.Parameters.AddWithValue("@IdTermino", item.termino.id);
                        cmd.Parameters.AddWithValue("@Traduccion", item.texto);
                        cmd.ExecuteNonQuery();
                    }
                    
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
                    conn.Close();
                }
            }
        }
    }
}
