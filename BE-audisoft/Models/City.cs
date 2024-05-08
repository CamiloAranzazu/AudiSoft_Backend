using System.ComponentModel.DataAnnotations;

namespace BE_axede.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
