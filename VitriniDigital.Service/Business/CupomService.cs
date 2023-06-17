using System;
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
    public class CupomService : ICupomService
    {
        private readonly ICupomRepository _cupomRepo;
        public CupomService(ICupomRepository cupomRepo)
        {
            _cupomRepo = cupomRepo;
        }
        public async Task<ResponseResult> AddCupomAsync(CupomDTO CupomDto)
        {
            var cupom = Cupom.CupomFactory.AdicionarCupom(CupomDto);
            await _cupomRepo.InsertAsync(cupom);

            ResponseResult rr = new()
            {
                Id = cupom.Id,
                Message = "Cupom criado com sucesso."
            };

            return rr;
        }
        public async Task<IEnumerable<Cupom>> GetAllCupomsAsync()
        {
            return await _cupomRepo.SelectAllAsync();
        }
        public async Task<IEnumerable<Cupom>> GetCupomByIdEstabelecimentoAsync(string idEstab)
        {
            var cupons = await _cupomRepo.SelectByIdEstabelecimentoAsync(idEstab);

            cupons = cupons.Where(x => x.DataValidade.Date >= DateTime.Now.Date && x.Ativo);
            return cupons;
        }
        public async Task<Cupom> GetCupomByIdAsync(string id)
        {
            var cupom = await _cupomRepo.SelectByIdAsync(id);

            return cupom.DataValidade.Date >= DateTime.Now.Date && 
                   cupom.Ativo ? cupom : null;
        }
        public async Task<bool> UpdateCupomAsync(Cupom cupom)
        {
            return await _cupomRepo.UpdateCupomAsync(cupom);
        }
        public async Task<bool> DesativarCupomAsync(string id)
        {
            return await _cupomRepo.DeleteAsync(id);
        }
    }
}
