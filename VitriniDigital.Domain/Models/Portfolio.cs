using VitriniDigital.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VitriniDigital.Domain.Models
{
    public class Portfolio
    {
        public Guid Id { get; set; }
        public Guid IdEstabelecimento { get; set; }
        public List<Imagem> Imagens { get; set; }
        public List<Link> Links { get; set; }
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
    public class Imagem
    {
        public Guid Id { get; set; }
        public Guid IdPortfolio { get; set; }
        public string Urls { get; set; }
        public byte[] Image { get; set; } //byte ou base64
    }
    public class Link
    {
        public Guid Id { get; set; }
        public Guid IdPortfolio { get; set; }
        public string Url { get; set; }
    }
}
