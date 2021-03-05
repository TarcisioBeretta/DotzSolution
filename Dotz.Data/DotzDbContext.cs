using Dotz.Core.Models;
using Dotz.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dotz.Data
{
    public class DotzDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Troca> Trocas { get; set; }

        public DotzDbContext(DbContextOptions<DotzDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
