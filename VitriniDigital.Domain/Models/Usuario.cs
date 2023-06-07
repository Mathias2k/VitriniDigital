﻿using VitriniDigital.Domain.Models.Login;

namespace VitriniDigital.Domain.Models
{
    public class Usuario 
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public string UserName { get; set; }
        public bool Ativo { get; private set; }
        public Estabelecimento Estabelecimento { get; set; }
        public static class UsuarioFactory
        {
            public static Usuario AdicionarUsuario(KeyCloackGetUser userKC)
            {
                var usuario = new Usuario
                {
                    Id = userKC.id,
                    UserName = userKC.email
                };

                return usuario;
            }
        }
    }
}
