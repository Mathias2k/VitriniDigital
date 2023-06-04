using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VitriniDigital.Domain.DTO
{
    public class PortfolioDTO
    {
        [Required(ErrorMessage = "Links são obrigatórios")]
        public List<LinkDTO> Links { get; set; }

        [Required(ErrorMessage = "Imagens são obrigatórias")]
        public List<ImagemDTO> Imagens { get; set; }
    }
}
