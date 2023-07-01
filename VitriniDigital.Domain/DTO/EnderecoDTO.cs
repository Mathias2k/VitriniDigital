using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class EnderecoDTO
    {
        [Required]
        public string Logradouro { get; set; } //rua, av, etc
        public string CEP { get; set; }
        public string Complemento { get; set; }

        [Required]
        public string Numero { get; set; }
        public string PontoReferencia { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }
        public string UF { get; set; }
    }
}
