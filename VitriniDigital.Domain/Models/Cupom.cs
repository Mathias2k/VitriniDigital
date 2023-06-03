using System;

namespace VitriniDigital.Domain.Models
{
    public class Cupom
    {
        public string Id { get; private set; }
        public string IdEstabelecimento { get; set; }
        public DateTime DataValidade { get; set; }
        public int Desconto { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        //gerar QRCODE -- futuro todo

        //[Write(false)]
        //public List<Imagem> Imagens { get; private set; }

        //[Write(false)]
        //public List<Link> Links { get; private set; }
        public static class CupomFactory
        {
            public static Cupom AdicionarCupom(string idEstabelecimento)
            {
                var Cupom = new Cupom
                {
                    Id = Guid.NewGuid().ToString(),
                    IdEstabelecimento = idEstabelecimento
                };

                return Cupom;
            }
        }
    }
}
