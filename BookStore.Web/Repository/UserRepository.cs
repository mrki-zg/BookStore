using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Web.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IList<User>> GetAll()
        {
            var identityUsers = await _userManager.Users.ToListAsync();

            var users = new List<User>();
            foreach (var identityUser in identityUsers)
            {
                var user = await FromIdentityUser(identityUser);
                users.Add(user);
            }

            return users;
        }

        public async Task<User> Get(string id)
        {
            User user = null;

            var identityUser = await _userManager.FindByIdAsync(id);
            if (identityUser != null)
            {
                user = await FromIdentityUser(identityUser);
            }

            return user;
        }

        public async Task Update(User user)
        {
            var identityUser = await _userManager.FindByIdAsync(user.Id);

            identityUser.Email = user.Email;
            identityUser.UserName = user.UserName;

            await _userManager.UpdateAsync(identityUser);

            var currentAssignedRoles = await _userManager.GetRolesAsync(identityUser);
            await _userManager.RemoveFromRolesAsync(identityUser, currentAssignedRoles);

            if (user.Roles != null)
            {
                await VerifyUserRoleExistence(user.Roles);
                await _userManager.AddToRolesAsync(identityUser, user.Roles);
            }
        }

        public async Task Delete(string id)
        {
            var identityUser = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(identityUser);
        }

        private async Task<User> FromIdentityUser(IdentityUser identityUser)
        {
            return new User
            {
                Id = identityUser.Id,
                UserName = identityUser.UserName,
                Email = identityUser.Email,
                Roles = await _userManager.GetRolesAsync(identityUser)
            };
        }

        private async Task VerifyUserRoleExistence(IList<string> roles)
        {
            if (roles == null || !roles.Any())
            {
                return;
            }

            var currentRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            var newRoles = roles.Except(currentRoles).ToList();
            if (newRoles.Any())
            {
                foreach (var newRole in newRoles.Distinct())
                {
                    await _roleManager.CreateAsync(new IdentityRole(newRole));
                }
            }
        }
    }
}
