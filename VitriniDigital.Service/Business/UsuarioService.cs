using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public UsuarioService(IUsuarioRepository usuarioRepo,
                              IHttpClienteService httpClientService)
        {
            _usuarioRepo = usuarioRepo;
            _httpClientService = httpClientService;
        }
        public async Task<bool> AddUsuarioAsync(UsuarioDTO userDto)
        {
            var usuario = Usuario.UsuarioFactory.AdicionarUsuario(userDto);
            var userKeycloak = KeycloakCreateUser.KeycloakCreateUserFactory.ConfigurarUsuario(usuario);

            //add no keycloak via post
            await _httpClientService.HttpClientPostAsync("", userKeycloak);

            await _usuarioRepo.InsertAsync(usuario);

            return true;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepo.SelectAllAsync();
        }

        public async Task<Usuario> GetUsuarioByIdAsync(Guid id)
        {
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
