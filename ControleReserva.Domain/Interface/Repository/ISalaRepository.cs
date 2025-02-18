using ControleReserva.Domain.Model;

namespace ControleReserva.Domain.Interface.Repository
{
    public interface ISalaRepository
    {       
        Task Create(Sala sala);
    }
}
