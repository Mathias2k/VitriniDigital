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
        //[HttpPost(Name = "PostEstabelecimento")]
        //[ProducesResponseType(typeof(ResponseResult), 200)]
        //public async Task<IActionResult> Post(EstabelecimentoDTO estabDto)
        //{
        //    return Ok(await _estabService.AddEstabelecimentoAsync(estabDto));
        //}

        [HttpGet(Name = "GetEstabelecimento")]
        [ProducesResponseType(typeof(List<Estabelecimento>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var respose = await _estabService.GetAllEstabelecimentosAsync();
            if(respose.Any())
                return Ok(respose);

            return NotFound();
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Estabelecimento), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            //buscar o e
            var respose = await _estabService.GetEstabelecimentosByIdAsync(id);

            if(respose.Id != 0)
                return Ok(respose);

            return NotFound();
        }

        //[Authorize]
        [HttpPut(Name = "PutEstabelecimento")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put(int id, EstabelecimentoDTO estabDto)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await _estabService.UpdateEstabelecimentoAsync(id, estabDto));
        }

        //[Authorize]
        [HttpDelete(Name = "DeleteEstabelecimento")]
        [ProducesResponseType(typeof(ResponseResult), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            return Ok(await _estabService.DeleteEstabelecimentoAsync(id));
        }
    }
}