using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationUserToken : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Provider { get; set; }
        public string TokenName { get; set; }
        public string TokenValue { get; set; } 
    }
}
