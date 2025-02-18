using ControleReserva.Domain.Interface;
using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleReserva.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReservaContext _reservaContext;

        public IUsuarioRepository Usuarios { get; }
        public ISalaRepository Salas { get; }
        public IReservaRepository Reservas { get; }

        public UnitOfWork(ReservaContext reservaContext,
                          IUsuarioRepository usuarioRepo,
                          ISalaRepository salaRepo,
                          IReservaRepository reservaRepo)
        {
            _reservaContext = reservaContext;
            Usuarios = usuarioRepo;
            Salas = salaRepo;
            Reservas = reservaRepo;
        }

        public async Task<int> CommitAsync()
        {
            return await _reservaContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _reservaContext.Dispose();
        }
    }
}
