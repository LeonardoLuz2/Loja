using FluentValidation;
using Loja.Application.Interfaces;
using Loja.Application.Services;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using Loja.Infra.Data.Repositories;
using Loja.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.CrossCutting.IoC
{
    public static class NativeDependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IValidator<Produto>, ProdutoValidation>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IValidator<Produto>, ProdutoValidation>();
        }
    }
}
