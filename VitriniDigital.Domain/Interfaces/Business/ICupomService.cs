using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface ICupomService
    {
        Task<bool> AddCupomAsync(CupomDTO userDto);
        Task<IEnumerable<Cupom>> GetAllCupomsAsync();
        Task<Cupom> GetCupomByIdAsync(Guid id);
        Task UpdateCupomAsync(CupomDTO CupomDto);
    }
}
