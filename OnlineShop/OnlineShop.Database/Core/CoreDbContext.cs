using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Core.Entity;
using OnlineShop.Database.Core.Mapping;

namespace OnlineShop.Database.Core
{
    public class CoreDbContext : BaseDbContext
    {
        public CoreDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new MappingApplicationUser().Configure(builder.Entity<ApplicationUser>());
            new MappingApplicationRole().Configure(builder.Entity<ApplicationRole>());
            new MappingApplicationClaim().Configure(builder.Entity<ApplicationClaim>());

            new MappingApplicationUserRole().Configure(builder.Entity<ApplicationUserRole>());
            new MappingApplicationUserClaim().Configure(builder.Entity<ApplicationUserClaim>());
            new MappingApplicationUserLogin().Configure(builder.Entity<ApplicationUserLogin>());
            new MappingApplicationUserToken().Configure(builder.Entity<ApplicationUserToken>());
            new MappingApplicationRoleClaim().Configure(builder.Entity<ApplicationRoleClaim>());
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<ApplicationRole> Roles { get; set; }
        public virtual DbSet<ApplicationClaim> Claims { get; set; }

        public virtual DbSet<ApplicationUserRole> UserRoles { get; set; }
        public virtual DbSet<ApplicationUserClaim> UserClaims { get; set; }
        public virtual DbSet<ApplicationUserLogin> UserLogins { get; set; }
        public virtual DbSet<ApplicationUserToken> UserTokens { get; set; }
        public virtual DbSet<ApplicationRoleClaim> RoleClaims { get; set; }
             
    }
}
