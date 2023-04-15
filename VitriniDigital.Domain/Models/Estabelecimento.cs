using System;
using System.Collections.Generic;
using VitriniDigital.Domain.Enum;

namespace VitriniDigital.Domain.Models
{
    public class Estabelecimento : Endereco
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoEstabelecimento TipoEstabelecimento { get; set; }
        public Portfolio Portfolio {get; set;} //1-1
        public string Email { get; private set; }
        //public string DDD { get; private set; }
        public List<string> Telefones { get; set; }
    }
}
