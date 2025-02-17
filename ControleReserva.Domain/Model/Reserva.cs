using ControleReserva.Domain.Enum;

namespace ControleReserva.Domain.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; } = Status.Confirmada;
    }
}
