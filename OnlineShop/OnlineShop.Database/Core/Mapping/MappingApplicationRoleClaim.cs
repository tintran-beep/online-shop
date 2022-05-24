using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationRoleClaim : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.ClaimId });
        }
    }
}
