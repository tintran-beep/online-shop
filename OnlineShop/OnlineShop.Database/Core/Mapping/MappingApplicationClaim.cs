using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationClaim : IEntityTypeConfiguration<ApplicationClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClaimType).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ClaimType).HasMaxLength(250).IsRequired();

            builder.HasMany<ApplicationRoleClaim>().WithOne().HasForeignKey(rc => rc.ClaimId);
            builder.HasMany<ApplicationUserClaim>().WithOne().HasForeignKey(uc => uc.ClaimId);
        }
    }
}
