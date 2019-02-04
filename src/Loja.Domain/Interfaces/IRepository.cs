using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Add(TEntity obj);
        void Remove(Guid id);
        void Update(TEntity obj);

        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(Guid id);
    }
}
