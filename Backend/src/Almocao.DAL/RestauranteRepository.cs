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
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly AlmocaoDbContext _dbContext;

        public RestauranteRepository(AlmocaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public async Task<Restaurante> GetByIdAsync(int restauranteId)
        {
            return await _dbContext.Restaurante.Where(x => x.Id.Equals(restauranteId)).FirstOrDefaultAsync();
        }
    }
}
