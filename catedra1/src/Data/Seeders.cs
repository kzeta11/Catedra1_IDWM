using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.Models;

namespace catedra1.src.Data
{
    public static class Seeders
    {
        public static async Task SeedData(DataContext context)
        {

            if (context.Users.Any())
            {
                return;
            }

            var generos = new string[] { "masculino", "femenino", "otro", "prefiero no decirlo" };
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var user = new User
                {
                    Rut = $"{random.Next(10000000, 30000000)}-{random.Next(0, 9)}",
                    Nombre = $"Usuario {i}",
                    Correo = $"correo{i}.@gmail.com",
                    Genero = generos[random.Next(0, generos.Length)],
                    FechaNacimiento = new DateTime(random.Next(1950, 2023), random.Next(1, 12), random.Next(1, 28))
        
                };

                await context.Users.AddAsync(user);
            
            }

            await context.SaveChangesAsync();
        }
    }
}