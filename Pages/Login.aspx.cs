using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Aquí verificamos  las credenciales de login (ojo esto es solo para ver como funciona la secuencia de las paginas creadas hasta hoy).
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (email == "RataNegra@hotmail.com" && password == "Rasta123")    // esto son los datos para probar las texbox
            {
                // Redirigir a la página de inicio (Home.aspx) si el login es correcto.
                Response.Redirect("Misreservaciones.aspx"); // Redirige a la página Misreservaciones.
            }
            else
            {
                // Mostrar mensaje de error si las credenciales son incorrectas.
                lblErrorMessage.Text = "Credenciales incorrectas. Intente nuevamente.";
                lblErrorMessage.Visible = true;
            }
        }
    }

}