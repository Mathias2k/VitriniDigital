using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class LinkRepository : ILinkRepository
    {
        private DbSession _session;
        public LinkRepository(DbSession session)
        {
            _session = session;
        }
        public async Task InsertAsync(Link link)
        {
            var param = new
            {
                IdPortfolio = link.IdPortfolio,
                Url = link.Url
            };

            await _session.Connection.ExecuteAsync(@"INSERT INTO tbl_Link
                                                      (IdPortfolio, Url)
                                                     VALUES(@IdPortfolio, @Url)",
                                                     param, _session.Transaction);
        }
        public async Task<IEnumerable<Link>> SelectByIdPortfolioAsync(string id)
        {
            var param = new
            {
                ID = id
            };

           return await _session.Connection.QueryAsync<Link>(@"SELECT * FROM tbl_Link
                                                               WHERE IdPortfolio = @ID",
                                                               param, _session.Transaction);
        }
        public async Task UpdateAsync(Link link)
        {
            var param = new
            {
                ID = link.IdPortfolio,
                Url = link.Url
            };

            await _session.Connection.ExecuteAsync(@"update tbl_Link
                                                     set Url = @Url
                                                     where IdPortfolio = @ID",
                                                     param, _session.Transaction);

        }
    }
}
