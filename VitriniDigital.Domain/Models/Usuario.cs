using System;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Usuario 
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }
        public static class UsuarioFactory
        {
            public static Usuario AdicionarUsuario(UsuarioDTO usuarioDto)
            {
                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Email = usuarioDto.Email,
                    UserName = usuarioDto.Email,
                    Password = usuarioDto.Password
                };

                return usuario;
            }
        }
    }
}
