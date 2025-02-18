using ControleReserva.Application.Validator;
using ControleReserva.Domain.DTOs;
using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Interface.Repository;
using ControleReserva.Domain.Interface.Service;
using ControleReserva.Domain.Model;
using Microsoft.Extensions.Logging;
using System.Text;

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

                    StringBuilder sb = new();
                    validationResult.Errors.Select(e => e.ErrorMessage).ToList().ForEach(e => { sb.AppendLine(e); });
                    return Response.Failure(sb.ToString(), false, 404);

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

        public async Task<Response> Delete(int id)
        {
            try
            {
                await _reservaRepository.Delete(id);
                return Response.Failure("Reserva removida com sucesso!", false, 204);

            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                              nameof(ReservaService),
                              nameof(Delete),
                              ex.Message);

                return Response.Failure("Erro ao removida reserva", false, 500);
            }
        }
        public async Task<Response> Update(ReservaDto entity)
        {
            try
            {
                var validationResult = _reservaValidator.Validate(entity);

                if (!validationResult.IsValid)
                {
                    _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                                     nameof(ReservaService),
                                     nameof(Update),
                                     validationResult.Errors.SelectMany(e => e.ErrorMessage));

                    StringBuilder sb = new();
                    validationResult.Errors.Select(e => e.ErrorMessage).ToList().ForEach(e => { sb.AppendLine(e); });
                    return Response.Failure(sb.ToString(), false, 404);

                }

                var reserva = Reserva.Map(entity);
                await _reservaRepository.Update(reserva);
                return Response.Failure("Reserva atualizada com sucesso!", false, 204);

            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                              nameof(ReservaService),
                              nameof(Update),
                              ex.Message);

                return Response.Failure("Erro ao atualizar reserva", false, 500);
            }
        }
        public async Task<Response> Get(int id)
        {
            try
            {
                var reserva = await _reservaRepository.Get(id);
                return Response.Successful("Sucesso ao consultar", true, 200, reserva);
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                                nameof(ReservaService),
                                nameof(Update),
                                ex.Message);

                return Response.Failure("Erro ao consultar reserva", false, 500);
            }
        }

        public async Task<Response> GetAll()
        {
            try
            {
                var reservas = await _reservaRepository.GetAll();
                return Response.Successful("Sucesso ao consultar", true, 200, reservas);
            }
            catch (Exception ex)
            {
                _logger.LogError("{ClasseName} - {MethodName} - {Message}",
                                nameof(ReservaService),
                                nameof(Update),
                                ex.Message);

                return Response.Failure("Erro ao consultar todas as reserva", false, 500);
            }
        }
    }
}
