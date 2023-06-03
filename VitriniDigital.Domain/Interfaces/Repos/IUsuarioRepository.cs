using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelectAllAsync();
        Task<Usuario> SelectByIdAsync(string id);
        Task<bool> InsertAsync(Usuario user);
        Task<bool> DisableUserAsync(string id);
    }
}
