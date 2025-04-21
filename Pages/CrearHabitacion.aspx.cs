using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using LinqToDB.Data;


namespace SistemaReservaciones.Pages
{
    public partial class CrearHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("Login");
                }
                CargarHoteles();
               // CargarNombreCliente();
               // LlenarListasCantidad();
                Page.DataBind();
            }
        }
        private void CargarHoteles()
        {
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                ddlHotel.DataSource = db.SpVerHoteles().OrderBy(h => h.Nombre).ToList();
                ddlHotel.DataTextField = "Nombre";
                ddlHotel.DataValueField = "IdHotel";
                ddlHotel.DataBind();

                // Esto asegura que siempre tenga el primer ítem
                ddlHotel.Items.Insert(0, new ListItem("-- Seleccione un hotel --", ""));
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                // (a) y (b): Si no pasa validaciones, no continúa
                return;
            }

            try
            {
                int idHotel = Convert.ToInt32(ddlHotel.SelectedValue);
                string numero = txtNumero.Text.Trim(); // ✅ Campo correcto

                int capacidad = Convert.ToInt32(txtCapacidad.Text.Trim());
                string descripcion = txtDescripcion.Text.Trim();

                // Validación (b) extra: que no exista ese número en el hotel
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                   
                    string Numero = txtNumero.Text.Trim(); // Número de habitación correcto
                    int Capacidad = Convert.ToInt32(txtCapacidad.Text);
                    string Descripcion = txtDescripcion.Text.Trim();
                    

                    db.ExecuteProc("sp_CrearHabitacion",
                        new DataParameter("@idHotel", idHotel),
                        new DataParameter("@numeroHabitacion", numero),
                        new DataParameter("@estado", "A"),
                        new DataParameter("@capacidadMaxima", capacidad),
                        new DataParameter("@descripcion", descripcion));

                }

                // (d) Redirigir a página de éxito
                Response.Redirect("Exito.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al guardar: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }

    }
}