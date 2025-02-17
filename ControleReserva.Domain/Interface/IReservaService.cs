using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;

namespace ControleReserva.Domain.Interface
{
    public interface IReservaService
    {
        Task ChangeStatus(int id, Status status);
        Task Create(ReservaDto entity);
        Task Update(ReservaDto entity);
        Task Delete(int id);
        Task<ReservaDto> Get(int id);
        Task<List<ReservaDto>> GetAll();
    }
}
