using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationUser : BaseEntity
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            CreatedDate_Utc = DateTime.UtcNow;
            ModifiedDate_Utc = DateTime.UtcNow;

            Status = (int)UserStatus.NEW;

            Enable2FA = false;
            AccessFailedCount = 0;
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string ConcurrencyStamp { get; set; }

        public int Status { get; set; }
        public int AccessFailedCount { get; set; }

        public bool Enable2FA { get; set; }

        public DateTimeOffset CreatedDate_Utc { get; set; }
        public DateTimeOffset ModifiedDate_Utc { get; set; }
        public DateTimeOffset? LockedEndDate_Utc { get; set; }

        public void GenerateConcurrencyStamp()
        {
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }

        public bool HasBeenChanged(string concurrencyStamp)
        {
            return ConcurrencyStamp.Equals(concurrencyStamp, StringComparison.OrdinalIgnoreCase);
        }
    }

    public enum UserStatus : int
    {
        NEW = 0,
        ACTIVED = 1,
        LOCKED = 2,
    }
}
