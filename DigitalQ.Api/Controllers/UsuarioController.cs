using DigitalQ.Domain.DTO;
using DigitalQ.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace DigitalQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        //private readonly IReservaService _reservaService;
        public UsuarioController(ILogger<UsuarioController> logger
                                //, 
                                 //IReservaService reservaService
            )
        {
            _logger = logger;
            //_reservaService = reservaService;
        }

        [HttpGet(Name = "GetReserva")]
        public async Task<IActionResult> Get()
        {
            //var ret = _reservaService.GetAllReservaAsync();
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPost(Name = "PostUsuario")]
        public async Task<IActionResult> Post(ReservaDTO reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            if (reserva.QtdePessoas <= 0)
                return BadRequest("A qtde de convidados deve ser maior que 0.");

            //await _reservaService.AddReservaAsync(reserva);
            return Ok();
        }

        [HttpPut(Name = "PutUsuario")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete(Name = "DeleteUsuario")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}