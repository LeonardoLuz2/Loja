using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Commands.Product;
using Loja.Domain.Entities;

namespace Loja.Application.AutoMapper
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductViewModel, RegisterProductCommand>()
                .ConstructUsing(p => new RegisterProductCommand(p.Name, p.Price))
                .ForMember(p => p.Id, x => x.Ignore())
                .AfterMap((viewModel, command) => viewModel.Id = command.Id);

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(p => new UpdateProductCommand(p.Id, p.Name, p.Price));
        }
    }
}
