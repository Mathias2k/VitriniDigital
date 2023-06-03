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
        Task<bool> DesativarUsuarioAsync(string id);
    }
}
