using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.Models;
using Microsoft.EntityFrameworkCore;

namespace catedra1.src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
       public DbSet<User> Users { get; set; } = null!;
    }
}