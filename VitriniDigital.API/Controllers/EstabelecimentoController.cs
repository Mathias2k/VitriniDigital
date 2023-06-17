using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(500)]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ILogger<EstabelecimentoController> _logger;
        private readonly IEstabelecimentoService _estabService;
        public EstabelecimentoController(ILogger<EstabelecimentoController> logger,
                                         IEstabelecimentoService estabService)
        {
            _estabService = estabService;
            _logger = logger;
        }

        //[Authorize]
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
                _logger.LogError(ex, nameof(Post));
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
                _logger.LogInformation("passei aqui");

                var respose = await _estabService.GetAllEstabelecimentosAsync();
                if (respose.Any())
                    return Ok(respose);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Get));
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
                _logger.LogError(ex, nameof(GetById));
                return StatusCode(500);
            }
        }

        //[Authorize]
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
                _logger.LogError(ex, nameof(Put));
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

                if (await _estabService.DesativarEstabelecimentoAsync(id))
                    return Ok();

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Delete));
                return StatusCode(500);
            }
        }
    }
}