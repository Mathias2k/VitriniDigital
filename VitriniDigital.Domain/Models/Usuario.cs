using VitriniDigital.Domain.DTO;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

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

        //[Cpf]
        public string CPF { get; private set; }

        //[Phone]
        public string Telefone { get; private set; }
        public Estabelecimento Estabelecimento { get; private set; }
        //private static int CalculaIdade(DateTime dtNascimento)
        //{
        //    return DateTime.Now.AddYears(-dtNascimento.Year).Year;
        //}
        private static void ValidaIdade(int idade)
        {
            if (idade < 18)
                throw new Exception("Menor de idade.");
        }
        public static class UsuarioFactory
        {
            public static Usuario AdicionarUsuario(UsuarioDTO usuarioDto)
            {
                //int age = CalculaIdade(usuarioDto.DataNascimento);
                //ValidaIdade(age);

                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = usuarioDto.Nome,
                    Password = usuarioDto.Password,
                    Estabelecimento = usuarioDto.Estabelecimento
                    //DataNascimento = usuarioDto.DataNascimento,
                    //Idade = age
                };

                return usuario;
            }
        }
    }
}
