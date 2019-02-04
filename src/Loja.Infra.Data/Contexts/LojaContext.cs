﻿using Loja.Domain.Entities;
using Loja.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data.Contexts
{
    public class LojaContext : DbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options)
            : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
