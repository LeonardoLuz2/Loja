using Loja.Domain.Interfaces;
using Loja.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LojaContext _context;

        public UnitOfWork(LojaContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
