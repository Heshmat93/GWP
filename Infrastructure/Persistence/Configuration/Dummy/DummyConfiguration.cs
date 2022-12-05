namespace Infrastructure.Persistence.Configuration.Dummy
{
    using Domain.Dummy;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class DummyConfiguration : IEntityTypeConfiguration<Dummy>
    {
        public void Configure(EntityTypeBuilder<Dummy> builder)
        {
            builder.Property(m => m.Description)
            .HasMaxLength(500);
            builder.Property(m => m.RefrenceKey)
           .IsRequired(true);
        }
    }
}
