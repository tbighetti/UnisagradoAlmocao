using Almocao.DAL.Infra;
using Almocao.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlmocaoDbContext _dbContext;

        public AlunoRepository(AlmocaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<Aluno> AutenticarAsync(string usuario, string senha)
        {
            return await _dbContext.Aluno.Where(x => x.Usuario.Equals(usuario) && x.Senha.Equals(senha)).FirstOrDefaultAsync();
        }

    }
}
