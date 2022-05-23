using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AM.Amil.PeNaAreia.Data.Context;
using AM.Amil.PeNaAreia.Domain.Interfaces.Repositories;
using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Domain.Extensions;

namespace AM.Amil.PeNaAreia.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly PhmContext _contexto;
        private DbSet<TEntity> Entidade { get { return _contexto.Set<TEntity>(); } }

        public BaseRepository(PhmContext contexto)
        {
            _contexto = contexto;
        }

        public TEntity Add(TEntity obj)
        {
            Entidade.Add(obj);
            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public int Count()
        {
            return Entidade.AsNoTracking().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return Entidade.AsNoTracking().Count(where);
        }

        public void Delete(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Deleted;
        }

        public void DeleteAll(IEnumerable<TEntity> objs)
        {
            foreach (var entity in objs)
            {
                Delete(entity);
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Entidade.AsNoTracking().Any(where);
        }

        public async Task<TEntity> GetById(int Id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _contexto.Set<TEntity>() as IQueryable<TEntity>;
            query = query.CarregamentoRapido(includes);
            return await query.FirstOrDefaultAsync(f=> (f as EntidadeBase).Id.Equals(Id));
        }

        public async Task<IEnumerable<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where)
        {
            return await _contexto.Set<TEntity>().Where(where).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _contexto.Set<TEntity>() as IQueryable<TEntity>;
            query = query.CarregamentoRapido(includes);

            return await query.Where(where).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, int start, int limit, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _contexto.Set<TEntity>() as IQueryable<TEntity>;
            query = query.CarregamentoRapido(includes);

            return await query.Where(where).Skip(start).Take(limit).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderby, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _contexto.Set<TEntity>() as IQueryable<TEntity>;
            query = query.CarregamentoRapido(includes);

            return await query.Where(where).OrderBy(orderby).ToListAsync();
        }

        public void Save(TEntity entity) => _contexto.Add(entity);

        public void SaveMany(IEnumerable<TEntity> entity) => _contexto.AddRange(entity);

        public void UpdateRange(List<TEntity> e) => _contexto.Set<TEntity>().UpdateRange(e);
        public async Task<IList<TEntity>> GetAll() => await _contexto.Set<TEntity>().ToListAsync();
    }
}
