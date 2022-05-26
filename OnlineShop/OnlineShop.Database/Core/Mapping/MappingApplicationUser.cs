using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationUser : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).HasMaxLength(50).IsConcurrencyToken();

            builder.HasMany<ApplicationUserRole>().WithOne().HasForeignKey(ur => ur.UserId);
            builder.HasMany<ApplicationUserClaim>().WithOne().HasForeignKey(uc => uc.UserId);
            builder.HasMany<ApplicationUserLogin>().WithOne().HasForeignKey(ul => ul.UserId);
            builder.HasMany<ApplicationUserToken>().WithOne().HasForeignKey(ut => ut.UserId);
            builder.ToTable(nameof(ApplicationUser));
        }
    }
}
