using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Controllers;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentoController : ControllerBase
    {
        private readonly ILogger<EstabelecimentoController> _logger;
        public EstabelecimentoController(ILogger<EstabelecimentoController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostEstabelecimento")]
        public async Task<IActionResult> Post(EstabelecimentoDTO estab)
        {
            return Ok();
        }

        [HttpGet(Name = "GetEstabelecimento")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            await Task.Yield();
            //var ret = await _portfolioService.GetPortfolioByIdAsync(id);

            return Ok();
        }

        [HttpPut(Name = "PutEstabelecimento")]
        public async Task<IActionResult> Put(Guid id, LinkDTO link)
        {
            await Task.Yield();
            //var ret = await _portfolioService.GetPortfolioByIdAsync(id);

            return Ok();
        }

        [HttpDelete(Name = "DeleteEstabelecimento")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
