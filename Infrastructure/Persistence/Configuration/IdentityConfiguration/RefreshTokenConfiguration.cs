namespace Infrastructure.Persistence.Configuration.IdentityConfiguration
{
    using GWPPlatform.Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => new
            {
                e.Id,
            });
            builder.Property(a => a.Id)
                .IsRequired(true);

            builder.Property(a => a.UserId)
                .IsRequired(true);

            builder.Property(a => a.Token)
                .IsRequired(true);

        }
    }
}
