using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IEnderecoService
    {
        Task<int> AddEnderecoAsync(EnderecoDTO endDto);
        Task<Endereco> GetEnderecoByIdAsync(int idEnd);
        Task UpdateEnderecoAsync(int id, EnderecoDTO endDto);
        Task DeleteEnderecoAsync(int id);
    }
}
