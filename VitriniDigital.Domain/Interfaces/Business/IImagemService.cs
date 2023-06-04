using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Domain.Interfaces.Business
{
    public interface IImagemService
    {
        Task AddImagemAsync(List<Imagem> imagens);
        Task<IEnumerable<Imagem>> GetImagemByIdPortfolioAsync(string id);
        Task UpdateImagemAsync(List<Imagem> imagens);
    }
}
