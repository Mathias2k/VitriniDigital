namespace VitriniDigital.Domain.Config
{
    public class ApiConfiguration
    {
        public string ConnectionString { get; set; }
        public string UrlBuscadorCEP { get; set; }
        public string UrlGetAdminToken { get; set; }
        public string UrlCreateUserKeyCloak { get; set; }
        public string UrlGetUsers { get; set; }
        public string UrlGetUserByUserName { get; set; }
        public string GrantType { get; set; }
        public string Client_ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
