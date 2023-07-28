using ReceitaWSAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Interfaces
{
    public interface ILoginAppService : IAppService<LoginViewModel>
    {
        Task<LoginViewModel> VerifyLogin(LoginViewModel loginViewModel);
    }
}
