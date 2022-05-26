using Microsoft.EntityFrameworkCore;
using OnlineShop.Database.Core;
using OnlineShop.Database.Core.Entity;
using OnlineShop.Infrastructure;
using OnlineShop.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Authentication
{
    public interface IUserManager
    {
        Task<IEnumerable<ApplicationUser>> AllUsers();
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork<CoreDbContext> _coreUnitOfWork;
        public UserManager(IUnitOfWork<CoreDbContext> coreUnitOfWork)
        {
            _coreUnitOfWork = coreUnitOfWork;
        }

        public async Task<IEnumerable<ApplicationUser>> AllUsers()
        {
            var user = new ApplicationUser()
            {
                Email = $"gg.tintran_{Guid.NewGuid().ToString().ToLower()}@gmail.com",
                FullName = $"Tin Tran {Guid.NewGuid().ToString().ToUpper()}",
                Password = $"PASSWORD {Guid.NewGuid().ToString().ToUpper()}"
            };

            await _coreUnitOfWork.Repository<ApplicationUser>().AddAsync(user);

            return await _coreUnitOfWork.Repository<ApplicationUser>().SelectAll().ToListAsync();
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            var response = new AuthenticationResponse();

            var user = await _coreUnitOfWork.Repository<ApplicationUser>().FindAsync(x => x.Email == request.Email);
            if (user == null)
            {
                response.Status = (int)AuthenticationResponseStatus.Failed;
            }
            else
            {
                response.Status = (int)AuthenticationResponseStatus.Succeed;
                response.User = new UserModel()
                {
                    FullName = user.FullName
                };
            }

            return response;
        }
    }
}
