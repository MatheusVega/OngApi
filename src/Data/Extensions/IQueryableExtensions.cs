using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AM.Amil.PeNaAreia.Domain.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> CarregamentoRapido<T>(this IQueryable<T> query, params
            Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));

            return query;
        }
    }
}
