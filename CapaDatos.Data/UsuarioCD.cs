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
    public class UsuarioCD
    {
        public List<Usuario> Listado()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Usuarios()", conexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                                Nombre = dr["Nombre"].ToString(),
                                FechaNacimiento = dr["FechaNacimiento"].ToString(),    //dr.GetDateTime(dr.GetOrdinal("FechaNacimiento")),
                                Sexo = dr.GetString(dr.GetOrdinal("Sexo")).ToCharArray()[0]
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Usuario Obtener(int IdUsuario)
        {
            Usuario entidad = new Usuario();

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_Usuario(@idUsuario)", conexion);
                cmd.Parameters.AddWithValue("@idUsuario", IdUsuario);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString());
                            entidad.Nombre = dr["Nombre"].ToString();
                            entidad.FechaNacimiento = dr["FechaNacimiento"].ToString();
                            entidad.Sexo = dr.GetString(dr.GetOrdinal("Sexo")).ToCharArray()[0];
                        }
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Crear(Usuario entidad)
        {
            bool respuesta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {

                SqlCommand cmd = new SqlCommand("sp_CrearUsuario", conexion);
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", entidad.Sexo);
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

        public bool Editar(Usuario entidad)
        {
            bool respuesta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {

                SqlCommand cmd = new SqlCommand("sp_EditarUsuario", conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", entidad.IdUsuario);
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", entidad.Sexo);
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

        public bool Eliminar(int IdUsuario)
        {
            bool respuesta = false;

            using (SqlConnection conexion = new SqlConnection(Conexion.Cadena))
            {

                SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", conexion);
                cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
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
