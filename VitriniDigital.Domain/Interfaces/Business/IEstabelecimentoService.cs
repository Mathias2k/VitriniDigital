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
        Task<Estabelecimento> GetEstabelecimentosByIdAsync(string id);
        Task<Estabelecimento> GetEstabelecimentosByIdUsuarioAsync(string id);
        Task<IEnumerable<Estabelecimento>> GetAllEstabelecimentosAsync();
        Task<bool> UpdateEstabelecimentoAsync(Estabelecimento estab);
        Task<bool> DesativarEstabelecimentoAsync(string id);
    }
}
