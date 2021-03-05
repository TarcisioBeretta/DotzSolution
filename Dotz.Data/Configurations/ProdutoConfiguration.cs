using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dotz.Core.Models;

namespace Dotz.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(m => m.Pontos)
                .IsRequired();

            builder
                .ToTable("Produtos");
        }
    }
}
