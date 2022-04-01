using Assignment_Backend.IService;
using Assignment_Backend.Models;
using Assignment_Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.ServiceImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepoistary _userRepoistary;

        public UserService (IUserRepoistary userRepoistary)
        {
            _userRepoistary = userRepoistary;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepoistary.AddUserToDBAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepoistary.GetAllUsersFromDBAsync();
        }
    }
}
