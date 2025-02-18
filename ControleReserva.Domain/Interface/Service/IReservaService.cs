using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;

namespace ControleReserva.Domain.Interface.Service
{
    public interface IReservaService
    {
        Task<Response> ChangeStatus(int id, Status status);
        Task<Response> Create(ReservaDto entity);
        Task<Response> Update(ReservaDto entity);
        Task<Response> Delete(int id);
        Task<ReservaDto> Get(int id);
        Task<List<ReservaDto>> GetAll();
    }
}
