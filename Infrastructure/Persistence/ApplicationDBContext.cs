namespace Infrastructure.Persistence
{
    using Application.Common.Interfaces;
    using Domain.Dummy;
    using GWPPlatform.Domain.Identity;
    using Infrastructure.Persistence.Configuration.IdentityConfiguration;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    public class ApplicationDBContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Dummy> Dummies { get; set; }

        public Task<int> SaveChangeAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
            //modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            //modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            //modelBuilder.ApplyConfiguration(new UserLoginConfiguration());


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }
    }
}
