using System;
using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class CupomDTO
    {
        [Required]
        public string IdEstabelecimento { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }

        [Required]
        public decimal Desconto { get; set; }

        [Required]
        public string Descricao { get; set; }       
    }
}
