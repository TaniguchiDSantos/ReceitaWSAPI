using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReceitaWSAPI.Data.Mappings;
using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Data.Context
{
    public class ReceitaWSContext : DbContext
    {
        public ReceitaWSContext(DbContextOptions options) : base(options) { }
        public DbSet<Login> Login { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.EnableSensitiveDataLogging(true)
                .UseSqlServer(config.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("ReceitaWSAPI.Data"));
        }
    }
}
