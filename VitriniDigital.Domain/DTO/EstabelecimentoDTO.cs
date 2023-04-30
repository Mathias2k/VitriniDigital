using System.ComponentModel.DataAnnotations;
using VitriniDigital.Domain.Enum;

namespace VitriniDigital.Domain.DTO
{
    public class EstabelecimentoDTO 
    {
        [Required(ErrorMessage = "Nome do estabelecimento é obrigatório")]
        public string Nome { get; set; }

        [Required]
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }

        [Required(ErrorMessage = "Endereço de email é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public EnderecoDTO EnderecoDto { get; set; }
    }
}
