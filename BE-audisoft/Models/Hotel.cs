using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_axede.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        public int idCity { get; set; }
        [ForeignKey("idCity")]

        public string Nombre { get; set; }

        


    }
}
