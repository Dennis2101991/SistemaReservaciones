using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
	public partial class Misreservaciones : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                try
                {
                    int idUsuario = Convert.ToInt32(Session["idPersona"]);
                    using (var db = new PvProyectoFinalDB("Conn"))
                    {
                        // Invocar el procedimiento almacenado y enlazar los datos
                        var reservaciones = db.SpObtenerMisReservaciones(idUsuario).ToList();
                        gvMisReservaciones.DataSource = reservaciones;
                        gvMisReservaciones.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Response.Write($"Error: {ex.Message}");
                }
            }
        }
        private void CargarReservaciones()
        {
            int idUsuarioLogueado = Convert.ToInt32(Session["idPersona"]); // ← Corrigido

            using (var db = new PvProyectoFinalDB("Conn"))
            {
                gvMisReservaciones.DataSource = db.SpObtenerMisReservaciones(idUsuarioLogueado).ToList();
                gvMisReservaciones.DataBind();
            }
        }

    }
}