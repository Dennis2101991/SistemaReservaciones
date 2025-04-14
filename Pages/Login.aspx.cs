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
            lblErrorMessage.Visible = false; // Oculta el mensaje de error en cada carga

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = "Ingrese su correo y contraseña.";
                lblErrorMessage.Visible = true;
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
                        lblErrorMessage.Text = "Credenciales incorrectas o usuario inactivo.";
                        lblErrorMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error en la conexión: " + ex.Message;
                lblErrorMessage.Visible = true;
            }


        }
    }

}