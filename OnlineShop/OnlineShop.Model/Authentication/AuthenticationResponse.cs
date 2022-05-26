using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model.Authentication
{
    public class AuthenticationResponse
    {
        public int Status { get; set; }
        public UserModel User { get; set; }
    }

    public enum AuthenticationResponseStatus : int
    {
        Succeed,
        Failed
    }
}
