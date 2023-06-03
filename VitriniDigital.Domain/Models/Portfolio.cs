using System.Collections.Generic;

namespace VitriniDigital.Domain.Models
{
    public class Portfolio
    {
        public string Id { get; set; }
        public List<Link> Links { get; set; }        
        public List<Imagem> Imagens { get; set; }
    }
}
