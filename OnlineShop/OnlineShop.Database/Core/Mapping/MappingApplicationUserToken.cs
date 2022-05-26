using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationUserToken : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.HasKey(x => new { x.UserId, x.Provider, x.TokenName });

            builder.Property(x => x.Provider).HasMaxLength(256).IsRequired();
            builder.Property(x => x.TokenName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.TokenValue).HasMaxLength(5000).IsRequired();
            builder.ToTable(nameof(ApplicationUserToken));
        }
    }
}
