using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IEnderecoService
    {
        Task<string> AddEnderecoAsync(EnderecoDTO endDto);
        Task<Endereco> GetEnderecoByIdAsync(string idEnd);
        Task UpdateEnderecoAsync(Endereco endereco);
        //Task DeleteEnderecoAsync(string id);
    }
}
