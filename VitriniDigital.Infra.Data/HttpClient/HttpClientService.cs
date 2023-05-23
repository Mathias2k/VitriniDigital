using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.Interfaces.Business;
using System.Text.Json.Serialization;
using System.Text.Json;
using VitriniDigital.Domain.Models.Login;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace VitriniDigital.Infra.Data.HttpClient
{
    public class HttpClientService : IHttpClienteService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ApiConfiguration _config;
        public HttpClientService(IHttpClientFactory clientFactory,
                                ApiConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<object> HttpClientPostAsync(string url, object obj, string token = null)
        {
            if (obj is null)
                throw new Exception("HttpClientPostAsync - Objeto não pode ser nulo.");

            var json = JsonSerializer.Serialize(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

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
        public async Task<string> GetAdminTokenAsync()
        {
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", _config.GrantType),
                new KeyValuePair<string, string>("client_id", _config.Client_ID),
                new KeyValuePair<string, string>("username", _config.UserName),
                new KeyValuePair<string, string>("password", _config.Password)
            };
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _config.UrlGetAdminToken) { Content = new FormUrlEncodedContent(nvc) };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var keyCloackAdminToken = JsonSerializer.Deserialize<KeyCloakAdminToken>(json);

            return keyCloackAdminToken.access_token;
        }
    }
}