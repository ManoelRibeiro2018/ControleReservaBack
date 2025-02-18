using ControleReserva.Domain.Model;

namespace ControleReserva.Domain.Interface.Repository
{
    public interface IUsuarioRepository
    {
        Task Create(Usuario usuario);
    }
}
