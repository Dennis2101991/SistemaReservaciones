using DataModels;
using LinqToDB.Data;
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
            if (!IsPostBack)
            {
                // Valida que el usuario esté autenticado y sea empleado.
                if (Session["nombreCompleto"] == null || Session["idPersona"] == null || Session["esEmpleado"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }
                bool esEmpleado = Convert.ToBoolean(Session["esEmpleado"]);
                if (!esEmpleado)
                {
                    // Si el usuario no es empleado, redirige a la vista de MisReservaciones.
                    Response.Redirect("Misreservaciones.aspx");
                    return;
                }

                try
                {
                    using (var db = new PvProyectoFinalDB("Conn"))
                    {
                        // Se invoca el SP que retorna todas las reservaciones del sistema con los datos del cliente.
                        var alumnos = db.SpObtenerReservacionesConUsuario().ToList();
                        gvReservaciones.DataSource = alumnos;
                        gvReservaciones.DataBind();

                    }

                }

                catch (Exception ex)
                {

                }
            }
        }


        protected void gvReservaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                int idReservacion = Convert.ToInt32(e.CommandArgument);
                // Redirige a la página de modificación pasando el id de la reservación por querystring.
                Response.Redirect("Consultar.aspx?id=" + idReservacion);
            }
        }

    }
}
