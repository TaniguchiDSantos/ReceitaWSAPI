using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceitaWSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitaWSAPI.Data.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PK__Pedido__09BA1410FFF7304D");

            builder.ToTable("Pedido");

            builder.Property(e => e.Id)
               .HasColumnName("PedidoID");

            builder.Property(e => e.CNPJ)
                .HasColumnName("CNPJ");

            builder.Property(e => e.Result).HasColumnName("Resultado");

            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(e => e.ClassLevelCascadeMode);
            builder.Ignore(e => e.RuleLevelCascadeMode);
            builder.Ignore(e => e.IdUsuarioCriacao);
            builder.Ignore(e => e.Ativo);
            builder.Ignore(e => e.DataHoraCriacao);
        }
    }
}
