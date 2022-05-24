using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationRole : BaseEntity
    {
        public ApplicationRole()
        {
            Id = Guid.NewGuid();
            CreatedDate_Utc = DateTime.UtcNow;
            ModifiedDate_Utc = DateTime.UtcNow;

            ConcurrencyStamp = Guid.NewGuid().ToString();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTimeOffset CreatedDate_Utc { get; set; }
        public DateTimeOffset ModifiedDate_Utc { get; set; }

        public void GenerateConcurrencyStamp()
        {
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        public bool HasBeenChanged(string concurrencyStamp)
        {
            return ConcurrencyStamp.Equals(concurrencyStamp, StringComparison.OrdinalIgnoreCase);
        }
    }

}
