using ABS;
using BE;
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
    public class DAL_Evento : IMetodosGenericos<Evento>
    {
        private SqlConnection _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);

        public bool Delete(Evento obj)
        {
            throw new NotImplementedException();
        }

        public Evento Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Evento obj)
        {
            using (SqlConnection conn = _conn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertEvento", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOrg", obj.Organizacion.id);
                    cmd.Parameters.AddWithValue("@desc", obj.Descripcion );
                    cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                    cmd.Parameters.AddWithValue("@coste", obj.ValorInscripcion);
                    cmd.Parameters.AddWithValue("@idDeporte", obj.Deporte.id_deporte);
                    cmd.Parameters.AddWithValue("@cupo",obj.cupo );

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

        public bool Update(Evento obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
