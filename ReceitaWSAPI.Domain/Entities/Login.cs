using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Domain.Entities
{
    public class Login : Entity<Login>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
