using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class PortfolioService : IPortfolioService
    {
        public Task<string> AddPortfolioAsync(PortfolioDTO portfolioDto)
        {
            throw new NotImplementedException();
        }

        public Task<Portfolio> GetPortfolioByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePortfolioAsync(PortfolioDTO portfolioDto)
        {
            throw new NotImplementedException();
        }
    }
}
