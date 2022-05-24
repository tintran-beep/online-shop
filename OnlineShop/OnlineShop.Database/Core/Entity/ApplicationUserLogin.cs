using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationUserLogin : BaseEntity
    {
        public string Provider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public Guid UserId { get; set; } 
    }
}
