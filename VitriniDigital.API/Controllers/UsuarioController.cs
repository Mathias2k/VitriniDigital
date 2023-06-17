using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(500)]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(ILogger<UsuarioController> logger,
                                 IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        //[Authorize]
        [HttpPost(Name = "PostUsuario")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                return Ok(await _usuarioService.AddUsuarioAsync(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Post));
                return StatusCode(500);
            }
        }

        //criar ReativarConta

        //[Authorize]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _usuarioService.GetAllUsuariosAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Get));
                return StatusCode(500);
            }
        }

        //[Authorize]
        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var user = await _usuarioService.GetUsuarioByIdAsync(id);
                if (user != null)
                    return Ok(user);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetById));
                return StatusCode(500);
            }
        }

        //[Authorize]
        [HttpGet("{username}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetByUserName(string username)
        {
            try
            {
                var user = await _usuarioService.GetUsuarioByUserNameAsync(username);
                if (user != null)
                    return Ok(user);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetByUserName));
                return StatusCode(500);
            }
        }

        //[Authorize]
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest();

                if (await _usuarioService.DesativarUsuarioAsync(id))
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
                return StatusCode(500);
            }
        }

        [HttpPut("ResetPassword")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ResetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            if(await _usuarioService.ResetarSenhaAsync(email))
                return Ok("Email enviado para recuperação de senha.");

            return StatusCode(500);
        }
    }
}