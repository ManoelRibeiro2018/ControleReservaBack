using ControleReserva.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleReserva.Infraestructure.Context
{
    public class ReservaContext : DbContext
    {
        public ReservaContext(DbContextOptions<ReservaContext> options) : base(options) { }
       
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
