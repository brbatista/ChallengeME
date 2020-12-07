using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Models;

namespace Persistencia.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(200)");

            builder.Property(c => c.PrecoUnitario)
                   .IsRequired()
                   .HasColumnType("decimal(19,4)");

            builder.Property(c => c.Qtd)
                   .IsRequired()
                   .HasColumnType("int");

            builder.ToTable("Item");
        }
    }
}
