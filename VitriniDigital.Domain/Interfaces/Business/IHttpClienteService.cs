using System.Threading.Tasks;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IHttpClienteService
    {
        Task<object> HttpClientPostAsync(string url, object obj);
        Task<object> HttpClientGetAsync(string url);
    }
}
