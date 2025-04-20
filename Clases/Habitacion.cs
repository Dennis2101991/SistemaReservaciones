using LinqToDB.Mapping;

namespace SistemaReservaciones.Clases

{
    [Table(Name = "Habitacion")]
    public class Habitacion
    {
        [PrimaryKey, Identity]
        public int IdHabitacion { get; set; }

        [Column(Name = "idHotel")]
        public int IdHotel { get; set; }

        [Column(Name = "numero")]
        public string Numero { get; set; } // o el nombre real que tenga
    }
}
