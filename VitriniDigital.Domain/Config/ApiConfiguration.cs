namespace VitriniDigital.Domain.Config
{
    public class ApiConfiguration
    {
        public string ConnectionString { get; set; }
        public string UrlGetLocalizacao { get; set; }
        public string UrlGetCEP { get; set; }
        public string UrlGetNormalToken { get; set; }
        public string UrlGetAdminToken { get; set; }
        public string UrlCreateUserKeyCloak { get; set; }
        public string UrlGetUsers { get; set; }
        public string UrlGetUserByUserName { get; set; }
        public string UrlResetPassword { get; set; }
        public string GrantType { get; set; }
        public string AdminClientID { get; set; }
        public string NormalUserClientID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
