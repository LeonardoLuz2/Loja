using Loja.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Site.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeDependencyInjection.RegisterDependencyInjection(services);
        }
    }
}
