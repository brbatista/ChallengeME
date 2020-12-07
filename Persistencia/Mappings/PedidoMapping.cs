using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(f => f.Itens)
                .WithOne(p => p.Pedido)
                .HasForeignKey(p => p.IdPedido);

            builder.ToTable("Pedido");
        }
    }
}
