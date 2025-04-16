using DataModels;
using SistemaReservaciones.Pages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["nombreCompleto"] != null)
                {
                    lbtnCerrarSession.Visible = true; // Si la condición anterior se cumple el link button va a ser visible
                    lblNombreCompleto.Text = "Bienvenid@, " + Session["nombreCompleto"].ToString(); // Si la sesión tiene información, obtiene el nombre completo
                }
                else
                {
                    lbtnCerrarSession.Visible = false; // Si la condición anterior NO se cumple el link button va a ser invisible
                }

                // Verifica si el usuario es empleado
                bool esEmpleado = false;

                if (Session["esEmpleado"] != null)
                {
                    esEmpleado = Convert.ToBoolean(Session["esEmpleado"]);
                }

                // Oculta o muestra las opciones según el rol del usuario.
                liGestionarReservaciones.Visible = esEmpleado;
                liGestionarHabitaciones.Visible = esEmpleado;
            }
        }

        protected void lbtnCerrarSession_Click(object sender, EventArgs e)
        {
            pnlConfirmaCerrarSesion.Visible = true;  // Muestra el panel de confirmación al hacer clic en cerrar sesión
        }

        protected void btnConfirmaCerrarSesion_Click(object sender, EventArgs e) // Si el usuario confirma que quiere cerrar la sesión lo redirige al login
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Pages/Login.aspx");
        }

        protected void btnCancelaCerrarSesion_Click(object sender, EventArgs e)
        {
            pnlConfirmaCerrarSesion.Visible = false;  // Si el usuario cancela el cerrar sesión, el panel se oculta
        }


    }
}