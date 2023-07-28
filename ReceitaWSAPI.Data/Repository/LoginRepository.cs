using Microsoft.EntityFrameworkCore;
using ReceitaWSAPI.Data.Context;
using ReceitaWSAPI.Domain.Entities;
using ReceitaWSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Data.Repository
{
    public class LoginRepository : Repository<Login>, ILoginRespository
    {
        public LoginRepository(ReceitaWSContext context) : base(context)
        {
        }

        public async Task<Login> VerifyLogin(Login login)
        {
            return await DbSet.AsNoTracking().Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefaultAsync();
        }
    }
}
