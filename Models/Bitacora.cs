using System;
using SistemaReservaciones.Models;


namespace SistemaReservaciones.Models
{
    public class Bitacora
    {
        public int idBitacora { get; set; }
        public int idReservacion { get; set; }
        public int idPersona { get; set; }
        public string accionRealizada { get; set; }
        public DateTime fechaDeLaAccion { get; set; }
    }
}
