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
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly ILogger<EstabelecimentoRepository> _logger;
        private DbSession _session;
        public EstabelecimentoRepository(DbSession session,
                                         ILogger<EstabelecimentoRepository> logger
            )
        {
            _logger = logger;
            _session = session;
        }
        public async Task<Estabelecimento> SelectByIdAsync(int idEstab)
        {
            var param = new
            {
                ID = idEstab
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Estabelecimento>(@"SELECT * FROM tbl_Estabelecimento
                                                                                         where Id = @ID",
                                                                                         param, _session.Transaction);
        }
        public async Task<IEnumerable<Estabelecimento>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Estabelecimento>(@"SELECT * FROM tbl_Estabelecimento",
                                                                         param: null, _session.Transaction);
        }
        public async Task<int> InsertAsync(Estabelecimento estab)
        {
            try
            {
                var param = new
                {
                    IdTipoEstabelecimento = estab.IdTipoEstabelecimento,
                    //IdEndereco = estab.IdEndereco,
                    Nome = estab.Nome,
                    Email = estab.Email,
                    Telefone1 = estab.Telefone1,
                    Telefone2 = estab.Telefone2
                };

                return await _session.Connection.QuerySingleAsync<int>(@"INSERT INTO tbl_Estabelecimento
                                                                         (IdTipoEstabelecimento, IdEndereco,
                                                                          Nome, Email, Telefone1, Telefone2)
                                                                         OUTPUT INSERTED.ID
                                                                         VALUES(@IdTipoEstabelecimento, @IdEndereco,
                                                                                @Nome, @Email, @Telefone1, @Telefone2)",
                                                                         param, _session.Transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError("EstabelecimentoRepository.InsertAsync - ", ex);
                throw;
            }
        }
        public async Task<int> UpdateAsync(int id, EstabelecimentoDTO estab)
        {
            try
            {
                var param = new
                {
                    ID = id,
                    IdTipoEstabelecimento = (int)estab.TipoEstabelecimento,
                    Nome = estab.Nome,
                    Email = estab.Email,
                    Telefone1 = estab.Telefone1,
                    Telefone2 = estab.Telefone2
                };

                return await _session.Connection.ExecuteAsync(@"update tbl_Estabelecimento
                                                                set IdTipoEstabelecimento = @IdTipoEstabelecimento,
                                                                	Nome = @Nome,
                                                                	Email = @Email,
                                                                	Telefone1 = @Telefone1,
                                                                	Telefone2 = @Telefone2
                                                                where Id = @ID",
                                                                param, _session.Transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError("EstabelecimentoRepository.UpdateAsync - ", ex);
                throw;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var param = new
                {
                    ID = id,
                };

                return await _session.Connection.ExecuteAsync(@"delete from tbl_Estabelecimento
                                                                where Id = @ID",
                                                                param, _session.Transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError("EstabelecimentoRepository.DeleteAsync - ", ex);
                throw;
            }
        }
    }
}