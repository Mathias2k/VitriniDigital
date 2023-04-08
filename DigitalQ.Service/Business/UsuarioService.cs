using DigitalQ.Domain.DTO;
using DigitalQ.Domain.Interfaces.Business;
using DigitalQ.Domain.Interfaces.Repos;
using DigitalQ.Domain.Models;

namespace DigitalQ.Service.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        public async Task<bool> AddUsuarioAsync(UsuarioDTO userDto)
        {
            var reserva = Usuario.UsuarioFactory.AdicionarUsuario(userDto);
            await _usuarioRepo.InsertAsync(reserva);

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
