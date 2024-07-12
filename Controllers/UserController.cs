using Microsoft.AspNetCore.Mvc;
using RedbullService.DTOs;
using RedbullService.Models;
using RedbullService.Repositories;
using System.Threading.Tasks;

namespace RedbullService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userRegisterDto)
        {
            var user = new User
            {
                username = userRegisterDto.Username,
                email = userRegisterDto.Email,
                password = userRegisterDto.Password,
                phone_number = userRegisterDto.PhoneNumber
            };

            var createdUser = await _userRepository.Register(user);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.user_id }, createdUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userRepository.Login(userLoginDto.Email, userLoginDto.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            user.username = userUpdateDto.Username;
            user.email = userUpdateDto.Email;
            user.phone_number = userUpdateDto.PhoneNumber;

            await _userRepository.UpdateUser(user);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }
    }
}
