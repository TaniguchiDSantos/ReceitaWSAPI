using AutoMapper;
using ReceitaWSAPI.Application.AutoMapper;
using ReceitaWSAPI.Application.Interfaces;
using ReceitaWSAPI.Application.Models;
using ReceitaWSAPI.Domain.Entities;
using ReceitaWSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Services
{
    public class LoginAppService : AppService<LoginViewModel, ILoginRespository, Login>, ILoginAppService
    {
        protected IMapper MapperLogin { get; private set; }

        public LoginAppService(ILoginRespository repository)
        {
            SetRepository(repository);
            SetMapperLogin();
        }

        protected void SetMapperLogin()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LoginMappingProfile>();
            });
            MapperLogin = configuration.CreateMapper();
        }

        public async Task<LoginViewModel> VerifyLogin(LoginViewModel loginViewModel)
        {
            var entity = MapperLogin.Map<Login>(loginViewModel);

            return MapperLogin.Map<LoginViewModel>(await Repository.VerifyLogin(entity));
        }
    }
}
