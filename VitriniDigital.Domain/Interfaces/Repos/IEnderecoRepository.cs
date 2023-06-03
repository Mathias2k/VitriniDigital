using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IEnderecoRepository
    {
        Task<string> InsertAsync(Endereco end);
        Task<Endereco> SelectByIdAsync(string idEnd);
        Task<IEnumerable<Endereco>> SelectAllAsync();
        Task<int> UpdateAsync(Endereco end);
        Task<int> DeleteAsync(string id);
    }
}
