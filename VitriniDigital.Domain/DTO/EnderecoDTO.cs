﻿namespace VitriniDigital.Domain.DTO
{
    public class EnderecoDTO
    {
        public string Logradouro { get; set; } //rua, av, etc
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string PontoReferencia { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
    }
}
