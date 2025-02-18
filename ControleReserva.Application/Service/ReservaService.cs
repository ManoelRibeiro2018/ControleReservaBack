using ControleReserva.Application.Validator;
using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Interface.Service;
using ControleReserva.Domain.Model;
using Microsoft.Extensions.Logging;

namespace ControleReserva.Application.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ILogger<ReservaService> _logger;
        private readonly ReservaValidator _reservaValidator;

        public ReservaService(IReservaRepository reservaRepository, ILogger<ReservaService> logger)
        {
            _reservaRepository = reservaRepository;
            _logger = logger;
        }

        public async Task<Response> ChangeStatus(int id, Status status)
        {
            try
            {
                var reserva = await _reservaRepository.Get(id);
                if (reserva == null || (reserva.Data - DateTime.Now).TotalHours < 24)
                    return Response.Failure("Reserva só pode ser cancelada com no mínimo 24 horas de antecedência.", false, 404);

                reserva.Status = Status.Cancelada;
                await _reservaRepository.Update(reserva);
                return Response.Successful("Status da reserva atualizado com sucesso", true, 201);
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                                 nameof(ReservaService),
                                 nameof(ChangeStatus),
                                 ex.Message);

                return Response.Failure("Erro ao atualizar status", false, 500);
            }
        }

        public async Task<Response> Create(ReservaDto entity)
        {
            try
            {
                var validationResult = _reservaValidator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                                     nameof(ReservaService),
                                     nameof(Create),
                                     validationResult.Errors.SelectMany(e => e.ErrorMessage));
                }
                var reservasExistentes = await _reservaRepository.GetAll();

                if (reservasExistentes.Any(r => r.SalaId == entity.SalaId && r.Data == entity.Data))
                    return Response.Failure("Uma sala só pode ser reservada se não houver conflitos de horário com outras reservas.", false, 404);

                entity.Status = Status.Confirmada;
                var reserva = Reserva.Map(entity);
                await _reservaRepository.Create(reserva);
                return Response.Failure("Reserva criada com sucesso!.", false, 200);
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                               nameof(ReservaService),
                               nameof(Create),
                               ex.Message);

                return Response.Failure("Erro ao criar reserva", false, 500); 
            }
        }

        public Task<Response> Delete(int id)
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

        public Task<Response> Update(ReservaDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
