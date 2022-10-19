using Entities;
using Interfaces.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T model)
        {
            _context.Set<T>().Add(model);
        }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }

        public async Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
                return await _context.Set<T>().SingleOrDefaultAsync(expression);

            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);
        }

        public async Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, List<string> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            if (trackChanges)
                return await query.SingleOrDefaultAsync(expression);

            return await query.AsNoTracking().SingleOrDefaultAsync(expression);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges)
                return _context.Set<T>();

            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindAll(List<string> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach(string include in includes)
            {
                query = query.Include(include);
            }

            if (trackChanges)
                return query;

            return query.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
                return _context.Set<T>().Where(expression);

            return _context.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, List<string> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (string include in includes)
            {
                query = query.Include(include);
            }

            if (trackChanges)
                return query.Where(expression);

            return query.Where(expression).AsNoTracking();
        }

        public void Update(T model)
        {
            _context.Set<T>().Update(model);
        }

        public async Task<bool> IsCollectionIdValid(Expression<Func<T, int>> expression, IQueryable<int> ids)
        {
            var validIds = await _context.Set<T>().Select(expression).ToListAsync();

            return ids.All(x => validIds.Contains(x));
        }
    }
}
