using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface ILinkRepository
    {
        Task InsertAsync(Link link);
        Task<IEnumerable<Link>> SelectByIdPortfolioAsync(string id);
        Task UpdateAsync(Link link);
    }
}
