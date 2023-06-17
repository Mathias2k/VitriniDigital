using System;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Cupom
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string IdEstabelecimento { get; set; }
        public DateTime DataValidade { get; set; }
        public decimal Desconto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; private set; }

        [JsonIgnore]
        public bool Ativo { get; private set; }
        public static class CupomFactory
        {
            public static Cupom AdicionarCupom(CupomDTO cupomDto)
            {
                var cupom = new Cupom
                {
                    Id = Guid.NewGuid().ToString(),
                    IdEstabelecimento = cupomDto.IdEstabelecimento,
                    DataValidade = cupomDto.DataValidade,
                    Desconto = cupomDto.Desconto,
                    Descricao = cupomDto.Descricao,
                    DataCadastro = DateTime.Now
                };

                return cupom;
            }
        }
    }
}
