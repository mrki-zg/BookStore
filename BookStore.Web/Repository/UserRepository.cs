﻿using System.Collections.Generic;
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

            if (user.Roles != null)
            {
                await _userManager.AddToRolesAsync(identityUser, user.Roles);
            }
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
    }
}
