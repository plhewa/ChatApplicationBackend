using Assignment_Backend.Models;
using Assignment_Backend.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend.Repositories.RepositoryImplmentation
{
    public class UserRepositoryImpl : IUserRepoistary
    {
        private readonly MyDbContext _context;

        public UserRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserToDBAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUsersFromDBAsync()
        {
            return await _context.User.ToListAsync();
        }
    }
}
