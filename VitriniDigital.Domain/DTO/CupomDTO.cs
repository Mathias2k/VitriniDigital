using System.Collections.Generic;

namespace VitriniDigital.Domain.DTO
{
    public class CupomDTO
    {
        public int IdEstabelecimento { get; set; }
        //[Write(false)]
        public List<ImagemDTO> ImagensDto { get; set; }

        //[Write(false)]
        public List<LinkDTO> LinksDto { get; set; }
    }
}
