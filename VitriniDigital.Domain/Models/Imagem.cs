using System.Collections.Generic;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Imagem
    {
        [JsonIgnore]
        public string IdPortfolio { get; private set; }
        public string ImageContent { get; private set; } //base64
        public static class ImagemFactory
        {
            public static List<Imagem> AdicionarImagem(List<ImagemDTO> imgDto, string idPortfolio)
            {
                var imagens = new List<Imagem>();

                if (imgDto?.Count > 0)
                {
                    for (int i = 0; i < imgDto.Count; i++)
                    {
                        var imagem = new Imagem
                        {
                            IdPortfolio = idPortfolio,
                            ImageContent = imgDto[i].ImageContent
                        };

                        imagens.Add(imagem);
                    }
                }

                return imagens;
            }
        }
    }
}
