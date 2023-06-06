using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IUsuarioService
    {
        Task<ResponseResult> AddUsuarioAsync(UsuarioDTO userDto);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(string id);
        Task<Usuario> GetUsuarioByUserNameAsync(string userName);
        Task<bool> DesativarUsuarioAsync(string id);
        Task<bool> ResetarSenhaAsync(string userName);
    }
}
