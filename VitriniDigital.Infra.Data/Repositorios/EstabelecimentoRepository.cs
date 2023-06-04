using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private DbSession _session;
        public EstabelecimentoRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<Estabelecimento> SelectByIdAsync(string idEstab)
        {
            var param = new
            {
                ID = idEstab
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Estabelecimento>(@"SELECT * FROM tbl_Estabelecimento
                                                                                         where Id = @ID",
                                                                                         param, _session.Transaction);
        }
        public async Task<Estabelecimento> SelectByIdUsuarioAsync(string idUsuario)
        {
            var param = new
            {
                IdUsuario = idUsuario
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Estabelecimento>(@"SELECT * FROM tbl_Estabelecimento
                                                                                         where IdUsuario = @IdUsuario",
                                                                                         param, _session.Transaction);
        }
        public async Task<IEnumerable<Estabelecimento>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Estabelecimento>(@"SELECT * FROM tbl_Estabelecimento",
                                                                         param: null, _session.Transaction);
        }
        public async Task<string> InsertAsync(Estabelecimento estab)
        {
            var param = new
            {
                ID = estab.Id,
                IdUsuario = estab.IdUsuario,
                IdTipoEstabelecimento = estab.IdTipoEstabelecimento,
                IdPortfolio = estab.IdPortfolio,
                IdEndereco = estab.IdEndereco,
                Nome = estab.Nome,
                Telefone1 = estab.Telefone1,
                Telefone2 = estab.Telefone2
            };

            return await _session.Connection.QuerySingleAsync<string>(@"INSERT INTO tbl_Estabelecimento
                                                                            (Id, IdTipoEstabelecimento, IdPortfolio, IdEndereco,
                                                                             IdUsuario, Nome, Telefone1, Telefone2)
                                                                            OUTPUT INSERTED.ID
                                                                            VALUES(@ID, @IdTipoEstabelecimento, @IdPortfolio, @IdEndereco,
                                                                                   @IdUsuario, @Nome, @Telefone1, @Telefone2)",
                                                                     param, _session.Transaction);
        }
        public async Task<bool> UpdateAsync(Estabelecimento estab)
        {

            var param = new
            {
                ID = estab.Id,
                IdTipoEstabelecimento = estab.IdTipoEstabelecimento,
                IdPortfolio = estab.IdPortfolio,
                Nome = estab.Nome,
                Telefone1 = estab.Telefone1,
                Telefone2 = estab.Telefone2
            };

            var ret = await _session.Connection.ExecuteAsync(@"update tbl_Estabelecimento
                                                                   set IdTipoEstabelecimento = @IdTipoEstabelecimento,
                                                                    IdPortfolio = @IdPortfolio,            
                                                                   	Nome = @Nome,
                                                                   	Telefone1 = @Telefone1,
                                                                   	Telefone2 = @Telefone2
                                                                   where Id = @ID",
                                                            param, _session.Transaction);

            return ret > 0;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            var param = new
            {
                ID = id,
            };

            var ret = await _session.Connection.ExecuteAsync(@"delete from tbl_Estabelecimento
                                                               where Id = @ID",
                                                             param, _session.Transaction);

            return ret > 0;
        }
    }
}