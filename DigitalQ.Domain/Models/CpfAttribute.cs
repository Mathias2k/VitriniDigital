using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DigitalQ.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ValidacaoCnpjInvalido = new ValidationResult("CPF Inválido.");
            CpfValidator cpf = Convert.ToString(value);
            return cpf.EhValido ? ValidationResult.Success : ValidacaoCnpjInvalido;
        }
    }
}
