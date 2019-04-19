using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Infra.Data.Context;

namespace Loja.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(LojaContext context)
            : base(context)
        {

        }
    }
}
