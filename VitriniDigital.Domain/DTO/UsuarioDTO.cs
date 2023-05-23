using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
