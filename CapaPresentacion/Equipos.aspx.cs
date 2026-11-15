
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Drawing;

namespace Banco.CapaPresentacion
{
    public partial class Equipos : System.Web.UI.Page
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
                "SELECT * FROM Equipos ORDER BY EquipoID", con))
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
            int equipoID;
            int usuarioID;

            if (!ValidarCampos(out equipoID, out usuarioID))
                return;

            int resultado = Capa_Logica.Equipo_Logica.AgregarEquipo(
                equipoID,
                txtTipoEquipo.Text,
                txtModelo.Text,
                usuarioID
            );

            if (resultado > 0)
            {
                MostrarMensaje("Equipo agregado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo agregar el equipo.", false);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int equipoID;
            int usuarioID;

            if (!ValidarCampos(out equipoID, out usuarioID))
                return;

            int resultado = Capa_Logica.Equipo_Logica.ModificarEquipo(
                equipoID,
                txtTipoEquipo.Text,
                txtModelo.Text,
                usuarioID
            );

            if (resultado > 0)
            {
                MostrarMensaje("Equipo modificado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo modificar el equipo.", false);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int equipoID;

            if (!int.TryParse(txtEquipoID.Text, out equipoID))
            {
                MostrarMensaje("Ingrese un ID de equipo válido.", false);
                return;
            }

            int resultado = Capa_Logica.Equipo_Logica.BorrarEquipo(equipoID);

            if (resultado > 0)
            {
                MostrarMensaje("Equipo eliminado correctamente.", true);
                LlenarGrid();
                LimpiarCampos();
            }
            else
            {
                MostrarMensaje("No se pudo eliminar el equipo.", false);
            }
        }

        protected bool ValidarCampos(out int equipoID, out int usuarioID)
        {
            equipoID = 0;
            usuarioID = 0;

            if (!int.TryParse(txtEquipoID.Text, out equipoID) ||
                !int.TryParse(txtUsuarioID.Text, out usuarioID) ||
                string.IsNullOrWhiteSpace(txtTipoEquipo.Text) ||
                string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MostrarMensaje("Complete los datos correctamente.", false);
                return false;
            }

            return true;
        }

        protected void MostrarMensaje(string mensaje, bool correcto)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = correcto ? Color.Green : Color.Red;
        }

        protected void LimpiarCampos()
        {
            txtEquipoID.Text = "";
            txtTipoEquipo.Text = "";
            txtModelo.Text = "";
            txtUsuarioID.Text = "";
        }
    }
}
