using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class LinkService : ILinkService
    {
        private readonly ILinkRepository _linkRepo;
        public LinkService(ILinkRepository linkRepo)
        {
            _linkRepo = linkRepo;
        }
        public async Task AddLinkAsync(List<Link> links)
        {
            if (links.Any())
                foreach (var link in links)
                    await _linkRepo.InsertAsync(link);
        }
        public async Task<IEnumerable<Link>> GetLinkByIdPortfolioAsync(string id)
        {
            return await _linkRepo.SelectByIdPortfolioAsync(id);
        }
        public async Task UpdateLinkAsync(List<Link> links)
        {
            if (links.Any())
                foreach (var link in links)
                    await _linkRepo.UpdateAsync(link);
        }
    }
}
