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
    }
}