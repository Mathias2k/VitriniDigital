using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Domain.Models.Login;
using VitriniDigital.Domain.Models.Response;

namespace VitriniDigital.Service.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEstabelecimentoService _estabService;
        private readonly IHttpClienteService _httpClientService;
        private readonly ApiConfiguration _config;
        public UsuarioService(IUsuarioRepository usuarioRepo,
                              IEstabelecimentoService estabService,
                              IHttpClienteService httpClientService,
                              ApiConfiguration config)
        {
            _usuarioRepo = usuarioRepo;
            _estabService = estabService;
            _httpClientService = httpClientService;
            _config = config;
        }
        public async Task<ResponseResult> AddUsuarioAsync(UsuarioDTO userDto)
        {
            var userKeycloak = KeycloakCreateUser.KeycloakCreateUserFactory.ConfigurarUsuario(userDto);

            await _httpClientService.HttpClientPostAsync(_config.UrlCreateUserKeyCloak,
                                                         userKeycloak,
                                                         await _httpClientService.GetAdminTokenAsync());

            string url = $"{_config.UrlGetUserByUserName}{userDto.Email}";
            var userKC = await _httpClientService.HttpClientGetKCUserAsync(url, await _httpClientService.GetAdminTokenAsync());

            //var userKC = JsonSerializer.Deserialize<List<KeyCloackGetUser>>(response.Content.ReadAsStream());

            //if (userKC?.Count == 0)
            //    return new ResponseResult();

            var usuario = Usuario.UsuarioFactory.AdicionarUsuario(userKC);
            await _usuarioRepo.InsertAsync(usuario);

            ResponseResult rr = new()
            {
                Id = usuario.Id,
                Message = "Usuário criado com sucesso."
            };

            return rr;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepo.SelectAllAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            var user = await _usuarioRepo.SelectByIdAsync(id);
            if (user == null)
                return null;
            if (!user.Ativo)
                return null;

            var estabelecimento = await _estabService.GetEstabelecimentosByIdUsuarioAsync(id);
            user.Estabelecimento = estabelecimento;

            return user;
        }
        public async Task<Usuario> GetUsuarioByUserNameAsync(string userName)
        {
            var user = await _usuarioRepo.SelectByUserNameAsync(userName);
            if (user == null)
                return null;
            if (!user.Ativo)
                return null;

            var estabelecimento = await _estabService.GetEstabelecimentosByIdUsuarioAsync(user.Id);
            user.Estabelecimento = estabelecimento;

            return user;
        }
        public async Task<bool> DesativarUsuarioAsync(string id)
        {
            return await _usuarioRepo.DisableUserAsync(id);
        }
        public async Task<bool> ResetarSenhaAsync(string email)
        {
            string urlGetUser = $"{_config.UrlGetUserByUserName}{email}";
            var response = await _httpClientService.HttpClientGetAsync(urlGetUser, await _httpClientService.GetAdminTokenAsync());
            var userKC = JsonSerializer.Deserialize<List<KeyCloackGetUser>>(response.Content.ReadAsStream());

            if (userKC?.Count == 0)
                return false;

            string[] UPDATE_PASSWORD = new string[] { "UPDATE_PASSWORD" };
            string urlReserPassword = $"{_config.UrlResetPassword.Replace("ID_REPLACE", userKC.FirstOrDefault().id)}";
            await _httpClientService.HttpClientPutAsync(urlReserPassword, UPDATE_PASSWORD, await _httpClientService.GetAdminTokenAsync());

            return true;
        }
    }
}