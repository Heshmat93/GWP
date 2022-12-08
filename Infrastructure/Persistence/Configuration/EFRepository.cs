namespace Infrastructure.Persistence.Configuration
{
    using Application.Common.Interfaces;
    using Application.Models;
    using CleanArchitecture.Application.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    internal class EFRepository<TEntity>
        : IRepository<TEntity>
          where TEntity : class//, IEntity
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable => _dbSet;

        public IQueryable<TEntity> AsQueryableNoTracking => _dbSet.AsNoTracking();

        public async Task<TEntity> GetByIdAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }

        public async Task<IList<TEntity>> GetAllAsync(string[] children)
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (string entity in children)
            {
                query = query.Include(entity);

            }
            return await query.AsNoTracking().ToListAsync();

        }

        public List<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet;

            return query.AsNoTracking().ToList();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IList<TEntity>> GetBy(Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<PaginatedList<TEntity>> GetPaginatedByAsync(PaginationInputModel<TEntity> pagination,Expression<Func<TEntity, bool>> filter = null, string[] children = null)
        {
            IQueryable<TEntity> query = _dbSet;
            var pageNumber =pagination.PageNumber;
            var pageSize =pagination.PageSize;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (children != null)
            {
                foreach (string entity in children)
                {
                    query = query.Include(entity);
                }
            }
            var items= await query.AsNoTracking().Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
            var count = await query.CountAsync();
            return new PaginatedList<TEntity>(items, count, pageNumber, pageSize);

        }
        public async Task<TEntity> Add(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Add(entity);
            }

            return entity;
        }

        public async Task<ICollection<TEntity>> AddRange(ICollection<TEntity> entities)
        {
            _dbSet.AddRange(entities);

            return entities;
        }

        public async Task<ICollection<TEntity>> UpdateRange(ICollection<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);

            return entities;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;

            return entity;
        }

        public async Task<TEntity> Delete(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            //Why.
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IQueryable<TEntity>> GetQueryableAsNoTracking()
        {

            return _dbSet.AsNoTracking();
        }
        //public async Task<List<TEntity>> AddBuilk(List<TEntity> listEntity)
        //{
        //    _context.BulkInsert(listEntity);
        //}

    }
}

//: IRepository<TEntity>  where TEntity : class
//{
//    private readonly ApplicationDBContext  _context;
//    public EFRepository(ApplicationDBContext context)
//    {
//        _context = context;
//    }
//protected virtual DbSet<TEntity> Entities { get; set; }
//public virtual IQueryable<TEntity> Table => Entities;

//public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

//public void Add(TEntity entity)
//{
//    throw new NotImplementedException();
//}

//public Task<int> Count(Expression<Func<TEntity, bool>> where)
//{
//    throw new NotImplementedException();
//}

//public Task<int> Count()
//{
//    throw new NotImplementedException();
//}

//public Task<bool> Delete(TEntity entity)
//{
//    throw new NotImplementedException();
//}

//public Task<bool> Delete(object entity)
//{
//    throw new NotImplementedException();
//}

//public Task<bool> Delete(Expression<Func<TEntity, bool>> where)
//{
//    throw new NotImplementedException();
//}

//public Task<TEntity> Get(object id)
//{
//    throw new NotImplementedException();
//}

//public async Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
//{
//    throw new NotImplementedException();
//}

//public IEnumerable<TEntity> GetAll()
//{
//    throw new NotImplementedException();
//}

//public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
//{
//    throw new NotImplementedException();
//}

//public void Update(TEntity entity)
//{
//    throw new NotImplementedException();
//}
//    }


//}
