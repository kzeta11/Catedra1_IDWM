using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.DTOs;
using catedra1.src.Models;

namespace catedra1.src.Mapper
{
    public static class UserMapper
    {

        public static UserDto ToUser(this User userModel)
        {
            return new UserDto
            {
                Rut = userModel.Rut,
                Nombre = userModel.Nombre,
                Correo = userModel.Correo,
                Genero = userModel.Genero,
                FechaNacimiento = userModel.FechaNacimiento,
            };
        }
        
    

        public static User ToUserFromCreatedDto(this CreateUserDto createUserDto)
        {
            return new User
            {
                Rut = createUserDto.Rut,
                Nombre = createUserDto.Nombre,
                Correo = createUserDto.Correo,
                Genero = createUserDto.Genero,
                FechaNacimiento = createUserDto.FechaNacimiento,
            };
        }
    }
}