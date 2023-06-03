using System;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Imagem
    {
        public string Id { get; private set; }
        public string ImageContent { get; private set; } //base64
        public static class ImagemFactory
        {
            public static Imagem CriarGuidImagem(ImagemDTO imgDto)
            {
                var imagem = new Imagem
                {
                    Id = Guid.NewGuid().ToString(),
                    ImageContent = imgDto.ImageContent
                };

                return imagem;
            }
        }
    }
}
