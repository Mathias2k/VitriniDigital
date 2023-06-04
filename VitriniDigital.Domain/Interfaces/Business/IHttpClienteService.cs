using System.Net.Http;
using System.Threading.Tasks;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IHttpClienteService
    {
        Task<object> HttpClientPostAsync(string url, object obj, string token = null);
        Task<HttpResponseMessage> HttpClientGetAsync(string url, string token = null);
        Task HttpClientPutAsync(string url, object obj, string token = null);
        Task<string> GetAdminTokenAsync();
    }
}
