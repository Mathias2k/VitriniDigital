using DigitalQ.Domain.DTO;
using DigitalQ.Domain.Models;

namespace DigitalQ.Domain.Interfaces.Business
{
    public interface IUsuarioService
    {
        Task<bool> AddUsuarioAsync(UsuarioDTO userDto);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(Guid id);
        Task UpdateUsuarioAsync(UsuarioDTO usuarioDto);
    }
}
