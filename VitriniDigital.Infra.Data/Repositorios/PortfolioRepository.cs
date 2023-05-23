using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class CupomRepository : ICupomRepository
    {
        //TODO
        public Task InsertAsync(Cupom user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cupom>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
