using System.Collections.Generic;
using System.Text.Json.Serialization;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Link
    {
        [JsonIgnore]
        public string IdPortfolio { get; private set; }
        public string Url { get; private set; }
        public static class LinkFactory
        {
            public static List<Link> AdicionarLink(List<LinkDTO> linkDto, string idPortfolio)
            {
                var links = new List<Link>();
                if (linkDto?.Count > 0)
                {
                    for (int i = 0; i < linkDto.Count; i++)
                    {
                        var link = new Link
                        {
                            IdPortfolio = idPortfolio,
                            Url = linkDto[i].Url
                        };

                        links.Add(link);
                    }
                }

                return links;
            }
        }
    }
}