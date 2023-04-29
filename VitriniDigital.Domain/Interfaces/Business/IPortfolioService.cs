using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IPortfolioService
    {
        Task<bool> AddPortfolioAsync(PortfolioDTO userDto);
        Task<IEnumerable<Portfolio>> GetAllPortfoliosAsync();
        Task<Portfolio> GetPortfolioByIdAsync(Guid id);
        Task UpdatePortfolioAsync(PortfolioDTO PortfolioDto);
    }
}
