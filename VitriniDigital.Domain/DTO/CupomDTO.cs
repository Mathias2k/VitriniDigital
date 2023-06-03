using System;
using System.Collections.Generic;

namespace VitriniDigital.Domain.DTO
{
    public class CupomDTO
    {
        public string IdEstabelecimento { get; set; }
        public DateTime DataValidade { get; set; }
        public int Desconto { get; set; }
        public string Descricao { get; set; }
        
        //public List<ImagemDTO> ImagensDto { get; set; }
        //public List<LinkDTO> LinksDto { get; set; }
    }
}
