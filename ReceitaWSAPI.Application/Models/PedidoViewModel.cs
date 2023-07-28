using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Models
{
    public class PedidoViewModel : ViewModel
    {
        public  string CNPJ { get; set; }
        public  string Result { get; set; }
    }
}
