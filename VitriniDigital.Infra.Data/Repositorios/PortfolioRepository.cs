using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Infra.Data.Repositorios
{
    public class PortfolioRepository : IPortfolioRepository
    {
        //TODO
        public Task InsertAsync(Portfolio user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Portfolio>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
