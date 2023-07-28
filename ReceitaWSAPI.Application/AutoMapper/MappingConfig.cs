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
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<LoginViewModel, Login>().ReverseMap();
                config.CreateMap<PedidoViewModel, Pedido>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
