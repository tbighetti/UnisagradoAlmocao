using System;
using System.Collections.Generic;
using System.Text;

namespace Almocao.Entities.DTO
{
    public class VotoApuradoDTO
    {
        public int RestauranteId { get; set; }
        public int Votos { get; set; }
        public String RestauranteNome { get; set; }
        public String RestauranteEndereco { get; set; }
    }
}
