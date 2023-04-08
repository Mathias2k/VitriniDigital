using DigitalQ.Domain.DTO;
using DigitalQ.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;

namespace DigitalQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(ILogger<UsuarioController> logger,
                                 IUsuarioService usuarioService
            )
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet(Name = "GetUsuario")]
        public async Task<IActionResult> Get()
        {
            var ret = await _usuarioService.GetAllUsuariosAsync();
            return Ok(ret);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ret = await _usuarioService.GetUsuarioByIdAsync(id);

            return Ok(ret);
        }

        [HttpPost(Name = "PostUsuario")]
        public async Task<IActionResult> Post(UsuarioDTO user)
        {
            if (user == null)
                return BadRequest();

            var ret = await _usuarioService.AddUsuarioAsync(user);
            if (ret)
                return Ok();

            return BadRequest();
        }

        [HttpPut(Name = "PutUsuario")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete(Name = "DeleteUsuario")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}