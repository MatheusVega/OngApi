using Fbr.Library.ManipulacaoDados.ServicoCriptografia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Data.Configuration;

namespace AM.Amil.PeNaAreia.Data.Context
{
    public class PhmContext : DbContext
    {
        public PhmContext()
        {
        }

        public PhmContext(DbContextOptions<PhmContext> options) : base(options)
        {
        }

        #region DbSet        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<UsuarioProjeto> UsuarioProjeto { get; set; }
        public DbSet<DoacaoProjeto> DoacaoProjeto { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioProjetoConfiguration());
            modelBuilder.ApplyConfiguration(new DoacaoProjetoConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
