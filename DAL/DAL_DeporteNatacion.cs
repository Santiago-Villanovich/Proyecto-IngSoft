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

        public int InsertPostaMetros(Natacion_PostaMetros obj)
        {
            using (SqlConnection conn = _conn)
            {
                int idNatacion;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertDeporteNatacion", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pileta", obj.Pileta.id);
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

                    return idNatacion;
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

        public int InsertPostaTiempo(Natacion_PostaTiempo obj)
        {
            using (SqlConnection conn = _conn)
            {
                int idNatacion;
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertDeporteNatacion", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_pileta", obj.Pileta.id);
                    cmd.Parameters.AddWithValue("@estilo", obj.Estilo);
                    cmd.Parameters.AddWithValue("@elemtos", obj.Elementos);
                    cmd.Parameters.AddWithValue("@cantIntegrantes", obj.cantidad_integrantes_equipo);
                    cmd.Parameters.AddWithValue("@metros", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tiempo", obj.TiempoTotal);

                    conn.Open();

                    idNatacion = (Int32)cmd.ExecuteScalar();
                    return idNatacion;
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
