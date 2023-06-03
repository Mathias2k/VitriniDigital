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
        public async Task<string> AddEnderecoAsync(EnderecoDTO endDto)
        {
            var endereco = Endereco.EnderecoFactory.AdicionarEstabelecimento(endDto);
            return await _enderecoRepo.InsertAsync(endereco);
        }
        public async Task<Endereco> GetEnderecoByIdAsync(string idEnd)
        {
            return await _enderecoRepo.SelectByIdAsync(idEnd);
        }
        public async Task UpdateEnderecoAsync(Endereco endereco)
        {
            await _enderecoRepo.UpdateAsync(endereco);
        }
        public async Task DeleteEnderecoAsync(string id)
        {
            await _enderecoRepo.DeleteAsync(id);
        }
    }
}