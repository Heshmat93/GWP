namespace Infrastructure.Persistence.Configuration.IdentityConfiguration
{
    using GWPPlatform.Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(e => new
            {
                e.UserId
            });
        }
    }
}
