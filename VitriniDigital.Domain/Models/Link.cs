using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Link
    {
        public int Id { get; private set; }
        public int IdPortfolio { get; private set; }
        public string Url { get; private set; }
        public static class LinkFactory
        {
            public static Link CriarGuidLink(LinkDTO linkDto, int idPortfolio)
            {
                var link = new Link
                {
                    IdPortfolio = idPortfolio,
                    Url = linkDto.Url
                };

                return link;
            }
        }
    }
}
