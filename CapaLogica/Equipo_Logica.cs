
using System;
using System.Data;
using System.Data.SqlClient;

namespace Banco.Capa_Logica
{
    public class Equipo_Logica
    {
        public static int AgregarEquipo(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Equipos (EquipoID, TipoEquipo, Modelo, UsuarioID) VALUES (@EquipoID, @TipoEquipo, @Modelo, @UsuarioID)", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@EquipoID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
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

        public static int ModificarEquipo(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Equipos SET TipoEquipo=@TipoEquipo, Modelo=@Modelo, UsuarioID=@UsuarioID WHERE EquipoID=@EquipoID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@EquipoID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@TipoEquipo", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@Modelo", modelo));
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

        public static int BorrarEquipo(int equipoID)
        {
            int retorno = 0;

            try
            {
                using (SqlConnection Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Equipos WHERE EquipoID=@EquipoID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add(new SqlParameter("@EquipoID", equipoID));

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
