using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitriniDigital.Domain.Interfaces.Business;
using VitriniDigital.Domain.Interfaces.Repos;
using VitriniDigital.Domain.Models;

namespace VitriniDigital.Service.Business
{
    public class ImagemService : IImagemService
    {
        private readonly IImagemRepository _imagemRepo;
        public ImagemService(IImagemRepository imagemRepo)
        {
            _imagemRepo = imagemRepo;
        }
        public async Task AddImagemAsync(List<Imagem> imagens)
        {
            if (imagens.Any())
                foreach (var imagem in imagens)
                    await _imagemRepo.InsertAsync(imagem);
        }
        public async Task<IEnumerable<Imagem>> GetImagemByIdPortfolioAsync(string id)
        {
            return await _imagemRepo.SelectByIdPortfolioAsync(id);
        }

        public async Task UpdateImagemAsync(List<Imagem> imagens)
        {
            if (imagens.Any())
                foreach (var img in imagens)
                    await _imagemRepo.UpdateAsync(img);
        }
    }
}
