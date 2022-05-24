using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationUserClaim : BaseEntity
    {
        public ApplicationUserClaim(Guid userId, Guid claimId) 
        {
            UserId = userId;
            ClaimId = claimId;
        }
        public Guid UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
