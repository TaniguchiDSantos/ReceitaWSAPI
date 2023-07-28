using AutoMapper;
using ReceitaWSAPI.Application.Interfaces;
using ReceitaWSAPI.Application.Models;
using ReceitaWSAPI.Data.Repository;
using ReceitaWSAPI.Domain.Entities;
using ReceitaWSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Services
{
    public abstract class AppService<TViewModel, TRepository, TEntity> : IAppService<TViewModel> where TEntity : Entity<TEntity> where TRepository : IRepository<TEntity> where TViewModel : ViewModel
    {
        protected IMapper Mapper { get; private set; }
        protected TRepository Repository { get; private set; }

        protected void SetRepository(TRepository repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync()
        {
            var teste = Mapper.Map<IEnumerable<TViewModel>>(await Repository.GetAllAsync());
            return Mapper.Map<IEnumerable<TViewModel>>(await Repository.GetAllAsync());
        }

        public virtual async Task AddAsync(TViewModel obj)
        {
            var entity = Mapper.Map<TEntity>(obj);

            await Repository.AddAsync(entity);
        }

    }
}
