using System;
using System.Linq;
using System.Web.UI.WebControls;
using DataModels;
using LinqToDB;
using LinqToDB.Data;
using SistemaReservaciones.Models;

namespace SistemaReservaciones.Pages
{
    public partial class GestionarHabitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHoteles();
            }
        }

        private void CargarHoteles()
        {
            using (var db = new PvProyectoFinalDB("Conn"))
            {
                ddlHotel.DataSource = db.SpVerHoteles().ToList();
                ddlHotel.DataTextField = "Nombre";
                ddlHotel.DataValueField = "IdHotel";
                ddlHotel.DataBind();
                ddlHotel.Items.Insert(0, new ListItem("-- Seleccione --", ""));
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
                var habitaciones = db.SpObtenerHabitacionesPorHotel(idHotel).ToList();
                gvHabitaciones.DataSource = habitaciones;
                gvHabitaciones.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHotel = Convert.ToInt32(ddlHotel.SelectedValue);
                string numero = txtNumeroHabitacion.Text.Trim();
                string estado = ddlEstado.SelectedValue;
                int capacidad = Convert.ToInt32(txtCapacidad.Text);
                string descripcion = txtDescripcion.Text.Trim();

                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    if (string.IsNullOrEmpty(hdnIdHabitacion.Value))
                    {
                        // Crear
                        db.ExecuteProc("sp_CrearHabitacion",
                            new DataParameter("@idHotel", idHotel),
                            new DataParameter("@numeroHabitacion", numero),
                            new DataParameter("@estado", estado),
                            new DataParameter("@capacidadMaxima", capacidad),
                            new DataParameter("@descripcion", descripcion));

                        lblMensaje.Text = "✅ Habitación creada correctamente.";
                    }
                    else
                    {
                        // Modificar
                        int id = Convert.ToInt32(hdnIdHabitacion.Value);
                        db.ExecuteProc("sp_ModificarHabitacion",
                            new DataParameter("@idHabitacion", id),
                            new DataParameter("@numeroHabitacion", numero),
                            new DataParameter("@estado", estado));
                        lblMensaje.Text = "✅ Habitación actualizada correctamente.";
                    }

                    hdnIdHabitacion.Value = "";
                    txtNumeroHabitacion.Text = "";
                    ddlEstado.SelectedIndex = 0;
                    txtCapacidad.Text = "";
                    txtDescripcion.Text = "";

                    CargarHabitaciones();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error: " + ex.Message;
            }

            lblMensaje.CssClass = "alert alert-info";
            lblMensaje.Visible = true;
        }


        protected void btnActivarDesdeFormulario_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hdnIdHabitacion.Value, out int idHabitacion))
            {
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    db.ExecuteProc("sp_ModificarEstadoHabitacion",
                        new DataParameter("@idHabitacion", idHabitacion),
                        new DataParameter("@estado", "A")); // Activar
                }

                lblMensaje.Text = "✅ Habitación activada correctamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;

                // Refrescar tabla
                CargarHabitaciones();
            }
            else
            {
                lblMensaje.Text = "❌ Debe seleccionar una habitación válida.";
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdnIdHabitacion.Value = "";
            txtNumeroHabitacion.Text = "";
            ddlEstado.SelectedIndex = 0;
            lblMensaje.Visible = false;
        }
        protected void gvHabitaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idHabitacion = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Editar")
            {
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    var habitacion = db.SpObtenerHabitacionesPorHotel(Convert.ToInt32(ddlHotel.SelectedValue))
                        .ToList()
                        .Select(h => new HabitacionDTO
                        {
                            IdHabitacion = h.IdHabitacion,
                            NumeroHabitacion = h.NumeroHabitacion,
                            Estado = Convert.ToString(h.Estado)

                        })
                        .FirstOrDefault(h => h.IdHabitacion == idHabitacion);

                    if (habitacion != null)
                    {
                        hdnIdHabitacion.Value = habitacion.IdHabitacion.ToString();
                        txtNumeroHabitacion.Text = habitacion.NumeroHabitacion;

                        // ✅ Verificamos que el estado exista en el DropDown antes de asignarlo
                        var item = ddlEstado.Items.FindByValue(habitacion.Estado?.Trim());
                        if (item != null)
                        {
                            ddlEstado.ClearSelection();
                            ddlEstado.SelectedValue = habitacion.Estado.Trim();
                        }
                    }
                }
            }

            else if (e.CommandName == "Activar")
            {
                int IdHabitacion = Convert.ToInt32(e.CommandArgument);
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                    db.ExecuteProc("sp_ModificarEstadoHabitacion",
                        new DataParameter("@idHabitacion", idHabitacion),
                        new DataParameter("@estado", "A")); // Activar con estado A
                }

                lblMensaje.Text = "✔️ Habitación activada correctamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;

                CargarHabitaciones(); // Refrescar tabla
            }

        }


    }
}
