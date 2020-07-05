using Almocao.BLL.Infra;
using Almocao.DAL.Infra;
using Almocao.Entities;
using System;
using System.Threading.Tasks;

namespace Almocao.BLL
{
    public class AlunoBLL : IAlunoBLL
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoBLL(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
        public async Task<Aluno> AutenticarAsync(string usuario, string senha)
        {
            return await _alunoRepository.AutenticarAsync(usuario, senha);
        }
    }
}
