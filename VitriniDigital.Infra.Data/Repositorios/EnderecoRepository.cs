using Dapper;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger<EnderecoRepository> _logger;
        private DbSession _session;
        public EnderecoRepository(DbSession session,
                                  ILogger<EnderecoRepository> logger)
        {
            _logger = logger;
            _session = session;
        }
        public async Task<Endereco> SelectByIdAsync(int idEnd)
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
        public async Task<int> InsertAsync(EnderecoDTO end)
        {
            try
            {
                var param = new
                {
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

                return await _session.Connection.QuerySingleAsync<int>(@"INSERT INTO tbl_Endereco
                                                                            (Logradouro, CEP, Complemento, Numero,
                                                                             PontoReferencia, Cidade, Bairro, UF,
                                                                             Latitude, Longitude)
                                                                         OUTPUT INSERTED.ID
                                                                         VALUES(@Logradouro, @CEP, @Complemento, @Numero,
                                                                                @PontoReferencia, @Cidade, @Bairro, @UF,
                                                                                @Latitude, @Longitude)",
                                                                         param, _session.Transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError("EnderecoRepository.InsertAsync - ", ex);
                throw;
            }
        }
    }
}
