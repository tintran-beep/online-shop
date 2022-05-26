using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model.Authentication
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ClaimModel> Claims { get; set; }
    }
}
