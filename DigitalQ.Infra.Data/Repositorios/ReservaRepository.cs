using Dapper;
using DigitalQ.Domain.Interfaces;
using DigitalQ.Domain.Models;
using DigitalQ.Infra.Data.Db;

namespace DigitalQ.Infra.Data.Repositorios
{
    public class ReservaRepository : IReservaRepository
    {
        private DbSession _session;
        public ReservaRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<IEnumerable<Usuario>> SelectAllAsync()
        {
            return await _session.Connection.QueryAsync<Usuario>("SELECT * FROM tbl_reserva", 
                                                                 null, _session.Transaction);
        }
        public async Task InsertAsync(Usuario reserva)
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

                int ret = await _session.Connection.ExecuteAsync(@"insert into tbl_reserva 
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
