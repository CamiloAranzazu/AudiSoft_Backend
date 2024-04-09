using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_audisoft.Models
{
    public class Notas
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int idProfesor { get; set; }
        [ForeignKey("idProfesor")]

        public int idEstudiante { get; set; }
        [ForeignKey("idEstudiante")]

        public int Valor { get; set; }

    }
}
