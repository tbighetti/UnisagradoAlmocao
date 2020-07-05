using Almocao.DAL.Infra;
using Almocao.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Almocao.DAL
{
    public class AlmocaoDbContext : DbContext, IUnitOfWork
    {
        private IConfiguration configuration;

        public AlmocaoDbContext(IConfiguration config)
        {
            configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = configuration.GetConnectionString("AlmocaoDbBase");
            optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Voto> Voto { get; set; }
    }
}
