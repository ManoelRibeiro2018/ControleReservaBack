using ControleReserva.Domain.Interface.Repository;

namespace ControleReserva.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        ISalaRepository Salas { get; }
        IReservaRepository Reservas { get; }

        Task<int> CommitAsync();
    }
}
