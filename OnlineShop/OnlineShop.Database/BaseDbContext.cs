using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Database
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
