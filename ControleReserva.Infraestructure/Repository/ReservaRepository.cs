using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Model;
using ControleReserva.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleReserva.Infraestructure.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly ReservaContext _reservaContext;

        public ReservaRepository(ReservaContext reservaContext)
        {
            _reservaContext = reservaContext;
        }

        public async Task ChangeStatus(int id, Status status)
        {
            var reserva = await Get(id);
            if (reserva != null)
            {
                reserva.Status = status;
                _reservaContext.Reservas.Update(reserva);
                await _reservaContext.SaveChangesAsync();
            }
        }

        public async Task Create(Reserva entity)
        {
            _reservaContext.Reservas.Add(entity);
            await _reservaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var reserva = await Get(id);
            if (reserva != null)
            {
                _reservaContext.Reservas.Remove(reserva);
                await _reservaContext.SaveChangesAsync();
            }
        }

        public async Task<Reserva> Get(int id)
        {
            var result = await _reservaContext.Reservas.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<List<Reserva>> GetAll()
        {
            var result = await _reservaContext.Reservas.ToListAsync();
            return result;
        }

        public async Task Update(Reserva entity)
        {
            var reserva = await Get(entity.Id);
            if (reserva != null)
            {
                reserva.Update(entity);
                await _reservaContext.SaveChangesAsync();
            }
        }
    }
}
