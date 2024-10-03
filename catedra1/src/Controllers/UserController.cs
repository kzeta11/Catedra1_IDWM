using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catedra1.src.DTOs;
using catedra1.src.Interfaces;
using catedra1.src.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace catedra1.src.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {  
        private readonly IUserRepository _userRepository;
        

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            bool exists = await _userRepository.ExistsByRut(createUserDto.Rut);

            if (exists)
            {
                return BadRequest("El usuario ya existe");
            }

            else
            {
                var userModel = createUserDto.ToUserFromCreatedDto();
                await _userRepository.Post(userModel);

                return CreatedAtAction("CreateUser", new {id = userModel.Id}, userModel);
            }
        }

        [HttpGet("")]

        public async Task<IActionResult> GetAllUsers([FromQuery] string? sort = "asc", [FromQuery] string? gender = null)
        {
            // Validaciones de los parámetros
            if (sort != "asc" && sort != "desc")
            {
                return BadRequest("El parámetro 'sort' solo puede tener los valores 'asc' o 'desc'.");
            }

            var validGenders = new List<string> { "masculino", "femenino", "otro", "prefiero no decirlo" };
            if (gender != null && !validGenders.Contains(gender.ToLower()))
            {
                return BadRequest("El parámetro 'gender' no es válido.");
            }
            var users = await _userRepository.GetAll();
            if (!string.IsNullOrEmpty(gender))
            {
                users = users.Where(u => u.Genero.Equals(gender, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            users = sort == "asc" ? users.OrderBy(u => u.Nombre).ToList() : users.OrderByDescending(u => u.Nombre).ToList();

            var userDtos = users.Select(x => x.ToUser());

            return Ok(userDtos);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser([FromBody] CreateUserDto createUserDto, [FromRoute] int id)
        {
            var userModel = createUserDto.ToUserFromCreatedDto();
            userModel.Id = id;
            await _userRepository.Post(userModel);
            return Ok(userModel);
        }

        
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepository.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok("Usuario eliminado");
        }

    }
}