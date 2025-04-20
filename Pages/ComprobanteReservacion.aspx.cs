using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;

namespace SistemaReservaciones.Pages
{
    public partial class ComprobanteReservacion : System.Web.UI.Page
    {
        
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Validar si el parámetro existe
                    if (Request.QueryString["id"] != null)
                    {
                        int idReserva;

                        // Validar que sea numérico
                        if (int.TryParse(Request.QueryString["id"], out idReserva))
                        {
                            using (var db = new PvProyectoFinalDB("Conn"))
                            {
                                var reserva = db.SpObtenerReservacionPorId(idReserva).FirstOrDefault();

                                if (reserva != null)
                                {
                                    lblHotel.Text = reserva.NombreHotel;
                                    lblCliente.Text = reserva.NombreCliente;
                                    lblFechaEntrada.Text =  reserva.FechaEntrada.ToShortDateString();
                                    lblFechaSalida.Text =  reserva.FechaSalida.ToShortDateString();
                                    lblHabitacion.Text =  reserva.NumeroHabitacion;
                                    lblTotal.Text = "₡" + reserva.CostoTotal;
                                }
                                else
                                {
                                    lblHotel.Text = "⚠ No se encontró la reservación con el ID: " + idReserva;
                                }
                            }
                        }
                        else
                        {
                            lblHotel.Text = "❌ El parámetro ID no es válido.";
                        }
                    }
                    else
                    {
                        lblHotel.Text = "❌ Falta el parámetro ID en la URL.";
                    }
                }
                catch (Exception ex)
                {
                    lblHotel.Text = "⚠ Ocurrió un error al cargar el comprobante: " + ex.Message;
                }
            }
        }


    }
}