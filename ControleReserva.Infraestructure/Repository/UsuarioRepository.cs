using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Model;
using ControleReserva.Infraestructure.Context;

namespace ControleReserva.Infraestructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ReservaContext _reservaContext;

        public UsuarioRepository(ReservaContext reservaContext)
        {
            _reservaContext = reservaContext;
        }

        public Task Create(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
