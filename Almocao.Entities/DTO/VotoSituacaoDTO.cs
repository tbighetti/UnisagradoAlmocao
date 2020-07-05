using System;
using System.Collections.Generic;
using System.Text;

namespace Almocao.Entities.DTO
{
    public class VotoSituacaoDTO
    {
        public enum SituacaoVoto
        {
            Aberto = 0,
            Votado = 1,
            Encerrado = 2
        }

        public SituacaoVoto Situacao { get; set; }
        public DateTime Dia { get; set; }

        public List<VotoApuradoDTO> Restaurantes { get; set; }
    }
}
