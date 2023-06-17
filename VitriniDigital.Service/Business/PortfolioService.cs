using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ILinkService _linkService;
        private readonly IImagemService _imagemService;
        public PortfolioService(ILinkService linkService,
                                IImagemService imagemService)
        {
            _linkService = linkService;
            _imagemService = imagemService;
        }
        public async Task<string> AddPortfolioAsync(PortfolioDTO portfolioDto)
        {
            var portfolio = Portfolio.PortfolioFactory.AdicionarPortfolio(portfolioDto);

            await _linkService.AddLinkAsync(portfolio.Links);
            await _imagemService.AddImagemAsync(portfolio.Imagens);

            return portfolio.Links.Any() &&
                   portfolio.Imagens.Any() ? portfolio.Id : null;
        }
        public async Task<Portfolio> GetPortfolioByIdAsync(string id)
        {
            var portfolio = new Portfolio(id)
            {
                Links = new(),
                Imagens = new()
            };

            var links = await _linkService.GetLinkByIdPortfolioAsync(id);
            if (links.Any())
                portfolio.Links.AddRange(links);

            var imagens = await _imagemService.GetImagemByIdPortfolioAsync(id);
            if (imagens.Any())
                portfolio.Imagens.AddRange(imagens);

            return portfolio;
        }
        public async Task UpdatePortfolioAsync(Portfolio portfolio)
        {
            await _linkService.UpdateLinkAsync(portfolio.Links);
            await _imagemService.UpdateImagemAsync(portfolio.Imagens);
        }
    }
}
