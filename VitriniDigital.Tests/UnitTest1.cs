using Moq;
using System.ComponentModel;
using VitriniDigital.Domain.Config;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Service.Business;

namespace VitriniDigital.Tests
{
    //[Collection(nameof(FakeDadosFixtureCollection))]
    public class UnitTest1
    {
        //readonly FakeDadosFixture _usuarioTestBogus;
        //readonly ApiConfiguration _config;
        //public UnitTest1(FakeDadosFixture usuarioTestBogus)
        //{
        //    _usuarioTestBogus = usuarioTestBogus;
        //    _config = new ApiConfiguration();
        //}

        //[Fact(DisplayName = "Adicionar Usuario com Sucesso")]
        //[Category("Teste de Cadastro")]
        //public async Task CadastrarUsuario_RetornarSucesso()
        //{
        //    // Arrange
        //    var user = _usuarioTestBogus.GerarUsuarioValido();
        //    var userDto = new UsuarioDTO()
        //    {
        //        Email = user.UserName,
        //        Password = "123"
        //    };
        //    var userRepo = new Mock<IUsuarioRepository>();
        //    var estabService = new Mock<IEstabelecimentoService>();
        //    var httpClient = new Mock<IHttpClienteService>();
        //    //configurar setup e return para Http Post e Get

        //    _config.UrlGetUserByUserName = $"http://20.201.116.67/admin/realms/marraia/users/?username={userDto.Email}";
        //    _config.UrlCreateUserKeyCloak = "http://20.201.116.67/admin/realms/marraia/users";
        //    _config.UrlGetAdminToken = "http://20.201.116.67/realms/master/protocol/openid-connect/token";
        //    _config.GrantType = "password";
        //    _config.AdminClientID = "admin-cli";
        //    _config.UserName = "admin";
        //    _config.Password = "7OhuRC4qKg!+ljRfrs0";

        //    var userService = new UsuarioService(userRepo.Object, estabService.Object,
        //                                         httpClient.Object, _config);

        //    // Act
        //    await userService.AddUsuarioAsync(userDto);

        //    // Assert
        //    Assert.True(user.Ativo);
        //    userRepo.Verify(r => r.InsertAsync(user), Times.Once);
        //}

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

        //[Fact(Skip = "Alta carga, testar só quando necessário")]
        //[Category("Teste de Carga")]
        //public void CargaAlta_RetornarSucesso()
        //{

        //}
    }
}