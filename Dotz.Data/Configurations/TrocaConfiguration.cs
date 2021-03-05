using Dotz.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotz.Data.Configurations
{
    public class TrocaConfiguration : IEntityTypeConfiguration<Troca>
    {
        public void Configure(EntityTypeBuilder<Troca> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Id)
                .UseIdentityColumn();

            builder
                .HasOne(o => o.Usuario)
                .WithMany(o => o.Trocas)
                .HasForeignKey(o => o.UsuarioId);

            builder
                .HasMany(o => o.Produtos)
                .WithOne(o => o.Troca)
                .HasForeignKey(o => o.TrocaId);

            builder
                .ToTable("Trocas");
        }
    }
}
