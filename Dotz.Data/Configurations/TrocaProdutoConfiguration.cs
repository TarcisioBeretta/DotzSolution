using Dotz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Data.Configurations
{
    public class TrocaProdutoConfiguration : IEntityTypeConfiguration<TrocaProduto>
    {
        public void Configure(EntityTypeBuilder<TrocaProduto> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .UseIdentityColumn();

            builder
                .HasOne(o => o.Troca)
                .WithMany()
                .HasForeignKey(o => o.TrocaId);

            builder
                .HasOne(o => o.Produto)
                .WithMany()
                .HasForeignKey(o => o.TrocaId);

            builder
                .Property(m => m.Quantidade)
                .IsRequired();

            builder
                .ToTable("TrocaProdutos");
        }
    }
}
