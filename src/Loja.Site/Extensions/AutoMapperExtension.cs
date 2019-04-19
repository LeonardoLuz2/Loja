using AutoMapper;
using Loja.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Site.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }
    }
}
