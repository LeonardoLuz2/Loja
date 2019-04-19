using FluentValidation;
using Loja.Application.Interfaces;
using Loja.Application.Services;
using Loja.Domain.CommandHandlers;
using Loja.Domain.Commands.Product;
using Loja.Domain.Core.Notifications;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations.Product;
using Loja.Infra.Data.Repositories;
using Loja.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Loja.Infra.CrossCutting.IoC
{
    public static class NativeDependencyInjection
    {
        public static void RegisterDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAppService, ProductAppService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRequestHandler<RegisterProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, ProductCommandHandler>();

            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
        }
    }
}
