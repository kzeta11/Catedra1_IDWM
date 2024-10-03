using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.Data;
using catedra1.src.Interfaces;
using catedra1.src.Models;
using Microsoft.EntityFrameworkCore;

namespace catedra1.src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }



        public async Task<bool> ExistsByRut(string rut)
        {
           return await _context.Users.AnyAsync(x => x.Rut == rut);
        }

        public async Task<User> Post(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}