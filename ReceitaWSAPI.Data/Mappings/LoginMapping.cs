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
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(e => e.Email)
                    .HasName("PK__Login__A9D10535FD13D13C");

            builder.ToTable("Login");

            builder.Property(e => e.Email)
                .HasColumnName("Email");

            builder.Property(e => e.Password).HasColumnName("Password");

            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(e => e.ClassLevelCascadeMode);
            builder.Ignore(e => e.RuleLevelCascadeMode);
            builder.Ignore(e => e.IdUsuarioCriacao);
            builder.Ignore(e => e.Id);
            builder.Ignore(e => e.Ativo);
            builder.Ignore(e => e.DataHoraCriacao);
        }
    }
}
