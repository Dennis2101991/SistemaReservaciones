using DataModels;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class GestionarReservaciones : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB("Conn"))
                    {
                       // Se invoca el SP que retorna todas las reservaciones del sistema con los datos del cliente.
                       var clientes = db.SpObtenerReservacionesConUsuario().ToList();
                       gvReservaciones.DataSource = clientes;
                       gvReservaciones.DataBind();

                    }

                    CargarClientes();  
                    CargarReservaciones();

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void CargarClientes()
        {
            try
            {
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    var clientes = db.SpVerClientesActivos().ToList();

                    ddlCliente.DataSource = clientes;
                    ddlCliente.DataTextField = "nombreCompleto";
                    ddlCliente.DataValueField = "idPersona";
                    ddlCliente.DataBind();

                    ddlCliente.Items.Insert(0, new ListItem("Seleccione un cliente", ""));
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string idCliente = ddlCliente.SelectedValue;
                string nombreCliente = null;

                // Obtiene el nombre completo del cliente seleccionado
                if (!string.IsNullOrEmpty(idCliente))
                {
                    using (var db = new PvProyectoFinalDB("Conn"))
                    {
                        var persona = db.GetTable<Persona>().FirstOrDefault(p => p.IdPersona.ToString() == idCliente);
                        if (persona != null)
                        {
                            nombreCliente = persona.NombreCompleto;
                        }
                    }
                }

                bool fechaEntradaValida = DateTime.TryParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out DateTime fechaEntrada);
                bool fechaSalidaValida = DateTime.TryParseExact(txtFechaSalida.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None, out DateTime fechaSalida);

                if (!fechaEntradaValida || !fechaSalidaValida)
                {
                    return;
                }

                if (fechaSalida < fechaEntrada)
                {
                    return;
                }

                // Llama al método con el nombre del cliente y las fechas ya como DateTime
                CargarReservaciones(nombreCliente, fechaEntrada, fechaSalida);
            }
            catch (Exception ex)
            {
               
            }
        }


        private void CargarReservaciones(string nombreCliente = null, DateTime? fechaEntrada = null, DateTime? fechaSalida = null)
        {
            try
            {
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    // Invoca el SP para obtener las reservaciones de un empleado
                    var reservaciones = db.SpConsultarReservacionesEmpleado(
                        Convert.ToInt32(Session["idPersona"]),
                        nombreCliente,
                        fechaEntrada,
                        fechaSalida
                    ).ToList();

                    // Asigna las reservaciones al GridView
                    gvReservaciones.DataSource = reservaciones;
                    gvReservaciones.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void gvReservaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Consultar")
            {
                int idReservacion = Convert.ToInt32(e.CommandArgument);
                // Redirige a la página de modificación pasando el id de la reservación por querystring.
                Response.Redirect("DetalleReservacion.aspx?id=" + idReservacion);
            }
        }


    }

}
