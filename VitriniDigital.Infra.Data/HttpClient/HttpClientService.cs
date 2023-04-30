using System.Net.Http;
using System.Threading.Tasks;

namespace VitriniDigital.Infra.Data.HttpClient
{  
    public class HttpClientService 
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<object> HttpClientPostAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("User-Agent", "YourApp");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return response;
        }
        public async Task<object> HttpClientGetAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("User-Agent", "YourApp");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            return response;
        }
    }
}