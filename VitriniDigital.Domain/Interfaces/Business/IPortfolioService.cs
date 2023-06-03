using System;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IPortfolioService
    {
        Task<string> AddPortfolioAsync(PortfolioDTO portfolioDto);
        Task<Portfolio> GetPortfolioByIdAsync(Guid id);
        Task UpdatePortfolioAsync(PortfolioDTO portfolioDto);
    }
}
