using Microsoft.Extensions.DependencyInjection;
using ReceitaWSAPI.Infra.CrossCutting.IoC.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.RegisterGeralInjectorServices();
        }
    }
}
