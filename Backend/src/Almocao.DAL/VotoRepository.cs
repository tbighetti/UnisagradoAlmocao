using Almocao.DAL.Infra;
using Almocao.Entities;
using Almocao.Entities.DTO;
using Almocao.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL
{
    public class VotoRepository : IVotoRepository
    {
        private readonly AlmocaoDbContext _dbContext;

        public VotoRepository(AlmocaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public async Task<Voto> VotoDoAluno(DateTime dia, int alunoId)
        {
            return await _dbContext.Voto.Where(x => x.Dia == dia.Date && x.Aluno.Id.Equals(alunoId)).FirstOrDefaultAsync();
        }

        public void ConfirmarAsync(Aluno aluno, Restaurante restaurante)
        {
            _dbContext.Voto.Add(new Voto {
                Dia = DateTime.Now.Date,
                Aluno = aluno,
                Restaurante = restaurante
            });
        }

        public List<VotoApuradoSemanaDTO> VotosDaSemana()
        {
            DateTime dataInicioSemana = DateTime.Now.AddDays((int)DateTime.Now.DayOfWeek*-1);
            return _dbContext.Voto
                .Where(v => v.Dia.Date >= dataInicioSemana)
                .GroupBy(v => new { v.Dia.Date, v.Restaurante.Id })
                .Select(
                    v => new VotoApuradoSemanaDTO
                    {
                        Dia = v.Key.Date,
                        RestauranteId = v.Key.Id,
                        Votos = v.Count()
                    }
                )
                .OrderBy(v => v.Dia).ThenByDescending(v => v.Votos).ThenByDescending(v => v.RestauranteId)
                .ToList();
        }

        public List<int> VencedoresDaSemana()
        {
            List<int> vencedores = new List<int>();

            List<VotoApuradoSemanaDTO> votosDaSemana = VotosDaSemana();
            DateTime? dia = null;
            foreach (VotoApuradoSemanaDTO voto in votosDaSemana)
            {
                if (voto.Dia.Equals(dia))
                {
                    continue;
                }
                dia = voto.Dia.Date;
                vencedores.Add(voto.RestauranteId);
            }

            return vencedores;
        }

        public VotoSituacaoDTO Status(Aluno aluno)
        {
            var votoSituacaoDTO = new VotoSituacaoDTO();
            votoSituacaoDTO.Situacao = VotoSituacaoDTO.SituacaoVoto.Aberto;

            var votoAluno = VotoDoAluno(DateTime.Now.Date, aluno.Id);
            if (votoAluno.Result != null && votoAluno.Result.Id > 0)
            {
                votoSituacaoDTO.Situacao = VotoSituacaoDTO.SituacaoVoto.Votado;
            }

            if (DateTime.Now.Hour >= 12)
            {
                votoSituacaoDTO.Situacao = VotoSituacaoDTO.SituacaoVoto.Encerrado;
            }

            votoSituacaoDTO.Dia = DateTime.Now.Date;

            if (votoSituacaoDTO.Situacao == VotoSituacaoDTO.SituacaoVoto.Aberto)
            {
                List<int> vencedoresDaSemana = VencedoresDaSemana();
                votoSituacaoDTO.Restaurantes = _dbContext.Restaurante
                    .Where(r => !vencedoresDaSemana.Contains(r.Id))
                    .Select(
                        v => new VotoApuradoDTO
                        {
                            RestauranteId = v.Id,
                            RestauranteNome = v.Nome,
                            RestauranteEndereco = v.Endereco
                        }
                    )
                    .ToList();
            }
            else
            {
                votoSituacaoDTO.Restaurantes = _dbContext.Voto
                    .Where(v => v.Dia.Date == DateTime.Now.Date)
                    .GroupBy(v => new { v.Restaurante.Id, v.Restaurante.Nome, v.Restaurante.Endereco })
                    .Select(
                        v => new VotoApuradoDTO
                        {
                            RestauranteId = v.Key.Id,
                            RestauranteNome = v.Key.Nome,
                            RestauranteEndereco = v.Key.Endereco,
                            Votos = v.Count()
                        }
                    )
                    .OrderByDescending(v => v.Votos).ThenBy(v => v.RestauranteId)
                    .ToList();
            }

            return votoSituacaoDTO;
        }
    }
}
