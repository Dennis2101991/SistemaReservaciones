using DataModels;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class NuevaReservacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHoteles();
                Page.DataBind(); // Asegura que las expresiones de enlace de datos se evalúen correctamente
            }
        }

        private void CargarHoteles()
        {
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                var hoteles = db.SpVerHoteles().ToList();
                ddlHotel.DataSource = hoteles;
                ddlHotel.DataTextField = "Nombre";
                ddlHotel.DataValueField = "IdHotel";
                ddlHotel.DataBind();
                ddlHotel.Items.Insert(0, new ListItem("Seleccione un hotel", ""));
            }
        }

        protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }

        private void CargarHabitaciones()
        {
            int idHotel = Convert.ToInt32(ddlHotel.SelectedValue);
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                var habitaciones = db.SpConsultarDisponibilidadHabitaciones(idHotel, null, null).ToList();
                ddlHabitacion.DataSource = habitaciones;
                ddlHabitacion.DataTextField = "NumeroHabitacion";
                ddlHabitacion.DataValueField = "IdHabitacion";
                ddlHabitacion.DataBind();
                ddlHabitacion.Items.Insert(0, new ListItem("Seleccione una habitación", ""));
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                int idCliente = Convert.ToInt32(Session["idPersona"]);
                int idHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
                DateTime fechaEntrada = DateTime.ParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null);
                DateTime fechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null);

                if (fechaEntrada < DateTime.Today)
                {
                    lblMensaje.Text = "La fecha de entrada no puede ser anterior a la fecha actual.";
                    return;
                }

                if (fechaSalida <= fechaEntrada)
                {
                    lblMensaje.Text = "La fecha de salida debe ser mayor a la fecha de entrada.";
                    return;
                }

                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    db.Insert(new Reservacion
                    {
                        IdPersona = idCliente,
                        IdHabitacion = idHabitacion,
                        FechaEntrada = fechaEntrada,
                        FechaSalida = fechaSalida,
                        Estado = 'A',
                        CostoTotal = CalcularCostoTotal(idHabitacion, fechaEntrada, fechaSalida)
                    });
                }

                lblMensaje.Text = "Reservación creada exitosamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear la reservación: " + ex.Message;
            }
        }

        private decimal CalcularCostoTotal(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida)
        {
            // Implementa la lógica para calcular el costo total de la reservación
            return 0; // Ejemplo: retorna 0, debes reemplazarlo con la lógica adecuada
        }
    }
}
