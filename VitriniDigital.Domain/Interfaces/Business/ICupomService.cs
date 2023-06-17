using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface ICupomService
    {
        Task<ResponseResult> AddCupomAsync(CupomDTO userDto);
        Task<IEnumerable<Cupom>> GetAllCupomsAsync();
        Task<Cupom> GetCupomByIdAsync(string id);
        Task<IEnumerable<Cupom>> GetCupomByIdEstabelecimentoAsync(string idEstab);
        Task<bool> UpdateCupomAsync(Cupom cupom);
        Task<bool> DesativarCupomAsync(string id);
    }
}
