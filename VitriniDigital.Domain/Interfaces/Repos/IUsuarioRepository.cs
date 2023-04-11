using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelectAllAsync();
        Task InsertAsync(Usuario user);
    }
}
