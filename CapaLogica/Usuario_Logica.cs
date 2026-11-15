using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Banco.Capa_Logica
{
    public class Usuario_Logica
    {
        public static int AgregarUsuario(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuarios (UsuarioID, Nombre, CorreoElectronico, Telefono) VALUES (@UsuarioID, @Nombre, @CorreoElectronico, @Telefono)", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", (object)telefono ?? DBNull.Value));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }

            return retorno;
        }

        public static int ModificarUsuario(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Usuarios SET Nombre=@Nombre, CorreoElectronico=@CorreoElectronico, Telefono=@Telefono WHERE UsuarioID=@UsuarioID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@Nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", (object)telefono ?? DBNull.Value));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }

            return retorno;
        }

        public static int BorrarUsuario(int usuarioID)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Usuarios WHERE UsuarioID=@UsuarioID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }

            return retorno;
        }
    }
}
