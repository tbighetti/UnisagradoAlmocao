using Almocao.Entities;
using Almocao.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.BLL.Infra
{
    public interface IVotoBLL : IDisposable
    {
        Task ConfirmarAsync(string usuario, string senha, int restauranteId);

        VotoSituacaoDTO Status(string usuario, string senha);
    }
}
