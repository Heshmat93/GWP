namespace Application.Common.Interfaces
{
    using Domain.Dummy;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public interface IApplicationDBContext
    {
        DbSet<Dummy> Dummies { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangeAsync();
    }
}
