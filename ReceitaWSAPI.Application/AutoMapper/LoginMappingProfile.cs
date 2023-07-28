using AutoMapper;
using ReceitaWSAPI.Application.Models;
using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.AutoMapper
{
    public class LoginMappingProfile : Profile
    {
        public LoginMappingProfile()
        {
            //DomainToViewModel
            CreateMap<Login, LoginViewModel>();

            //ViewModelToDomain
            CreateMap<LoginViewModel, Login>();
        }
    }
}
