using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _usuarioService.GetAllUsuariosAsync());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(Get));
                throw;
            }
        }

        //[add ratelimite]
        //[Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var user = await _usuarioService.GetUsuarioByIdAsync(id.ToString());
                if (user != null)
                    return Ok(user);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetById));
                throw;
            }
        }

        //[add ratelimite]
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                if (await _usuarioService.AddUsuarioAsync(user))
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Post));
                throw;
            }
        }

        //[add ratelimite]
        //delete logico
        //[Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _usuarioService.DesativarUsuarioAsync(id.ToString()))
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
                throw;
            }
        }
    }
}