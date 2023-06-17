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
            string idPortfolio = await _portfolioService.AddPortfolioAsync(estabDto.PortfolioDto);

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
            if (estabelecimento == null || !estabelecimento.Ativo)
                return new Estabelecimento();

            return await GetRelacionamentosAsync(estabelecimento);
        }
        public async Task<Estabelecimento> GetEstabelecimentosByIdUsuarioAsync(string id)
        {
            var estabelecimento = await _estabelecimentoRepo.SelectByIdUsuarioAsync(id);
            if (estabelecimento == null || !estabelecimento.Ativo)
                return new Estabelecimento();

            return await GetRelacionamentosAsync(estabelecimento);
        }
        public async Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentosAsync()
        {
            var estabelecimentos = await _estabelecimentoRepo.SelectAllAsync();
            estabelecimentos = estabelecimentos.Where(x => x.Ativo);

            if (estabelecimentos.Any())
                foreach (var item in estabelecimentos) //pode ser um gargalo no futuro (usar paginacao) Skip(x).Take(n)
                {
                    item.Endereco = await _enderecoService.GetEnderecoByIdAsync(item.IdEndereco);
                    item.Portfolio = await _portfolioService.GetPortfolioByIdAsync(item.IdPortfolio);
                    item.Cupons = await _cupomService.GetCupomByIdEstabelecimentoAsync(item.Id);
                }

            return estabelecimentos;
        }
        public async Task<bool> UpdateEstabelecimentoAsync(Estabelecimento estab)
        {
            await _enderecoService.UpdateEnderecoAsync(estab.Endereco);
            await _portfolioService.UpdatePortfolioAsync(estab.Portfolio);

            return await _estabelecimentoRepo.UpdateAsync(estab);
        }
        public async Task<bool> DesativarEstabelecimentoAsync(string id)
        {
            var estabelecimento = await GetEstabelecimentosByIdAsync(id);
            if (estabelecimento == null || !estabelecimento.Ativo)
                return false;

            await _estabelecimentoRepo.DeleteAsync(id);
            return await DesativarRelacionamentosAsync(estabelecimento);
        }
        private async Task<Estabelecimento> GetRelacionamentosAsync(Estabelecimento estab)
        {
            estab.Endereco = await _enderecoService.GetEnderecoByIdAsync(estab.IdEndereco);
            estab.Portfolio = await _portfolioService.GetPortfolioByIdAsync(estab.IdPortfolio);
            estab.Cupons = await _cupomService.GetCupomByIdEstabelecimentoAsync(estab.Id);

            return estab;
        }
        private async Task<bool> DesativarRelacionamentosAsync(Estabelecimento estabelecimento)
        {
            var cupons = await _cupomService.GetCupomByIdEstabelecimentoAsync(estabelecimento.Id);
            if (cupons.Any())
                foreach (var cupom in cupons)
                    await _cupomService.DesativarCupomAsync(cupom.Id);

            return true;
        }
    }
}