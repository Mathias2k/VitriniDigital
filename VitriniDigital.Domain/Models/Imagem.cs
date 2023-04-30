using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Imagem
    {
        public int Id { get; private set; }
        public int IdPortfolio { get; private set; }
        public byte[] Content { get; private set; } //byte ou base64
        public static class ImagemFactory
        {
            public static Imagem CriarGuidImagem(ImagemDTO imgDto, int idPortfolio)
            {
                var imagem = new Imagem
                {
                    IdPortfolio = idPortfolio,
                    Content = imgDto.Content
                };

                return imagem;
            }
        }
    }
}
