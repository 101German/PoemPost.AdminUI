﻿using Microsoft.AspNetCore.Identity;
using PoemPost.STS.Identity.Configuration;
using System.Threading.Tasks;
using PoemPost.Shared.Configuration.Identity;

namespace PoemPost.STS.Identity.Helpers
{
    public class UserResolver<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly LoginResolutionPolicy _policy;

        public UserResolver(UserManager<TUser> userManager, LoginConfiguration configuration)
        {
            _userManager = userManager;
            _policy = configuration.ResolutionPolicy;
        }

        public async Task<TUser> GetUserAsync(string login)
        {
            switch (_policy)
            {
                case LoginResolutionPolicy.Username:
                    return await _userManager.FindByNameAsync(login);
                case LoginResolutionPolicy.Email:
                    return await _userManager.FindByEmailAsync(login);
                default:
                    return null;
            }
        }
    }
}






