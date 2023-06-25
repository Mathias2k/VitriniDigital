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
        //public UnitTest1(FakeDadosFixture usuarioTestBogus)
        //{
        //    _usuarioTestBogus = usuarioTestBogus;
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
        //    var apiConfig = new Mock<ApiConfiguration>();

        //    var userService = new UsuarioService(userRepo.Object, estabService.Object, 
        //                                         httpClient.Object, apiConfig.Object);

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