using Cultura.Application.Dtos.Input;
using Cultura.Application.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.Senac.Cultura.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UsuarioCreateDto usuarioDto)
        {
            await _usuarioService.CreateUsuario(usuarioDto);
            return Ok();
        }
        [HttpGet("Login")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email, [FromQuery] string senha)
        {
            var usuario = await _usuarioService.GetUsuarioByEmail(email, senha);
            if (usuario == null)
                return NotFound("Usuário não encontrado ou credenciais inválidas.");
            return Ok(usuario);
        }
    }
}
