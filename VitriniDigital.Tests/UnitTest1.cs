using Moq;
using System.ComponentModel;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models.Login;
using VitriniDigital.Infra.Data.Db;
using VitriniDigital.Service.Business;

namespace VitriniDigital.Tests
{
    [Collection(nameof(FakeDadosFixtureCollection))]
    public class UnitTest1
    {
        readonly FakeDadosFixture _usuarioTestBogus;
        readonly ApiConfiguration _config;
        public UnitTest1(FakeDadosFixture usuarioTestBogus)
        {
            _usuarioTestBogus = usuarioTestBogus;
            _config = new ApiConfiguration();
        }

        [Fact(DisplayName = "Adicionar Usuario com Sucesso")]
        [Category("Teste de Cadastro")]
        public async Task CadastrarUsuario_RetornarSucesso()
        {
            #region Arrange
            var user = _usuarioTestBogus.GerarUsuarioValido();
            var userDto = new UsuarioDTO()
            {
                Email = user.UserName,
                Password = "123"
            };
            var userRepo = new Mock<IUsuarioRepository>();
            var estabService = new Mock<IEstabelecimentoService>();
            var httpClient = new Mock<IHttpClienteService>();

            _config.UrlGetUserByUserName = $"http://20.201.116.67/admin/realms/marraia/users/?username={userDto.Email}";
            _config.UrlCreateUserKeyCloak = "http://20.201.116.67/admin/realms/marraia/users";
            _config.UrlGetAdminToken = "http://20.201.116.67/realms/master/protocol/openid-connect/token";
            _config.GrantType = "password";
            _config.AdminClientID = "admin-cli";
            _config.UserName = "admin";
            _config.Password = "7OhuRC4qKg!+ljRfrs0";

            httpClient.Setup(c => c.HttpClientGetKCUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                      .Returns(FakeKeyClockUser(user.UserName));

            userRepo.Setup(c => c.InsertAsync(user)).Returns(It.IsAny<Task<bool>>());

            var userService = new UsuarioService(userRepo.Object, estabService.Object,
                                                 httpClient.Object, _config);
            #endregion

            // Act
            await userService.AddUsuarioAsync(userDto);

            // Assert
            Assert.True(user.Ativo);
            //userRepo.Verify(r => r.InsertAsync(user), Times.Never);
        }

        [Fact(DisplayName = "Adicionar Usuario com Sucesso - Carga Alta")] 
        //(Skip = "Alta carga, testar só quando necessário")
        [Category("Teste de Carga")]
        public async Task CargaAlta_RetornarSucesso()
        {
            #region Arrange
            var user = _usuarioTestBogus.ObterUsuariosVariados(qtdeCriar: 5000).ToList();

            for (int i = 0; i < user.Count(); i++)
            {
                var userDto = new UsuarioDTO()
                {
                    Email = user[i].UserName,
                    Password = "123"
                };
                var userRepo = new Mock<IUsuarioRepository>();
                var estabService = new Mock<IEstabelecimentoService>();
                var httpClient = new Mock<IHttpClienteService>();

                _config.UrlGetUserByUserName = $"http://20.201.116.67/admin/realms/marraia/users/?username={userDto.Email}";
                _config.UrlCreateUserKeyCloak = "http://20.201.116.67/admin/realms/marraia/users";
                _config.UrlGetAdminToken = "http://20.201.116.67/realms/master/protocol/openid-connect/token";
                _config.GrantType = "password";
                _config.AdminClientID = "admin-cli";
                _config.UserName = "admin";
                _config.Password = "7OhuRC4qKg!+ljRfrs0";

                httpClient.Setup(c => c.HttpClientGetKCUserAsync(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(FakeKeyClockUser(user[i].UserName));

                userRepo.Setup(c => c.InsertAsync(user[i])).Returns(It.IsAny<Task<bool>>());

                var userService = new UsuarioService(userRepo.Object, estabService.Object,
                                                     httpClient.Object, _config);
                #endregion

                // Act
                await userService.AddUsuarioAsync(userDto);

                // Assert
                Assert.True(user[i].Ativo);
            }
        }
        private async Task<KeyCloackGetUser> FakeKeyClockUser(string userNameEmail)
        {
            await Task.Yield();

            return new KeyCloackGetUser()
            {
                id = "d24b99d9-e047-496a-aef7-9a2a1715bf1f",
                createdTimestamp = 1688849612877,
                username = userNameEmail,
                enabled = true,
                email = userNameEmail,
                access = new()
            };
        }

        //[Fact]
        //[Category("Teste de Cadastro")]
        //public void CadastrarEstabelecimento_RetornarSucesso()
        //{

        //}

        //[Fact]
        //[Category("Teste de Cadastro")]
        //public void CadastrarCupom_RetornarSucesso()
        //{

        //}
    }
}