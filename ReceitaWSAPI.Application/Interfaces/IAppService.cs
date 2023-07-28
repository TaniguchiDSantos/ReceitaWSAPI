using ReceitaWSAPI.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Application.Interfaces
{
    public interface IAppService<TViewModel> where TViewModel : ViewModel
    {
        Task<IEnumerable<TViewModel>> GetAllAsync();
        Task AddAsync(TViewModel obj);
    }
}
