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
    public class Portfolio
    {
        public int Id { get; private set; }
        public int IdEstabelecimento { get; private set; }

        //[Write(false)]
        //public List<Imagem> Imagens { get; private set; }

        //[Write(false)]
        //public List<Link> Links { get; private set; }
        public static class PortfolioFactory
        {
            public static Portfolio AdicionarPortfolio(int idEstabelecimento)
            {
                var portfolio = new Portfolio
                {
                    IdEstabelecimento = idEstabelecimento
                };

                return portfolio;
            }
        }
    }
}
