using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Controllers;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagemController : ControllerBase
    {
        private readonly ILogger<ImagemController> _logger;
        public ImagemController(ILogger<ImagemController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "PostImagem")]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file.Length == 0)
                return BadRequest("Deve-se adicionar no minímo 1 imagem.");


            return Ok();
        }

        [HttpGet(Name = "GetImagem")]
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

        [HttpPut(Name = "PutImagem")]
        public async Task<IActionResult> Put(Guid id, ImagemDTO link)
        {

            return Ok();
        }

        [HttpDelete(Name = "DeleteImagem")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
