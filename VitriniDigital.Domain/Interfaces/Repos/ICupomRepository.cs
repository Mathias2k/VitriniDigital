using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface ICupomRepository
    {
        Task<IEnumerable<Cupom>> SelectAllAsync();
        Task InsertAsync(Cupom user);
    }
}
