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
            return await _session.Connection.QueryAsync<Usuario>("SELECT * FROM tbl_usuario", 
                                                                 null, _session.Transaction);
        }
        public async Task InsertAsync(Usuario user)
        {
            try
            {
                var param = new
                {
                    //Id = reserva.Id,
                    //IdUsuario = reserva.IdUsuario,
                    //IdEstabelecimento = reserva.IdEstabelecimento,
                    //DataHoraReserva = reserva.DataHoraReserva,
                    //QtdePessoas = reserva.QtdePessoas,
                    //StatusReserva = reserva.StatusReserva
                };

                int ret = await _session.Connection.ExecuteAsync(@"insert into tbl_usuario 
                                                                   (Id, IdEstabelecimento, IdUsuario DataHoraReserva, 
                                                                   QtdePessoas, StatusReserva) 
                                                                   values(@Id, @IdUsuario, @IdEstabelecimento, @DataHoraReserva, 
                                                                   @QtdePessoas, @StatusReserva)",
                                                                   param, _session.Transaction);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
