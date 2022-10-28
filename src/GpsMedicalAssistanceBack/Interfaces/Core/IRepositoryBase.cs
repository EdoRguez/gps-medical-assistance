using Entities.RequestFeatures;
using System.Linq.Expressions;

namespace Interfaces.Core
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindAll(List<IncludesGeneral> includes, bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, List<IncludesGeneral> includes, bool trackChanges);
        Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<T> FindSingleByCondition(Expression<Func<T, bool>> expression, List<IncludesGeneral> includes, bool trackChanges);
        Task<bool> IsCollectionIdValid(Expression<Func<T, int>> expression, IQueryable<int> ids);
        void Create(T model);
        void Update(T model);
        void Delete(T model);
        void ManageIncludes(ref IQueryable<T> query, List<IncludesGeneral> includes, string includeQuery);
    }
}
