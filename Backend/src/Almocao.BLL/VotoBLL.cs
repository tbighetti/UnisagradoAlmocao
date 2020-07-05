using Almocao.BLL.Infra;
using Almocao.DAL.Infra;
using Almocao.Entities;
using Almocao.Entities.DTO;
using Almocao.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.BLL
{
    public class VotoBLL : IVotoBLL
    {
        private readonly IVotoRepository _votoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IRestauranteRepository _restauranteRepository;

        public VotoBLL(IVotoRepository votoRepository, IAlunoRepository alunoRepository, IRestauranteRepository restauranteRepository)
        {
            _votoRepository = votoRepository;
            _alunoRepository = alunoRepository;
            _restauranteRepository = restauranteRepository;
        }

        public void Dispose()
        {
            _votoRepository?.Dispose();
        }

        public async Task ConfirmarAsync(string usuario, string senha, int restauranteId)
        {
            Task<Aluno> aluno = _alunoRepository.AutenticarAsync(usuario, senha);
            if (aluno.Result == null)
            {
                throw new BusinessException("Usuário ou Senha Inválidos");
            }

            Task<Voto> votoAluno = _votoRepository.VotoDoAluno(DateTime.Now.Date, aluno.Result.Id);
            if (votoAluno.Result != null && votoAluno.Result.Id > 0)
            {
                throw new BusinessException("Usuário já votou");
            }

            if (DateTime.Now.Hour >= 12)
            {
                throw new BusinessException("Votação encerrada");
            }

            Task<Restaurante> restaurante = _restauranteRepository.GetByIdAsync(restauranteId);
            if (restaurante.Result == null)
            {
                throw new BusinessException("Restaurante não encontrado");
            }

            _votoRepository.ConfirmarAsync(aluno.Result, restaurante.Result);
            await _votoRepository.UnitOfWork.Commit();
        }

        public VotoSituacaoDTO Status(string usuario, string senha)
        {
            Task<Aluno> aluno = _alunoRepository.AutenticarAsync(usuario, senha);
            if (aluno.Result == null)
            {
                throw new BusinessException("Usuário ou Senha Inválidos");
            }

            return _votoRepository.Status(aluno.Result);
        }
    }
}
