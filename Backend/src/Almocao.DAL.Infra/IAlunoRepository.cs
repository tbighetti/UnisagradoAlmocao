using Almocao.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL.Infra
{
    public interface IAlunoRepository : IRepository
    {
        Task<Aluno> AutenticarAsync(string usuario, string senha);
    }
}
