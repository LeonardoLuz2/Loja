using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Infra.Data.Contexts;

namespace Loja.Infra.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LojaContext context)
            : base(context)
        {

        }
    }
}
