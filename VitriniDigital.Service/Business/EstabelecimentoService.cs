using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Service.Business
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepo;
        private readonly IEnderecoService _enderecoService;
        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepo,
                                      IEnderecoService enderecoService)
        {
            _estabelecimentoRepo = estabelecimentoRepo;
            _enderecoService = enderecoService;
        }
        public async Task<ResponseResult> AddEstabelecimentoAsync(EstabelecimentoDTO estabDto)
        {
            int idEnd = await _enderecoService.AddEnderecoAsync(estabDto.EnderecoDto);

            var estabelecimento = Estabelecimento.EstabelecimentoFactory.AdicionarEstabelecimento(estabDto, idEnd);

            ResponseResult response = new()
            {
                Id = await _estabelecimentoRepo.InsertAsync(estabelecimento),
                Message = "Estabelecimento criado com sucesso."
            };

            return response;
        }
        public async Task<Estabelecimento> GetEstabelecimentosByIdAsync(int id)
        {
            var estabelecimento = await _estabelecimentoRepo.SelectByIdAsync(id);
            estabelecimento.Endereco = await _enderecoService.GetEnderecoByIdAsync(estabelecimento.IdEndereco);

            return estabelecimento;
        }
        public async Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentosAsync()
        {
            var estabelecimentos = await _estabelecimentoRepo.SelectAllAsync();

            if (estabelecimentos.Any())
                foreach (var item in estabelecimentos) //pode ser um gargalo no futuro (usar paginacao) Skip(x).Take(n)
                {
                    item.Endereco = await _enderecoService.GetEnderecoByIdAsync(item.IdEndereco);
                    //item.Cupom = await ...
                }

            return estabelecimentos;
        }
        public async Task<ResponseResult> UpdateEstabelecimentoAsync(int id, EstabelecimentoDTO estabDto)
        {
            var estabelecimento = await GetEstabelecimentosByIdAsync(id);
            var retorno = await _estabelecimentoRepo.UpdateAsync(id, estabDto);

            await _enderecoService.UpdateEnderecoAsync(estabelecimento.IdEndereco, estabDto.EnderecoDto);

            ResponseResult response = new()
            {
                Id = id,
                Message = retorno == 1 ? "Estabelecimento atualizado com sucesso." : "Nenhum registro foi atualizado."
            };

            return response;
        }
        public async Task<ResponseResult> DeleteEstabelecimentoAsync(int id)
        {
            var estabelecimento = await GetEstabelecimentosByIdAsync(id);
            var retorno = await _estabelecimentoRepo.DeleteAsync(id);

            await _enderecoService.DeleteEnderecoAsync(estabelecimento.IdEndereco);

            ResponseResult response = new()
            {
                Id = id,
                Message = retorno == 1 ? "Estabelecimento apagado com sucesso." : "Nenhum registro foi apagado."
            };

            return response;
        }
    }
}