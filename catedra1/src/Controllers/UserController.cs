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

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            var UserDto = users.Select(x => x.ToUser());
            return Ok(UserDto);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser([FromBody] CreateUserDto createUserDto, [FromRoute] int id)
        {
            var userModel = createUserDto.ToUserFromCreatedDto();
            userModel.Id = id;
            await _userRepository.Post(userModel);
            return Ok(userModel);
        }

        /**
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(user);
            return Ok();
        }**/

    }
}