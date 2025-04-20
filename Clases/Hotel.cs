using LinqToDB.Mapping;

namespace SistemaReservaciones.Clases

{
    [Table(Name = "Hotel")]
    public class Hotel
    {
        [PrimaryKey, Identity]
        public int IdHotel { get; set; }

        [Column(Name = "nombre")]
        public string Nombre { get; set; }

        [Column(Name = "costoPorCadaAdulto")]
        public decimal CostoPorCadaAdulto { get; set; }

        [Column(Name = "costoPorCadaNinho")]
        public decimal CostoPorCadaNinho { get; set; }
    }
}
