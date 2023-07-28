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
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            //DomainToViewModel
            CreateMap<Pedido, PedidoViewModel>();

            //ViewModelToDomain
            CreateMap<PedidoViewModel, Pedido>();
        }
    }
}
