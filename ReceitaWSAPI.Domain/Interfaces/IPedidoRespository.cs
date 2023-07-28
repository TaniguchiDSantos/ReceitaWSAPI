using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Domain.Interfaces
{
    public interface IPedidoRespository : IRepository<Pedido>
    {
        Task<List<Pedido>> GetAllPedidoAsync();
        Task CNPJSerachAsync(string cnpj);
    }
}
