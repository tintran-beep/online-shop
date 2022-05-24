﻿using System;

namespace OnlineShop.Database.Core.Entity
{
    public class ApplicationUserRole : BaseEntity
    {
        public ApplicationUserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
