using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Imagem
    {
        public int Id { get; private set; }
        public int IdCupom { get; private set; }
        public byte[] Content { get; private set; } //byte ou base64
        public static class ImagemFactory
        {
            public static Imagem CriarGuidImagem(ImagemDTO imgDto, int idCupom)
            {
                var imagem = new Imagem
                {
                    IdCupom = idCupom,
                    Content = imgDto.Content
                };

                return imagem;
            }
        }
    }
}
