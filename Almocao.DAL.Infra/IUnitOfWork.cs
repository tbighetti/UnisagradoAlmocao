using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL.Infra
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
