using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Commands.Product;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public ProductAppService(IProductRepository productRepository, 
            IMapper mapper, 
            IUnitOfWork uow, 
            IMediator mediator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _uow = uow;
            _mediator = mediator;
        }

        public void Register(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<RegisterProductCommand>(productViewModel);
            _mediator.Send(product);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(_productRepository.GetAll());
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var product = new RemoveProductCommand(id);
            _mediator.Send(product);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<UpdateProductCommand>(productViewModel);
            _mediator.Send(product);
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllAsync());
        }

        public async Task<ProductViewModel> GetByIdAsync(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetByIdAsync(id));
        }
    }
}
