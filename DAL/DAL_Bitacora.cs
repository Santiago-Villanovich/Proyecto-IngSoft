using BE;
using System;
using System.Collections.Generic;
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
    }
}
