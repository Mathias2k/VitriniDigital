using Dapper;
using System;
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
        public async Task<bool> InsertAsync(Usuario user)
        {
            try
            {
                var param = new
                {
                    Id = user.Id,
                    UserName = user.UserName
                };

                int ret = await _session.Connection.ExecuteAsync(@"insert into tbl_Usuario 
                                                                   (Id, UserName) 
                                                                   values(@Id, @UserName)",
                                                                   param, _session.Transaction);

                return ret > 0;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
