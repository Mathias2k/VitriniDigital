using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.DTO;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IEnderecoService
    {
        Task<int> AddEnderecoAsync(EnderecoDTO endDto);
        Task<Endereco> GetEnderecoByIdAsync(int idEnd);
    }
}
