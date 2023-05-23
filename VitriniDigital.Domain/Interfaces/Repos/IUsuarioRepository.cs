using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelectAllAsync();
        Task<bool> InsertAsync(Usuario user);
    }
}
