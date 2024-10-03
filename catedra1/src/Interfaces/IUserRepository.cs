using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.DTOs;
using catedra1.src.Models;

namespace catedra1.src.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> ExistsByRut(string rut);

        Task<User> Post(User user);

        Task<List<User>> GetAll();

        Task<User?> Put(int id, UpdateUserDto updateUserDto);

        Task<User?> Delete(int id);
    }
}