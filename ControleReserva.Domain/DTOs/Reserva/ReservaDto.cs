using ControleReserva.Domain.Enum;
using ControleReserva.Domain.Usuario;

namespace ControleReserva.Domain.DTOs.Reserva
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; } = Status.Confirmada;
    }
}
