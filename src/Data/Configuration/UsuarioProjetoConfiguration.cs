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
    public class UsuarioProjetoConfiguration : EntidadeBaseConfiguration<UsuarioProjeto>
    {
        public override void Configure(EntityTypeBuilder<UsuarioProjeto> modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.ToTable("USUARIO_PROJETO");

            modelBuilder
                 .Property("ProjetoId")
                 .HasColumnName("ID_PROJETO");

            modelBuilder
                .HasOne(p => p.Projeto)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("ProjetoId");

            modelBuilder
                 .Property("UsuarioId")
                 .HasColumnName("ID_USUARIO");

            modelBuilder
                .HasOne(p => p.Usuario)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("UsuarioId");

            modelBuilder.Property(p => p.DataCadastro)
                .HasColumnName("DATA_CADASTRO")
                .HasDefaultValueSql("(getdate())")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
