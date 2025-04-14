using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class GestionarReservaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new PvProyectoFinalDB("Conn")) // Conexión al contexto LINQ to DB
                {
                    // Llamar al procedimiento almacenado para obtener reservaciones con usuario
                    var reservaciones = db.SpObtenerReservacionesConUsuario().ToList();

                    // Mostrar los resultados en el GridView
                    if (reservaciones.Any())
                    {
                        gvReservaciones.DataSource = reservaciones;
                        gvReservaciones.DataBind();
                        lblMensaje.Visible = false; // Ocultar mensaje de error
                    }
                    else
                    {
                        lblMensaje.Text = "No se encontraron reservaciones.";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                lblMensaje.Text = "Error al realizar la consulta: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }

        protected void gvReservaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                // Obtener el ID de la reservación desde el CommandArgument
                int idReservacion = Convert.ToInt32(e.CommandArgument);

                // Redirigir a la página de modificación con el ID como parámetro
                Response.Redirect($"Modificar.aspx?id={idReservacion}");
            }
        }
    }
}
