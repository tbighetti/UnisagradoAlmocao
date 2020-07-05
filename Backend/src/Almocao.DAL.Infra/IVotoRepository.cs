using Almocao.Entities;
using Almocao.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL.Infra
{
    public interface IVotoRepository : IRepository
    {
        Task<Voto> VotoDoAluno(DateTime dia, int alunoId);

        void ConfirmarAsync(Aluno aluno, Restaurante restaurante);

        List<VotoApuradoSemanaDTO> VotosDaSemana();

        List<int> VencedoresDaSemana();

        VotoSituacaoDTO Status(Aluno aluno);
    }
}
