using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaReservaciones.Pages
{
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Cargar listas de hoteles y cantidades antes de asignar valores
                    CargarHoteles();
                    LlenarListasCantidad();

                    int idReserva;
                    if (int.TryParse(Request.QueryString["id"], out idReserva))
                    {
                        hdnReserva.Value = idReserva.ToString();

                        using (var db = new PvProyectoFinalDB("Conn"))
                        {
                            var reserva = db.SpObtenerReservacionPorId(idReserva).FirstOrDefault();

                            if (reserva != null)
                            {
                                lblNombreCliente.Text = reserva.NombreCliente;
                                ddlHotel.SelectedValue = reserva.IdHotel.ToString();

                                // Cargar habitaciones según el hotel antes de seleccionarla
                                CargarHabitaciones();
                                ddlHabitacion.SelectedValue = reserva.IdHabitacion.ToString();

                                ddlAdultos.SelectedValue = reserva.NumeroAdultos.ToString();
                                ddlNinos.SelectedValue = reserva.NumeroNinhos.ToString();
                                txtFechaEntrada.Text = reserva.FechaEntrada.ToString("dd/MM/yyyy");
                                txtFechaSalida.Text = reserva.FechaSalida.ToString("dd/MM/yyyy");
                                txtTotal.Text = reserva.CostoTotal.ToString("₡");
                            }
                            else
                            {
                                lblMensaje.Text = "No se encontró la reservación.";
                            }
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "No se proporcionó un ID de reservación.";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar los datos: " + ex.Message;
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
            ddlAdultos.Items.Clear();
            ddlNinos.Items.Clear();

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

        private void CargarHabitaciones()
        {
            if (!string.IsNullOrEmpty(ddlHotel.SelectedValue))
            {
                int idHotel = Convert.ToInt32(ddlHotel.SelectedValue);

                try
                {
                    using (var db = new PvProyectoFinalDB("Conn"))
                    {
                        // Llamar al SP que ya tenés
                        var habitaciones = db.SpConsultarDisponibilidadHabitaciones(idHotel, null, null).ToList();

                        ddlHabitacion.DataSource = habitaciones;
                        ddlHabitacion.DataTextField = "NumeroHabitacion";
                        ddlHabitacion.DataValueField = "IdHabitacion";
                        ddlHabitacion.DataBind();
                        ddlHabitacion.Items.Insert(0, new ListItem("Seleccione una habitación", ""));
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "❌ Error al cargar habitaciones: " + ex.Message;
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idReserva = Convert.ToInt32(Request.QueryString["id"]);
                int idPersona = Convert.ToInt32(Session["idPersona"]);
                int idHabitacion = Convert.ToInt32(ddlHabitacion.SelectedValue);
                int adultos = Convert.ToInt32(ddlAdultos.SelectedValue);
                int ninos = Convert.ToInt32(ddlNinos.SelectedValue);
                DateTime fechaEntrada = DateTime.ParseExact(txtFechaEntrada.Text, "dd/MM/yyyy", null);
                DateTime fechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy", null);

                // Obtención de costos (ejemplo, podrías obtener esto de la base de datos si no los tienes)
                decimal costoAdulto = 100; // cambiar por lo que tengas
                decimal costoNinho = 50;   // cambiar por lo que tengas
                int dias = (fechaSalida - fechaEntrada).Days;
                decimal costoTotal = dias * ((adultos * costoAdulto) + (ninos * costoNinho));

                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    db.SpModificarReservacion(
                        idReserva,
                        fechaEntrada,
                        fechaSalida,
                        adultos,
                        ninos,
                        idHabitacion,
                        costoAdulto,
                        costoNinho,
                        dias,
                        costoTotal,
                        idPersona
                    );
                }

                lblMensaje.Text = "Reservación actualizada correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar la reservación: " + ex.Message;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idReserva = Convert.ToInt32(hdnReserva.Value);
                int idPersona = Convert.ToInt32(Session["idPersona"]);

                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    var resultado = db.SpEliminarReservacionPorId(idReserva, idPersona).FirstOrDefault();

                    if (resultado != null && resultado.Mensaje == "Reservación cancelada correctamente.")
                    {
                        Response.Redirect("~/Pages/Exito.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrió un problema al cancelar la reservación.";
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Pages/Error.aspx?msg=" + Server.UrlEncode(ex.Message));
            }
        }







    }
}
