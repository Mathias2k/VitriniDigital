using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface ICupomRepository
    {
        Task<bool> InsertAsync(Cupom cupom);
        Task<Cupom> SelectByIdAsync(string id);
        Task<IEnumerable<Cupom>> SelectByIdEstabelecimentoAsync(string idEstab);
        Task<IEnumerable<Cupom>> SelectAllAsync();
        Task<bool> UpdateCupomAsync(Cupom cupom);
        Task<bool> DeleteAsync(string id);
    }
}
