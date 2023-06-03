using System;
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

namespace VitriniDigital.Service.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEstabelecimentoRepository _estabRepo;
        private readonly IHttpClienteService _httpClientService;
        private readonly ApiConfiguration _config;
        public UsuarioService(IUsuarioRepository usuarioRepo,
                              IEstabelecimentoRepository estabRepo,
                              IHttpClienteService httpClientService,
                              ApiConfiguration config)
        {
            _usuarioRepo = usuarioRepo;
            _estabRepo = estabRepo;
            _httpClientService = httpClientService;
            _config = config;
        }
        public async Task<bool> AddUsuarioAsync(UsuarioDTO userDto)
        {
            var userKeycloak = KeycloakCreateUser.KeycloakCreateUserFactory.ConfigurarUsuario(userDto);

            await _httpClientService.HttpClientPostAsync(_config.UrlCreateUserKeyCloak,
                                                         userKeycloak,
                                                         await _httpClientService.GetAdminTokenAsync());

            string url = $"{_config.UrlGetUserByUserName}{userDto.Email}";
            var response = await _httpClientService.HttpClientGetAsync(url, await _httpClientService.GetAdminTokenAsync());

            var userKC = JsonSerializer.Deserialize<List<KeyCloackGetUser>>(response.Content.ReadAsStream());

            if (userKC?.Count == 0)
                return false;

            var usuario = Usuario.UsuarioFactory.AdicionarUsuario(userKC.FirstOrDefault());

            return await _usuarioRepo.InsertAsync(usuario);
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepo.SelectAllAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(string id)
        {
            var user = await _usuarioRepo.SelectByIdAsync(id.ToString());
            if (user == null)
                return null;
            if (!user.Ativo)
                return null;

            var estabelecimento = await _estabRepo.SelectByIdAsync(1);
            user.Estabelecimento = estabelecimento;

            return user;
        }
        public async Task<bool> DesativarUsuarioAsync(string id)
        {
            return await _usuarioRepo.DisableUserAsync(id);
        }
    }
}
