using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IUsuarioService
    {
        Task<bool> AddUsuarioAsync(UsuarioDTO userDto);
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(string id);
        Task<bool> DesativarUsuarioAsync(string id);
    }
}
