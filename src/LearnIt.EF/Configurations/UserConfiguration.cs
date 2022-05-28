using LearnIt.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnIt.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.DeviceId).IsUnique();

            builder
                .HasMany(u => u.Words)
                .WithOne(uw => uw.User);

            builder
                .HasMany(u => u.SelectedCategories)
                .WithOne(uw => uw.User);
        }
    }
}