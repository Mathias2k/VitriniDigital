using System.Collections.Generic;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models.Login
{
    public class KeycloakCreateUser
    {
        public KeycloakCreateUser()
        {
            disableableCredentialTypes = new();
            requiredActions = new();
        }
        public long createdTimestamp { get; set; } = 1588880747548;
        public string username { get; set; }
        public bool enabled { get; set; } = true;
        public bool totp { get; set; } = false;
        public bool emailVerified { get; set; } = true;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public List<object> disableableCredentialTypes { get; set; }
        public List<object> requiredActions { get; set; }
        public int notBefore { get; set; } = 0;
        public List<credential> credentials { get; set; }
        public access access { get; set; }
        public List<string> realmRoles { get; set; } = new List<string> { "default-roles-marraia" };
        public static class KeycloakCreateUserFactory
        {
            public static KeycloakCreateUser ConfigurarUsuario(UsuarioDTO user)
            {
                credential credential = new()
                {
                    value = user.Password
                };
                List<credential> credentials = new()
                {
                    credential
                };

                access access = new();

                var usuarioKeycloak = new KeycloakCreateUser
                {
                    username = user.Email,
                    firstName = "",
                    lastName = "",
                    email = user.Email,
                    credentials = credentials,
                    access = access
                };

                return usuarioKeycloak;
            }
        }
    }
    public class access
    {
        public bool manageGroupMembership { get; set; } = true;
        public bool view { get; set; } = true;
        public bool mapRoles { get; set; } = true;
        public bool impersonate { get; set; } = true;
        public bool manage { get; set; } = true;
    }
    public class credential
    {
        [JsonPropertyName("type")]
        public string type { get; set; } = "password";
        public string value { get; set; }
        public bool temporary { get; set; } = false;
    }
}