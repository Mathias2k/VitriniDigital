using VitriniDigital.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dapper.Contrib.Extensions;

namespace VitriniDigital.Domain.Models
{
    public class Cupom
    {
        public int Id { get; private set; }
        public int IdEstabelecimento { get; private set; }

        [Write(false)]
        public List<Imagem> Imagens { get; private set; }

        [Write(false)]
        public List<Link> Links { get; private set; }
        public static class CupomFactory
        {
            public static Cupom AdicionarCupom(int idEstabelecimento)
            {
                var Cupom = new Cupom
                {
                    IdEstabelecimento = idEstabelecimento
                };

                return Cupom;
            }
        }
    }
}
