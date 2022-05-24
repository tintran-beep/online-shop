using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationRoleClaim : BaseEntity
    {
        public ApplicationRoleClaim(Guid roleId, Guid claimId)
        {
            RoleId = roleId;
            ClaimId = claimId;
        }
        public Guid RoleId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
