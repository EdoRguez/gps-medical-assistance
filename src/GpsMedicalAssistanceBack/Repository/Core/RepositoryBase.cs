using Entities;
using Entities.RequestFeatures;
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

        public async Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, List<IncludesGeneral> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            ManageIncludes(ref query, includes, string.Empty);

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

        public IQueryable<T> FindAll(List<IncludesGeneral> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            ManageIncludes(ref query, includes, string.Empty);

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

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, List<IncludesGeneral> includes, bool trackChanges)
        {
            var query = _context.Set<T>().AsQueryable();

            ManageIncludes(ref query, includes, string.Empty);

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

        public void ManageIncludes(ref IQueryable<T> query, List<IncludesGeneral> includes, string includeQuery)
        {
            foreach (var item in includes)
            {
                includeQuery = String.IsNullOrEmpty(includeQuery) ? item.Name : $"{includeQuery}.{item.Name}";

                if (item.Children.Count > 0)
                    ManageIncludes(ref query, item.Children, includeQuery);
                else
                    query = query.Include(includeQuery);
            }
        }
    }
}
