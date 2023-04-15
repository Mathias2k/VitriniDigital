using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Controllers;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkController : ControllerBase
    {
        private readonly ILogger<LinkController> _logger;
        public LinkController(ILogger<LinkController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostLink")]
        public async Task<IActionResult> Post(LinkDTO link)
        {
            return Ok();
        }

        [HttpGet(Name = "GetLink")]
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

        [HttpPut(Name = "PutLink")]
        public async Task<IActionResult> Put(Guid id, LinkDTO link)
        {
            await Task.Yield();
            //var ret = await _portfolioService.GetPortfolioByIdAsync(id);

            return Ok();
        }

        [HttpDelete(Name = "DeleteLink")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
