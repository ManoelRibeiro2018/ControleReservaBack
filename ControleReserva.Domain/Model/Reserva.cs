using ControleReserva.Domain.DTOs.Reserva;
using ControleReserva.Domain.Enum;

namespace ControleReserva.Domain.Model
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Data { get; set; }
        public Status Status { get; set; }

        public static Reserva Map(ReservaDto entity) => new()
        {
            Id = entity.Id,
            SalaId = entity.SalaId,
            UsuarioId = entity.Usuario.Id,
            Data = entity.Data,
            Status = entity.Status,
        };

        public void Update(Reserva entity)
        {
            Id = entity.Id;
            SalaId = entity.SalaId;
            UsuarioId = entity.UsuarioId;
            Data = entity.Data;
            Status = entity.Status;
        }
    }
}
