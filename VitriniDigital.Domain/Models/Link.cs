using System;
using VitriniDigital.Domain.DTO;

namespace VitriniDigital.Domain.Models
{
    public class Link
    {
        public string Id { get; private set; }
        public string Url { get; private set; }
        public static class LinkFactory
        {
            public static Link CriarGuidLink(LinkDTO linkDto)
            {
                var link = new Link
                {
                    Id = Guid.NewGuid().ToString(),
                    Url = linkDto.Url
                };

                return link;
            }
        }
    }
}