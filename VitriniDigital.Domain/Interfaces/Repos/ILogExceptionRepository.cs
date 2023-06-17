using System.Threading.Tasks;
using VitriniDigital.Domain.Models.Exception;

namespace VitriniDigital.Domain.Interfaces.Repos
{
    public interface ILogExceptionRepository
    {
        Task AddErrorAsync(LogException log);
    }
}
