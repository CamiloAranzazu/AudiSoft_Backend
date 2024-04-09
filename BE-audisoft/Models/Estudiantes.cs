using System.ComponentModel.DataAnnotations;

namespace BE_audisoft.Models
{
    public class Estudiantes
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
    }
}
