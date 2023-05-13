using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Estabelecimento : Endereco
    {
        [Key]
        [JsonPropertyName("IdEstabelecimento")]
        public int Id { get; private set; }

        [JsonIgnore]
        public int IdTipoEstabelecimento { get; private set; }

        [JsonIgnore]
        public int IdEndereco { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone1 { get; private set; }
        public string Telefone2 { get; private set; }
        public Endereco Endereco { get; set; }
        public Cupom Cupom { get; set; }

        public static class EstabelecimentoFactory
        {
            public static Estabelecimento AdicionarEstabelecimento(EstabelecimentoDTO estabDto, 
                                                                   int idEndereco)
            {
                var estabelecimento = new Estabelecimento
                {
                    IdTipoEstabelecimento = (int)estabDto.TipoEstabelecimento,
                    IdEndereco = idEndereco,
                    Nome = estabDto.Nome,
                    Email = estabDto.Email,
                    Telefone1 = estabDto.Telefone1.Replace("(","").Replace(")","").Replace("-",""),
                    Telefone2 = estabDto.Telefone2.Replace("(", "").Replace(")", "").Replace("-", "")
                };

                return estabelecimento;
            }
        }
    }
}