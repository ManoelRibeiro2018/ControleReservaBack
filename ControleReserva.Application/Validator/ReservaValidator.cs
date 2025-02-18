using ControleReserva.Domain.DTOs.Reserva;
using FluentValidation;

namespace ControleReserva.Application.Validator
{
    public class ReservaValidator : AbstractValidator<ReservaDto>
    {
        public ReservaValidator() { 
            RuleFor(e => e.SalaId).NotEmpty();
            RuleFor(e => e.Usuario.Email).EmailAddress();
            RuleFor(e => e.Usuario.Nome).NotEmpty();
            RuleFor(e => e.Data).NotEqual(default(DateTime));
        }
    }
}
