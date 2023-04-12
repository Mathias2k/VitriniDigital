using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Portfolio>> SelectAllAsync();
        Task InsertAsync(Portfolio user);
    }
}
