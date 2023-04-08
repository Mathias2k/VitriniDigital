using System.ComponentModel.DataAnnotations;

namespace DigitalQ.Domain.DTO
{
    public class ReservaDTO
    {
        [Required]
        public Guid IdUsuario { get; set; }

        [Required]
        public Guid IdEstabelecimento { get; set; }

        [Required]
        public DateTime DataHoraReserva { get; set; }

        [Required]
        public int QtdePessoas { get; set; }
    }
}
