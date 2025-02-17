using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Interface.Repository;

namespace ControleReserva.Infraestructure.Repository
{
    public class ReservaRepository : IReservaRepository
    {

        public async Task ChangeStatus(int id, Status status)
        {
            throw new NotImplementedException();
        }

        public Task Create(ReservaDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReservaDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReservaDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ReservaDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
