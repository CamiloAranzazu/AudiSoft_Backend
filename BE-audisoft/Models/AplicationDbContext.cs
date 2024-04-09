using Microsoft.EntityFrameworkCore;

namespace BE_audisoft.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) {
        


        }

        public DbSet<Estudiantes> Estudiantes { get; set; }

        public DbSet<Profesores> Profesores { get; set; }

        public DbSet<Notas> Notas{ get; set; }
    }
}
