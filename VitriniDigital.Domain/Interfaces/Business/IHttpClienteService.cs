using System.Threading.Tasks;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IHttpClienteService
    {
        Task<object> HttpClientPostAsync(string url, object obj, string token = null);
        Task<object> HttpClientGetAsync(string url);
        Task<string> GetAdminTokenAsync();
    }
}
