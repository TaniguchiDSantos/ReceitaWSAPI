using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Models
{
    public class ViewModel
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string? IdUsuarioCriacao { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
    }
}
