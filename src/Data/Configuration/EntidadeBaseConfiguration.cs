using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AM.Amil.PeNaAreia.Domain.Entities;

namespace AM.Amil.PeNaAreia.Data.Configuration
{
    public abstract class EntidadeBaseConfiguration<T> : IEntityTypeConfiguration<T>
    where T : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataCadastro)
                .HasColumnName("DATA_CADASTRO")
                .HasDefaultValueSql("(getdate())")
                .ValueGeneratedOnAdd()
                .IsRequired();                
        }
    }
}
