
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Drawing;

namespace Banco.CapaPresentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager
                .ConnectionStrings["conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Usuarios ORDER BY UsuarioID", con))
            {
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int usuarioID;

            if (!int.TryParse(txtUsuarioID.Text, out usuarioID) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarMensaje("Complete los datos obligatorios.", false);
                return;
            }

            int resultado = Capa_Logica.Usuario_Logica.AgregarUsuario(
                usuarioID,
                txtNombre.Text,
                txtCorreo.Text,
                txtTelefono.Text
            );

            if (resultado > 0)
            {
                MostrarMensaje("Usuario agregado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo agregar el usuario.", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int usuarioID;

            if (!int.TryParse(txtUsuarioID.Text, out usuarioID) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MostrarMensaje("Complete los datos obligatorios.", false);
                return;
            }

            int resultado = Capa_Logica.Usuario_Logica.ModificarUsuario(
                usuarioID,
                txtNombre.Text,
                txtCorreo.Text,
                txtTelefono.Text
            );

            if (resultado > 0)
            {
                MostrarMensaje("Usuario modificado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo modificar el usuario.", false);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int usuarioID;

            if (!int.TryParse(txtUsuarioID.Text, out usuarioID))
            {
                MostrarMensaje("Ingrese un ID de usuario válido.", false);
                return;
            }

            int resultado = Capa_Logica.Usuario_Logica.BorrarUsuario(usuarioID);

            if (resultado > 0)
            {
                MostrarMensaje("Usuario eliminado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo eliminar el usuario.", false);
            }
        }

        protected void MostrarMensaje(string mensaje, bool correcto)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = correcto ? Color.Green : Color.Red;
        }

        protected void LimpiarCampos()
        {
            txtUsuarioID.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
        }
    }
}
