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
                    Response.Redirect("Login");
                }

                try
                {
                    int idUsuario = Convert.ToInt32(Session["idPersona"]);
                    using (var db = new PvProyectoFinalDB("Conn"))
                    {
                        // Se invoca el SP que filtra por el id del usuario.
                        var reservaciones = db.SpObtenerMisReservaciones(idUsuario).ToList();
                        gvMisReservaciones.DataSource = reservaciones;
                        gvMisReservaciones.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

    }
}