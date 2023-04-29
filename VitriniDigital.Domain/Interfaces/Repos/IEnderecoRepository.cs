using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IEnderecoRepository
    {
        Task<int> InsertAsync(EnderecoDTO end);
        Task<Endereco> SelectByIdAsync(int idEnd);
        Task<IEnumerable<Endereco>> SelectAllAsync();
    }
}
