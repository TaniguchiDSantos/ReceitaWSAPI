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
    public class PedidoAppService : AppService<PedidoViewModel, IPedidoRespository, Pedido>, IPedidoAppService
    {
        protected IMapper MapperPedido { get; private set; }

        public PedidoAppService(IPedidoRespository repository)
        {
            SetRepository(repository);
            SetMapperPedido();
        }

        protected void SetMapperPedido()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PedidoMappingProfile>();
            });
            MapperPedido = configuration.CreateMapper();
        }

        public virtual async Task CNPJSerachAsync(string cnpj)
        {
            await Repository.CNPJSerachAsync(cnpj);
        }

        public async Task<List<PedidoViewModel>> getAllPedidoAsync()
        {
            return (List<PedidoViewModel>)MapperPedido.Map<IEnumerable<PedidoViewModel>>(await Repository.GetAllPedidoAsync());
        }
    }
}
