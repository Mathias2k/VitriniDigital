using System.ComponentModel.DataAnnotations;
using VitriniDigital.Domain.Enum;

namespace VitriniDigital.Domain.DTO
{
    public class EstabelecimentoDTO 
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        [Required]
        public EnderecoDTO EnderecoDto { get; set; }
    }
}
