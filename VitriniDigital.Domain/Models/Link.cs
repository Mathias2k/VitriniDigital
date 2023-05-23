using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Link
    {
        public int Id { get; private set; }
        public int IdCupom { get; private set; }
        public string Url { get; private set; }
        public static class LinkFactory
        {
            public static Link CriarGuidLink(LinkDTO linkDto, int idCupom)
            {
                var link = new Link
                {
                    IdCupom = idCupom,
                    Url = linkDto.Url
                };

                return link;
            }
        }
    }
}
