using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.Configurations {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("Users");

            builder.HasKey(nameof(User.Id));
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100)
                .HasConversion(
                    username => username.Value,
                    converted => new Username(converted)
                );

            builder.HasIndex(u => u.Username).IsUnique();
        }
    }
}