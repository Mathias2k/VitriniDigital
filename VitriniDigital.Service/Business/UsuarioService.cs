using System;
using System.Collections.Generic;
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
        private readonly IHttpClienteService _httpClientService;
        private readonly ApiConfiguration _config;
        public UsuarioService(IUsuarioRepository usuarioRepo,
                              IHttpClienteService httpClientService,
                              ApiConfiguration config)
        {
            _usuarioRepo = usuarioRepo;
            _httpClientService = httpClientService;
            _config = config;
        }
        public async Task<bool> AddUsuarioAsync(UsuarioDTO userDto)
        {
            var usuario = Usuario.UsuarioFactory.AdicionarUsuario(userDto);
            var userKeycloak = KeycloakCreateUser.KeycloakCreateUserFactory.ConfigurarUsuario(usuario);

            await _httpClientService.HttpClientPostAsync(_config.UrlCreateUserKeyCloak,
                                                         userKeycloak,
                                                         await _httpClientService.GetAdminTokenAsync());
            return await _usuarioRepo.InsertAsync(usuario);
        }

        //talvez nao precise desse endpoint
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepo.SelectAllAsync();
        }

        //talvez nao precise desse endpoint
        public async Task<Usuario> GetUsuarioByIdAsync(Guid id)
        {
            //busco user no DB
            //busco users no KC: http://20.201.116.67//admin/realms/marraia/users

            //busco na lista de user do KC o usuario que corresponde ao user que tenho no DB
            return new Usuario();
        }

        public async Task UpdateUsuarioAsync(UsuarioDTO userDto)
        {

        }
        public async Task ReportarProblemaAsync()
        {

        }
    }
}
