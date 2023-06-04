using System;
using System.Collections.Generic;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Portfolio
    {
        public Portfolio(string id)
        {
            Id = id;
        }
        public Portfolio()
        {

        }
        public string Id { get; private set; }
        public List<Link> Links { get; set; }        
        public List<Imagem> Imagens { get; set; }
        public static class PortfolioFactory
        {
            public static Portfolio AdicionarPortfolio(PortfolioDTO portfolioDto)
            {
                var idPortfolio = Guid.NewGuid().ToString();
                var portfolio = new Portfolio
                {
                    Id = idPortfolio,
                    Links = Link.LinkFactory.AdicionarLink(portfolioDto.Links, idPortfolio),
                    Imagens = Imagem.ImagemFactory.AdicionarImagem(portfolioDto.Imagens, idPortfolio)
                };

                return portfolio;
            }
        }
    }
}
