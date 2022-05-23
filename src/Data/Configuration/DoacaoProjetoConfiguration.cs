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
    public class DoacaoProjetoConfiguration : EntidadeBaseConfiguration<DoacaoProjeto>
    {
        public override void Configure(EntityTypeBuilder<DoacaoProjeto> modelBuilder)
        {
            base.Configure(modelBuilder);

            modelBuilder.ToTable("DOACAO_PROJETO");

            modelBuilder
                 .Property("ProjetoId")
                 .HasColumnName("ID_PROJETO");

            modelBuilder
                .HasOne(p => p.Projeto)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey("UsuarioId");

            modelBuilder
                .Property(a => a.Descricao)
                .HasColumnType("varchar(200)")
                .HasColumnName("DESCRICAO");

            modelBuilder
                .Property(a => a.Valor)
                .HasColumnType("decimal")
                .HasColumnName("VALOR");

            modelBuilder.Property(p => p.DataCadastro)
                .HasColumnName("DATA_CADASTRO")
                .HasDefaultValueSql("(getdate())")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
