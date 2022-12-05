namespace Infrastructure.Persistence.Configuration.IdentityConfiguration
{
    using GWPPlatform.Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => new
            {
                e.Id,
            });
            builder.HasMany(a => a.UserRoles)
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId);

            builder.HasData(
           new Role { Id = new Guid("a2006ffb-9a49-4784-a63b-80929f5216f1"), Name = "Admin", NormalizedName = "ADMIN" },
           new Role { Id = new Guid("151dc82e-7159-46ed-8c63-df7aef02c219"), Name = "Employee", NormalizedName = "EMPLOYEE" },
           new Role { Id = new Guid("151dc82e-7159-46ed-8c63-df7aef02c859"), Name = "System", NormalizedName = "SYSTEM" });

        }
    }
}
