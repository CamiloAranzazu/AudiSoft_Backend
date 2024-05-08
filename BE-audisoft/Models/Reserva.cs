using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_axede.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int idHabitacion { get; set; }
        [ForeignKey("idHabitacion")]

        public int people { get; set; }

    }
}
