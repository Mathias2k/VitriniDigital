using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class CupomRepository : ICupomRepository
    {
        private DbSession _session;
        public CupomRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<bool> InsertAsync(Cupom cupom)
        {
            var param = new
            {
                ID = cupom.Id,
                IdEstabelecimento = cupom.IdEstabelecimento,
                DataValidade = cupom.DataValidade,
                Descricao = cupom.Descricao,
                Desconto = cupom.Desconto
            };

            int ret = await _session.Connection.ExecuteAsync(@"insert into tbl_Cupom 
                                                               (Id, IdEstabelecimento, DataValidade, Descricao, Desconto, Ativo, DataCadastro) 
                                                               values(@ID, @IdEstabelecimento, @DataValidade, @Descricao, @Desconto, 1, getDate())",
                                                               param, _session.Transaction);

            return ret > 0;
        }
        public async Task<Cupom> SelectByIdAsync(string id)
        {
            var param = new
            {
                ID = id
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Cupom>(@"SELECT * FROM tbl_Cupom
                                                                                where Id = @ID",
                                                                                param, _session.Transaction);
        }
        public async Task<IEnumerable<Cupom>> SelectByIdEstabelecimentoAsync(string idEstab)
        {
            var param = new
            {
                IdEstabelecimento = idEstab
            };

            return await _session.Connection.QueryAsync<Cupom>(@"SELECT * FROM tbl_Cupom
                                                                 where IdEstabelecimento = @IdEstabelecimento",
                                                                 param, _session.Transaction);
        }
        public async Task<IEnumerable<Cupom>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Cupom>(@"SELECT * FROM tbl_Cupom",
                                                                 param: null, _session.Transaction);
        }
        public async Task<bool> UpdateCupomAsync(Cupom cupom)
        {
            var param = new
            {
                ID = cupom.Id,
                Descricao = cupom.Descricao,
                Desconto = cupom.Desconto,
                DataValidade = cupom.DataValidade
            };

            var ret = await _session.Connection.ExecuteAsync(@"update tbl_Cupom
                                                                set Descricao = @Descricao,
                                                                	Desconto = @Desconto,
                                                                	DataValidade = @DataValidade
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

            var ret = await _session.Connection.ExecuteAsync(@"update tbl_Cupom
                                                               set Ativo = 0
                                                               where Id = @ID",
                                                             param, _session.Transaction);

            return ret > 0;
        }
    }
}