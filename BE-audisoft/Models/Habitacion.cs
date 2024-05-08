using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_axede.Models
{
    public class Habitaciones
    {
        [Key]
        public int Id { get; set; }

        public int idTypeHabitacion { get; set; }
        [ForeignKey("idTypeHabitacion")]

        public int idHotel { get; set; }
        [ForeignKey("idHotel")]

        public int PriceAlto { get; set; }

        public int PriceBajo { get; set; }

        public int maxPersonas { get; set; }
    }
}
