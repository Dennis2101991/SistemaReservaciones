using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaReservaciones.Models
{
    public class SpObtenerReservacionPorIdResult
    {
        public int idReservacion { get; set; }
        public int idPersona { get; set; }
        public int idHabitacion { get; set; }
        public DateTime fechaEntrada { get; set; }
        public DateTime fechaSalida { get; set; }
        public int numeroAdultos { get; set; }
        public int numeroNinhos { get; set; }
        public int totalDiasReservacion { get; set; }
        public decimal costoPorCadaAdulto { get; set; }
        public decimal costoPorCadaNinho { get; set; }
        public decimal costoTotal { get; set; }
        public string estado { get; set; }
        public string nombreCliente { get; set; }
        public int idHotel { get; set; }
        public int numeroHabitacion { get; set; }
        public string nombreHotel { get; set; }
    }

}