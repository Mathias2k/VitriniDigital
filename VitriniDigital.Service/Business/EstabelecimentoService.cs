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
        private readonly IPortfolioService _portfolioService;
        private readonly IEnderecoService _enderecoService;
        private readonly ICupomService _cupomService;
        public EstabelecimentoService(IEstabelecimentoRepository estabelecimentoRepo,
                                      IPortfolioService portfolioService,
                                      IEnderecoService enderecoService,
                                      ICupomService cupomService)
        {
            _estabelecimentoRepo = estabelecimentoRepo;
            _portfolioService = portfolioService;
            _enderecoService = enderecoService;
            _cupomService = cupomService;
        }
        public async Task<ResponseResult> AddEstabelecimentoAsync(EstabelecimentoDTO estabDto)
        {
            string idEndereco = await _enderecoService.AddEnderecoAsync(estabDto.EnderecoDto);
            string idPortfolio = "";
            //string idPortfolio = await _portfolioService.AddPortfolioAsync(estabDto.PortfolioDto);

            var estabelecimento = Estabelecimento.EstabelecimentoFactory.AdicionarEstabelecimento(estabDto, 
                                                                                        idEndereco, idPortfolio);

            ResponseResult rr = new()
            {
                Id = await _estabelecimentoRepo.InsertAsync(estabelecimento),
                Message = "Estabelecimento criado com sucesso."
            };

            return rr;
        }
        public async Task<Estabelecimento> GetEstabelecimentosByIdAsync(string id)
        {
            var estabelecimento = await _estabelecimentoRepo.SelectByIdAsync(id);
            if (estabelecimento == null)
                return new Estabelecimento();

            return await GetRelacionamentosAsync(estabelecimento);
        }
        public async Task<Estabelecimento> GetEstabelecimentosByIdUsuarioAsync(string id)
        {
            var estabelecimento = await _estabelecimentoRepo.SelectByIdUsuarioAsync(id);
            if (estabelecimento == null)
                return new Estabelecimento();

            return await GetRelacionamentosAsync(estabelecimento);
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
        public async Task<bool> UpdateEstabelecimentoAsync(Estabelecimento estab)
        {
            await _enderecoService.UpdateEnderecoAsync(estab.Endereco);

            return await _estabelecimentoRepo.UpdateAsync(estab);
        }
        public async Task<bool> DeleteEstabelecimentoAsync(string id)
        {
            var estabelecimento = await GetEstabelecimentosByIdAsync(id);
            if (estabelecimento == null)
                return false;

            await _estabelecimentoRepo.DeleteAsync(id);
            return await DeleteRelacionamentosAsync(estabelecimento);
        }
        private async Task<Estabelecimento> GetRelacionamentosAsync(Estabelecimento estab)
        {
            estab.Endereco = await _enderecoService.GetEnderecoByIdAsync(estab.IdEndereco);
            //estabelecimento.Portfolio = await _portfolioService.GetPortfolioByIdAsync();
            //estabelecimento.Cupons = await _cupomService;

            return estab;
        }
        private async Task<bool> DeleteRelacionamentosAsync(Estabelecimento estabelecimento)
        {
            await _enderecoService.DeleteEnderecoAsync(estabelecimento.IdEndereco);
            //await _portfolioService.DeletePortfolioAsync();
            //await _cupomService.DeleteCupomAsync();

            return true;
        }
    }
}