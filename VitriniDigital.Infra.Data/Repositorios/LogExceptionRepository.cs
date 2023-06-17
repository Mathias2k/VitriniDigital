using Dapper;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models.Exception;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class LogExceptionRepository : ILogExceptionRepository
    {
        private DbSession _session;
        public LogExceptionRepository(DbSession session)
        {
            _session = session;
        }
        public async Task AddErrorAsync(LogException log)
        {
            var param = new
            {
                Endpoint = log.Endpoint,
                MessageError = log.MessageError
            };

            await _session.Connection.ExecuteAsync(@"INSERT INTO tbl_LogException
                                                      (Endpoint, MessageError)
                                                     VALUES(@Endpoint, @MessageError)",
                                                     param, _session.Transaction);
        }
    }
}