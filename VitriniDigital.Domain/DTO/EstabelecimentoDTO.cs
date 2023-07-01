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
        public EnderecoDTO EnderecoDto { get; set; }
        public PortfolioDTO PortfolioDto { get; set; }
    }
}