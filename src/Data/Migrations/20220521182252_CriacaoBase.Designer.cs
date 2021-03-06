// <auto-generated />
using System;
using AM.Amil.PeNaAreia.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AM.Amil.PeNaAreia.Data.Migrations
{
    [DbContext(typeof(PhmContext))]
    [Migration("20220521182252_CriacaoBase")]
    partial class CriacaoBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.DoacaoProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRICAO");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROJETO");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal")
                        .HasColumnName("VALOR");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("DOACAO_PROJETO");
                });

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(120)")
                        .HasColumnName("CIDADE");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(120)")
                        .HasColumnName("ESTADO");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("PROJETO");
                });

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("ATIVO");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(14)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_ATUALIZACAO");

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(120)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(120)")
                        .HasColumnName("SENHA");

                    b.HasKey("Id");

                    b.ToTable("USUARIO");
                });

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.UsuarioProjeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATA_CADASTRO")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROJETO");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("ID_USUARIO");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("USUARIO_PROJETO");
                });

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.DoacaoProjeto", b =>
                {
                    b.HasOne("AM.Amil.PeNaAreia.Domain.Entities.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("AM.Amil.PeNaAreia.Domain.Entities.UsuarioProjeto", b =>
                {
                    b.HasOne("AM.Amil.PeNaAreia.Domain.Entities.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AM.Amil.PeNaAreia.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Projeto");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
