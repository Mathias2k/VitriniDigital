using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IPortfolioRepository _PortfolioRepo;
        public PortfolioService(IPortfolioRepository PortfolioRepo)
        {
            _PortfolioRepo = PortfolioRepo;
        }
        public async Task<bool> AddPortfolioAsync(PortfolioDTO portfolioDto)
        {
            var portfolio = Portfolio.PortfolioFactory.AdicionarPortfolio(portfolioDto.IdEstabelecimento);
            await _PortfolioRepo.InsertAsync(portfolio);

            return true;
        }
        public async Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync()
        {
            return await _PortfolioRepo.SelectAllAsync();
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(Guid id)
        {
            return new Portfolio();
        }

        public async Task UpdatePortfolioAsync(PortfolioDTO userDto)
        {

        }
        public async Task ReportarProblemaAsync()
        {

        }
    }
}
