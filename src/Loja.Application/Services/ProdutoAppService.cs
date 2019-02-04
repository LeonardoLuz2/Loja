using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProdutoAppService(IProdutoRepository produtoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public void Register(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Add(produto);

            _uow.Commit();
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(_produtoRepository.GetAll());
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(_produtoRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _produtoRepository.Remove(id);

            _uow.Commit();
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Update(produto);

            _uow.Commit();
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAsync()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.GetAsync());
        }

        public async Task<ProdutoViewModel> GetAsync(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.GetAsync(id));
        }
    }
}
