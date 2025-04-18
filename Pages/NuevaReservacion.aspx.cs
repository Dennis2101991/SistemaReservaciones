// NuevaReservacion.aspx.cs
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
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("Login");
                }
                CargarHoteles();
                CargarNombreCliente();
                LlenarListasCantidad();
                Page.DataBind();
            }
        }

        private void CargarNombreCliente()
        {
            int idCliente = Convert.ToInt32(Session["idPersona"]);
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                var cliente = db.GetTable<Persona>().FirstOrDefault(p => p.IdPersona == idCliente);
                if (cliente != null)
                    lblNombreCliente.Text = cliente.NombreCompleto;
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

        private void LlenarListasCantidad()
        {
            for (int i = 1; i <= 10; i++)
            {
                ddlAdultos.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlAdultos.Items.Insert(0, new ListItem("Seleccione cantidad", ""));
            for (int i = 0; i <= 10; i++)
            {
                ddlNinos.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlNinos.Items.Insert(0, new ListItem("Seleccione cantidad", ""));
        }

        protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHabitaciones();
        }

        protected void ddlHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        protected void ddlCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
        }

        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotal();
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
                int adultos = Convert.ToInt32(ddlAdultos.SelectedValue);
                int ninos = Convert.ToInt32(ddlNinos.SelectedValue);
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

                // Llamar al SP usando LinqToDB
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    db.ExecuteProc("sp_InsertarReservacion",
                        new DataParameter("@idPersona", idCliente),
                        new DataParameter("@idHabitacion", idHabitacion),
                        new DataParameter("@fechaEntrada", fechaEntrada),
                        new DataParameter("@fechaSalida", fechaSalida),
                        new DataParameter("@numeroAdultos", adultos),
                        new DataParameter("@numeroNinhos", ninos),
                        new DataParameter("@estado", 'A')
                    );
                }
                lblMensaje.Text = "Reservación creada exitosamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear la reservación: " + ex.Message;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Misreservaciones.aspx");
        }

        private decimal CalcularCostoTotal(int idHabitacion, DateTime fechaEntrada, DateTime fechaSalida, int adultos, int ninos)
        {
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                var habitacion = db.GetTable<Habitacion>().FirstOrDefault(h => h.IdHabitacion == idHabitacion);
                if (habitacion == null)
                {
                    throw new Exception("Habitación no encontrada.");
                }
                var hotel = db.GetTable<Hotel>().FirstOrDefault(h => h.IdHotel == habitacion.IdHotel);
                if (hotel == null)
                {
                    throw new Exception("Hotel no encontrado.");
                }
                decimal precioAdulto = hotel.CostoPorCadaAdulto;
                decimal precioNinho = hotel.CostoPorCadaNinho;
                int dias = (fechaSalida - fechaEntrada).Days;
                decimal totalAdultos = adultos * precioAdulto;
                decimal totalNinos = ninos * precioNinho;
                return dias * (totalAdultos + totalNinos);
            }
        }

        protected void btnConsultarPrecio_Click(object sender, EventArgs e)
        {
            if (ddlHabitacion.SelectedValue != "" && ddlAdultos.SelectedValue != "" && ddlNinos.SelectedValue != "" && txtFechaEntrada.Text != "" && txtFechaSalida.Text != "")
            {
                int idHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
                int adultos = Convert.ToInt32(ddlAdultos.SelectedValue);
                int ninos = Convert.ToInt32(ddlNinos.SelectedValue);
                DateTime fechaEntrada = DateTime.ParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null);
                DateTime fechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null);
                decimal total = CalcularCostoTotal(idHabitacion, fechaEntrada, fechaSalida, adultos, ninos);
                txtTotal.Text = total.ToString("C");
            }
        }

        private void ActualizarTotal()
        {
            if (string.IsNullOrEmpty(ddlHabitacion.SelectedValue) ||
                string.IsNullOrEmpty(txtFechaEntrada.Text) ||
                string.IsNullOrEmpty(txtFechaSalida.Text) ||
                string.IsNullOrEmpty(ddlAdultos.SelectedValue) ||
                string.IsNullOrEmpty(ddlNinos.SelectedValue))
            {
                txtTotal.Text = "";
                return;
            }
            try
            {
                int idHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
                int adultos = Convert.ToInt32(ddlAdultos.SelectedValue);
                int ninos = Convert.ToInt32(ddlNinos.SelectedValue);
                DateTime fechaEntrada = DateTime.ParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null);
                DateTime fechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null);
                decimal total = CalcularCostoTotal(idHabitacion, fechaEntrada, fechaSalida, adultos, ninos);
                txtTotal.Text = total.ToString("C");
            }
            catch
            {
                txtTotal.Text = "";
            }
        }
    }
}
