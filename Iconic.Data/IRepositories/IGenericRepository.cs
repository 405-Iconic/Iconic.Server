﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconic.Data.IRepositories
{
    public interface IGenericRepository<TSource> where TSource : class
    {
        IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string includes = null, bool isTracking = true);
        Task<TSource> AddAsync(TSource entity);
        Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression, string includes = null);
        TSource Update(TSource entity);
        void Delete(TSource entity);
        Task SaveChangesAsync();
    }
}
