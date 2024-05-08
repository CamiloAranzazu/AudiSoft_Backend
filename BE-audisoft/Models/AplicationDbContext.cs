using BE_axede.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_axede.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) {
        


        }

        public DbSet<City> City { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Habitaciones> Habitaciones { get; set; }

        public DbSet<TypeHabitacion> TypeHabitacion { get; set; }

        public DbSet<Reserva> Reserva { get; set; }

    }
}
