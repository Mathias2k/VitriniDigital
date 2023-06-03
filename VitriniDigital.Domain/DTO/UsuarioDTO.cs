using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Endereço de email é obrigatório")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
