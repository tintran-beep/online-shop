using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationRole : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.ConcurrencyStamp).HasMaxLength(50).IsConcurrencyToken();

            builder.HasMany<ApplicationUserRole>().WithOne().HasForeignKey(ur => ur.RoleId);
            builder.HasMany<ApplicationRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId);
        }
    }
}
