using System;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Endereco
    {
        public string Id { get; set; }
        public string Logradouro { get; set; } //rua, av, etc
        public string CEP { get; set; }
        public string Complemento { get; set; } 
        public string Numero { get; set; }
        public string PontoReferencia { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public static class EnderecoFactory
        {
            public static Endereco AdicionarEstabelecimento(EnderecoDTO endDto)
            {
                var endereco = new Endereco
                {
                    Id = Guid.NewGuid().ToString(),
                    Logradouro = endDto.Logradouro,
                    CEP = endDto.CEP,
                    Complemento = endDto.Complemento,
                    Numero = endDto.Numero,
                    PontoReferencia = endDto.PontoReferencia,
                    Cidade = endDto.Cidade,
                    Bairro = endDto.Bairro,
                    UF = endDto.UF
                };

                return endereco;
            }
        }
    }
}