using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface ILinkService
    {
        Task AddLinkAsync(List<Link> links);
        Task<IEnumerable<Link>> GetLinkByIdPortfolioAsync(string id);
        Task UpdateLinkAsync(List<Link> links);
    }
}