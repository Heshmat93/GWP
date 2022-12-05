namespace Infrastructure.Persistence
{
    using Application.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;
        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            var result = await _dbContext.SaveChangesAsync(CancellationToken.None);
            DetachAllEntities();

            return result;
        }
        private void DetachAllEntities()
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted ||
                            e.State == EntityState.Unchanged
                            )
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        //public IRepository<AppSetting> AppSettingRepo => throw new NotImplementedException();

        //public IRepository<Category> CategoryRepo => throw new NotImplementedException();

        //public void BeginTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        //public void CommitTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        //public void RollBackTransaction()
        //{
        //    throw new NotImplementedException();
        //}

        //public int Save()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> SaveAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
