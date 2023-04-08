using DigitalQ.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalQ.Domain.Models
{
    public class Portfolio
    {
        public Guid Id { get; set; }
        public Guid IdEstabelecimento { get; set; }
        public List<UrlImagem> UrlsImagens { get; set; }
        public static class PortfolioFactory
        {
            public static Portfolio AdicionarPortfolio(PortfolioDTO portfolioDto)
            {
                var portfolio = new Portfolio
                {
                    Id = Guid.NewGuid(),
                    //IdEstabelecimento = portfolioDto.IdEstabelecimento,
                    //UrlsImagens.AddRange(portfolioDto.UrlsImagens)
                };

                return portfolio;
            }
        }
    }

    public class UrlImagem
    {
        public Guid Id { get; set; }
        public Guid IdPortfolio { get; set; }
        public string Urls { get; set; }
        public byte[] Imagem { get; set; } //talvez List<byte[]>
    }

}
