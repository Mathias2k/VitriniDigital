using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IPortfolioService
    {
        Task<string> AddPortfolioAsync(PortfolioDTO portfolioDto);
        Task<Portfolio> GetPortfolioByIdAsync(string id);
        Task UpdatePortfolioAsync(Portfolio portfolioDto);
    }
}
