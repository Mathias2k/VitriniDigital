using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class ImagemRepository : IImagemRepository
    {
        private DbSession _session;
        public ImagemRepository(DbSession session)
        {
            _session = session;
        }
        public async Task InsertAsync(Imagem link)
        {
            var param = new
            {
                IdPortfolio = link.IdPortfolio,
                ImageContent = link.ImageContent
            };

            await _session.Connection.ExecuteAsync(@"INSERT INTO tbl_Imagem
                                                      (IdPortfolio, ImageContent)
                                                     VALUES(@IdPortfolio, @ImageContent)",
                                                     param, _session.Transaction);
        }
        public async Task<IEnumerable<Imagem>> SelectByIdPortfolioAsync(string id)
        {
            var param = new
            {
                ID = id
            };

            return await _session.Connection.QueryAsync<Imagem>(@"SELECT * FROM tbl_Imagem
                                                                  WHERE IdPortfolio = @ID",
                                                                  param, _session.Transaction);
        }
        public async Task UpdateAsync(Imagem imagem)
        {
            var param = new
            {
                ID = imagem.IdPortfolio,
                ImageContent = imagem.ImageContent
            };

            await _session.Connection.ExecuteAsync(@"update tbl_Imagem
                                                     set ImageContent = @ImageContent
                                                     where IdPortfolio = @ID",
                                                     param, _session.Transaction);

        }
    }
}