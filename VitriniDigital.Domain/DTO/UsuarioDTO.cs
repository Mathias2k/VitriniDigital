using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
