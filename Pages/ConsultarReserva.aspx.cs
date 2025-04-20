using DataModels;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class ConsultarReserva : System.Web.UI.Page
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

                    if (esEmpleado)
                    {
                        Response.Redirect("GestionarReservaciones.aspx");
                    }
                    else
                    {
                        Response.Redirect("Misreservaciones.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                // Puedes registrar el error o mostrar un mensaje al usuario
            }
        }

        private void CargarDatosReservacion()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string query = "SELECT * FROM Reservacion WHERE idReservacion = @idReservacion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReservacion", Request.QueryString["id"]);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    // Asegúrate de que estos nombres de columna coincidan con los de tu base de datos
                    ddlHotel.SelectedValue = reader["idHotel"].ToString(); // Cambia 'idHotel' por el nombre correcto si es necesario
                    ddlHabitacion.SelectedValue = reader["idHabitacion"].ToString(); // Cambia 'idHabitacion' por el nombre correcto si es necesario
                    lblNombreCliente.Text = reader["idPersona"].ToString(); // Cambia 'idPersona' por el nombre correcto si es necesario
                    txtFechaEntrada.Text = Convert.ToDateTime(reader["fechaEntrada"]).ToString("dd/MM/yyyy");
                    txtFechaSalida.Text = Convert.ToDateTime(reader["fechaSalida"]).ToString("dd/MM/yyyy");
                    ddlAdultos.SelectedValue = reader["numeroAdultos"].ToString();
                    ddlNinos.SelectedValue = reader["numeroNinhos"].ToString();
                    txtCostoTotal.Text = reader["costoTotal"].ToString();
                }
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

        private void ActualizarTotal()
        {
            if (string.IsNullOrEmpty(ddlHabitacion.SelectedValue) || string.IsNullOrEmpty(txtFechaEntrada.Text) || string.IsNullOrEmpty(txtFechaSalida.Text) || string.IsNullOrEmpty(ddlAdultos.SelectedValue) || string.IsNullOrEmpty(ddlNinos.SelectedValue))
            {
                txtCostoTotal.Text = "";
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
                txtCostoTotal.Text = total.ToString("C");
            }
            catch
            {
                txtCostoTotal.Text = "";
            }
        }

        protected void btnActualizarReservacion_Click(object sender, EventArgs e)
        {
            // Código para actualizar la reservación
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string query = "UPDATE Reservacion SET idHabitacion = @idHabitacion, idPersona = @idPersona, fechaEntrada = @fechaEntrada, fechaSalida = @fechaSalida, totalDiasReservacion = @totalDiasReservacion, numeroAdultos = @numeroAdultos, numeroNinhos = @numeroNinhos, costoTotal = @costoTotal WHERE idReservacion = @idReservacion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReservacion", Request.QueryString["id"]);
                command.Parameters.AddWithValue("@idHabitacion", ddlHabitacion.SelectedValue); // Cambia 'idHabitacion' por el nombre correcto si es necesario
                command.Parameters.AddWithValue("@idPersona", lblNombreCliente.Text); // Cambia 'idPersona' por el nombre correcto si es necesario
                command.Parameters.AddWithValue("@fechaEntrada", DateTime.ParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null));
                command.Parameters.AddWithValue("@fechaSalida", DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null));
                command.Parameters.AddWithValue("@totalDiasReservacion", int.Parse(txtDiasReserva.Text));
                command.Parameters.AddWithValue("@numeroAdultos", int.Parse(ddlAdultos.SelectedValue));
                command.Parameters.AddWithValue("@numeroNinhos", int.Parse(ddlNinos.SelectedValue));
                command.Parameters.AddWithValue("@costoTotal", decimal.Parse(txtCostoTotal.Text));
                connection.Open();
                command.ExecuteNonQuery();
            }
           
        }

        protected void btnCancelarReservacion_Click(object sender, EventArgs e)
        {
            // Código para cancelar la reservación
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string query = "UPDATE Reservacion SET estado = 'I' WHERE idReservacion = @idReservacion";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReservacion", Request.QueryString["id"]);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
