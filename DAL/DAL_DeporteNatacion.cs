using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Configuration;

namespace DAL
{
    public class DAL_DeporteNatacion
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool InsertPostaMetros(Natacion_PostaMetros obj, int idEvento)
        {
            using (SqlConnection conn = _conn)
            {
                int idNatacion;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertDeporteNatacion", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pileta", obj.Pileta.id);
                    cmd.Parameters.AddWithValue("@id_evento", idEvento);
                    cmd.Parameters.AddWithValue("@estilo", obj.Estilo);
                    cmd.Parameters.AddWithValue("@elementos", obj.Elementos);
                    cmd.Parameters.AddWithValue("@cantIntegrantes", obj.cantidad_integrantes_equipo);
                    cmd.Parameters.AddWithValue("@metros", obj.MetrosTotales); 
                    cmd.Parameters.AddWithValue("@tiempo", DBNull.Value);
                    

                    SqlParameter returno = new SqlParameter();
                    returno.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returno);

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    idNatacion = (int)returno.Value;

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

        public bool InsertPostaTiempo(Natacion_PostaTiempo obj, int idEvento)
        {
            using (SqlConnection conn = _conn)
            {
                int idNatacion;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertDeporteNatacion", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pileta", obj.Pileta.id);
                    cmd.Parameters.AddWithValue("@id_evento", idEvento);
                    cmd.Parameters.AddWithValue("@estilo", obj.Estilo);
                    cmd.Parameters.AddWithValue("@elemtos", obj.Elementos);
                    cmd.Parameters.AddWithValue("@cantIntegrantes", obj.cantidad_integrantes_equipo);
                    cmd.Parameters.AddWithValue("@metros", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tiempo", obj.TiempoTotal);

                    conn.Open();

                    idNatacion = (Int32)cmd.ExecuteScalar();
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

        

    }
}
