using Loja.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IProdutoAppService
    {
        void Register(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> GetAll();
        ProdutoViewModel GetById(Guid id);
        void Update(ProdutoViewModel produtoViewModel);
        void Remove(Guid id);

        Task<IEnumerable<ProdutoViewModel>> GetAsync();
        Task<ProdutoViewModel> GetAsync(Guid id);
    }
}
