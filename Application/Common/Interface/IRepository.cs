namespace Application.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(params object[] keys);
        Task<IList<TEntity>> GetAllAsync(string[] children);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(object id);
        IQueryable<TEntity> AsQueryableNoTracking { get; }
        IQueryable<TEntity> AsQueryable { get; }
        Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities);
        Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities);
        Task<IList<TEntity>> GetAllAsync();
        List<TEntity> GetAll();
        Task<IList<TEntity>> GetBy(Expression<Func<TEntity, bool>> filter = null, string[] children = null);
        Task<TEntity> Delete(TEntity entity);
    }
}
