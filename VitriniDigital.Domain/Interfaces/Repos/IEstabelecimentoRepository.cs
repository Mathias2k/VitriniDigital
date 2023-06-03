using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IEstabelecimentoRepository
    {
        Task<Estabelecimento> SelectByIdAsync(string idEstab);
        Task<Estabelecimento> SelectByIdUsuarioAsync(string idUsuario);
        Task<IEnumerable<Estabelecimento>> SelectAllAsync();
        Task<string> InsertAsync(Estabelecimento estab);
        Task<bool> UpdateAsync(Estabelecimento estab);
        Task<bool> DeleteAsync(string id);
    }
}
