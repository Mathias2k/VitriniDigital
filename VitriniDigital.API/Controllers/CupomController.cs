using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;

namespace VitriniDigital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly ILogger<CupomController> _logger;
        private readonly ICupomService _CupomService;
        public CupomController(ILogger<CupomController> logger,
                                   ICupomService CupomService
            )
        {
            _logger = logger;
            _CupomService = CupomService;
        }

        [Authorize]
        [HttpGet(Name = "GetCupom")]
        public async Task<IActionResult> Get()
        {
            var ret = await _CupomService.GetAllCupomsAsync();
            return Ok(ret);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ret = await _CupomService.GetCupomByIdAsync(id);

            return Ok(ret);
        }

        [Authorize]
        [HttpPost(Name = "PostCupom")]
        public async Task<IActionResult> Post([FromBody]CupomDTO Cupom)
        {
            if (Cupom == null)
                return BadRequest();

            var ret = await _CupomService.AddCupomAsync(Cupom);
            if (ret)
                return Ok();

            return BadRequest();
        }

        [Authorize]
        [HttpPut(Name = "PutCupom")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [Authorize]
        [HttpDelete(Name = "DeleteCupom")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}