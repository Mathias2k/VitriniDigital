using DigitalQ.Domain.DTO;
using DigitalQ.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace DigitalQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly ILogger<ReservaController> _logger;
        //private readonly IReservaService _reservaService;
        public ReservaController(ILogger<ReservaController> logger
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

        [HttpPost(Name = "PostReserva")]
        public async Task<IActionResult> Post(ReservaDTO reserva)
        {
            ArgumentNullException.ThrowIfNull(reserva);
            if (reserva.QtdePessoas <= 0)
                return BadRequest("A qtde de convidados deve ser maior que 0.");

            //await _reservaService.AddReservaAsync(reserva);
            return Ok();
        }

        [HttpPut(Name = "PutReserva")]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete(Name = "DeleteReserva")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}