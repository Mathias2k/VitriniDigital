using DigitalQ.Domain.Config;
using System.Data;
using System.Data.SqlClient;

namespace DigitalQ.Infra.Data.Db
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        private readonly ApiConfiguration _config;
        public DbSession(ApiConfiguration config)
        {
            _config = config;
            _id = Guid.NewGuid();
            Connection = new SqlConnection(_config.ConnectionString);
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}
