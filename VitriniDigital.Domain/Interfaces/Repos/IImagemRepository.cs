using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IImagemRepository
    {
        Task InsertAsync(Imagem link);
        Task<IEnumerable<Imagem>> SelectByIdPortfolioAsync(string id);
        Task UpdateAsync(Imagem imagem);
    }
}
