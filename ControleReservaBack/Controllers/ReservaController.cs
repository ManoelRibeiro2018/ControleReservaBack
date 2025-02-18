using ControleReserva.Domain.DTOs.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace ControleReservaBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDto usuarioDto)
        {
            return Ok();
        }
    }
}
