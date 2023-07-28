using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Domain.Entities
{
    public class Pedido : Entity<Pedido>
    {
        public string CNPJ { get; set; }
        public string Result { get; set; }
    }
}
