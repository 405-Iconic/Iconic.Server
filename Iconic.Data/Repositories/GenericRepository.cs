using Iconic.Data.Contexts;
using Iconic.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Iconic.Data.Repositories
{
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TSource> dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TSource>();
        }

        public async ValueTask<TSource> AddAsync(TSource entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public void Delete(TSource entity)
            => dbSet.Remove(entity);

        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string include = null
            , bool isTracking = true)
        {
            IQueryable<TSource> query = expression is null ? dbSet : dbSet.Where(expression);

            if (!isTracking)
                query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(include))
                foreach (var i in include.Split(','))
                    query = query.Include(i.Trim());

            return query;
        }

        public async ValueTask<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string includes = null)
            => await GetAll(expression, includes).FirstOrDefaultAsync();

        public TSource Update(TSource entity)
            => dbSet.Update(entity).Entity;

        public async ValueTask SaveChangesAsync()
            => await dbContext.SaveChangesAsync();
    }
}
