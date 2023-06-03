using System.ComponentModel.DataAnnotations;
using VitriniDigital.Domain.Enum;

namespace VitriniDigital.Domain.DTO
{
    public class EstabelecimentoDTO 
    {
        public string IdUsuario { get; set; }

        [Required(ErrorMessage = "Nome do estabelecimento é obrigatório")]
        public string Nome { get; set; }

        [Required]
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        public EnderecoDTO EnderecoDto { get; set; }

        [Required(ErrorMessage = "Portfólio é obrigatório")]
        public PortfolioDTO PortfolioDto { get; set; }
    }
}