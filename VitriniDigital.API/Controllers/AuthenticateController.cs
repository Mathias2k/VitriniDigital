using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models.Exception;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<CupomController> _logger;
        private readonly ILogExceptionRepository _logException;
        private readonly IHttpClienteService _httpClienteService;
        public AuthenticateController(ILogger<CupomController> logger,
                                      ILogExceptionRepository logException,
                                      IHttpClienteService httpClienteService)
        {
            _logger = logger;
            _logException = logException;
            _httpClienteService = httpClienteService;
        }

        [HttpPost(Name = "Authenticate")]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var token = await _httpClienteService.GetNormalTokenAsync(user);
                if (string.IsNullOrEmpty(token))
                    return Unauthorized();

                return Ok(token);
            }
            catch (Exception ex)
            {
                string rota = $"{Request.Path.Value} -> {ControllerContext.ActionDescriptor.ActionName}";
                _logger.LogError(ex, rota);
                await _logException.AddErrorAsync(new LogException(rota, ex.Message));
                return StatusCode(500);
            }
        }
    }
}