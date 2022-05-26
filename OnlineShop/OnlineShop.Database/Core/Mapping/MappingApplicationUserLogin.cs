using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OnlineShop.Database.Core.Entity;

namespace OnlineShop.Database.Core.Mapping
{
    public class MappingApplicationUserLogin : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.HasKey(x => new { x.Provider, x.ProviderKey });

            builder.Property(x => x.Provider).HasMaxLength(256).IsRequired();
            builder.Property(x => x.ProviderKey).HasMaxLength(256).IsRequired();
            builder.Property(x => x.ProviderDisplayName).HasMaxLength(256).IsRequired();
            builder.ToTable(nameof(ApplicationUserLogin));
        }
    }
}
