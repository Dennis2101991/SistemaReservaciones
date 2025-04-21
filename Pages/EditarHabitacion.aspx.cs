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
    public partial class EditarHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idHabitacion = Convert.ToInt32(Request.QueryString["id"]);
                using (var db = new PvProyectoFinalDB("Conn"))
                {
                   
                    var habitacion = db.SpBuscarHabitacionPorId(idHabitacion).FirstOrDefault();
                    if (habitacion != null)
                    {
                        // Validar si está inactiva
                        if (habitacion.Estado == "I")
                        {
                            Response.Redirect("Error.aspx?msg=habitacionInactiva");
                            return;
                        }

                        // Validar si tiene reservaciones activas con fecha futura
                        var tieneReservasActivas = db.SpReservacionesActivasPorHabitacion(idHabitacion).Any();

                        if (habitacion.Estado == "A" && tieneReservasActivas)
                        {
                            Response.Redirect("Error.aspx?msg=habitacionConReservas");
                            return;
                        }

                        lblHotel.Text = habitacion.NombreHotel;
                        txtNumero.Text = habitacion.NumeroHabitacion;
                        txtNumero.ReadOnly = true;
                        txtCapacidad.Text = habitacion.CapacidadMaxima.ToString();
                        txtDescripcion.Text = habitacion.Descripcion;
                    }

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idHabitacion = Convert.ToInt32(Request.QueryString["id"]);
            int capacidad = Convert.ToInt32(txtCapacidad.Text);
            string descripcion = txtDescripcion.Text.Trim();

            using (var db = new PvProyectoFinalDB("Conn"))
            {
                db.ExecuteProc("sp_EditarHabitacion",
                    new DataParameter("@idHabitacion", idHabitacion),
                    new DataParameter("@capacidadMaxima", capacidad),
                    new DataParameter("@descripcion", descripcion)
                );
            }

            Response.Redirect("Exito.aspx?msg=habitacionEditada");
        }
        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            int idHabitacion = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new PvProyectoFinalDB("Conn"))
            {
                db.ExecuteProc("sp_InactivarHabitacion",
                    new DataParameter("@idHabitacion", idHabitacion)
                );
               

            }

            Response.Redirect("GestionarHabitaciones.aspx");
        }


    }
}