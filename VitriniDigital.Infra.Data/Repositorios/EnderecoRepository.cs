using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private DbSession _session;
        public EnderecoRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<Endereco> SelectByIdAsync(string idEnd)
        {
            var param = new
            {
                ID = idEnd
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Endereco>(@"SELECT * FROM tbl_Endereco
                                                                                  where Id = @ID",
                                                                                  param, _session.Transaction);
        }

        public async Task<IEnumerable<Endereco>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Endereco>(@"SELECT * FROM tbl_Endereco",
                                                                    param: null, _session.Transaction);
        }
        public async Task<string> InsertAsync(Endereco end)
        {
            var param = new
            {
                ID = end.Id,
                Logradouro = end.Logradouro,
                CEP = end.CEP,
                Complemento = end.Complemento,
                Numero = end.Numero,
                PontoReferencia = end.PontoReferencia,
                Cidade = end.Cidade,
                Bairro = end.Bairro,
                UF = end.UF,
                Latitude = end.Latitude,
                Longitude = end.Longitude
            };

            return await _session.Connection.QuerySingleAsync<string>(@"INSERT INTO tbl_Endereco
                                                                            (Id, Logradouro, CEP, Complemento, Numero,
                                                                             PontoReferencia, Cidade, Bairro, UF,
                                                                             Latitude, Longitude)
                                                                         OUTPUT INSERTED.ID
                                                                         VALUES(@ID, @Logradouro, @CEP, @Complemento, @Numero,
                                                                                @PontoReferencia, @Cidade, @Bairro, @UF,
                                                                                @Latitude, @Longitude)",
                                                                     param, _session.Transaction);
        }
        public async Task<int> UpdateAsync(Endereco end)
        {
            var param = new
            {
                ID = end.Id,
                Logradouro = end.Logradouro,
                CEP = end.CEP,
                Complemento = end.Complemento,
                Numero = end.Numero,
                PontoReferencia = end.PontoReferencia,
                Cidade = end.Cidade,
                Bairro = end.Bairro,
                UF = end.UF,
                Latitude = end.Latitude,
                Longitude = end.Longitude
            };

            return await _session.Connection.ExecuteAsync(@"update tbl_Endereco
                                                                set Logradouro = @Logradouro,
                                                                	CEP = @CEP,
                                                                	Complemento = @Complemento,
                                                                	Numero = @Numero,
                                                                	PontoReferencia = @PontoReferencia,
                                                                	Cidade = @Cidade,
                                                                	Bairro = @Bairro,
                                                                	UF = @UF,
                                                                	Latitude = @Latitude,
                                                                	Longitude = @Longitude
                                                                where Id = @ID",
                                                            param, _session.Transaction);
        }
        //public async Task<int> DeleteAsync(string id)
        //{
        //    var param = new
        //    {
        //        ID = id,
        //    };

        //    return await _session.Connection.ExecuteAsync(@"delete from tbl_Endereco
        //                                                        where Id = @ID",
        //                                                    param, _session.Transaction);

        //}
    }
}