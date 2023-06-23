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
    public class DAL_DigitoVerificador
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public string GetDVTabla(string nom)
        {
            using (SqlConnection conn = _conn)
            {
                IDataReader reader = null;
                string DVT = string.Empty;

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_GetTableDV";
                    cmd.Parameters.AddWithValue("@Nom", nom);
                    cmd.Connection = conn;
                    conn.Open();

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DVT = reader["digitoVerificador_tabla"].ToString();
                    }
                    return DVT;
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

        public bool InsertDVTabla(string Nom, string DVT)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.CommandText = "sp_UpdateTablesDV";
                    cmd.Parameters.AddWithValue("@Nom", Nom);
                    cmd.Parameters.AddWithValue("@DV", DVT);

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
        }

    }
}
