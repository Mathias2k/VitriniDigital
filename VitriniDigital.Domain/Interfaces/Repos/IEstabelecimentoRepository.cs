using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IEstabelecimentoRepository
    {
        Task<Estabelecimento> SelectByIdAsync(int idEstab);
        Task<IEnumerable<Estabelecimento>> SelectAllAsync();
        Task<int> InsertAsync(Estabelecimento estab);
        Task<int> UpdateAsync(int id, EstabelecimentoDTO estab);
        Task<int> DeleteAsync(int id);
    }
}
