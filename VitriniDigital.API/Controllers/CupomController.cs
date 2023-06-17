using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Models;
using VitriniDigital.Service.Business;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly ILogger<CupomController> _logger;
        private readonly ICupomService _cupomService;
        public CupomController(ILogger<CupomController> logger,
                               ICupomService cupomService)
        {
            _logger = logger;
            _cupomService = cupomService;
        }


        //[Authorize]
        [HttpPost(Name = "PostCupom")]
        public async Task<IActionResult> Post([FromBody] CupomDTO Cupom)
        {
            try
            {
                if (Cupom == null)
                    return BadRequest();

                return Ok(await _cupomService.AddCupomAsync(Cupom));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(Post));
                return StatusCode(500);
            }
        }

        //[Authorize]
        [HttpGet("estabelecimento/{id:guid}")]
        public async Task<IActionResult> GetByIdEstabelecimento(string id)
        {
            var ret = await _cupomService.GetCupomByIdEstabelecimentoAsync(id);
            return Ok(ret);
        }

        //[Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var ret = await _cupomService.GetCupomByIdAsync(id);
                if (ret != null)
                    return Ok(ret);

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, nameof(GetById));
                return StatusCode(500);
            }
        }

        //[Authorize]
        [HttpPut(Name = "PutCupom")]
        public async Task<IActionResult> Put([FromBody] Cupom cupom)
        {
            try
            {
                if (cupom == null)
                    return BadRequest();

                if (await _cupomService.UpdateCupomAsync(cupom))
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
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest();

                if (await _cupomService.DesativarCupomAsync(id))
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