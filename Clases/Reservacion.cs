using LinqToDB.Mapping;
using System;

namespace SistemaReservaciones.Clases

{
    [Table(Name = "Reservacion")]
    public class Reservacion
    {
        [PrimaryKey, Identity]
        public int IdReservacion { get; set; }

        [Column]
        public int IdPersona { get; set; }

        [Column]
        public int IdHabitacion { get; set; }

        [Column]
        public DateTime FechaEntrada { get; set; }

        [Column]
        public DateTime FechaSalida { get; set; }

        [Column]
        public int NumeroAdultos { get; set; }

        [Column]
        public int NumeroNinhos { get; set; }

        [Column]
        public int TotalDiasReservacion { get; set; }

        [Column]
        public decimal CostoPorCadaAdulto { get; set; }

        [Column]
        public decimal CostoPorCadaNinho { get; set; }

        [Column]
        public decimal CostoTotal { get; set; }

        [Column]
        public DateTime FechaCreacion { get; set; }

        [Column]
        public DateTime? FechaModificacion { get; set; }

        [Column]
        public string Estado { get; set; }
    }
}
