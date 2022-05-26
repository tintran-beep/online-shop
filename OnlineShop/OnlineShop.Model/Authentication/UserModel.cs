using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model.Authentication
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string AuthenticationToken { get; set; }
        public List<RoleModel> Roles { get; set; }
        public List<ClaimModel> Claims { get; set; }
    }

}
