using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Domain.Interfaces
{
    public interface ILoginRespository : IRepository<Login>
    {
        Task<Login> VerifyLogin(Login login);
    }
}
