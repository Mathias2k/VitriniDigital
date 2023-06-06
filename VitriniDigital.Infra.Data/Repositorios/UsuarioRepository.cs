using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;
using VitriniDigital.Infra.Data.Db;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DbSession _session;
        public UsuarioRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<IEnumerable<Usuario>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Usuario>("SELECT * FROM tbl_Usuario",
                                                                 null, _session.Transaction);
        }
        public async Task<Usuario> SelectByIdAsync(string id)
        {
            var param = new
            {
                ID = id
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Usuario>(@"SELECT * FROM tbl_Usuario
                                                                                  where Id = @ID",
                                                                                  param, _session.Transaction);
        }
        public async Task<Usuario> SelectByUserNameAsync(string username)
        {
            var param = new
            {
                UserName = username
            };

            return await _session.Connection.QuerySingleOrDefaultAsync<Usuario>(@"SELECT * FROM tbl_Usuario
                                                                                  where UserName = @UserName",
                                                                                  param, _session.Transaction);
        }
        public async Task<bool> InsertAsync(Usuario user)
        {
            var param = new
            {
                Id = user.Id,
                UserName = user.UserName
            };

            int ret = await _session.Connection.ExecuteAsync(@"insert into tbl_Usuario 
                                                                   (Id, UserName, Ativo) 
                                                                   values(@Id, @UserName, 1)",
                                                               param, _session.Transaction);

            return ret > 0;
        }
        public async Task<bool> DisableUserAsync(string id)
        {
            var param = new
            {
                Id = id,
            };

            int ret = await _session.Connection.ExecuteAsync(@"update tbl_Usuario
                                                                set Ativo = 0
                                                                where Id = @ID",
                                                               param, _session.Transaction);

            return ret > 0;
        }
    }
}