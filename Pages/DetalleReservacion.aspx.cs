using System;
using System.Linq;
using System.Web.UI;
using DataModels;
using LinqToDB.Data;

namespace SistemaReservaciones.Pages
{
    public partial class DetalleReservacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int idReserva;
                if (!int.TryParse(Request.QueryString["id"], out idReserva))
                {
                    Response.Redirect("DetalleReservacion.aspx");
                    return;
                }

                CargarDetalleReservacion(idReserva);
            }
        }

        private void CargarDetalleReservacion(int idReserva)
        {
            int idUsuario = Convert.ToInt32(Session["idPersona"]);
            bool esEmpleado = Convert.ToBoolean(Session["esEmpleado"]);

            using (var db = new PvProyectoFinalDB("Conn"))
            {
                var reservacion = db.SpObtenerReservacionPorId(idReserva).FirstOrDefault();

                if (reservacion == null)
                {
                    Response.Redirect("MisReservaciones.aspx");
                    return;
                }

                // Validar si el cliente puede ver su propia reservación
                if (!esEmpleado && reservacion.IdPersona != idUsuario)
                {
                    Response.Redirect("MisReservaciones.aspx");
                    return;
                }

                // ✅ Mostrar los datos correctamente
                lblId.Text = reservacion.IdReservacion.ToString();
                lblHotel.Text = reservacion.NombreHotel;
                lblHabitacion.Text = reservacion.NumeroHabitacion;
                lblCliente.Text = reservacion.NombreCliente;
                lblFechaEntrada.Text = reservacion.FechaEntrada.ToString("dd/MM/yyyy");
                lblFechaSalida.Text = reservacion.FechaSalida.ToString("dd/MM/yyyy");
                lblDias.Text = reservacion.TotalDiasReservacion.ToString();
                lblAdultos.Text = reservacion.NumeroAdultos.ToString();
                lblNinos.Text = reservacion.NumeroNinhos.ToString();
                lblCosto.Text = string.Format("${0:N2}", reservacion.CostoTotal);
            }
        }



        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            bool esEmpleado = Convert.ToBoolean(Session["esEmpleado"]);
            if (esEmpleado)
                Response.Redirect("GestionarReservaciones.aspx");
            else
                Response.Redirect("MisReservaciones.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            int idReserva = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect("EditarReservacion.aspx?id=" + idReserva);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            int idReserva = Convert.ToInt32(Request.QueryString["id"]);
            int idUsuario = Convert.ToInt32(Session["idPersona"]);

            using (var db = new PvProyectoFinalDB("Conn"))
            {
                db.ExecuteProc("sp_ModificarEstadoReservacion",
                    new DataParameter("@idReservacion", idReserva),
                    new DataParameter("@estado", "C"));

                db.SpInsertarBitacora(idReserva, idUsuario, "Cancelada", DateTime.Now);
            }

            Response.Redirect("MisReservaciones.aspx");
        }
    }
}
