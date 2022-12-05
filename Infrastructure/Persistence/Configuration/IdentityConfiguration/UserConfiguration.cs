namespace Infrastructure.Persistence.Configuration.IdentityConfiguration
{
    using GWPPlatform.Domain.Enums;
    using GWPPlatform.Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => new
            {
                e.Id
            });
            builder.Property(a => a.NameAr)
                 .IsRequired(true);

            builder.Property(a => a.NameEn)
                    .IsRequired(true);

            builder.Property(a => a.Gender)
                    .IsRequired(true);

            builder.Property(a => a.MobileNo)
                    .IsRequired(true);

            builder.Property(a => a.ProfilePicture)
                    .IsRequired(true);


            builder.HasQueryFilter(a => !a.IsDeleted);



            builder.Property(a => a.IsActive)
                    .IsRequired(true).HasDefaultValue(true);

            builder.HasMany(a => a.UserRoles)
          .WithOne(a => a.User)
          .HasForeignKey(a => a.UserId);


            builder.HasData(new User
            {
                Id = new Guid("ff52237c-7c43-4863-a739-fa38dfab1fa4"),
                PasswordHash = "AQAAAAEAACcQAAAAEBJ52ycs6cJIuClP26C6hXSu2oOW4nL6smqB1fIKxG+n95MjI6vGpHK0JA1eH6L05w==",
                Email = "SuperAdmin@mim.com.sa.com",
                UserName = "SuperAdmin@mim.com.sa.com",
                NameAr = "ادمن",
                NameEn = "Admin",
                Gender = Gender.Male,
                MobileNo = "0557112794",
                ProfilePicture = "string",
            });
            builder.HasData(new User
            {
                Id = new Guid("ff52237c-7c43-4863-a731-fa38dfab1fa4"),
                PasswordHash = "AQAAAAEAACcQAAAAEBJ52ycs6cJIuClP26C6hXSu2oOW4nL6smqB1fIKxG+n95MjI6vGpHK0JA1eH6L05w==",
                Email = "SuperAdmin2@mim.gov.sa",
                UserName = "SuperAdmin2@mim.gov.sa",
                NameAr = "وكالة التحكم الرقمى",
                NameEn = "Digital Control Agency",
                Gender = Gender.Male,
                MobileNo = "05537112794",
                ProfilePicture = "string",
            });










        }
    }
}
