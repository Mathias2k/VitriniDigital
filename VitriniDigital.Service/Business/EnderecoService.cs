using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepo;
        public EnderecoService(IEnderecoRepository enderecoRepo)
        {
            _enderecoRepo = enderecoRepo;
        }
        public async Task<int> AddEnderecoAsync(EnderecoDTO endDto)
        {
            return await _enderecoRepo.InsertAsync(endDto);
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int idEnd)
        {
            return await _enderecoRepo.SelectByIdAsync(idEnd);
        }
        public async Task UpdateEnderecoAsync(int id, EnderecoDTO endDto)
        {
             await _enderecoRepo.UpdateAsync(id, endDto);
        }
        public async Task DeleteEnderecoAsync(int id)
        {
            await _enderecoRepo.DeleteAsync(id);
        }
    }
}