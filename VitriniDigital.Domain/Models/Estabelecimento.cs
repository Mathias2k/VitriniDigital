using VitriniDigital.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace VitriniDigital.Domain.Models
{
    public class Estabelecimento : Endereco
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }
        public List<Portfolio> Portfolios {get; set;}

        [EmailAddress]
        public string Email { get; private set; }
        //public string DDD { get; private set; }
        public List<string> Telefones { get; set; }
    }
}
