using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using ReceitaWSAPI.Domain.Entities;
using ReceitaWSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceitaWSAPI.Data.Context;
using FluentAssertions.Common;

namespace ReceitaWSAPI.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected ReceitaWSContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(ReceitaWSContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();

        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            await Db.SaveChangesAsync();
            return obj;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var teste = await DbSet.AsNoTracking().ToListAsync();
            return await DbSet.AsNoTracking().ToListAsync();
        }
    }
}
