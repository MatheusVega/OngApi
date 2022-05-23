using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AM.Amil.PeNaAreia.Data.Context;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using AM.Amil.PeNaAreia.Data.Repositories;
using AM.Amil.PeNaAreia.Domain.Entities;

namespace AM.Amil.PeNaAreia.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region dispose

        /***********************************************************************************************************/
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        private readonly PhmContext _context;
        private IUsuarioRepository usuarioRepository = null;
        private IProjetoRepository projetoRepository = null;
        private IUsuarioProjetoRepository usuarioProjetoRepository = null;
        private IDoacaoProjetoRepository doacaoProjetoRepository = null;

        public UnitOfWork(PhmContext context)
        {
            _context = context;
        }
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (usuarioRepository == null)
                {
                    usuarioRepository = new UsuarioRepository(_context);
                }
                return usuarioRepository;
            }
        }
        public IProjetoRepository ProjetoRepository
        {
            get
            {
                if (projetoRepository == null)
                {
                    projetoRepository = new ProjetoRepository(_context);
                }
                return projetoRepository;
            }
        }
        public IUsuarioProjetoRepository UsuarioProjetoRepository
        {
            get
            {
                if (usuarioProjetoRepository == null)
                {
                    usuarioProjetoRepository = new UsuarioProjetoRepository(_context);
                }
                return usuarioProjetoRepository;
            }
        }
        public IDoacaoProjetoRepository DoacaoProjetoRepository
        {
            get
            {
                if (doacaoProjetoRepository == null)
                {
                    doacaoProjetoRepository = new DoacaoProjetoRepository(_context);
                }
                return doacaoProjetoRepository;
            }
        }

        public async Task<bool> CommitAsync()
        {
            var entries = _context.ChangeTracker.Entries()
                    .Where(e => e.Entity is EntidadeBase && (
                    e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntidadeBase)entityEntry.Entity).DataCadastro = DateTime.Now;
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
