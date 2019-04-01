﻿using Loja.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

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
