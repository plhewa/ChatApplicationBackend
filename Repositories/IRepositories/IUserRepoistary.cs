using Assignment_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Repositories.IRepositories
{
    public interface IUserRepoistary
    {
        Task<User> AddUserToDBAsync(User user);
        Task<List<User>> GetAllUsersFromDBAsync();
    }
}
