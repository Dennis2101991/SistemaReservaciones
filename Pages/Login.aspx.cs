using DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SistemaReservaciones.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensajeError.Visible = false; // Oculta el mensaje de error en cada carga

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMensajeError.Text = "Ingrese su correo y contraseña.";
                lblMensajeError.Visible = true;
                return;
            }

            try
            {
                using (var db = new PvProyectoFinalDB("Conn"))  // Conecta con la BD
                {
                    var usuario = db.SpLoginUsuario(email, password).FirstOrDefault(); // Llama al Sp de la bd

                    if (usuario != null) // Valida si el usuario existe
                    {
                        Session["idPersona"] = usuario.IdPersona;
                        Session["nombreCompleto"] = usuario.NombreCompleto;
                        Session["esEmpleado"] = usuario.EsEmpleado;

                        Response.Redirect("Misreservaciones.aspx");
                    }
                    else
                    {
                        lblMensajeError.Text = "Credenciales incorrectas o usuario inactivo.";
                        lblMensajeError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error en la conexión: " + ex.Message;
                lblMensajeError.Visible = true;
            }


        }
    }

}