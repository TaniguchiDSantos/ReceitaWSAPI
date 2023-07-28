using ReceitaWSAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Interfaces
{
    public interface IPedidoAppService : IAppService<PedidoViewModel>
    {
        Task<List<PedidoViewModel>> getAllPedidoAsync();
        Task CNPJSerachAsync(string cnpj);
    }
}
