using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class CupomService : ICupomService
    {
        private readonly ICupomRepository _CupomRepo;
        public CupomService(ICupomRepository CupomRepo)
        {
            _CupomRepo = CupomRepo;
        }
        public async Task<bool> AddCupomAsync(CupomDTO CupomDto)
        {
            var Cupom = Cupom.CupomFactory.AdicionarCupom(CupomDto.IdEstabelecimento);
            await _CupomRepo.InsertAsync(Cupom);

            return true;
        }
        public async Task<IEnumerable<Cupom>> GetAllCupomsAsync()
        {
            return await _CupomRepo.SelectAllAsync();
        }

        public async Task<Cupom> GetCupomByIdAsync(Guid id)
        {
            return new Cupom();
        }

        public async Task UpdateCupomAsync(CupomDTO userDto)
        {

        }
        public async Task ReportarProblemaAsync()
        {

        }
    }
}
