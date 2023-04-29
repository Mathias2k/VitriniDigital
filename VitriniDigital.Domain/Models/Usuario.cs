using VitriniDigital.Domain.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace VitriniDigital.Domain.Models
{
    public class Usuario : Endereco
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { get; private set; }

        [EmailAddress]
        public string Email { get; private set; }

        [Cpf]
        public string CPF { get; private set; }

        [Phone]
        public string Telefone { get; private set; }

        private static int CalculaIdade(DateTime dtNascimento)
        {
            return DateTime.Now.AddYears(-dtNascimento.Year).Year;
        }
        private static void ValidaIdade(int idade)
        {
            if (idade < 18)
                throw new Exception("Menor de idade.");
        }
        public static class UsuarioFactory
        {
            public static Usuario AdicionarUsuario(UsuarioDTO usuarioDto)
            {
                int age = CalculaIdade(usuarioDto.DataNascimento);
                ValidaIdade(age);

                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = usuarioDto.Nome,
                    DataNascimento = usuarioDto.DataNascimento,
                    Idade = age
                };

                return usuario;
            }
        }
    }
}
