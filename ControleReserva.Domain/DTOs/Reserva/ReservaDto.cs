using ControleReserva.Domain.DTOs.Usuario;
using ControleReserva.Domain.Enum;

namespace ControleReserva.Domain.DTOs.Reserva
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public UsuarioDto Usuario { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }

    }
}
