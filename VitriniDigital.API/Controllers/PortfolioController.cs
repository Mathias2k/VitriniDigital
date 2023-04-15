using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly IPortfolioService _portfolioService;
        public PortfolioController(ILogger<PortfolioController> logger,
                                   IPortfolioService portfolioService
            )
        {
            _logger = logger;
            _portfolioService = portfolioService;
        }

        [Authorize]
        [HttpGet(Name = "GetPortfolio")]
        public async Task<IActionResult> Get()
        {
            var ret = await _portfolioService.GetAllPortfoliosAsync();
            return Ok(ret);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ret = await _portfolioService.GetPortfolioByIdAsync(id);

            return Ok(ret);
        }

        [HttpPost(Name = "PostPortfolio")]
        public async Task<IActionResult> Post([FromBody]PortfolioDTO portfolio)
        {
            if (portfolio == null)
                return BadRequest();

            var ret = await _portfolioService.AddPortfolioAsync(portfolio);
            if (ret)
                return Ok();

            return BadRequest();
        }

        [HttpPut(Name = "PutPortfolio")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete(Name = "DeletePortfolio")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}