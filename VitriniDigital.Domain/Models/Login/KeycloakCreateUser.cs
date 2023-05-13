using System;
using System.Collections.Generic;
using System.Net;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models.Login
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<KeycloakCreateUser>(myJsonResponse);

    //add value predefinido nas props

    public class KeycloakCreateUser
    {
        //private Usuario _user;

        public KeycloakCreateUser()
        {
            Credentials = new();
            DisableableCredentialTypes = new();
            RequiredActions = new();
        }
        public long CreatedTimestamp { get; set; } = 1588880747548;
        public string Username { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Totp { get; set; } = false;
        public bool EmailVerified { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<object> DisableableCredentialTypes { get; set; }
        public List<object> RequiredActions { get; set; }
        public int NotBefore { get; set; } = 0;
        public List<Credential> Credentials { get; set; }
        public Access Access { get; set; }
        public List<string> RealmRoles { get; set; } = new List<string> { "default-roles-marraia" };
        public static class KeycloakCreateUserFactory
        {
            public static KeycloakCreateUser ConfigurarUsuario(Usuario user)
            {
                //int age = CalculaIdade(usuarioDto.DataNascimento);
                //ValidaIdade(age);

                Credential credential = new()
                {
                    Value = user.Password
                };
                List<Credential> credentials = new()
                {
                    credential
                };

                var usuarioKeycloak = new KeycloakCreateUser
                {
                    Username = user.UserName,
                    FirstName = user.Nome,
                    LastName = user.SobreNome,
                    Email = user.Email,
                    Credentials = credentials
                };

                return usuarioKeycloak;
            }
        }
    }
    public class Access
    {
        public bool ManageGroupMembership { get; set; } = true;
        public bool View { get; set; } = true;
        public bool MapRoles { get; set; } = true;
        public bool Impersonate { get; set; } = true;
        public bool Manage { get; set; } = true;
    }
    public class Credential
    {
        public string Type { get; set; } = "password";
        public string Value { get; set; }
        public bool Temporary { get; set; } = false;
    }
}