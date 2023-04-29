using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Enum;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.DTO
{
    public class EstabelecimentoDTO : Endereco
    {
        [Required]
        public string Nome { get; set; }
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }
        public Portfolio Portfolio { get; set; } //1-1

        [EmailAddress]
        public string Email { get; private set; }
        //public string DDD { get; private set; }
        public List<string> Telefones { get; set; }
    }
}
