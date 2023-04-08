using DigitalQ.Domain.Models;

namespace DigitalQ.Domain.Interfaces.Repos
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelectAllAsync();
        Task InsertAsync(Usuario user);
    }
}
