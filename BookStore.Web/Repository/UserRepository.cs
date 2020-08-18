using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Web.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IList<User>> GetAll()
        {
            var identityUsers = await _userManager.Users.ToListAsync();

            var users = new List<User>();
            foreach (var identityUser in identityUsers)
            {
                var user = new User
                {
                    UserName = identityUser.UserName,
                    Email = identityUser.Email
                };

                users.Add(user);

                user.Roles = await _userManager.GetRolesAsync(identityUser);
            }

            return users;
        }
    }
}
