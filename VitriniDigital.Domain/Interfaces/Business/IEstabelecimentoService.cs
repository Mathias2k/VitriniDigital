using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IEstabelecimentoService
    {
        Task<ResponseResult> AddEstabelecimentoAsync(EstabelecimentoDTO estabDto);
        Task<Estabelecimento> GetEstabelecimentosByIdAsync(int id);
        Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentosAsync();
        Task<ResponseResult> UpdateEstabelecimentoAsync(int id, EstabelecimentoDTO estabDto);
        Task<ResponseResult> DeleteEstabelecimentoAsync(int id);
    }
}
