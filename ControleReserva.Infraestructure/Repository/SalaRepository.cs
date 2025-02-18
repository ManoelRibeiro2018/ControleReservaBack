using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Model;
using ControleReserva.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleReserva.Infraestructure.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly ReservaContext _reservaContext;

        public SalaRepository(ReservaContext reservaContext)
        {
            _reservaContext = reservaContext;
        }
        public async Task Create(Sala sala)
        {
            await _reservaContext.Salas.AddAsync(sala);
        }      
    }
}
