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
    public class UsuarioConfiguration : EntidadeBaseConfiguration<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.ToTable("USUARIO");

            modelBuilder
                .Property(a => a.Cpf)
                .HasColumnType("varchar(14)")
                .HasColumnName("CPF");

            modelBuilder
                .Property(a => a.Nome)
                .HasColumnType("varchar(120)")
                .HasColumnName("NOME");

            modelBuilder
                .Property(a => a.Email)
                .HasColumnType("varchar(80)")
                .HasColumnName("EMAIL");


            modelBuilder
                .Property(a => a.Senha)
                .HasColumnType("varchar(120)")
                .HasColumnName("SENHA");

            modelBuilder.Property(p => p.DataAtualizacao)
                .HasColumnName("DATA_ATUALIZACAO");

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