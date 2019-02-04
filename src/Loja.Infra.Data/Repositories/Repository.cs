using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly LojaContext _context;
        private readonly DbSet<TEntity> _db;

        public Repository(LojaContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            _db.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public TEntity GetById(Guid id)
        {
            return _db.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(Guid id)
        {
            _db.Remove(GetById(id));
        }

        public void Update(TEntity obj)
        {
            _db.Update(obj);
        }
    }
}
