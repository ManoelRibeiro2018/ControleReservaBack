using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Model;

namespace ControleReserva.Domain.Interface.Repository
{
    public interface IReservaRepository
    {
        Task ChangeStatus(int id, Status status);
        Task Create(Reserva entity);
        Task Update(Reserva entity);
        Task Delete(int id);
        Task<Reserva> Get(int id);
        Task<List<Reserva>> GetAll();
    }
}
