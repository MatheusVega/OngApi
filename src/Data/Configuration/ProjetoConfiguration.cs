using AM.Amil.PeNaAreia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Amil.PeNaAreia.Data.Configuration
{
    public class ProjetoConfiguration : EntidadeBaseConfiguration<Projeto>
    {
        public override void Configure(EntityTypeBuilder<Projeto> modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.ToTable("PROJETO");

            modelBuilder
                .Property(a => a.Nome)
                .HasColumnType("varchar(200)")
                .HasColumnName("NOME");

            modelBuilder
                .Property(a => a.Estado)
                .HasColumnType("varchar(120)")
                .HasColumnName("ESTADO");

            modelBuilder
                .Property(a => a.Cidade)
                .HasColumnType("varchar(120)")
                .HasColumnName("CIDADE");

            modelBuilder
                .Property(a => a.Ativo)
                .HasColumnName("ATIVO");

            modelBuilder.Property(p => p.DataCadastro)
                .HasColumnName("DATA_CADASTRO")
                .HasDefaultValueSql("(getdate())")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
