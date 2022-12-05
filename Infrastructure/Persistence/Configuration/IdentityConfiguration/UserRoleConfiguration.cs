namespace Infrastructure.Persistence.Configuration.IdentityConfiguration
{
    using GWPPlatform.Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => new
            {
                e.RoleId,
                e.UserId
            });
            builder.Property(a => a.UserId)
                .IsRequired(true);

            builder.Property(a => a.RoleId)
                .IsRequired(true);

            builder.HasOne(a => a.User)
                .WithMany(a => a.UserRoles)
                .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.Role)
                .WithMany(a => a.UserRoles)
                .HasForeignKey(a => a.RoleId);

            builder.HasData(new UserRole { RoleId = new Guid("151dc82e-7159-46ed-8c63-df7aef02c859"), UserId = new Guid("ff52237c-7c43-4863-a731-fa38dfab1fa4") });




        }
    }
}
