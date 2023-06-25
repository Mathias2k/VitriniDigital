using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Models.Login;

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
        public async Task<HttpResponseMessage> HttpClientGetAsync(string url, string token = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return response;
        }
        public async Task HttpClientPutAsync(string url, object obj, string token = null)
        {
            if (obj is null)
                throw new Exception("HttpClientPostAsync - Objeto não pode ser nulo.");

            var json = JsonSerializer.Serialize(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
        public async Task<string> GetAdminTokenAsync()
        {
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", _config.GrantType),
                new KeyValuePair<string, string>("client_id", _config.AdminClientID),
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
        public async Task<string> GetNormalTokenAsync(UsuarioDTO user)
        {
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", _config.GrantType),
                new KeyValuePair<string, string>("client_id", _config.NormalUserClientID),
                new KeyValuePair<string, string>("username", user.Email),
                new KeyValuePair<string, string>("password", user.Password),
                new KeyValuePair<string, string>("client_secret", "JXCgUy5wvOet9jN6QG6XIbHJrQUaHTVd")
            };
            var client = _clientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, _config.UrlGetNormalToken) { Content = new FormUrlEncodedContent(nvc) };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //var json = 
            return await response.Content.ReadAsStringAsync();
            // var keyCloackAdminToken = JsonSerializer.Deserialize<KeyCloakAdminToken>(json);

            //return keyCloackAdminToken.access_token;
        }
    }
}