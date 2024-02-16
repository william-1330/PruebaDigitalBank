using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio.Entidades;
using CapaDatos.Data;

namespace CapaDatos.Data
{
    public class LogCD
    {
        public bool Crear(int idUsuario, string fecha, string metodo)
        {
            bool respuesta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearLog", conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Metodo", metodo);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
