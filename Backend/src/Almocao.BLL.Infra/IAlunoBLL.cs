using Almocao.Entities;
using System;
using System.Threading.Tasks;

namespace Almocao.BLL.Infra
{
    public interface IAlunoBLL : IDisposable
    {
        Task<Aluno> AutenticarAsync(string usuario, string senha);
    }
}
