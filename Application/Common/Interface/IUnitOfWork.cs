namespace Application.Common.Interfaces
{
    using System.Threading.Tasks;
    public interface IUnitOfWork
    {
        //IRepository<AppSetting> AppSettingRepo { get; }
        //IRepository<Category> CategoryRepo { get; }
        //Task<int> SaveAsync();
        //int Save();
        //void BeginTransaction();
        //void CommitTransaction();
        //void RollBackTransaction();
        int Commit();
        Task<int> CommitAsync();
    }
}
