using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Estabelecimento
    {
        public string Id { get; set; }
        public int IdTipoEstabelecimento { get; set; }

        [JsonIgnore]
        public string IdUsuario { get; private set; }
        public string Nome { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        [JsonIgnore]
        public bool Ativo { get; private set; }

        [JsonIgnore]
        public string IdEndereco { get; private set; }
        public Endereco Endereco { get; set; }

        [JsonIgnore]
        public string IdPortfolio { get; private set; }
        public Portfolio Portfolio { get; set; }

        [JsonIgnore]
        public string IdCupons { get; private set; }
        public IEnumerable<Cupom> Cupons { get; set; }
        public static class EstabelecimentoFactory
        {
            public static Estabelecimento AdicionarEstabelecimento(EstabelecimentoDTO estabDto,
                                                                   string idEndereco, string idPortfolio)
            {
                var estabelecimento = new Estabelecimento
                {
                    Id = Guid.NewGuid().ToString(),
                    IdUsuario = estabDto.IdUsuario,
                    IdTipoEstabelecimento = (int)estabDto.TipoEstabelecimento,
                    IdEndereco = idEndereco,
                    IdPortfolio = idPortfolio,
                    Nome = estabDto.Nome,
                    Telefone1 = estabDto.Telefone1.Replace("(","").Replace(")","").Replace("-",""),
                    Telefone2 = estabDto.Telefone2.Replace("(", "").Replace(")", "").Replace("-", "")
                };

                return estabelecimento;
            }
        }
    }
}