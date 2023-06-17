using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Exception;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(500)]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ILogger<EstabelecimentoController> _logger;
        private readonly ILogExceptionRepository _logException;
        private readonly IEstabelecimentoService _estabService;
        public EstabelecimentoController(ILogger<EstabelecimentoController> logger,
                                         ILogExceptionRepository logException,
                                         IEstabelecimentoService estabService)
        {
            _estabService = estabService;
            _logException = logException;
            _logger = logger;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] EstabelecimentoDTO estabDto)
        {
            try
            {
                return Ok(await _estabService.AddEstabelecimentoAsync(estabDto));
            }
            catch (Exception ex)
            {
                string rota = $"{Request.Path.Value} -> {ControllerContext.ActionDescriptor.ActionName}";
                _logger.LogError(ex, rota);
                await _logException.AddErrorAsync(new LogException(rota, ex.Message));
                return StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Estabelecimento>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var respose = await _estabService.GetAllEstabelecimentosAsync();
                if (respose.Any())
                    return Ok(respose);

                return NotFound();
            }
            catch (Exception ex)
            {
                string rota = $"{Request.Path.Value} -> {ControllerContext.ActionDescriptor.ActionName}";
                _logger.LogError(ex, rota);
                await _logException.AddErrorAsync(new LogException(rota, ex.Message));
                return StatusCode(500);
            }
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Estabelecimento), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var estabelecimento = await _estabService.GetEstabelecimentosByIdAsync(id);

                if (!string.IsNullOrEmpty(estabelecimento.Id))
                    return Ok(estabelecimento);

                return NotFound();
            }
            catch (Exception ex)
            {
                string rota = $"{Request.Path.Value} -> {ControllerContext.ActionDescriptor.ActionName}";
                _logger.LogError(ex, rota);
                await _logException.AddErrorAsync(new LogException(rota, ex.Message));
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromBody] Estabelecimento estab)
        {
            try
            {
                if (estab == null)
                    return BadRequest();

                if (await _estabService.UpdateEstabelecimentoAsync(estab))
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                string rota = $"{Request.Path.Value} -> {ControllerContext.ActionDescriptor.ActionName}";
                _logger.LogError(ex, rota);
                await _logException.AddErrorAsync(new LogException(rota, ex.Message));
                return StatusCode(500);
            }
        }

        [Authorize]
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

                if (await _estabService.DesativarEstabelecimentoAsync(id))
                    return Ok();

                return NotFound();
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