using Bogus;
using Bogus.DataSets;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Tests
{
    [CollectionDefinition(nameof(FakeDadosFixtureCollection))]
    public class FakeDadosFixtureCollection : ICollectionFixture<FakeDadosFixture>
    { }
    public class FakeDadosFixture : IDisposable
    {
        public Usuario GerarUsuarioValido()
        {
            return GerarUsuario(1, true).FirstOrDefault();
        }
        public IEnumerable<Usuario> ObterUsuariosVariados()
        {
            var user = new List<Usuario>();

            user.AddRange(GerarUsuario(50, true).ToList());
            user.AddRange(GerarUsuario(50, false).ToList());

            return user;
        }
        public IEnumerable<Usuario> GerarUsuario(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var users = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario() { 
                    Id = Guid.NewGuid().ToString(),
                    Nome = f.Name.FirstName(genero),
                    Ativo = ativo,
                }).RuleFor(c => c.UserName, (f, c) =>
                    f.Internet.Email(c.Nome.ToLower(), "123teste"));

            return users.Generate(quantidade);
        }
        public void Dispose()
        {
        }
    }
}
